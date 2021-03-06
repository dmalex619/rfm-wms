set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsSelectCell]
	@nOutputID	int, 
	@bUnSuсcess	bit = 0 output, 
	@nError		int = 0 output, 
	@cErrorText	varchar(50) = '' output
AS
-- Автоматический подбор ячейки отгрузки для задания

set nocount on

declare @nOutCellID int, @nComplexID int

-- Проверка того, что ячейка уже выбрана
select @nOutCellID = CellID, @nComplexID = ComplexID 
	from Outputs 
	where ID = @nOutputID
if @nOutCellID is not Null return

-- Коэффициент запаса по паллетности
declare @nReserve dec(5,1)
set @nReserve = 1.1

declare @cCarAlias varchar(50), @dDateOutput smalldatetime, @nPalletsQnt int, @nCount int

-- Получение данных о всех доступных ячейках отгрузки
select  C.ID, C.Address, 
		IsNull(C.MaxPalletQnt, SZ.MaxPalletQnt) as MaxPalletQnt, 
		cast (0 as int) as PalletsQnt 
	into #Cells 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ForOutputs = 1 and C.Actual = 1 and C.Locked = 0 and C.Deleted = 0 and 
		(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1))
select @nCount = @@RowCount
if @nCount = 0 begin
	-- Ячеек нет в принципе - на фиг с пляжа
	select	@nError = -1, 
			@cErrorText = 'Нет ни одной ячейки отгрузки!'
	return
end
if @nCount = 1 begin
	-- Ячейка одна в принципе - нет вариантов
	update Outputs set CellID = #Cells.ID 
		from #Cells 
		where Outputs.ID = @nOutputID
	return
end

-- Удаляем безразмерные ячейки - их можно выбрать только вручную
delete #Cells 
	where MaxPalletQnt is Null or MaxPalletQnt = 0
if not exists (select top 1 ID from #Cells) begin
	select	@nError = -2, 
			@cErrorText = 'Нет ни одной доступной ячейки отгрузки!'
	return
end

select top 1 @nOutCellID = ID 
	from Cells 
	order by ID		-- первая попавшаяся ячейка
update Outputs set CellID = @nOutCellID 
	where ID = @nOutputID	-- 'заперли' текущий Output, чтобы его не захватил процесс с другого компа.

-- Получение даты и названия машины для задания на отгрузку
select @dDateOutput = DateOutput, @cCarAlias = CarAlias 
	from Outputs 
	where ID = @nOutputID

-- Получаем рассчетное завышенное количество паллет в заказе
select @nPalletsQnt = ceiling(sum((OG.QntWished / P.InBox / P.BoxInPal) * @nReserve)) 
	from OutputsGoods OG with (nolock) 
	inner join Packings P on OG.PackingID = P.ID 
	where OG.OutputID = @nOutputID

-- Остальные расходы на ту же дату - чтобы посчитать заполнение ячеек отгрузки
select ID, CellID, IsNull(CarAlias, '') as CarAlias 
	into #Outputs 
	from Outputs with (nolock) 
	where	datediff(day, DateOutput, @dDateOutput) = 0 and 
			CellID is not Null and 
			ID <> @nOutputID

-- Получаем расчетную "занятость" ячеек
update #Cells set PalletsQnt = IsNull(X.PalletsQnt, 0) 
	from (select O.CellID, sum(ceiling(OG.QntWished / P.InBox / P.BoxInPal * @nReserve)) as PalletsQnt 
			from OutputsGoods OG 
			inner join #Outputs O on O.ID = OG.OutputID 
			inner join Packings P on OG.PackingID = P.ID 
			group by O.CellID) X 
	where X.CellID = #Cells.ID

-- Удаляем ячейки, в которые не поместится наше задание
delete #Cells 
	where MaxPalletQnt < (PalletsQnt + @nPalletsQnt)

-- Обнуляем код искомой ячейки
select @nOutCellID = Null

-- Получаем все ячейки отгрузки, к которым приписаны задания из той же машины
-- Делаем это только в случае, если название машины задано,
-- чтобы не сваливать весь самовывоз в одну кучу
if len(@cCarAlias) > 0 begin
	select distinct CellID 
		into #CarsByCells 
		from #Outputs O with (nolock) 
		where CarAlias = @cCarAlias 
	if @@RowCount > 0 begin
		select top 1 @nOutCellID = C.ID 
			from #Cells C 
			inner join #CarsByCells CB on C.ID = CB.CellID 
			order by MaxPalletQnt - PalletsQnt, PalletsQnt / MaxPalletQnt
		if @nOutCellID is not Null begin
			-- нашли ячейку, куда собираются заказы из той же машины
			--print @nOutCellID
			update Outputs set CellID = @nOutCellID 
				where ID = @nOutputID
			return
		end
	end
end

-- Не нашли ячейку для той же машины - ищем во всех остальных
select top 1 @nOutCellID = ID 
	from #Cells C 
	order by MaxPalletQnt - PalletsQnt, PalletsQnt / MaxPalletQnt

-- Если нашли подходящую ячейку записали ее, иначе записали Null 
update Outputs set CellID = @nOutCellID 
	where ID = @nOutputID

-- Если не нашли - вернем признак, что не нашли
if @nOutCellID is Null
	set @bUnSuсcess = 1
else
	set @bUnSuсcess = 0
return