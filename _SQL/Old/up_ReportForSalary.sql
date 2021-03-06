USE [WMS]
GO
/****** Object:  StoredProcedure [dbo].[up_ReportForSalary]    Script Date: 09/10/2008 16:57:28 ******/
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
-- up_ReportForSalary 'InputsAccept', '20080716', '20080813', 1, null, null, null
-- up_ReportForSalary 'TrafficsFramesHi', '20080716', '20080813', 0, null, null, null
-- up_ReportForSalary 'TrafficsFramesLo', '20080716', '20080813', 0, null, null, null
-- up_ReportForSalary 'OutputsPicking', '20080716', '20080813', 0, null, null, null
-- up_ReportForSalary 'OutputsLoad', '20080801', '20080802', 0, null, null, null

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max)

if upper(@cMode) = 'INPUTSACCEPT' begin 
	select  II.ID * 1 as InputItemID, 
			II.InputID, 
			II.UserID, 
			U.BrigadeID, 
			II.FrameID,
			II.PackingID, 
			P.InBox, P.BoxInPal, G.Netto, 
			II.Qnt  
		into #InputsData
		from InputsItems II with (nolock)
		inner join _Users U with (nolock) on II.UserID = U.ID
		inner join Packings P with (nolock) on II.PackingID = P.ID
		inner join Goods G with (nolock) on P.GoodID = G.ID
		where 1 = 2 

	set @cSelect = 
	'insert #InputsData (InputItemID, InputID, UserID, BrigadeID, FrameID, 
			PackingID, InBox, BoxInPal, Netto, Qnt) 
		select  II.ID, II.InputID, II.UserID, U.BrigadeID, II.FrameID,
				II.PackingID, 
				P.InBox, P.BoxInPal, G.Netto, 
				II.Qnt  
		from InputsItems II with (nolock)
		inner join Inputs I with (nolock) on II.InputID = I.ID 
		inner join _Users U with (nolock) on II.UserID = U.ID 
		inner join Packings P with (nolock) on II.PackingID = P.ID
		inner join Goods G with (nolock) on P.GoodID = G.ID '

	set @cWhere = ' where 1 = 1 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', II.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, II.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '

	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and II.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	if @cInputsTypesList is not Null
		set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	select InputID, UserID, BrigadeID, PackingID, 
			sum(Qnt) as Qnt, 
			sum(Qnt / InBox) as Boxes, 
			sum(Qnt / InBox / BoxInPal) as CalcPallets, 
			sum(case when FrameID is null then 0 else 1 end) as Pallets, 
			sum(Qnt * Netto) as Netto 
		into #InputsDataSum
		from #InputsData
		group by InputID, UserID, BrigadeID, PackingID

	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, 
				Null as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #InputsDataSum
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end 
	else begin
		-- по сотрудникам
		select X.*, 
				U.Name as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select  UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #InputsDataSum
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end 
end 

if upper(@cMode) = 'TRAFFICSFRAMES' begin 
	select  T.ID * 1 as TrafficID, 
			T.UserID, 
			U.BrigadeID, 
			cast(0 as bit) as Up 
		into #TrafficsFramesData
		from TrafficsFrames T with (nolock)
		inner join _Users U with (nolock) on T.UserID = U.ID
		where 1 = 2 

	-- съем 
	set @cSelect = 
	'insert #TrafficsFramesData (TrafficID, UserID, BrigadeID, Up) 
		select  T.ID, T.UserID, U.BrigadeID, 0
			from TrafficsFrames T with (nolock)
			inner join _Users U with (nolock) on T.UserID = U.ID 
			inner join Cells C with (nolock) on T.CellSourceID = C.ID 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID '
	
	set @cWhere = ' where T.DateConfirm is not Null and T.Success = 1 and T.ErrorID is Null and ' + 
						' SZT.ForStorage = 1 and SZT.ForPicking = 0 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '

	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	-- подъем
	set @cSelect = 
	'insert #TrafficsFramesData (TrafficID, UserID, BrigadeID, Up) 
		select  T.ID, T.UserID, U.BrigadeID, 1
			from TrafficsFrames T with (nolock)
			inner join _Users U with (nolock) on T.UserID = U.ID 
			inner join Cells C with (nolock) on T.CellTargetID = C.ID 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID '

	set @cWhere = ' where T.DateConfirm is not Null and SZT.ForStorage = 1 and SZT.ForPicking = 0 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '

	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	select UserID, BrigadeID, 
			sum(1) as PalletsDown, 
			cast(0 as int) as PalletsUp 
		into #TrafficsFramesDataSum
		from #TrafficsFramesData
		where Up = 0
		group by UserID, BrigadeID

	insert #TrafficsFramesDataSum (UserID, BrigadeID, PalletsDown, PalletsUp)
		select UserID, BrigadeID, 
				0 as PalletsDown, 
				sum(1) as PalletsUp
			from #TrafficsFramesData
			where Up = 1
			group by UserID, BrigadeID

	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, 
				Null as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						BrigadeID, 
						sum(PalletsDown) as PalletsDown, 
						sum(PalletsUp) as PalletsUp
					from #TrafficsFramesDataSum
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end 
	else begin
		-- по сотрудникам
		select X.*, 
				U.Name as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select UserID, 
						BrigadeID, 
						sum(PalletsDown) as PalletsDown, 
						sum(PalletsUp) as PalletsUp
					from #TrafficsFramesDataSum
					group by UserID, BrigadeID) X
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end 
end 

if upper(@cMode) = 'OUTPUTSTRAFFICSGOODS' begin 
	select  T.ID * 1 as TrafficID, 
			T.OutputID, 
			T.UserID, 
			U.BrigadeID, 
			T.PackingID, 
			P.InBox, P.BoxInPal, G.Netto, 
			T.QntConfirmed as Qnt   
		into #OutputsTrafficsGoodsData
		from TrafficsGoods T with (nolock)
		inner join _Users U with (nolock) on T.UserID = U.ID
		inner join Packings P with (nolock) on T.PackingID = P.ID
		inner join Goods G with (nolock) on P.GoodID = G.ID
		where 1 = 2 

	set @cSelect = 
	'insert #OutputsTrafficsGoodsData (TrafficID, OutputID, UserID, BrigadeID, 
			PackingID, InBox, BoxInPal, Netto, Qnt) 
		select  T.ID, T.OutputID, T.UserID, U.BrigadeID, 
				T.PackingID, 
				P.InBox, P.BoxInPal, G.Netto, 
				T.QntConfirmed  
		from TrafficsGoods T with (nolock)
		inner join Outputs O with (nolock) on T.OutputID = O.ID 
		inner join _Users U with (nolock) on T.UserID = U.ID 
		inner join Packings P with (nolock) on T.PackingID = P.ID
		inner join Goods G with (nolock) on P.GoodID = G.ID '

	set @cWhere = ' where T.DateConfirm is not Null and T.QntConfirmed > 0 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '

	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	if @cOutputsTypesList is not Null
		set @cWhere = @cWhere + ' and O.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	select TrafficID, OutputID, UserID, BrigadeID, PackingID, 
			sum(Qnt) as Qnt, 
			sum(Qnt / InBox) as Boxes, 
			sum(Qnt / InBox / BoxInPal) as Pallets, 
			sum(Qnt * Netto) as Netto 
		into #OutputsTrafficsGoodsDataSum
		from #OutputsTrafficsGoodsData
		group by TrafficID, OutputID, UserID, BrigadeID, PackingID

	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, 
				Null as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #OutputsTrafficsGoodsDataSum
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end 
	else begin
		-- по сотрудникам
		select X.*, 
				U.Name as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select  UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #OutputsTrafficsGoodsDataSum
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end 
end 

if upper(@cMode) = 'OUTPUTSTRAFFICSFRAMES' begin 
	select  T.ID * 1 as TrafficID, 
			T.OutputID, 
			T.FrameID, 
			T.UserID, 
			U.BrigadeID, 
			CC.PackingID, 
			P.InBox, P.BoxInPal, G.Netto, 
			CC.Qnt 
		into #OutputsTrafficsFramesData
		from TrafficsFrames T with (nolock)
		inner join _Users U with (nolock) on T.UserID = U.ID
		left  join CellsContents CC with (nolock) on T.FrameID = CC.FrameID 
		left  join Packings P with (nolock) on CC.PackingID = P.ID
		left  join Goods G with (nolock) on P.GoodID = G.ID
		where 1 = 2 

	set @cSelect = 
	'insert #OutputsTrafficsFramesData (TrafficID, OutputID, FrameID, UserID, BrigadeID, 
			PackingID, InBox, BoxInPal, Netto, Qnt) 
		select  T.ID, T.OutputID, T.FrameID, T.UserID, U.BrigadeID, 
				CC.PackingID, 
				0, 0, 0, 
				CC.Qnt
		from TrafficsFrames T with (nolock)
		inner join Outputs O with (nolock) on T.OutputID = O.ID 
		inner join _Users U with (nolock) on T.UserID = U.ID 
		inner join Cells C with (nolock) on T.CellSourceID = C.ID
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID
		left  join CellsContents CC with (nolock) on T.FrameID = CC.FrameID '

	set @cWhere = ' where T.DateConfirm is not Null and T.Success = 1 and ' + 
						' SZT.ForStorage = 1 and SZT.ForPicking = 0 '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '

	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	if @cOutputsTypesList is not Null
		set @cWhere = @cWhere + ' and O.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	-- для уже уехавших контейнеров
	update #OutputsTrafficsFramesData
		set PackingID = OI.PackingID, Qnt = OI.Qnt
		from OutputsItems OI
		where #OutputsTrafficsFramesData.FrameID = OI.FrameID and 
				#OutputsTrafficsFramesData.OutputID = OI.OutputID 

	update #OutputsTrafficsFramesData
		set InBox = P.InBox, BoxInPal = P.BoxInPal, 
			Netto = G.Netto 
		from Packings P with (nolock) 
		inner join Goods G with (nolock) on P.GoodID = G.ID
		where #OutputsTrafficsFramesData.PackingID = P.ID

	select TrafficID, OutputID, UserID, BrigadeID, PackingID, 
			sum(Qnt) as Qnt, 
			sum(Qnt / InBox) as Boxes, 
			sum(Qnt / InBox / BoxInPal) as CalcPallets, 
			sum(1) as Pallets, 
			sum(Qnt * Netto) as Netto 
		into #OutputsTrafficsFramesDataSum
		from #OutputsTrafficsFramesData
		group by TrafficID, OutputID, UserID, BrigadeID, PackingID

	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, 
				Null as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #OutputsTrafficsFramesDataSum
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end 
	else begin
		-- по сотрудникам
		select X.*, 
				U.Name as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select  UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #OutputsTrafficsFramesDataSum
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end 
end 

if upper(@cMode) = 'OUTPUTS' begin 
	-- сейчас: это не сотрудники/бригады загрузки! это сотрудники, подтверждавшие приход!
	select  OG.ID * 1 as OutputGoodID, 
			OG.OutputID, 
			O.ConfirmUserID as UserID, -- д.б. наверное что-то типа OG.UserID
			U.BrigadeID, 
			OG.PackingID, 
			P.InBox, P.BoxInPal, G.Netto, 
			OG.QntConfirmed as Qnt  
		into #OutputsData
		from OutputsGoods OG with (nolock)
		inner join Outputs O with (nolock) on OG.OutputID = O.ID
		inner join _Users U with (nolock) on O.ConfirmUserID = U.ID -- OG.UserID
		inner join Packings P with (nolock) on OG.PackingID = P.ID
		inner join Goods G with (nolock) on P.GoodID = G.ID
		where 1 = 2 

	set @cSelect = 
	'insert #OutputsData (OutputGoodID, OutputID, UserID, BrigadeID, 
			PackingID, InBox, BoxInPal, Netto, Qnt) 
		select  OG.ID, OG.OutputID, O.ConfirmUserID, U.BrigadeID, -- OG.UserID
				OG.PackingID, 
				P.InBox, P.BoxInPal, G.Netto, 
				OG.QntConfirmed 
			from OutputsGoods OG with (nolock)
			inner join Outputs O with (nolock) on OG.OutputID = O.ID 
			inner join _Users U with (nolock) on O.ConfirmUserID = U.ID -- OG.UserID
			inner join Packings P with (nolock) on OG.PackingID = P.ID
			inner join Goods G with (nolock) on P.GoodID = G.ID '

	set @cWhere = ' where O.DateConfirm is not Null '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', O.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, O.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '

	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and O.ConfirmUserID in (' + dbo._NormalizeList(@cUsersList) + ') ' -- OG.UserID

	if @cOutputsTypesList is not Null
		set @cWhere = @cWhere + ' and O.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	select OutputID, UserID, BrigadeID, PackingID, 
			sum(Qnt) as Qnt, 
			sum(Qnt / InBox) as Boxes, 
			sum(Qnt / InBox / BoxInPal) as Pallets, 
			sum(Qnt * Netto) as Netto 
		into #OutputsDataSum
		from #OutputsData
		group by OutputID, UserID, BrigadeID, PackingID

	if @bGroupBy = 1 begin 
		-- по бригадам
		select X.*, 
				Null as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select cast(0 as int) as UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #OutputsDataSum
					group by BrigadeID) X
				left join Brigades B with (nolock) on X.BrigadeID = B.ID
				order by B.Name
	end 
	else begin
		-- по сотрудникам
		select X.*, 
				U.Name as UserName, 
				isNull(B.Name, '') as BrigadeName 
			from (select  UserID, 
						BrigadeID, 
						sum(1) as Lines, 
						sum(Qnt) as Qnt, 
						sum(Boxes) as Boxes, 
						sum(Pallets) as Pallets, 
						sum(Netto) as Netto
					from #OutputsDataSum
					group by UserID, BrigadeID) X 
			left join _Users U with (nolock) on X.UserID = U.ID
			left join Brigades B with (nolock) on X.BrigadeID = B.ID
			order by B.Name, U.Name
	end 
end 
return