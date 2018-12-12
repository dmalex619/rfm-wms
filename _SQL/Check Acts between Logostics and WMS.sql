-- Check Acts between Logostics and WMS
select *
from (
	select 'L.ACT.' + replace(str(LA.ID, 10), ' ', '0') as LERPCode, 
		count(LAG.ID) as LCount
		from Acts LA with (nolock)
		inner join ActsGoods LAG with (nolock) on LAG.ActID = LA.ID
		group by LA.ID
		) X
left join (
	select WA.ERPCode as WERPCode, 
		count(WAG.ID) as WCount
		from wms.dbo.AuditActs WA with (nolock)
		inner join wms.dbo.AuditActsGoods WAG with (nolock) on WAG.AuditActID = WA.ID
		group by WA.ERPCode
) Y on X.LERPCode = Y.WERPCode
where LCount <> WCount
