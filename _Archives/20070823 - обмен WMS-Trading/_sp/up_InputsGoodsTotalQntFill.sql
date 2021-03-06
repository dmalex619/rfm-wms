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
		not exists (select ID from Inputs where ID = @nInputID) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден приход № ' + ltrim(str(@nInputID)) + '...'
	return
end

select	IG.PackingID, 
		sum(IG.QntWished) as QntWished, 
		sum(IG.QntConfirmed) as QntConfirmed, 
		IG.PalletTypeID 
	into	#InputsGoodsQnt
	from	InputsGoods IG 
	where	IG.InputID = @nInputID
	group by IG.PackingID, IG.PalletTypeID 

select	@nInputID as InputID, 
        IG.PackingID, P.GoodID, 
        IG.QntWished, IG.QntConfirmed, 
        IG.PalletTypeID, PT.Name as PalletTypeName, 
        P.BoxInPal, P.BoxInRow,
        IG.QntWished / P.InBox as BoxWished,
        IG.QntWished / (P.InBox * P.BoxInPal) as PalWished,
        IG.QntConfirmed / P.InBox as BoxConfirmed,
        IG.QntConfirmed / (P.InBox * P.BoxInPal) as PalConfirmed,
        P.InBox, P.BoxInPal as DefaultBoxInPal, P.BoxInRow as DefaultBoxInRow, 
        G.Alias as GoodAlias, 
		G.Name as GoodName, 
		G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingAlias,
        G.Name  + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName,
        G.Weighting, G.Retention, 
        P.BoxHeight
    from	#InputsGoodsQnt IG 
    inner join Packings P on IG.PackingID = P.ID
    inner join Goods G on P.GoodID = G.ID
    left  join PalletsTypes PT on P.PalletTypeID = PT.ID
	-- where 
    order by G.Alias