select convert(varchar(10), I.DateInput, 104) as DateInput, I.ERPCode, I.ID, Pr.Name as PartnerName, 
	GG.Name as GroupName, G.Alias as GoodName, P.InBox, IG.QntConfirmed 
	from Inputs I
	inner join InputsGoods IG on IG.InputID = I.ID
	inner join Partners Pr on I.PartnerID = Pr.ID 
	inner join Packings P on IG.PackingID = P.ID 
	inner join Goods G on P.GoodID = G.ID 
	inner join GoodsGroups GG on G.GoodGroupID = GG.ID 
	where I.InputTypeID = 2 and I.DateConfirm is not Null and IG.QntConfirmed >= 1000
	order by I.DateInput,2,3,4
