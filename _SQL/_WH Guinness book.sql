if object_id('Tempdb.dbo.#_Inputs') is not Null drop table #_Inputs

select U.Name as UserName, II.InputID, 
	dbo.GetInputNetto(I.ID, 1) as InputNetto, 
	sum(II.Qnt / P.InBox / P.BoxInPal) as Pallets, 
	min(II.DateConfirm) as DateMin, max(II.DateConfirm) as DateMax
into #_Inputs 
from _Users U with (nolock) 
inner join InputsItems II with (nolock) on II.UserID = U.ID
inner join Inputs I with (nolock) on II.InputID = I.ID 
inner join Packings P with (nolock) on II.PackingID = P.ID 
where	I.DateConfirm is not Null and 
		I.DateConfirm >= DateAdd(Day, -90, GetDate()) and 
		II.DateConfirm is not Null and 
		II.FrameID is not Null 
group by U.Name, II.InputID, dbo.GetInputNetto(I.ID, 1)
order by U.Name, II.InputID, dbo.GetInputNetto(I.ID, 1)

select UserName, 
	avg(DateDiff(mi, DateMin, DateMax)) as AvgMinutes, 
	count(distinct InputID) as InputCount 
from #_Inputs
	where InputNetto > 18000
	group by UserName
	having count(distinct InputID) >= 10
	order by AvgMinutes

select UserName, 
	round(avg(Pallets) / avg(DateDiff(mi, DateMin, DateMax)), 2) as AvgPalletsPerMinute, 
	round(avg(InputNetto) / avg(DateDiff(mi, DateMin, DateMax)), 2) as AvgNettoPerMinute
from #_Inputs
	where InputNetto > 18000
	group by UserName
	having count(distinct InputID) >= 10
	order by AvgNettoPerMinute desc
