set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[ws_UpdateCells]
-- ? для SuitableWMSWebService
-- Обновление данных о ячейках - съем контейнеров из высотной зоны
AS
set nocount on

-- Проверка существования таблицы (создается в ?WebService)
if object_id('Tempdb.dbo.#WHDrafts') is Null begin
	RaisError(N'Отсутствует временная таблица #WHDrafts', 16, 1)
	return
end
if object_id('Tempdb.dbo.#WHDraftsGoods') is Null begin
	RaisError(N'Отсутствует временная таблица #WHDraftsGoods', 16, 1)
	return
end

-- Обновление и добавление данных
begin tran

	-- таблица ячеек высотной зоны
	select	C.ID, C.ErpCode, C.StoreZoneID, 
			substring(C.Address, len(SZ.NamePrefix) + 1, len(C.Address)) as AddressT
		into	#Cells
		from	Cells C
		inner join StoresZones SZ on C.StoreZoneID = SZ.ID
		inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID
		where	SZT.ShortCode = 'STOR'
	-- приводим адрес к виду как в Trading
	update	#Cells
		set AddressT = left(#Cells.AddressT, charindex(SZ.NameSuffix, #Cells.AddressT) - 1)
		from	StoresZones SZ 
		where	SZ.NameSuffix > '' and 
				charindex(SZ.NameSuffix, AddressT) > 0 and 
				#Cells.StoreZoneID = SZ.ID

	-- ячейки, которые надо очистить
	select	C.ID
		into	#CellsClear 
		from	#Cells C
		inner join #WHDraftsGoods DG on C.AddressT = DG.CellAddress
		
	-- контейнеры, которые надо удалить
	select	distinct CC.FrameID
		into	#FramesClear 
		from	CellsContents CC
		inner join #CellsClear C on CC.CellID = C.ID

	-- очищаем содержимое ячеек
	delete CellsContents 
		from	#CellsClear C 
		where	CellsContents.CellID = C.ID
		
	-- ? состояние ячейки
	update	Cells 
		set		State = Null
		from	#CellsClear C
		where	Cells.ID = C.ID

	-- ? если используем временную блокировку ячеек 
	update	Cells 
		set		Locked = 0
		from	#CellsClear C
		where	Cells.ID = C.ID
	
	-- делаем контейнеры неактуальнымии
	update Frames
		set		Actual = 0 
		from	#FramesClear FC 
		where	Frames.ID = FC.FrameID

commit tran
return

Tr_Error:
rollback
return

