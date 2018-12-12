set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsForInputsClear]
	@nUserID		int = Null, 
	@nError			int = 0 output, 
	@cErrorStr		varchar(200) = '' output
AS
-- "Очистка" приходных ячеек от неконтейнерных товаров
-- Данная процедура может применятся для быстрой очистки 
-- приемных ячеек перед проведением ревизии

-- ячейки, подвергающиеся очистке
select C.ID * 1 as CellID, C.Address as CellAddress 
	into #Cells 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where	SZT.ShortCode = 'IN' and SZT.ForInputs = 1 and 
			C.Actual = 1 and C.Deleted = 0 and C.Locked = 0
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Нет приходных ячеек...'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- текущее содержимое этих ячеек (неконтейнерное)
select CC.ID, CC.CellID, C.CellAddress, CC.OwnerID, CC.GoodStateID, 
		CC.PackingID, CC.Qnt, CC.DateValid 
	into #CellsContents 
	from CellsContents CC with (nolock) 
	inner join #Cells C on CC.CellID = C.CellID 
	where CC.FrameID is Null and CC.Qnt <> 0 and CC.GoodStateID is not Null		-- на всякий случай
if @@RowCount = 0 begin
	select	@nError = -2, 
			@cErrorStr = 'В приходных ячейках нет товаров без контейнеров...'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- не нужно ли вычесть из них товары обработанных, но неподтвержденных приходов?
-- пока нет

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
	-- идем по "лишним" товарам и переписываем их в Lost&Found
	declare @nLFCellContentID int, @nParentID int, @cCellID varchar(20)
	declare @nCellContentID int, @nCellID int, @cCellAddress varchar(20), 
		@nOwnerID int, @nGoodStateID int, @nPackingID int, @nQnt decimal(15, 3), @dDateValid smalldatetime
	declare C_CellsContents cursor for 
		select ID, CellID, CellAddress, OwnerID, GoodStateID, PackingID, Qnt, DateValid 
			from #CellsContents 
			order by OwnerID, GoodStateID, PackingID
	open C_CellsContents
	
	fetch next from C_CellsContents into 
		@nCellContentID, @nCellID, @cCellAddress, 
		@nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
	while @@fetch_status = 0 begin
		select @nLFCellContentID = Null, @nParentID = Null, @cCellID = ltrim(rtrim(str(@nCellID)))
		
		-- "списываем" лишний товар из текущей ячейки
		insert CellsChanges 
				(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
				DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
			select	@nCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, @dDateValid, 
					GetDate(), 
					'товар "перемещен" из прих.ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ') '+ 
						'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')', 
					'"очистка" приходных ячеек', @nUserID, Null, @nParentID
		select @nParentID = @@Identity, @nError = @@Error
		if @nError <> 0 goto tr_err_c
		
		-- вместо обнуления количества в приходной ячейке просто удаляем запись
		delete CellsContents 
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
						'из прих.ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
					'"очистка" приходных ячеек', @nUserID, Null, @nParentID
		select @nParentID = @@Identity, @nError = @@Error
		if @nError <> 0 goto tr_err_c
		
		-- есть такая запись в CellsContents для Lost&Found?
		select top 1 @nLFCellContentID = ID 
			from CellsContents 
			where CellID = @nLostFoundCellID and 
					FrameID is Null and 
					PackingID = @nPackingID and 
					GoodStateID = @nGoodStateID and 
					IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
		if @nLFCellContentID is Null begin
			-- добавление записи
			insert CellsContents 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation) 
				select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, Null, GetDate()
		end
		else begin
			-- обновление записи
			update CellsContents 
				set	Qnt = Qnt + @nQnt, DateLastOperation = GetDate() 
					where ID = @nLFCellContentID
		end
		select @nError = @@Error
		if @nError <> 0 goto tr_err_c
		
		fetch next from C_CellsContents into 
			@nCellContentID, @nCellID, @cCellAddress, 
			@nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
	end
	close C_CellsContents
	deallocate C_CellsContents
	
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