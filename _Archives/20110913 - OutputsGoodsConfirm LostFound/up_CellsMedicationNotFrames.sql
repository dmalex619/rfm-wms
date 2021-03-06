SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellsMedicationNotFrames]
	@nCellID		int, 
	@nUserID		int, 
	@nDeviceID		int, 
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

-- в таблице #CellsContents находится новое наполнение ячейки
if object_id('tempdb..#CellsContents') is Null begin
	select	@nError = -2, 
			@cErrorStr = 'Не создана таблица с новым состоянием ячейки с кодом ' + @cCellID +  '...'
	raiserror (@cErrorStr, 11, 1);
	return 
end 

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if isNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -3, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	raiserror (@cErrorStr, 11, 1);
	return 
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from	Cells
	where	Address = @cLostFoundAddress
if isNull(@nLostFoundCellID, 0) = 0 begin
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

declare @nGoodStateDefaultID int
select	top 1 @nGoodStateDefaultID = ID	
	from	GoodsStates
	where	Actual = 1 and Basic = 1 

declare @nCellContentID int, @nParentID int, 
		@cChanges varchar(10), @cType varchar(10),
		@nOwnerID int, @nGoodStateID int, 
		@nPackingID int, @nQnt decimal(12, 3), @dDateValid smalldatetime, 
		@nQntOld decimal(15, 3), @nQntNew decimal(15, 3), 
		@dDateValidOld smalldatetime, @dDateValidNew smalldatetime, 
		@nLFCellContentID int 

begin tran 
	-- собственно обновление: для каждого товара
	
	-- 1. измененные товары E (могло поменяться количество и срок годности)
	-- 1.1. Изменилось только количество
	select	'1' as Type, 
			CTemp.ID as CellContentID, 
			CTemp.OwnerID, CTemp.GoodStateID, CTemp.PackingID, 
			CTemp.Qnt - CC.Qnt as Qnt, 
			CC.Qnt as QntOld, 
			CTemp.Qnt as QntNew, 
			CC.DateValid as DateValidOld, 
			CTemp.DateValid as DateValidNew
		into	#CellsContentsE
		from	#CellsContents CTemp
		inner join CellsContents CC on CTemp.ID = CC.ID
		where	CTemp.Changes = 'E' and 
				CTemp.Qnt <> CC.Qnt and 
				1 = 1 -- datediff(day, isNull(CTemp.DateValid, @dMinDate), isNull(CC.DateValid, @dMinDate)) = 0
	
	-- 1.2. Изменился только срок годности (не потребуется Lost&Found)
	insert	#CellsContentsE 
			(Type, CellContentID, 
			OwnerID, GoodStateID, PackingID, 
			Qnt, 
			QntOld, QntNew, 
			DateValidOld, DateValidNew)
		select	'2' as Type, 
				CTemp.ID, 
				CTemp.OwnerID, CTemp.GoodStateID, CTemp.PackingID, 
				CTemp.Qnt - CC.Qnt as Qnt, 
				CC.Qnt as QntOld, 
				CTemp.Qnt as QntNew, 
				CC.DateValid as DateValidOld, 
				CTemp.DateValid as DateValidNew
		from	#CellsContents CTemp
		inner join CellsContents CC on CTemp.ID = CC.ID
		where	CTemp.Changes = 'E' and 
				CTemp.Qnt = CC.Qnt and 
				1 = 2 -- datediff(day, isNull(CTemp.DateValid, @dMinDate), isNull(CC.DateValid, @dMinDate)) <> 0
	
	-- 1.3. Изменилось и количество, и срок годности
	insert	#CellsContentsE 
			(Type, CellContentID, 
			OwnerID, GoodStateID, PackingID, 
			Qnt, 
			QntOld, QntNew, 
			DateValidOld, DateValidNew)
		select	'3' as Type, 
				CTemp.ID, 
				CTemp.OwnerID, CTemp.GoodStateID, CTemp.PackingID, 
				CTemp.Qnt - CC.Qnt as Qnt, 
				CC.Qnt as QntOld, 
				CTemp.Qnt as QntNew, 
				CC.DateValid as DateValidOld, 
				CTemp.DateValid as DateValidNew
		from	#CellsContents CTemp
		inner join CellsContents CC on CTemp.ID = CC.ID
		where	CTemp.Changes = 'E' and 
				CTemp.Qnt <> CC.Qnt and 
				1 = 2 -- datediff(day, isNull(CTemp.DateValid, @dMinDate), isNull(CC.DateValid, @dMinDate)) <> 0
	
	-- есть изменения
	if exists (select Type from #CellsContentsE) begin
		declare C_CellsContentsE cursor for 
			select	Type, CellContentID, 
					OwnerID, GoodStateID, PackingID, Qnt, 
					QntOld, QntNew, DateValidOld, DateValidNew
				from	#CellsContentsE
				order by PackingID
		open C_CellsContentsE
		fetch next from C_CellsContentsE into @cType, @nCellContentID, 
				@nOwnerID, @nGoodStateID, @nPackingID, @nQnt, 
				@nQntOld, @nQntNew, @dDateValidOld, @dDateValidNew
		
		while @@fetch_status = 0 begin
			if @cType = '1' begin 
				-- только количество: 
				-- @nQnt > 0 - товар добавился в текущую ячейку, надо взять его из Lost&Found
				-- @nQnt < 0 - товар удалился из текущей ячейки, надо положить его в Lost&Found
				
				-- 1. Lost&Found
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, -@nQnt, @dDateValidOld, 
							GetDate(), 
							case when @nQnt > 0 
								then 'товар "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')'
								else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
								end,
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@identity 
				
				-- есть такая запись в CellsContents для Lost&Found?
				select	@nLFCellContentID = Null
				select	top 1 @nLFCellContentID = ID
					from	CellsContents 
					where	CellID = @nLostFoundCellID and 
							FrameID is Null and 
							PackingID = @nPackingID and 
							GoodStateID = isNull(@nGoodStateID, @nGoodStateDefaultID) and 
							isNull(OwnerID, -1) = isNull(@nOwnerID, -1)
				if @nLFCellContentID is Null begin 
					insert	CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation)
						select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
							@nPackingID, -@nQnt, Null /*@dDateValidOld*/, GetDate()
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
						select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, @nQnt, @dDateValidNew, 
							GetDate(), 
							case when @nQnt > 0 
								then 'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')' 
								else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
								end,
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@identity 
				
				update CellsContents 
					set	Qnt = Qnt + @nQnt,
						DateLastOperation = GetDate()
					where ID = @nCellContentID
			end
			
			-------------------------------------------------------------
			
			if @cType = '2' begin -- не исп.
				-- только дата
				
				-- 1. Lost&Found - не используется, так как не меняется количество
				
				-- 2. текущая ячейка 
				-- "ушел" товар со старым сроком годности 
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, 
						PackingID, Qnt, DateValid, 
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
							@nPackingID, -@nQntOld, @dDateValidOld, 
							GetDate(), 
							'изменен срок годности товара в ячейке ' + @cCellAddress + ' (ID ' + @cCellID + '): ' + 
								convert(char(10), @dDateValidOld, 104) + '->' + convert(char(10), @dDateValidNew, 104),  
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@identity 
				-- "пришел" товар с новым сроком годности
				insert CellsChanges 
							(CellID, FrameID, OwnerID, GoodStateID, 
							PackingID, Qnt, DateValid, 
							DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
							@nPackingID, @nQntNew, @dDateValidNew, 
							GetDate(), 
							'изменен срок годности товара в ячейке ' + @cCellAddress + ' (ID ' + @cCellID + '): ' + 
								convert(char(10), @dDateValidOld, 104) + '->' + convert(char(10), @dDateValidNew, 104),  
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@identity 
				
				update CellsContents 
					set	DateValid = @dDateValidNew,
						DateLastOperation = GetDate()
					where ID = @nCellContentID
			end 
			
			-------------------------------------------------------------
			
			if @cType = '3' begin -- сейчас не исп.
				-- и количество, и срок годности 
				
				-- 1. Lost&Found
				insert CellsChanges 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
						DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
					select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, 
							-@nQnt, @dDateValidNew, 
							GetDate(), 
							case when @nQnt > 0 
								then 'товар "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')'
								else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
								end,
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@identity 
				
				-- есть такая запись в CellsContents?
				select	@nLFCellContentID = Null
				select	top 1 @nLFCellContentID = ID
					from	CellsContents 
					where	CellID = @nLostFoundCellID and 
							FrameID is Null and 
							PackingID = @nPackingID and 
							GoodStateID = isNull(@nGoodStateID, @nGoodStateDefaultID) and 
							isNull(OwnerID, -1) = isNull(@nOwnerID, -1) and 
							datediff(day, isNull(DateValid, @dMinDate), isNull(@dDateValidNew, @dMinDate)) = 0 
				if @nLFCellContentID is Null begin 
					insert	CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation)
						select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
							@nPackingID, -@nQnt, @dDateValidNew, GetDate()

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
					select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, @nQnt, @dDateValid, 
							GetDate(), 
							case when @nQnt > 0 
								then 'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')' 
								else 'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
									'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')'
								end + 
							', изменен срок годности: ' + 
								convert(char(10), @dDateValidOld, 104) + '->' + convert(char(10), @dDateValidNew, 104), 
							@cNoteManual, @nUserID, @nDeviceID, @nParentID
				select	@nParentID = @@identity 
				
				update CellsContents 
					set	Qnt = Qnt + @nQnt, 
						DateValid = @dDateValidNew,
						DateLastOperation = GetDate()
					where ID = @nCellContentID
			end 
			
			fetch next from C_CellsContentsE into @cType, @nCellContentID, 
					@nOwnerID, @nGoodStateID, @nPackingID, @nQnt, 
					@nQntOld, @nQntNew, @dDateValidOld, @dDateValidNew
		end
		
		close C_CellsContentsE
		deallocate C_CellsContentsE
	end
	
	-- 2. добавленные товары A
	select	OwnerID, GoodStateID, PackingID, Qnt, DateValid
		into	#CellsContentsA
		from	#CellsContents 
		where	Changes = 'A'
	if @@RowCount > 0 begin 
		declare C_CellsContentsA cursor for 
			select	OwnerID, GoodStateID, PackingID, Qnt, DateValid
				from	#CellsContentsA
				order by PackingID
		open C_CellsContentsA
		fetch next from C_CellsContentsA into @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
		
		while @@fetch_status = 0 begin
			-- 1. Lost&Found
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, 
						-@nQnt, @dDateValid, 
						GetDate(), 
						'товар "создан" в вирт.ячейке ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'для перемещения в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						@cNoteManual, @nUserID, @nDeviceID, @nParentID
			select	@nParentID = @@identity 
			
			-- есть такая запись в CellsContents?
			select	@nLFCellContentID = Null
			select	top 1 @nLFCellContentID = ID
				from	CellsContents 
				where	CellID = @nLostFoundCellID and 
						FrameID is Null and 
						PackingID = @nPackingID and 
						GoodStateID = isNull(@nGoodStateID, @nGoodStateDefaultID) and 
						isNull(OwnerID, -1) = isNull(@nOwnerID, -1)
			if @nLFCellContentID is Null begin 
				insert	CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation)
					select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
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
				select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, @nQnt, @dDateValid, 
						GetDate(), 
						'товар "перемещен" из вирт.ячейки ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'в ячейку ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						@cNoteManual, @nUserID, @nDeviceID, @nParentID
			select	@nParentID = @@identity 
			
			-- есть такая запись в CellsContents?
			select	@nCellContentID = Null
			select	top 1 @nCellContentID = ID
				from	CellsContents 
				where	CellID = @nCellID and 
						FrameID is Null and 
						PackingID = @nPackingID and 
						GoodStateID = isNull(@nGoodStateID, @nGoodStateDefaultID) and 
						isNull(OwnerID, -1) = isNull(@nOwnerID, -1)
			if @nCellContentID is Null begin 
				insert	CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid,DateLastOperation)
					select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
						@nPackingID, @nQnt, Null, GetDate()

			end
			else begin 
				update CellsContents 
					set	Qnt = Qnt + @nQnt,
						DateLastOperation = GetDate()
					where ID = @nCellContentID 
			end 
			
			fetch next from C_CellsContentsA into @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
		end
		
		close C_CellsContentsA
		deallocate C_CellsContentsA
	end
	
	-- 3. удаленные товары D
	select	CC.ID * 1 as CellContentID, 
			CTemp.OwnerID, CTemp.GoodStateID, CTemp.PackingID, 
			CC.Qnt, CC.DateValid
		into	#CellsContentsD
		from	#CellsContents CTemp
		inner join CellsContents CC on CTemp.ID = CC.ID
		where	CTemp.Changes = 'D' and CTemp.ID is not Null
	if @@RowCount > 0 begin 
		declare C_CellsContentsD cursor for 
			select	CellContentID, OwnerID, GoodStateID, PackingID, Qnt, DateValid
				from	#CellsContentsD
				order by PackingID
		open C_CellsContentsD
		fetch next from C_CellsContentsD into @nCellContentID, 
			@nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
		
		while @@fetch_status = 0 begin
			-- 1. Lost&Found
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, 
						@nQnt, @dDateValid, 
						GetDate(), 
						'товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						@cNoteManual, @nUserID, @nDeviceID, @nParentID
			select	@nParentID = @@identity 
			
			-- есть такая запись в CellsContents для Lost&Found?
			select	@nLFCellContentID = Null
			select	top 1 @nLFCellContentID = ID
				from	CellsContents 
				where	CellID = @nLostFoundCellID and 
						FrameID is Null and 
						PackingID = @nPackingID and 
						GoodStateID = isNull(@nGoodStateID, @nGoodStateDefaultID) and 
						isNull(OwnerID, -1) = isNull(@nOwnerID, -1)
			if @nLFCellContentID is Null begin 
				insert	CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation)
					select	@nLostFoundCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), 
						@nPackingID, @nQnt, Null /*@dDateValid*/, GetDate()
			end
			else begin 
				update CellsContents 
					set	Qnt = Qnt + @nQnt,
						DateLastOperation = GetDate()
					where ID = @nLFCellContentID 
			end 
			
			-- 2. текущая ячейка 
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, NoteManual, UserID, DeviceID, ParentID) 
				select	@nCellID, Null, @nOwnerID, isNull(@nGoodStateID, @nGoodStateDefaultID), @nPackingID, -@nQnt, @dDateValid, 
						GetDate(), 
						'весь товар "перемещен" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ') ' + 
							'из ячейки ' + @cCellAddress + ' (ID ' + @cCellID + ')', 
						@cNoteManual, @nUserID, @nDeviceID, @nParentID
			select	@nParentID = @@identity 
			
			delete CellsContents 
				where ID = @nCellContentID 
			
			fetch next from C_CellsContentsD into @nCellContentID, 
				@nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid
		end
		
		close C_CellsContentsD
		deallocate C_CellsContentsD
	end
	----- END -----

	-- очистить пустые записи в Lost&Found
	exec up_CellsContentsClearEmpty @nLostFoundCellID

commit tran
return

tr_err:
rollback tran
return