-- Привязка фиксированных упаковок для пикинга в WMS
-- по данным из Trading

set nocount on

update Cells set FixedPackingID = Null
update Cells set FixedPackingID = T.PackingID
from (
	select C.ID as CellID, P.ID as PackingID
		from Cells C 
		inner join Trading.dbo.WHPicking WP on replace(C.Address, '.', '') = WP.Address 
		inner join Goods G on G.ERPCode = WP.Good 
		inner join Packings P on P.GoodID = G.ID and P.InBox = WP.InBox
	) T 
where Cells.ID = T.CellID
