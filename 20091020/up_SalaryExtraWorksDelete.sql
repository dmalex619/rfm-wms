SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_SalaryExtraWorksDelete]
	@nID		int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output
AS

set nocount on

if not exists (select ID from SalaryExtraWorks where ID = @nID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найдена операция с кодом ' + ltrim(str(@nID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

begin tran
	delete SalaryExtraWorks 
		where ID = @nID
	select @nError = @@Error
	if @nError > 0 goto ERR

commit tran
return

ERR:
rollback
return