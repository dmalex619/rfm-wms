set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_SalaryTariffsFill]
	@nID	int = null, 
	@dDate	smalldatetime = Null
AS

set nocount on

declare @cSelect varchar(max)
if @dDate is Null begin 
	set @cSelect = 
	'select ST.*, U.Name as UserName 
		from SalaryTariffs ST with (nolock) 
		left join _Users U with (nolock) on ST.UserID = U.ID '
	if @nID is Null begin
		set @cSelect = @cSelect + 
			' where 1 = 1 '
	end
	else begin
		set @cSelect = @cSelect + 
			' where ST.ID = ' + str(@nID)
	end
end
else begin
	set @cSelect = 
	'select top 1 ST.*, U.Name as UserName 
		from SalaryTariffs ST with (nolock) 
		left join _Users U with (nolock) on ST.UserID = U.ID 
		where datediff(day, ST.DateBeg, ''' + convert(varchar, @dDate, 112) + ''') >= 0 '
end 
set @cSelect = @cSelect + ' order by DateBeg desc '
exec (@cSelect)
return