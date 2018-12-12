select GG.Name as GroupAlias, G.Alias as GoodAlias, P.InBox, Y.Qnt
from (select PackingID, sum(QntConfirmed) as Qnt 
		from MovingsGoods MG with (nolock)
		inner join (select ID from Movings with (nolock) 
					where DateDiff(Day, DateMoving, '20120526') = 0 and CellSourceID > 3) X
				on X.ID = MG.MovingID 
		group by PackingID) Y
inner join Packings P with (nolock) on Y.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
order by 1,2