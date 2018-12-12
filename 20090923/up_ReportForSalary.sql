set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_ReportForSalary]
	@cMode				varchar(50),	
						-- InputsUnload / InputsAccept / TrafficsFramesHi / TrafficsFramesLo / OutputPicking / OutputsLoad / TOTAL
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
exec up_ReportForSalary 'InputsUnload', '20080801', '20080810', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'InputsAccept', '20080801', '20080810', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'TrafficsFramesHi', '20080716', '20080813', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'TrafficsFramesLo', '20080716', '20080813', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'OutputsPicking', '20080716', '20080813', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'OutputsLoad', '20080716', '20080813', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'TOTAL', '20080801', '20080810', 'DETAIL', 0, null, null, null, null
exec up_ReportForSalary 'TOTAL', '20080801', '20080810', 'DATE', 0, null, null, null, null
exec up_ReportForSalary 'TOTAL', '20080801', '20080810', 'TOTAL', 0, null, null, null, null
*/

set nocount on

set dateformat ymd
if IsNull(@cDetailMode, '') = '' set @cDetailMode = 'TOTAL'

declare @cSelect varchar(max), @cWhere varchar(max)

if upper(@cMode) = 'INPUTSUNLOAD' begin
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
	
	if @cDetailMode = 'DETAIL' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					X.DateConfirm, 
					I.ERPCode, 
					P.Name as PartnerName, 
					'' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select InputID, 
							DateConfirm, 
							cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto, 
							sum(InputsItemsCount) as InputsItemsCount, 
							sum(InputsItemsRelativeCount) as InputsItemsRelativeCount 
						from #InputsUnloadDataSum 
						group by InputID, DateConfirm, BrigadeID) X
					inner join Inputs I with (nolock) on X.InputID = I.ID 
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					left join Partners P with (nolock) on I.PartnerID = P.ID
					order by X.DateConfirm, P.Name, I.ERPCode, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm, 
					I.ERPCode, 
					P.Name as PartnerName, 
					'' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select InputID,   
							DateConfirm, 
							UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto, 
							sum(InputsItemsCount) as InputsItemsCount, 
							sum(InputsItemsRelativeCount) as InputsItemsRelativeCount 
						from #InputsUnloadDataSum 
						group by InputID, DateConfirm, UserID, BrigadeID) X 
				inner join Inputs I with (nolock) on X.InputID = I.ID 
				left join _Users U with (nolock) on X.UserID = U.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				left join Partners P with (nolock) on I.PartnerID = P.ID
				order by X.DateConfirm, P.Name, I.ERPCode, B.Name, U.Name
		end 
	end 
	
	if @cDetailMode = 'DATE' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*,
					X.DateConfirm,  
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm,  
							cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto, 
							sum(InputsItemsCount) as InputsItemsCount, 
							sum(InputsItemsRelativeCount) as InputsItemsRelativeCount 
						from #InputsUnloadDataSum 
						group by DateConfirm, BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by X.DateConfirm, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm,  
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm, 
							UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto, 
							sum(InputsItemsCount) as InputsItemsCount, 
							sum(InputsItemsRelativeCount) as InputsItemsRelativeCount 
						from #InputsUnloadDataSum 
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
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select cast(0 as int) as UserID, 
							BrigadeID, 
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
			select X.*, 
					Null as DateConfirm,  
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select  UserID, 
							BrigadeID, 
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
end

--------------------------------------------------------------------------------
if upper(@cMode) = 'INPUTSACCEPT' begin
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
	
	if @cDetailMode = 'DETAIL' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					X.DateConfirm, 
					I.ERPCode, 
					P.Name as PartnerName, 
					'' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select InputID, 
							DateConfirm, 
							cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(OperationsCount) as OperationsCount 
							-- есть еще BoxesCount, Netto
						from #InputsAcceptDataSum
						group by InputID, DateConfirm, BrigadeID) X
					inner join Inputs I with (nolock) on X.InputID = I.ID 
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					left join Partners P with (nolock) on I.PartnerID = P.ID
					order by X.DateConfirm, P.Name, I.ERPCode, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm, 
					I.ERPCode, 
					P.Name as PartnerName, 
					'' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select InputID,   
							DateConfirm, 
							UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(OperationsCount) as OperationsCount 
						from #InputsAcceptDataSum
						group by InputID, DateConfirm, UserID, BrigadeID) X 
				inner join Inputs I with (nolock) on X.InputID = I.ID 
				left join _Users U with (nolock) on X.UserID = U.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				left join Partners P with (nolock) on I.PartnerID = P.ID
				order by X.DateConfirm, P.Name, I.ERPCode, B.Name, U.Name
		end 
	end 
	
	if @cDetailMode = 'DATE' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*,
					X.DateConfirm,  
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm,  
							cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(OperationsCount) as OperationsCount 
						from #InputsAcceptDataSum
						group by DateConfirm, BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by X.DateConfirm, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm,  
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm,   
							UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(OperationsCount) as OperationsCount 
						from #InputsAcceptDataSum 
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
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(OperationsCount) as OperationsCount 
						from #InputsAcceptDataSum
						group by BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					Null as DateConfirm,  
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select  UserID, 
							BrigadeID, 
							count(distinct InputID) as InputsCount, 
							sum(OperationsCount) as OperationsCount 
						from #InputsAcceptDataSum
						group by UserID, BrigadeID) X 
				left join _Users U with (nolock) on X.UserID = U.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name, U.Name
		end 
	end 
end

--------------------------------------------------------------------------------
if upper(@cMode) in ('TRAFFICSFRAMESHI', 'TRAFFICSFRAMESLO') begin
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
	-- чтобы не платить дважды за операции перемещения внутри высотки
	select UserID, BrigadeID, DateConfirm, 
			count(TrafficID) as OperationsCount, 
			sum(MovesUp)   as MovesUp, 
			cast(0 as int) as MovesDown 
		into #TrafficsFramesDataSum 
		from #TrafficsFramesData 
		group by UserID, BrigadeID, DateConfirm
	update #TrafficsFramesDataSum set MovesDown = OperationsCount - MovesUp
	
	if @cDetailMode = 'DETAIL' or @cDetailMode = 'DATE' begin
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm, 
							cast(0 as int) as UserID, 
							BrigadeID, 
							sum(OperationsCount) as OperationsCount, 
							sum(MovesUp)   as MovesUp, 
							sum(MovesDown) as MovesDown 
						from #TrafficsFramesDataSum
						group by DateConfirm, BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by X.DateConfirm, B.Name
		end		
		else begin
			-- по сотрудникам
			select X.*, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm, 
							UserID, 
							BrigadeID, 
							sum(OperationsCount) as OperationsCount, 
							sum(MovesUp)   as MovesUp, 
							sum(MovesDown) as MovesDown 
						from #TrafficsFramesDataSum
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
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select cast(0 as int) as UserID, 
							BrigadeID, 
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
					Null as DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select UserID, 
							BrigadeID, 
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
end

--------------------------------------------------------------------------------
if upper(@cMode) = 'OUTPUTSPICKING' begin
	-- Коробочный пикинг
	select  U.BrigadeID, 
			T.UserID, 
			T.OutputID, 
			T.DateConfirm, -- O.DatePick ???
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
	
	if @cDetailMode = 'DETAIL' begin
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					X.DateConfirm, 
					O.ERPCode, 
					IsNull(P.Name, '') as PartnerName, 
					IsNull(O.CarAlias, '') as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select  OutputID, 
							DateConfirm, 
							cast(0 as int) as UserID, 
							BrigadeID, 
							sum(OutputsCount) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto 
						from #OutputsTrafficsGoodsDataSum
						group by OutputID, DateConfirm, BrigadeID) X
					inner join Outputs O with (nolock) on X.OutputID = O.ID 
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					left join Partners P with (nolock) on O.PartnerID = P.ID
					order by X.DateConfirm, P.Name, O.ERPCode, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm, 
					O.ERPCode, 
					IsNull(P.Name, '') as PartnerName, 
					IsNull(O.CarAlias, '') as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select OutputID, 
							DateConfirm,   
							UserID, 
							BrigadeID, 
							sum(OutputsCount) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto 
						from #OutputsTrafficsGoodsDataSum
						group by OutputID, DateConfirm, UserID, BrigadeID) X 
				inner join Outputs O with (nolock) on X.OutputID = O.ID 
				left join _Users U with (nolock) on X.UserID = U.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				left join Partners P with (nolock) on O.PartnerID = P.ID
				order by X.DateConfirm, P.Name, O.ERPCode, B.Name, U.Name
		end 
	end 
	
	if @cDetailMode = 'DATE' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					X.DateConfirm as DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select  DateConfirm, 
							cast(0 as int) as UserID, 
							BrigadeID, 
							sum(OutputsCount) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto 
						from #OutputsTrafficsGoodsDataSum
						group by DateConfirm, BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by X.DateConfirm, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm as DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm,   
							UserID, 
							BrigadeID, 
							sum(OutputsCount) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto 
						from #OutputsTrafficsGoodsDataSum
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
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select cast(0 as int) as UserID, 
							BrigadeID, 
							sum(1) as Lines, 
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
			select X.*, 
					Null as DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select  UserID, 
							BrigadeID, 
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
end

--------------------------------------------------------------------------------
if upper(@cMode) = 'OUTPUTSLOAD' begin
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
		sum(T.LinesCount / X.OutputsCount) as LinesCount, 
		sum(T.BoxesCount / X.OutputsCount) as BoxesCount, 
		sum(T.Netto / X.OutputsCount) as Netto 
		into #OutputsLoadDataSum 
		from #OutputsLoadData T 
		inner join (select OutputID, count(*) as OutputsCount 
						from #OutputsLoadData 
						group by OutputID) X on X.OutputID = T.OutputID 
		group by T.BrigadeID, T.UserID, T.OutputID, T.DateConfirm
	
	if @cDetailMode = 'DETAIL' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					X.DateConfirm, 
					O.ERPCode, 
					IsNull(P.Name, '') as PartnerName, 
					IsNull(O.CarAlias, '') as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select OutputID, 
							DateConfirm, 
							cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct OutputID) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto  
						from #OutputsLoadDataSum
						group by OutputID, DateConfirm, BrigadeID) X
					inner join Outputs O with (nolock) on X.OutputID = O.ID 
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					left join Partners P with (nolock) on O.PartnerID = P.ID
					order by X.DateConfirm, P.Name, O.ERPCode, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm, 
					O.ERPCode, 
					IsNull(P.Name, '') as PartnerName, 
					IsNull(O.CarAlias, '') as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select OutputID,   
							DateConfirm, 
							UserID, 
							BrigadeID, 
							count(distinct OutputID) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto  
						from #OutputsLoadDataSum
						group by OutputID, DateConfirm, UserID, BrigadeID) X 
				inner join Outputs O with (nolock) on X.OutputID = O.ID 
				left join _Users U with (nolock) on X.UserID = U.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				left join Partners P with (nolock) on O.PartnerID = P.ID
				order by X.DateConfirm, P.Name, O.ERPCode, B.Name, U.Name
		end 
	end 
	
	if @cDetailMode = 'DATE' begin 
		if @bGroupBy = 1 begin 
			-- по бригадам
			select X.*, 
					X.DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm,  
							cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct OutputID) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto  
						from #OutputsLoadDataSum
						group by DateConfirm, BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by X.DateConfirm, B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					X.DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select DateConfirm, 
							UserID, 
							BrigadeID, 
							count(distinct OutputID) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto  
						from #OutputsLoadDataSum
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
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					Null as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select cast(0 as int) as UserID, 
							BrigadeID, 
							count(distinct OutputID) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto  
						from #OutputsLoadDataSum
						group by BrigadeID) X
					left join Brigades B with (nolock) on X.BrigadeID = B.ID
					order by B.Name
		end 
		else begin
			-- по сотрудникам
			select X.*, 
					Null as DateConfirm, 
					'' as ERPCode, '' as PartnerName, '' as CarAlias, 
					U.Name as UserName, 
					IsNull(B.Name, '') as BrigadeName 
				from (select  UserID, 
							BrigadeID, 
							count(distinct OutputID) as OutputsCount, 
							sum(LinesCount) as LinesCount, 
							sum(BoxesCount) as BoxesCount, 
							sum(Netto) as Netto  
						from #OutputsLoadDataSum
						group by UserID, BrigadeID) X 
				left join _Users U with (nolock) on X.UserID = U.ID
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name, U.Name
		end 
	end 
end 

if upper(@cMode) = 'TOTAL' begin
	exec up_ReportForSalaryTotal @dDateBeg, @dDateEnd, 
		@cDetailMode, @bGroupBy, 
		@cUsersList, 
		@cInputsTypesList, @cOutputsTypesList, 
		@cOwnersList	
end
return