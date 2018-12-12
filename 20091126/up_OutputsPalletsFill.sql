set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsPalletsFill]
	@nOutputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	@nOutputID <> 0 and 
		not exists (select ID from Outputs with (nolock) where ID = IsNull(@nOutputID, 0)) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден расход с кодом ' + ltrim(str(@nOutputID)) + '...'
	raiserror(@cErrorText, 16, 1)
	return
end

select	OG.ID as OutputGoodID, 
		OG.PackingID, P.InBox, P.BoxInRow, 
		OG.QntWished, 
		OG.QntWished / P.InBox as BoxWished, 
		cast(OG.QntWished / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished, 
		CC.Qnt as QntConfirmed, 
		CC.Qnt / P.InBox as BoxConfirmed, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
		OG.QntOdd, 
		OG.QntOdd / P.InBox as BoxOdd, 
		cast(OG.QntOdd / P.InBox / P.BoxInPal as decimal(12, 4)) as PalOdd, 
		IsNull(CC.DateValid, cast(Null as smalldatetime)) as DateValid, 
		CC.FrameID, 
		F.FrameHeight, 
		P.BoxHeight, 
		CC.ID as FCID, 
		dbo.IsFrameGoodsMono(F.ID) as GoodsMono, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.Articul, 
		G.BarCode as GoodBarCode, 
		G.Weighting, G.Retention 
	from OutputsGoods OG with (nolock) 
	inner join Packings P with (nolock) on OG.PackingID = P.ID 
	inner join Goods G with (nolock) on G.ID = P.GoodID 
	inner join OutputsItems OI with (nolock) on OG.OutputID = OI.OutputID and OG.PackingID = OI.PackingID 
	inner join Frames F with (nolock) on OI.FrameID = F.ID 
	inner join CellsContents CC with (nolock) on F.ID = CC.FrameID and OG.PackingID = CC.PackingID 
	where OG.OutputID = IsNull(@nOutputID, 0) 
	order by G.Alias, OG.ID
return