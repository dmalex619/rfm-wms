-- Расчет суммы актов по ревизии от 25.01.2009
-- Коды актов (приходов) получены от Хоменко и согласованы с Юрловым
if object_id('Tempdb.dbo.#Diff') is not Null drop table #Diff
if object_id('Tempdb.dbo.#Odds') is not Null drop table #Odds
if object_id('Tempdb.dbo.#Goods') is not Null drop table #Goods
select D.Uniq as DepotUniq, GG.Uniq as GroupUniq, G.Uniq as GoodUniq, P.InBox, 
	sum(IG.QntConfirmed) as Qnt 
	into #Diff 
	from WHInputs I with (nolock) 
	inner join WHInputsGoods IG with (nolock) on IG.WHInput = I.Uniq 
	inner join Depots D with (nolock) on I.Depot = D.Uniq 
	inner join Packings P with (nolock) on IG.Packing = P.Uniq 
	inner join Goods G with (nolock) on P.Good = G.Uniq 
	inner join GoodsGroups GG with (nolock) on G.GoodsGroup = GG.Uniq
	where I.Uniq in (143624, 143849, 144301, 144304, 145620, 145622, 145623, 145624)
	group by D.Uniq, GG.Uniq, G.Uniq, P.InBox
	order by 1,2,3,4

-- Получение остатков от 24.01.2009 23:45
select OG.Depot as DepotUniq, GG.Uniq as GroupUniq, G.Uniq as GoodUniq, P.InBox, 
	sum(OG.Qnt) as Qnt 
	into #Odds 
	from WHSavedOddmentsGoods OG with (nolock) 
	inner join Packings P with (nolock) on OG.Packing = P.Uniq 
	inner join Goods G with (nolock) on P.Good = G.Uniq 
	inner join GoodsGroups GG with (nolock) on G.GoodsGroup = GG.Uniq
	where OG.WHSavedOddment = 1703 
	group by OG.Depot, GG.Uniq, G.Uniq, P.InBox
	order by 1,2,3,4

-- Получение справочника товаров
select distinct D.Uniq as DepotUniq, GG.Uniq as GroupUniq, G.Uniq as GoodUniq, P.InBox 
	into #Goods 
	from Depots D, Packings P, Goods G, GoodsGroups GG 
	where P.Good = G.Uniq and G.GoodsGroup = GG.Uniq 

-- Получение чистых остатков
select D.Alias as DepotAlias, GG.Alias as GroupAlias, G.Alias as GoodAlias, X.InBox, 
	(IsNull(O.Qnt, 0) + IsNull(A.Qnt, 0)) as Qnt, 
	round(((IsNull(O.Qnt, 0) + IsNull(A.Qnt, 0)) / X.InBox), 2) as QntBoxes 
	from #Goods X 
	left join #Odds O on 
		X.DepotUniq = O.DepotUniq and X.GroupUniq = O.GroupUniq and X.GoodUniq = O.GoodUniq and X.InBox = O.InBox 
	left join #Diff A on 
		X.DepotUniq = A.DepotUniq and X.GroupUniq = A.GroupUniq and X.GoodUniq = A.GoodUniq and X.InBox = A.InBox 
	inner join Depots D with (nolock) on X.DepotUniq = D.Uniq 
	inner join Goods G with (nolock) on X.GoodUniq = G.Uniq 
	inner join GoodsGroups GG with (nolock) on X.GroupUniq = GG.Uniq 
	where IsNull(O.Qnt, 0) + IsNull(A.Qnt, 0) <> 0 
	order by 1,2,3,4
