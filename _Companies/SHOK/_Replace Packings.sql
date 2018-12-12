-- «амена невесовых товаров на весовые
declare @nPackingID int, @nGoodID int, @nNetto dec(15,3)

declare _Packings cursor for
	select P.ID as PackingID, G.ID as GoodID, G.Netto 
		from Packings P with (nolock) 
		inner join Goods G with (nolock) on P.GoodID = G.ID 
		where G.HalfStuff = 1 and G.Weighting = 0 --and G.Netto <> 1.0

open _Packings
fetch next from _Packings into @nPackingID, @nGoodID, @nNetto
begin tran
	while @@fetch_status = 0 begin
		print str(@nPackingID)
		update AuditActsGoods 
			set QntConfirmed = QntConfirmed * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update CellsChanges 
			set Qnt = Qnt * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update CellsContents 
			set Qnt = Qnt * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update InputsGoods 
			set QntWished = QntWished * @nNetto, QntConfirmed = QntConfirmed * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update InputsItems 
			set Qnt = Qnt * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update Oddments 
			set Qnt = Qnt * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update OutputsGoods 
			set QntWished = QntWished * @nNetto, QntSelected = QntSelected * @nNetto, QntConfirmed = QntConfirmed * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update OutputsItems 
			set Qnt = Qnt * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update TrafficsGoods 
			set QntWished = QntWished * @nNetto, QntConfirmed = QntConfirmed * @nNetto 
			where PackingID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update Packings 
			set InBox = InBox * @nNetto 
			where ID = @nPackingID
		if @@Error <> 0 goto Tr_Error
		
		update Goods 
			set Netto = 1.0, Brutto = 1.1, Weighting = 1 
			where ID = @nGoodID
		if @@Error <> 0 goto Tr_Error
		
		fetch next from _Packings into @nPackingID, @nGoodID, @nNetto
	end
commit tran
goto Tr_OK

Tr_Error:
rollback

Tr_OK:
close _Packings
deallocate _Packings
