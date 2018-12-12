-- Закрепление ячеек пикинга за упаковками,
-- имеющимися в ожидаемых отгрузках,
-- но не закрепленными через Trading

-- Только для отладки!!! В рабочей БД не применять!!!
-- В отладочной БД должны быть данные об отгрузках!!!

set nocount on

declare @nPackingID int, @nCellID int

-- Получение всех незакрепленных упаковок
declare _Packings cursor for 
	select distinct PackingID 
		from OutputsGoods 
		where PackingID not in 
			(select FixedPackingID from Cells where FixedPackingID is not Null)
open _Packings
fetch next from _Packings into @nPackingID
while @@fetch_status = 0 begin
	select top 1 @nCellID = C.ID 
		from Cells C 
		inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
		where SZT.ShortCode = 'PICK' and C.FixedPackingID is Null 
		order by C.ID desc
	if @@RowCount > 0 
		update Cells set FixedPackingID = @nPackingID where ID = @nCellID
	
	fetch next from _Packings into @nPackingID
end

close _Packings
deallocate _Packings
