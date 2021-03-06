set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_FramesArrange]
	@nFrameID		int,				-- исходный контейнер
	@nAccCell		int = Null output,	-- искомая ячейка
	@nError			int = 0 output, 
	@cErrorText		varchar(MAX) = '' output, 
	@bCreateTraffic bit = 1,			-- флаг нужно ли создавать трафик 
	@nComplexID		int = Null
AS

set nocount on

-- всяческие проверки
-- получим данные контейнера
declare @cFrameState char(1), @bFrameGoodsMono bit
select	@cFrameState = F.State, @bFrameGoodsMono = .dbo.IsFrameGoodsMono(F.ID) 
	from	Frames F with (nolock) 
	where	F.ID = IsNull(@nFrameID, 0) and F.Actual = 1

-- есть такой контейнер?
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorText = 'Не найден контейнер с кодом ' + ltrim(str(@nFrameID)) + '...'
	return
end

if not (IsNull(@cFrameState, '') in ('I', 'S', '')) begin
	select	@nError = -2, 
			@cErrorText = 'Контейнер с кодом ' + ltrim(str(@nFrameID)) + ' имеет статус ''' + @cFrameState + ''' и не готов к размещению...'
	return
end

if exists (select ID 
			from	TrafficsFrames with (nolock) 
			where	FrameID = IsNull(@nFrameID, 0) and DateConfirm is Null) begin
	select	@nError = -3, 
			@cErrorText = 'Для контейнера с кодом ' + ltrim(str(@nFrameID)) + ' есть незавершенные операции транспортировки...'
	return
end

-- есть содержимое у контейнера?
declare @nCnt int
select	@nCnt = count(ID) 
	from	CellsContents with (nolock) 
	where	FrameID = IsNull(@nFrameID, 0)
if @nCnt < 1 begin
	select	@nError = -4, 
			@cErrorText = 'Не найдено содержимое контейнера с кодом ' + ltrim(str(@nFrameID)) + '...'
	return
end

/*
-- содержимое контейнера соответствует признаку "монотовар"?
if dbo.IsFrameGoodsMono(@nFrameID) = 0 begin 
	select	@nError = -5, 
		@cErrorText = 'Контейнер с кодом ' + ltrim(str(@nFrameID)) + ' содержит разные товары и не подлежит автоматическому размещению...'
	return
end
*/

-- контейнер находится в ячейке? 
declare @nCellSourceID int, @bCellLocked bit, @bSpecial bit
select @nCellSourceID = CC.CellID, @bCellLocked = C.Locked, @bSpecial = SZT.Special, 
		@nComplexID = case when @nComplexID is Null then SZ.ComplexID else @nComplexID end 
	from CellsContents CC with (nolock) 
	inner join Cells C with (nolock) on CC.CellID = C.ID 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where CC.FrameID = IsNull(@nFrameID, 0) and C.Deleted = 0
if @@RowCount = 0 begin
	select	@nError = -6, 
			@cErrorText = 'Не определена ячейка, в которой находится контейнер с кодом ' + ltrim(str(@nFrameID)) + '...'
	return
end

-- не блокирована ли исходная ячейка, в которой сейчас находится контейнер?
-- не учитываем ячейки в типе зоны Special
if @bCellLocked = 1 and @bSpecial = 0 begin
	select	@nError = -7, 
			@cErrorText = 'Ячейка, в которой находится контейнер с кодом ' + ltrim(str(@nFrameID)) + ', блокирована...'
	return
end
-- собственно процедура

-- рабочие переменные, опр по @nFrameID
declare @nFrameCell int, @nFrameZoneTypeID int, @nFrameZoneID int, @nOwnerID int, @nInputID int
declare @nGoodStateID int, @nPackingID int, @nPalletTypeID int, @nMaxWeight numeric(10,3), @cTemperatureMode varchar(1)
declare @nFrameWeight numeric(10,3), @nFrameHeight numeric(10,3), @bHalfStuff bit, @bFullPallet bit
declare @dDateValid smalldatetime

-- остальные переменные
declare @cCommand nvarchar(1000), @nPickingCellID int, @cPickingCell varchar(25), @cWhere varchar(2000)
declare @cBuilding varchar(10), @cLine varchar(10), @cRack varchar(10)

select @nFrameCell = ID, @nFrameZoneID = StoreZoneID, @nMaxWeight = MaxWeight 
	from Cells with (nolock) 
	where ID = (select distinct CellID from CellsContents where FrameID = IsNull(@nFrameID, 0))

select @nFrameZoneTypeID = StoreZoneTypeID 
	from StoresZones with (nolock) 
	where ID = @nFrameZoneID

select top 1 @nInputID = InputID 
	from InputsItems with (nolock) 
	where FrameID = IsNull(@nFrameID, 0) 
	order by ID desc

declare @bSeparatePicking bit
select @bSeparatePicking = P.SeparatePicking, @nOwnerID = I.OwnerID 
	from Inputs I with (nolock) 
	inner join Partners P on P.ID = I.OwnerID 
	where I.ID = @nInputID

if @bSeparatePicking = 0 
	set @nOwnerID = Null

select @nGoodStateID = GoodStateID, @nPalletTypeID = PalletTypeID, @nFrameHeight = FrameHeight 
	from Frames with (nolock) 
	where ID = IsNull(@nFrameID, 0)

select @nPackingID = max(PackingID), @dDateValid = max(DateValid) 
	from CellsContents with (nolock) 
	where FrameID = IsNull(@nFrameID, 0)
select @nFrameWeight = PalletWeight 
	from PalletsTypes with (nolock) 
	where ID = @nPalletTypeID

select @bFullPallet = dbo.IsFullPallet(@nFrameID)

select @bHalfStuff = G.HalfStuff, @cTemperatureMode = G.TemperatureMode 
	from CellsContents CC with (nolock) 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	inner join Goods G with (nolock) on G.ID = P.GoodID 
	where CC.FrameID = IsNull(@nFrameID, 0)

select @nFrameWeight = dbo.GetFrameWeight(@nFrameID)

if not exists (select ID 
		from	AccommodationsRules AR with (nolock) 
		where	Actual = 1 and 
				((AR.SourceZoneTypeID = @nFrameZoneTypeID and AR.SourceZoneID is Null) or 
				 (AR.SourceZoneID = @nFrameZoneID and AR.SourceZoneTypeID is Null)) or 
				 (AR.SourceZoneID is Null and AR.SourceZoneTypeID is Null)) begin
	select	@nError = -8, 
			@cErrorText = 'Нет правил для размещения контейнера с кодом ' + ltrim(str(@nFrameID)) + ' (начальная ячейка/зона)...'
	return
end

declare @nDaysValidDiff int
select  @nDaysValidDiff = IsNull(cast(dbo._SettingsGetValue('nDaysValidDiff') as int), 7)
declare @cR_Name varchar(200)

-- переменные для курсора
declare @nR_ID int, @nR_Priority int
declare @nR_SourceZoneTypeID int, @nR_SourceZoneID int
declare @nR_TargetZoneTypeID int, @nR_TargetZoneID int
declare	@bR_OwnerControl bit, @bR_GoodStateControl bit, @bR_PackingControl bit, @bR_TemperatureModeControl bit
declare	@bR_CellPalletTypeControl bit, @bR_CellWeightControl bit, @bR_CellHeightControl bit
declare @bR_RestsControl bit, @bR_FullPalletControl bit, @bR_HalfStuffControl bit, @bR_CellMaxQntControl bit
declare @nErrorTry int
set @nErrorTry = 0

BODY:
declare _AccommodationRules cursor static 
	for select	ID, Priority, 
				SourceZoneTypeID, SourceZoneID, 
				OwnerControl, GoodStateControl, PackingControl, 
				CellPalletTypeControl, CellWeightControl, CellHeightControl, RestsControl, 
				CellMaxQntControl, TemperatureModeControl, FullPalletControl, HalfStuffControl, 
				TargetZoneTypeID, TargetZoneID 
		from	AccommodationsRules AR 
		where	Actual = 1 and 
					((AR.SourceZoneTypeID = @nFrameZoneTypeID and AR.SourceZoneID is Null) or 
					 (AR.SourceZoneID = @nFrameZoneID and AR.SourceZoneTypeID is Null) or 
					 (AR.SourceZoneID is Null and AR.SourceZoneTypeID is Null)) 
		order by Priority
open _AccommodationRules
fetch next from _AccommodationRules 
	into @nR_ID, @nR_Priority, @nR_SourceZoneTypeID, @nR_SourceZoneID, 
	@bR_OwnerControl, @bR_GoodStateControl, @bR_PackingControl, @bR_CellPalletTypeControl, 
	@bR_CellWeightControl, @bR_CellHeightControl, @bR_RestsControl, 
	@bR_CellMaxQntControl, @bR_TemperatureModeControl, @bR_FullPalletControl, @bR_HalfStuffControl, 
	@nR_TargetZoneTypeID, @nR_TargetZoneID

while @@fetch_status = 0 begin
	-- Проверки, не требующие таблицы доступных ячеек
	if @bR_FullPalletControl is not Null begin
		if not ((@bR_FullPalletControl = 1 and @bFullPallet = 1) or 
				(@bR_FullPalletControl = 0 and @bFullPallet = 0))
			goto Next_Rule
	end
	
	if @bR_HalfStuffControl is not Null begin
		if not ((@bR_HalfStuffControl = 1 and @bHalfStuff = 1) or 
				(@bR_HalfStuffControl = 0 and @bHalfStuff = 0)) 
			goto Next_Rule
	end
	
	if @bR_PackingControl = 1 and @bFrameGoodsMono <> 1
		goto Next_Rule
	
	-- Выборка доступных ячеек
	set @cCommand = ''
	if object_id('tempdb.dbo.#Cells') is not Null drop table #Cells
	
	select cast(ID as int) as ID, FixedOwnerID, FixedGoodStateID, FixedPackingID, 
			StoreZoneID, PalletTypeID, CBuilding, CLine, CRack, CLevel, CPlace, BarCode, 
			Address, MaxWeight, CellWidth, CellHeight, MaxPalletQnt, State, GoodsMono, 
			Locked, Actual, cast(0 as numeric(10,3)) as MaxPalQnt, Rank, 
			cast(Null as varchar(1)) as TemperatureMode 
		into #Cells 
		from Cells 
		where 1 = 2
	
	if @nR_TargetZoneID is Null
		set @cCommand = ' insert into #Cells ' + 
			'select C.ID, FixedOwnerID, FixedGoodStateID, FixedPackingID, ' + 
				'StoreZoneID, PalletTypeID, CBuilding, CLine, CRack, CLevel, CPlace, BarCode, ' + 
				'Address, MaxWeight, CellWidth, CellHeight, C.MaxPalletQnt, State, GoodsMono, ' + 
				'Locked, C.Actual, IsNull(IsNull(C.MaxPalletQnt, SZ.MaxPalletQnt), 999), Rank, ' + 
				'SZ.TemperatureMode ' + 
			'from Cells C with (nolock) ' + 
			'inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID and ' + 
				'SZ.StoreZoneTypeID = ' + cast(@nR_TargetZoneTypeID as varchar(10))
	else
		set @cCommand = ' insert into #Cells ' + 
			'select C.ID, FixedOwnerID, FixedGoodStateID, FixedPackingID, ' + 
				'StoreZoneID, PalletTypeID, CBuilding, CLine, CRack, CLevel, CPlace, BarCode, ' + 
				'Address, MaxWeight, CellWidth, CellHeight, C.MaxPalletQnt, State, GoodsMono, ' + 
				'Locked, C.Actual, IsNull(IsNull(C.MaxPalletQnt, SZ.MaxPalletQnt), 999) as MaxPalQnt, Rank, ' + 
				'SZ.TemperatureMode ' + 
			'from Cells C with (nolock) ' + 
			'inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID and ' + 
				'C.StoreZoneID = ' + cast(@nR_TargetZoneID as varchar(10))
	
	set @cWhere = ' where C.Deleted = 0 and C.Locked = 0 and C.Actual = 1 and C.IsFull = 0 '

	if @nComplexID is not Null 
		set @cWhere = @cWhere + ' and SZ.ComplexID = ' + str(@nComplexID)
	
	if @bR_CellMaxQntControl = 1
		set @cWhere = @cWhere + ' and dbo.IsCellFull(C.ID) = 0 '
	if @bR_TemperatureModeControl = 1
		set @cWhere = @cWhere + ' and IsNull(TemperatureMode, -1) = IsNull(''' + @cTemperatureMode + ''', -1) '
	if @bR_OwnerControl = 1 begin
		if @bSeparatePicking = 0
			set @cWhere = @cWhere + ' and FixedOwnerID is Null '
		else	
			set @cWhere = @cWhere + ' and IsNull(FixedOwnerID, -1) = IsNull(' + cast(IsNull(@nOwnerID, -1) as varchar(6)) + ', -1) '
	end
	if @bR_GoodStateControl = 1
		set @cWhere = @cWhere + ' and IsNull(FixedGoodStateID, -1) = IsNull(' + cast(IsNull(@nGoodStateID, -1) as varchar(6)) + ', -1) '
	if @bR_PackingControl = 1
		set @cWhere = @cWhere + ' and IsNull(FixedPackingID, -1) = IsNull(' + cast(IsNull(@nPackingID, -1) as varchar(6)) + ', -1) '
	if @bR_CellWeightControl = 1
		set @cWhere = @cWhere + ' and MaxWeight >= ' + cast(IsNull(@nFrameWeight, -1) as varchar(12))
	if @bR_CellHeightControl = 1
		set @cWhere = @cWhere + ' and CellHeight >= ' + cast(IsNull(@nFrameHeight, -1) as varchar(12))
	if @bR_CellPalletTypeControl = 1
		set @cWhere = @cWhere + ' and PalletTypeID = ' + cast(IsNull(@nPalletTypeID, -1) as varchar(6))
	
	/*if @bR_RestsControl = 1 begin -- проверка на отсутствие данного товара в данном состоянии
		if (exists (select CC.ID from CellsContents CC 
					inner join #Cells C on C.ID = CC.CellID 
					where CC.PackingID = @nPackingID and CC.GoodStateID = @nGoodStateID 
					)) begin
			if @bIsDebug = 1
				print 'Отказ: Не пройден контроль остатков в ячейке'
				goto Next_Rule
		end
	end*/
	
	exec (@cCommand + @cWhere)
	
	if not exists (select top 1 ID from #Cells)
		goto Next_Rule
	
	declare @cStoreZoneTypeCode varchar(10)
	if @nR_TargetZoneTypeID is not Null
		select @cStoreZoneTypeCode = ShortCode 
			from StoresZonesTypes with (nolock) 
			where ID = @nR_TargetZoneTypeID
	else
		select @cStoreZoneTypeCode = SZT.ShortCode 
			from StoresZonesTypes SZT with (nolock) 
			inner join StoresZones SZ with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
			where SZ.ID = @nR_TargetZoneID
	
	--	собственно выбор из оставшихся ячееек
	-- 'MaxWeight, CellHeight, Rank, Address' обычная сортировка ячеек при размещении
	if @cStoreZoneTypeCode = 'Rill' begin		-- Отдельно для ручья, отдельно для всего остального
		-- не рассматриваем ячейки содержащие другой товар
		delete #Cells from CellsContents 
			where	#Cells.ID = CellsContents.CellID and 
					CellsContents.PackingID <> @nPackingID
		while 1 = 1 begin
			-- ищем неполный ручей с аналогичным товаром
			-- цикл нужен, т.к. может быть несколько ручьев с этим товаром, но с разными сроками годности
			select top 1 @nAccCell = C.ID 
				from #Cells C 
				inner join CellsContents CC with (nolock) on CC.CellID = C.ID and CC.PackingID = @nPackingID 
				order by MaxWeight, CellHeight, Rank, Address
			if @nAccCell is not Null begin
				-- если нашли, проверяем срок годности в ячейке
				-- (разрешаем поставить контейнер со сроком годности большим или не меньшим, чем есть, на N дней)
				if exists (select ID from CellsContents 
							where CellID = @nAccCell and 
								datediff(day, @dDateValid, DateValid - @nDaysValidDiff) > 0
							) begin
					delete #Cells where ID = @nAccCell
					set @nAccCell = Null
					-- ищем другую в цикле
				end
				else break
				-- подобрали
			end
			else break
			-- не нашли, вышли из цикла, продолжаем искать по другим правилам
		end
		
		if @nAccCell is Null begin
			-- если не нашли ищем пустую, в которую есть трафик с аналогичным товаром,
			-- срок годности которого в допустимых пределах, НО НУЖНО ПРИ ПОДТВЕРЖДЕНИИ ПЕРЕМЕЩЕНИЯ ПРОВЕРИТЬ!!!
			-- и количество перемещаемых паллет не превышает вместимость ячейки
			select CellTargetID, count(*) as Cnt, max(C.MaxPalQnt) as MaxPal 
				into #My_TrafficsFrames 
				from TrafficsFrames T with (nolock) 
				inner join #Cells C on C.ID = T.CellTargetID 
				left join CellsContents CC with (nolock) on CC.FrameID = T.FrameID 
				where T.DateConfirm is Null and CC.PackingID = @nPackingID 
				group by CellTargetID 
				having datediff(day, min(CC.DateValid) - @nDaysValidDiff, @dDateValid) >= 0
			select top 1 @nAccCell = ID 
				from #Cells C 
				where dbo.GetFramesQntInCell(ID) = 0 and 
					C.ID in (select CellTargetID from #My_TrafficsFrames where Cnt < MaxPal) 
				order by MaxWeight, CellHeight, Rank, Address
			
			if @nAccCell is Null begin
				-- и опять не нашли, ищем пустую, в которую нет трафика с другим товаром
				-- и нет трафика с таким же товаром но с другим сроком годности
				select distinct(CellTargetID) 
					into #Foreign_TrafficsFrames 
					from TrafficsFrames T with (nolock) 
					inner join #Cells C with (nolock) on C.ID = T.CellTargetID 
					left join CellsContents CC on CC.FrameID = T.FrameID 
					where T.DateConfirm is Null and CC.PackingID <> @nPackingID
				insert #Foreign_TrafficsFrames (CellTargetID) 
					select CellTargetID 
						from TrafficsFrames T with (nolock) 
						inner join #Cells C on C.ID = T.CellTargetID 
						left join CellsContents CC with (nolock) on CC.FrameID = T.FrameID 
						where T.DateConfirm is Null and CC.PackingID = @nPackingID 
						group by CellTargetID 
						having datediff(day, @dDateValid, max(CC.DateValid) - @nDaysValidDiff) > 0
				
				select CellTargetID 
					from TrafficsFrames T with (nolock) 
					inner join #Cells C on C.ID = T.CellTargetID 
					left join CellsContents CC with (nolock) on CC.FrameID = T.FrameID 
					where T.DateConfirm is Null and CC.PackingID = @nPackingID 
					group by CellTargetID 
					having datediff(day, @dDateValid, max(CC.DateValid) - @nDaysValidDiff) > 0
				
				select top 1 @nAccCell = ID 
					from #Cells C 
					where dbo.GetFramesQntInCell(ID) = 0 and 
						C.ID not in (select CellTargetID from #Foreign_TrafficsFrames) 
					order by MaxWeight, CellHeight, Rank, Address
			end
		end
	end
	else begin
		-- Все остальные ячейки хранения кроме ручьев
		if exists (select C.ID 
					from Cells C with (nolock) 
					inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
					inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
					where SZT.ForPicking = 1 and 
						(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1) ) 
			) begin
			-- если есть пикинг - ищем ближайшую к соотв. ячейке пикинга
			
			declare @cMask varchar(50), @nIndex int
			select @cPickingCell = '', @nPickingCellID = Null
			-- поиск ячейки пикинга для данного товара
			select @nPickingCellID = C.ID, @cPickingCell = C.Address, @cMask = SZT.AddressMask 
				from Cells C with (nolock) 
				inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
				inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
				where	FixedPackingID = @nPackingID and 
						FixedGoodStateID = @nGoodStateID and 
						IsNull(FixedOwnerID, -1) = IsNull(@nOwnerID, -1) and 
						SZT.ForPicking = 1 and 
						C.Deleted = 0 and 
						(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)) 
			if @@RowCount > 0 begin
				set @cBuilding	= substring(@cPickingCell, charindex('B', @cMask), dbo._Occurs('B', @cMask))
				set @cLine		= substring(@cPickingCell, charindex('L', @cMask), dbo._Occurs('L', @cMask))
				set @cRack		= substring(@cPickingCell, charindex('R', @cMask), dbo._Occurs('R', @cMask))
			end
			else begin
				-- если не нашли ячейки пикинга для товара, она может быть Packings.Note, причем без маски
				-- устаревшая цепочка, можно заремить
				select @cPickingCell = IsNull(Note, '???') 
					from Packings with (nolock) 
					where ID = @nPackingID
				if (len(@cPickingCell) > 0 and Charindex(',', @cPickingCell) > 0) begin
					set @cPickingCell = ltrim(substring(@cPickingCell, Charindex(',', @cPickingCell) + 1, len(@cPickingCell)))
					set @cBuilding	= left(@cPickingCell, 1)
					set @cLine		= substring(@cPickingCell, 2, 1)
					set @cRack		= substring(@cPickingCell, 3, 2)
					select @nPickingCellID = ID 
						from Cells 
						where Address = @cPickingCell
				end
			end
			if @nPickingCellID is not Null begin
				-- нашли ячейку пикинга для товара
				-- ищем ячейку в том же здании
				-- идеальное попадание - в ту же линию и в тот же стояк
				--
				-- Изменение от 06.03.2009
				-- В связи с переносом в ИНКО ячеек пикинга с 1-го и 2-го склада на 4-ый
				-- Юрлов попросил как можно реже использовать высотку 4-го склада,
				-- т.к. идет постоянное пересечение маршрутов техники.
				-- Из-за этого пришлось заблокировать условие по поиску ячейки в том же здании,
				-- и перейти на систему рангов ячеек.
				-- На момент изменения ранг ячеек на складе 3 равен № стояка,
				-- а на складе 4 - № стояка + 10
				select top 1 @nAccCell = C.ID 
					from #Cells C 
					inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
					inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
					where 
						/*IsNull(C.CBuilding, '') = @cBuilding and */
						SZT.ForStorage = 1 and SZT.ForPicking = 0 and 
						(MaxPalQnt - (dbo.GetFramesQntInCell(C.ID) + dbo.GetFramesQntToCell(C.ID))) >= 1 
					order by 
							/*case when CLine = @cLine then 0 else 1 end, 
							case when CRack = @cRack then 0 else 1 end, */
							C.MaxWeight, C.CellHeight, C.Rank, C.Address
				if @nAccCell is Null begin
						-- Не нашли, ищем в других зданиях.
						-- Список доступных зданий формируем следующим образом:
						-- количество ячеек в этих зданиях, 
						-- отвечающих условию SZT.ForStorage = 1 and SZT.ShortCode = 'STOR',
						-- должно быть бОльшим или равным 80% от общего числа ячеек.
						
						-- На 12.04.2008 в ИНКО распределение ячеек по складам следующее:
						-- Склад		Пикинг		Хранение
						-- склад 1		 33%			 67%
						-- склад 2		 33%			 67%
						-- склад 3		  0%			100%
						-- склад 4		  6%			 94%
						-- склад 5		100%			  0%
						
						-- Всю картину портит склад 4, имеющий небольшое количество ячеек пикинга.
						
						-- Смысл в том, чтобы хитрым образом решить следующую проблему в ИНКО:
						-- подпиточные паллеты для товаров, набираемых на складе 1, 
						--		можно хранить только в зонах 1,3,4
						-- подпиточные паллеты для товаров, набираемых на складе 2, 
						--		можно хранить только в зонах 2,3,4
						-- подпиточные паллеты для товаров, набираемых на складе 4, 
						--		можно хранить только в зонах 4,3
						-- подпиточные паллеты для товаров, набираемых на складе 5, 
						--		можно хранить только в зонах 3,4
						-- Отсечкой в 80% мы добиваемся того, 
						-- что склады 3 и 4 доступны для размещения паллет ВСЕГДА.
						
						-- На складах других компаний данная проблема пока отсутствует,
						-- все склады состоят из одного здания.
						-- Возможно, в будущем данная проверка будет ликвидирована.
						
						-- Делаем выборку по всем зданиям
						if object_id('Tempdb..#StorByBuildings') is not Null drop table #StorByBuildings
						select	C.CBuilding, 
								count(*) as FullCount, 
								sum(case when SZT.ShortCode = 'STOR' 
									then cast(1 as dec) 
									else cast(0 as dec) 
									end) as StorCount 
							into #StorByBuildings 
							from Cells C with (nolock) 
							inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
							inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
							where SZT.ForStorage = 1 and 
								(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)) 
							group by C.CBuilding 
							having count(*) > 0
						/*select ID, MaxPalQnt, StoreZoneID, MaxWeight, CellHeight, Rank, Address 
							into #AB_Cells 
							from #Cells 
							where CBuilding not in (select distinct CBuilding 
												from Cells C with (nolock) 
												inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
												inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
												where SZT.ForPicking = 1)*/
						-- Выбираем склады по правилу 80%
						if object_id('Tempdb..#AB_Cells') is not Null drop table #AB_Cells
						select ID, MaxPalQnt, StoreZoneID, MaxWeight, CellHeight, Rank, Address 
							into #AB_Cells 
							from #Cells 
							where CBuilding in (select distinct CBuilding 
												from #StorByBuildings C 
												where (StorCount / FullCount >= 0.8))
						-- #AB_Cells (Another buildings) - новая таблица, не = #Cells)
						select top 1 @nAccCell = C.ID 
							from #AB_Cells C 
							inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
							inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
							where (MaxPalQnt - (dbo.GetFramesQntInCell(C.ID) + dbo.GetFramesQntToCell(C.ID))) >= 1 and 
								SZT.ForStorage = 1 
							order by C.MaxWeight, C.CellHeight, C.Rank, C.Address
						
						drop table #AB_Cells
						drop table #StorByBuildings
				end
			end
			else begin
				-- не нащли ячейки пикинга для товара, берем подходящую по текущему правилу
				select top 1 @nAccCell = ID 
					from #Cells 
					where (MaxPalQnt - (dbo.GetFramesQntInCell(ID) + dbo.GetFramesQntToCell(ID))) >= 1 
					order by MaxWeight, CellHeight, Rank, Address
			end
		end
		else begin
			-- нет пикинга вовсе, берем подходящую по текущему правилу
			select top 1 @nAccCell = ID 
				from #Cells 
				where (MaxPalQnt - (dbo.GetFramesQntInCell(ID) + dbo.GetFramesQntToCell(ID))) >= 1 
				order by MaxWeight, CellHeight, Rank, Address
		end
--		else begin
--				какие - то другие варианты размещения
--		end
	end
	
	if object_id('tempdb.dbo.#My_TrafficsFrames') is not Null drop table #My_TrafficsFrames
 	if object_id('tempdb.dbo.#Foreign_TrafficsFrames') is not Null drop table #Foreign_TrafficsFrames
	
	if @nAccCell is not Null
		break
	
	Next_Rule:
	fetch next from _AccommodationRules into @nR_ID, @nR_Priority, @nR_SourceZoneTypeID, @nR_SourceZoneID, 
		@bR_OwnerControl, @bR_GoodStateControl, @bR_PackingControl, @bR_CellPalletTypeControl, 
		@bR_CellWeightControl, @bR_CellHeightControl, @bR_RestsControl, 
		@bR_CellMaxQntControl, @bR_TemperatureModeControl, @bR_FullPalletControl, @bR_HalfStuffControl, 
		@nR_TargetZoneTypeID, @nR_TargetZoneID
end

if @nAccCell is Null begin
	if object_id('tempdb.dbo.#Cells') is not Null begin
		-- иначе, если совсем ничего не нашли, первую попавшуюся
		-- предполагаем, что по самому последнему правилу(наиболее "мягкому")
		-- остались ячейки в #Cells
		select top 1 @nAccCell = ID 
			from #Cells 
			where (MaxPalQnt - (dbo.GetFramesQntInCell(ID) + dbo.GetFramesQntToCell(ID))) >= 1 
			order by MaxWeight, CellHeight, Rank, Address
	end
end

close _AccommodationRules
deallocate _AccommodationRules

if @nAccCell is not Null and @bCreateTraffic = 1 begin
	declare @cnR_ID varchar(100)
	declare @nPriority tinyint
	declare @nMaxPalQnt	numeric(9,2)
	set @nPriority = 8
	
	-- создание операций транспортировки в найденную ячейку
	select @nError = 0, @cErrorText = '', @cnR_ID = 'Автоподбор места по правилу № ' + cast(@nR_ID as varchar(10))
	select @nMaxPalQnt = MaxPalQnt from #Cells where ID = @nAccCell
	
	-- Дополнительная проверка на то, что ячейка не была подобрана другим пользователем.
	-- Это может происходить на медленном сервевре при одновременной работе нескольких человек.
	-- Данная ситуация имела место на МБК
	if @nMaxPalQnt = 1 and 
		exists(select ID from TrafficsFrames where CellTargetID = @nAccCell and DateConfirm is Null) begin
		set @nAccCell = Null
		if @nErrorTry > 3 
			return
		else begin
			set @nErrorTry = @nErrorTry + 1
 			goto BODY
		end
	end
	
	-- непосредственно создание транспортировки
 	exec up_TrafficsFramesOneCreate 
		@nFrameID, @nFrameCell, @nAccCell, @nPriority, 
		@nInputID, Null, Null, 0, @cnR_ID, @nError output
end
return