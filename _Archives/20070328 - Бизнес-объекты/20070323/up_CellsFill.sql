set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsFill]
	@nId				int = Null, 
	@cBarCode			varchar(100) = Null, -- штрих-код ячейки
	@bActual			bit = Null, 
	@bLocked			bit = Null, -- ячейки блокированы?
	@cOwnersList		varchar(max) = Null, -- список владельцев (через ,)
	@cGoodsStatesList	varchar(max) = Null, -- список состояний товара (через ,)
	@cCellsStatesStr	varchar(max) = Null, -- строка статусов ячеек (без разделителей)
	@cCBuilding			varchar(2) = Null, -- Адрес: здание
	@cCLine				varchar(2) = Null, -- Адрес: линия
	@cCRack				varchar(2) = Null, -- Адрес: стояк
	@cCLevel			varchar(2) = Null, -- Адрес: уровень
	@cCPlace			varchar(2) = Null, -- Адрес: ячейка
	@cAddress			varchar(25) = Null, -- Адрес
	@nStoreZoneID		int = Null, -- зона склада
	@nFixesPackingID	int = Null, -- товар-упаковка [умолч.]
	@nPalletTypeID		int = Null, -- тип паллеты
	@nMaxWeightMore		numeric(10, 3) = Null, -- max допустимый вес в ячейке (кг), не менее
	@nCellHeightMore	numeric(10, 3) = Null  -- высота ячейки (м), не менее	
AS
BEGIN

select	@cOwnersList = replace(@cOwnersList, ' ', ''),
		@cGoodsStatesList = replace(@cGoodsStatesList, ' ', '')

select	C.ID, C.ID as CellID, C.BarCode, 
		C.FixedOwnerID, C.FixedGoodStateID, C.FixedPackingID, 
		C.StoreZoneID, C.PalletTypeID, 
		C.CBuilding, C.CLine, C.CRack, C.CLevel, C.CPlace, C.Address, 
		C.MaxWeight, 
		C.CellWidth, C.CellHeight, 
		C.State,
		C.GoodsMono, 
		C.Locked, C.Actual, 
		OW.Name as OwnerName,
		GS.Name as GoodStateName, 
		G.Name as GoodName, P.InBox 
	from Cells C
	left join GoodsStates GS on GS.ID  = C.FixedGoodStateID
	left join Partners Ow on C.FixedOwnerID = Ow.ID 
	left join Packings P on C.FixedPackingID = P.ID 
	left join Goods G on P.GoodID = G.ID 
	where	(
			@nID is not Null or @cBarCode is not Null and 
			(@nID is Null or 
				@nID = C.ID) and 
			(@cBarCode is Null or 
				@cBarCode = C.BarCode)
			) 
		or 
			(
			  @nId is Null and @cBarCode is Null and 
			 (@bActual is Null or 
				C.Actual = @bActual) and 
			 (@bLocked is Null or 
				C.Locked = @bLocked) and 
			 (@cOwnersList is Null or 
				charindex(',' + ltrim(str(C.FixedOwnerID)) + ',', ',' + @cOwnersList + ',') > 0) and 
			 (@cGoodsStatesList is Null or 
				charindex(',' + ltrim(str(C.FixedGoodStateID)) + ',', ',' + @cGoodsStatesList + ',') > 0) and 
			 (@cCellsStatesStr is Null or 
				charindex(C.State, @cCellsStatesStr) > 0) and 
			 (@cCBuilding is Null or 
				C.CBuilding = @cCBuilding) and 
			 (@cCLine is Null or 
				C.CLine = @cCLine) and 
			 (@cCRack is Null or 
				C.CRack = @cCRack) and 
			 (@cCLevel is Null or 
				C.CLevel = @cCLevel) and 
			 (@cCPlace is Null or 
				C.CPlace = @cCPlace) and 
			 (@cAddress is Null or 
				C.Address = @cAddress) and 
			 (@nStoreZoneID is Null or 
				C.StoreZoneID = @nStoreZoneID) and 
			 (@nFixesPackingID is Null or 
				C.FixedPackingID = @nFixesPackingID) and 
			 (@nPalletTypeID is Null or 
				C.PalletTypeID = @nPalletTypeID) and 
			 (@nMaxWeightMore is Null or 
				C.MaxWeight >= @nMaxWeightMore) and 
			 (@nCellHeightMore is Null or 
				C.CellHeight >= @nCellHeightMore)
			)
	order by C.BarCode, C.Id
END
