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
select	T.ID, T.FrameID, F.BarCode as FrameBarCode, 
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
		IsNull(CSB.ID, 0)			as SourceBufferID, 
		IsNull(CSB.BarCode, '')		as SourceBufferBarCode, 
		IsNull(CSB.Address, '')		as SourceBufferAddress, 
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
		IsNull(CTB.ID, 0)			as TargetBufferID, 
		IsNull(CTB.BarCode, '')		as TargetBufferBarCode, 
		IsNull(CTB.Address, '')		as TargetBufferAddress, 
		case	when SZTS.ShortCode in ('STOR', 'RILL') 
					then 'Снятие ' + CS.Address + ' > ' + CT.Address 
				when SZTT.ShortCode in ('STOR', 'RILL') 
					then 'Подъем ' + CS.Address + ' > ' + CT.Address 
				else 'Перем. ' + CS.Address + ' > ' + CT.Address end as Description, 
		T.Priority, T.DateBirth, 
		T.DateSend, T.DateAccept, T.DateConfirm, T.Success, 
		T.UserID, T.DeviceID, T.ErrorID 
	into #_TrafficsFrames 
	from TrafficsFrames T with (nolock) 
	inner join (select min(ID) as MinID 
					from TrafficsFrames with (nolock) 
					where DateConfirm is Null /*and DateAccept is Null */
					group by FrameID) AT on T.ID = AT.MinID 
	inner join Frames F with (nolock) on T.FrameID = F.ID 
	inner join Cells CS with (nolock) on T.CellSourceID = CS.ID 
	left join Cells CSB with (nolock) on CS.BufferCellID = CSB.ID 
	inner join Cells CT with (nolock) on T.CellTargetID = CT.ID 
	left join Cells CTB with (nolock) on CT.BufferCellID = CTB.ID 
	inner join StoresZones SZS with (nolock) on CS.StoreZoneID = SZS.ID 
	inner join StoresZones SZT with (nolock) on CT.StoreZoneID = SZT.ID 
	inner join StoresZonesTypes SZTS with (nolock) on SZS.StoreZoneTypeID = SZTS.ID 
	inner join StoresZonesTypes SZTT with (nolock) on SZT.StoreZoneTypeID = SZTT.ID 
	where T.DateConfirm is Null and 
		/*T.DateAccept is Null and */
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
			where	SourceShortCode not in ('STOR', 'RILL') and 
					TargetShortCode not in ('STOR', 'RILL')
	else
		delete #_TrafficsFrames 
			where	 SourceShortCode in ('STOR', 'RILL') or 
					(TargetShortCode in ('STOR', 'RILL') and 
						SourceBufferID = 0 and TargetBufferID = 0)
end

-- Обработка фильтра по зданию
-- Фильтруем список только в случае, если это имеет смысл
if @cBuilding is not Null and len(@cBuilding) > 0 and 
	exists(select ID from #_TrafficsFrames 
			where SourceBuilding = @cBuilding or TargetBuilding = @cBuilding)
	delete #_TrafficsFrames 
		where SourceBuilding <> @cBuilding and TargetBuilding <> @cBuilding

-- Возврат выборки
select * from #_TrafficsFrames
return