if object_id('__Acts') is Null return

declare @nGoodStateID int, @nID int, @nError int
declare _CActs cursor for 
	select distinct GoodStateID from __Acts
open _CActs
fetch next from _CActs into @nGoodStateID
while @@fetch_status = 0 begin
	begin tran
		insert into AuditActs (DateAudit, OwnerID, GoodStateID, Note, 
				DateConfirm, OddmentSavedID, ERPCode) 
			select '20090215', 1, @nGoodStateID, '¬ыравнивание остатков по состо€ни€м товара', 
				'20090215', Null, Null
		select @nError = @@Error, @nID = @@Identity
		if @nError <> 0 goto Tr_Error
		
		insert into AuditActsGoods (AuditActID, PackingID, QntConfirmed, ERPCode) 
			select @nID, PackingID, -Diff, Null 
				from __Acts 
				where GoodStateID = @nGoodStateID 
				order by PackingID
		if @@Error <> 0 goto Tr_Error
	commit tran
	goto Tr_End
	
	Tr_Error:
	if @@trancount > 0 rollback
	
	Tr_End:
	fetch next from _CActs into @nGoodStateID
end

close _CActs
deallocate _CActs
