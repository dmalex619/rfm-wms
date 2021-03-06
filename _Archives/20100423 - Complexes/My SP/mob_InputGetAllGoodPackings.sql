SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_InputGetAllGoodPackings] 
	@nGoodID	int,	-- код товара
	@nInputID	int		-- код прихода
AS
-- Получение списка всех упаковок заданного товара
-- с выделением имеющихся в ожидаемом приходе

set nocount on

select	P.ID, P.ID as PackingID, 
		cast(P.InBox as varchar(10)) as Name, 
		case when isnull(X.PackingID, 0) > 0 then '+ ' else '' end + 
			cast(P.InBox as varchar(10)) + ' ' + 
			case when G.Weighting = 1 then 'кг' else 'шт.' end + ' в кор.' + 
			case when P.Actual = 0 then ' (Н/А)' else '' end as SelectName, 
		G.Alias as GoodName, G.Weighting, G.Retention, 
		P.GoodID, P.PalletTypeID, P.Actual, 
		P.InBox, P.BoxInPal, P.BoxInRow, P.BoxHeight 
	from Packings P with (nolock) 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	left join (select distinct PackingID 
				from InputsGoods IG with (nolock) 
				where InputID = IsNull(@nInputID, 0)) X on X.PackingID = P.ID 
	where P.GoodID = @nGoodID 
	order by ~P.Actual, P.InBox
return