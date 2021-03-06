USE [WMS]
GO
/****** Object:  StoredProcedure [dbo].[up_ReportForSalary]    Script Date: 09/18/2008 11:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_ReportForSalary]
	@cMode				varchar(50),	
						-- InputsUnload / InputsAccept / TrafficsFramesHi / TrafficsFramesLo / OutputPicking / OutputsLoad
	@dDateBeg			smalldatetime	= Null, 
	@dDateEnd			smalldatetime	= Null, 
	@bGroupBy			bit, 
	@cUsersList			varchar(max)	= Null, 
	@cInputsTypesList	varchar(max)	= Null,
	@cOutputsTypesList	varchar(max)	= Null
AS
-- up_ReportForSalary 'InputsUnload', '20080716', '20080813', 1, null, null, null
-- up_ReportForSalary 'InputsAccept', '20080901', '20080907', 1, null, null, null
-- up_ReportForSalary 'TrafficsFramesHi', '20080716', '20080813', 0, null, null, null
-- up_ReportForSalary 'TrafficsFramesLo', '20080716', '20080813', 0, null, null, null
-- up_ReportForSalary 'OutputsPicking', '20080716', '20080813', 0, null, null, null
-- up_ReportForSalary 'OutputsLoad', '20080801', '20080802', 0, null, null, null

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max)

if upper(@cMode) = 'INPUTSUNLOAD' begin
	-- Разгрузка машины
	select  U.BrigadeID,  
			II.UserID, 
			II.InputID, 
			cast(0 as dec(15,1)) as BoxesCount, 
			cast(0 as dec(15,0)) as Netto, 
			cast(0 as dec(5,1)) as InputsItemsCount, 
			cast(0 as dec(5,1)) as CoefficientUnload 
		into #InputsUnloadData 
		from InputsItems II with (nolock)
		inner join _Users U with (nolock) on II.UserID = U.ID
		where 1 = 2 
	
	set @cSelect = 
	'insert #InputsUnloadData (BrigadeID, UserID, InputID, 
			BoxesCount, Netto, InputsItemsCount, CoefficientUnload) 
		select  U.BrigadeID, IU.UserID, IU.InputID, 
		X.BoxesCount, X.Netto, X.InputsItemsCount, I.CoefficientUnload 
		from InputsUnloaders IU with (nolock) 
		inner join Inputs I with (nolock) on IU.InputID = I.ID 
		inner join _Users U with (nolock) on IU.UserID = U.ID 
		inner join (select II.InputID, 
			sum(II.Qnt / P.InBox) as BoxesCount, 
			sum(II.Qnt * G.Netto) as Netto, 
			count(*) as InputsItemsCount 
			from InputsItems II with (nolock) 
			inner join Packings P with (nolock) on II.PackingID = P.ID 
			inner join Goods G with (nolock) on P.GoodID = G.ID 
			group by InputID) X on IU.InputID = X.InputID '
	
	set @cWhere = ' where 1 = 1 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', I.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, I.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and IU.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
	if @cInputsTypesList is not Null
		set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '
	
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
	
	-- Раскидываем приходы по количеству людей
	select T.BrigadeID, T.UserID, T.InputID, 
		sum(BoxesCount) as BoxesCount, 
		sum(Netto) as Netto, 
		sum(T.InputsItemsCount / X.InputsCount) as InputsItemsCount, 
		sum(T.InputsItemsCount * T.CoefficientUnload / X.InputsCount) as InputsItemsRelativeCount 
		into #InputsUnloadDataSum 
		from #InputsUnloadData T 
		inner join (select InputID, count(*) as InputsCount 
			from #InputsUnloadData group by InputID) X on X.InputID = T.InputID 
		group by T.BrigadeID, T.UserID, T.InputID
	
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, Null as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(BoxesCount) as BoxesCount, 
						sum(Netto) as Netto, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount 
					from #InputsUnloadDataSum 
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, U.Name as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select  UserID, BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(BoxesCount) as BoxesCount, 
						sum(Netto) as Netto, 
						sum(InputsItemsCount) as InputsItemsCount, 
						sum(InputsItemsRelativeCount) as InputsItemsRelativeCount 
					from #InputsUnloadDataSum 
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end
end

if upper(@cMode) = 'INPUTSACCEPT' begin
	-- Непосредственно приемка
	select  U.BrigadeID,  
			II.UserID, 
			II.InputID, 
			II.ID * 1 as InputItemID 
		into #InputsAcceptData
		from InputsItems II with (nolock)
		inner join _Users U with (nolock) on II.UserID = U.ID
		where 1 = 2 
	
	set @cSelect = 
	'insert #InputsAcceptData (BrigadeID, UserID, InputID, InputItemID) 
		select  U.BrigadeID, II.UserID, II.InputID, II.ID 
		from InputsItems II with (nolock)
		inner join Inputs I with (nolock) on II.InputID = I.ID 
		inner join _Users U with (nolock) on II.UserID = U.ID '
	
	set @cWhere = ' where 1 = 1 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', I.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, I.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and II.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
	if @cInputsTypesList is not Null
		set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '
	
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
	
	select UserID, BrigadeID, InputID, 
			count(InputItemID) as OperationsCount 
		into #InputsAcceptDataSum 
		from #InputsAcceptData 
		group by BrigadeID, UserID, InputID
	
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, Null as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(OperationsCount) as OperationsCount 
					from #InputsAcceptDataSum 
					group by BrigadeID) X 
				left join Brigades B with (nolock) on X.BrigadeID = B.ID 
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, U.Name as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select  UserID, BrigadeID, 
						count(distinct InputID) as InputsCount, 
						sum(OperationsCount) as OperationsCount 
					from #InputsAcceptDataSum 
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID 
			left join Brigades B with (nolock) on X.BrigadeID = B.ID 
			order by B.Name, U.Name
	end
end

if upper(@cMode) in ('TRAFFICSFRAMESHI', 'TRAFFICSFRAMESLO') begin
	-- Перемещения контейнеров
	select  U.BrigadeID, 
			T.UserID, 
			T.ID * 1 as TrafficID, 
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
	'insert #TrafficsFramesData (BrigadeID, UserID, TrafficID, MovesUp) 
		select U.BrigadeID, T.UserID, T.ID, 
			case when T.CellTargetID in (select CellID from #CellsHi) then 1 else 0 end as MovesUp 
			from TrafficsFrames T with (nolock)
			left join _Users U with (nolock) on T.UserID = U.ID '
	
	set @cWhere = ' where T.DateConfirm is not Null and T.Success = 1 and T.ErrorID is Null '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
	
	if upper(@cMode) = 'TRAFFICSFRAMESHI'
		set @cWhere = @cWhere + ' and   (T.CellSourceID in (select CellID from #CellsHi) or ' + 
										'T.CellTargetID in (select CellID from #CellsHi))'
	else
		set @cWhere = @cWhere + ' and   (T.CellSourceID not in (select CellID from #CellsHi) and ' + 
										'T.CellTargetID not in (select CellID from #CellsHi))'
	
	set @cSelect = @cSelect + @cWhere
	exec (@cSelect)
	
	-- Количество спусков вычисляем обратным счетом,
	-- чтобы не платить дважды за операции перемещния внутри высотки
	select UserID, BrigadeID, 
			count(TrafficID) as OperationsCount, 
			sum(MovesUp)   as MovesUp, 
			cast(0 as int) as MovesDown 
		into #TrafficsFramesDataSum 
		from #TrafficsFramesData 
		group by UserID, BrigadeID
	update #TrafficsFramesDataSum set MovesDown = OperationsCount - MovesUp
	
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, Null as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, BrigadeID, 
						sum(OperationsCount) as OperationsCount, 
						sum(MovesUp)   as MovesUp, 
						sum(MovesDown) as MovesDown 
					from #TrafficsFramesDataSum 
					group by BrigadeID) X 
				left join Brigades B with (nolock) on X.BrigadeID = B.ID 
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, 
				U.Name as UserName, 
				IsNull(B.Name, '') as BrigadeName 
			from (select UserID, BrigadeID, 
						sum(OperationsCount) as OperationsCount, 
						sum(MovesUp)   as MovesUp, 
						sum(MovesDown) as MovesDown 
					from #TrafficsFramesDataSum 
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID 
			left join Brigades B with (nolock) on X.BrigadeID = B.ID 
			order by B.Name, U.Name
	end
end

if upper(@cMode) = 'OUTPUTSPICKING' begin
	-- Коробочный пикинг
	select  U.BrigadeID, 
			T.UserID, 
			T.OutputID, 
			T.PackingID, P.InBox, P.BoxInPal, G.Netto, 
			T.QntConfirmed as Qnt, 
			T.ID * 1 as TrafficID 
		into #OutputsTrafficsGoodsData
		from TrafficsGoods T with (nolock)
		inner join _Users U with (nolock) on T.UserID = U.ID
		inner join Packings P with (nolock) on T.PackingID = P.ID
		inner join Goods G with (nolock) on P.GoodID = G.ID
		where 1 = 2 

	set @cSelect = 
	'insert #OutputsTrafficsGoodsData (BrigadeID, UserID, OutputID, 
			PackingID, InBox, BoxInPal, Netto, Qnt, TrafficID) 
		select  U.BrigadeID, T.UserID, T.OutputID, 
				T.PackingID, P.InBox, P.BoxInPal, G.Netto, 
				T.QntConfirmed, T.ID 
		from TrafficsGoods T with (nolock) 
		inner join Outputs O with (nolock) on T.OutputID = O.ID 
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

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	select BrigadeID, UserID, 
			count(distinct OutputID) as OutputsCount, 
			sum(Qnt / InBox) as BoxesCount, 
			sum(Qnt * Netto) as Netto, 
			count(TrafficID) as LinesCount 
		into #OutputsTrafficsGoodsDataSum 
		from #OutputsTrafficsGoodsData 
		group by BrigadeID, UserID

	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, Null as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, BrigadeID, 
						sum(OutputsCount) as OutputsCount, 
						sum(LinesCount) as LinesCount, 
						sum(BoxesCount) as BoxesCount, 
						sum(Netto) as Netto 
					from #OutputsTrafficsGoodsDataSum 
					group by BrigadeID) X 
				left join Brigades B with (nolock) on X.BrigadeID = B.ID 
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, U.Name as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select  UserID, BrigadeID, 
						sum(OutputsCount) as OutputsCount, 
						sum(LinesCount) as LinesCount, 
						sum(BoxesCount) as BoxesCount, 
						sum(Netto) as Netto 
					from #OutputsTrafficsGoodsDataSum 
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID 
			left join Brigades B with (nolock) on X.BrigadeID = B.ID 
			order by B.Name, U.Name
	end
end

if upper(@cMode) = 'OUTPUTSLOAD' begin 
	-- загрузка в машины
	select  U.BrigadeID,  
			OI.UserID, 
			OI.OutputID, 
			cast(0 as dec(15,1)) as BoxesCount, 
			cast(0 as dec(5,1)) as LinesCount, 
			cast(0 as dec(15,0)) as Netto 
		into #OutputsLoadData 
		from OutputsItems OI with (nolock)
		inner join _Users U with (nolock) on OI.UserID = U.ID
		where 1 = 2 
	
	set @cSelect = 
	'insert #OutputsLoadData (BrigadeID, UserID, OutputID, BoxesCount, LinesCount, Netto) 
		select  U.BrigadeID, OL.UserID, X.OutputID, 
			X.BoxesCount, cast(X.LinesCount as dec(8,1)) as LinesCount, X.Netto 
		from (select O.OutputTypeID, O.DateConfirm, OG.OutputID, 
						sum(OG.QntConfirmed / P.InBox) as BoxesCount, 
						count(distinct PackingID) as LinesCount, 
						sum(OG.QntConfirmed * G.Netto) as Netto 
					from Outputs O with (nolock) 
					inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
					inner join Packings P with (nolock) on OG.PackingID = P.ID 
					inner join Goods G with (nolock) on P.GoodID = G.ID 
					where O.DateConfirm is not Null and OG.QntConfirmed > 0 
					group by O.OutputTypeID, O.DateConfirm, OG.OutputID) X 
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
	
	set @cSelect = @cSelect + @cWhere
	exec (@cSelect)
	
	-- Раскидываем расходы по количеству людей
	select T.BrigadeID, T.UserID, T.OutputID, 
		sum(T.BoxesCount / X.OutputsCount) as BoxesCount, 
		sum(T.LinesCount / X.OutputsCount) as LinesCount, 
		sum(T.Netto / X.OutputsCount) as Netto 
		into #OutputsLoadDataSum 
		from #OutputsLoadData T 
		inner join (select OutputID, count(*) as OutputsCount 
			from #OutputsLoadData group by OutputID) X on X.OutputID = T.OutputID 
		group by T.BrigadeID, T.UserID, T.OutputID
	
	if @bGroupBy = 1 begin
		-- по бригадам
		select X.*, Null as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, BrigadeID, 
						count(distinct OutputID) as OutputsCount, 
						sum(BoxesCount) as BoxesCount, 
						sum(LinesCount) as LinesCount, 
						sum(Netto) as Netto  
					from #OutputsLoadDataSum 
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end
	else begin
		-- по сотрудникам
		select X.*, U.Name as UserName, IsNull(B.Name, '') as BrigadeName 
			from (select  UserID, BrigadeID, 
						count(distinct OutputID) as OutputsCount, 
						sum(BoxesCount) as BoxesCount, 
						sum(LinesCount) as LinesCount, 
						sum(Netto) as Netto  
					from #OutputsLoadDataSum 
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end
end 
return