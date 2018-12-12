set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_SalaryTariffsDelete]
	@nID		int, 
	@nError		int = 0 output,
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if not exists (select ID from SalaryTariffs where ID = @nID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найдены тарифы с кодом ' + ltrim(str(@nID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

begin tran
	delete SalaryTariffs
		where ID = @nID
	select @nError = @@Error
	if @nError > 0 goto ERR

commit tran
return

ERR:
rollback
return