select GG.Name as GroupName, 
	G.Alias + ' (' + ltrim(str(P.InBox, 10, 3)) + ')' as GoodName, 
	sum(CC.Qnt) as Qnt 
	from CellsContents CC 
	inner join Cells C on CC.CellID = C.ID 
	inner join Packings P on CC.PackingID = P.ID 
	inner join Goods G on P.GoodID = G.ID 
	inner join GoodsGroups GG on G.GoodGroupID = GG.ID 
	where left(G.ERPCode, 2) <> 'TM' and C.CLevel = 1 
	group by GG.Name,G.Alias + ' (' + ltrim(str(P.InBox, 10, 3)) + ')'
	order by 1,2
