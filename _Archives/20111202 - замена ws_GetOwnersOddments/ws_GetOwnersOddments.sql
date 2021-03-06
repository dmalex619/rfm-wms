SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_GetOwnersOddments]
	@cOwnersList		varchar(max) = '', 
	@cGoodsStatesList	varchar(max) = '', 
	@dDateEnd			smalldatetime = Null
AS
-- SuitableWMSWebService
-- Получение остатков по владельцам на заданную дату-время
-- Расчет ведется по приходам и расходам "от начала времен"

-- Получение списка ID для фильтрации владельцев
declare @cOwnersWhere varchar(max)
set @cOwnersWhere = ''
if len(replace(@cOwnersList, ' ', '')) > 0 begin
	select @cOwnersWhere = @cOwnersWhere + cast(ID as varchar(10)) + ',' 
		from Partners with (nolock) 
		where charindex(',' + ERPCode + ',', ',' + dbo._NormalizeList(@cOwnersList) + ',') > 0
	if len(@cOwnersWhere) > 0
		set @cOwnersWhere = ' and Own.ID in (' + substring(@cOwnersWhere, 1, len(@cOwnersWhere) - 1) + ') '
end

-- Получение списка ID для фильтрации состояний товаров
declare @cGoodsStatesWhere varchar(max)
set @cGoodsStatesWhere = ''
if len(replace(@cGoodsStatesList, ' ', '')) > 0 begin
	select @cGoodsStatesWhere = @cGoodsStatesWhere + cast(ID as varchar(10)) + ',' 
		from GoodsStates with (nolock) 
		where charindex(',' + ERPCode + ',', ',' + dbo._NormalizeList(@cGoodsStatesList) + ',') > 0
	if len(@cGoodsStatesWhere) > 0
		set @cGoodsStatesWhere = ' and GS.ID in (' + substring(@cGoodsStatesWhere, 1, len(@cGoodsStatesWhere) - 1) + ') '
end

-- Проверка даты
if @dDateEnd is Null 
	set @dDateEnd = DateAdd(Day, 1, getdate())
declare @cDateEnd varchar(10)
set @cDateEnd = convert(varchar(25), @dDateEnd, 112)

-- Получение списка товаров 
-- с группировкой по владельцу, состоянию товара, товару, кол-ву в коробке
declare @cSelect varchar(max)
set @cSelect = '
select	Own.ERPCode as ERPOwner, 
		GS.ERPCode as ERPGoodState, 
		G.ERPCode as ERPGood, 
		P.InBox, 
		sum(Qnt) as Qnt 
	from (
		select	I.OwnerID as OwnerID, 
				IG.GoodStateID as GoodStateID, 
				IG.PackingID as PackingID, 
				sum(IG.QntConfirmed) as Qnt 
			from Inputs I with (nolock) 
			inner join InputsGoods IG with (nolock) on IG.InputID = I.ID 
			where I.DateConfirm is not Null and DateDiff(Day, I.DateConfirm, ''' + @cDateEnd + ''') >= 0  
			group by I.OwnerID, IG.GoodStateID, IG.PackingID 
		union all 
		select	O.OwnerID as OwnerID, 
				OG.GoodStateID as GoodStateID, 
				OG.PackingID as PackingID, 
				sum(-OG.QntConfirmed) as Qnt 
			from Outputs O with (nolock) 
			inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
			where O.DateConfirm is not Null and DateDiff(Day, O.DateConfirm, ''' + @cDateEnd + ''') >= 0 
			group by O.OwnerID, OG.GoodStateID, OG.PackingID 
		union all 
		select	A.OwnerID as OwnerID, 
				A.GoodStateID as GoodStateID, 
				AG.PackingID as PackingID, 
				sum(AG.QntConfirmed) as Qnt 
			from AuditActs A with (nolock) 
			inner join AuditActsGoods AG with (nolock) on AG.AuditActID = A.ID 
			where A.DateConfirm is not Null and DateDiff(Day, A.DateConfirm, ''' + @cDateEnd + ''') >= 0 
			group by A.OwnerID, A.GoodStateID, AG.PackingID 
		) X 
	inner join Partners Own with (nolock) on X.OwnerID = Own.ID 
	inner join GoodsStates GS with (nolock) on X.GoodStateID = GS.ID 
	inner join Packings P with (nolock) on X.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where 1 = 1 ' + 
	case when len(@cOwnersWhere) > 0 then @cOwnersWhere else '' end + 
	case when len(@cGoodsStatesWhere) > 0 then @cGoodsStatesWhere else '' end + 
	'group by Own.ERPCode, GS.ERPCode, G.ERPCode, P.InBox 
	having sum(X.Qnt) <> 0 
	order by 1,2,3,4'
exec(@cSelect)
return