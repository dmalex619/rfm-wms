-- ѕереброска €чеек из зоны в зону дл€ ёрлова
if object_id('Tempdb..#Cells') is not Null drop table #Cells
select ID as CellID 
	into #Cells 
	from Cells 
	where CBuilding = '4' and CLevel = 1 and CLine in ('A', 'B', 'C', 'D') 

select * from CellsContents where CellID in (select CellID from #Cells)
update Cells set StoreZoneID = 14 where ID in (select CellID from #Cells)
--select * from #Cells
