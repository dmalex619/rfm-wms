set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsFill]
	-- параметры для поиска одной ячейки
	@nID					int				= Null, 
	-- параметры для поиска ячеек
	@cIDList				varchar(max)	= Null, -- список Cells.ID (через ,) 
	@cComplexesList			varchar(max)	= Null, -- список кодов комплексов (через ,)
	@cBarCode				varchar(100)	= Null,	-- штрих-код ячейки
	@bActual				bit				= Null,	-- ячейки актуальны?
	@bLocked				bit				= Null,	-- ячейки блокированы?
	@bHasCellContent		bit				= Null,	-- есть наполнение ячейки?
	@bIsFull				bit				= Null, -- ячейка заполнена полностью?
	@bTrafficsToExists		bit				= Null, -- есть подготовленные траффики в ячейку
	@bTrafficsFromExists	bit				= Null, -- есть подготовленные траффики из ячейки
	@cFixedOwnersList		varchar(max)	= Null,	-- список владельцев (через ,)
	@cFixedGoodsStatesList	varchar(max)	= Null,	-- список состояний товара (через ,)
	@cCellsStatesStr		varchar(max)	= Null,	-- строка статусов ячеек (без разделителей)
	@cCBuilding				varchar(10)		= Null,	-- Адрес: здание
	@cCLine					varchar(10)		= Null,	-- Адрес: линия
	@cCRack					varchar(10)		= Null,	-- Адрес: стояк
	@cCLevel				varchar(10)		= Null,	-- Адрес: уровень
	@cCPlace				varchar(10)		= Null,	-- Адрес: ячейка
	@cAddress				varchar(25)		= Null,	-- Адрес полностью
	@cAddressContext		varchar(25)		= Null,	-- Адрес контекст
	@cStoresZonesList		varchar(max)	= Null,	-- список складских зон (через ,)
	@cStoresZonesTypesList	varchar(max)	= Null, -- список типов складских зон (через ,)
	@cStoreZoneTypeShortCode varchar(5)		= Null, -- символьный код типа складской зоны
	@bForInputs				bit				= Null, -- для приходов?
	@bForOutputs			bit				= Null, -- для отгрузок?
	@bForStorage			bit				= Null, -- для хранения?
	@bForPicking			bit				= Null, -- для пикинга?
	@bForFrames				bit				= Null, -- для контейнеров? (в т.ч. Null)
	@cFixedPackingsList		varchar(max)	= Null,	-- список упаковок (через ,)
	@cFixedGoodsList		varchar(max)	= Null,	-- список товаров (через ,)
	@cPalletsTypesList		varchar(max)	= Null,	-- список типов поддонов (через ,)
	@nMaxWeightBeg			numeric(10, 3)	= Null,	-- max допустимый вес в ячейке (кг), от
	@nMaxWeightEnd			numeric(10, 3)	= Null,	-- max допустимый вес в ячейке (кг), до
	@nCellHeightBeg			numeric(10, 3)	= Null,	-- высота ячейки (м), от	
	@nCellHeightEnd			numeric(10, 3)	= Null,	-- высота ячейки (м), до
	@nCellWidthBeg			numeric(10, 3)	= Null,	-- ширина ячейки (м), от	
	@nCellWidthEnd			numeric(10, 3)	= Null,	-- ширина ячейки (м), до
	-- параметры для поиска ячеек по содержимому
	@cCellsContentsOwnersList		varchar(max) = Null, -- список владельцев (через ,)
	@cCellsContentsGoodsStatesList	varchar(max) = Null, -- список состояний товара (через ,)
	@cCellsContentsPackingsList		varchar(max) = Null, -- список упаковок (через ,)
	@cCellsContentsGoodsList		varchar(max) = Null, -- список товаров (через ,)
	@cCellsContentsFramesList		varchar(max) = Null, -- список контейнеров (через ,)
	-- по сроку годности содержимого
	@nCheckDateValid		int = Null -- Null без анализа, % осталось менее, -1 просрочен, -2 завышен
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- для поиска по содержимому
declare @bCellsContents bit
set @bCellsContents = 0
select CellID 
	into #CellsContents 
	from CellsContents with (nolock) 
	where 1 = 2
if	@cCellsContentsOwnersList		is not Null or 
	@cCellsContentsGoodsStatesList 	is not Null or 
	@cCellsContentsPackingsList		is not Null or 
	@cCellsContentsGoodsList		is not Null or 
	@cCellsContentsFramesList		is not Null or 
	@nCheckDateValid is not Null begin
	
	set @bCellsContents = 1

	set @cSelect = '
	insert #CellsContents (CellID) 
		select CellID 
			from CellsContents CC with (nolock) 
			left  join Partners Ow with (nolock) on CC.OwnerID = Ow.ID 
			left  join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
			inner join Packings P with (nolock) on CC.PackingID = P.ID 
			inner join Goods G with (nolock) on P.GoodID = G.ID '
	set @cWhere = '	where 1 = 1 '
	if @cCellsContentsOwnersList is not Null
		set @cWhere = @cWhere + ' and IsNull(CC.OwnerID, -1) in (' + dbo._NormalizeList(@cCellsContentsOwnersList) + ')'
	if @cCellsContentsGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and CC.GoodStateID in (' + dbo._NormalizeList(@cCellsContentsGoodsStatesList) + ')'
	if @cCellsContentsPackingsList is not Null
		set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cCellsContentsPackingsList) + ')'
	if @cCellsContentsGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cCellsContentsGoodsList) + ')'
	if @cCellsContentsFramesList is not Null
		set @cWhere = @cWhere + ' and IsNull(CC.FrameID, -1) in (' + dbo._NormalizeList(@cCellsContentsFramesList) + ')'
	if @nCheckDateValid is not Null begin
		declare @cNow varchar(12)
		select @cNow = '''' + convert(char(10), GetDate(), 112) + '''' 
		if @nCheckDateValid = -1 -- просрочен
			set @cWhere = @cWhere + ' and CC.DateValid is not Null 
									  and datediff(day, CC.DateValid, ' + @cNow + ') > 0 '
		if @nCheckDateValid = -2 -- завышен
			set @cWhere = @cWhere + ' and G.Retention >= 30
									  and CC.DateValid is not Null 
									  and datediff(day, dateadd(day, G.Retention, ' + @cNow + '), CC.DateValid) > 0 '
		if @nCheckDateValid between 0 and 100 -- %
			set @cWhere = @cWhere + ' and CC.DateValid is not Null 
									  and datediff(day, ' + @cNow + ', CC.DateValid) > 0 
									  and datediff(day, CC.DateValid, dateadd(day, G.Retention * ' + ltrim(str(@nCheckDateValid)) + ' / 100, ' + @cNow + ')) > 0 '
	end
	set @cSelect = @cSelect + @cWhere
	exec (@cSelect)
end

-- итоговая выборка
set @cSelect = 
'select	C.ID, C.ID as CellID, C.BarCode, 
		C.StoreZoneID, SZ.Name as StoreZoneName, 
		SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, SZT.ShortCode as StoreZoneTypeShortCode, 
		SZT.ForFrames, 
		SZT.ForStorage, SZT.ForInputs, SZT.ForOutputs, SZT.ForPicking, 
		SZ.ComplexID, Cx.Name as ComplexName, 
		C.CBuilding, C.CLine, C.CRack, C.CLevel, C.CPlace, C.Address, 
		C.MaxWeight, 
		C.CellWIDth, C.CellHeight, 
		C.State, 
		C.GoodsMono, 
		C.Locked, 
		C.Actual, 
		C.Rank, 
		C.MaxPalletQnt, SZ.MaxPalletQnt as StoreZoneMaxPalletQnt, 
		C.PalletTypeID, PT.Name as PalletTypeName, 
		SZ.TemperatureMode, 
		C.FixedOwnerID, OW.Name as FixedOwnerName, 
		C.FixedGoodStateID, GS.Name as FixedGoodStateName, 
		C.FixedPackingID, G.Articul as FixedArticul, 
		C.BufferCellID, CB.Address as BufferAddress, 
		P.InBox, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Alias + '' ('' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + '')'' as PackingAlias, 
		cast(case	when G.Actual is Null or P.Actual is Null then Null 
					when G.Actual = 1 and P.Actual = 1 then 1 
					else 0 end as bit) as FixedGoodAndPackingActual, 
		cast(case when exists (select top 1 CC.ID from CellsContents CC where CC.CellID = C.ID and CC.Qnt > 0) then 1 else 0 end as bit) as HasCellContent, 
		C.IsFull, C.ErpCode 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	left  join Complexes Cx with (nolock) on SZ.ComplexID = Cx.ID 
	left  join Partners Ow with (nolock) on C.FixedOwnerID = Ow.ID 
	left  join GoodsStates GS with (nolock) on GS.ID = C.FixedGoodStateID 
	left  join PalletsTypes PT with (nolock) on C.PalletTypeID = PT.ID 
	left  join Packings P with (nolock) on C.FixedPackingID = P.ID 
	left  join Goods G with (nolock) on P.GoodID = G.ID 
	left  join Cells CB with (nolock) on C.BufferCellID = CB.ID '

set @cWhere = 'where C.Deleted = 0 '
if @nID is not Null begin
	set @cWhere = @cWhere + ' and C.ID = ' + ltrim(str(@nID))
end
else begin
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and C.ID in (' + dbo._NormalizeList(@cIDList) + ')'
	
	if @cComplexesList is not Null
		set @cWhere = @cWhere + ' and SZ.ComplexID in (' + dbo._NormalizeList(@cComplexesList) + ') '

	if @cBarCode is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cBarCode + ''', C.BarCode) > 0'
	if @bActual is not Null
		set @cWhere = @cWhere + ' and C.Actual = ' + ltrim(str(@bActual))
	if @bLocked is not Null
		set @cWhere = @cWhere + ' and C.Locked = ' + ltrim(str(@bLocked))
	
	if @bHasCellContent is not Null
		set @cWhere = @cWhere + ' and C.ID ' + 
			case when @bHasCellContent = 1 then '' else 'not ' end + 
			'in (select CellID from CellsContents with (nolock) where Qnt > 0)'
	if @bIsFull is not Null
		set @cWhere = @cWhere + ' and C.IsFull = ' + ltrim(str(@bIsFull))
	
	if @bTrafficsToExists is not Null
		set @cWhere = @cWhere + ' and C.ID ' + 
			case when @bTrafficsToExists = 1 then '' else 'not ' end + 
			'in (select CellTargetID from TrafficsFrames TF1 with (nolock) where TF1.DateConfirm is Null)'
	if @bTrafficsFromExists is not Null
		set @cWhere = @cWhere + ' and C.ID ' + 
			case when @bTrafficsFromExists = 1 then '' else 'not ' end + 
			'in (select CellSourceID from TrafficsFrames TF1 with (nolock) where TF1.DateConfirm is Null)'
	
	if @cFixedOwnersList is not Null
		set @cWhere = @cWhere + ' and IsNull(C.FixedOwnerID, 0) in (' + dbo._NormalizeList(@cFixedOwnersList) + ')'
	if @cFixedGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and IsNull(C.FixedGoodStateID, 0) in (' + dbo._NormalizeList(@cFixedGoodsStatesList) + ')'
	if @cFixedPackingsList is not Null
		set @cWhere = @cWhere + ' and IsNull(C.FixedPackingID, 0) in (' + dbo._NormalizeList(@cFixedPackingsList) + ')'
	if @cFixedGoodsList is not Null
		set @cWhere = @cWhere + ' and IsNull(P.GoodID, 0) in (' + dbo._NormalizeList(@cFixedGoodsList) + ')'
	if @cPalletsTypesList is not Null
		set @cWhere = @cWhere + ' and IsNull(C.PalletTypeID, 0) in (' + dbo._NormalizeList(@cPalletsTypesList) + ')'
	if @cCellsStatesStr is not Null
		set @cWhere = @cWhere + ' and IsNull(C.State, '''') in (' + dbo._NormalizeList(@cCellsStatesStr) + ')'
	
	if @cCBuilding is not Null
		set @cWhere = @cWhere + ' and IsNull(C.CBuilding, '''') = ''' + @cCBuilding + ''''
	if @cCLine is not Null
		set @cWhere = @cWhere + ' and IsNull(C.CLine, '''') = ''' + @cCLine + ''''
	if @cCRack is not Null
		set @cWhere = @cWhere + ' and IsNull(C.CRack, '''') = ''' + @cCRack + ''''
	if @cCLevel is not Null
		set @cWhere = @cWhere + ' and IsNull(C.CLevel, '''') = ''' + @cCLevel + ''''
	if @cCPlace is not Null
		set @cWhere = @cWhere + ' and IsNull(C.CPlace, '''') = ''' + @cCPlace + ''''
	if @cAddress is not Null
		set @cWhere = @cWhere + ' and IsNull(C.Address, '''') = ''' + @cAddress + ''''
	if @cAddressContext is not Null begin 
		if charindex('%', @cAddressContext) > 0 or charindex('_', @cAddressContext) > 0 
			set @cWhere = @cWhere + ' and C.Address like ''' + @cAddressContext + ''''
		else 
			set @cWhere = @cWhere + ' and charindex(upper(''' + @cAddressContext + '''), C.Address) > 0'
	end

	if @cStoresZonesList is not Null
		set @cWhere = @cWhere + ' and IsNull(C.StoreZoneID, 0) in (' + dbo._NormalizeList(@cStoresZonesList) + ')'
	if @cStoresZonesTypesList is not Null
		set @cWhere = @cWhere + ' and IsNull(SZ.StoreZoneTypeID, 0) in (' + dbo._NormalizeList(@cStoresZonesTypesList) + ')'
	if @cStoreZoneTypeShortCode is not Null
		set @cWhere = @cWhere + ' and IsNull(SZT.ShortCode, 0) in (''' + dbo._NormalizeList(@cStoreZoneTypeShortCode) + ''')'
	
	if @bForInputs is not Null
		set @cWhere = @cWhere + ' and SZT.ForInputs = ' + ltrim(str(@bForInputs))
	if @bForOutputs is not Null
		set @cWhere = @cWhere + ' and SZT.ForOutputs = ' + ltrim(str(@bForOutputs))
	if @bForStorage is not Null
		set @cWhere = @cWhere + ' and SZT.ForStorage = ' + ltrim(str(@bForStorage))
	if @bForPicking is not Null
		set @cWhere = @cWhere + ' and SZT.ForPicking = ' + ltrim(str(@bForPicking))
	if @bForFrames is not Null
		set @cWhere = @cWhere + ' and (SZT.ForFrames is Null or SZT.ForFrames = ' + ltrim(str(@bForFrames)) + ')'
	
	if @nMaxWeightBeg is not Null
		set @cWhere = @cWhere + ' and C.MaxWeight >= ' + ltrim(str(@nMaxWeightBeg))
	if @nMaxWeightEnd is not Null
		set @cWhere = @cWhere + ' and C.MaxWeight <= ' + ltrim(str(@nMaxWeightEnd))
	
	if @nCellHeightBeg is not Null
		set @cWhere = @cWhere + ' and C.CellHeight >= ' + str(@nCellHeightBeg, 15, 3)
	if @nCellHeightEnd is not Null
		set @cWhere = @cWhere + ' and C.CellHeight <= ' + str(@nCellHeightEnd, 15, 3)
	if @nCellWidthBeg is not Null
		set @cWhere = @cWhere + ' and C.CellWidth >= ' + str(@nCellWidthBeg, 15, 3)
	if @nCellWidthEnd is not Null
		set @cWhere = @cWhere + ' and C.CellWidth <= ' + str(@nCellWidthEnd, 15, 3)
	
	if @bCellsContents <> 0
		set @cWhere = @cWhere + ' and C.ID in (select CellID from #CellsContents)'
end

set @cOrderBy = ' order by '
if @cIDList is not Null
	set @cOrderBy  = @cOrderBy + 'charindex('','' + ltrim(str(C.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy  = @cOrderBy + 'C.BarCode, C.ID'

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return