set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsGoodsFill] 
	@nOutputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	@nOutputID <> 0 and 
		not exists (select ID from Outputs with (nolock) where ID = IsNull(@nOutputID, 0)) begin
	select	@nError = -1, 
			@cErrorText = 'Не найден расход с кодом ' + ltrim(str(@nOutputID)) + '...'
	raiserror(@cErrorText,16, 1)
	return
end

select TG.PackingID, TG.QntConfirmed as Qnt, TG.OutputGoodID  
	into #Picked 
	from TrafficsGoods TG 
	where TG.OutputID = IsNull(@nOutputID, 0) and TG.DateConfirm is not Null

declare @nCellTargetID int
select @nCellTargetID = CellID 
	from Outputs 
	where ID = IsNull(@nOutputID, 0)
if @nCellTargetID is not Null begin
	select distinct TF.FrameID 
		into #FramesInTraffics 
		from TrafficsFrames TF 
		where OutputID = IsNull(@nOutputID, 0) and 
				TF.DateConfirm is not Null and 
				TF.Success = 1 and 
				TF.CellTargetID = IsNull(@nCellTargetID, 0)
	
	insert #Picked (PackingID, Qnt, OutputGoodID) 
		select OI.PackingID, OI.Qnt, OI.OutputGoodID  
			from OutputsItems OI 
			inner join #FramesInTraffics F on OI.FrameID = F.FrameID 
			where OI.OutputID = IsNull(@nOutputID, 0)
end

select OutputGoodID, max(PackingID) as PackingID, sum(Qnt) as Qnt 
	into #OutputsGoodsPicked 
	from #Picked 
	group by OutputGoodID

declare @nOwnerID int, @nGoodStateID int, @bSeparatePicking bit
select @nOwnerID = OwnerID, @nGoodStateID = GoodStateID 
	from Outputs with (nolock) 
	where ID = IsNull(@nOutputID, 0)
select @bSeparatePicking = SeparatePicking 
	from Partners with (nolock) 
	where ID = IsNull(@nOwnerID, 0)
if @bSeparatePicking = 0 set @nOwnerID = Null

-- соотв. ячейки пикинга
select	ID as OutputGoodID, 
		.dbo.GetPackingPickingCellID(PackingID, @nOwnerID, @nGoodStateID) as CellID 
	into #TableCells 
	from OutputsGoods with (nolock) 
	where OutputID = @nOutputID

-- итоговая выборка
select  OG.ID, OG.ID as OutputGoodID, 
		OG.OutputID, 
		OG.PackingID, P.GoodID, 
		OG.QntWished, OG.QntSelected, OG.QntConfirmed, OG.QntOdd, 
		OG.QntSelected - OG.QntWished as QntSelDiff, 
		OG.QntConfirmed - OG.QntWished as QntDiff, 
		OG.QntWished / P.InBox as BoxWished, 
		cast(OG.QntWished / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished, 
		OG.QntSelected / P.InBox as BoxSelected, 
		cast(OG.QntSelected / P.InBox / P.BoxInPal as decimal(12, 4)) as PalSelected, 
		OG.QntConfirmed / P.InBox as BoxConfirmed, 
		cast(OG.QntConfirmed / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
		OG.QntOdd / P.InBox as BoxOdd, 
		cast(OG.QntOdd / P.InBox / P.BoxInPal as decimal(12, 4)) as PalOdd, 
		(OG.QntSelected - OG.QntWished) / P.InBox as BoxSelDiff, 
		cast((OG.QntSelected - OG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalSelDiff, 
		(OG.QntConfirmed - OG.QntWished) / P.InBox as BoxDiff, 
		cast((OG.QntConfirmed - OG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalDiff, 
		IsNull(TG.Qnt, 0) as QntPicked, 
		IsNull(TG.Qnt, 0) / P.InBox as BoxPicked, 
		cast(IsNull(TG.Qnt, 0) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalPicked, 
		OG.DateValid, OG.IsExists, OG.GoodStateID, 
		OG.ERPNote, 
		
		P.InBox, P.BoxInPal, P.BoxInRow, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, G.HalfStuff, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
		P.BoxHeight, 
		
		C.Address, C.Rank, C.CLine, 
		C.StoreZoneID, SZ.Name as StoreZoneName 
	
	from OutputsGoods OG with (nolock) 
	inner join Packings P with (nolock) on OG.PackingID = P.ID 
	inner join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	left join #OutputsGoodsPicked TG on OG.ID = TG.OutputGoodID 
	left join #TableCells TX on OG.ID = TX.OutputGoodID 
	left join Cells C with (nolock) on TX.CellID = C.ID 
	left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	where OG.OutputID = IsNull(@nOutputID, 0) 
	order by G.Alias, OG.ID
return