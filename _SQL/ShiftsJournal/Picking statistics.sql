-- Picking statistics
if OBJECT_ID('Tempdb.dbo.#PickStat') is not Null drop table #PickStat

-- Пикинг
/*select	SJ.ID as ShiftID, SJ.DateBeg, SJ.DateEnd, SJ.IsNight, 
		SJ.MajorID, min(M.Name) as MajorName, 
		OI.UserID as PickingUserID, min(E.Name) as PickingUserName, 
		sum((OI.Qnt % (P.InBox * P.BoxInPal)) / P.InBox) as Boxes 
--		sum(OI.Qnt / P.InBox) as Boxes 
	into #PickStat 
	from Shifts SJ with (nolock) 
	inner join OutputsItems OI with (nolock) on OI.DateConfirm > SJ.DateBeg and OI.DateConfirm <= SJ.DateEnd 
	inner join _Users M with (nolock) on SJ.MajorID = M.ID 
	inner join _Users E with (nolock) on OI.UserID = E.ID 
	inner join Packings P with (nolock) on OI.PackingID = P.ID 
	where OI.FrameID is Null and OI.Qnt > 0 
	group by SJ.ID, SJ.DateBeg, SJ.DateEnd, SJ.IsNight, SJ.MajorID, OI.UserID
	order by SJ.ID, 5,7*/
select	SJ.ID as ShiftID, SJ.DateBeg, SJ.DateEnd, SJ.IsNight, 
		SJ.MajorID, min(M.Name) as MajorName, 
		OI.UserID as PickingUserID, min(E.Name) as PickingUserName, 
		sum((OI.QntConfirmed % (P.InBox * P.BoxInPal)) / P.InBox) as Boxes 
--		sum(OI.Qnt / P.InBox) as Boxes 
	into #PickStat 
	from Shifts SJ with (nolock) 
	inner join TrafficsGoods OI with (nolock) on OI.DateConfirm > SJ.DateBeg and OI.DateConfirm <= SJ.DateEnd 
	inner join _Users M with (nolock) on SJ.MajorID = M.ID 
	inner join _Users E with (nolock) on OI.UserID = E.ID 
	inner join Packings P with (nolock) on OI.PackingID = P.ID 
	where OI.FrameID is Null and OI.QntConfirmed > 0 and OI.OutputID is not Null 
	group by SJ.ID, SJ.DateBeg, SJ.DateEnd, SJ.IsNight, SJ.MajorID, OI.UserID
	order by SJ.ID, 5,7

-- Отгрузка
/*select	SJ.ID as ShiftID, SJ.DateBeg, SJ.DateEnd, SJ.IsNight, 
		SJ.MajorID, min(M.Name) as MajorName, 
		O.ValidateUserID as PickingUserID, min(E.Name) as PickingUserName, 
		sum((OI.QntConfirmed % (P.InBox * P.BoxInPal)) / P.InBox) as Boxes 
	into #PickStat 
	from Shifts SJ with (nolock) 
	inner join Outputs O with (nolock) on O.DateConfirm > SJ.DateBeg and O.DateConfirm <= SJ.DateEnd 
	inner join OutputsGoods OI with (nolock) on OI.OutputID = O.ID 
	inner join _Users M with (nolock) on SJ.MajorID = M.ID 
	inner join _Users E with (nolock) on O.ValidateUserID = E.ID 
	inner join Packings P with (nolock) on OI.PackingID = P.ID 
	where OI.QntConfirmed > 0 
	group by SJ.ID, SJ.DateBeg, SJ.DateEnd, SJ.IsNight, SJ.MajorID, O.ValidateUserID
	order by SJ.ID, 5,7*/

--select * from #PickStat

-- by Major
-- сначала осредняем по сменам, а потом по бригадирам
select	MajorName, IsNight, AVG(AvgBoxesPerPickerPerHour) as AvgBoxesPerPickerPerHour 
from (
select	MajorName, IsNight, ShiftID, 
		SUM(Boxes) / 
			(COUNT(distinct PickingUserName) * case when IsNight = 1 then 13 else 11 end) as AvgBoxesPerPickerPerHour 
	from #PickStat 
	group by MajorName, IsNight, ShiftID 
) X 
	group by MajorName, IsNight 
	order by 1,2

-- by Picker
select	PickingUserID, PickingUserName, IsNight, COUNT(distinct ShiftID) as ShiftsCount, 
		SUM(Boxes) / COUNT(distinct ShiftID) 
			/ case when IsNight = 1 then 13 else 11 end as AvgBoxesPerPickerPerHour 
	from #PickStat 
	group by PickingUserID, PickingUserName, IsNight 
	order by 3,5 desc

--select * from #PickStat where PickingUserID = 93
