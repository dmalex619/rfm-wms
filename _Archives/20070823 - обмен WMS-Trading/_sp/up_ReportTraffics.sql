set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_ReportTraffics]
	@dDateBegBirth		smalldatetime	= Null, 
	@dDateEndBirth 		smalldatetime	= Null, 
	@dDateBegConfirm	smalldatetime	= Null, 
	@dDateEndConfirm	smalldatetime	= Null, 
	@bConfirmed			bit				= Null, 
	@bSuccess			bit				= Null,
	@cUsersList			varchar(max)	= Null, 
	@cDevicesList		varchar(max)	= Null,
	@cFrameBarCodeContext varchar(100)	= Null
AS

select	@cUsersList			= ',' + replace(@cUsersList,		' ', '') + ',',
		@cDevicesList		= ',' + replace(@cDevicesList,		' ', '') + ','

-- для поиска по списку ячеек
declare @bCellsSource bit 
set @bCellsSource = 0
create table #CellsSource (CellID int)
if object_id('tempdb..#CellsSourceIDList') is not Null begin 
	set @bCellsSource = 1
	insert #CellsSource (CellID)
		select CellID 
			from #CellsSourceIDList
end
else begin
	insert #CellsSource (CellID) 
		values (0)
end

declare @bCellsTarget bit 
set @bCellsTarget = 0
create table #CellsTarget (CellID int)
if object_id('tempdb..#CellsTargetIDList') is not Null begin 
	set @bCellsTarget = 1
	insert #CellsTarget (CellID)
		select CellID 
			from #CellsTargetIDList
end
else begin
	insert #CellsTarget (CellID) 
		values (0)
end

/*
-- для поиска по списку контейнеров 
declare @bFrames bit 
set @bFrames = 0
create table #Frames (FrameID int)
if @cFrameBarCode <> '' begin 
	set @bFrames = 1
	insert #Frames (FrameID)
		select FrameID 
			from Frames
			where charindex(@cFrameBarCode, BarCode) > 0
end
else begin
	insert #Frames (FrameID) 
		values (0)
end
*/

-- 

select	T.ID, T.ID as TrafficID,
		T.PreviousTrafficID, 
		T.FrameID, F.BarCode as FrameBarCode, 
		T.CellSourceID, C_S.Address as CellSourceAddress, C_S.BarCode as CellSourceBarCode, 
		SZ_S.Name as StoreZoneSourceName, SZT_S.Name as StoreZoneTypeSourceName, SZT_S.ShortCode as StoreZoneTypeSourceShortCode, 
		C_S.BufferCellID as BufferCellSourceID, C_S_B.Address as BufferCellSourceAddress, 
		T.CellTargetID, C_T.Address as CellTargetAddress, C_T.BarCode as CellTargetBarCode, 
		SZ_T.Name as StoreZoneTargetName, SZT_T.Name as StoreZoneTypeTargetName, SZT_T.ShortCode as StoreZoneTypeTargetShortCode, 
		C_T.BufferCellID as BufferCellTargetID, C_T_B.Address as BufferCellTargetAddress, 
		T.Priority, T.ByOrder, 
		T.DateBirth, T.DateSend, T.DateAccept, 
		T.DateConfirm, 
		cast(case when T.DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
		T.Success, 
		T.UserID, U.Name as UserName, 
		T.DeviceID, D.Name as DeviceName, 
		T.ErrorID, TE.Name as TrafficErrorName, TE.Severity as TrafficErrorSeverity, 
		F.OwnerID, Ow.Name as FrameOwnerName, 
		F.GoodStateID, GS.Name as FrameGoodStateName, 
		case when T.DateConfirm is Null or T.DateBirth is Null then Null 
			 else DateDiff(mi, T.DateBirth, T.DateConfirm) end as LiveDuration, 
		case when T.DateConfirm is Null or T.DateAccept is Null then Null
			 else DateDiff(mi, T.DateAccept, T.DateConfirm) end as WorkDuration
	from Traffics T 

	inner join #CellsSource CSList on T.CellSourceID = (case when @bCellsSource = 1 then CSList.CellID  else T.CellSourceID end) 
	inner join #CellsTarget CTList on T.CellTargetID = (case when @bCellsTarget = 1 then CTList.CellID  else T.CellTargetID end) 

	left  join Frames F on T.FrameID = F.ID
	inner join Cells C_S on T.CellSourceID = C_S.ID
	left  join Cells C_S_B on C_S.BufferCellID = C_S_B.ID
	inner join Cells C_T on T.CellTargetID = C_T.ID
	left  join Cells C_T_B on C_T.BufferCellID = C_T_B.ID
	inner join StoresZones SZ_S on C_S.StoreZoneID = SZ_S.ID
	inner join StoresZones SZ_T on C_T.StoreZoneID = SZ_T.ID
	inner join StoresZonesTypes SZT_S on SZ_S.StoreZoneTypeID = SZT_S.ID
	inner join StoresZonesTypes SZT_T on SZ_T.StoreZoneTypeID = SZT_T.ID
	left  join TrafficsErrors TE on TE.ID = T.ErrorID
	left  join _Users U on U.ID  = T.UserID
	left  join Devices D	on D.ID  = T.DeviceID
	left  join Partners Ow on F.OwnerID = Ow.ID
	left  join GoodsStates GS on F.GoodStateID = GS.ID
	where	 (@bConfirmed is Null or
				@bConfirmed = 0 and T.DateConfirm is Null or
				@bConfirmed = 1 and T.DateConfirm is not Null) and 
			 (@bSuccess is Null or
				T.Success = @bSuccess) and 
			 (@dDateBegBirth is Null or 
				datediff(day, @dDateBegBirth, T.DateBirth) >= 0) and 
			 (@dDateEndBirth is Null or 
				datediff(day, T.DateBirth, @dDateEndBirth) >= 0) and 
			 (@dDateBegConfirm is Null or 
				datediff(day, @dDateBegConfirm, T.DateConfirm) >= 0) and 
			 (@dDateEndConfirm is Null or 
				datediff(day, T.DateConfirm, @dDateEndConfirm) >= 0) and 
			 (@cUsersList is Null or 
				charindex(',' + ltrim(str(T.UserID)) + ',', @cUsersList) > 0) and 
			 (@cDevicesList is Null or 
				charindex(',' + ltrim(str(T.DeviceID)) + ',', @cDevicesList) > 0) and 
			 (@cFrameBarCodeContext is Null or 
				charindex(@cFrameBarCodeContext, F.BarCode) > 0)
	order by T.DateBirth, U.Name, T.ID