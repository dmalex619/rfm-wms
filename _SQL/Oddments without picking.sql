-- Просмотр количества товаров, не привязанных к пикингу
if object_id('Tempdb..#Temp') is not Null drop table #Temp

select G.Alias as GoodName, P.InBox, 
	sum(cast((O.Qnt - IsNull(S.Qnt, 0)) / P.InBox as dec(15,1))) as Boxes, 
	sum(cast((O.Qnt - IsNull(S.Qnt, 0)) / P.InBox / P.BoxInPal as dec(15,1))) as Pallets, 
	_C.Address
into #Temp 
from Packings P 
inner join Goods G on P.Good = G.Uniq 
inner join (select Packing, sum(Qnt - Picked) as Qnt 
	from WHOddments 
	where Depot in (select Uniq from Depots where WMSGoodState = 1)
	group by Packing) O on O.Packing = P.Uniq
left join (select Packing, sum(IsNull(Qnt, 0)) as Qnt 
	from WHStorage 
	where Depot in (select Uniq from Depots where WMSGoodState = 1)
	group by Packing) S on S.Packing = P.Uniq 
left join WMS.dbo.Goods _G on _G.ERPCode = G.Uniq 
left join WMS.dbo.Packings _P on _P.GoodID = _G.ID and _P.InBox = P.InBox 
left join WMS.dbo.Cells _C on _C.FixedPackingID = _P.ID and _C.FixedGoodStateID = 1 
where O.Qnt <> 0 and G.Tare = 0 and G.GoodsGroup <> 5 
group by G.Alias, P.InBox, _C.Address

select * from #Temp 
where Boxes <> 0 --and abs(Pallets) > 1
order by /*GoodName*/ Address, Boxes
