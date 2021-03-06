SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellsMassMedicationNotFrames]
	@nCellID		int, 
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
	where	ID = @nCellID and Deleted = 0 
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Нет ячейки с кодом ' + ltrim(str(@nCellID)) +  '...'
	RaisError (@cErrorStr, 16, 1)
	return 
end

-- в таблице #CellsContents находится старое и новое наполнение ячейки
if object_id('tempdb..#CellsContents') is Null begin
	select	@nError = -2, 
			@cErrorStr = 'Не создана таблица со списком содержимого ячейки ' + @cCellAddress +  '...'
	RaisError (@cErrorStr, 16, 1)
	return 
end 

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if isNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -3, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	RaisError (@cErrorStr, 16, 1)
	return 
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from	Cells
	where	Address = @cLostFoundAddress
if isNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -4, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	RaisError (@cErrorStr, 16, 1)
	return 
end 

if @nCellID = @nLostFoundCellID begin
	select	@nError = -5, 
			@cErrorStr = 'Для виртуальной ячейки (Lost&Found) с адресом ' + @cLostFoundAddress + ' операция исправления запрещена...'
	raiserror (@cErrorStr, 11, 1);
	return 
end

select  CellContentID, PackingID, 
		GoodStateID_Before, OwnerID_Before, 
		GoodStateID_After, OwnerID_After, 
		Qnt_Before, Qnt_After
	into #CC 
	from #CellsContents 
	where Qnt_Before != Qnt_After or 
		isNull(GoodStateID_Before, -1) != isNull(GoodStateID_After, -1) or 
		isNull(OwnerID_Before, -1) != isNull(OwnerID_After, -1)
if @@RowCount = 0 begin
	select	@nError = -5, 
			@cErrorStr = 'Нет изменений в содержимом ячейки с адресом ' + @cCellAddress + '...'
	RaisError (@cErrorStr, 16, 1)
	return 
end 
	
declare @nCellContentID int, @nParentID int, 
		@nPackingID int, @nQnt decimal(12, 3), 
		@nGoodStateID_Before int, @nOwnerID_Before int, 
		@nGoodStateID_After int, @nOwnerID_After int, 
		@nQnt_Before decimal(12, 3), @nQnt_After decimal(12, 3), 
		@nLFCellContentID int, 
		@cNote varchar(250), 
		@nCCError int, @cCCErrorStr varchar(200)
		 
begin tran 
	-- собственно обновление: для каждого измененного товара. сам товар не меняется!
	declare C_ cursor for 
		select	CellContentID, PackingID, 
				GoodStateID_Before, OwnerID_Before, 
				GoodStateID_After, OwnerID_After, 
				Qnt_Before, Qnt_After 
			from #CC
			order by PackingID
	open C_
	fetch next from C_ into @nCellContentID, @nPackingID, 
			@nGoodStateID_Before, @nOwnerID_Before, 
			@nGoodStateID_After, @nOwnerID_After, 
			@nQnt_Before, @nQnt_After
	while @@fetch_status = 0 begin
		if  isNull(@nGoodStateID_Before, -1) != isNull(@nGoodStateID_After, -1) or 
			isNull(@nOwnerID_Before, -1) != isNull(@nOwnerID_After, -1) begin 

			-- полное изменение: все старое списать, все новое положить	

			-- 1) списываем старое из текущей ячейки в L&F
			select @nCCError = 0, @cCCErrorStr = '', 
					@cNote = 'товар "перемещен" из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ') ' + 
						'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')'
			exec up_CellsChangesNotFramesCreate 
				@nCellID, @nLostFoundCellID, 
				@nOwnerID_Before, @nGoodStateID_Before, 
				@nPackingID, @nQnt_Before, 
				@nUserID, @cNote, @cNoteManual, 
				@nCCError output, @cCCErrorStr output
			if @nCCError != 0 goto NextCC
			/*
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, Null, @nOwnerID_Before, @nGoodStateID_Before, 
						@nPackingID, -@nQnt_Before, Null, 
						GetDate(), 
						'товар "перемещен" из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ') ' + 
								'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')',
						@cNoteManual, @nUserID, Null, @nParentID
			select	@nParentID = @@identity 
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID_Before, @nGoodStateID_Before, 
						@nPackingID, @nQnt_Before, Null, 
						GetDate(), 
						'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
								'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						@cNoteManual, @nUserID, Null, @nParentID
			select	@nParentID = @@identity 

			-- есть такая запись в CellsContents для Lost&Found?
			select	@nLFCellContentID = Null
			select	top 1 @nLFCellContentID = ID
				from	CellsContents 
				where	CellID = @nLostFoundCellID and 
						FrameID is Null and 
						PackingID = @nPackingID and 
						GoodStateID = @nGoodStateID_Before and 
						isNull(OwnerID, -1) = isNull(@nOwnerID_Before, -1)
			if @nLFCellContentID is Null begin 
				insert	CellsContents 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation)
					select	@nLostFoundCellID, Null, @nOwnerID_Before, @nGoodStateID_Before, 
						@nPackingID, @nQnt_Before, Null, GetDate()
			end
			else begin 
				update CellsContents 
					set	Qnt = Qnt + @nQnt_Before,
						DateLastOperation = GetDate()
					where ID = @nLFCellContentID 
			end 
			*/

			-- 2) добавляем новое из ячейки L&F в текущую 
			select  @nCCError = 0, @cCCErrorStr = '', 
					@cNote = 'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
						'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')'
			exec up_CellsChangesNotFramesCreate 
				@nLostFoundCellID, @nCellID, 
				@nOwnerID_After, @nGoodStateID_After, 
				@nPackingID, @nQnt_After, 
				@nUserID, @cNote, @cNoteManual, 
				@nCCError output, @cCCErrorStr output
			if @nCCError != 0 goto NextCC
			/*
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID_After, @nGoodStateID_After, 
						@nPackingID, -@nQnt_After, Null, 
						GetDate(), 
						'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
								'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						@cNoteManual, @nUserID, Null, @nParentID
			select	@nParentID = @@identity 
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, Null, @nOwnerID_After, @nGoodStateID_After, 
						@nPackingID, @nQnt_After, Null, 
						GetDate(), 
						'товар "перемещен" в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ') ' + 
							'из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')', 
						@cNoteManual, @nUserID, Null, @nParentID
			select	@nParentID = @@identity 

			update CellsContents 
				set	GoodStateID = @nGoodStateID_After, OwnerID = @nOwnerID_After, 
					Qnt = @nQnt_After,
					DateLastOperation = GetDate()
				where ID = @nCellContentID
			*/
		end 
		else begin 
			-- только изменение количества 
			set @nQnt = @nQnt_Before - @nQnt_After

			select @nCCError = 0, @cCCErrorStr = '',
					@cNote = case when @nQnt < 0 
					then 'товар "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')'
					else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
					end
			exec up_CellsChangesNotFramesCreate 
				@nCellID, @nLostFoundCellID, 
				@nOwnerID_Before, @nGoodStateID_Before, 
				@nPackingID, @nQnt, 
				@nUserID, @cNote, @cNoteManual, 
				@nCCError output, @cCCErrorStr output
			if @nCCError != 0 goto NextCC

			/*
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID_Before, @nGoodStateID_Before, 
						@nPackingID, -@nQnt, Null, 
						GetDate(), 
						case when @nQnt > 0 
							then 'товар "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')'
							else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
						end,
						@cNoteManual, @nUserID, Null, @nParentID
			select	@nParentID = @@identity 
				
			-- есть такая запись в CellsContents для Lost&Found?
			select	@nLFCellContentID = Null
			select	top 1 @nLFCellContentID = ID
				from	CellsContents 
				where	CellID = @nLostFoundCellID and 
						FrameID is Null and 
						PackingID = @nPackingID and 
						GoodStateID = @nGoodStateID_Before and 
						isNull(OwnerID, -1) = isNull(@nOwnerID_Before, -1)
			if @nLFCellContentID is Null begin 
				insert	CellsContents 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation)
					select	@nLostFoundCellID, Null, @nOwnerID_Before, @nGoodStateID_Before, 
						@nPackingID, -@nQnt, Null, GetDate()
			end
			else begin 
				update CellsContents 
					set	Qnt = Qnt - @nQnt,
						DateLastOperation = GetDate()
					where ID = @nLFCellContentID 
			end 
			
			-- 2. текущая ячейка 
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, Null, @nOwnerID_Before, @nGoodStateID_Before, 
						@nPackingID, @nQnt, Null, 
						GetDate(), 
						case when @nQnt > 0 
							then 'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
								'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')' 
							else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
								'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
							end,
						@cNoteManual, @nUserID, Null, @nParentID
			select	@nParentID = @@identity 
			
			update CellsContents 
				set	Qnt = Qnt + @nQnt,
					DateLastOperation = GetDate()
				where ID = @nCellContentID
			*/ 
		end
		
NextCC:
		fetch next from C_ into @nCellContentID, @nPackingID, 
				@nGoodStateID_Before, @nOwnerID_Before, 
				@nGoodStateID_After, @nOwnerID_After, 
				@nQnt_Before, @nQnt_After
	end
	close C_
	deallocate C_

	-- очистить пустые записи в Lost&Found и в текущей ячейке 
	exec up_CellsContentsClearEmpty @nLostFoundCellID
	exec up_CellsContentsClearEmpty @nCellID

commit tran
return

tr_err:
rollback tran
return