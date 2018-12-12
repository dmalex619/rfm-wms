if object_id('Tempdb..#Result') is not Null drop table #Result

select GS.Name as GoodStateAlias, G.Alias as GoodAlias, P.InBox, 
	sum(IG.QntWished) as WQnt, sum(IG.QntWished / P.InBox) as WBoxes, 
	sum(IG.QntConfirmed) as CQnt, sum(IG.QntConfirmed / P.InBox) as CBoxes 
into #Result 
from Inventories I with (nolock) 
inner join InventoriesCells IG with (nolock) on IG.InventoryID = I.ID 
inner join GoodsStates GS with (nolock) on IG.GoodStateID = GS.ID 
inner join Packings P with (nolock) on IG.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
where DateDiff(Day, I.DateConfirm, '20081019') = 0 and IG.Success is not Null 
group by GS.Name, G.Alias, P.InBox 
order by 1,2,3

select * from #Result where abs(WBoxes - CBoxes) > 5
select sum(WBoxes - CBoxes) from #Result
