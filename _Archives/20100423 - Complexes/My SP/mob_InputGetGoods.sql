SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_InputGetGoods] 
	@nInputID	int
AS
-- Получение списка товаров в приходе

set nocount on

select	IG.ID, IG.ID as InputGoodID, 
		IG.InputID, IG.GoodStateID as WaitingGoodStateID, 
		IG.PackingID, P.GoodID, 
		IG.QntWished, IG.QntConfirmed, 
		P.BoxInPal, P.BoxInRow, 
		IG.QntWished / P.InBox as BoxWished, 
		cast(IG.QntWished / (P.InBox * P.BoxInPal) as decimal(12,4)) as PalWished, 
		IG.QntConfirmed / P.InBox as BoxConfirmed, 
		cast(IG.QntConfirmed / (P.InBox * P.BoxInPal) as decimal(12,4)) as PalConfirmed, 
		P.InBox, P.BoxInPal as DefaultBoxInPal, P.BoxInRow as DefaultBoxInRow, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName, 
		G.Weighting, G.Retention, 
		P.BoxHeight 
	from InputsGoods IG with (nolock) 
	inner join Packings P with (nolock) on IG.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where IG.InputID = IsNull(@nInputID, 0) 
	order by G.Name, IG.ID
return