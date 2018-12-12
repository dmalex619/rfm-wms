-- Сравнение количества товара в остатках и на высотке
if object_id('Tempdb..#Temp') is not Null drop table #Temp

select GS.Alias as GSAlias, G.Alias as GoodAlias, G.Uniq as GoodID, P.InBox, 
	sum(cast((O.Qnt - O.Picked) / P.InBox as dec(15,1))) as OBoxes, 
	sum(cast(S.Qnt / P.InBox as dec(15,1))) as SBoxes, 
	sum(cast((O.Qnt - O.Picked) * G.Netto as dec(15,1))) as ONetto, 
	sum(cast(S.Qnt * G.Netto as dec(15,1))) as SNetto, 
	cast(Null as dec(12,1)) as BoxesPrc 
into #Temp 
from WHOddments O
inner join Packings P on O.Packing = P.Uniq 
inner join Goods G on P.Good = G.Uniq 
inner join Depots D on O.Depot = D.Uniq 
inner join WMSGoodsStates GS on D.WMSGoodState = GS.Uniq 
left join (select Depot, Packing, sum(Qnt) as Qnt 
	from WHStorage 
	where Qnt is not Null 
	group by Depot, Packing) S 
	on O.Packing = S.Packing and O.Depot = S.Depot 
--where IsNull(O.Qnt, 0) <> 0 
where G.GoodsGroup <> 5 
group by GS.Alias, G.Alias, G.Uniq, P.InBox 
order by ONetto

update #Temp set BoxesPrc = 
	case when IsNull(OBoxes, 0) <> 0 
	then cast(SBoxes / OBoxes * 100 as dec(12,1)) 
	else 0 end

select * from #Temp 
where (ONetto <> 0 or SNetto <> 0) and IsNull(BoxesPrc, 0) > 100
--order by GSAlias, BoxesPrc
order by GoodAlias, GSAlias

/*
select T.GoodAlias, T.InBox, 	
	left(S.Address, 2) + '.' + 
	substring(S.Address, 3, 2) + '.' + 
	substring(S.Address, 5, 1) + '.' + 
	right(S.Address, 1) as Address 
from #Temp T
inner join Packings P on T.GoodID = P.Good and T.InBox = P.InBox 
inner join WHStorage S on S.Packing = P.Uniq
where (ONetto <> 0 or SNetto <> 0) and IsNull(BoxesPrc, 0) > 100
order by GoodAlias, Address
*/
