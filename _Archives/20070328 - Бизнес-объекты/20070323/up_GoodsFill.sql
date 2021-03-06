set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_GoodsFill]
	@nGoodID				int = Null, 
	@nPackingID				int = Null, 
	@cGoodBarCode			varchar(13) = Null, -- штрих-код товара
	@cPackingBarCode		varchar(13) = Null, -- штрих-код упаковки
	@bGoodsActual			bit = Null, -- актуальные товары?
	@bPackingsActual		bit = Null, -- актуальные упаковки?
	@cGoodNameContext		varchar(max) = Null, -- контекст названия товара
	@cGoodsGroupsList		varchar(max) = Null, -- список товарных групп (через,)
	@cGoodsBrandsList		varchar(max) = Null  -- список брендов (через ,) 
AS
BEGIN

select	@cGoodsGroupsList = replace(@cGoodsGroupsList, ' ', ''),
		@cGoodsBrandsList = replace(@cGoodsBrandsList, ' ', '')

select	G.ID as GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode,
		G.Name as GoodName, 
		G.Name + ': ' + cast(P.InBox as varchar(30)) as PackingName, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal 
	from Packings P 
	inner join Goods G on P.GoodID = G.Id 
	left join GoodsGroups GG on G.GoodGroupID = GG.Id 
	left join GoodsBrands GB on G.GoodBrandID = GB.Id 
	where	(
			(@nGoodID is not Null or @nPackingID is not Null or 
			 @cGoodBarCode is not Null or @cPackingBarCode is not Null
			) and 
			(@nGoodID is Null or 
				G.ID = @nGoodID) and
			(@nPackingID is Null or 
				P.ID = @nPackingID) and 
			(@cGoodBarCode is Null or 
				G.BarCode = @cGoodBarCode) and 
			(@cPackingBarCode is Null or 
				P.BarCode = @cPackingBarCode)
			)
		or 
			(
			  @nGoodID is Null and @nPackingID is Null and 
			  @cGoodBarCode is Null and @cPackingBarCode is Null and 
			 (@bGoodsActual is Null or 
				G.Actual = @bGoodsActual) and 
			 (@bPackingsActual is Null or 
				P.Actual = @bPackingsActual) and 
			 (@cGoodNameContext is Null or 
				charindex(upper(@cGoodNameContext), upper(G.Name)) > 0) and 
			 (@cGoodsGroupsList is Null or 
				charindex(',' + ltrim(str(G.GoodGroupID)) + ',', ',' + @cGoodsGroupsList + ',') > 0) and 
			 (@cGoodsBrandsList is Null or 
				charindex(',' + ltrim(str(G.GoodBrandID)) + ',', ',' + @cGoodsBrandsList + ',') > 0) 
			)
	order by GoodName, GoodID, PackingID
END
