SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_TrafficsFramesGetList] 
	@cMode			char(1), 
	@cBuilding		char(1) = '', 
	@cFramesList	varchar(max) = ''
AS
-- Получение списка доступных перемещений заданного типа
-- Параметр @cMode: 
--		G - для погрузчика (ground), 
--		H - для штабелера (high),
--		F - для заданного списка контейнеров
set nocount on

-- Проверка режима вызова
if @cMode not in ('G', 'H', 'F') return

-- Обработка списка контейнеров
if len(@cFramesList) > 0 begin
	if left(@cFramesList, 1)  <> ',' set @cFramesList = ',' + @cFramesList
	if right(@cFramesList, 1) <> ',' set @cFramesList = @cFramesList + ','
end

-- Выборка всех перемещений из числа доступных для каждого контейнера
select 
	T.ID, T.FrameID, F.BarCode as FrameBarCode, CC.ByOrder, 
	T.CellSourceID	as SourceID, 
	CS.Address		as SourceAddress, 
	CS.BarCode		as SourceBarCode,
	CS.CBuilding	as SourceBuilding, 
	CS.CLine		as SourceLine, 
	CS.CRack		as SourceRack, 
	CS.CLevel		as SourceLevel, 
	CS.CPlace		as SourcePlace, 
	SZS.Name		as SourceStoreZoneName, 
	SZTS.ShortCode	as SourceShortCode, 
	isnull(CSB.ID, 0)			as SourceBufferID, 
	isnull(CSB.BarCode, '')		as SourceBufferBarCode, 
	isnull(CSB.Address, '')		as SourceBufferAddress, 
	T.CellTargetID	as TargetID, 
	CT.Address		as TargetAddress, 
	CT.BarCode		as TargetBarCode,
	CT.CBuilding	as TargetBuilding, 
	CT.CLine		as TargetLine, 
	CT.CRack		as TargetRack, 
	CT.CLevel		as TargetLevel, 
	CT.CPlace		as TargetPlace, 
	SZT.Name		as TargetStoreZoneName, 
	SZTT.ShortCode	as TargetShortCode, 
	isnull(CTB.ID, 0)			as TargetBufferID, 
	isnull(CTB.BarCode, '')		as TargetBufferBarCode, 
	isnull(CTB.Address, '')		as TargetBufferAddress,
	case when SZTS.ShortCode in ('STOR', 'RILL', 'RILLDIRECT') 
				then 'Снятие ' + CS.Address + (case when SZTS.ShortCode = 'RILLDIRECT' then ' >>> ' else ' > ' end) + CT.Address 
			when SZTT.ShortCode in ('STOR', 'RILL', 'RILLDIRECT') 
				then 'Подъем ' + CS.Address + (case when SZTS.ShortCode = 'RILLDIRECT' then ' >>> ' else ' > ' end) + CT.Address 
			else 'Перем. ' + CS.Address + (case when SZTS.ShortCode = 'RILLDIRECT' then ' >>> ' else ' > ' end) + CT.Address 
			end as Description, 
	T.Priority, T.DateBirth, 
	T.DateSend, T.DateAccept, T.DateConfirm, T.Success, 
	T.UserID, T.DeviceID, T.ErrorID, 
	cast(case when SZTS.ShortCode = 'RILLDIRECT' then 1 else 0 end as Bit) as IsRillDirect, 
	cast(0 as Int) as Indention 
into #_TrafficsFrames 
from TrafficsFrames T with (nolock) 
inner join (select min(ID) as MinID 
				from TrafficsFrames with (nolock) 
				where DateConfirm is Null /*and DateAccept is Null */
				group by FrameID) AT on T.ID = AT.MinID 
inner join Frames F with (nolock) on T.FrameID = F.ID 
inner join Cells CS with (nolock) on T.CellSourceID = CS.ID 
left  join Cells CSB with (nolock) on CS.BufferCellID = CSB.ID 
inner join Cells CT with (nolock) on T.CellTargetID = CT.ID 
left  join Cells CTB with (nolock) on CT.BufferCellID = CTB.ID 
inner join CellsContents CC with (nolock) on CS.ID = CellID and CC.FrameID = F.ID
inner join StoresZones SZS with (nolock) on CS.StoreZoneID = SZS.ID 
inner join StoresZones SZT with (nolock) on CT.StoreZoneID = SZT.ID 
inner join StoresZonesTypes SZTS with (nolock) on SZS.StoreZoneTypeID = SZTS.ID 
inner join StoresZonesTypes SZTT with (nolock) on SZT.StoreZoneTypeID = SZTT.ID 
where T.DateConfirm is Null and 
	T.FrameID not in (select distinct FrameID 
						from TrafficsFrames with (nolock) 
						where DateConfirm is Null and ErrorID is not Null) and 
	(len(@cFramesList) = 0 or 
		charindex(',' + cast(T.FrameID as varchar) + ',', @cFramesList) > 0) 
order by T.Priority, T.DateBirth, T.ID

-- Удаление лишних перемещений
if @cMode in ('H', 'G') begin
	if @cMode = 'H'
		delete #_TrafficsFrames 
			where	SourceShortCode not in ('STOR', 'RILL', 'RILLDIRECT') and 
					TargetShortCode not in ('STOR', 'RILL', 'RILLDIRECT')

	else
		delete #_TrafficsFrames 
			where	 SourceShortCode in ('STOR', 'RILL', 'RILLDIRECT') or 
					(TargetShortCode in ('STOR', 'RILL', 'RILLDIRECT') and 
						SourceBufferID = 0 and TargetBufferID = 0)
end

-- Обработка фильтра по зданию
-- Фильтруем список только в случае, если это имеет смысл
if @cBuilding is not Null and len(@cBuilding) > 0 and 
	exists(select ID from #_TrafficsFrames 
			where SourceBuilding = @cBuilding or TargetBuilding = @cBuilding)
	delete #_TrafficsFrames 
		where SourceBuilding <> @cBuilding and TargetBuilding <> @cBuilding

-- попытка сортировки по удаленности от края ручья прямого доступа
update #_TrafficsFrames  set #_TrafficsFrames.Indention = X.MaxByOrder - #_TrafficsFrames.ByOrder 
	from (select SourceID, max(ByOrder) as MaxByOrder from #_TrafficsFrames 
		where IsRillDirect = 1 group by SourceID having count(SourceID) > 1) X 
	where X.SourceID  = #_TrafficsFrames.SourceID

-- Возврат выборки
if exists(select * from #_TrafficsFrames where Indention != 0)
	select * from #_TrafficsFrames order by Indention, Priority, DateBirth
else
	select * from #_TrafficsFrames
return