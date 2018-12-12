-- ������ ���������� �������:
--		1. ����������� � ����������� � �������
--		2. �����������, �� �� ����������� � �������
--		3. �� �����������, �� ����������� � �������

set nocount on

-- �������� ��� ������, ����������� � ������� ��������� N �������
-- ������ �������� ������
-- �� ��������� ���� � ������
declare @nMonthes int
set @nMonthes = 3

if object_id('Tempdb..#Sales') is not Null drop table #Sales
select distinct /*O.Depot as SDepot,*/ P.Good as SGood, P.InBox as SInBox, 
	G.Alias as GoodAlias, IsNull(Od.Qnt, 0) / P.InBox as Boxes 
	into #Sales 
	from WHOutputs O with (nolock) 
	inner join WHOutputsGoods I with (nolock) on I.WHOutput = O.Uniq 
	inner join Packings P with (nolock) on I.Packing = P.Uniq 
	inner join Goods G with (nolock) on P.Good = G.Uniq 
	left join WHOddments Od with (nolock) on Od.Depot = 1 and P.Uniq = Od.Packing 
	where	O.Depot in (select Uniq from Depots where Basic = 1) and 
			O.OutputsType in (1,2) and 
			O.DateOutput >= DateAdd(Month, -@nMonthes, GetDate()) and 
			I.QntConfirmed > 0 and 
			G.Tare = 0 and G.GoodsGroup <> 5 
	order by /*O.Depot,*/ P.Good, P.InBox
print 'All sales packings: ' + str(@@RowCount)

-- ��� ������ � ��������
select Address from WHPicking where Address is not Null
print 'All picking cells : ' + str(@@RowCount)

-- ��� ����������� ������
if object_id('Tempdb..#Rel') is not Null drop table #Rel
select P.Address, /*P.Depot,*/ P.Good, P.InBox, /*S.SDepot,*/ S.SGood, S.SInBox, S.GoodAlias, S.Boxes 
	into #Rel 
	from WHPicking P with (nolock) 
	full outer join #Sales S on P.Good = S.SGood and P.InBox = S.SInBox 
--		P.Depot = S.SDepot and P.Good = S.SGood and P.InBox = S.SInBox 
	order by P.Address/*, S.SDepot*/

-- �������� ������ �������
--delete #Rel where Address is Null /*and SDepot is Null*/

-- 1
select * from #Rel 
	where Address is not Null and SGood is not Null
print 'Sales & rel: ' + str(@@RowCount)

-- 2
select * from #Rel 
	where Address is Null and SGood is not Null 
	order by Boxes desc
print 'Sales but not rel: ' + str(@@RowCount)

-- 3
select * from #Rel 
	where Address is not Null and Good is not Null and SGood is Null 
	order by Boxes desc
print 'Not sales but rel: ' + str(@@RowCount)

