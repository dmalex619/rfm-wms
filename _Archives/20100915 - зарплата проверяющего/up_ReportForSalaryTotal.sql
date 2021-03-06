SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_ReportForSalaryTotal]
	@dDateBeg			smalldatetime	= Null, 
	@dDateEnd 			smalldatetime	= Null, 
	@cDetailMode		varchar(20)		= Null, -- DETAIL, DATE, TOTAL
	@bGroupBy			bit, 
	@cUsersList			varchar(max)	= Null, 
	@cInputsTypesList	varchar(max)	= Null,
	@cOutputsTypesList	varchar(max)	= Null, 
	@cOwnersList		varchar(max)	= Null, 
	@bMoney				bit = null
AS
/*
exec up_ReportForSalaryTotal '20080801', '20080810', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'DATE', 0, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'TOTAL', 0, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'DETAIL', 1, null, null, null, null
exec up_ReportForSalaryTotal '20100601', '20100610', 'DATE', 1, null, null, null, null, 1
exec up_ReportForSalaryTotal '20090301', '20090315', 'TOTAL', 0, '9', null, null, null
*/

set nocount on

set dateformat ymd

if @bMoney is Null set @bMoney = 0

declare @cDateConvertPart varchar(10), @nDateConvertFormat int
select @cDateConvertPart = 'day', @nDateConvertFormat = 112
if datepart(mi, @dDateBeg) > 0 or datepart(mi, @dDateEnd) > 0 or 
	datepart(hh, @dDateBeg) > 0 or datepart(hh, @dDateEnd) > 0
	select @cDateConvertPart = 'mi', @nDateConvertFormat = 120

select U.BrigadeID, T.UserID, T.DateConfirm, 
		cast(0 as int) as InputID, 
		cast(0 as dec(5, 1)) as InputsItemsCount, 
		cast(0 as dec(15, 1)) as InputsBoxesCount, 
		cast(0 as dec(15, 0)) as InputsNetto, 
		cast(0 as dec(5, 1)) as InputsItemsRelativeCount, 
		cast(0 as int) as AccInputID, 
		cast(0 as int) as AccInputsOperationsCount, 
		cast(0 as int) as MovesOperationsCount, 
 		cast(0 as int) as MovesUp, 
		cast(0 as int) as MovesDown, 
		cast(0 as int) as MovesFloorCount, 
		cast(0 as int) as PickOutputID, 
		cast(0 as dec(8, 1)) as PickOutputsLinesCount, 
		cast(0 as dec(15, 1)) as PickOutputsBoxesCount, 
		cast(0 as dec(15, 0)) as PickOutputsNetto, 
		cast(0 as int) as OutputID, 
		cast(0 as dec(8, 1)) as OutputsLinesCount, 
		cast(0 as dec(15, 1)) as OutputsBoxesCount, 
		cast(0 as dec(15, 0)) as OutputsNetto, 
		cast(0 as int) as ValidateOutputID, 
		cast(0 as int) as ValidateOutputsCount, 
		cast(0 as dec(8, 1)) as ValidateOutputsLinesCount, 
		cast(0 as dec(15, 1)) as ValidateOutputsBoxesCount, 
		cast(0 as dec(15, 0)) as ValidateOutputsNetto, 
		cast(0 as dec(15, 1)) as MovingsBoxesCount, 
		cast(0 as int) as InventoriesCellsCount, 
		cast(0 as int) as SalaryExtraWorkID, 
		cast(0 as money) as SalaryExtraWorksAmount 
	into #Data 
	from TrafficsGoods T with (nolock)
	inner join _Users U with (nolock) on T.UserID = U.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	where 1 = 2 
create index IX_UserID on #Data (UserID)
create index IX_BrigadeID on #Data (BrigadeID)
create index IX_DateConfirm on #Data (DateConfirm)

declare @cSelect varchar(max), @cSelectX varchar(max), @cWhere varchar(max)

-- 'INPUTSUNLOAD'
-- Разгрузка машины
select U.BrigadeID, 
		II.UserID, 
		II.InputID, 
		I.DateConfirm, 
		cast(0 as dec(15,1)) as BoxesCount, 
		cast(0 as dec(15,0)) as Netto, 
		cast(0 as dec(5,1)) as InputsItemsCount, 
		cast(0 as dec(5,1)) as CoefficientUnload 
	into #InputsUnloadData 
	from InputsItems II with (nolock)
	inner join Inputs I with (nolock) on II.InputID = I.ID
	inner join _Users U with (nolock) on II.UserID = U.ID
	where 1 = 2 

-- приходы для расчета
select ID * 1 as ID 
	into #InputsUnloadTemp
	from Inputs with (nolock) 
	where 1 = 2

set	@cWhere = ' where 1 = 1 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', I.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', I.DateConfirm, ''' + convert(varchar, @dDateEnd , @nDateConvertFormat) + ''') >= 0 '
if @cInputsTypesList is not Null
	set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '

set @cSelect = 
'insert #InputsUnloadTemp (ID) 
	select I.ID 
		from Inputs I with (nolock) 
		inner join Partners Own with (nolock) on I.OwnerID = Own.ID '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)
-- 

set @cSelect = 
'insert #InputsUnloadData (BrigadeID, UserID, InputID, DateConfirm, 
		BoxesCount, Netto, InputsItemsCount, CoefficientUnload) 
	select U.BrigadeID, IU.UserID, X.InputID, 
			convert(datetime, convert(varchar, I.DateConfirm, 112)), 
			X.BoxesCount, X.Netto, X.InputsItemsCount, I.CoefficientUnload 
		from (select II.InputID, 
					sum(ceiling(II.Qnt / P.InBox)) as BoxesCount, 
					sum(II.Qnt * G.Netto) as Netto, 
					count(*) as InputsItemsCount 
				from InputsItems II with (nolock) 
				inner join #InputsUnloadTemp _XYZ on II.InputID = _XYZ.ID
				inner join Packings P with (nolock) on II.PackingID = P.ID 
				inner join Goods G with (nolock) on P.GoodID = G.ID 
				group by InputID) X 
		inner join Inputs I with (nolock) on X.InputID = I.ID 
		left join InputsUnloaders IU with (nolock) on X.InputID = IU.InputID
		left join _Users U with (nolock) on IU.UserID = U.ID '
exec (@cSelect)

-- Раскидываем приходы по количеству людей
select T.BrigadeID, T.UserID, T.InputID, T.DateConfirm, 
		sum(T.BoxesCount / X.InputsCount) as BoxesCount, 
		sum(T.Netto / X.InputsCount) as Netto, 
		sum(T.InputsItemsCount / X.InputsCount) as InputsItemsCount, 
		sum(T.InputsItemsCount * T.CoefficientUnload / X.InputsCount) as InputsItemsRelativeCount 
	into #InputsUnloadDataSum 
	from #InputsUnloadData T 
	inner join (select InputID, count(*) as InputsCount 
					from #InputsUnloadData 
					group by InputID) X on X.InputID = T.InputID 
	group by T.BrigadeID, T.UserID, T.InputID, T.DateConfirm

-- И вот только теперь применяем фильтр по сотрудникам!
if @cUsersList is not Null begin
	set @cSelect = 'delete #InputsUnloadDataSum ' + 
					'where UserID is Null or UserID not in ('+ dbo._NormalizeList(@cUsersList) + ')'
	exec (@cSelect)
end

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			InputID, InputsItemsCount, BoxesCount, Netto, InputsItemsRelativeCount, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			0, 0, Null, 0
		from #InputsUnloadDataSum 

--------------------------------------------------------------------------------
-- 'INPUTSACCEPT'
-- Непосредственно приемка
select U.BrigadeID, 
		II.UserID, 
		II.InputID, 
		I.DateConfirm, 
		II.ID * 1 as InputItemID 
	into #InputsAcceptData
	from InputsItems II with (nolock)
	inner join Inputs I with (nolock) on II.InputID = I.ID
	inner join _Users U with (nolock) on II.UserID = U.ID
	where 1 = 2 

set @cSelect = 
'insert #InputsAcceptData (BrigadeID, UserID, InputID, DateConfirm, InputItemID) 
	select U.BrigadeID, II.UserID, II.InputID, 
			convert(datetime, convert(varchar, I.DateConfirm, 112)), 
			II.ID 
		from InputsItems II with (nolock)
		inner join Inputs I with (nolock) on II.InputID = I.ID 
		inner join Partners Own with (nolock) on I.OwnerID = Own.ID 
		inner join _Users U with (nolock) on II.UserID = U.ID '
set @cWhere = ' where 1 = 1 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', I.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', I.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
/*if @cUsersList is not Null
	set @cWhere = @cWhere + ' and II.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '*/
if @cInputsTypesList is not Null
	set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select UserID, BrigadeID, InputID, DateConfirm, 
		count(InputItemID) as OperationsCount 
	into #InputsAcceptDataSum 
	from #InputsAcceptData 
	group by BrigadeID, UserID, InputID, DateConfirm

-- И вот только теперь применяем фильтр по сотрудникам!
if @cUsersList is not Null begin
	set @cSelect = 'delete #InputsAcceptDataSum ' + 
					'where UserID is Null or UserID not in ('+ dbo._NormalizeList(@cUsersList) + ')'
	exec (@cSelect)
end

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			InputID, OperationsCount, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			0, 0, Null, 0
		from #InputsAcceptDataSum

--------------------------------------------------------------------------------
-- 'TRAFFICSFRAMESHI', 'TRAFFICSFRAMESLO'
-- Перемещения контейнеров
select U.BrigadeID, 
		T.UserID, 
		T.ID * 1 as TrafficID, 
		T.DateConfirm, 
		cast(0 as int) as MovesUp 
	into #TrafficsFramesData 
	from TrafficsFrames T with (nolock) 
	inner join _Users U with (nolock) on T.UserID = U.ID 
	where 1 = 2

-- Получение ячеек высотной зоны
select C.ID as CellID 
	into #CellsHi 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ShortCode in ('STOR', 'RILL')
alter table #CellsHi add constraint PK_CellsHi primary key clustered(CellID)

set @cSelect = 
'insert #TrafficsFramesData (BrigadeID, UserID, TrafficID, DateConfirm, MovesUp) 
	select U.BrigadeID, T.UserID, T.ID, 
		convert(datetime, convert(varchar, T.DateConfirm, 112)), 
		case when T.CellTargetID in (select CellID from #CellsHi) then 1 else 0 end as MovesUp 
		from TrafficsFrames T with (nolock)
		left join _Users U with (nolock) on T.UserID = U.ID '
set @cWhere = ' where T.DateConfirm is not Null and T.Success = 1 and T.ErrorID is Null ' + 
	' and (T.CellSourceID in (select CellID from #CellsHi) or ' + 
		'  T.CellTargetID in (select CellID from #CellsHi) )'
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', T.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', T.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID is not Null and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
set @cSelect = @cSelect + @cWhere 
exec (@cSelect)

-- Количество спусков вычисляем обратным счетом,
-- чтобы не платить дважды за операции перемещения внутри высотки
select UserID, BrigadeID, DateConfirm, 
		count(TrafficID) as OperationsCount, 
		sum(MovesUp) as MovesUp, 
		cast(0 as int) as MovesDown 
	into #TrafficsFramesDataSum 
	from #TrafficsFramesData 
	group by UserID, BrigadeID, DateConfirm
update #TrafficsFramesDataSum set MovesDown = OperationsCount - MovesUp

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			OperationsCount, MovesUp, MovesDown, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			Null, 0, 0, 0 
		from #TrafficsFramesDataSum 

-- перемещения без подъемов/спусков
set @cSelect = 
'delete #TrafficsFramesData 
 insert #TrafficsFramesData (BrigadeID, UserID, TrafficID, DateConfirm, MovesUp) 
	select U.BrigadeID, T.UserID, T.ID, 
		convert(datetime, convert(varchar, T.DateConfirm, 112)), 
		0 as MovesUp 
		from TrafficsFrames T with (nolock)
		left join _Users U with (nolock) on T.UserID = U.ID '
set @cWhere = ' where T.DateConfirm is not Null and T.Success = 1 and T.ErrorID is Null ' + 
	' and (T.CellSourceID not in (select CellID from #CellsHi) and ' + 
		'  T.CellTargetID not in (select CellID from #CellsHi) )'
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', T.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', T.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID is not Null and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
set @cSelect = @cSelect + @cWhere 
exec (@cSelect)

select UserID, BrigadeID, DateConfirm, 
		count(TrafficID) as OperationsCount 
	into #TrafficsFramesFloorDataSum 
	from #TrafficsFramesData 
	group by UserID, BrigadeID, DateConfirm

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, OperationsCount, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0,
			Null, 0, 0, 0, 0,  
			0, 0, Null, 0
		from #TrafficsFramesFloorDataSum 

--------------------------------------------------------------------------------
-- 'OUTPUTSPICKING'
-- Коробочный пикинг
select U.BrigadeID, 
		T.UserID, 
		T.OutputID, 
		T.DateConfirm, 
		T.PackingID, P.InBox, P.BoxInPal, G.Weighting, G.Netto, 
		T.QntConfirmed as Qnt, 
		T.ID * 1 as TrafficID 
	into #OutputsTrafficsGoodsData
	from TrafficsGoods T with (nolock)
	inner join _Users U with (nolock) on T.UserID = U.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	where 1 = 2 

set @cSelect = 
'insert #OutputsTrafficsGoodsData (BrigadeID, UserID, OutputID, DateConfirm, 
		PackingID, InBox, BoxInPal, Weighting, Netto, Qnt, TrafficID) 
	select U.BrigadeID, T.UserID, T.OutputID, 
			convert(datetime, convert(varchar, T.DateConfirm, 112)), 
			T.PackingID, P.InBox, P.BoxInPal, G.Weighting, G.Netto, 
			T.QntConfirmed, T.ID 
	from TrafficsGoods T with (nolock) 
	inner join Outputs O with (nolock) on T.OutputID = O.ID 
	inner join Partners Own with (nolock) on O.OwnerID = Own.ID 
	left join _Users U with (nolock) on T.UserID = U.ID 
	inner join Packings P with (nolock) on T.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID '
set @cWhere = ' where T.DateConfirm is not Null and T.QntConfirmed > 0 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', O.DatePick) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', O.DatePick, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID is not Null and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
if @cOutputsTypesList is not Null
	set @cWhere = @cWhere + ' and O.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select OutputID, DateConfirm, 
		BrigadeID, UserID, 
		count(distinct OutputID) as OutputsCount, 
		sum(case when Weighting = 1 then cast(0.0 as dec(15,3)) else ceiling(Qnt / InBox) end) as BoxesCount, 
		sum(case when Weighting = 0 then cast(0.0 as dec(15,3)) else Qnt * Netto end) as Netto, 
		count(TrafficID) as LinesCount 
	into #OutputsTrafficsGoodsDataSum 
	from #OutputsTrafficsGoodsData 
	group by OutputID, DateConfirm, BrigadeID, UserID

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			OutputID, LinesCount, BoxesCount, Netto, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			0, 0, Null, 0
		from #OutputsTrafficsGoodsDataSum 

--------------------------------------------------------------------------------
-- 'OUTPUTSLOAD'
-- загрузка в машины
select U.BrigadeID, 
		OI.UserID, 
		OI.OutputID, 
		O.DateConfirm, 
		cast(0 as dec(8,1)) as LinesCount, 
		cast(0 as dec(15,1)) as BoxesCount, 
		cast(0 as dec(15,0)) as Netto 
	into #OutputsLoadData 
	from OutputsItems OI with (nolock) 
	inner join Packings P with (nolock) on OI.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join Outputs O with (nolock) on OI.OutputID = O.ID 
	inner join _Users U with (nolock) on OI.UserID = U.ID 
	where 1 = 2 

-- расходы для анализа
select O.ID * 1 as ID
	into #OutputsLoadTemp
	from Outputs O with (nolock) 
	where 1 = 2

set @cWhere = ' where X.DateConfirm is not Null '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', X.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', X.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cOutputsTypesList is not Null
	set @cWhere = @cWhere + ' and X.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '

set @cSelect = 
'insert #OutputsLoadTemp (ID)
	select X.ID 
		from Outputs X with (nolock) 
		inner join Partners Own with (nolock) on X.OwnerID = Own.ID '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)
--

set @cSelect = 
'insert #OutputsLoadData (BrigadeID, UserID, OutputID, DateConfirm, LinesCount, BoxesCount, Netto) 
	select U.BrigadeID, OL.UserID, X.OutputID, 
			convert(datetime, convert(varchar, X.DateConfirm, 112)), 
			cast(X.LinesCount as dec(8,1)) as LinesCount, X.BoxesCount, X.Netto 
		from (select O.OutputTypeID, O.DateConfirm, OG.OutputID, 
						count(distinct PackingID) as LinesCount, 
						sum(case when G.Weighting = 1 then cast(0.0 as dec(15,3)) else ceiling(OG.QntConfirmed / P.InBox) end) as BoxesCount, 
						sum(case when G.Weighting = 0 then cast(0.0 as dec(15,3)) else OG.QntConfirmed * G.Netto end) as Netto 
					from #OutputsLoadTemp _XYZ
					inner join Outputs O with (nolock) on _XYZ.ID = O.ID 
					inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
					inner join Packings P with (nolock) on OG.PackingID = P.ID 
					inner join Goods G with (nolock) on P.GoodID = G.ID 
					where OG.QntConfirmed > 0 
					group by O.OutputTypeID, O.DateConfirm, OG.OutputID) X 
		inner join Outputs OO with (nolock) on X.OutputID = OO.ID 
		left join OutputsLoaders OL with (nolock) on OL.OutputID = X.OutputID 
		left join _Users U with (nolock) on OL.UserID = U.ID '
--set @cSelect = @cSelect + @cWhere
exec (@cSelect)

-- Раскидываем расходы по количеству людей
select T.BrigadeID, T.UserID, T.OutputID, T.DateConfirm, 
	sum(X.OutputsCount) as OutputsCount, 
	sum(T.LinesCount / X.OutputsCount) as LinesCount, 
	sum(T.BoxesCount / X.OutputsCount) as BoxesCount, 
	sum(T.Netto / X.OutputsCount) as Netto 
	into #OutputsLoadDataSum 
	from #OutputsLoadData T 
	inner join (select OutputID, count(*) as OutputsCount 
					from #OutputsLoadData 
					group by OutputID) X on X.OutputID = T.OutputID 
	group by T.BrigadeID, T.UserID, T.OutputID, T.DateConfirm

-- И вот только теперь применяем фильтр по сотрудникам!
if @cUsersList is not Null begin
	set @cSelect = 'delete #OutputsLoadDataSum ' + 
					'where UserID is Null or UserID not in ('+ dbo._NormalizeList(@cUsersList) + ')'
	exec (@cSelect)
end

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			OutputID, LinesCount, BoxesCount, Netto, 
			Null, 0, 0, 0, 0, 
			0, 0, Null, 0
		from #OutputsLoadDataSum 

--------------------------------------------------------------------------------
-- 'OUTPUTSVALIDATE'
-- контроль загрузки в машины
select U.BrigadeID, 
		OI.UserID, 
		OI.OutputID, 
		O.DateConfirm, 
		cast(0 as dec(8,1)) as LinesCount, 
		cast(0 as dec(15,1)) as BoxesCount, 
		cast(0 as dec(15,0)) as Netto 
	into #OutputsValidateData 
	from OutputsItems OI with (nolock) 
	inner join Packings P with (nolock) on OI.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join Outputs O with (nolock) on OI.OutputID = O.ID 
	inner join _Users U with (nolock) on OI.UserID = U.ID 
	where 1 = 2 

-- расходы для анализа
select O.ID * 1 as ID
	into #OutputsValidateTemp
	from Outputs O with (nolock) 
	where 1 = 2

set @cWhere = ' where X.DateConfirm is not Null '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', X.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', X.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cOutputsTypesList is not Null
	set @cWhere = @cWhere + ' and X.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '

set @cSelect = 
'insert #OutputsValidateTemp (ID)
	select X.ID 
		from Outputs X with (nolock) 
		inner join Partners Own with (nolock) on X.OwnerID = Own.ID '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)
--

set @cSelect = 
'insert #OutputsValidateData (BrigadeID, UserID, OutputID, DateConfirm, LinesCount, BoxesCount, Netto) 
	select U.BrigadeID, OO.ValidateUserID, X.OutputID, 
			convert(datetime, convert(varchar, X.DateConfirm, 112)), 
			cast(X.LinesCount as dec(8,1)) as LinesCount, X.BoxesCount, X.Netto 
		from (select O.OutputTypeID, O.DateConfirm, OG.OutputID, 
						count(distinct PackingID) as LinesCount, 
						sum(case when G.Weighting = 1 then cast(0.0 as dec(15,3)) else ceiling(OG.QntConfirmed / P.InBox) end) as BoxesCount, 
						sum(case when G.Weighting = 0 then cast(0.0 as dec(15,3)) else OG.QntConfirmed * G.Netto end) as Netto 
					from #OutputsValidateTemp _XYZ
					inner join Outputs O with (nolock) on _XYZ.ID = O.ID 
					inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
					inner join Packings P with (nolock) on OG.PackingID = P.ID 
					inner join Goods G with (nolock) on P.GoodID = G.ID 
					where OG.QntConfirmed > 0 
					group by O.OutputTypeID, O.DateConfirm, OG.OutputID) X 
		inner join Outputs OO with (nolock) on X.OutputID = OO.ID 
		left join _Users U with (nolock) on OO.ValidateUserID = U.ID '
--set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select BrigadeID, UserID, OutputID, DateConfirm, 
		1 as OutputsCount, LinesCount, BoxesCount, Netto 
	into #OutputsValidateDataSum 
	from #OutputsValidateData

-- применяем фильтр по сотрудникам!
if @cUsersList is not Null begin
	set @cSelect = 'delete #OutputsValidateDataSum ' + 
					'where UserID is Null or UserID not in ('+ dbo._NormalizeList(@cUsersList) + ')'
	exec (@cSelect)
end

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0,
			OutputID, OutputsCount, LinesCount, BoxesCount, Netto, 
			0, 0, Null, 0
		from #OutputsValidateDataSum 

--------------------------------------------------------------------------------
-- 'MOVINGS' 
-- перемещения коробок (не имеющие отношения к отгрузке)
select U.BrigadeID, 
		T.UserID, 
		T.DateConfirm, 
		T.PackingID, P.InBox, P.BoxInPal, G.Weighting, G.Netto, 
		T.QntConfirmed as Qnt, 
		T.ID * 1 as TrafficID 
	into #MovingsTrafficsGoodsData
	from TrafficsGoods T with (nolock)
	inner join _Users U with (nolock) on T.UserID = U.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	where 1 = 2 
	
set @cSelect = 
'insert #MovingsTrafficsGoodsData (BrigadeID, UserID, DateConfirm, 
		PackingID, InBox, BoxInPal, Weighting, Netto, Qnt, TrafficID) 
	select U.BrigadeID, T.UserID, 
			convert(datetime, convert(varchar, T.DateConfirm, 112)), 
			T.PackingID, P.InBox, P.BoxInPal, G.Weighting, G.Netto, 
			T.QntConfirmed, T.ID 
	from TrafficsGoods T with (nolock) 
	left join Partners Own with (nolock) on T.OwnerID = Own.ID 
	left join _Users U with (nolock) on T.UserID = U.ID 
	inner join Packings P with (nolock) on T.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID '
set @cWhere = ' where T.OutputID is Null and ' + 
					'T.DateConfirm is not Null and T.QntConfirmed > 0 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', T.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', T.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID is not Null and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select TrafficID, DateConfirm, 
		BrigadeID, UserID, 
		count(distinct TrafficID) as TrafficsCount, 
		sum(ceiling(Qnt / InBox)) as BoxesCount 
	into #MovingsTrafficsGoodsDataSum 
	from #MovingsTrafficsGoodsData 
	group by TrafficID, DateConfirm, BrigadeID, UserID

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			BoxesCount, 0, Null, 0
		from #MovingsTrafficsGoodsDataSum 

--------------------------------------------------------------------------------
-- 'INVENTORIES' 
-- ревизии, кол-во ревизованных ячеек
select I.ID as InventoryID, 
		U.BrigadeID, 
		IC.UserID, 
		I.DateConfirm, 
		IC.ID * 1 as InventoryCellID 
	into #InventoriesData
	from Inventories I with (nolock)
	inner join InventoriesCells IC with (nolock) on I.ID = IC.InventoryID
	inner join _Users U with (nolock) on IC.UserID = U.ID
	where 1 = 2 
	
set @cSelect = 
'insert #InventoriesData (InventoryID, BrigadeID, UserID, DateConfirm, InventoryCellID)
	select I.ID, U.BrigadeID, IC.UserID, 
			convert(datetime, convert(varchar, I.DateConfirm, 112)), 
			IC.ID 
	from Inventories I with (nolock)
	inner join InventoriesCells IC with (nolock) on I.ID = IC.InventoryID
	inner join _Users U with (nolock) on IC.UserID = U.ID '
set @cWhere = ' where I.DateConfirm is not Null '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', I.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', I.DateConfirm, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and IC.UserID is not Null and IC.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
if @cOwnersList is not Null -- ?
	set @cWhere = @cWhere + ' and IC.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select InventoryID, DateConfirm, 
		BrigadeID, UserID, 
		count(distinct InventoryCellID) as CellsCount 
	into #InventoriesDataSum 
	from #InventoriesData 
	group by InventoryID, DateConfirm, BrigadeID, UserID
	
insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			0, CellsCount, Null, 0
		from #InventoriesDataSum 

--------------------------------------------------------------------------------
-- 'SALARYEXTRAWORKS' 
-- доп.работы
select SEW.ID as SalaryExtraWorkID, 
		U.BrigadeID, 
		SEW.UserID, 
		SEW.DateWork as DateConfirm,
		SEW.Qnt, SEW.Price, SEW.Qnt * SEW.Price as Amount 
	into #SalaryExtraWorksData
	from SalaryExtraWorks SEW with (nolock)
	inner join _Users U with (nolock) on SEW.UserID = U.ID
	where 1 = 2 
	
set @cSelect = 
'insert #SalaryExtraWorksData (SalaryExtraWorkID, BrigadeID, UserID, DateConfirm, 
		Qnt, Price, Amount)
	select SEW.ID, U.BrigadeID, SEW.UserID, 
			convert(datetime, convert(varchar, SEW.DateWork, 112)), 
			SEW.Qnt, SEW.Price, SEW.Qnt * SEW.Price as Amount 
	from SalaryExtraWorks SEW with (nolock)
	inner join _Users U with (nolock) on SEW.UserID = U.ID '
set @cWhere = ' where 1 = 1 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', ''' + convert(varchar, @dDateBeg, @nDateConvertFormat) + ''', SEW.DateWork) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(' + @cDateConvertPart + ', SEW.DateWork, ''' + convert(varchar, @dDateEnd, @nDateConvertFormat) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and SEW.UserID is not Null and SEW.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

/*	
select SalaryExtraWorkID, DateConfirm, 
		BrigadeID, UserID, 
		sum(Amount) as Amount
	into #SalaryExtraWorksDataSum 
	from #SalaryExtraWorksData
	group by SalaryExtraWorkID, DateConfirm, BrigadeID, UserID
*/
select * 
	into #SalaryExtraWorksDataSum 
	from #SalaryExtraWorksData
	
insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount, 
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto, 
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto, 
		ValidateOutputID, ValidateOutputsCount, ValidateOutputsLinesCount, ValidateOutputsBoxesCount, ValidateOutputsNetto, 
		MovingsBoxesCount, InventoriesCellsCount, SalaryExtraWorkID, SalaryExtraWorksAmount)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0, 0, 
			0, 0, SalaryExtraWorkID, Amount
		from #SalaryExtraWorksDataSum 

-- ИТАК: -- 
/*
if @cDetailMode = 'DETAIL' begin
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, 
				X.DateConfirm, 
				IsNull(I.ERPCode, IsNull(IAcc.ERPCode, IsNull(OPick.ERPCode, IsNull(O.ERPCode, SE.ERPCode)))) as ERPCode, 
				IsNull(PInp.Name, IsNull(PInpAcc.Name, IsNull(POutPick.Name, IsNull(POut.Name, SE.WorkName)))) as PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						cast(0 as int) as UserID, 
						D.BrigadeID, 
						D.InputID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney)) as InputsItemsRelativeCount, 
						D.AccInputID, 						
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney)) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney)) as MovesUp, 
						sum(D.MovesDown * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney)) as MovesDown, 
						sum(D.MovesFloorCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney)) as MovesFloorCount, 
						D.PickOutputID, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney)) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney)) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney)) as PickOutputsNetto, 
						D.OutputID, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney)) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney)) as OutputsBoxesCount, 
						sum(D.OutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney)) as OutputsNetto, 
						D.ValidateOutputID, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney)) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney)) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney)) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney)) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney)) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney)) as InventoriesCellsCount, 
						D.SalaryExtraWorkID, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) + 
							IsNull(D.AccInputsOperationsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) +
							IsNull(D.MovesUp, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) +
							IsNull(D.MovesDown, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) +
							IsNull(D.MovesFloorCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) +
							IsNull(D.PickOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) +
							IsNull(D.PickOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) +
							IsNull(D.PickOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) +
							IsNull(D.OutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) +
							IsNull(D.OutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) +
							IsNull(D.OutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) +
							/*IsNull(D.ValidateOutputsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) + */
							IsNull(D.ValidateOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) +
							IsNull(D.ValidateOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) +
							IsNull(D.ValidateOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) +
							IsNull(D.MovingsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) + 
							IsNull(D.InventoriesCellsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) + 
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #Data D 
					group by D.BrigadeID, D.DateConfirm, D.InputID, D.AccInputID, D.PickOutputID, D.OutputID, D.ValidateOutputID, D.SalaryExtraWorkID) X
				left join Inputs I with (nolock) on X.InputID = I.ID 
				left join Inputs IAcc with (nolock) on X.AccInputID = IAcc.ID 
				left join Outputs OPick with (nolock) on X.PickOutputID = OPick.ID 
				left join Outputs O with (nolock) on X.OutputID = O.ID 
				left join Outputs OValidate with (nolock) on X.ValidateOutputID = OValidate.ID 
				left join SalaryExtraWorks SE with (nolock) on X.SalaryExtraWorkID = SE.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				left join Partners PInp with (nolock) on I.PartnerID = PInp.ID
				left join Partners PInpAcc with (nolock) on IAcc.PartnerID = PInpAcc.ID
				left join Partners POutPick with (nolock) on OPick.PartnerID = POutPick.ID
				left join Partners POut with (nolock) on O.PartnerID = POut.ID
				left join Partners POutValidate with (nolock) on OValidate.PartnerID = POutValidate.ID
				order by X.DateConfirm, B.Name, I.ERPCode, IAcc.ERPCode, OPick.ERPCode, O.ERPCode, OValidate.ERPCode, SE.ERPCode
	end
	else begin
		-- по сотрудникам
		select X.*, 
				IsNull(I.ERPCode, IsNull(IAcc.ERPCode, IsNull(OPick.ERPCode, IsNull(O.ERPCode, IsNull(OValidate.ERPCode, SE.ERPCode))))) as ERPCode, 
				IsNull(PInp.Name, IsNull(PInpAcc.Name, IsNull(POutPick.Name, IsNull(POut.Name, IsNull(POutValidate.Name, SE.WorkName))))) as PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						D.UserID, 
						D.BrigadeID, 
						D.InputID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney)) as InputsItemsRelativeCount, 
						D.AccInputID, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney)) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney)) as MovesUp, 
						sum(D.MovesDown * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney)) as MovesDown, 
						sum(D.MovesFloorCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney)) as MovesFloorCount, 
						D.PickOutputID, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney)) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney)) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney)) as PickOutputsNetto, 
						D.OutputID, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney)) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney)) as OutputsBoxesCount, 
						sum(D.OutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney)) as OutputsNetto, 
						D.ValidateOutputID, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney)) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney)) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney)) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney)) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney)) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney)) as InventoriesCellsCount, 
						D.SalaryExtraWorkID, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) + 
							IsNull(D.AccInputsOperationsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) +
							IsNull(D.MovesUp, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) +
							IsNull(D.MovesDown, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) +
							IsNull(D.MovesFloorCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) +
							IsNull(D.PickOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) +
							IsNull(D.PickOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) +
							IsNull(D.PickOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) +
							IsNull(D.OutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) +
							IsNull(D.OutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) +
							IsNull(D.OutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) +
							/*IsNull(D.ValidateOutputsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) + */
							IsNull(D.ValidateOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) +
							IsNull(D.ValidateOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) +
							IsNull(D.ValidateOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) +
							IsNull(D.MovingsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) + 
							IsNull(D.InventoriesCellsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) + 
							IsNull(D.SalaryExtraWorksAmount, 0)) as TotalAmount 
					from #Data D
					group by D.BrigadeID, D.UserID, D.DateConfirm, D.InputID, D.AccInputID, D.PickOutputID, D.OutputID, D.ValidateOutputID, D.SalaryExtraWorkID) X 
			left join Inputs I with (nolock) on X.InputID = I.ID 
			left join Inputs IAcc with (nolock) on X.AccInputID = I.ID 
			left join Outputs OPick with (nolock) on X.PickOutputID = OPick.ID 
			left join Outputs O with (nolock) on X.OutputID = O.ID 
			left join Outputs OValidate with (nolock) on X.ValidateOutputID = OValidate.ID 
			left join SalaryExtraWorks SE with (nolock) on X.SalaryExtraWorkID = SE.ID
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			left join Partners PInp with (nolock) on I.PartnerID = PInp.ID
			left join Partners PInpAcc with (nolock) on IAcc.PartnerID = PInpAcc.ID
			left join Partners POutPick with (nolock) on OPick.PartnerID = POutPick.ID
			left join Partners POut with (nolock) on O.PartnerID = POut.ID
			left join Partners POutValidate with (nolock) on OValidate.PartnerID = POutValidate.ID
			order by X.DateConfirm, B.Name, U.Name
	end
end

if @cDetailMode = 'DATE' begin
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*,
				X.DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						cast(0 as int) as UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney)) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney)) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney)) as MovesUp, 
						sum(D.MovesDown * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney)) as MovesDown, 
						sum(D.MovesFloorCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney)) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney)) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney)) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney)) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney)) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney)) as OutputsBoxesCount, 
						sum(D.OutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney)) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney)) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney)) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney)) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney)) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney)) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney)) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) + 
							IsNull(D.AccInputsOperationsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) +
							IsNull(D.MovesUp, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) +
							IsNull(D.MovesDown, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) +
							IsNull(D.MovesFloorCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) +
							IsNull(D.PickOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) +
							IsNull(D.PickOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) +
							IsNull(D.PickOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) +
							IsNull(D.OutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) +
							IsNull(D.OutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) +
							IsNull(D.OutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) +
							/*IsNull(D.ValidateOutputsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) + */
							IsNull(D.ValidateOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) +
							IsNull(D.ValidateOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) +
							IsNull(D.ValidateOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) +
							IsNull(D.MovingsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) + 
							IsNull(D.InventoriesCellsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) + 
							IsNull(D.SalaryExtraWorksAmount, 0)) as TotalAmount 
					from #Data D
					group by D.DateConfirm, D.BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by X.DateConfirm, B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, 
				X.DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						D.UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney)) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney)) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney)) as MovesUp, 
						sum(D.MovesDown * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney)) as MovesDown, 
						sum(D.MovesFloorCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney)) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney)) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney)) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney)) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney)) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney)) as OutputsBoxesCount, 
						sum(D.OutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney)) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney)) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney)) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney)) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney)) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney)) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney)) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) + 
							IsNull(D.AccInputsOperationsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) +
							IsNull(D.MovesUp, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) +
							IsNull(D.MovesDown, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) +
							IsNull(D.MovesFloorCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) +
							IsNull(D.PickOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) +
							IsNull(D.PickOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) +
							IsNull(D.PickOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) +
							IsNull(D.OutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) +
							IsNull(D.OutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) +
							IsNull(D.OutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) +
							/*IsNull(D.ValidateOutputsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) + */
							IsNull(D.ValidateOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) +
							IsNull(D.ValidateOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) +
							IsNull(D.ValidateOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) +
							IsNull(D.MovingsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) + 
							IsNull(D.InventoriesCellsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) + 
							IsNull(D.SalaryExtraWorksAmount, 0)) as TotalAmount 
					from #Data D 
					group by D.DateConfirm, D.UserID, D.BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by X.DateConfirm, B.Name, U.Name
	end
end

if @cDetailMode = 'TOTAL' begin
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, 
				Null as DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney)) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney)) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney)) as MovesUp, 
						sum(D.MovesDown * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney)) as MovesDown, 
						sum(D.MovesFloorCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney)) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney)) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney)) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney)) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney)) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney)) as OutputsBoxesCount, 
						sum(D.OutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney)) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney)) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney)) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney)) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney)) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney)) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney)) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) + 
							IsNull(D.AccInputsOperationsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) +
							IsNull(D.MovesUp, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) +
							IsNull(D.MovesDown, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) +
							IsNull(D.MovesFloorCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) +
							IsNull(D.PickOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) +
							IsNull(D.PickOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) +
							IsNull(D.PickOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) +
							IsNull(D.OutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) +
							IsNull(D.OutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) +
							IsNull(D.OutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) +
							/*IsNull(D.ValidateOutputsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) + */
							IsNull(D.ValidateOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) +
							IsNull(D.ValidateOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) +
							IsNull(D.ValidateOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) +
							IsNull(D.MovingsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) + 
							IsNull(D.InventoriesCellsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) + 
							IsNull(D.SalaryExtraWorksAmount, 0)) as TotalAmount 
					from #Data D
					group by D.BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, 
				Null as DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney)) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney)) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney)) as MovesUp, 
						sum(D.MovesDown * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney)) as MovesDown, 
						sum(D.MovesFloorCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney)) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney)) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney)) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney)) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney)) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney)) as OutputsBoxesCount, 
						sum(D.OutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney)) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney)) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney)) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney)) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney)) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney)) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney)) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) + 
							IsNull(D.AccInputsOperationsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) +
							IsNull(D.MovesUp, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) +
							IsNull(D.MovesDown, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) +
							IsNull(D.MovesFloorCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) +
							IsNull(D.PickOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) +
							IsNull(D.PickOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) +
							IsNull(D.PickOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) +
							IsNull(D.OutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) +
							IsNull(D.OutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) +
							IsNull(D.OutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) +
							/*IsNull(D.ValidateOutputsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) + */
							IsNull(D.ValidateOutputsLinesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) +
							IsNull(D.ValidateOutputsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) +
							IsNull(D.ValidateOutputsNetto, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) +
							IsNull(D.MovingsBoxesCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) + 
							IsNull(D.InventoriesCellsCount, 0) * .dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) + 
							IsNull(D.SalaryExtraWorksAmount, 0)) as TotalAmount 
					from #Data D 
					group by D.UserID, D.BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end
end
*/

-- предварительно заполним тарифы 
select D.*, 
		IsNull(I.ERPCode, IsNull(IAcc.ERPCode, IsNull(OPick.ERPCode, IsNull(O.ERPCode, isNull(OValidate.ERPCode, SE.ERPCode))))) as ERPCode, 
		IsNull(PInp.Name, IsNull(PInpAcc.Name, IsNull(POutPick.Name, IsNull(POut.Name, isNull(POutValidate.Name, SE.WorkName))))) as PartnerName, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'InputsItemsRelative', @bMoney) as TariffInputsItemsRelative, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'AccInputsOperations', @bMoney) as TariffAccInputsOperations, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'MovesUpOperations', @bMoney) as TariffMovesUpOperations, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'MovesDownOperations', @bMoney) as TariffMovesDownOperations, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'MovesFloorOperations', @bMoney) as TariffMovesFloorOperations, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsLines', @bMoney) as TariffPickOutputsLines, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsBoxes', @bMoney) as TariffPickOutputsBoxes, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'PickOutputsNetto', @bMoney) as TariffPickOutputsNetto, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'OutputsLines', @bMoney) as TariffOutputsLines, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'OutputsBoxes', @bMoney) as TariffOutputsBoxes, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'OutputsNetto', @bMoney) as TariffOutputsNetto, 
		/*.dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsOperations', @bMoney) as TariffValidateOutputsOperations, */
		.dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsLines', @bMoney) as TariffValidateOutputsLines, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsBoxes', @bMoney) as TariffValidateOutputsBoxes, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'ValidateOutputsNetto', @bMoney) as TariffValidateOutputsNetto, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'MovingsBoxes', @bMoney) as TariffMovingsBoxes, 
		.dbo.GetSalaryTariff(D.DateConfirm, 'InventoriesCells', @bMoney) as TariffInventoriesCells 
	into #DataData	
	from #Data D 
	left join Inputs I with (nolock) on D.InputID = I.ID 
	left join Inputs IAcc with (nolock) on D.AccInputID = IAcc.ID 
	left join Outputs OPick with (nolock) on D.PickOutputID = OPick.ID 
	left join Outputs O with (nolock) on D.OutputID = O.ID 
	left join Outputs OValidate with (nolock) on D.ValidateOutputID = OValidate.ID 
	left join SalaryExtraWorks SE with (nolock) on D.SalaryExtraWorkID = SE.ID
	left join Partners PInp with (nolock) on I.PartnerID = PInp.ID
	left join Partners PInpAcc with (nolock) on IAcc.PartnerID = PInpAcc.ID
	left join Partners POutPick with (nolock) on OPick.PartnerID = POutPick.ID
	left join Partners POut with (nolock) on O.PartnerID = POut.ID
	left join Partners POutValidate with (nolock) on OValidate.PartnerID = POutValidate.ID

if @cDetailMode = 'DETAIL' begin
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, 
				X.DateConfirm, X.ERPCode, X.PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						cast(0 as int) as UserID, 
						D.BrigadeID, 
						D.ERPCode, D.PartnerName, 
						D.InputID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * D.TariffInputsItemsRelative) as InputsItemsRelativeCount, 
						D.AccInputID, 						
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * D.TariffAccInputsOperations) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * D.TariffMovesUpOperations) as MovesUp, 
						sum(D.MovesDown * D.TariffMovesDownOperations) as MovesDown, 
						sum(D.MovesFloorCount * D.TariffMovesFloorOperations) as MovesFloorCount, 
						D.PickOutputID, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * D.TariffPickOutputsLines) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * D.TariffPickOutputsBoxes) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * D.TariffPickOutputsNetto) as PickOutputsNetto, 
						D.OutputID, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * D.TariffOutputsLines) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * D.TariffOutputsBoxes) as OutputsBoxesCount, 
						sum(D.OutputsNetto * D.TariffOutputsNetto) as OutputsNetto, 
						D.ValidateOutputID, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * D.TariffValidateOutputsOperations) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * D.TariffValidateOutputsLines) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * D.TariffValidateOutputsBoxes) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * D.TariffValidateOutputsNetto) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * D.TariffMovingsBoxes) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * D.TariffInventoriesCells) as InventoriesCellsCount, 
						D.SalaryExtraWorkID, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * D.TariffInputsItemsRelative + 
							IsNull(D.AccInputsOperationsCount, 0) * D.TariffAccInputsOperations +
							IsNull(D.MovesUp, 0) * D.TariffMovesUpOperations +
							IsNull(D.MovesDown, 0) * D.TariffMovesDownOperations +
							IsNull(D.MovesFloorCount, 0) * D.TariffMovesFloorOperations +
							IsNull(D.PickOutputsLinesCount, 0) * D.TariffPickOutputsLines +
							IsNull(D.PickOutputsBoxesCount, 0) * D.TariffPickOutputsBoxes +
							IsNull(D.PickOutputsNetto, 0) * D.TariffPickOutputsNetto +
							IsNull(D.OutputsLinesCount, 0) * D.TariffOutputsLines +
							IsNull(D.OutputsBoxesCount, 0) * D.TariffOutputsBoxes +
							IsNull(D.OutputsNetto, 0) * D.TariffOutputsNetto +
							/*IsNull(D.ValidateOutputsCount, 0) * D.TariffValidateOutputsOperations + */
							IsNull(D.ValidateOutputsLinesCount, 0) * D.TariffValidateOutputsLines +
							IsNull(D.ValidateOutputsBoxesCount, 0) * D.TariffValidateOutputsBoxes +
							IsNull(D.ValidateOutputsNetto, 0) * D.TariffValidateOutputsNetto +
							IsNull(D.MovingsBoxesCount, 0) * D.TariffMovingsBoxes + 
							IsNull(D.InventoriesCellsCount, 0) * D.TariffInventoriesCells +  
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #DataData D 
					group by D.BrigadeID, D.DateConfirm, D.InputID, D.AccInputID, D.PickOutputID, D.OutputID, D.ValidateOutputID, D.SalaryExtraWorkID, D.ERPCode, D.PartnerName) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by X.DateConfirm, B.Name, X.ERPCode
	end
	else begin
		-- по сотрудникам
		select X.*, 
				X.ERPCode, X.PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						D.UserID, 
						D.BrigadeID, 
						D.ERPCode, D.PartnerName, 
						D.InputID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * D.TariffInputsItemsRelative) as InputsItemsRelativeCount, 
						D.AccInputID, 						
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * D.TariffAccInputsOperations) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * D.TariffMovesUpOperations) as MovesUp, 
						sum(D.MovesDown * D.TariffMovesDownOperations) as MovesDown, 
						sum(D.MovesFloorCount * D.TariffMovesFloorOperations) as MovesFloorCount, 
						D.PickOutputID, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * D.TariffPickOutputsLines) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * D.TariffPickOutputsBoxes) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * D.TariffPickOutputsNetto) as PickOutputsNetto, 
						D.OutputID, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * D.TariffOutputsLines) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * D.TariffOutputsBoxes) as OutputsBoxesCount, 
						sum(D.OutputsNetto * D.TariffOutputsNetto) as OutputsNetto, 
						D.ValidateOutputID, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * D.TariffValidateOutputsOperations) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * D.TariffValidateOutputsLines) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * D.TariffValidateOutputsBoxes) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * D.TariffValidateOutputsNetto) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * D.TariffMovingsBoxes) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * D.TariffInventoriesCells) as InventoriesCellsCount, 
						D.SalaryExtraWorkID, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * D.TariffInputsItemsRelative + 
							IsNull(D.AccInputsOperationsCount, 0) * D.TariffAccInputsOperations +
							IsNull(D.MovesUp, 0) * D.TariffMovesUpOperations +
							IsNull(D.MovesDown, 0) * D.TariffMovesDownOperations +
							IsNull(D.MovesFloorCount, 0) * D.TariffMovesFloorOperations +
							IsNull(D.PickOutputsLinesCount, 0) * D.TariffPickOutputsLines +
							IsNull(D.PickOutputsBoxesCount, 0) * D.TariffPickOutputsBoxes +
							IsNull(D.PickOutputsNetto, 0) * D.TariffPickOutputsNetto +
							IsNull(D.OutputsLinesCount, 0) * D.TariffOutputsLines +
							IsNull(D.OutputsBoxesCount, 0) * D.TariffOutputsBoxes +
							IsNull(D.OutputsNetto, 0) * D.TariffOutputsNetto +
							/*IsNull(D.ValidateOutputsCount, 0) * D.TariffValidateOutputsOperations + */
							IsNull(D.ValidateOutputsLinesCount, 0) * D.TariffValidateOutputsLines +
							IsNull(D.ValidateOutputsBoxesCount, 0) * D.TariffValidateOutputsBoxes +
							IsNull(D.ValidateOutputsNetto, 0) * D.TariffValidateOutputsNetto +
							IsNull(D.MovingsBoxesCount, 0) * D.TariffMovingsBoxes + 
							IsNull(D.InventoriesCellsCount, 0) * D.TariffInventoriesCells +  
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #DataData D
					group by D.BrigadeID, D.UserID, D.DateConfirm, D.InputID, D.AccInputID, D.PickOutputID, D.OutputID, D.ValidateOutputID, D.SalaryExtraWorkID, D.ERPCode, D.PartnerName) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by X.DateConfirm, B.Name, U.Name
	end
end

if @cDetailMode = 'DATE' begin
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*,
				X.DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						cast(0 as int) as UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * D.TariffInputsItemsRelative) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * D.TariffAccInputsOperations) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * D.TariffMovesUpOperations) as MovesUp, 
						sum(D.MovesDown * D.TariffMovesDownOperations) as MovesDown, 
						sum(D.MovesFloorCount * D.TariffMovesFloorOperations) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * D.TariffPickOutputsLines) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * D.TariffPickOutputsBoxes) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * D.TariffPickOutputsNetto) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * D.TariffOutputsLines) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * D.TariffOutputsBoxes) as OutputsBoxesCount, 
						sum(D.OutputsNetto * D.TariffOutputsNetto) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * D.TariffValidateOutputsOperations) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * D.TariffValidateOutputsLines) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * D.TariffValidateOutputsBoxes) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * D.TariffValidateOutputsNetto) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * D.TariffMovingsBoxes) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * D.TariffInventoriesCells) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * D.TariffInputsItemsRelative + 
							IsNull(D.AccInputsOperationsCount, 0) * D.TariffAccInputsOperations +
							IsNull(D.MovesUp, 0) * D.TariffMovesUpOperations +
							IsNull(D.MovesDown, 0) * D.TariffMovesDownOperations +
							IsNull(D.MovesFloorCount, 0) * D.TariffMovesFloorOperations +
							IsNull(D.PickOutputsLinesCount, 0) * D.TariffPickOutputsLines +
							IsNull(D.PickOutputsBoxesCount, 0) * D.TariffPickOutputsBoxes +
							IsNull(D.PickOutputsNetto, 0) * D.TariffPickOutputsNetto +
							IsNull(D.OutputsLinesCount, 0) * D.TariffOutputsLines +
							IsNull(D.OutputsBoxesCount, 0) * D.TariffOutputsBoxes +
							IsNull(D.OutputsNetto, 0) * D.TariffOutputsNetto +
							/*IsNull(D.ValidateOutputsCount, 0) * D.TariffValidateOutputsOperations + */
							IsNull(D.ValidateOutputsLinesCount, 0) * D.TariffValidateOutputsLines +
							IsNull(D.ValidateOutputsBoxesCount, 0) * D.TariffValidateOutputsBoxes +
							IsNull(D.ValidateOutputsNetto, 0) * D.TariffValidateOutputsNetto +
							IsNull(D.MovingsBoxesCount, 0) * D.TariffMovingsBoxes + 
							IsNull(D.InventoriesCellsCount, 0) * D.TariffInventoriesCells +  
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #DataData D
					group by D.DateConfirm, D.BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by X.DateConfirm, B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, 
				X.DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.DateConfirm, 
						D.UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * D.TariffInputsItemsRelative) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * D.TariffAccInputsOperations) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * D.TariffMovesUpOperations) as MovesUp, 
						sum(D.MovesDown * D.TariffMovesDownOperations) as MovesDown, 
						sum(D.MovesFloorCount * D.TariffMovesFloorOperations) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * D.TariffPickOutputsLines) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * D.TariffPickOutputsBoxes) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * D.TariffPickOutputsNetto) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * D.TariffOutputsLines) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * D.TariffOutputsBoxes) as OutputsBoxesCount, 
						sum(D.OutputsNetto * D.TariffOutputsNetto) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * D.TariffValidateOutputsOperations) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * D.TariffValidateOutputsLines) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * D.TariffValidateOutputsBoxes) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * D.TariffValidateOutputsNetto) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * D.TariffMovingsBoxes) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * D.TariffInventoriesCells) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * D.TariffInputsItemsRelative + 
							IsNull(D.AccInputsOperationsCount, 0) * D.TariffAccInputsOperations +
							IsNull(D.MovesUp, 0) * D.TariffMovesUpOperations +
							IsNull(D.MovesDown, 0) * D.TariffMovesDownOperations +
							IsNull(D.MovesFloorCount, 0) * D.TariffMovesFloorOperations +
							IsNull(D.PickOutputsLinesCount, 0) * D.TariffPickOutputsLines +
							IsNull(D.PickOutputsBoxesCount, 0) * D.TariffPickOutputsBoxes +
							IsNull(D.PickOutputsNetto, 0) * D.TariffPickOutputsNetto +
							IsNull(D.OutputsLinesCount, 0) * D.TariffOutputsLines +
							IsNull(D.OutputsBoxesCount, 0) * D.TariffOutputsBoxes +
							IsNull(D.OutputsNetto, 0) * D.TariffOutputsNetto +
							/*IsNull(D.ValidateOutputsCount, 0) * D.TariffValidateOutputsOperations + */
							IsNull(D.ValidateOutputsLinesCount, 0) * D.TariffValidateOutputsLines +
							IsNull(D.ValidateOutputsBoxesCount, 0) * D.TariffValidateOutputsBoxes +
							IsNull(D.ValidateOutputsNetto, 0) * D.TariffValidateOutputsNetto +
							IsNull(D.MovingsBoxesCount, 0) * D.TariffMovingsBoxes + 
							IsNull(D.InventoriesCellsCount, 0) * D.TariffInventoriesCells +  
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #DataData D 
					group by D.DateConfirm, D.UserID, D.BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by X.DateConfirm, B.Name, U.Name
	end
end

if @cDetailMode = 'TOTAL' begin
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, 
				Null as DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * D.TariffInputsItemsRelative) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * D.TariffAccInputsOperations) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * D.TariffMovesUpOperations) as MovesUp, 
						sum(D.MovesDown * D.TariffMovesDownOperations) as MovesDown, 
						sum(D.MovesFloorCount * D.TariffMovesFloorOperations) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * D.TariffPickOutputsLines) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * D.TariffPickOutputsBoxes) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * D.TariffPickOutputsNetto) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * D.TariffOutputsLines) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * D.TariffOutputsBoxes) as OutputsBoxesCount, 
						sum(D.OutputsNetto * D.TariffOutputsNetto) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * D.TariffValidateOutputsOperations) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * D.TariffValidateOutputsLines) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * D.TariffValidateOutputsBoxes) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * D.TariffValidateOutputsNetto) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * D.TariffMovingsBoxes) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * D.TariffInventoriesCells) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * D.TariffInputsItemsRelative + 
							IsNull(D.AccInputsOperationsCount, 0) * D.TariffAccInputsOperations +
							IsNull(D.MovesUp, 0) * D.TariffMovesUpOperations +
							IsNull(D.MovesDown, 0) * D.TariffMovesDownOperations +
							IsNull(D.MovesFloorCount, 0) * D.TariffMovesFloorOperations +
							IsNull(D.PickOutputsLinesCount, 0) * D.TariffPickOutputsLines +
							IsNull(D.PickOutputsBoxesCount, 0) * D.TariffPickOutputsBoxes +
							IsNull(D.PickOutputsNetto, 0) * D.TariffPickOutputsNetto +
							IsNull(D.OutputsLinesCount, 0) * D.TariffOutputsLines +
							IsNull(D.OutputsBoxesCount, 0) * D.TariffOutputsBoxes +
							IsNull(D.OutputsNetto, 0) * D.TariffOutputsNetto +
							/*IsNull(D.ValidateOutputsCount, 0) * D.TariffValidateOutputsOperations + */
							IsNull(D.ValidateOutputsLinesCount, 0) * D.TariffValidateOutputsLines +
							IsNull(D.ValidateOutputsBoxesCount, 0) * D.TariffValidateOutputsBoxes +
							IsNull(D.ValidateOutputsNetto, 0) * D.TariffValidateOutputsNetto +
							IsNull(D.MovingsBoxesCount, 0) * D.TariffMovingsBoxes + 
							IsNull(D.InventoriesCellsCount, 0) * D.TariffInventoriesCells +  
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #DataData D
					group by D.BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, 
				Null as DateConfirm, 
				'' as ERPCode, '' as PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select D.UserID, 
						D.BrigadeID, 
						count(distinct D.InputID) as InputsCount, 
						sum(D.InputsItemsCount) as InputsItemsCount, 
						sum(D.InputsBoxesCount) as InputsBoxesCount, 
						sum(D.InputsNetto) as InputsNetto, 
						sum(D.InputsItemsRelativeCount * D.TariffInputsItemsRelative) as InputsItemsRelativeCount, 
						count(distinct D.AccInputID) as AccInputsCount, 
						sum(D.AccInputsOperationsCount * D.TariffAccInputsOperations) as AccInputsOperationsCount, 
						sum(D.MovesOperationsCount) as MovesOperationsCount, 
						sum(D.MovesUp * D.TariffMovesUpOperations) as MovesUp, 
						sum(D.MovesDown * D.TariffMovesDownOperations) as MovesDown, 
						sum(D.MovesFloorCount * D.TariffMovesFloorOperations) as MovesFloorCount, 
						count(distinct D.PickOutputID) as PickOutputsCount, 
						sum(D.PickOutputsLinesCount * D.TariffPickOutputsLines) as PickOutputsLinesCount, 
						sum(D.PickOutputsBoxesCount * D.TariffPickOutputsBoxes) as PickOutputsBoxesCount, 
						sum(D.PickOutputsNetto * D.TariffPickOutputsNetto) as PickOutputsNetto, 
						count(distinct D.OutputID) as OutputsCount, 
						sum(D.OutputsLinesCount * D.TariffOutputsLines) as OutputsLinesCount, 
						sum(D.OutputsBoxesCount * D.TariffOutputsBoxes) as OutputsBoxesCount, 
						sum(D.OutputsNetto * D.TariffOutputsNetto) as OutputsNetto, 
						count(distinct D.ValidateOutputID) as ValidateOutputsCount, 
						/*sum(D.ValidateOutputsCount * D.TariffValidateOutputsOperations) as ValidateOutputsOperationsCount, */
						sum(D.ValidateOutputsLinesCount * D.TariffValidateOutputsLines) as ValidateOutputsLinesCount, 
						sum(D.ValidateOutputsBoxesCount * D.TariffValidateOutputsBoxes) as ValidateOutputsBoxesCount, 
						sum(D.ValidateOutputsNetto * D.TariffValidateOutputsNetto) as ValidateOutputsNetto, 
						sum(D.MovingsBoxesCount * D.TariffMovingsBoxes) as MovingsBoxesCount, 
						sum(D.InventoriesCellsCount * D.TariffInventoriesCells) as InventoriesCellsCount, 
						sum(D.SalaryExtraWorksAmount) as SalaryExtraWorksAmount, 
						sum(IsNull(D.InputsItemsRelativeCount, 0) * D.TariffInputsItemsRelative + 
							IsNull(D.AccInputsOperationsCount, 0) * D.TariffAccInputsOperations +
							IsNull(D.MovesUp, 0) * D.TariffMovesUpOperations +
							IsNull(D.MovesDown, 0) * D.TariffMovesDownOperations +
							IsNull(D.MovesFloorCount, 0) * D.TariffMovesFloorOperations +
							IsNull(D.PickOutputsLinesCount, 0) * D.TariffPickOutputsLines +
							IsNull(D.PickOutputsBoxesCount, 0) * D.TariffPickOutputsBoxes +
							IsNull(D.PickOutputsNetto, 0) * D.TariffPickOutputsNetto +
							IsNull(D.OutputsLinesCount, 0) * D.TariffOutputsLines +
							IsNull(D.OutputsBoxesCount, 0) * D.TariffOutputsBoxes +
							IsNull(D.OutputsNetto, 0) * D.TariffOutputsNetto +
							/*IsNull(D.ValidateOutputsCount, 0) * D.TariffValidateOutputsOperations + */
							IsNull(D.ValidateOutputsLinesCount, 0) * D.TariffValidateOutputsLines +
							IsNull(D.ValidateOutputsBoxesCount, 0) * D.TariffValidateOutputsBoxes +
							IsNull(D.ValidateOutputsNetto, 0) * D.TariffValidateOutputsNetto +
							IsNull(D.MovingsBoxesCount, 0) * D.TariffMovingsBoxes + 
							IsNull(D.InventoriesCellsCount, 0) * D.TariffInventoriesCells +  
							IsNull(D.SalaryExtraWorksAmount, 0) ) as TotalAmount 
					from #DataData D 
					group by D.UserID, D.BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end
end
return