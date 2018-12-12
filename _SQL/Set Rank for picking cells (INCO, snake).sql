-- �������������� ���������� ����� ������� ������� 
-- � ������������ ����� ������ ����-���������
-- ������ ������ ����������� ������� ��������������� WMS
-- ���������� ������� - ���������� ������ "�������" 
-- ��� ������� 3-�� � 4-�� �������

-- ����� �������� ���� ������� � ������ 3P.01.1.1,
-- ������� ����� ������� P & O �� ����������� ������� ������� � �����,
-- � ������ ������ ����������� � ��������� ������,
-- ������� ����� ������� N & M �� �������� ������� ������� � �����,
-- � ��� �����.
-- ����� ��������� ����� ������� �� ������ 3 �� ��������� �� ����� 4,
-- � ��� ��������� ��� ���������, ������� � ������ 4V.01.1.1

if db_name() <> 'WMS' return

set nocount on

-- ��������� ��������� ������� ��� ���������� ����� �������
if object_id('Tempdb..#Cells') is not Null drop table #Cells
select ID, Rank, CBuilding, CLine, CRack, CLevel, CPlace, 
	Ascii(CLine) as LineNum, Ascii(CLine) as Aisle, 
	cast(CRack as int) as NRack, cast(CPlace as int) as NPlace 
	into #Cells 
	from Cells 
	where StoreZoneID in (24, 14) and Deleted = 0 
	order by CBuilding, CLine desc, CRack, CLevel, CPlace
alter table #Cells add constraint _PK_Cells primary key (ID)

-- ����� <P> ������ 3 ���������� �� 2-�� ������,
-- ������� ����������� ��������� ��� ������� �� 1
update #Cells set NRack = NRack + 1 where CBuilding = '3' and CLine = 'P'

-- "�����" �������� ����������� ������ �������� ��� �������� �����
update #Cells set Aisle = LineNum + 1 where LineNum % 2 = 1
update #Cells set Aisle = Aisle + 2 where CBuilding = '4'

-- ����������� ��������, � ������� �������� ���������� �� ������� ������,
-- ������ ������, � ��������� - ��������
update #Cells set Aisle = Aisle / 2

-- ������ ������ ������� � ����� �������������� ��� �������� ��������
update #Cells set NRack = -NRack, NPlace = -NPlace where Aisle % 2 = 1

-- ��������� ������� "�������" (��������)
/*
select * 
	from #Cells 
	order by CBuilding, Aisle desc, NRack, CLevel, NPlace, CLine desc
*/

-- ������� ���������� ��� ���������� �����
declare @nID int, @nRank int
set @nRank = 0

-- ������� ������ ��� ���������� �����
declare _Cells cursor for 
	select ID from #Cells 
		order by CBuilding, Aisle desc, NRack, CLevel, NPlace, CLine desc
open _Cells

-- �������� ���� �� ��������� �������
fetch next from _Cells into @nID
while @@fetch_status = 0 begin
	set @nRank = @nRank + 1
	update #Cells set Rank = @nRank where ID = @nID
	
	fetch next from _Cells into @nID
end

close _Cells
deallocate _Cells


-- �������� � �������� ������������ �����
update Cells set Rank = 0 
	where ID in (select ID from #Cells)
update Cells set Rank = X.Rank 
	from #Cells X 
	where Cells.ID = X.ID

select * 
	from #Cells 
	where ID in (select ID from #Cells) 
	order by Rank
