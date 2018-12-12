-- Проверка конвертора подтвержденных приходов WMS -> Trading
-- Разница возможна, если товар принят в другом состоянии!
-- В этом случае надо искать в Trading приход на другой склад!

-- Подтвержденные позиции в WMS
if object_id('Tempdb..#WMS') is not Null drop table #WMS
select I.ERPCode as ERPInputID, 
	G.ERPCode as ERPGoodID,
	P.InBox as ERPInBox,
	IG.QntConfirmed, 
	GS.Name as GoodStateName
into #WMS 
from WMS.dbo.Inputs I
inner join WMS.dbo.InputsGoods IG with (nolock) on IG.InputID = I.ID 
inner join WMS.dbo.Packings P with (nolock) on IG.PackingID = P.ID 
inner join WMS.dbo.Goods G with (nolock) on P.GoodID = G.ID 
inner join WMS.dbo.GoodsStates GS with (nolock) on IG.GoodStateID = GS.ID 
where IG.QntConfirmed <> 0

-- Подтвержденные позиции в Trading
select IG.WHInput, W.ERPInputID, 
	G.Uniq as Good,
	G.Alias,  
	P.InBox, 
	IG.QntConfirmed, W.QntConfirmed, 
	W.GoodStateName 
from WHInputsGoods IG
inner join Packings P with (nolock) on IG.Packing = P.Uniq 
inner join Goods G with (nolock) on P.Good = G.Uniq 
left join #WMS W on IG.WHInput = W.ERPInputID and 
	G.Uniq = W.ERPGoodID and 
	P.InBox = ERPInBox
where W.ERPInputID is not Null and IG.QntConfirmed <> W.QntConfirmed

