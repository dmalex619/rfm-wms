set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[ws_DraftsConvertWMS]
as 
-- Выполняем в WMS съем контейнеров из ячеек на основании Trading.WHDrafts 
-- Предварительно надо заполнить 
-- update WHDrafts set WMSSent = 1 where DraftType = 'D' and DateConfirm is not Null 

set nocount on

-- Проверка режима работы
if not exists (select Uniq from _GENERAL where Variable = 'glWMS' and Meaning = '.T.') begin
	raiserror(N'WMS не активна...', 11, 1)
	return	
end

declare @nError int, @nCount int

-- 1. получение данных о выполненных WHDrafts (из БД Trading)
select	Uniq, Depot 
	into	#WHDrafts 
	from	WHDrafts D
	where	DateConfirm is not Null and 
			WMSSent = 0 and 
			DateDiff(day, DateConfirm, GetDate()) <= 2 -- ? дата выполнения съема 
if @@RowCount = 0 begin
	print 'No new WHDrafts...'
	return
end

select	DG.Uniq, DG.WHDraft, DG.Packing, 
		DG.Cell, DG.CellAddress, DG.QntConfirmed 
	into	#WHDraftsGoods 
	from	WHDraftsGoods DG
	inner join #WHDrafts TD on DG.WHDraft = TD.Uniq
	where	DG.QntConfirmed > 0 
if @@RowCount = 0 begin
	print 'No new WHDrafts with confirmed Cells...'
	return
end

-------------------------------------------------------------------------------
-- 2. Получение данных о съеме контейнеров из высотной зоны (в БД WMS)

begin tran 
	-- Таблица всех ячеек высотной зоны
	select	C.ID, C.ErpCode, C.StoreZoneID, C.Locked, C.Actual, 
			C.CBuilding + C.CLine + C.CRack + C.CLevel + C.CPlace as CompoundAddress 
		into	#Cells 
		from	WMS.dbo.Cells C 
		inner join WMS.dbo.StoresZones SZ on C.StoreZoneID = SZ.ID 
		inner join WMS.dbo.StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
		where	SZT.ShortCode = 'STOR'
	if @@Error <> 0 goto Tr_Error
	
	-- Ячейки, которые надо очистить
	select	C.ID, C.Locked, C.Actual 
		into	#CellsClear 
		from	#Cells C
		inner join #WHDraftsGoods DG on C.CompoundAddress = DG.CellAddress
	if @@Error <> 0 goto Tr_Error
	
	-- Контейнеры, которые надо удалить
	select	distinct CC.FrameID 
		into	#FramesClear 
		from	WMS.dbo.CellsContents CC 
		inner join #CellsClear C on CC.CellID = C.ID
	if @@Error <> 0 goto Tr_Error
	
	-- Снимаем товар с остатков 
	update	WMS.dbo.Oddments 
		set Qnt = WMS.dbo.Oddments.Qnt - X.Qnt 
		from	(select OwnerID, GoodStateID, PackingID, 
					sum(IsNull(Qnt, 0)) as Qnt 
					from WMS.dbo.CellsContents CC 
					inner join #CellsClear C on C.ID = CC.CellID 
					group by OwnerID, GoodStateID, PackingID) X 
		where	IsNull(Oddments.OwnerID, -1) = IsNull(X.OwnerID, -1) and 
				Oddments.GoodStateID = X.GoodStateID and 
				Oddments.PackingID = X.PackingID
	if @@Error <> 0 goto Tr_Error
	
	-- Проверяем наличие товара в заблокированных ячейках
	-- При начальной перекачке ячейки, занятые в Trading, 
	-- блокируются в WMS и не имеют содержимого
	-- Если такое содержимое обнаружено - это: 
	--		либо заблокировали ячейку с товаром в WMS (чего врядли)
	--		либо косяк программы
	if exists (select top 1 * 
				from #CellsClear C 
				inner join WMS.dbo.CellsContents CC on CC.CellID = C.ID 
				where C.Locked = 1) begin
		raiserror(N'Найдены не пустые заблокированные ячейки!', 16, 1)
		goto Tr_Error
	end
	
	-- Очищаем содержимое ячеек
	delete WMS.dbo.CellsContents 
		from	#CellsClear C 
		where	WMS.dbo.CellsContents.CellID = C.ID
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'CellsContents deleted: ' + ltrim(str(@nCount))
	
	-- Состояние ячейки
	update	WMS.dbo.Cells 
		set		State = Null 
		from	#CellsClear C 
		where	WMS.dbo.Cells.ID = C.ID and WMS.dbo.Cells.State is not Null
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'Cells updated: ' + ltrim(str(@nCount))
	
	-- Если используем временную блокировку ячеек - разблокируем их
	update	WMS.dbo.Cells 
		set		Locked = 0 
		from	#CellsClear C 
		where	WMS.dbo.Cells.ID = C.ID and WMS.dbo.Cells.Locked = 1
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'Cells unlocked: ' + ltrim(str(@nCount))
	
	-- Делаем контейнеры неактуальнымии
	update WMS.dbo.Frames 
		set		Actual = 0, State = 'D' 
		from	#FramesClear FC 
		where	WMS.dbo.Frames.ID = FC.FrameID
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'Frames deleted: ' + ltrim(str(@nCount))
	
	-- Взводим признак обработки задания на съем
	update	WHDrafts 
		set		WMSSent = 1 
		from	#WHDrafts TD 
		where	WHDrafts.Uniq = TD.Uniq
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'WHDrafts sent: ' + ltrim(str(@nCount))

if @@TranCount > 0 commit tran
return

Tr_Error:
if @@TranCount > 0 rollback tran
return