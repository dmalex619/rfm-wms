select	A.ID, O.Name as OwnerName, GS.Name as GoodStateName, 
		GG.Name as GroupAlias, G.Alias as GoodAlias, P.InBox, 
		AG.QntConfirmed, AG.QntConfirmed * Trading.dbo.GetOneGoodCost(G.ERPCode, getdate(), 1) as Cost 
	from AuditActs A with (nolock) 
	inner join AuditActsGoods AG with (nolock) on AG.AuditActID = A.ID 
	inner join Partners O with (nolock) on A.OwnerID = O.ID 
	inner join Packings P with (nolock) on AG.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	inner join GoodsStates GS with (nolock) on A.GoodStateID = GS.ID 
	where A.ID = 52233
