set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsHistoryFill]
	@nCellID		int				= Null, -- код записи о ячейке
	@cCellsIDList	varchar(max) 	= Null, -- список Cells.ID (через ,) 
	@dDateBeg		smalldatetime	= Null, -- начало периода
	@dDateEnd		smalldatetime	= Null, -- окончание периода
	@bCellsChangesOnly	bit = null -- только изменение состояния
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max)

create table #History 
	(OperationType char(1), OperationName varchar(100), Problem bit, 
	 OperationCode varchar(20), 
	 CellID int, DateOper datetime, UserID int, DeviceID int, Note varchar(1000), 
	 FrameID int, OwnerID int, GoodStateID int, 
	 PackingID int, Qnt decimal(12, 3), DateValid smalldatetime, 
	 InputID int, OutputID int, 
	 ErpCode varchar(50) ) 
create index Index_History_PackingID on #History (PackingID)

if isNull(@bCellsChangesOnly, 0) = 0 begin
	-- 1. TrafficsFrames
	
	-- транспортировки: в ячейку
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, Problem,
			OperationCode, 
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			InputID, OutputID, 
			ErpCode) 
		select	''I'', ''Транспортировка контейнера в ячейку'', case when ErrorID is not null then 1 else 0 end, 
				''TF'' + str(T.ID), 
				T.CellTargetID, T.DateConfirm, T.UserID, T.DeviceID, LTrim(isNull(TE.Name, '''') + '' '' + T.Note), 
				T.FrameID, 
				CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid, 
				T.InputID, T.OutputID, 
				T.ErpCode
			from	TrafficsFrames T with (nolock) 
			left join TrafficsFramesErrors TE with (nolock) on T.ErrorID = TE.ID
			left join CellsContents CC with (nolock) on T.FrameID = CC.FrameID '
	set @cWhere = ' where T.DateConfirm is not Null '
	if @nCellID is not Null 
		set @cWhere = @cWhere + ' and T.CellTargetID = ' + str(@nCellID) + ' '
	if @cCellsIDList is not Null 
		set @cWhere = @cWhere + ' and T.CellTargetID in (' + dbo._NormalizeList(@cCellsIDList) + ') '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
	
	-- транспортировки: из ячейки
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, Problem, 
			OperationCode, 
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			InputID, OutputID, 
			ErpCode) 
		select	''O'', ''Транспортировка контейнера из ячейки'', case when ErrorID is not null then 1 else 0 end, 
				''TF'' + str(T.ID), 
				T.CellSourceID, T.DateConfirm, T.UserID, T.DeviceID, LTrim(isNull(TE.Name, '''') + '' '' + T.Note), 
				T.FrameID, CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid, 
				T.InputID, T.OutputID, 
				T.ErpCode 
			from	TrafficsFrames T with (nolock) 
			left join TrafficsFramesErrors TE with (nolock) on T.ErrorID = TE.ID
			left join CellsContents CC with (nolock) on T.FrameID = CC.FrameID '
	set @cWhere = ' where T.DateConfirm is not Null '
	if @nCellID is not Null 
		set @cWhere = @cWhere + ' and T.CellSourceID = ' + str(@nCellID) + ' '
	if @cCellsIDList is not Null 
		set @cWhere = @cWhere + ' and T.CellSourceID in (' + dbo._NormalizeList(@cCellsIDList) + ') '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
	
	-- точно по приходу / расходу (важно для уже неактуальных контейнеров)
	update #History
		set OwnerID = I.OwnerID, GoodStateID = II.GoodstateID, 
			PackingID = II.PackingID, Qnt = II.Qnt, DateValid = II.DateValid
		from InputsItems II 
		left join Inputs I on II.InputID = I.ID 
		where #History.InputID is not Null and
			  #History.InputID = II.InputID and 
			  #History.FrameID = II.FrameID
	update #History
		set OwnerID = O.OwnerID, GoodStateID = OI.GoodstateID, 
			PackingID = OI.PackingID, Qnt = OI.Qnt, DateValid = OI.DateValid
		from OutputsItems OI 
		left join Outputs O on OI.OutputID = O.ID 
		where #History.OutputID is not Null and
			  #History.OutputID = OI.OutputID and 
			  #History.FrameID = OI.FrameID
	
	-- 2. TrafficsGoods
	
	-- перемещение: в ячейку
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, Problem,
			OperationCode,  
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			InputID, OutputID, 
			ErpCode) 
		select	''I'', ''Перемещение коробок/штук в ячейку'', case when ErrorID is not null then 1 else 0 end, 
				''TG'' + str(T.ID), 
				T.CellTargetID, T.DateConfirm, T.UserID, T.DeviceID, LTrim(isNull(TE.Name, '''') + '' '' + T.Note), 
				Null, T.OwnerID, T.GoodStateID, T.PackingID, T.QntConfirmed, Null, 
				T.InputID, T.OutputID, 
				T.ErpCode
			from	TrafficsGoods T with (nolock) 
			left join TrafficsGoodsErrors TE with (nolock) on T.ErrorID = TE.ID '
	set @cWhere = ' where T.DateConfirm is not Null '
	if @nCellID is not Null 
		set @cWhere = @cWhere + ' and T.CellTargetID = ' + str(@nCellID) + ' '
	if @cCellsIDList is not Null 
		set @cWhere = @cWhere + ' and T.CellTargetID in (' + dbo._NormalizeList(@cCellsIDList) + ') '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
	
	-- перемещения: из ячейки
	set @cSelect = 
	'insert	#History 
			(OperationType, OperationName, Problem, 
			OperationCode, 
			CellID, DateOper, UserID, DeviceID, Note, 
			FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
			InputID, OutputID, 
			ErpCode) 
		select	''O'', ''Перемещение коробок/штук из ячейки'', case when ErrorID is not null then 1 else 0 end, 
				''TG'' + str(T.ID), 
				T.CellSourceID, T.DateConfirm, T.UserID, T.DeviceID, LTrim(isNull(TE.Name, '''') + '' '' + T.Note), 
				Null, T.OwnerID, T.GoodStateID, T.PackingID, T.QntConfirmed, Null, 
				T.InputID, T.OutputID, 
				T.ErpCode
			from	TrafficsGoods T with (nolock) 
			left join TrafficsGoodsErrors TE with (nolock) on T.ErrorID = TE.ID '
	set @cWhere = ' where T.DateConfirm is not Null '
	if @nCellID is not Null 
		set @cWhere = @cWhere + ' and T.CellSourceID = ' + str(@nCellID) + ' '
	if @cCellsIDList is not Null 
		set @cWhere = @cWhere + ' and T.CellSourceID in (' + dbo._NormalizeList(@cCellsIDList) + ') '
	if @dDateBeg is not Null 
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateConfirm) >= 0 '
	if @dDateEnd is not Null 
		set @cWhere = @cWhere + ' and datediff(day, T.DateConfirm, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
end

-- исправление состояния ячейки
set @cSelect = 
'insert	#History 
		(OperationType, OperationName, Problem, 
		OperationCode, 
		CellID, DateOper, UserID, DeviceID, Note, 
		FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid,  
		ErpCode) 
	select	''S'', ''Исправление состояния ячейки'', 0, 
			''CH'' + str(CH.ID), 
			CH.CellID, CH.DateEdit, CH.UserID, CH.DeviceID, ltrim(CH.NoteManual + '' '' + CH.Note), 
			CH.FrameID, CH.OwnerID, CH.GoodStateID, CH.PackingID, CH.Qnt, CH.DateValid, 
			CH.ErpCode 
		from	CellsChanges CH with (nolock) '
set @cWhere = ' where 1 = 1 '
if @nCellID is not Null 
	set @cWhere = @cWhere + ' and CH.CellID = ' + str(@nCellID) + ' '
if @cCellsIDList is not Null 
	set @cWhere = @cWhere + ' and CH.CellID in (' + dbo._NormalizeList(@cCellsIDList) + ') '
if @dDateBeg is not Null 
	set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', CH.DateEdit) >= 0 '
if @dDateEnd is not Null 
	set @cWhere = @cWhere + ' and datediff(day, CH.DateEdit, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
set @cSelect = @cSelect + @cWhere 
exec (@cSelect)

select	-- ячейка 
	H.CellID, 
	C.BarCode as CellBarCode, C.Address as CellAddress, 
	-- контейнер
	H.FrameID, 
	F.BarCode as FrameBarCode,  
	-- изменение
	H.OperationType, H.OperationName, H.Problem, 
	H.OperationCode, 
	H.DateOper, 
	H.UserID, U.Name as UserName, 
	H.DeviceID, D.Name as DeviceName, 
	H.Note, 
	H.InputID, H.OutputID, 
 	H.OwnerID, Ow.Name as OwnerName, 
	H.GoodStateID, GS.Name as GoodStateName, 
	H.PackingID, P.GoodID, 
	G.ID as GoodID, P.ID as PackingID, 
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
	H.ErpCode 
	from #History H 
	inner join Cells C with (nolock) on H.CellID = C.ID
	left  join Frames F with (nolock) on H.FrameID = F.ID
	left  join Partners Ow with (nolock) on H.OwnerID = Ow.ID
	left  join _Users U with (nolock) on H.UserID = U.ID
	left  join Devices D with (nolock) on H.DeviceID = D.ID
	left  join GoodsStates GS with (nolock) on H.GoodStateID = GS.ID
	left /*inner*/ join Packings P with (nolock) on H.PackingID = P.ID -- есть операции с контейнером, где контейнер уже разобран
	left  join Goods G with (nolock) on P.GoodID = G.ID 
	left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	order by H.CellID, H.DateOper desc
return