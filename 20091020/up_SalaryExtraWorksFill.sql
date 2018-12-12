set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_SalaryExtraWorksFill]
	@nID				int				= Null, 
	@cIDList			varchar(max)	= Null, -- список SalaryExtraWorks.ID (через ,) 
	@dDateBeg			smalldatetime	= Null, -- дата нач.периода
	@dDateEnd			smalldatetime	= Null, -- дата кон.периода
	@cUsersList			varchar(max)	= Null, -- список сотрудников (через ,)
	@cWorkNameContext	varchar(200)	= Null  -- контектс названия работ
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

set @cSelect = 
'select	SEW.ID, SEW.ID as SalaryExtraWorkID, 
		SEW.DateWork, 
		SEW.WorkName, 
		SEW.UserID, U.Name as UserName, U.BrigadeID, B.Name as BrigadeName, 
		SEW.Qnt, SEW.Price, SEW.Qnt * SEW.Price as Amount, 
		SEW.Note, 
		SEW.ERPCode 
	from SalaryExtraWorks SEW with (nolock)  
	left join _Users U with (nolock) on SEW.UserID = U.ID 
	left join Brigades B with (nolock) on U.BrigadeID = B.ID '

if @nID is not Null begin
	set @cWhere = ' where SEW.ID = ' + str(@nID) + ' ' 
end 
else begin 
	set @cWhere = ' where 1 = 1 ' 
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and SEW.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	if @dDateBeg is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', SEW.DateWork) >= 0 '
	if @dDateEnd is not Null
		set @cWhere = @cWhere + ' and datediff(day, SEW.DateWork, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and SEW.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
	if @cWorkNameContext is not Null
		set @cWhere = @cWhere + ' and charindex(''' + @cWorkNameContext + ''', SEW.WorkName) > 0 '
end

set @cOrderBy = ' order by '
if @cIDList is not Null
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(SEW.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + ' SEW.DateWork, U.Name, SEW.WorkName '

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return