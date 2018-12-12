-- Должен быть подготовлен текстовый файл со списком пустых ячеек
if object_id('__Buffer') is not Null drop table __Buffer;
create table __Buffer (Address varchar(20));
exec master..xp_cmdshell 'bcp WMS.dbo.__Buffer in "E:\SuitableWMS\_SQL\Depots\MBK\EmptyCells.txt" -c -k -C1251 -T';

update __Buffer set Address = left(Address, 2) + '0' + substring(Address, 3, len(Address))
	where substring(Address, 2, 1) = '-' and substring(Address, 4, 1) = '-'
update __Buffer set Address = replace(Address, '-', '.')
select * from __Buffer order by 1
/*
select B.Address, C.ID 
	from __Buffer B 
	inner join WMS_MBK.dbo.Cells C on C.Address = B.Address
*/