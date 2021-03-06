set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsPalletsFill]
	@nInputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs where ID = @nInputID) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден приход № ' + ltrim(str(@nInputID)) + '...'
	RAISERROR (@cErrorText, 11, 1);
	return
end

select	IG.ID as InputGoodID, 
		G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as GoodAlias,
		G.Name + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as GoodName,
		IG.PackingID, P.InBox, IG.BoxInPal, P.BoxInRow, IG.PalletTypeID, 
		IG.QntWished, 
		IG.QntWished / P.InBox as BoxWished, 
		IG.QntWished / P.InBox / IG.BoxInPal as PalWished, 
		CC.Qnt as QntConfirmed, 
		CC.Qnt / P.InBox as BoxConfirmed, 
		CC.Qnt / P.InBox / IG.BoxInPal as PalConfirmed, 
		isnull(CC.DateValid, cast(Null as smalldatetime)) as DateValid, 
		CC.FrameID,
		F.FrameHeight, 
		GS.ID as GoodStateID, GS.Name as GoodStateName, 
		P.BoxHeight,
		CC.ID as FCID, 
		F.GoodsMono, 
		G.Weighting
	from InputsGoods IG 
	inner join Packings P on IG.PackingID = P.ID
	inner join Goods G on G.ID = P.GoodID
	inner join Frames F on IG.InputID = F.InputID 
	inner join CellsContents CC on F.ID = CC.FrameID and IG.GoodStateID = CC.GoodStateID and IG.PackingID = CC.PackingID
	inner join GoodsStates GS  on GS.ID = F.GoodStateID
	where IG.InputID = @nInputID	
	order by G.Alias, IG.ID