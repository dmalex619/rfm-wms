set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_PartnersFill]
	@nID				int = Null, 
	@cIDList			varchar(max) = Null, -- список кодов клиентов Partners.ID (через ,) 
	@cHostsList			varchar(max) = Null, -- список числовых кодов Host-ов (через,)
	@cNameContext		varchar(200) = Null, -- контекст названия
	@bActual			bit = Null, 
	@bOwner				bit = Null, -- владелец?
	@bSeparatePicking	bit = Null, -- учет остатков для владельца?
	@bExistsInInputs	bit = Null  -- партнер является поставщиком в приходе?
AS

set nocount on

create table #PartnersInInputs (PartnerID int)
if @bExistsInInputs is not Null begin
	insert #PartnersInInputs (PartnerID)
		select distinct PartnerID 
			from Inputs with (nolock)
end 

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

set @cSelect = 
	'select	P.ID, P.ID as PartnerID, 
		P.Name, 
		P.Owner, P.SeparatePicking, P.Actual, 
		P.HostID, HS.Name as HostName,  
		P.ERPCode
	from Partners P with (nolock) 
	left join Hosts HS with (nolock) on P.HostID = HS.ID '

set @cWhere = ' where 1 = 1 '
if @nID is not Null
	set @cWhere = @cWhere + ' and P.ID = ' + str(@nID)
else begin
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and P.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @cHostsList is not Null
		set @cWhere = @cWhere + ' and P.HostID in (' + dbo._NormalizeList(@cHostsList) + ') '
	
	if @cNameContext is not Null 
		set @cWhere = @cWhere + ' and charindex(''' + @cNameContext + ''', P.Name) > 0 '
	
	if @bActual is not Null
		set @cWhere = @cWhere + ' and P.Actual = ' + str(@bActual) + ' '
	
	if @bOwner is not Null
		set @cWhere = @cWhere + ' and P.Owner = ' + str(@bOwner) + ' '
	
	if @bSeparatePicking is not Null
		set @cWhere = @cWhere + ' and P.SeparatePicking = ' + str(@bSeparatePicking) + ' '
	
	if @bExistsInInputs is not Null
		set @cWhere = @cWhere + ' and ' + (case when @bExistsInInputs = 0 then ' not ' else '' end) + 'exists (select PII.PartnerID from #PartnersInInputs PII where P.ID = PII.PartnerID) '
end

set @cOrderBy = ' order by '
if @cIDList is not Null 
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(P.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' P.Name, P.ID'
set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return