SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_InputsFill]
	@nID				int				= Null, 
	@cIDList			varchar(max)	= Null, -- список Inputs.ID (через ,) 
	@cHostsList			varchar(max)	= Null, -- список числовых кодов Host-ов (через,)
	@cBarCode			varchar(100)	= Null, -- штрих-код документа-прихода (контекст), 
	@bConfirmed			bit				= Null, -- подтвержденные приходы?
	@bConfirmedZero		bit				= Null, -- отклоненные приходы?
	@bStarted			bit				= Null, -- обработка прихода начата?
	@dDateBeg			smalldatetime	= Null, -- дата нач.периода
	@dDateEnd			smalldatetime	= Null, -- дата кон.периода
	@dDateBegConfirm	smalldatetime	= Null, -- дата подтверждения нач.периода
	@dDateEndConfirm	smalldatetime	= Null, -- дата подтверждения кон.периода
	@cInputsTypesList	varchar(max)	= Null, -- список типов приходов (через,)
	@cPartnersList		varchar(max)	= Null, -- список поставщиков (через ,)
	@cPartnerContext	varchar(200)	= Null, -- контекст названия поставщика
	@cOwnersList		varchar(max)	= Null, -- список владельцев (через ,)
	@cGoodsStatesList	varchar(max)	= Null, -- список состояний товара (через ,)
	@bGoodStateTerm		bit				= Null, -- список состояний товара - для прихода (0) или для товаров в приходе (1)
	@bTrafficsCreated	bit				= Null, -- созданы операции транспортировки для контейнеров
	@bTrafficsConfirmed bit				= Null, -- выполнены операции транспортировки 
	-- параметры для поиска приходов по товарам
	@cPackingsList		varchar(max)	= Null, -- список упаковок (через ,)
	@cGoodsList			varchar(max)	= Null, -- список товаров (через ,)
	-- параметры для поиска приходов по составляющим
	@cUsersList			varchar(max)	= Null, -- список пользователей, выполнявших приход (через ,)
	-- проблемы 
	@bFramesArrangeProblem			bit	= Null, -- проблемы при подборе ячеек для контейнеров
	@bTrafficsFramesConfirmProblem	bit	= Null  -- проблемы при выполнении транспортировок для контейнеров 
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- для поиска по товарам в приходах
declare @bInputsGoods bit
set @bInputsGoods = 0
select  InputID 
	into #InputsGoods 
	from InputsGoods with (nolock) 
	where 1 = 2
if	@cPackingsList is not Null or 
	@cGoodsList is not Null or 
	(@cGoodsStatesList is not Null and @bGoodStateTerm is not Null and @bGoodStateTerm = 1) begin 
	
	set @bInputsGoods = 1
	create index IX_InputsGoods_InputID on #InputsGoods (InputID)
	
	set @cSelect = 
	'insert #InputsGoods (InputID) 
		select InputID 
			from InputsGoods IG with (nolock)
			inner join Packings P with (nolock) on IG.PackingID = P.ID 
			inner join Goods G with (nolock) on P.GoodID = G.ID '
	set @cWhere = ' where 1 = 1 ' 
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and IG.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @cGoodsList is not Null 
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '
	if @cGoodsStatesList is not Null and @bGoodStateTerm is not Null and @bGoodStateTerm = 1
		set @cWhere = @cWhere + ' and IG.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
end

-- для поиска по составляющим приходов
declare @bInputsItems bit
set @bInputsItems = 0
select  InputID 
	into #InputsItems 
	from InputsItems with (nolock) 
	where 1 = 2
if	@cUsersList is not Null begin 
	set @bInputsItems = 1
	create index IX_InputsItems_InputID on #InputsItems (InputID)	
	
	set @cSelect = 
	'insert #InputsItems (InputID) 
		select InputID 
			from InputsItems II with (nolock) '
	set @cWhere = ' where 1 = 1 ' 
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and II.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '

	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)
end

-- для поиска по состоянию контейнеров
select	I.ID * 1 as InputID, 
		cast(0 as int) as TrfCreatedCount, 
		cast(0 as int) as TrfConfirmedCount, 
		cast(0 as int) as InpItemsCount 
		into #InputsTraffics
		from Inputs I with (nolock) 
		where 1 = 2
if (@bTrafficsCreated is not Null or @bTrafficsConfirmed is not Null) begin
	set @cSelect = 
	'insert #InputsTraffics (InputID, TrfCreatedCount, TrfConfirmedCount, InpItemsCount) 
		select I.ID, 0, 0, 0
		from Inputs I with (nolock) '
	if @bInputsGoods = 1
		set @cSelect = @cSelect + ' inner join #InputsGoods IG_X on I.ID = IG_X.InputID ' 
	if @bInputsItems = 1
		set @cSelect = @cSelect + ' inner join #InputsItems II_X on I.ID = II_X.InputID ' 
	exec (@cSelect)
	
	create index IX_InputsTraffics_InputID on #InputsTraffics (InputID)	
	
	-- кол-во созданных и выполненных транспортировок
	update  #InputsTraffics 
		set TrfCreatedCount = isNull(X.TrfCreatedCount, 0), 
			TrfConfirmedCount = isNull(X.TrfConfirmedCount, 0) 
		from (select I.ID as InputID, 
					count(T.ID) as TrfCreatedCount, 
					sum(case when T.DateConfirm is not Null then 1 else 0 end) as TrfConfirmedCount 
				from Inputs I with (nolock)
				inner join TrafficsFrames T with (nolock) on I.ID = T.InputID 
				group by I.ID) X 
		where #InputsTraffics.InputID = X.InputID
	-- кол-во составляющих прихода
	update  #InputsTraffics 
		set InpItemsCount = isNull(X.InpItemsCount, 0) 
		from (select I.ID as InputID, 
					 count(II.FrameID) as InpItemsCount 
				from Inputs I with (nolock)
				inner join InputsItems II with (nolock) on I.ID = II.InputID 
				where II.FrameID is not Null 
				group by I.ID) X 
		where #InputsTraffics.InputID = X.InputID
end 

set @cSelect = 
'select	I.ID, I.ID as InputID, 
		I.DateInput, I.DateStart, I.DateConfirm, 
		I.ConfirmUserID, UC.Name as ConfirmUserName, 
		I.InputTypeID, IT.Name as InputTypeName, 
		I.PartnerID, P.Name as PartnerName, 
		I.OwnerID, Ow.Name as OwnerName, Ow.SeparatePicking, 
		I.GoodStateID, GS.Name as GoodStateName, 
		I.Note, 
		cast(case when DateConfirm is Null then 0 else 1 end as bit) as IsConfirmed, 
		.dbo.GetInputNetto(I.ID,  0) as NettoWished,  .dbo.GetInputNetto(I.ID,  1) as NettoConfirmed, 
		.dbo.GetInputBrutto(I.ID, 0) as BruttoWished, .dbo.GetInputBrutto(I.ID, 1) as BruttoConfirmed, 
		I.PalletsFactQnt, 
		I.CoefficientUnload, 
		I.HostID, HS.Name as HostName, 
		I.ERPBarCode as BarCode, 
		I.ERPCode 
	from Inputs I with (nolock)
	left join Partners P with (nolock) on I.PartnerID = P.ID 
	left join Partners Ow with (nolock) on I.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on I.GoodStateID = GS.ID 
	left join InputsTypes IT with (nolock) on I.InputTypeID = IT.ID 
	left join _Users UC with (nolock) on I.ConfirmUserID = UC.ID 
	left join Hosts HS with (nolock) on I.HostID = HS.ID '

if @nID is not Null begin
	set @cWhere = ' where I.ID = ' + str(@nID) + ' ' 
end 
else begin 
	set @cWhere = ' where 1 = 1 ' 
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and I.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @cHostsList is not Null
		set @cWhere = @cWhere + ' and I.HostID in (' + dbo._NormalizeList(@cHostsList) + ') '
	
	if @cBarCode is not Null 
		set @cWhere = @cWhere + ' and charindex(''' + @cBarCode + ''', I.ERPBarCode) > 0 '
	
	if @bConfirmed is not Null
		set @cWhere = @cWhere + ' and I.DateConfirm is ' + 
			case when @bConfirmed = 1 then 'not' else '' end + ' Null '
	
	if @bConfirmedZero is not Null
		set @cWhere = @cWhere + ' and (I.DateConfirm is not Null and ' + 
			(case when @bConfirmedZero = 1 then 'not' else '' end) + ' exists (select ID from InputsGoods IG_CZ with (nolock) where IG_CZ.InputID = I.ID and IG_CZ.QntConfirmed > 0) ) ' 
	
	if @bStarted is not Null
		set @cWhere = @cWhere + ' and I.DateStart is ' + 
			case when @bStarted = 1 then 'not' else '' end + ' Null '
	
	if @dDateBeg is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', I.DateInput) >= 0 '
	
	if @dDateEnd is not Null
		set @cWhere = @cWhere + ' and datediff(day, I.DateInput, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	
	if @dDateBegConfirm is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBegConfirm, 112) + ''', I.DateConfirm) >= 0 '
	
	if @dDateEndConfirm is not Null
		set @cWhere = @cWhere + ' and datediff(day, I.DateConfirm, ''' + convert(varchar, @dDateEndConfirm, 112) + ''') >= 0 '
	
	if @cInputsTypesList is not Null 
		set @cWhere = @cWhere + ' and I.InputTypeID in (' + dbo._NormalizeList(@cInputsTypesList) + ') '
	
	if @cPartnersList is not Null
		set @cWhere = @cWhere + ' and I.PartnerID in (' + dbo._NormalizeList(@cPartnersList) + ') '
	
	if @cPartnerContext is not Null 
		set @cWhere = @cWhere + ' and charindex(upper(''' + @cPartnerContext + '''), upper(P.Name)) > 0 '
	
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and I.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	
	if @cGoodsStatesList is not Null and @bGoodStateTerm is not Null and @bGoodStateTerm = 0  
		set @cWhere = @cWhere + ' and I.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	
	if @bTrafficsCreated is not Null
		set @cWhere = @cWhere + ' and I.ID in (select InputID from #InputsTraffics 
			where TrfCreatedCount ' + (case when @bTrafficsCreated = 1 then '=' else '<' end) + ' InpItemsCount) '
	
	if @bTrafficsConfirmed is not Null
		set @cWhere = @cWhere + ' and I.ID in (select InputID from #InputsTraffics 
			where TrfConfirmedCount ' + (case when @bTrafficsCreated = 1 then '=' else '<' end) + ' TrfCreatedCount) '
	
	if @bInputsGoods = 1
		set @cWhere = @cWhere + ' and I.ID in (select InputID from #InputsGoods) ' 
	
	if @bInputsItems = 1
		set @cWhere = @cWhere + ' and I.ID in (select InputID from #InputsItems) '
	
	if @bFramesArrangeProblem is not Null and @bFramesArrangeProblem = 1 -- проблемы подбор
		set @cWhere = @cWhere + ' and exists (select II_P.ID 
								from InputsItems II_P with (nolock) 
								where	II_P.InputID = I.ID and 
										II_P.FrameID is not Null and 
										II_P.FrameID not in (select FrameID from TrafficsFrames with (nolock) where InputID = I.ID) ) '
	
	if @bTrafficsFramesConfirmProblem is not Null and @bTrafficsFramesConfirmProblem = 1 -- проблемы размещение
		set @cWhere = @cWhere + ' and exists (select TF_P.ID 
								from TrafficsFrames TF_P with (nolock) 
								inner join TrafficsFramesErrors TFE_P with (nolock) on TF_P.ErrorID = TFE_P.ID
								where	TF_P.InputID = I.ID and 
										TF_P.DateConfirm is not Null and 
										TF_P.Success = 0 and 
										TFE_P.Severity >= 0) '
end

set @cOrderBy = ' order by '
if @cIDList is not Null 
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(I.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' I.DateInput, P.Name, I.ID '

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return