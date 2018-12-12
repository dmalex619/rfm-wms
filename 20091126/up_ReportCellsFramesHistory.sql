set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_ReportCellsFramesHistory]
	@dDateBeg			smalldatetime = Null, -- начало периода
	@dDateEnd			smalldatetime = Null, -- окончание периода
	@bTraffics			bit = null,			  -- показывать транспортировки 
	@bChanges			bit = null,			  -- показывать исправления
	@cOwnersList		varchar(max) = Null, 
	@cGoodsStatesList	varchar(max) = Null, 
	@cPackingsList		varchar(max) = Null, 
	@cUsersList			varchar(max) = Null
AS

-- up_ReportCellsFramesHistory '20080801', '20080831', 1, 1, '1,1', null, 3950, null
set nocount on

declare @cSelect varchar(max), @cWhere varchar(max)

-- для поиска по списку ячеек
declare @bCells bit
set @bCells = 0
if object_id('tempdb..#CellsIDList') is not Null 
	set @bCells = 1

-- для поиска по списку контейнеров 
declare @bFrames bit
set @bFrames = 0
if object_id('tempdb..#FramesIDList') is not Null
	set @bFrames = 1

create table #History 
	(OperationType char(1), OperationName varchar(100), 
	 OperationCode varchar(20), 
	 ErrorID int, Problem bit, 
	 CellID int, DateOper datetime, UserID int, DeviceID int, Note varchar(1000), 
	 FrameID int, OwnerID int, GoodStateID int, 
	 PackingID int, Qnt decimal(12, 3), DateValid smalldatetime, 
	 InputID int, OutputID int, 
	 ErpCode varchar(50))
create index Index_History_PackingID on #History (PackingID)
create index Index_History_CellID on #History (CellID)

if isNull(@bTraffics, 0) = 1 begin
	-- 1. TrafficsFrames

	-- транспортировки: в ячейку
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, 
			OperationCode, 
			ErrorID, Problem, 
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			InputID, OutputID, 
			ErpCode) 
		select	''I'', ''Транспортировка контейнера в ячейку'', 
				''TF'' + str(T.ID), 
				T.ErrorID, 
				case when T.ErrorID is not null then 1 else 0 end, 
				T.CellTargetID, T.DateConfirm, T.UserID, T.DeviceID, 
				case when T.ErrorID is Null 
					 then ''Транспортировка из ячейки '' + CS.Address 
					 else ''Ошибка: '' + isNull(TE.Name, '''') end, 
				T.FrameID, CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid, 
				T.InputID, T.OutputID, 
				T.ErpCode 
			from	TrafficsFrames T with (nolock) 
			left join TrafficsFramesErrors TE with (nolock) on T.ErrorID = TE.ID 
			left join CellsContents CC with (nolock) on T.FrameID = CC.FrameID 
			left join Cells CS with (nolock) on T.CellSourceID = CS.ID '
	if @bCells = 1 
		set @cSelect = @cSelect + '	inner join #CellsIDList CList on T.CellTargetID = CList.CellID '
	if @bFrames = 1 
		set @cSelect = @cSelect + '	inner join #FramesIDList FList on T.FrameID = FList.FrameID '

	set @cWhere = ' where T.DateConfirm is not Null '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	-- транспортировки: из ячейки
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, 
			OperationCode, 
			ErrorID, Problem, 
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			InputID, OutputID, 
			ErpCode) 
		select	''O'', ''Транспортировка контейнера из ячейки'', 
				''TF'' + str(T.ID), 
				T.ErrorID, 
				case when T.ErrorID is not null then 1 else 0 end, 
				T.CellSourceID, T.DateConfirm, T.UserID, T.DeviceID, 
				case when T.ErrorID is Null 
					 then ''Транспортировка в ячейку '' + CT.Address 
					 else ''Ошибка: '' + isNull(TE.Name, '''') end, 
				T.FrameID, CC.OwnerID, CC.GoodStateID, CC.PackingID, -CC.Qnt, CC.DateValid, 
				T.InputID, T.OutputID, 
				T.ErpCode 
			from	TrafficsFrames T with (nolock) 
			left join TrafficsFramesErrors TE with (nolock) on T.ErrorID = TE.ID
			left join CellsContents CC with (nolock) on T.FrameID = CC.FrameID
			left join Cells CT with (nolock) on T.CellTargetID = CT.ID '
	if @bCells = 1 
		set @cSelect = @cSelect + '	inner join #CellsIDList CList on T.CellSourceID = CList.CellID '
	if @bFrames = 1 
		set @cSelect = @cSelect + '	inner join #FramesIDList FList on T.FrameID = FList.FrameID '

	set @cWhere = ' where T.DateConfirm is not Null '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	-- обновить данными из Inputs, Outputs, т.е. точно по приходу / расходу 
	-- (важно для уже неактуальных контейнеров)
	update #History
		set OwnerID = I.OwnerID, GoodStateID = II.GoodStateID, 
			PackingID = II.PackingID, Qnt = II.Qnt, DateValid = II.DateValid
		from InputsItems II 
		left join Inputs I on II.InputID = I.ID 
		where #History.InputID is not Null and
			  #History.InputID = II.InputID and 
			  #History.FrameID = II.FrameID
	update #History
		set OwnerID = O.OwnerID, GoodStateID = OI.GoodStateID, 
			PackingID = OI.PackingID, Qnt = OI.Qnt, DateValid = OI.DateValid
		from OutputsItems OI 
		left join Outputs O on OI.OutputID = O.ID 
		where #History.OutputID is not Null and
			  #History.OutputID = OI.OutputID and 
			  #History.FrameID = OI.FrameID

	-- и теперь удалить лишние по фильтрам
	if @cOwnersList is not Null and @cOwnersList > '' begin
		set @cSelect = 'delete #History where OwnerID not in (' + dbo._NormalizeList(@cOwnersList) + ') '
		exec (@cSelect)
	end 
	if @cGoodsStatesList is not Null and @cGoodsStatesList > '' begin 
		set @cSelect = 'delete #History where GoodStateID not in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
		exec (@cSelect)
	end 
	if @cPackingsList is not Null and @cPackingsList > '' begin 
		set @cSelect = 'delete #History where PackingID is Null or PackingID not in (' + dbo._NormalizeList(@cPackingsList) + ') ' 
		exec (@cSelect)
	end 

	-- 2. TrafficsGoods (если нет списка контейнеров)
	if @bFrames = 0 begin
		-- перемещения: в ячейку
		set @cSelect = 
		'insert	#History 
				(OperationType, OperationName, 
				OperationCode, 
				ErrorID, Problem, 
				CellID, DateOper, UserID, DeviceID, Note, 
				FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
				InputID, OutputID, 
				ErpCode) 
			select	''I'', ''Перемещение штук/коробок в ячейку'', 
					''TG'' + str(T.ID), 
					T.ErrorID, 
					case when T.ErrorID is not null then 1 else 0 end, 
					T.CellTargetID, T.DateConfirm, T.UserID, T.DeviceID, 
					case when T.ErrorID is Null 
						 then ''Перемещение штук/коробок из ячейки '' + CS.Address 
						 else ''Ошибка: '' + isNull(TE.Name, '''') end, 
					Null, T.OwnerID, T.GoodStateID, T.PackingID, T.QntConfirmed, Null, 
					T.InputID, T.OutputID, 
					T.ErpCode 
				from	TrafficsGoods T with (nolock) 
				left join TrafficsGoodsErrors TE with (nolock) on T.ErrorID = TE.ID 
				left join Cells CS with (nolock) on T.CellSourceID = CS.ID '
		if @bCells = 1 
			set @cSelect = @cSelect + '	inner join #CellsIDList CList on T.CellTargetID = CList.CellID '

		set @cWhere = ' where T.DateConfirm is not Null '
		if @dDateBeg is not Null 
			set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
		if @dDateEnd is not Null 
			set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
		if @cUsersList is not Null
			set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

		if @cOwnersList is not Null
			set @cWhere = @cWhere + ' and T.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
		if @cGoodsStatesList is not Null
			set @cWhere = @cWhere + ' and T.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
		if @cPackingsList is not Null
			set @cWhere = @cWhere + ' and T.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') ' 

		set @cSelect = @cSelect + @cWhere 
		exec (@cSelect)

		-- перемещения: из ячейки
		set @cSelect = 
		'insert	#History 
				(OperationType, OperationName, 
				OperationCode, 
				ErrorID, Problem, 
				CellID, DateOper, UserID, DeviceID, Note, 
				FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
				InputID, OutputID, 
				ErpCode) 
			select	''O'', ''Перемещение штук/коробок из ячейки'', 
					''TG'' + str(T.ID), 
					T.ErrorID, 
					case when T.ErrorID is not null then 1 else 0 end, 
					T.CellSourceID, T.DateConfirm, T.UserID, T.DeviceID, 
					case when T.ErrorID is Null 
						 then ''Перемещение штук/коробок в ячейку '' + CT.Address 
						 else ''Ошибка: '' + isNull(TE.Name, '''') end, 
					Null, T.OwnerID, T.GoodStateID, T.PackingID, -T.QntConfirmed, Null, 
					T.InputID, T.OutputID, 
					T.ErpCode 
				from	TrafficsGoods T with (nolock) 
				left join TrafficsGoodsErrors TE with (nolock) on T.ErrorID = TE.ID 
				left join Cells CT with (nolock) on T.CellTargetID = CT.ID '
		if @bCells = 1 
			set @cSelect = @cSelect + '	inner join #CellsIDList CList on T.CellTargetID = CList.CellID '

		set @cWhere = ' where T.DateConfirm is not Null '
		if @dDateBeg is not Null 
			set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
		if @dDateEnd is not Null 
			set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
		if @cUsersList is not Null
			set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

		if @cOwnersList is not Null
			set @cWhere = @cWhere + ' and T.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
		if @cGoodsStatesList is not Null
			set @cWhere = @cWhere + ' and T.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
		if @cPackingsList is not Null
			set @cWhere = @cWhere + ' and T.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') ' 

		set @cSelect = @cSelect + @cWhere 
		exec (@cSelect)
	end
end

if isNull(@bChanges, 0) = 1 begin
	-- исправление состояния ячейки
	
	-- 1. контейнеры 
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, 
			OperationCode, 
			ErrorID, Problem, 
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			ErpCode) 
		select	''S'', ''Исправление состояния ячейки/контейнера'', 
				''CH'' + str(CH.ID), 
				Null, 0, 
				CH.CellID, CH.DateEdit, CH.UserID, CH.DeviceID, ltrim(CH.NoteManual + '' '' + CH.Note), 
				CH.FrameID, CH.OwnerID, CH.GoodStateID, CH.PackingID, CH.Qnt, CH.DateValid, 
				CH.ErpCode 
			from CellsChanges CH with (nolock) '
	if @bCells = 1 
		set @cSelect = @cSelect + '	inner join #CellsIDList CList on CH.CellID = CList.CellID '
	if @bFrames = 1 
		set @cSelect = @cSelect + '	inner join #FramesIDList FList on CH.FrameID = FList.FrameID '

	set @cWhere = ' where CH.FrameID is not Null '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', CH.DateEdit) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, CH.DateEdit, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and CH.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and CH.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and CH.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and CH.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') ' 
	
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	-- 2. товары 
	if @bFrames = 0 begin
		set @cSelect = 
		'insert	#History 
				(OperationType, OperationName, 
				OperationCode, 
				ErrorID, Problem, 
				CellID, DateOper, UserID, DeviceID, Note, 
				FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
				ErpCode) 
			select	''S'', ''Исправление состояния ячейки'', 
					''CH'' + str(CH.ID), 
					Null, 0, 
					CH.CellID, CH.DateEdit, CH.UserID, CH.DeviceID, ltrim(CH.NoteManual + '' '' + CH.Note), 
					CH.FrameID, CH.OwnerID, CH.GoodStateID, CH.PackingID, CH.Qnt, CH.DateValid, 
					CH.ErpCode 
				from CellsChanges CH with (nolock) '
		if @bCells = 1 
			set @cSelect = @cSelect + '	inner join #CellsIDList CList on CH.CellID = CList.CellID '

		set @cWhere = ' where CH.FrameID is Null '
		if @dDateBeg is not Null 
			set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', CH.DateEdit) >= 0 '
		if @dDateEnd is not Null 
			set @cWhere = @cWhere + ' and datediff(day, CH.DateEdit, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
		if @cUsersList is not Null
			set @cWhere = @cWhere + ' and CH.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

		if @cOwnersList is not Null
			set @cWhere = @cWhere + ' and CH.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
		if @cGoodsStatesList is not Null
			set @cWhere = @cWhere + ' and CH.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
		if @cPackingsList is not Null
			set @cWhere = @cWhere + ' and CH.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') ' 
		
		set @cSelect = @cSelect + @cWhere 
		exec (@cSelect)
	end 
end

select	-- ячейка 
		H.CellID, 
		C.BarCode as CellBarCode, C.Address as CellAddress, 
		SZ.Name as StoreZoneName, SZT.Name as StoreZoneTypeName, 
		-- контейнер
		H.FrameID, 
		F.BarCode as FrameBarCode, 
		-- изменение
		H.OperationType, H.OperationName, 
		H.OperationCode, 
		H.Problem, H.ErrorID, 
		H.DateOper, 
		H.UserID, U.Name as UserName, 
		H.DeviceID, D.Name as DeviceName, 
		H.Note, 
	 	H.OwnerID, Ow.Name as OwnerName, 
		H.GoodStateID, GS.Name as GoodStateName, 
		H.PackingID, P.GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal, 
		H.Qnt, 
		H.Qnt / P.InBox as BoxQnt, 
		cast(H.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		H.DateValid, 
		H.InputID, H.OutputID, 
		H.ErpCode 
	from #History H 
	inner join Cells C with (nolock) on H.CellID = C.ID 
	left  join Frames F with (nolock) on H.FrameID = F.ID 
	left  join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left  join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	left  join Partners Ow with (nolock) on H.OwnerID = Ow.ID 
	left  join _Users U with (nolock) on H.UserID = U.ID 
	left  join Devices D with (nolock) on H.DeviceID = D.ID 
	left  join GoodsStates GS with (nolock) on H.GoodStateID = GS.ID 
	left  join Packings P with (nolock) on H.PackingID = P.ID 
	left  join Goods G with (nolock) on P.GoodID = G.ID 
	left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	order by H.DateOper desc, C.Address
return