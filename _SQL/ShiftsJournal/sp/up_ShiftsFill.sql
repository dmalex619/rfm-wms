SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE up_ShiftsFill
	@nID			int				= Null, 
	@cIDList		varchar(max)	= Null, -- ������ Shifts.ID (����� ,) 
	@dDateBeg		smalldatetime	= Null, -- ���� ���.�������
	@dDateEnd		smalldatetime	= Null, -- ���� ���.�������
	@cMajorsList	varchar(max)	= Null, -- ������ ID ������� ����������� � ����� (�����,)
	@bIsNight		bit				= Null	-- ������� ������ �������/������ ����
AS
-- ��������� ������ ����

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

set @cSelect = 
'select	S.ID, S.ID as ShiftID, 
		S.DateBeg, S.DateEnd, 
		DateDiff(Hour, S.DateBeg, S.DateEnd) as Duration, 
		S.MajorID, U.Name as MajorName, 
		S.IsNight, 
		S.Note 
	from Shifts S with (nolock) 
	inner join _Users U with (nolock) on S.MajorID = U.ID '

if @nID is not Null begin
	set @cWhere = ' where S.ID = ' + str(@nID) + ' ' 
end 
else begin
	set @cWhere = ' where 1 = 1 ' 
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and S.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @dDateBeg is not Null
		set @cWhere = @cWhere + ' and DateBeg >= ''' + convert(varchar, @dDateBeg, 126) + ''' '
	if @dDateEnd is not Null
		set @cWhere = @cWhere + ' and DateEnd <= ''' + convert(varchar, @dDateEnd, 126) + ''' '
	
	if @cMajorsList is not Null
		set @cWhere = @cWhere + ' and S.MajorID in (' + dbo._NormalizeList(@cMajorsList) + ') '
	
	if @bIsNight is not Null
		set @cWhere = @cWhere + ' and S.IsNight = ' + cast(@bIsNight as varchar(1))
end

set @cOrderBy = ' order by S.DateBeg '
set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return