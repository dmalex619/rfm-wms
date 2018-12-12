select GG.Name as GroupName, G.Name as GoodName, Netto, Brutto
	from Goods G 
	inner join GoodsGroups GG on G.GoodGroupID = GG.ID 
	where (Brutto = 0 or Netto / Brutto not between 0.85 and 1.1)
	and G.Actual = 1 
	and G.HostID = 2
	order by 1,2
