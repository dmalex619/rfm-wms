select G.ERPCode, G.Alias, P.InBox, X.PCount
from Goods G
inner join Packings P on P.GoodID = G.ID
inner join (
select PackingID, count(*) as PCount
from CellsContents
where CellID in 
	(select C.ID from Cells C 
		inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
		where SZT.ShortCode = 'PICK')
group by PackingID
having count(*) > 1) X on P.ID = X.PackingID
