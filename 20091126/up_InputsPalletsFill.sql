set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsPalletsFill]
	@nInputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS
-- используется при редактировании прихода в desktop-части

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs where ID = IsNull(@nInputID, 0)) begin
	select	@nError = -1, 
			@cErrorText = 'Не найден приход с кодом ' + ltrim(str(@nInputID)) + '...'
	raiserror (@cErrorText, 11, 1)
	return
end

select	IG.ID as InputGoodID, 
		II.ID as InputItemID, 
		II.PackingID, P.InBox, P.BoxInPal, P.BoxInRow, 
		P.PalletTypeID, 
		IsNull(IG.QntWished, 0) as QntWished, 
		IsNull(IG.QntWished, 0) / P.InBox as BoxWished, 
		cast(IsNull(IG.QntWished, 0) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished, 
		II.Qnt as QntConfirmed, 
		II.Qnt / P.InBox as BoxConfirmed, 
		cast(II.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
		IsNull(II.DateValid, cast(Null as smalldatetime)) as DateValid, 
		CC.FrameID, 
		F.FrameHeight, 
		GS.ID as GoodStateID, GS.Name as GoodStateName, 
		P.BoxHeight, 
		II.ID as InputItemID, 
		II.CellID, C.Address as CellAddress, 
		C.StoreZoneID, SZ.StoreZoneTypeID, 
		dbo.IsFrameGoodsMono(F.ID) as GoodsMono, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		cast(case when II.FrameID is null then 0 else 1 end as bit) as IsFrame, 
		cast(case when TF.DateConfirm is null and TF.DateAccept is Null then 0 else 1 end as bit) as IsDisplaced, 
		cast(case when TF.ID is Null then 0 else 1 end as bit) as TrafficCreated 
	from InputsItems II with (nolock) 
	left  join InputsGoods IG with (nolock) on IG.InputID = II.InputID and IG.PackingID = II.PackingID and IG.GoodStateID = II.GoodStateID 
	inner join Packings P with (nolock) on II.PackingID = P.ID 
	inner join Goods G with (nolock) on G.ID = P.GoodID 
	inner join GoodsStates GS with (nolock) on GS.ID = II.GoodStateID 
	left  join Frames F with (nolock) on II.FrameID = F.ID 
	left  join CellsContents CC with (nolock) on F.ID = CC.FrameID and II.PackingID = CC.PackingID and II.GoodStateID = CC.GoodStateID 
	left  join Cells C with (nolock) on II.CellID = C.ID 
	left  join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left  join TrafficsFrames TF with (nolock) on F.ID = TF.FrameID and TF.InputID = IsNull(@nInputID, 0) and TF.CellSourceID = II.CellID 
	where II.InputID = IsNull(@nInputID, 0) 
	order by II.ID, G.Alias
return