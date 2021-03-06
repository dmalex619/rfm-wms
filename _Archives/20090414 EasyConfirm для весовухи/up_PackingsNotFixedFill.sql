set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_PackingsNotFixedFill]
	@cPackingsList		varchar(max) = Null, 
	@bPackingsActual	bit = Null, 
	@bGoodsActual		bit = Null, 
	@cInputsList		varchar(max) = Null, 
	@cOutputsList		varchar(max) = Null, 
	@nGoodStateID		int = Null, 
	@nOwnerID			int = Null
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max)

if @nGoodStateID is Null begin
	select top 1 @nGoodStateID = ID 
		from GoodsStates with (nolock) 
		where Basic = 1
end

select ID * 1 as ID 
	into #Packings 
	from Packings P with (nolock) 
	where 1 = 2

set @cSelect = 
'insert #Packings (ID) 
	select P.ID 
		from Packings P with (nolock) 
		inner join Goods G with (nolock) on P.GoodID = G.ID '
set @cWhere = 
		'where not exists (select ID from Cells C with (nolock) 
							where C.Deleted = 0 and C.FixedPackingID = P.ID ' 
if @nGoodStateID is not Null
	set @cWhere = @cWhere + ' and C.FixedGoodStateID = ' + str(@nGoodStateID) + ' ' --  Null не бывает
if @nOwnerID is not Null
	set @cWhere = @cWhere + ' and C.FixedOwnerID = ' + str(@nOwnerID) + ' '
else 
	set @cWhere = @cWhere + ' and C.FixedOwnerID is Null ' 
set @cWhere = @cWhere + ')'

if @bPackingsActual is not Null 
	set @cWhere = @cWhere + ' and P.Actual = ' + str(@bPackingsActual) + ' '
if @bGoodsActual is not Null 
	set @cWhere = @cWhere + ' and G.Actual = ' + str(@bGoodsActual) + ' '
if @cPackingsList is not Null
	set @cWhere = @cWhere + ' and P.ID in (' + dbo._NormalizeList(@cPackingsList) + ') '
if @cInputsList is not Null
	set @cSelect = @cSelect + ' inner join InputsGoods IG with (nolock) on P.ID = IG.PackingID and 
												InputID in (' + dbo._NormalizeList(@cInputsList) + ') '
if @cOutputsList is not Null
	set @cSelect = @cSelect + ' inner join OutputsGoods OG with (nolock) ' + 
												' where OutputID in (' + dbo._NormalizeList(@cOutputsList) + ') '

set @cSelect = @cSelect + @cWhere 
exec (@cSelect)

select distinct ID 
	into #Packings_X 
	from #Packings

select	G.ID as GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Name  + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName, 
		G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		G.Actual as GoodActual, P.Actual as PackingActual, 
		P.InBox, P.BoxInPal, P.BoxInRow, 
		P.BoxWeight, P.BoxLength, P.BoxWidth, P.BoxHeight, 
		P.PalletTypeID, PT.Name as PalletTypeName, 
		G.TemperatureMode, 
		G.ErpCode as GoodErpCode, P.ErpCode as PackingErpCode 
	from Packings P with (nolock) 
	inner join #Packings_X P_X on P.ID = P_X.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	left join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
	order by GoodName, GoodID, PackingID
return