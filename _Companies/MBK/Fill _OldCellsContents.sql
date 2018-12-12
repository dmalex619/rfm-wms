-- Должен быть подготовлен текстовый файл со списком пустых ячеек
if object_id('__Buffer') is not Null drop table __Buffer;
create table __Buffer 
	(Address varchar(20), ERPGood varchar(50), InBox dec(10,3), 
	DateValid varchar(10), Qnt dec(12,3), GoodStateID int);
exec master..xp_cmdshell 'bcp WMS_MBK.dbo.__Buffer in "E:\SuitableWMS\_SQL\Depots\MBK\OldCellsContents.txt" -c -k -C1251 -T';

update __Buffer set Address = left(Address, 2) + '0' + substring(Address, 3, len(Address))
	where substring(Address, 2, 1) = '-' and substring(Address, 4, 1) = '-'
update __Buffer set Address = replace(Address, '-', '.')
update __Buffer set DateValid = left(DateValid, 6) + '20' + right(DateValid, 2)

-- Получение кодов ячейки и упаковки
alter table __Buffer add CellID int Null
alter table __Buffer add PackingID int Null
update __Buffer set CellID = C.ID 
	from Cells C with (nolock) 
	where __Buffer.Address = C.Address
update __Buffer set PackingID = P.ID 
	from Packings P with (nolock) 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where __Buffer.ERPGood = G.ERPCode and __Buffer.InBox = P.InBox
if exists(select * from __Buffer where CellID is Null or PackingID is Null) begin
	raiserror(N'Wrong data!', 16, 1)
	return
end

--select * from __Buffer order by 1

truncate table _OldCellsContents
insert into _OldCellsContents (CellID, OwnerID, GoodStateID, PackingID, DateValid, Qnt)
	select CellID, Null, GoodStateID, PackingID, DateValid, Qnt
	from __Buffer
select * from _OldCellsContents
