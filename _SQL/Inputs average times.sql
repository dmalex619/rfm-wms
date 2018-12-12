declare @dDateStart smalldatetime, @nMinInputCount int
select @dDateStart = '20080301', @nMinInputCount = 5

-- Среднее время между началом и подтверждением
select P.Name, count(I.ID) as ICount, avg(DateDiff(minute, DateStart, DateConfirm)) as AvgMin
from Inputs I
inner join Partners P on I.PartnerID = P.ID
where I.DateConfirm is not Null and I.DateConfirm >= @dDateStart and 
	DateDiff(Day, DateStart, DateConfirm) <= 1 and I.InputTypeID = 6
group by P.Name
having count(I.ID) >= @nMinInputCount
order by 3 desc

-- Среднее время между началом и выгрузкой первой паллеты
select P.Name, count(I.ID) as ICount, avg(DateDiff(minute, I.DateStart, X.MinDateConfirm)) as AvgMin
from Inputs I
inner join Partners P on I.PartnerID = P.ID
inner join (select InputID, min(DateConfirm) as MinDateConfirm 
			from InputsItems
			group by InputID) X on I.ID = X.InputID 
where I.DateConfirm is not Null and I.DateConfirm >= @dDateStart and 
	DateDiff(Day, DateStart, DateConfirm) <= 1 and I.InputTypeID = 6
group by P.Name
having count(I.ID) >= @nMinInputCount
order by 3 desc

-- Среднее время между приемкой первой и последней паллеты
select P.Name, count(I.ID) as ICount, 
	avg(cast(PCount as dec(6,1))) as PCount, 
	avg(cast(DateDiff(minute, X.MinDateConfirm, X.MaxDateConfirm) as dec(6,1))) as AvgMin, 
	avg(cast(PCount as dec(6,1))) / avg(cast(DateDiff(minute, X.MinDateConfirm, X.MaxDateConfirm) as dec(6,1))) as PalletPerMin
from Inputs I
inner join Partners P on I.PartnerID = P.ID
inner join (select InputID, count(*) as PCount, min(DateConfirm) as MinDateConfirm, max(DateConfirm) as MaxDateConfirm 
			from InputsItems
			group by InputID) X on I.ID = X.InputID 
where I.DateConfirm is not Null and I.DateConfirm >= @dDateStart and 
	DateDiff(Day, DateStart, DateConfirm) <= 1 and I.InputTypeID = 6
group by P.Name
having count(I.ID) >= @nMinInputCount and avg(cast(PCount as dec(6,1))) >= 8
order by 5 desc
