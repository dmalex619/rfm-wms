-- Calc data for salary (Traffics)
--if object_id('Temp..#TrafficsFiltered') is not Null drop table #TrafficsFiltered
if object_id('Temp..#Traffics1') is not Null drop table #Traffics1
if object_id('Temp..#Traffics2') is not Null drop table #Traffics2
drop table #Traffics1
drop table #Traffics2
drop table #HighCells

declare @nMode tinyint, @bSummary bit
select @nMode = 2, @bSummary = 1

declare @dDateBeg smalldatetime, @dDateEnd smalldatetime
select @dDateBeg = '20080903', @dDateEnd = '20080903'

select C.ID as CellID 
	into #HighCells 
	from Cells C 
	inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ShortCode in ('STOR', 'RILL')

if @nMode = 1 begin
	-- TrafficsFrames Hi
	select B.Name as BrigadeAlias, U.Name as UserAlias, 
		T.DateConfirm, 
		T.RecCount, U.BrigadeID, T.UserID 
		into #Traffics1 
		from (select UserID, convert(varchar, DateConfirm, 112) as DateConfirm, count(*) as RecCount 
				from TrafficsFrames 
				where DateConfirm is not Null and 
					DateDiff(Day, DateConfirm, @dDateBeg) <= 0 and 
					DateDiff(Day, DateConfirm, @dDateEnd) >= 0 and 
					(CellSourceID in (select CellID from #HighCells) or 
					 CellTargetID in (select CellID from #HighCells))
				group by UserID, convert(varchar, DateConfirm, 112)) T
		inner join _Users U on T.UserID = U.ID 
		inner join Brigades B on U.BrigadeID = B.ID 
		order by BrigadeAlias, UserAlias
		
		if @bSummary = 0 
			select * from #Traffics1
		else
			select BrigadeAlias, sum(Reccount) as Points 
				from #Traffics1 group by BrigadeAlias
end
else begin
	-- TrafficsFrames Lo
	select B.Name as BrigadeAlias, U.Name as UserAlias, 
		T.DateConfirm, 
		T.RecCount, U.BrigadeID, T.UserID 
		into #Traffics2 
		from (select UserID, convert(varchar, DateConfirm, 112) as DateConfirm, count(*) as RecCount 
				from TrafficsFrames 
				where DateConfirm is not Null and 
					DateDiff(Day, DateConfirm, @dDateBeg) <= 0 and 
					DateDiff(Day, DateConfirm, @dDateEnd) >= 0 and 
					CellSourceID not in (select CellID from #HighCells) and 
					CellTargetID in (select CellID from #HighCells)
				group by UserID, convert(varchar, DateConfirm, 112)) T
		inner join _Users U on T.UserID = U.ID 
		inner join Brigades B on U.BrigadeID = B.ID 
		order by BrigadeAlias, UserAlias
		
		if @bSummary = 0 
			select * from #Traffics2
		else
			select BrigadeAlias, sum(Reccount) as Points 
				from #Traffics2 group by BrigadeAlias
end

