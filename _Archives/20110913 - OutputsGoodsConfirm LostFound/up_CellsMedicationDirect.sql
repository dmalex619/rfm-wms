SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellsMedicationDirect]
	@nCellID		int, 
	@nGoodStateID	int,
	@nOwnerID		int,
	@nPackingID		int, 
	@nQnt			decimal (15, 3), 
 	@nUserID		int, 
	@cNoteManual	varchar(200), 
	@nError			int = 0 output, -- 
	@cErrorStr		varchar(200) = '' output
AS

-- ячейка есть? адрес
declare	@cCellAddress varchar(20), @cCellID varchar(20)
select	@cCellAddress = Address, 
		@cCellID = ltrim(str(ID))
	from	Cells with (nolock) 
	where	ID = @nCellID
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Нет ячейки с кодом ' + ltrim(str(@nCellID)) +  '...'
	raiserror (@cErrorStr, 11, 1);
	return 
end

declare @bSeparatePicking bit
set @bSeparatePicking = 0
if @nOwnerID is not Null begin 
	select @bSeparatePicking = SeparatePicking 
		from	Partners with (nolock) 
		where	ID = @nOwnerID 
	if @bSeparatePicking = 0
		set @nOwnerID = Null
end

declare @nFixedOwnerID int, @nFixedGoodStateID int, @nFixedPackingID int
select  @nFixedOwnerID = FixedOwnerID, 
		@nFixedGoodStateID = FixedGoodStateID, 
		@nFixedPackingID = FixedPackingID 
	from	Cells with (nolock) 
	where	ID = @nCellID 
if	@nFixedOwnerID is not Null		and IsNull(@nFixedOwnerID, -1) <> IsNull(@nOwnerID, -1) or 
	@nFixedGoodStateID is not Null	and IsNull(@nFixedGoodStateID, -1) <> IsNull(@nGoodStateID, -1) or 
	@nFixedPackingID is not Null	and IsNull(@nFixedPackingID, -1) <> IsNull(@nPackingID, -1) begin
	select	@nError = -25, 
			@cErrorStr = 'Ячейка ' + @cCellAddress + ' закреплена за другим владельцем/состоянием/товаром...'
	raiserror(@cErrorStr, 16, 1)
	return 
end

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -3, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	raiserror (@cErrorStr, 11, 1);
	return 
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from	Cells
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -4, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	raiserror (@cErrorStr, 11, 1);
	return 
end 

if @nCellID = @nLostFoundCellID begin
	select	@nError = -5, 
			@cErrorStr = 'Для виртуальной ячейки (Lost&Found) с адресом ' + @cLostFoundAddress + ' операция исправления запрещена...'
	raiserror (@cErrorStr, 11, 1);
	return 
end

----- BEGIN ------

set dateformat dmy
declare @dMinDate smalldatetime
set @dMinDate = '19000101'

declare @nLFCellContentID int, @nCellContentID int, @nParentID int 

begin tran 
	-- молча забираем из L&F и записываем в ячейку 	
	select @nParentID = Null
	
	-- 1. Lost&Found
	insert CellsChanges 
			(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
		select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, Null, 
				GetDate(), 
				'товар "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
						'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
				@cNoteManual, @nUserID, Null, @nParentID
	select	@nParentID = @@identity 
	
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
		insert	CellsContents (CellID, FrameID, OwnerID, GoodStateID, 
			PackingID, Qnt, DateValid, DateLastOperation)
			select	@nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, 
				@nPackingID, -@nQnt, Null, GetDate()
	end
	else begin
		update CellsContents 
			set	Qnt = Qnt - @nQnt, DateLastOperation = GetDate()
			where ID = @nLFCellContentID 
	end 
	
	-- 2. текущая ячейка 
	insert CellsChanges 
			(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
		select	@nCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, Null, 
				GetDate(), 
				'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
					'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')',
				@cNoteManual, @nUserID, Null, @nParentID
	select	@nParentID = @@identity 
	
	-- есть такая запись в CellsContents?
	select	@nCellContentID = Null
	select	top 1 @nCellContentID = ID
		from	CellsContents 
		where	CellID = @nCellID and 
				FrameID is Null and 
				PackingID = @nPackingID and 
				GoodStateID = @nGoodStateID and 
				IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
	if @nCellContentID is Null begin 
		insert	CellsContents (CellID, FrameID, OwnerID, GoodStateID, 
			PackingID, Qnt, DateValid,DateLastOperation)
			select	@nCellID, Null, @nOwnerID, @nGoodStateID, 
				@nPackingID, @nQnt, Null, GetDate()
	end
	else begin 
		update CellsContents 
			set	Qnt = Qnt + @nQnt, DateLastOperation = GetDate()
			where ID = @nCellContentID 
	end 
	
	-- очистить пустые записи в Lost&Found
	exec up_CellsContentsClearEmpty @nLostFoundCellID

commit tran
return

tr_err:
rollback tran
return