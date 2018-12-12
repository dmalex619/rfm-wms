set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_ReportInputsFrames]
	@dDateBeg			smalldatetime	= Null, 
	@dDateEnd	 		smalldatetime	= Null, 
	@dDateBegConfirm	smalldatetime	= Null, 
	@dDateEndConfirm	smalldatetime	= Null, 
	@bConfirmed			bit				= Null, 
	@cUsersList			varchar(max)	= Null, 
	@cFrameBarCodeContext varchar(100)	= Null, 
	@cPackingsList		varchar(max)	= Null 
AS

set nocount on

select	@cUsersList		= ',' + replace(@cUsersList,	' ', '') + ',',
		@cPackingsList	= ',' + replace(@cPackingsList,	' ', '') + ','

select	F.ID, F.ID as FrameID, F.BarCode, 
		F.OwnerID, Ow.Name as OwnerName, 
		F.GoodStateID, GS.Name as GoodStateName, 
		F.DateBirth, F.DateLastOperation, 
		dbo.IsFrameGoodsMono(F.ID) as GoodsMono, 
		F.State, 
		F.Actual, 
		F.FrameHeight, dbo.GetFrameWeight(F.ID) as FrameWeight, 
		F.PalletTypeID, PT.Name as PalletTypeName, 
		C.ID as CellID, C.Address as CellAddress, C.BarCode as CellBarCode, 
		C.StoreZoneID, SZ.Name as StoreZoneName, 
		SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, SZT.ShortCode, 
		II.PackingID, P.GoodID, 
		P.InBox, P.BoxInPal, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
		II.Qnt, 
		II.Qnt / P.InBox as BoxQnt, 
		cast(II.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		II.DateValid, 
		I.DateInput, I.DateConfirm, 
		II.UserID, U.Name as UserName, 
		PR.Name as PartnerName, 
		I.Note as InputNote
 	from Frames F with (nolock) 
	inner join InputsItems II with (nolock) on II.FrameID = F.ID 
	left  join Partners OW with (nolock) on F.OwnerID = OW.ID 
	inner join GoodsStates GS with (nolock) on F.GoodStateID = GS.ID 
	left  join PalletsTypes PT on F.PalletTypeID = PT.ID
	inner join Cells C with (nolock) on II.CellID = C.ID 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	inner join Packings P with (nolock) on II.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	inner join Inputs I with (nolock) on I.ID = II.InputID
	left  join Partners PR  with (nolock) on I.PartnerID = PR.ID 
	left  join _Users U with (nolock) on II.UserID = U.ID 
	where	 (@bConfirmed is Null or
				@bConfirmed = 0 and I.DateConfirm is Null or
				@bConfirmed = 1 and I.DateConfirm is not Null) and 
			 (@dDateBeg is Null or 
				datediff(day, @dDateBeg, I.DateInput) >= 0) and 
			 (@dDateEnd is Null or 
				datediff(day, I.DateInput, @dDateEnd) >= 0) and 
			 (@dDateBegConfirm is Null or 
				datediff(day, @dDateBegConfirm, I.DateConfirm) >= 0) and 
			 (@dDateEndConfirm is Null or 
				datediff(day, I.DateConfirm, @dDateEndConfirm) >= 0) and 
			 (@cUsersList is Null or 
				charindex(',' + ltrim(str(II.UserID)) + ',', @cUsersList) > 0) and 
			 (@cFrameBarCodeContext is Null or 
				charindex(@cFrameBarCodeContext, F.BarCode) > 0) and
			 (@cPackingsList is Null or 
				charindex(',' + ltrim(str(II.PackingID)) + ',', @cPackingsList) > 0)
	order by II.DateConfirm desc, F.ID
return