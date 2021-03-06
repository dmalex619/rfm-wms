SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_ReportOutputsQntDifferences]
	@cOutputsList		varchar(MAX),					-- список кодов расходов через ,
	@cUnit				varchar(1) = 'U',				-- единица расчета (U - штуки, B - коробки, P - паллеты)
	@bGroupByPacking	bit = 0,						-- группировать по товару
	@bIncludeWeighting	bit = 1,						-- включать в отчет весовые товары
	@nWeightDiffPrc		decimal(6, 2) = 0,				-- расхождение для весовых товаров в %%
	@cQntFieldName1		varchar(20) = 'QntWished',		-- имя первого поля для сравнения
	@cQntFieldName2		varchar(20) = 'QntConfirmed'	-- имя второго поля для сравнения
AS

set nocount on

if IsNull(@cOutputsList, '') = '' return
if IsNull(@cUnit, 'U') not in ('U', 'B', 'P') set @cUnit = 'U'

select  @cQntFieldName1 = upper(@cQntFieldName1), @cQntFieldName2 = upper(@cQntFieldName2)
if charindex('QNT', @cQntFieldName1) = 0 set @cQntFieldName1 = 'QNTWISHED'
if charindex('QNT', @cQntFieldName2) = 0 set @cQntFieldName2 = 'QNTCONFIRMED'

declare @cSelect varchar(max)

select ID * 1 as ID, CellID 
	into #Outputs 
	from Outputs with (nolock) 
	where 1 = 2

set @cSelect = '
insert #Outputs (ID, CellID) 
	select ID, CellID from Outputs with (nolock) 
	where ID in (' + dbo._NormalizeList(@cOutputsList) + ')'
exec (@cSelect)

if not exists (select top 1 ID from #Outputs)
	return

select	O.ID as OutputID, O.DateOutput, O.OwnerID, O.PartnerID, O.ERPCode, 
		OG.ID as OutputGoodID, O.GoodStateID, 
		OG.PackingID, P.InBox, P.BoxInPal, G.Weighting, 
		OG.QntWished, OG.QntSelected, OG.QntSelected as QntPicked, OG.QntConfirmed 
	into #Report 
	from Outputs O with (nolock) 
	inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
	inner join Packings P with (nolock) on OG.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where 1 = 2
create index IX_Report on #Report (OutputGoodID, PackingID)

set @cSelect = '
insert #Report 
		(OutputID, DateOutput, OwnerID, PartnerID, ERPCode, 
		OutputGoodID, GoodStateID, PackingID, InBox, BoxInPal, Weighting, 
		QntWished, QntSelected, QntPicked, QntConfirmed) 
	select	O.ID, O.DateOutput, O.OwnerID, O.PartnerID, O.ERPCode, 
			OG.ID, O.GoodStateID, OG.PackingID, 
			case when P.InBox > 0 then P.InBox else 1 end, 
			case when P.BoxInPal > 0 then P.BoxInPal else 1 end, G.Weighting, 
			OG.QntWished, OG.QntSelected, OG.QntSelected * 0 as QntPicked, OG.QntConfirmed 
		from Outputs O with (nolock) 
		inner join #Outputs X on O.ID = X.ID 
		inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
		inner join Packings P with (nolock) on OG.PackingID = P.ID 
		inner join Goods G with (nolock) on P.GoodID = G.ID 
		where 1 = 1 '
if @bIncludeWeighting = 0 
	set @cSelect = @cSelect + ' and G.Weighting = 0 '
if charindex('SELECTED', @cQntFieldName1) > 0 or charindex('SELECTED', @cQntFieldName2) > 0
	set @cSelect = @cSelect + ' and O.DateSelect is not Null '
if charindex('PICKED', @cQntFieldName1) > 0 or charindex('PICKED', @cQntFieldName2) > 0
	set @cSelect = @cSelect + ' and O.DatePick is not Null '
if charindex('CONFIRMED', @cQntFieldName1) > 0 or charindex('CONFIRM', @cQntFieldName2) > 0
	set @cSelect = @cSelect + ' and O.DateConfirm is not Null '
exec (@cSelect)

-- анализ собранного товара (QntPicked)
if charindex('PICKED', @cQntFieldName1) > 0 or charindex('PICKED', @cQntFieldName2) > 0 begin
	select TG.PackingID, TG.QntConfirmed as Qnt, TG.OutputGoodID 
		into #Picked 
		from TrafficsGoods TG with (nolock) 
		inner join #Outputs X on TG.OutputID = X.ID 
		where TG.DateConfirm is not Null 
	select distinct TF.FrameID 
		into #FramesInTraffics 
		from TrafficsFrames TF with (nolock) 
		inner join #Outputs X on TF.OutputID = X.ID 
		where TF.DateConfirm is not Null and 
			TF.Success = 1 and 
			TF.CellTargetID = IsNull(X.CellID, -1)
	insert #Picked (PackingID, Qnt, OutputGoodID) 
		select OI.PackingID, OI.Qnt, OI.OutputGoodID 
			from OutputsItems OI with (nolock) 
			inner join #FramesInTraffics F on OI.FrameID = F.FrameID 
			inner join #Outputs X on OI.OutputID = X.ID 
	select OutputGoodID, PackingID, sum(Qnt) as Qnt 
		into #OutputsGoodsPicked 
		from #Picked 
		group by OutputGoodID, PackingID
	
	update #Report set QntPicked = X.Qnt 
		from #OutputsGoodsPicked X 
		where #Report.OutputGoodID = X.OutputGoodID and #Report.PackingID = X.PackingID
end

-- поля для сравнения
set @cSelect = 'delete #Report where Weighting = 0 and ' + @cQntFieldName1 + ' = ' + @cQntFieldName2
exec (@cSelect)

set @cSelect = 'delete #Report where Weighting = 1 and ' + 
	'100 * abs(' + @cQntFieldName1 + ' - ' + @cQntFieldName2 + ') / ' + 
	'case when ' + @cQntFieldName1 + ' > 0 then ' + @cQntFieldName1 + ' else 1 end ' + 
	'<= ' + str(@nWeightDiffPrc, 10, 3)
exec (@cSelect)

-- приведение к единице расчета
if @cUnit = 'B' begin
	update #Report set 
		QntWished		= QntWished		/ InBox, 
		QntSelected		= QntSelected	/ InBox, 
		QntPicked		= QntPicked		/ InBox, 
		QntConfirmed	= QntConfirmed	/ InBox 
end
if @cUnit = 'P' begin
	update #Report set 
		QntWished		= QntWished		/ InBox / BoxInPal, 
		QntSelected		= QntSelected	/ InBox / BoxInPal, 
		QntPicked		= QntPicked		/ InBox / BoxInPal, 
		QntConfirmed	= QntConfirmed	/ InBox / BoxInPal 
end

-- итоговая выборка
if @bGroupByPacking = 1 begin
	select	GS.Name as GoodStateName, G.Alias as GoodName, P.InBox, P.BoxInPal, 
			G.Weighting, G.Articul, G.BarCode as GoodBarCode, 
			GG.Name as GoodGroupName, GB.Name as GoodBrandName, 
			X.QntWished, X.QntSelected, X.QntPicked, X.QntConfirmed 
		from (select GoodStateID, PackingID, 
					sum(QntWished) as QntWished, 
					sum(QntSelected) as QntSelected, 
					sum(QntPicked) as QntPicked, 
					sum(QntConfirmed) as QntConfirmed 
				from #Report 
				group by GoodStateID, PackingID) X 
		inner join GoodsStates GS with (nolock) on X.GoodStateID = GS.ID 
		inner join Packings P with (nolock) on X.PackingID = P.ID 
		inner join Goods G with (nolock) on P.GoodID = G.ID 
		inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
		inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
		order by G.Name, P.InBox
end
else begin
	select	X.DateOutput, 
			Ow.Name as OwnerName, IsNull(Ps.Name, '') as PartnerName, 
			X.ERPCode, 
			GS.Name as GoodStateName, 
			G.Alias as GoodName, P.InBox, P.BoxInPal, 
			G.Weighting, G.Articul, G.BarCode as GoodBarCode, 
			GG.Name as GoodGroupName, GB.Name as GoodBrandName, 
			X.QntWished, X.QntSelected, X.QntPicked, X.QntConfirmed 
		from #Report X 
		inner join GoodsStates GS with (nolock) on X.GoodStateID = GS.ID 
		inner join Packings P with (nolock) on X.PackingID = P.ID 
		inner join Goods G with (nolock) on P.GoodID = G.ID 
		inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
		inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
		left join Partners Ow with (nolock) on X.OwnerID = Ow.ID 
		left join Partners Ps with (nolock) on X.PartnerID = Ps.ID 
	order by X.DateOutput, Ow.Name, Ps.Name, G.Name, P.InBox
end
return