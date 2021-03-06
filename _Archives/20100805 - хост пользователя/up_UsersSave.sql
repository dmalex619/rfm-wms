SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_UsersSave]
	@nUserID	int = 0 output,   -- Users.ID
	@cUserName	varchar(50),
	@nBrigadeID int, 
	@cPassword	varchar(20),
	@cAlias		varchar(20),
	@cLocPath	varchar(50), 
	@cNetPath	varchar(50), 
	@bIsAdmin	bit, 
	@bActual	bit, 
	@nHostID	int, 
	@nError		int = 0 output,
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	IsNull(@nUserID, 0) <> 0 and 
		not exists (select ID from _Users where ID = @nUserID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найден пользователь с кодом ' + ltrim(str(@nUserID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

begin transaction
	if IsNull(@nUserID, 0) = 0 begin
		-- добавляем запись
		insert _Users (Name, Password, Alias, LocPath, NetPath, IsAdmin, Actual, BrigadeID, HostID) 
			values (@cUserName, @cPassword, @cAlias, @cLocPath, @cNetPath, @bIsAdmin, @bActual, @nBrigadeID, @nHostID)
		select	@nUserID = @@Identity, @nError = @@Error
		if @nError <> 0 goto ERR
		
		-- история нахождения в бригаде
		insert BrigadesHistory (DateChange, UserID, BrigadeID) 
			values (convert(varchar(10), GetDate(), 112), @nUserID, @nBrigadeID)
		if @nError <> 0 goto ERR
	end
	else begin
		-- запрос текущей бригады
		declare @nOldBrigadeID int
		select @nOldBrigadeID = BrigadeID 
			from _Users where ID = @nUserID
		
		-- будем редактировать
		update _Users 
			set Name = @cUserName, 
				Password = @cPassword, 
				Alias = @cAlias, 
				LocPath = @cLocPath, NetPath = @cNetPath, 
				IsAdmin = @bIsAdmin, 
				Actual = @bActual, 
				BrigadeID = @nBrigadeID, 
				HostID = @nHostID 
			where ID = @nUserID
		if @@Error > 0 goto ERR
		
		if IsNull(@nOldBrigadeID, -1) <> IsNull(@nBrigadeID, -1) begin
			-- история нахождения в бригаде
			delete BrigadesHistory 
				where	UserID = @nUserID and 
						DateChange = (convert(varchar(10), GetDate(), 112))
			if @nError <> 0 goto ERR
			
			insert BrigadesHistory (DateChange, UserID, BrigadeID) 
				values (convert(varchar(10), GetDate(), 112), @nUserID, @nBrigadeID)
			if @nError <> 0 goto ERR
		end
	end
	
	if object_id('tempdb..#RolesForUser') is not Null begin
		delete #RolesForUser where IsUsed = 0
		
		select RoleID 
			into #Old_RolesForUser 
			from _UsersRoles 
			where UserID = @nUserID
		
		-- роли были назначены, теперь - нет
		delete _UsersRoles 
			where	UserID = @nUserID and 
					RoleID not in (select RoleID from #RolesForUser)
		if @@Error > 0 goto ERR
		
		-- роль не были назначены, теперь - да
		insert _UsersRoles (UserID, RoleID, Actual) 
			select @nUserID, RoleID, 1 
				from #RolesForUser 
				where RoleID not in (select RoleID from #Old_RolesForUser)
		if @@Error > 0 goto ERR
	end

commit transaction
return

ERR:
rollback transaction
return