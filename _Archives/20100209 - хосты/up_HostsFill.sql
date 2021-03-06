set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_HostsFill]
	@nID			int = Null, 
	@cIDList		varchar(max)= Null, 
	@cNameContext	varchar(200) = Null, -- контекст названия 
	@cShortCode		varchar(200) = Null, -- контекст символьного кода
	@bActual		bit = Null
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

set @cSelect = 
	'select	HS.ID, HS.ID as HostID, 
		HS.Name, HS.ShortCode, HS.Actual, 
		HS.Password 
	from Hosts HS with (nolock) '
set @cWhere = ' where 1 = 1 '
if @nID is not Null
	set @cWhere = @cWhere + ' and HS.ID = ' + str(@nID)
else begin
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and HS.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	if @cNameContext is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cNameContext + ''', HS.Name) > 0 '
	if @cShortCode is not Null begin
		if @cShortCode = ''
			set @cWhere = @cWhere + ' and HS.ShortCode) = '''' '
		else
			set @cWhere = @cWhere + ' and charindex(''' + @cShortCode + ''', HS.ShortCode) > 0 '
	end
	if @bActual is not Null
		set @cWhere = @cWhere + ' and HS.Actual = ' + str(@bActual) + ' '
end

set @cOrderBy = ' order by '
if @cIDList is not Null
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(HS.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' HS.Name, HS.ID'
set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return