set nocount on

declare @nOldID int, @nNewID int, @nError int

set @nOldID = 76140
begin tran
	insert AuditActs 
			(DateAudit, OwnerID, GoodStateID, Note, DateConfirm, OddmentSavedID, ERPCode, HostID) 
		select DateAudit, OwnerID, GoodStateID, Note, Null, Null, ERPCode, HostID 
		from AuditActs 
		where ID = @nOldID
	select @nNewID = @@identity, @nError = @@error
	if @nError <> 0 goto tr_err
	
	insert AuditActsGoods 
			(AuditActID, PackingID, QntConfirmed, ERPCode) 
		select @nNewID, PackingID, -QntConfirmed, ERPCode 
		from AuditActsGoods 
		where AuditActID = @nOldID
	select @nError = @@error
	if @nError <> 0 goto tr_err
	
commit tran
exec up_AuditActsConfirm @nNewID, null, null

goto tr_end

tr_err:
rollback tran

tr_end:
return
