select convert(varchar(10), I.DateConfirm, 112) as DateOper, I.ERPCode, 
	GI.Alias + ' (' + ltrim(str(PkI.InBox, 15, 3)) + ')' as GoodAlias, 
	cast(IG.QntConfirmed as dec(15,3)) as QntPlus, cast(0 as dec(15,3)) as QntMinus 
	from Inputs I with (nolock) 
	inner join InputsGoods IG with (nolock) on IG.InputID = I.ID 
 	inner join Packings PkI with (nolock) on IG.PackingID = PkI.ID
	inner join Goods GI with (nolock) on PkI.GoodID = GI.ID
	where	I.DateConfirm >= '20081027' and 
			I.OwnerID = 14217 and 
			IG.QntConfirmed > 0 
union all
select convert(varchar(10), O.DateConfirm, 112) as DateOper, O.ERPCode, 
	GO.Alias + ' (' + ltrim(str(PkO.InBox, 15, 3)) + ')' as GoodAlias, 
	cast(0 as dec(15,3)) as QntPlus , cast(OG.QntConfirmed as dec(15,3)) as QntMinus 
	from Outputs O with (nolock) 
	inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
 	inner join Packings PkO with (nolock) on OG.PackingID = PkO.ID
	inner join Goods GO with (nolock) on PkO.GoodID = GO.ID
	where	O.DateConfirm >= '20081027' and 
			O.OwnerID = 14217 and 
			OG.QntConfirmed > 0 
union all
select convert(varchar(10), A.DateConfirm, 112) as DateOper, A.ERPCode, 
	GA.Alias + ' (' + ltrim(str(PkA.InBox, 15, 3)) + ')' as GoodAlias, 
	cast(case when AG.QntConfirmed > 0 then AG.QntConfirmed else 0 end as dec(15,3)) as QntPlus , 
	cast(case when AG.QntConfirmed < 0 then -AG.QntConfirmed else 0 end as dec(15,3)) as QntMinus 
	from AuditActs A with (nolock) 
	inner join AuditActsGoods AG with (nolock) on AG.AuditActID = A.ID 
 	inner join Packings PkA with (nolock) on AG.PackingID = PkA.ID
	inner join Goods GA with (nolock) on PkA.GoodID = GA.ID
	where	A.DateConfirm >= '20081027' and 
			A.OwnerID = 14217 and 
			AG.QntConfirmed <> 0 
order by 1,2,3