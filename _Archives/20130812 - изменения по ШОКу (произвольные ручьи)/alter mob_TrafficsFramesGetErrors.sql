SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_TrafficsFramesGetErrors] 
	@TrafficFrameID int		-- ID операции контейнерного перемещения
AS
-- Получение списка возможных ошибок для контейнерного перемещения
-- Ошибки фильтруются исходя из данных о начальной и конечной ячейках

set nocount on

-- Получение списка всех ошибок
select * 
	into #Errors 
	from TrafficsFramesErrors with (nolock)

-- Получение данных о перемещении
declare @cSourceType varchar(50), @cTargetType varchar(50), @dDateConfirm smalldatetime
select	@cSourceType = SZTS.ShortCode, 
		@cTargetType = SZTT.ShortCode, 
		@dDateConfirm = TF.DateConfirm 
		from TrafficsFrames TF with (nolock) 
		inner join Cells CS with (nolock) on TF.CellSourceID = CS.ID 
		inner join StoresZones SZS with (nolock) on CS.StoreZoneID = SZS.ID 
		inner join StoresZonesTypes SZTS with (nolock) on SZS.StoreZoneTypeID = SZTS.ID 
		inner join Cells CT with (nolock) on TF.CellTargetID = CT.ID 
		inner join StoresZones SZT with (nolock) on CT.StoreZoneID = SZT.ID 
		inner join StoresZonesTypes SZTT with (nolock) on SZT.StoreZoneTypeID = SZTT.ID 
		where IsNull(@TrafficFrameID, 0) = TF.ID

-- Если перемещение отсутствует - возвращаем пустой список
if @@RowCount = 0 begin
	delete from #Errors
end
else begin
	-- Отсечение неподходящих ошибок
	if @cSourceType not in ('STOR', 'RILL', 'RILLDIRECT')
		delete from #Errors where LockCellSource = 1
	if @cTargetType not in ('STOR', 'RILL', 'RILLDIRECT')
		delete from #Errors where LockCellTarget = 1
	if @cSourceType not in ('STOR', 'RILL', 'RILLDIRECT') and @cTargetType not in ('STOR', 'RILL', 'RILLDIRECT')
		delete from #Errors where LockFrame = 1
end

-- Возврат результата
select ID, Name from #Errors order by Name
return