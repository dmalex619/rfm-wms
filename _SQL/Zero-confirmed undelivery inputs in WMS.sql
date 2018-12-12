-- Недовозы, подтвержденные с количеством меньше ожидаемого
if object_id('Tempdb..#Total') is not Null drop table #Total

select GS.ERPCode as ERPGoodState, G.ERPCode as ERPGood, P.InBox, 
	G.Alias as GoodAlias, 
	sum(II.QntWished - II.QntConfirmed) as IQnt, 
	sum((II.QntWished - II.QntConfirmed) / P.InBox) as IBoxes 
into #Total 
from Inputs I with (nolock) 
inner join InputsGoods II with (nolock) on II.InputID = I.ID 
inner join Packings P with (nolock) on II.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsStates GS with (nolock) on II.GoodStateID = GS.ID 
where I.DateConfirm between '20080301 00:00' and '20081012 20:00' and 
	I.InputTypeID in (3) and II.QntWished - II.QntConfirmed <> 0
group by GS.ERPCode, G.ERPCode, P.InBox, G.Alias
order by GoodAlias

select sum(IBoxes) from #Total
