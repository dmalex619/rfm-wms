SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_GoodsFill]
	@nGoodID			int = Null, 
	@nPackingID			int = Null, 
	@cGoodsIDList		varchar(max)= Null, 
	@cPackingsIDList	varchar(max) = Null, 
	@cHostsList			varchar(max) = Null, 
	@cGoodBarCode		varchar(13) = Null, -- штрих-код товара
	@cPackingBarCode	varchar(13) = Null, -- штрих-код упаковки
	@bGoodsActual		bit = Null, -- актуальные товары?
	@bPackingsActual	bit = Null, -- актуальные упаковки?
	@cGoodNameContext	varchar(200) = Null, -- контекст названия товара
	@cGoodsGroupsList	varchar(max) = Null, -- список товарных групп (через,)
	@cGoodsBrandsList	varchar(max) = Null  -- список брендов (через ,) 
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- для закрепленных ячеек пикинга
declare @nGoodStateDefaultID int 
select  top 1 @nGoodStateDefaultID = ID
	from GoodsStates with (nolock)
	where Basic = 1
select C.* 
	into #Cells 
	from Cells C with (nolock)
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ForPicking = 1 and 
			C.FixedPackingID is not Null and 
			C.FixedOwnerID is Null and 
			C.FixedGoodStateID = @nGoodStateDefaultID and 
			C.Deleted = 0

set @cSelect = 
	'select	G.ID as GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Name  + '' ('' + ltrim(str(round(P.InBox, case when G.Weighting = 1 then 3 else 0 end))) + '')'' as PackingName, 
		G.Alias + '' ('' + ltrim(str(round(P.InBox, case when G.Weighting = 1 then 3 else 0 end))) + '')'' as PackingAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		G.TemperatureMode, 
		G.Actual as GoodActual, P.Actual as PackingActual, 
		P.InBox, P.BoxInPal, P.BoxInRow, 
		P.BoxWeight, P.BoxLength, P.BoxWidth, P.BoxHeight, 
		P.PalletTypeID, PT.Name as PalletTypeName, 
		C.Address, SZ.Name as StoreZoneName, 
		.dbo.GetPackingsPickingList(P.ID) as PickingList, 
		G.HostID, HS.Name as HostName, 
		G.ERPCode as GoodERPCode, P.ERPCode as PackingERPCode, 
		G.ABCRank 
	from Packings P with (nolock) 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	left join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
	left join #Cells C with (nolock) on P.ID = C.FixedPackingID 
	left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left join Hosts HS with (nolock) on G.HostID = HS.ID '

if @nGoodID is not Null or @nPackingID is not Null begin
	if @nGoodID is not Null 
		set @cWhere = ' where G.ID = ' + str(@nGoodID)
	if @nPackingID is not Null 
		set @cWhere = ' where P.ID = ' + str(@nPackingID)
end
else begin
	set @cWhere = ' where 1 = 1 '
	
	if @cGoodBarCode is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cGoodBarCode + ''', G.BarCode) > 0 '
	if @cPackingBarCode is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cPackingBarCode + ''', P.BarCode) > 0 '
	
	if @cGoodsIDList is not Null
		set @cWhere = @cWhere + ' and G.ID in (' + dbo._NormalizeList(@cGoodsIDList) + ') '
	if @cPackingsIDList is not Null
		set @cWhere = @cWhere + ' and P.ID in (' + dbo._NormalizeList(@cPackingsIDList) + ') '
	
	if @cHostsList is not Null
		set @cWhere = @cWhere + ' and G.HostID in (' + dbo._NormalizeList(@cHostsList) + ') '
	
	if @bGoodsActual is not Null 
		set @cWhere = @cWhere + ' and G.Actual = ' + str(@bGoodsActual) + ' '
	if @bPackingsActual is not Null 
		set @cWhere = @cWhere + ' and P.Actual = ' + str(@bPackingsActual) + ' '
	
	if @cGoodNameContext is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cGoodNameContext + ''', G.Alias + ''###'' + G.Name) > 0 '
	
	if @cGoodsGroupsList is not Null
		set @cWhere = @cWhere + ' and G.GoodGroupID in (' + dbo._NormalizeList(@cGoodsGroupsList) + ') '
	if @cGoodsBrandsList is not Null
		set @cWhere = @cWhere + ' and G.GoodBrandID in (' + dbo._NormalizeList(@cGoodsBrandsList) + ') '
end

set @cOrderBy = ' order by G.Alias, G.ID'

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return