set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_ComplexesFill]
	@nID			int = Null, 
	@cIDList		varchar(max)= Null, 
	@cNameContext	varchar(200) = Null, -- контекст названия 
	@bActual		bit = Null
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

set @cSelect = 
	'select	Cx.ID, Cx.ID as ComplexID, Cx.Name, Cx.Alias, Cx.Actual 
		from Complexes Cx with (nolock) '
set @cWhere = ' where 1 = 1 '
if @nID is not Null
	set @cWhere = @cWhere + ' and Cx.ID = ' + str(@nID)
else begin
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and Cx.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	if @cNameContext is not Null
		set @cWhere = @cWhere + ' and (charindex(''' + @cNameContext + ''', Cx.Name) > 0 or 
										charindex(''' + @cNameContext + ''', Cx.Alias) > 0) '
	if @bActual is not Null
		set @cWhere = @cWhere + ' and Cx.Actual = ' + str(@bActual) + ' '
end

set @cOrderBy = ' order by '
if @cIDList is not Null
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(Cx.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' Cx.Name, Cx.ID'
set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return