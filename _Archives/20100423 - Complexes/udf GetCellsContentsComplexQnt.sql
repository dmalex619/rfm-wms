set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE FUNCTION [dbo].[GetCellsContentsComplexQnt]
(
	@nPackingID		int,
	@nGoodStateID	int, 
	@nOwnerID		int, 
	@nComplexID		int, 
	@bIncludeDefectCellQnt		bit, 
	@bIncludeLostFoundCellQnt	bit
)
RETURNS  decimal(15, 3)

AS
BEGIN
	declare @nQnt decimal(15, 3)
	set @nQnt = 0
	
	-- ячейка Lost&Found
	declare @nLostFoundCellID int, @nDefectCellID int
	select  @nLostFoundCellID = 0, @nDefectCellID = 0
	if @bIncludeLostFoundCellQnt = 0 begin 
		-- не включать кол-во в ячейке Lost&Found
		declare @cLostFoundAddress varchar(20)
		select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress'), 
				@nLostFoundCellID = Null
		if IsNull(@cLostFoundAddress, '') <> '' begin
			select	top 1 @nLostFoundCellID = ID
				from	Cells
				where	Address = @cLostFoundAddress
		end
		if @nLostFoundCellID is Null 
			set @nLostFoundCellID = 0
	end
	
	-- ячейка Брак
	if @bIncludeDefectCellQnt = 0 begin
		-- не включать кол-во в ячейке Брак
		select	top 1 @nDefectCellID = C.ID
			from	StoresZonesTypes SZT with (nolock)
			inner join StoresZones SZ with (nolock) on SZT.ID = SZ.StoreZoneTypeID
			inner join Cells C with (nolock) on SZ.ID = C.StoreZoneID
			where	SZT.ShortCode = 'DFCT' and 
					IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)
		if @nDefectCellID is Null 
			set @nDefectCellID = 0
	end
	
	if @nOwnerID is not Null begin
		declare @bSeparatePicking bit
		set @bSeparatePicking = 0
		if @nOwnerID is not Null begin
			select	@bSeparatePicking = SeparatePicking 
				from Partners with (nolock) 
				where ID = @nOwnerID
			if @bSeparatePicking = 0 
				set @nOwnerID = Null
		end
	end
	
	-- расчет
	select @nQnt = sum(CC.Qnt) 
		from CellsContents CC with (nolock) 
		inner join Cells C with (nolock) on CC.CellID = C.ID 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
		where 	CC.PackingID = @nPackingID and 
				CC.GoodStateID = @nGoodStateID and 
				IsNull(CC.OwnerID, 0) = IsNull(@nOwnerID, 0) and 
				IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)
	
	declare @nQntInExcludeCells decimal(15, 3)
	if @nDefectCellID <> 0 begin
		select @nQntInExcludeCells = sum(CC.Qnt) 
			from CellsContents CC with (nolock) 
			inner join Cells C with (nolock) on CC.CellID = C.ID 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			where 	CC.CellID = @nDefectCellID and 
					CC.PackingID = @nPackingID and 
					CC.GoodStateID = @nGoodStateID and 
					IsNull(CC.OwnerID, 0) = IsNull(@nOwnerID, 0) and 
					IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)
		set @nQnt = IsNull(@nQnt, 0) - IsNull(@nQntInExcludeCells, 0)
	end
	
	if @nLostFoundCellID <> 0 begin
		set @nQntInExcludeCells = 0
		select @nQntInExcludeCells = sum(CC.Qnt) 
			from CellsContents CC with (nolock) 
			where 	CC.CellID = @nLostFoundCellID and 
					CC.PackingID = @nPackingID and 
					CC.GoodStateID = @nGoodStateID and 
					IsNull(CC.OwnerID, 0) = IsNull(@nOwnerID, 0)
		set @nQnt = IsNull(@nQnt, 0) - IsNull(@nQntInExcludeCells, 0)
	end
	
	return IsNull(@nQnt, 0)
END