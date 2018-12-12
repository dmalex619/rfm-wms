SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION GetShiftID
(
	@dDateTime	smalldatetime
)
RETURNS int
AS
-- ��������� ID ����� ��� ��������� ������� �������
-- ������������, ��� ����� �� ������������
BEGIN
	declare @nID int
	select top 1 @nID = ID 
		from Shifts with (nolock) 
		where @dDateTime >= DateBeg and @dDateTime < DateEnd
	return @nID
END
GO