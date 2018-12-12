-- Сравнение остатков в Trading & WMS после ревизии
-- Остатки в Trading не скорректированы, а в WMS - скорректированы
-- Следовательно, разница и есть недостачи и излишки склада
-- Выполняется в БД WMS для простоты
if db_name() <> 'WMS' return

-- Удаление временных таблиц
if object_id('Tempdb..#Goods') is not Null drop table #Goods
if object_id('Tempdb..#TOddments') is not Null drop table #TOddments
if object_id('Tempdb..#WOddments') is not Null drop table #WOddments
if object_id('Tempdb..#Inputs') is not Null drop table #Inputs
if object_id('Tempdb..#Outputs') is not Null drop table #Outputs
if object_id('Tempdb..#NCInputs') is not Null drop table #NCInputs
if object_id('Tempdb..#NCOutputs') is not Null drop table #NCOutputs
if object_id('Tempdb..#Total') is not Null drop table #Total
if object_id('Tempdb..#Result') is not Null drop table #Result
if object_id('Tempdb..#Result2') is not Null drop table #Result2

-- Получение списка всех товаров
select distinct GS.Alias as GoodStateAlias, GG.Alias as GoodGroupAlias, G.Alias as GoodAlias, 
	G.Uniq as ERPGood, P.InBox, GS.Uniq as ERPGoodState, G.Actual as GoodActual 
into #Goods 
from 
	Trading.dbo.Goods G with (nolock), 
	Trading.dbo.WMSGoodsStates GS with (nolock), 
	Trading.dbo.Packings P with (nolock), 
	Trading.dbo.GoodsGroups GG with (nolock)  
where P.Good = G.Uniq and G.GoodsGroup = GG.Uniq and 
	G.Tare = 0 and G.GoodsGroup <> 5 and G.Uniq <> 4602 
order by 1,2

-- Получение остатков Trading (на 12.10.2208 20:00)
select GS.Uniq as ERPGoodState, P.Good as ERPGood, P.InBox, sum(O.Qnt) as TQnt 
into #TOddments 
from Trading.dbo.WHOddments O with (nolock) 
inner join Trading.dbo.Packings P with (nolock) on O.Packing = P.Uniq 
inner join Trading.dbo.Depots D with (nolock) on O.Depot = D.Uniq 
inner join Trading.dbo.WMSGoodsStates GS with (nolock) on D.WMSGoodState = GS.Uniq 
where O.Qnt <> 0 and D.RemoteDepot is Null 
group by GS.Uniq, P.Good, P.InBox

-- Получение остатков WMS (за исключением LOST&FOUND) (на 13.10.2008 00:30)
-- В первую ревизию неправильно посчитали брак - 
-- учли его дважды для товаров, находящихся в высотной зоне
-- Вычленяем товары в этом состоянии И НАХОДЯЩИЕСЯ В ВЫСОТКЕ из остатков
select GS.ERPCode as ERPGoodState, G.ERPCode as ERPGood, P.InBox, sum(CC.Qnt) as WQnt 
into #WOddments 
from CellsContents CC with (nolock) 
inner join Packings P with (nolock) on CC.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
where CC.CellID not in (4) and CC.Qnt <> 0 
	and not (CC.FrameID is not Null and CC.GoodStateID in (2))
group by GS.ERPCode, G.ERPCode, P.InBox

-- Приходы WMS
select GS.ERPCode as ERPGoodState, G.ERPCode as ERPGood, P.InBox, sum(II.Qnt) as IQnt 
into #Inputs 
from Inputs I with (nolock) 
inner join InputsItems II with (nolock) on II.InputID = I.ID 
inner join Packings P with (nolock) on II.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsStates GS with (nolock) on II.GoodStateID = GS.ID 
where I.DateConfirm >= '20081012 20:00'
group by GS.ERPCode, G.ERPCode, P.InBox

-- Приходы WMS (непереданные)
select GS.ERPCode as ERPGoodState, G.ERPCode as ERPGood, P.InBox, sum(II.Qnt) as IQnt 
into #NCInputs 
from Inputs I with (nolock) 
inner join InputsItems II with (nolock) on II.InputID = I.ID 
inner join Packings P with (nolock) on II.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsStates GS with (nolock) on II.GoodStateID = GS.ID 
where I.DateInput >= '20080929 10:00' and II.DateConfirm < '20081012 20:00' and 
	I.ERPCode in (select Uniq from Trading.dbo.WHInputs where DateConfirm is Null and DateInput >= '20080929 10:00') 
--AND 1=0
group by GS.ERPCode, G.ERPCode, P.InBox

-- Расходы WMS
select GS.ERPCode as ERPGoodState, G.ERPCode as ERPGood, P.InBox, sum(II.Qnt) as OQnt 
into #Outputs 
from Outputs I with (nolock) 
inner join OutputsItems II with (nolock) on II.OutputID = I.ID 
inner join Packings P with (nolock) on II.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsStates GS with (nolock) on II.GoodStateID = GS.ID 
where I.DateConfirm >= '20081012 20:00' 
group by GS.ERPCode, G.ERPCode, P.InBox

-- Расходы WMS (непереданные) НЕ ПРИМЕНЯЮТСЯ!!!
select GS.ERPCode as ERPGoodState, G.ERPCode as ERPGood, P.InBox, sum(II.Qnt) as OQnt 
into #NCOutputs 
from Outputs I with (nolock) 
inner join OutputsItems II with (nolock) on II.OutputID = I.ID 
inner join Packings P with (nolock) on II.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsStates GS with (nolock) on II.GoodStateID = GS.ID 
where I.DateOutput >= '20080929 10:00' and II.DateConfirm < '20081012 20:00' and 
	I.ERPCode in (select Uniq from Trading.dbo.WHOutputs where DateConfirm is Null and DateOutput >= '20080929 10:00')
AND 1=0
group by GS.ERPCode, G.ERPCode, P.InBox

-- Сравнение остатков
select G.GoodStateAlias, G.GoodGroupAlias, G.GoodAlias, G.ERPGoodSTate, G.ERPGood, G.InBox, 
	IsNull(T.TQnt, 0) / G.InBox as TBoxes, 
	(IsNull(W.WQnt, 0) - IsNull(I.IQnt, 0) + IsNull(O.Oqnt, 0) - IsNull(NCI.IQnt, 0) + IsNull(NCO.Oqnt, 0)) / G.InBox as WBoxes, 
	IsNull(T.TQnt, 0) / G.InBox - (IsNull(W.WQnt, 0) - IsNull(I.IQnt, 0) + IsNull(O.Oqnt, 0) - IsNull(NCI.IQnt, 0) + IsNull(NCO.Oqnt, 0)) / G.InBox as BoxesDiff, 
	IsNull(T.TQnt, 0) as TQnt, 
	(IsNull(W.WQnt, 0) - IsNull(I.IQnt, 0) + IsNull(O.OQnt, 0) - IsNull(NCI.IQnt, 0) + IsNull(NCO.OQnt, 0)) as WQnt, 
	IsNull(T.TQnt, 0) - (IsNull(W.WQnt, 0) - IsNull(I.IQnt, 0) + IsNull(O.OQnt, 0) - IsNull(NCI.IQnt, 0) + IsNull(NCO.OQnt, 0)) as QntDiff 
into #Total 
from #Goods G 
left join #TOddments T on G.ERPGood = T.ERPGood and G.InBox = T.InBox and G.ERPGoodSTate = T.ERPGoodState 
left join #WOddments W on G.ERPGood = W.ERPGood and G.InBox = W.InBox and G.ERPGoodSTate = W.ERPGoodState 
left join #Inputs I on G.ERPGood = I.ERPGood and G.InBox = I.InBox and G.ERPGoodSTate = I.ERPGoodState 
left join #Outputs O on G.ERPGood = O.ERPGood and G.InBox = O.InBox and G.ERPGoodSTate = O.ERPGoodState 
left join #NCInputs NCI on G.ERPGood = NCI.ERPGood and G.InBox = NCI.InBox and G.ERPGoodSTate = NCI.ERPGoodState 
left join #NCOutputs NCO on G.ERPGood = NCO.ERPGood and G.InBox = NCO.InBox and G.ERPGoodSTate = NCO.ERPGoodState 
order by 1,2,3

select T.*, abs(T.TQnt - T.WQnt) / T.TQnt * 100 as DiffPrc 
	into #Result 
	from #Total T 
	where T.TQnt <> 0 and T.WQnt <> 0
	and T.TQnt <> T.WQnt 
--	and abs(BoxesDiff) > 10
--	and T.GoodStateAlias in ('_Основной', 'перефасовка')
--	order by DiffPrc
--	order by GoodAlias, BoxesDiff
	order by GoodStateAlias, BoxesDiff
--	order by 1 desc
select * from #Result order by GoodAlias
select sum(BoxesDiff) from #Total 
--	where GoodStateAlias in ('_Основной', 'перефасовка')

-- Заносим остатки в спецтаблицу Trading для последующего автоматического расчета актов списания
if object_id('Trading.dbo.__InventoryResult') is not Null drop table Trading.dbo.__InventoryResult
select cast(4 as varchar(10)) as ERPOwner, ERPGoodState, ERPGood, InBox, TQnt, WQnt 
	into Trading.dbo.__InventoryResult 
	from #Result



-- Работаем с остатками, равными 0 в WMS или в Trading
select T.* 
	into #Result2 
	from #Total T 
	where (T.TQnt <> 0 and T.WQnt = 0) or (T.TQnt = 0 and T.WQnt <> 0)
	order by GoodStateAlias, BoxesDiff
select * from #Result2 order by GoodAlias
select sum(BoxesDiff) from #Result2 

-- Заносим остатки в спецтаблицу Trading для последующего автоматического расчета актов списания
if object_id('Trading.dbo.__InventoryResult2') is not Null drop table Trading.dbo.__InventoryResult2
select cast(4 as varchar(10)) as ERPOwner, ERPGoodState, ERPGood, InBox, TQnt, WQnt 
	into Trading.dbo.__InventoryResult2 
	from #Result2
