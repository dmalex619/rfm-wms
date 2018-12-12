-- Delete "wrong" AuditAct in WMS because of exchange error
declare @nAuditActID int
set @nAuditActID = 17293



declare @cAuditActID varchar(10), @cCCNote varchar(max), @nError int
select  @cAuditActID = ltrim(str(@nAuditActID)) 
set @cCCNote = 'Акт ' + @cAuditActID + ':'

-- Проверки
-- акт есть? 
if not exists (select ID from AuditActs where ID = @nAuditActID) begin
	RaisError ('Нет акта с заданным кодом...', 11, 1)
	return 
end
-- товары в акте есть?
if not exists (select ID from AuditActsGoods where AuditActID = @nAuditActID) begin
	RaisError ('Нет товаров в акте...', 11, 1)
	return 
end
-- акт еще не проведен?
if (select DateConfirm from AuditActs where ID = @nAuditActID) is Null begin
	RaisError ('Акт еще не проведен...', 11, 1)
	return 
end

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), @cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	RaisError ('Не задан адрес виртуальной ячейки Lost&Found...', 11, 1)
	return 
end 
select	@nLostFoundCellID = ID, @cLostFoundCellID = ltrim(str(ID)) 
	from	Cells
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	RaisError('Не найдена виртуальная ячейка (Lost&Found)...', 11, 1)
	return 
end 

-- Служебные переменные
declare @nOwnerID int, @nGoodStateID int, 
		@nPackingID int, @nQnt decimal(12, 3), 
		@nLFCellContentID int 
select	@nOwnerID = OwnerID, @nGoodStateID = GoodStateID 
	from AuditActs 
	where ID = @nAuditActID
if @nOwnerID is not Null and 
	(select SeparatePicking from Partners where ID = @nOwnerID) = 0 begin
	select @nOwnerID = Null
end 

begin tran 
	-- Delete log
	delete CellsChanges 
		where left(Note, len(@cCCNote)) =  @cCCNote
	if @@Error <> 0 goto tr_err
	
	declare C_AuditActsGoods cursor for 
		select	PackingID, QntConfirmed 
			from AuditActsGoods 
			where AuditActID = @nAuditActID 
			order by PackingID
	open C_AuditActsGoods
	
	fetch next from C_AuditActsGoods into @nPackingID, @nQnt
	while @@fetch_status = 0 begin
			-- есть такая запись в CellsContents для Lost&Found?
		select	@nLFCellContentID = Null
		select	top 1 @nLFCellContentID = ID
			from	CellsContents 
			where	CellID = @nLostFoundCellID and 
					FrameID is Null and 
					PackingID = @nPackingID and 
					GoodStateID = @nGoodStateID and 
					IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
		if @nLFCellContentID is Null begin 
			insert	CellsContents 
					(CellID, FrameID, OwnerID, GoodStateID, 
					PackingID, Qnt, DateValid, DateLastOperation)
				select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, 
						@nPackingID, -@nQnt, Null, GetDate()
			select @nError = @@Error
			if @nError > 0 goto tr_err
		end
		else begin 
			update CellsContents 
				set	Qnt = Qnt - @nQnt, DateLastOperation = GetDate()
				where ID = @nLFCellContentID 
			select @nError = @@Error
			if @nError > 0 goto tr_err
		end
		
		-- таблица остатков Oddments
		declare @nOddmentID int
		set @nOddmentID = Null
		select @nOddmentID = ID 
			from Oddments 
			where PackingID = @nPackingID and GoodStateID = @nGoodStateID and 
				IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
		if @nOddmentID is not Null begin
			update Oddments set Qnt = Qnt - @nQnt 
				where ID = @nOddmentID
			select @nError = @@Error
			if @nError > 0 goto tr_err
		end
		else begin
			insert Oddments (PackingID, GoodStateID, OwnerID, Qnt) 
				select @nPackingID, @nGoodStateID, @nOwnerID, -@nQnt
			select @nError = @@Error
			if @nError > 0 goto tr_err
		end 

		fetch next from C_AuditActsGoods into @nPackingID, @nQnt
	end
	
	close C_AuditActsGoods
	deallocate C_AuditActsGoods
	
	delete AuditActsGoods 
		where AuditActID = @nAuditActID
	if @@Error <> 0 goto tr_err
	
	delete AuditActs 
		where ID = @nAuditActID
	if @@Error <> 0 goto tr_err
	
commit tran
goto tr_end

tr_err:
rollback tran

tr_end:
return