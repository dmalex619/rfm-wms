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

-- Удаление пробелов из списка владельцев
if charindex(' ', @cOwnersList) > 0 
	set @cOwnersList = replace(@cOwnersList, ' ', '')

-- Дополнение строки со списком владельцев
if len(@cOwnersList) > 0 begin
	if left(@cOwnersList, 1)  <> ',' set @cOwnersList = ',' + @cOwnersList
	if right(@cOwnersList, 1) <> ',' set @cOwnersList = @cOwnersList + ','
end

-- Получение списка владельцев
select ID, ERPCode 
	into #Owners 
	from Partners with (nolock)
if len(@cOwnersList) > 0
	delete #Owners 
		where charindex(',' + ERPCode + ',', @cOwnersList) = 0
create index _IX_Owners_ID on #Owners (ID)

-- Удаление пробелов из списка состояний товаров
if charindex(' ', @cGoodsStatesList) > 0 
	set @cGoodsStatesList = replace(@cGoodsStatesList, ' ', '')

-- Дополнение строки со списком состояний товаров
if len(@cGoodsStatesList) > 0 begin
	if left(@cGoodsStatesList, 1)  <> ',' set @cGoodsStatesList = ',' + @cGoodsStatesList
	if right(@cGoodsStatesList, 1) <> ',' set @cGoodsStatesList = @cGoodsStatesList + ','
end

-- Получение списка состояний товаров
select ID, ERPCode 
	into #GoodsStates 
	from GoodsStates with (nolock)
if len(@cGoodsStatesList) > 0
	delete #GoodsStates 
		where charindex(',' + ERPCode + ',', @cGoodsStatesList) = 0

-- Проверка даты
if @dDateEnd is Null 
	set @dDateEnd = DateAdd(Day, 1, getdate())

-- Получение списка товаров 
-- с группировкой по владельцу, состоянию товара, товару, кол-ву в коробке
select ERPOwner, ERPGoodState, ERPGood, InBox, sum(Qnt) as Qnt 
	from (
		-- Приходы
		select	O1.ERPCode as ERPOwner, 
				GS1.ERPCode as ERPGoodState, 
				G1.ERPCode as ERPGood, 
				P1.InBox, 
				sum(IG.QntConfirmed) as Qnt 
			from #Owners O1 
			inner join Inputs I with (nolock) on I.OwnerID = O1.ID 
			inner join InputsGoods IG with (nolock) on IG.InputID = I.ID 
			inner join GoodsStates GS1 with (nolock) on IG.GoodStateID = GS1.ID 
			inner join #GoodsStates XGS1 with (nolock) on GS1.ID = XGS1.ID 
			inner join Packings P1 with (nolock) on IG.PackingID = P1.ID 
			inner join Goods G1 with (nolock) on P1.GoodID = G1.ID 
			where I.DateConfirm is not Null and I.DateConfirm <= @dDateEnd 
			group by O1.ERPCode, GS1.ERPCode, G1.ERPCode, P1.InBox 
		union all 
		-- Отгрузки
		select	O2.ERPCode as ERPOwner, 
				GS2.ERPCode as ERPGoodState, 
				G2.ERPCode as ERPGood, 
				P2.InBox, 
				sum(-OG.QntConfirmed) as Qnt 
			from #Owners O2 
			inner join Outputs O with (nolock) on O.OwnerID = O2.ID 
			inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
			inner join GoodsStates GS2 with (nolock) on OG.GoodStateID = GS2.ID 
			inner join #GoodsStates XGS2 with (nolock) on GS2.ID = XGS2.ID 
			inner join Packings P2 with (nolock) on OG.PackingID = P2.ID 
			inner join Goods G2 with (nolock) on P2.GoodID = G2.ID 
			where O.DateConfirm is not Null and O.DateConfirm <= @dDateEnd 
			group by O2.ERPCode, GS2.ERPCode, G2.ERPCode, P2.InBox 
		union all 
		-- Акты
		select	O3.ERPCode as ERPOwner, 
				GS3.ERPCode as ERPGoodState, 
				G3.ERPCode as ERPGood, 
				P3.InBox, 
				sum(AG.QntConfirmed) as Qnt 
			from #Owners O3 
			inner join AuditActs A with (nolock) on A.OwnerID = O3.ID 
			inner join AuditActsGoods AG with (nolock) on AG.AuditActID = A.ID 
			inner join GoodsStates GS3 with (nolock) on A.GoodStateID = GS3.ID 
			inner join #GoodsStates XGS3 with (nolock) on GS3.ID = XGS3.ID 
			inner join Packings P3 with (nolock) on AG.PackingID = P3.ID 
			inner join Goods G3 with (nolock) on P3.GoodID = G3.ID 
			where A.DateConfirm is not Null and A.DateConfirm <= @dDateEnd 
			group by O3.ERPCode, GS3.ERPCode, G3.ERPCode, P3.InBox 
		) X 
	group by ERPOwner, ERPGoodState, ERPGood, InBox 
	having sum(Qnt) <> 0 
	order by ERPOwner, ERPGoodState, ERPGood, InBox
return