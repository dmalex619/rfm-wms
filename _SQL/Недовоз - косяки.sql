-- Недовоз, косяки
if object_ID('Tempdb..#Out') is not Null drop table #Out
if object_ID('Tempdb..#Diff') is not Null drop table #Diff

select * into #Out from Orders 
	where DateConfirm is not Null and DateDelivery between '20080401' and '20080430'

select OG.Orders, OG.Shipped, OG.Brouth, G.Netto, 
	case when OG.Brouth > 1 then round(OG.Shipped / OG.Brouth, 1) else 0 end as Diff 
	into #Diff 
	from OrdersGoods OG 
	inner join #Out O on OG.Orders = O.Uniq 
	inner join Packings P on OG.Packing = P.Uniq 
	inner join Goods G on P.Good = G.Uniq 
	where OG.Shipped > OG.Brouth
select sum((Shipped - Brouth) * Netto) as ReturnKG from #Diff

select D.*, O.Note, O.FailReason
	from #Diff D 
	inner join #Out O on D.Orders = O.Uniq 
	where D.Diff >= 5
	order by Diff desc
