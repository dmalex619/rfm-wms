set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsGoodsFill] 
	@nInputID	int, 
	@bTotalQnt	bit = 0, -- только товар и кол-во, без учета состояния товара
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

if @bTotalQnt = 0 begin
	select  IG.ID, IG.ID as InputGoodID, 
			IG.InputID,
			IG.GoodStateID, GS.Name as GoodStateName, 
			IG.PackingID, P.GoodID, 
			IG.QntWished, IG.QntConfirmed, IG.QntConfirmed - IG.QntWished as QntDiff, 
			IG.BoxInPal, IG.BoxInRow, 
			IG.PalletTypeID, PT.Name as PalletTypeName, 
			IG.QntWished / P.InBox as BoxWished, 
			IG.QntWished / (P.InBox * IG.BoxInPal) as PalWished, 
			IG.QntConfirmed / P.InBox as BoxConfirmed, 
			IG.QntConfirmed / (P.InBox * IG.BoxInPal) as PalConfirmed, 
			(IG.QntConfirmed - IG.QntWished) / P.InBox as BoxDiff, 
			(IG.QntConfirmed - IG.QntWished) / (P.InBox * IG.BoxInPal) as PalDiff, 
			P.InBox, P.BoxInPal as DefaultBoxInPal, P.BoxInRow as DefaultBoxInRow, 
			G.Alias as GoodAlias, 			
			G.Name as GoodName, 
			G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingAlias, 
			G.Name  + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName, 
			G.BarCode as GoodBarCode, 
			G.Weighting, G.Retention, 
			P.BoxHeight 
		from InputsGoods IG 
		left join GoodsStates GS on IG.GoodStateID = GS.ID
		left join Packings P on IG.PackingID = P.ID
		left join PalletsTypes PT on P.PalletTypeID = PT.ID 
		left join Goods G on P.GoodID = G.ID
		where InputID = @nInputID
		order by G.Name, IG.ID
end
else begin 
	select	IG.PackingID, 
			sum(IG.QntWished) as QntWished, 
			sum(IG.QntConfirmed) as QntConfirmed, 
			IG.PalletTypeID,
			max(IG.BoxInPal) as BoxInPal   
		into	#InputsGoodsQnt
		from	InputsGoods IG 
		where	IG.InputID = @nInputID
		group by IG.PackingID, IG.PalletTypeID 

	select	@nInputID as InputID, 
			IG.PackingID, P.GoodID, 
			IG.QntWished, IG.QntConfirmed, IG.QntConfirmed - IG.QntWished as QntDiff,  
			IG.PalletTypeID, PT.Name as PalletTypeName, 
			P.BoxInPal, P.BoxInRow,
			IG.QntWished / P.InBox as BoxWished,
			IG.QntWished / (P.InBox * P.BoxInPal) as PalWished,
			IG.QntConfirmed / P.InBox as BoxConfirmed,
			IG.QntConfirmed / (P.InBox * P.BoxInPal) as PalConfirmed,
			(IG.QntConfirmed - IG.QntWished) / P.InBox as BoxDiff, 
			(IG.QntConfirmed - IG.QntWished) / (P.InBox * IG.BoxInPal) as PalDiff, 
			P.InBox, P.BoxInPal as DefaultBoxInPal, P.BoxInRow as DefaultBoxInRow, 
			G.Alias as GoodAlias, 
			G.Name as GoodName, 
			G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingAlias,
			G.Name  + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName,
			G.BarCode as GoodBarCode, 
			G.Weighting, G.Retention, 
			P.BoxHeight
		from	#InputsGoodsQnt IG 
		inner join Packings P on IG.PackingID = P.ID
		inner join Goods G on P.GoodID = G.ID
		left  join PalletsTypes PT on P.PalletTypeID = PT.ID
		-- where 
		order by G.Alias
end