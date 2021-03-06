SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellsMedicationFrames]
	@nCellID		int, 
	@nUserID		int, 
	@nDeviceID		int, 
	@cNoteManual	varchar(200), 
	@nError			int = 0 output, 
	@cErrorStr		varchar(200) = '' output
AS

-- ячейка есть? адрес
declare	@cCellAddress varchar(20), @cCellID varchar(20)
select	@cCellAddress = Address, 
		@cCellID = ltrim(str(ID))
	from	Cells with (nolock) 
	where	ID = IsNull(@nCellID, 0)
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Нет ячейки с кодом ' + ltrim(str(@nCellID)) +  '...'
	raiserror (@cErrorStr, 11, 1)
	return
end

-- в таблице #CellsContents находится новое наполнение ячейки
if object_id('tempdb..#CellsContents') is Null begin
	select	@nError = -2, 
			@cErrorStr = 'Не создана таблица с новым состоянием ячейки с кодом ' + @cCellID +  '...'
	raiserror (@cErrorStr, 11, 1)
	return 
end

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -3, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	raiserror (@cErrorStr, 11, 1)
	return 
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from	Cells with (nolock) 
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -4, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	raiserror (@cErrorStr, 11, 1)
	return
end

if @nCellID = @nLostFoundCellID begin
	select	@nError = -5, 
			@cErrorStr = 'Для виртуальной ячейки (Lost&Found) с адресом ' + @cLostFoundAddress + ' операция исправления запрещена...'
	raiserror (@cErrorStr, 11, 1);
	return 
end

-- есть невыполненные транспортировки?
if exists(select T.ID 
				from TrafficsFrames T
				inner join #CellsContents CC on T.FrameID = CC.FrameID
				where DateConfirm is Null and 
					(CellSourceID = IsNull(@nCellID, 0) or CellTargetID = IsNull(@nCellID, 0)) and 
					(CC.Changes = 'A' or CC.Changes = 'D') ) begin 
	select	@nError = -5, 
			@cErrorStr = 'Существуют невыполненные транспортировки контейнеров в ячейку / из ячейки...'
	raiserror (@cErrorStr, 11, 1)
	return
end 

select @cNoteManual = IsNull(@cNoteManual, '')

begin tran 
	-- собственно обновление: для каждого контейнера/товара
	declare @nI int, @nParentID int, 
			@nCellTempID int, @cCellTempAddress varchar(20), 
			@cCellTempID varchar(20), 
			@cChanges varchar(10), 
			@nFrameID int, @nOwnerID int, @nGoodStateID int, 
			@nPackingID int, @nQnt decimal(12, 3), @dDateValid smalldatetime, 
			@cFrameID varchar(20), 
			@nLFCellContentID int
	select	@nI = 0
	declare C_CellsContents cursor for 
		select	Changes, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid
			from	#CellsContents
			order by FrameID, charindex(Changes, ' DA'), PackingID
	open C_CellsContents
	
	fetch next from C_CellsContents into @cChanges, 
		@nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
	while @@fetch_status = 0 begin
		set @cFrameID = ltrim(str(@nFrameID))
		
		-- контейнеры "D" отправляются в Lost&Found 
		-- (в Lost&Found при этом теряется номер контейнера и срок годности)
		if @cChanges = 'D' begin 
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, @dDateValid, 
						GetDate(), 
						'контейнер ' + @cFrameID + ' "удален" из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ') ' + 
							'для "перемещения" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')', 
						@cNoteManual, @nUserID, @nDeviceID, @nParentID
			select	@nParentID = @@Identity 
			
			insert CellsChanges 
				(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
				DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid, 
						GetDate(), 
						'контейнер ' + @cFrameID + ' "перемещен" из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ') ' + 
							'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') и разобран', 
						@cNoteManual, @nUserID, @nDeviceID, @nParentID
			select	@nParentID = @@Identity 

			-- разбираем контейнер по товарам, чтобы разложить его в Lost&Found 
			select @nLFCellContentID = Null
			select @nLFCellContentID = ID
				from CellsContents 
				where CellID = @nLostFoundCellID and 
						FrameID is Null and 
						PackingID = @nPackingID and	
						GoodStateID = @nGoodStateID and 
						IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
			if @nLFCellContentID is Null begin
				-- нет записи для этого товара в Lost&Found. 
				-- просто меняем ячейку и затираем контейнер у текущей записи
				update  CellsContents 
					set		CellID = @nLostFoundCellID,
							FrameID = Null, 
							DateValid = Null, 
							ByOrder = 0, 
							DateLastOperation = GetDate()
					where	CellID = IsNull(@nCellID, 0) and 
							FrameID = @nFrameID and 
							IsNull(PackingID, 0) = IsNull(@nPackingID, 0) and 
							GoodStateID = @nGoodStateID and 
							IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
			end
			else begin 
				-- есть запись для такого товара в Lost&Found
				update CellsContents 
					set Qnt = Qnt + @nQnt, 
						DateLastOperation = GetDate()
					where ID = @nLFCellContentID 
				delete CellsContents 
					where CellID = IsNull(@nCellID, 0) and 
							FrameID = @nFrameID and 
							PackingID = @nPackingID and		
							GoodStateID = @nGoodStateID and 
							IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
			end 
		end
		
		-- контейнеры "A" забираются из своих ячеек и добавляются в текущую ячейку 
		select @nCellTempID = null, @cCellTempID = ''
		if @cChanges = 'A' begin 
			select	@nCellTempID = CellID, 
					@cCellTempID = ltrim(str(CellID))
				from	CellsContents
				where	FrameID = @nFrameID and
						CellID is not Null
			if @nCellTempID is not Null begin
				-- контейнер находится в ячейке @nCellTempID
				select	@cCellTempAddress = Address 
					from	Cells
					where	ID = @nCellTempID

				-- 1. выносим контейнер из старой ячейки
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid,
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nCellTempID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, @dDateValid, 
							GetDate(), 
							'контейнер ' + @cFrameID + ' "удален" из ячейки ' + @cCellTempAddress + ' (ID ' + @cCellTempID + ') ' + 
								'для "перемещения" в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@Identity 
				
				-- 2. добавляем контейнер в текущую ячейку
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nCellID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid, 
							GetDate(), 
							'контейнер ' + @cFrameID + ' "перемещен" из ячейки ' + @cCellTempAddress + ' (ID ' + @cCellTempID + ') ' +   
								'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@Identity
				
				-- изменяем ячейку у содержимого контейнера 
				update  CellsContents 
					set		CellID = @nCellID,
							DateLastOperation = GetDate(), 
							ByOrder = .dbo.GetFrameByOrderInCell(@nFrameID, @nCellID)
					where	FrameID = @nFrameID and 
							PackingID = @nPackingID and 
							GoodStateID = @nGoodStateID and 
							IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
			end
			else begin
				-- контейнер нигде не находится (?)
				-- 1. выносим контейнер из ячейки Lost&Found (потоварно)
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nLostFoundCellID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, @dDateValid, 
							GetDate(), 
							'контейнер ' + @cFrameID + ' "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
								'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@Identity 

				-- разбираем будущий контейнер по товарам 
				select @nLFCellContentID = Null
				select @nLFCellContentID = ID
					from CellsContents 
					where CellID = @nLostFoundCellID and 
							FrameID is Null and 
							PackingID = @nPackingID and		
							GoodStateID = @nGoodStateID and 
							IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
				if @nLFCellContentID is Null begin
					-- нет записи для этого товара в Lost&Found. добавляем
					insert CellsContents 
							(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
							ByOrder, DateLastOperation)
						select @nLostFoundCellID, Null, @nOwnerID, @nGoodStateID, @nPackingID, -@nQnt, Null, 
								0, GetDate()
				end
				else begin 
					-- есть запись для такого товара в Lost&Found
					update CellsContents 
						set Qnt = Qnt - @nQnt, 
							DateLastOperation = GetDate()
						where ID = @nLFCellContentID 
				end 
				
				-- 2. добавляем контейнер в текущую ячейку
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nCellID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid, 
							GetDate(), 
							'контейнер '  + @cFrameID + ' "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
								' в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@Identity 
				
				-- добавляем содержимое контейнера в текущую ячейку - одним контейнером
				insert CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
						ByOrder, DateLastOperation)
					select @nCellID, @nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid, 
							.dbo.GetFrameByOrderInCell(@nFrameID, @nCellID), GetDate()
			end
		end
		
		fetch next from C_CellsContents into @cChanges, 
			@nFrameID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
	end
	
	close C_CellsContents
	deallocate C_CellsContents
	
	-- очистить пустые записи в Lost&Found
	exec up_CellsContentsClearEmpty @nLostFoundCellID

commit tran
return

tr_err:
rollback tran
return