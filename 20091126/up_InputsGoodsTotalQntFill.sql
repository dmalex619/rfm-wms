set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsGoodsTotalQntFill] 
	@nInputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
-- получение списка товаров в приходе без учета реального и фактического состояния (только кол-во)
AS

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs with (nolock) where ID = IsNull(@nInputID, 0)) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден приход № ' + ltrim(str(@nInputID)) + '...'
	return
end

select	IG.PackingID, 
		sum(IG.QntWished) as QntWished, 
		sum(IG.QntConfirmed) as QntConfirmed
	into	#InputsGoodsQnt
	from	InputsGoods IG with (nolock) 
	where	IG.InputID = IsNull(@nInputID, 0) 
	group by IG.PackingID

select	@nInputID as InputID, 
        IG.PackingID, P.GoodID, 
        IG.QntWished, IG.QntConfirmed, 
		P.PalletTypeID, PT.Name as PalletTypeName, 
        IG.QntWished / P.InBox as BoxWished,
        cast(IG.QntWished / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished,
        IG.QntConfirmed / P.InBox as BoxConfirmed,
        cast(IG.QntConfirmed / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed,
        P.InBox, P.BoxInPal, P.BoxInRow, 
		P.BoxInPal as DefaultBoxInPal, P.BoxInRow as DefaultBoxInRow, 
        G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
        P.BoxHeight
    from	#InputsGoodsQnt IG 
    inner join Packings P with (nolock) on IG.PackingID = P.ID
    inner join Goods G with (nolock) on P.GoodID = G.ID
	left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID
	left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID
    left  join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID
	-- where 
    order by G.Alias
return