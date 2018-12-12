select 
	Convert(varchar(6), DateBirth, 112), 
	count(*), 
	count(distinct CellTargetID)
from TrafficsFrames
where ErrorID = 2 and CellTargetID in
(select ID from Cells where CBuilding in ('3', '4'))
group by Convert(varchar(6), DateBirth, 112)
order by 1
