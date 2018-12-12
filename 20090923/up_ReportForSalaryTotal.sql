set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_ReportForSalaryTotal]
	@dDateBeg			smalldatetime	= Null, 
	@dDateEnd			smalldatetime	= Null, 
	@cDetailMode		varchar(20)		= Null, -- DETAIL, DATE, TOTAL
	@bGroupBy			bit, 
	@cUsersList			varchar(max)	= Null, 
	@cInputsTypesList	varchar(max)	= Null,
	@cOutputsTypesList	varchar(max)	= Null, 
	@cOwnersList		varchar(max)	= Null
AS
/*
exec up_ReportForSalaryTotal '20080801', '20080810', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'DATE', 0, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'TOTAL', 0, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'DETAIL', 1, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'DATE', 1, null, null, null, null
exec up_ReportForSalaryTotal '20080801', '20080810', 'TOTAL', 1, null, null, null, null
*/

set nocount on

set dateformat ymd

select  U.BrigadeID, T.UserID, T.DateConfirm, 
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
		cast(0 as dec(15, 0)) as OutputsNetto 
	into #Data 
	from TrafficsGoods T with (nolock)
	inner join _Users U with (nolock) on T.UserID = U.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	where 1 = 2 
create index IX_UserID on #Data (UserID)
create index IX_BrigadeID on #Data (BrigadeID)

declare @cSelect varchar(max), @cSelectX varchar(max), @cWhere varchar(max)

-- 'INPUTSUNLOAD'
-- Разгрузка машины
select  U.BrigadeID,  
		II.UserID, 
		II.InputID, 
		I.DateConfirm, -- (DateInput)
		cast(0 as dec(15,1)) as BoxesCount, 
		cast(0 as dec(15,0)) as Netto, 
		cast(0 as dec(5,1)) as InputsItemsCount, 
		cast(0 as dec(5,1)) as CoefficientUnload 
	into #InputsUnloadData 
	from InputsItems II with (nolock)
	inner join Inputs I with (nolock) on II.InputID = I.ID
	inner join _Users U with (nolock) on II.UserID = U.ID
	where 1 = 2 

set @cSelect = 
'insert #InputsUnloadData (BrigadeID, UserID, InputID, DateConfirm, 
		BoxesCount, Netto, InputsItemsCount, CoefficientUnload) 
	select  U.BrigadeID, IU.UserID, X.InputID, 
			convert(datetime, convert(varchar, I.DateConfirm, 112)), 
			X.BoxesCount, X.Netto, X.InputsItemsCount, I.CoefficientUnload 
		from (select II.InputID, 
					sum(II.Qnt / P.InBox) as BoxesCount, 
					sum(II.Qnt * G.Netto) as Netto, 
					count(*) as InputsItemsCount 
				from InputsItems II with (nolock) 
				inner join Packings P with (nolock) on II.PackingID = P.ID 
				inner join Goods G with (nolock) on P.GoodID = G.ID 
				group by InputID) X 
		inner join Inputs I with (nolock) on X.InputID = I.ID 
		inner join Partners Own with (nolock) on I.OwnerID = Own.ID 
		left join InputsUnloaders IU with (nolock) on X.InputID = IU.InputID
		left join _Users U with (nolock) on IU.UserID = U.ID '
set	@cWhere = ' where 1 = 1 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', I.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(day, I.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and IU.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
if @cInputsTypesList is not Null
	set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
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

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount,  
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto,  
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			InputID, InputsItemsCount, BoxesCount, Netto, InputsItemsRelativeCount, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0 
		from #InputsUnloadDataSum 

--------------------------------------------------------------------------------
-- 'INPUTSACCEPT'
-- Непосредственно приемка
select  U.BrigadeID,  
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
	select  U.BrigadeID, II.UserID, II.InputID, 
			convert(datetime, convert(varchar, I.DateConfirm, 112)),  -- II.DateConfirm
			II.ID 
		from InputsItems II with (nolock)
		inner join Inputs I with (nolock) on II.InputID = I.ID 
		inner join Partners Own with (nolock) on I.OwnerID = Own.ID 
		inner join _Users U with (nolock) on II.UserID = U.ID '
set @cWhere = ' where 1 = 1 '
if @dDateBeg is not Null 
	--set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', II.DateConfirm) >= 0 '
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', I.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	--set @cWhere = @cWhere + ' and datediff(day, II.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	set @cWhere = @cWhere + ' and datediff(day, I.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and II.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
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

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount,  
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto,  
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			InputID, OperationsCount, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0 
		from #InputsAcceptDataSum

--------------------------------------------------------------------------------
-- 'TRAFFICSFRAMESHI', 'TRAFFICSFRAMESLO'
-- Перемещения контейнеров
select  U.BrigadeID, 
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
	from Cells C 
	inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
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
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
set @cSelect = @cSelect + @cWhere 
exec (@cSelect)
-- Количество спусков вычисляем обратным счетом,
-- чтобы не платить дважды за операции перемещения внутри высотки
select UserID, BrigadeID, DateConfirm, 
		count(TrafficID) as OperationsCount, 
		sum(MovesUp)   as MovesUp, 
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
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			OperationsCount, MovesUp, MovesDown, 0, 
			Null, 0, 0, 0, 
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
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
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
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, OperationsCount, 
			Null, 0, 0, 0, 
			Null, 0, 0, 0 
		from #TrafficsFramesFloorDataSum 

--------------------------------------------------------------------------------
-- 'OUTPUTSPICKING'
-- Коробочный пикинг
select  U.BrigadeID, 
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
	select  U.BrigadeID, T.UserID, T.OutputID, 
			convert(datetime, convert(varchar, T.DateConfirm, 112)), 
			T.PackingID, P.InBox, P.BoxInPal, G.Weighting, G.Netto, 
			T.QntConfirmed, T.ID 
	from TrafficsGoods T with (nolock) 
	inner join Outputs O with (nolock) on T.OutputID = O.ID 
	inner join Partners Own with (nolock) on O.OwnerID = Own.ID 
	inner join _Users U with (nolock) on T.UserID = U.ID 
	inner join Packings P with (nolock) on T.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID '
set @cWhere = ' where T.DateConfirm is not Null and T.QntConfirmed > 0 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', O.DatePick) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(day, O.DatePick, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
if @cOutputsTypesList is not Null
	set @cWhere = @cWhere + ' and O.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select  OutputID, DateConfirm,   
		BrigadeID, UserID, 
		count(distinct OutputID) as OutputsCount, 
		sum(case when Weighting = 1 then cast(0.0 as dec(15,3)) else Qnt / InBox end) as BoxesCount, 
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
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			OutputID, LinesCount, BoxesCount, Netto, 
			Null, 0, 0, 0 
		from #OutputsTrafficsGoodsDataSum 

--------------------------------------------------------------------------------
-- 'OUTPUTSLOAD'
-- загрузка в машины
select  U.BrigadeID,  
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

set @cSelect = 
'insert #OutputsLoadData (BrigadeID, UserID, OutputID, DateConfirm, LinesCount, BoxesCount, Netto) 
	select  U.BrigadeID, OL.UserID, X.OutputID, 
			convert(datetime, convert(varchar, X.DateConfirm, 112)), 
			cast(X.LinesCount as dec(8,1)) as LinesCount, X.BoxesCount, X.Netto 
		from (select O.OutputTypeID, O.DateConfirm, OG.OutputID, 
						count(distinct PackingID) as LinesCount, 
						sum(case when G.Weighting = 1 then cast(0.0 as dec(15,3)) else OG.QntConfirmed / P.InBox end) as BoxesCount, 
						sum(case when G.Weighting = 0 then cast(0.0 as dec(15,3)) else OG.QntConfirmed * G.Netto end) as Netto 
					from Outputs O with (nolock) 
					inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
					inner join Packings P with (nolock) on OG.PackingID = P.ID 
					inner join Goods G with (nolock) on P.GoodID = G.ID 
					where O.DateConfirm is not Null and OG.QntConfirmed > 0 
					group by O.OutputTypeID, O.DateConfirm, OG.OutputID) X 
		inner join Outputs OO with (nolock) on X.OutputID = OO.ID 
		inner join Partners Own with (nolock) on OO.OwnerID = Own.ID 
		left join OutputsLoaders OL with (nolock) on OL.OutputID = X.OutputID 
		left join _Users U with (nolock) on OL.UserID = U.ID '
set @cWhere = ' where 1 = 1 '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', X.DateConfirm) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(day, X.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
if @cUsersList is not Null
	set @cWhere = @cWhere + ' and OL.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
if @cOutputsTypesList is not Null
	set @cWhere = @cWhere + ' and X.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '
if @cOwnersList is not Null
	set @cWhere = @cWhere + ' and Own.ID in (' + dbo._NormalizeList(@cOwnersList) + ') '
set @cSelect = @cSelect + @cWhere
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

insert #Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown, MovesFloorCount,  
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto,  
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
	select BrigadeID, UserID, DateConfirm, 
			Null, 0, 0, 0, 0, 
			Null, 0, 
			0, 0, 0, 0, 
			Null, 0, 0, 0, 
			OutputID, LinesCount, BoxesCount, Netto
		from #OutputsLoadDataSum 

------- ИТОГО -------------
/*
#Data (BrigadeID, UserID, DateConfirm, 
		InputID, InputsItemsCount, InputsBoxesCount, InputsNetto, InputsItemsRelativeCount, 
		AccInputID, AccInputsOperationsCount, 
		MovesOperationsCount, MovesUp, MovesDown,  
		PickOutputID, PickOutputsLinesCount, PickOutputsBoxesCount, PickOutputsNetto,  
		OutputID, OutputsLinesCount, OutputsBoxesCount, OutputsNetto)
*/

if @cDetailMode = 'DETAIL' begin 
	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, 
				X.DateConfirm, 
				isNull(I.ERPCode, isNull(IAcc.ERPCode, isNull(OPick.ERPCode, O.ERPCode))) as ERPCode, 
				isNull(PInp.Name, isNull(PInpAcc.Name, isNull(POutPick.Name, POut.Name))) as PartnerName, 
				Null as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select DateConfirm, 
						cast(0 as int) as UserID, 
						BrigadeID, 
						InputID, 
						count(distinct InputID) as InputsCount, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsBoxesCount) as InputsBoxesCount, 
						sum(InputsNetto) as InputsNetto, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount, 
						AccInputID, 						
						count(distinct AccInputID) as AccInputsCount, 
						sum(AccInputsOperationsCount) as AccInputsOperationsCount, 
						sum(MovesOperationsCount) as MovesOperationsCount, 
						sum(MovesUp) as MovesUp, 
						sum(MovesDown) as MovesDown,  
						sum(MovesFloorCount) as MovesFloorCount, 
						PickOutputID, 
						count(distinct PickOutputID) as PickOutputsCount, 
						sum(PickOutputsLinesCount) as PickOutputsLinesCount, 
						sum(PickOutputsBoxesCount) as PickOutputsBoxesCount, 
						sum(PickOutputsNetto) as PickOutputsNetto,  
						OutputID, 
						count(distinct OutputID) as OutputsCount, 
						sum(OutputsLinesCount) as OutputsLinesCount, 
						sum(OutputsBoxesCount) as OutputsBoxesCount, 
						sum(OutputsNetto) as OutputsNetto
					from #Data
					group by BrigadeID, DateConfirm, InputID, AccInputID, PickOutputID, OutputID) X
				left join Inputs I with (nolock) on X.InputID = I.ID 
				left join Inputs IAcc with (nolock) on X.AccInputID = IAcc.ID 
				left join Outputs OPick with (nolock) on X.PickOutputID = OPick.ID 
				left join Outputs O with (nolock) on X.OutputID = O.ID 
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				left join Partners PInp with (nolock) on I.PartnerID = PInp.ID
				left join Partners PInpAcc with (nolock) on IAcc.PartnerID = PInpAcc.ID
				left join Partners POutPick with (nolock) on OPick.PartnerID = POutPick.ID
				left join Partners POut with (nolock) on O.PartnerID = POut.ID
				order by X.DateConfirm, B.Name, I.ERPCode, IAcc.ERPCode, OPick.ERPCode, O.ERPCode
	end 
	else begin
		-- по сотрудникам
		select X.*, 
				isNull(I.ERPCode, isNull(IAcc.ERPCode, isNull(OPick.ERPCode, O.ERPCode))) as ERPCode, 
				isNull(PInp.Name, isNull(PInpAcc.Name, isNull(POutPick.Name, POut.Name))) as PartnerName, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select DateConfirm, 
						UserID, 
						BrigadeID, 
						InputID, 
						count(distinct InputID) as InputsCount, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsBoxesCount) as InputsBoxesCount, 
						sum(InputsNetto) as InputsNetto, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount, 
						AccInputID, 
						count(distinct AccInputID) as AccInputsCount, 
						sum(AccInputsOperationsCount) as AccInputsOperationsCount, 
						sum(MovesOperationsCount) as MovesOperationsCount, 
						sum(MovesUp) as MovesUp, 
						sum(MovesDown) as MovesDown,  
						sum(MovesFloorCount) as MovesFloorCount, 
						PickOutputID,  
						count(distinct PickOutputID) as PickOutputsCount, 
						sum(PickOutputsLinesCount) as PickOutputsLinesCount, 
						sum(PickOutputsBoxesCount) as PickOutputsBoxesCount, 
						sum(PickOutputsNetto) as PickOutputsNetto,  
						OutputID, 
						count(distinct OutputID) as OutputsCount, 
						sum(OutputsLinesCount) as OutputsLinesCount, 
						sum(OutputsBoxesCount) as OutputsBoxesCount, 
						sum(OutputsNetto) as OutputsNetto
					from #Data
					group by BrigadeID, UserID, DateConfirm, InputID, AccInputID, PickOutputID, OutputID) X 
			left join Inputs I with (nolock) on X.InputID = I.ID 
			left join Inputs IAcc with (nolock) on X.AccInputID = I.ID 
			left join Outputs OPick with (nolock) on X.PickOutputID = OPick.ID 
			left join Outputs O with (nolock) on X.OutputID = O.ID 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			left join Partners PInp with (nolock) on I.PartnerID = PInp.ID
			left join Partners PInpAcc with (nolock) on IAcc.PartnerID = PInpAcc.ID
			left join Partners POutPick with (nolock) on OPick.PartnerID = POutPick.ID
			left join Partners POut with (nolock) on O.PartnerID = POut.ID
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
			from (select DateConfirm,  
						cast(0 as int) as UserID, 
						BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsBoxesCount) as InputsBoxesCount, 
						sum(InputsNetto) as InputsNetto, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount, 
						count(distinct AccInputID) as AccInputsCount, 
						sum(AccInputsOperationsCount) as AccInputsOperationsCount, 
						sum(MovesOperationsCount) as MovesOperationsCount, 
						sum(MovesUp) as MovesUp, 
						sum(MovesDown) as MovesDown,  
						sum(MovesFloorCount) as MovesFloorCount, 
						count(distinct PickOutputID) as PickOutputsCount, 
						sum(PickOutputsLinesCount) as PickOutputsLinesCount, 
						sum(PickOutputsBoxesCount) as PickOutputsBoxesCount, 
						sum(PickOutputsNetto) as PickOutputsNetto,  
						count(distinct OutputID) as OutputsCount, 
						sum(OutputsLinesCount) as OutputsLinesCount, 
						sum(OutputsBoxesCount) as OutputsBoxesCount, 
						sum(OutputsNetto) as OutputsNetto
					from #Data
					group by DateConfirm, BrigadeID) X
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
			from (select DateConfirm, 
						UserID, 
						BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsBoxesCount) as InputsBoxesCount, 
						sum(InputsNetto) as InputsNetto, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount, 
						count(distinct AccInputID) as AccInputsCount, 
						sum(AccInputsOperationsCount) as AccInputsOperationsCount, 
						sum(MovesOperationsCount) as MovesOperationsCount, 
						sum(MovesUp) as MovesUp, 
						sum(MovesDown) as MovesDown,  
						sum(MovesFloorCount) as MovesFloorCount, 
						count(distinct PickOutputID) as PickOutputsCount, 
						sum(PickOutputsLinesCount) as PickOutputsLinesCount, 
						sum(PickOutputsBoxesCount) as PickOutputsBoxesCount, 
						sum(PickOutputsNetto) as PickOutputsNetto,  
						count(distinct OutputID) as OutputsCount, 
						sum(OutputsLinesCount) as OutputsLinesCount, 
						sum(OutputsBoxesCount) as OutputsBoxesCount, 
						sum(OutputsNetto) as OutputsNetto
					from #Data
					group by DateConfirm, UserID, BrigadeID) X 
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
						BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsBoxesCount) as InputsBoxesCount, 
						sum(InputsNetto) as InputsNetto, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount, 
						count(distinct AccInputID) as AccInputsCount, 
						sum(AccInputsOperationsCount) as AccInputsOperationsCount, 
						sum(MovesOperationsCount) as MovesOperationsCount, 
						sum(MovesUp) as MovesUp, 
						sum(MovesDown) as MovesDown,  
						sum(MovesFloorCount) as MovesFloorCount, 
						count(distinct PickOutputID) as PickOutputsCount, 
						sum(PickOutputsLinesCount) as PickOutputsLinesCount, 
						sum(PickOutputsBoxesCount) as PickOutputsBoxesCount, 
						sum(PickOutputsNetto) as PickOutputsNetto,  
						count(distinct OutputID) as OutputsCount, 
						sum(OutputsLinesCount) as OutputsLinesCount, 
						sum(OutputsBoxesCount) as OutputsBoxesCount, 
						sum(OutputsNetto) as OutputsNetto
					from #Data
					group by BrigadeID) X
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
			from (select  UserID, 
						BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsBoxesCount) as InputsBoxesCount, 
						sum(InputsNetto) as InputsNetto, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount, 
						count(distinct AccInputID) as AccInputsCount, 
						sum(AccInputsOperationsCount) as AccInputsOperationsCount, 
						sum(MovesOperationsCount) as MovesOperationsCount, 
						sum(MovesUp) as MovesUp, 
						sum(MovesDown) as MovesDown,  
						sum(MovesFloorCount) as MovesFloorCount, 
						count(distinct PickOutputID) as PickOutputsCount, 
						sum(PickOutputsLinesCount) as PickOutputsLinesCount, 
						sum(PickOutputsBoxesCount) as PickOutputsBoxesCount, 
						sum(PickOutputsNetto) as PickOutputsNetto,  
						count(distinct OutputID) as OutputsCount, 
						sum(OutputsLinesCount) as OutputsLinesCount, 
						sum(OutputsBoxesCount) as OutputsBoxesCount, 
						sum(OutputsNetto) as OutputsNetto
					from #Data
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end 
end 
return