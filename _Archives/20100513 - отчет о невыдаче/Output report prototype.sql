select	O.DateOutput, 
		Own.Name as OwnerName, IsNull(Prt.Name, '') as PartnerName, 
		O.ERPCode, 
		G.Alias as GoodName, P.InBox, 
		OG.QntWished, OG.QntSelected, /*X.QntPicked,*/ OG.QntConfirmed 
	from Outputs O with (nolock) 
	inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
	inner join Packings P with (nolock) on OG.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	--inner join (select Picked) on 
	inner join Partners Own with (nolock) on O.OwnerID = Own.ID 
	left join Partners Prt with (nolock) on O.PartnerID = Prt.ID 
	where	O.DateOutput between '20100501' and '20100505' and 
			O.DateConfirm is not Null and 
			G.Weighting = 0 and 
			--(OG.QntWished > OG.QntSelected /*or OG.QntWished > X.QntPicked*/ or OG.QntWished > OG.QntConfirmed) 
			(OG.QntWished > OG.QntConfirmed) 
	order by 1,2,3,4,5,6
