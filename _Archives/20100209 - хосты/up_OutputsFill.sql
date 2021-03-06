set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsFill]
	@nID				int				= Null, 
	@cIDList			varchar(max)	= Null, -- список Outputs.ID (через ,) 
	@cHostsList			varchar(max)	= Null, -- список числовых кодов Host-ов (через,)
	@cBarCode			varchar(100)	= Null, -- штрих-код расхода (контекст), 
	@bPicked			bit				= Null, -- собранные расходы?
	@bConfirmed			bit				= Null, -- подтвержденные расходы?
	@dDateBeg			smalldatetime	= Null, -- дата нач.периода
	@dDateEnd			smalldatetime	= Null, -- дата кон.периода
	@dDateBegConfirm	smalldatetime	= Null, -- дата подтверждения нач.периода
	@dDateEndConfirm	smalldatetime	= Null, -- дата подтверждения кон.периода
	@cOutputsTypesList	varchar(max)	= Null, -- список типов расходов (через,)
	@cGoodsStatesList	varchar(max)	= Null, -- список состояний товара (через ,)
	@cOwnersList		varchar(max)	= Null, -- список владельцев (через ,)
	@cPartnersList		varchar(max)	= Null, -- список получателей (через ,)
	@cPartnerContext	varchar(200)	= Null, -- контекст названия получателя
	@cCarAliasContext	varchar(200)	= Null, -- контекст названия машины
	@cCarsAliasesList	varchar(max)	= Null, -- список названий машины (через разделитель)
	@bBackDoor			bit				= Null, -- задняя дверь? 
	-- параметры для поиска расходов по товарам
	@cPackingsList		varchar(max)	= Null, -- список упаковок (через ,)
	@cGoodsList			varchar(max)	= Null, -- список товаров (через ,)
	@nOutputSelectedInfo int			= Null, -- выполнен подбор товаров: 
												-- -1 что-то не подобрано (0, 1), 0 ничего не подобрано, 1 подобрано не все, 
												-- 2,3 подобрано все (3 переподобрано)
	@nOutputTrafficsInfo tinyint		= Null,  -- перемещения и транспортировки: 0 не выполнены, 1 выполнены не все, 2 выполенены все 
	@bOutputFullConfirmedInfo bit       = Null   -- 0 в расходе не весь подобранный товар выдан
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- для поиска по товарам в расходах
declare @bOutputsGoods bit
set @bOutputsGoods = 0
select  OutputID 
	into #OutputsGoods 
	from OutputsGoods with (nolock) 
	where 1 = 2
create index IX_OutputsGoods_OutputID on #OutputsGoods (OutputID)

if	@cPackingsList is not Null or @cGoodsList is not Null begin
	set @bOutputsGoods = 1
	
	set @cSelect = 
	'insert #OutputsGoods (OutputID) 
		select OutputID 
			from OutputsGoods IG with (nolock) 
			inner join Packings P with (nolock) on IG.PackingID = P.ID 
			inner join Goods G with (nolock) on P.GoodID = G.ID '
	set @cWhere = ' where 1 = 1 '
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and IG.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @cGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '
	
	set @cSelect = @cSelect + @cWhere
	exec (@cSelect)
end

set @cSelect = 
'select	O.ID, O.ID as OutputID, 
		O.DateOutput, O.DatePrint, O.DateStart, O.DateSelect, 
		O.DatePick, 
		cast(case when DatePick is Null then 0 else 1 end as bit) as IsPicked, 
		O.DateConfirm, 
		cast(case when DateConfirm is Null then 0 else 1 end as bit) as IsConfirmed, 
		O.ConfirmUserID, UC.Name as ConfirmUserName, 
		O.OutputTypeID, IT.Name as OutputTypeName, 
		O.GoodStateID, GS.Name as GoodStateName, 
		O.OwnerID, Ow.Name as OwnerName, Ow.SeparatePicking, 
		O.PartnerID, P.Name as PartnerName, 
		O.CellID, C.Address as CellAddress, 
		O.Note, 
		
		O.CarAlias, O.BackDoor, 
		case when O.CarAlias > '''' then O.CarAlias + (case when O.BackDoor = 1 then '' (зад.)'' else '' (бок.)'' end) else '''' end as CarAliasFull, 
		O.ChargeOrder, 
		
		.dbo.GetOutputNetto(O.ID,  0) as NettoWished,  .dbo.GetOutputNetto(O.ID,  1) as NettoConfirmed, 
		.dbo.GetOutputBrutto(O.ID, 0) as BruttoWished, .dbo.GetOutputBrutto(O.ID, 1) as BruttoConfirmed, 
		.dbo.GetOutputPalletsQnt(O.ID) as PalletsQnt, 
		
		.dbo.GetOutputExistsNewTrafficsGoods(O.ID) as ExistsNewTrafficsGoods, 
		
		O.IsSelecting, 
		
		O.CoefficientLoad, 
		
		O.HostID, HS.Name as HostName, 
		O.ERPBarCode as BarCode, 
		O.ERPCode, 
		.dbo.GetOutputSelectedInfo(O.ID) as OutputSelectedInfo, 
		.dbo.GetOutputTrafficsInfo(O.ID) as OutputTrafficsInfo 
	from Outputs O with (nolock) 
	left join Partners P with (nolock) on O.PartnerID = P.ID 
	left join Partners Ow with (nolock) on O.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on O.GoodStateID = GS.ID 
	left join OutputsTypes IT with (nolock) on O.OutputTypeID = IT.ID 
	left join Cells C with (nolock) on O.CellID = C.ID 
	left join _Users UC	with (nolock) on O.ConfirmUserID = UC.ID 
	left join Hosts HS with (nolock) on O.HostID = HS.ID '

if @nID is not Null begin
	set @cWhere = ' where O.ID = ' + str(@nID) + ' '
end
else begin
	set @cWhere = ' where 1 = 1 '
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and O.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @cHostsList is not Null
		set @cWhere = @cWhere + ' and O.HostID in (' + dbo._NormalizeList(@cHostsList) + ') '
	
	if @cBarCode is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cBarCode + ''', O.ERPBarCode) > 0 '
	
	if @bConfirmed is not Null
		set @cWhere = @cWhere + ' and O.DateConfirm is ' + 
			case when @bConfirmed = 1 then 'not' else '' end + ' Null '
	if @bPicked is not Null
		set @cWhere = @cWhere + ' and O.DatePick is ' + 
			case when @bPicked = 1 then 'not' else '' end + ' Null '
	
	if @dDateBeg is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', O.DateOutput) >= 0 '
	if @dDateEnd is not Null
		set @cWhere = @cWhere + ' and datediff(day, O.DateOutput, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	
	if @dDateBegConfirm is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBegConfirm, 112) + ''', O.DateConfirm) >= 0 '
	if @dDateEndConfirm is not Null
		set @cWhere = @cWhere + ' and datediff(day, O.DateConfirm, ''' + convert(varchar, @dDateEndConfirm, 112) + ''') >= 0 '
	
	if @cOutputsTypesList is not Null
		set @cWhere = @cWhere + ' and O.OutputTypeID in (' + dbo._NormalizeList(@cOutputsTypesList) + ') '
	
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and O.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and O.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	
	if @cPartnersList is not Null
		set @cWhere = @cWhere + ' and O.PartnerID in (' + dbo._NormalizeList(@cPartnersList) + ') '
	
	if @cPartnerContext is not Null
		set @cWhere = @cWhere + ' and charindex(upper(''' + @cPartnerContext + '''), upper(P.Name)) > 0 '
	
	if @cCarAliasContext is not Null
		set @cWhere = @cWhere + ' and charindex(upper(''' + @cCarAliasContext + '''), upper(O.CarAlias)) > 0 '
	
	if @cCarsAliasesList is not Null begin
		-- разделитель в списке машин
		declare @cCarAliasDelimiter varchar(20)
		set @cCarAliasDelimiter = Null
		select @cCarAliasDelimiter = [Value] 
			from _Settings with (nolock) 
			where Variable = 'sCarAliasDelimeter'
		if @cCarAliasDelimiter is Null
			set @cCarAliasDelimiter = '###'
		
		set @cCarsAliasesList = @cCarAliasDelimiter + @cCarsAliasesList + @cCarAliasDelimiter
		set @cWhere = @cWhere + ' and CarAlias > '''' and ' + 
				'charindex(''' + @cCarAliasDelimiter + ''' + upper(O.CarAlias) + ''' + @cCarAliasDelimiter + ''', upper(''' + @cCarsAliasesList+ ''')) > 0 '
	end
	
	if @bBackDoor is not Null
		set @cWhere = @cWhere + ' and (ltrim(rtrim(O.CarAlias)) > '''' and O.BackDoor = ' + str(@bBackDoor) + ') '
	
	if @bOutputsGoods = 1
		set @cWhere = @cWhere + ' and O.ID in (select OutputID from #OutputsGoods) '
	
	if @nOutputSelectedInfo is Not Null begin
		if @nOutputSelectedInfo = -1
			set @cWhere = @cWhere + ' and .dbo.GetOutputSelectedInfo(O.ID) <= 1 '
		else
			set @cWhere = @cWhere + ' and .dbo.GetOutputSelectedInfo(O.ID) ' + (case when @nOutputSelectedInfo = 2 
				then '>' else '' end) + '= ' + str(@nOutputSelectedInfo) + ' '
	end
	
	if @nOutputTrafficsInfo is not Null
		set @cWhere = @cWhere + ' and .dbo.GetOutputTrafficsInfo(O.ID) = ' + str(@nOutputTrafficsInfo) + ' '
	
	if @bOutputFullConfirmedInfo is not Null
		set @cWhere = @cWhere + ' and .dbo.GetOutputFullConfirmedInfo(O.ID) = 0'
end

set @cOrderBy = ' order by '
if @cIDList is not Null
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(O.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' O.DateOutput, Ow.Name, O.ID '

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return