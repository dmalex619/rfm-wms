-- Расчет суммы актов по ревизии от 25.01.2009
-- Коды актов (приходов) получены от Хоменко и согласованы с Юрловым
select GG.Alias as GroupAlias, G.Alias as GoodAlias, D.Alias as DepotAlias, P.InBox, 
	sum(IG.QntConfirmed) as Qnt, 
	cast(sum(IG.QntConfirmed / P.InBox) as dec(15,3)) as QntBoxes, 
	cast(sum(IG.QntConfirmed / P.InBox / P.BoxInPal) as dec(15,3)) as QntPallets, 
	cast(sum(IG.QntConfirmed * G.Netto) as dec(15,3)) as QntNetto,  
	cast(sum(IG.QntConfirmed * IsNull(dbo.GetOneGoodCost(G.Uniq, '20090125', 1), 0)) as money) as QntCost  
	from WHInputs I with (nolock) 
	inner join WHInputsGoods IG with (nolock) on IG.WHInput = I.Uniq 
	inner join Depots D with (nolock) on I.Depot = D.Uniq 
	inner join Packings P with (nolock) on IG.Packing = P.Uniq 
	inner join Goods G with (nolock) on P.Good = G.Uniq 
	inner join GoodsGroups GG with (nolock) on G.GoodsGroup = GG.Uniq
	where I.Uniq in (143624, 143849, 144301, 144304, 145620, 145622, 145623, 145624)
	group by GG.Alias, G.Alias, D.Alias, P.InBox
	order by 1,2,3,4
