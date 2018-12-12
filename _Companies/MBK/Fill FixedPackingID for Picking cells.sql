-- Должен быть подготовлен текстовый файл со списком
-- ячеек пикинга и их привязкой (товар + штук в кор.)
if object_id('__Buffer') is not Null drop table __Buffer;
create table __Buffer 
	(Address varchar(20), GoodName varchar(100), ERPGood varchar(50), InBox dec(10,3))
exec master..xp_cmdshell 'bcp WMS_MBK.dbo.__Buffer in "E:\SuitableWMS\_SQL\Depots\MBK\MBK_Picking_Fixed.txt" -c -k -C1251 -T';

-- Выбрасываем пустые ячейки
--delete __Buffer where len(GoodName) = 0

-- Линия Z1
update __Buffer set Address = '@' + substring(Address, 3, len(Address))
	where left(Address, 2) = 'Z1'
-- Стояк
update __Buffer set Address = left(Address, 2) + '0' + substring(Address, 3, len(Address))
	where substring(Address, 2, 1) = '-' and substring(Address, 4, 1) = '-'
-- Ячейка
update __Buffer set Address = left(Address, 7) + '0' + substring(Address, 8, len(Address))
	where substring(Address, 2, 1) = '-' and substring(Address, 5, 1) = '-' and substring(Address, 7, 1) = '-' and len(Address) = 8
-- Линия Z1 опять
update __Buffer set Address = 'ZZ' + substring(Address, 2, len(Address))
	where left(Address, 1) = '@'

update __Buffer set Address = replace(Address, '-', '.')

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
if exists(select * from __Buffer where CellID is Null or (len(GoodName) > 0 and PackingID is Null)) begin
	raiserror(N'Wrong data!', 16, 1)
--	return
end

-- Добавление отсутствующих ячеек пикинга
insert into Cells (StoreZoneID, PalletTypeID, CBuilding, 
	CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, GoodsMono, MaxPalletQnt, 
	BufferCellID, Rank, State, IsFull, Locked, Actual, Deleted, ERPCode) 
	select 7, Null, '', 
		case when left(Address, 2) = 'ZZ' then 'ZZ' else left(Address, 1) end as CLine, 
		case when left(Address, 2) = 'ZZ' then substring(Address, 4, 2) else substring(Address, 3, 2) end as CRack, 
		case when left(Address, 2) = 'ZZ' then substring(Address, 7, 1) else substring(Address, 6, 1) end as CLevel, 
		right(Address, 2) as CPlace, 
		Address, 
		0.0, 0.0, 0.0, 1, 1.0, 
		Null, 0, Null, 0, 0, 0, 0, Null 
		from __Buffer 
		where CellID is Null
		order by 1

-- Добавление привязок
update Cells set FixedGoodStateID = 1, FixedPackingID = X.PackingID 
	from __Buffer X 
	where Cells.ID = X.CellID
