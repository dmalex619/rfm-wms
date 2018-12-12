declare @nPackingID int
set @nPackingID = 7840

select * from AuditACtsGoods where PackingID = @nPackingID
select * from CellsChanges where PackingID = @nPackingID
select * from CellsContents where PackingID = @nPackingID
select * from InputsGoods where PackingID = @nPackingID
select * from InputsItems where PackingID = @nPackingID
select * from MovingsGoods where PackingID = @nPackingID
select * from Oddments where PackingID = @nPackingID
select * from OutputsGoods where PackingID = @nPackingID
select * from OutputsItems where PackingID = @nPackingID
select * from TrafficsGoods where PackingID = @nPackingID
