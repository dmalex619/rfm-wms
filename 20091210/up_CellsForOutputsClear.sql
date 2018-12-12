set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsForOutputsClear]
	@nUserID		int = Null, 
	@nError			int = 0 output, 
	@cErrorStr		varchar(200) = '' output
AS
-- "Очистка" расходных ячеек от неконтейнерных товаров, 
-- за исключением товаров, подготовленных для отгрузки (собраны, но не подтверждены)
-- Данная процедура может применятся для быстрой очистки 
-- ячеек отгрузки перед проведением ревизии

-- ячейки, подвергающиеся очистке
select C.ID * 1 as CellID, C.Address as CellAddress 
	into #Cells 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where	SZT.ShortCode = 'OUT' and SZT.ForOutputs = 1 and 
			C.Actual = 1 and C.Deleted = 0 and C.Locked = 0
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Нет расходных ячеек...'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- текущее содержимое этих ячеек (неконтейнерное)
select CC.CellID, CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt 
	into #CellsContentsX 
	from CellsContents CC with (nolock) 
	inner join #Cells C on CC.CellID = C.CellID 
	where	CC.FrameID is Null and CC.Qnt <> 0
if @@RowCount = 0 begin
	-- ? возможно, в ячейках отгрузки есть недостающие товары, нужные для отправки, что выяснится чуть позже...
	-- ? так что, возможно, тут не нужно выходить...
	select	@nError = -2, 
			@cErrorStr = 'В расходных ячейках нет товаров без контейнеров...'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- добавим к врем. таблице остатков товары, собранные в ячейках отгрузки и готовые к отправке,
-- находящиеся в неподтвержденных расходах, с учетом общего или конкретного владельца (OwnerID)
-- (они уже перенесены в ячейку отгрузку и в ближайщем будущем будут отгружены) -
-- С МИНУСОМ! их не нужно очищать! 
insert #CellsContentsX
		(CellID, OwnerID, GoodStateID, PackingID, Qnt)
	select	OI.CellID, (case when P.SeparatePicking = 1 then O.OwnerID else Null end) as OwnerID, 
			OI.GoodStateID, OI.PackingID, -OI.Qnt
		from OutputsItems OI with (nolock)
		inner join Outputs O with (nolock) on OI.OutputID = O.ID
		inner join Partners P with (nolock) on O.OwnerID = P.ID
		inner join #Cells C on OI.CellID = C.CellID
		where O.DateConfirm is Null --and OI.FrameID is Null

-- будем выравнивать содержимое расходных ячеек под полученные значения 
-- (товары собраны в ячейках отгрузки и готовы к отправке) 
select X.CellID, C.CellAddress, X.OwnerID, X.GoodStateID, X.PackingID, X.Qnt 
	into #CellsContents 
	from (select CellID, OwnerID, GoodStateID, PackingID, sum(Qnt) as Qnt 
			from #CellsContentsX 
			group by CellID, OwnerID, GoodStateID, PackingID) X 
	inner join #Cells C on X.CellID = C.CellID 
	where X.Qnt <> 0
if @@RowCount = 0 begin
	select	@nError = -2, 
			@cErrorStr = 'В расходных ячейках нет товаров, требующих изменения...'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), @cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -3, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	RaisError (@cErrorStr, 11, 1)
	return
end
select	@nLostFoundCellID = ID, @cLostFoundCellID = ltrim(str(ID)) 
	from Cells with (nolock) 
	where Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -4, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	RaisError (@cErrorStr, 11, 1)
	return
end

begin tran
	-- идем по товарам, требующим корректировки, и 
	-- переписываем их в Lost&Found, если они лишние (Qnt > 0) 
	-- либо 
	-- добавляем их из Lost&Found, если они собраны для отгрузки, но их не хватает (Qnt < 0) 
	declare @nCellContentID int, @nCellContentQnt decimal(15, 3), 
			@nLFCellContentID int, @nParentID int, @cCellID varchar(20)
	declare @nCellID int, @cCellAddress varchar(20), 
		@nOwnerID int, @nGoodStateID int, @nPackingID int, @nQnt decimal(15, 3)
	declare C_CellsContents cursor for 
		select CellID, CellAddress, OwnerID, GoodStateID, PackingID, Qnt 
			from #CellsContents 
			order by OwnerID, GoodStateID, PackingID
	open C_CellsContents
	
	fetch next from C_CellsContents 
		into @nCellID, @cCellAddress, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt
	while @@fetch_status = 0 begin
		select	@nCellContentID = Null, 
				@nCellContentQnt = 0, 
				@nLFCellContentID = Null, 
				@nParentID = Null, 
				@cCellID = ltrim(rtrim(str(@nCellID)))
		
		-- есть такая запись в CellsContents для расходной ячейки?
		select top 1 @nCellContentID = ID, @nCellContentQnt = Qnt 
			from CellsContents 
			where	CellID = @nCellID and 
					FrameID is Null and 
					PackingID = @nPackingID and 
					GoodStateID = @nGoodStateID and 
					IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
		if @nError <> 0 goto tr_err_c
		
		-- есть такая запись в CellsContents для Lost&Found?
		select top 1 @nLFCellContentID = ID 
			from CellsContents 
			where	CellID = @nLostFoundCellID and 
					FrameID is Null and 
					PackingID = @nPackingID and 
					GoodStateID = @nGoodStateID and 
					IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
		if @nError <> 0 goto tr_err_c
		
		if @nQnt > 0 begin 
			-- "списываем" лишний товар из текущей расходной ячейки 
			-- (@nQnt > CellsContents.Qnt не может быть, 
			-- так как изначально @nQnt = CellsContents.Qnt, а OutputsInputs.Qnt могло его только уменьшить) 
			
			-- дополнительные проверки в режиме списывания товаров
			if @nCellContentID is Null begin 
				-- не должно быть
				select	@nError = -11, 
						@cErrorStr = 'Не найдено содержимое ячейки ' + @cCellAddress + ' для уменьшения количества товара с кодом ' + ltrim(str(@nPackingID)) + '...' 
				goto tr_err_c
			end
			if @nQnt > @nCellContentQnt begin 
				-- не должно быть, иначе нужно было бы менять количество на "-" число
				select	@nError = -12, 
						@cErrorStr = 'Содержимое ячейки ' + @cCellAddress + ' недостаточно для уменьшения количества товара с кодом ' + ltrim(str(@nPackingID)) + '...' 
				goto tr_err_c
			end
			
			-- расходная ячейка (журнал)
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, Null, 
						GetDate(), 
						'товар "перемещен" из расх.ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ') '+ 
							'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')', 
						'"очистка" расходных ячеек', @nUserID, Null, @nParentID
			select @nParentID = @@Identity, @nError = @@Error
			if @nError <> 0 goto tr_err_c
			
			-- сама расходная ячейка
			update CellsContents set 
				Qnt = Qnt - @nQnt, DateLastOperation = GetDate() 
				where ID = @nCellContentID
			select @nError = @@Error
			if @nError <> 0 goto tr_err_c
			
			-- ячейка Lost&Found
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, Null, 
						GetDate(), 
						'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'из расх.ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						'"очистка" расходных ячеек', @nUserID, Null, @nParentID
			select @nParentID = @@Identity, @nError = @@Error
			if @nError <> 0 goto tr_err_c
			
			if @nLFCellContentID is Null begin
				insert CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation) 
					select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, 
							@nPackingID, @nQnt, Null, GetDate()
			end
			else begin
				update CellsContents set Qnt = Qnt + @nQnt, DateLastOperation = GetDate() 
					where ID = @nLFCellContentID
			end
			select @nError = @@Error
			if @nError <> 0 goto tr_err_c
		end
		else begin 
			-- @nQnt < 0 
			-- "дописываем" недостающий товар в текущую расходную ячейку из Lost&Found 
			set @nQnt = -@nQnt
			
			-- ячейка Lost&Found
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, Null, 
						GetDate(), 
						'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'в расх.ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						'"очистка" расходных ячеек', @nUserID, Null, @nParentID
			select @nParentID = @@Identity, @nError = @@Error
			if @nError <> 0 goto tr_err_c
			
			if @nLFCellContentID is Null begin
				insert CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation) 
					select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, 
							@nPackingID, -@nQnt, Null, GetDate()
			end
			else begin
				update CellsContents set Qnt = Qnt - @nQnt, DateLastOperation = GetDate() 
					where ID = @nLFCellContentID
			end
			select @nError = @@Error
			if @nError <> 0 goto tr_err_c
			
			-- расходная ячейка
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, Null, 
						GetDate(), 
						'товар "перемещен" в расх.ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ') '+ 
							'из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')', 
						'"очистка" расходных ячеек', @nUserID, Null, @nParentID
			select @nParentID = @@Identity, @nError = @@Error
			if @nError <> 0 goto tr_err_c
			
			if @nCellContentID is Null begin
				insert CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation) 
					select	@nCellID, Null, @nOwnerID, @nGoodStateID, 
							@nPackingID, @nQnt, Null, GetDate()
			end
			else begin
				update CellsContents set Qnt = Qnt + @nQnt, DateLastOperation = GetDate() 
					where ID = @nCellContentID
			end
			select @nError = @@Error
			if @nError <> 0 goto tr_err_c
		end
		
		fetch next from C_CellsContents 
			into @nCellID, @cCellAddress, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt
	end
	close C_CellsContents
	deallocate C_CellsContents
	
	-- очистить пустые записи в обработанных ячейках отгрузки 
	declare C_Cells cursor for 
		select CellID
			from #Cells
	open C_Cells
	
	fetch next from C_Cells into @nCellID
	while @@fetch_status = 0 begin
		exec up_CellsContentsClearEmpty @nCellID
		fetch next from C_Cells into @nCellID
	end
	
	close C_Cells
	deallocate C_Cells
	
	-- очистить пустые записи в Lost&Found
	exec up_CellsContentsClearEmpty @nLostFoundCellID

commit tran
return

tr_err_c:
close C_CellsContents
deallocate C_CellsContents

tr_err:
rollback tran
return