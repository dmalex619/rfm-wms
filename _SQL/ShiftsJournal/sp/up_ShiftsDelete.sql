SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE up_ShiftsDelete
	@nShiftID		int, 
	@nError			int = 0 output,
	@cErrorText		varchar(200) = '' output
AS

if not exists (select ID from Shifts where ID = @nShiftID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найденa смена с кодом ' + ltrim(str(@nShiftID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

begin transaction
	delete Shifts 
		where ID = @nShiftID
	select @nError = @@Error
	if @nError > 0 goto ERR

commit transaction
return

ERR:
rollback transaction
return