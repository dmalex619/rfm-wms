set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_AuditActsFill]
	@nID				int				= Null, 
	@cIDList			varchar(max)	= Null, -- список AuditActs.ID (через ,) 
	@cHostsList			varchar(max)	= Null, -- список числовых кодов Host-ов (через,)
	@dDateBeg			smalldatetime	= Null, -- дата нач.периода
	@dDateEnd			smalldatetime	= Null, -- дата кон.периода
	@bConfirmed			bit				= Null, -- подтвержденные?
	@cOwnersList		varchar(max)	= Null, -- список владельцев (через ,)
	@cGoodsStatesList	varchar(max)	= Null, -- список состояний товара (через ,)
	-- параметры для поиска по товарам
	@cPackingsList		varchar(max)	= Null, -- список упаковок (через ,)
	@cGoodsList			varchar(max)	= Null  -- список товаров (через ,)
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- для поиска по товарам в актах
declare @bAuditActs bit
set @bAuditActs = 0
select  AuditActID 
	into #AuditActs
	from AuditActsGoods with (nolock) 
	where 1 = 2
if	@cPackingsList is not Null or @cGoodsList is not Null begin 
	set @bAuditActs = 1
	set @cSelect = '
	insert #AuditActs (AuditActID) 
		select AuditActID
			from AuditActsGoods AG with (nolock) 
			inner join Packings P with (nolock) on AG.PackingID = P.ID 
			inner join Goods G with (nolock) on P.GoodID = G.ID '
	set @cWhere = ' where 1 = 1 '
	if @cPackingsList is not Null 
		set @cWhere = ' and AG.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @cGoodsList is not Null 
		set @cWhere = ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '
	set @cSelect = @cSelect + @cWhere
	exec (@cSelect)
end

set @cSelect = '
select	A.ID, A.ID as AuditActID, 
		A.DateAudit, 
		A.OwnerID, Ow.Name as OwnerName, Ow.SeparatePicking, 
		A.GoodStateID, GS.Name as GoodStateName, 
		A.DateConfirm, 
		cast(case when DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
		A.Note, 
		A.OddmentSavedID, 
		A.HostID, HS.Name as HostName, 
		A.ErpCode 
	from AuditActs A with (nolock) 
	left join Partners Ow with (nolock) on A.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on A.GoodStateID = GS.ID 
	left join Hosts HS with (nolock) on A.HostID = HS.ID '

if @nID is not Null
	set @cWhere = ' where A.ID = ' + str(@nID)
else begin
	set @cWhere = ' where 1 = 1 '
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and A.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @cHostsList is not Null
		set @cWhere = @cWhere + ' and A.HostID in (' + dbo._NormalizeList(@cHostsList) + ') '
	
	if @dDateBeg is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', A.DateAudit) >= 0 '
	if @dDateEnd is not Null
		set @cWhere = @cWhere + ' and datediff(day, A.DateAudit, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	
	if @bConfirmed is not Null
		set @cWhere = @cWhere + ' and A.DateConfirm is ' + case when @bConfirmed = 1 then 'not' else '' end + ' Null '
	
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and A.OwnerID in (' +  dbo._NormalizeList(@cOwnersList) + ') '
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and A.GoodStateID in (' +  dbo._NormalizeList(@cGoodsStatesList) + ') '
	
	-- по связанным таблицам 
	if @bAuditActs = 1
		set @cWhere = @cWhere + ' and A.ID in (select AuditActID from #AuditActs) '
end 
set @cOrderBy = ' order by '
if @cIDList is not Null 
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(A.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' A.DateAudit desc, A.ID'
set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return