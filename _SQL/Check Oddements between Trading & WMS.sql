-- ��������� �������� ����� Trading & WMS
-- �� ����������� ��������� ������, ���� � ������
-- ����������� ����� ���� �� �������� ���������������� � WMS ��������
use Trading
go

select distinct GG.Alias as GroupAlias, G.Alias as GoodAlias, 
	P.Good as TradingGood, P.InBox, 
	IsNull(T.Qnt, 0.000) as TQnt, IsNull(W.Qnt, 0.000) as WQnt, 
	(IsNull(T.Qnt, 0.000) - IsNull(W.Qnt, 0.000)) as QntDiff, 
	(IsNull(T.Qnt, 0.000) - IsNull(W.Qnt, 0.000)) / P.InBox as BoxDiff 
from Goods G with (nolock) 
inner join GoodsGroups GG with (nolock) on G.GoodsGroup = GG.Uniq 
inner join Packings P with (nolock) on P.Good = G.Uniq 
left join (select TP.Good, TP.InBox, sum(TOd.Qnt) as Qnt 
	from WHOddments TOd with (nolock) 
	inner join Depots D on TOd.Depot = D.Uniq 
	inner join Packings TP with (nolock) on TOd.Packing = TP.Uniq 
	inner join Goods TG with (nolock) on TP.Good = TG.Uniq
	where TG.Tare = 0 and TG.GoodsGroup <> 5 and D.RemoteDepot is Null 
	group by TP.Good, TP.InBox) T on P.Good = T.Good and P.InBox = T.InBox
left join (select WG.ERPCode as Good, WP.InBox, sum(cast(WO.Qnt as dec(18,3))) as Qnt
--	from WMS.dbo.CellsContents WO with (nolock)			/* last check 13.02.2009 */
	from WMS.dbo.Oddments WO with (nolock) 
	inner join WMS.dbo.Packings WP with (nolock) on WO.PackingID = WP.ID
	inner join WMS.dbo.Goods WG with (nolock) on WP.GoodID = WG.ID 
	where WO.OwnerID is Null 
	group by WG.ERPCode, WP.InBox) W on cast(P.Good as varchar(50)) = W.Good and P.InBox = W.InBox
where IsNull(T.Qnt, 0.000) <> IsNull(W.Qnt, 0.000)
--where P.Good = 7940
--group by G.Alias, P.InBox 
order by 1,2
