set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_SalaryExtraWorksSave]
	@nID		int = 0 output, 
	@dDateWork 	smalldatetime, 
	@cWorkName 	varchar(250), 
	@nUserID 	int, 
	@nQnt 		decimal(6, 1), 
	@nPrice 	money,  
	@cNote		varchar(250), 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output
AS

set nocount on

if	IsNull(@nID, 0) <> 0 and 
		not exists (select ID from SalaryExtraWorks where ID = @nID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найдена операция с кодом ' + ltrim(str(@nID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

begin tran
	if IsNull(@nID, 0) = 0 begin
		insert	SalaryExtraWorks 
			(DateWork, WorkName, UserID, Qnt, Price, Note) 
			values (@dDateWork, @cWorkName, @nUserID, @nQnt, @nPrice, @cNote)
		select	@nID = @@identity, @nError = @@Error
		if @nError <> 0 goto ERR
	end
	else begin
		update SalaryExtraWorks 
			set DateWork = @dDateWork, WorkName = @cWorkName, UserID = @nUserID, 
				Qnt = @nQnt, Price = @nPrice, Note = @cNote 
			where ID = @nID
		select @nError = @@Error
		if @nError <> 0 goto ERR
	end

commit tran
return

ERR:
rollback
return