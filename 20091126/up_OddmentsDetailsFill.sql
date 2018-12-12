set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OddmentsDetailsFill]
	@nOwnerID			int = Null, -- владелец
	@nGoodStateID		int = Null, -- состояние товара
	@nPackingID			int = Null, -- код упаковки
	@bDateValidGroup	bit = 0,   -- группировать по срокам годности
	-- по сроку годности
	@nCheckDateValid	int = Null -- Null без анализа, % осталось менее, -1 просрочен, -2 завышен
AS

set nocount on

declare @dNow smalldatetime
select	@dNow = GetDate()

select	CC.CellID, CC.FrameID, 
		CC.OwnerID, CC.GoodStateID, CC.PackingID, 
		CC.Qnt, CC.DateValid, CC.DateLastOperation, CC.ID as CellsContentsID 
	into	#CellsContents_Temp 
	from	CellsContents CC with (nolock) 
	left join Packings P with (nolock) on CC.PackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	where	IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1) and 
			(@nGoodStateID is Null or CC.GoodStateID = @nGoodStateID) and 
			(@nPackingID is Null or CC.PackingID = @nPackingID) and 
			(@nCheckDateValid is Null or 
			 (@nCheckDateValid = -1 and -- просрочен
				CC.DateValid is not Null and datediff(day, CC.DateValid, @dNow) > 0) or 
			 (@nCheckDateValid = -2 and -- завышен
				G.Retention >= 30 and 
				CC.DateValid is not Null and datediff(day, dateadd(day, G.Retention, @dNow), CC.DateValid) > 0) or 
			 (@nCheckDateValid between 0 and 100 and -- %
				CC.DateValid is not Null and datediff(day, @dNow, CC.DateValid) > 0 and 
											 datediff(day, CC.DateValid, dateadd(day, G.Retention * @nCheckDateValid / 100, @dNow)) > 0)
			)

select	CellID, FrameID, 
		OwnerID, GoodStateID, PackingID, 
		Qnt, DateValid, DateLastOperation, IsNull(ID, 0) as CellsContentsID 
	into #CellsContents 
	from CellsContents with (nolock) 
	where 1 = 2

if @bDateValidGroup = 1 begin
	insert	#CellsContents 
			(CellID, FrameID, 
			OwnerID, GoodStateID, PackingID, 
			Qnt, DateValid, DateLastOperation, CellsContentsID) 
		select	CellID, FrameID, 
				OwnerID, GoodStateID, PackingID, 
				sum(Qnt), min(DateValid), max(DateLastOperation), Null 
			from	#CellsContents_Temp 
			group by CellID, FrameID, OwnerID, GoodStateID, PackingID
end
else begin
	insert	#CellsContents 
			(CellID, FrameID, 
			OwnerID, GoodStateID, PackingID, 
			Qnt, DateValid, DateLastOperation, CellsContentsID) 
		select	CellID, FrameID, 
				OwnerID, GoodStateID, PackingID, 
				Qnt, DateValid, DateLastOperation, CellsContentsID 
			from	#CellsContents_Temp
end 

select	CC.OwnerID, Ow.Name as OwnerName, Ow.SeparatePicking, 
		CC.GoodStateID, GS.Name as GoodStateName, 
		CC.CellID, C.Address as CellAddress, C.BarCode as CellBarCode, C.Locked, 
		C.StoreZoneID, SZ.Name as StoreZoneName, 
		SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, 
		CC.FrameID, F.BarCode as FrameBarCode, 
		CC.Qnt, CC.DateValid, CC.DateLastOperation, 
		CC.PackingID, P.GoodID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal, 
		CC.Qnt / P.InBox as BoxQnt, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
	(case when CC.DateValid is Null or G.Retention = 0 then Null else 
			datediff(day, getdate(), IsNull(CC.DateValid, getdate())) * 100 / G.Retention 
		end) as DateValidPercent, 
		CC.CellsContentsID 
	from	#CellsContents CC 
	left join Cells C with (nolock) on CC.CellID = C.ID 
	left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	left join Frames F with (nolock) on CC.FrameID = F.ID 
	left join Partners Ow with (nolock) on CC.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
	left join Packings P with (nolock) on CC.PackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	order by G.Alias, CC.DateValid, C.Address, F.ID
return