-- ������������� CellsContentsSnapshotsEnd �� �������� ���������,
-- �� ��� �� ������������ �������
-- ��������� ��������� �������� ����� ����������� � ������� ��������
-- � ����������� � ��������� �������, � ��������� �� ����� ����������� LOST&FOUND
if db_name() <> 'WMS' return

set nocount on

-- ��������� ��� ������������ ����� ��������
declare @nCCSnapshotID int
set @nCCSnapshotID = 10

-- �������� ����� �������� � �������� ����� ��������
declare @dDateBeg datetime, @dDateEnd datetime
select @dDateBeg = DateBeg, @dDateEnd = DateEnd 
	from CellsContentsSnapshots 
	where ID = IsNull(@nCCSnapshotID, 0)
if @@RowCount = 0 begin
	raiserror(N'Cell Content Snapshot with ID %i hasn`t found!', 16, 1, @nCCSnapshotID)
	return
end

-- ����� ���� ���� �������, �� �������������� �� ������ �������� ����� ��������,
-- �� ������� ������� (��������� ��� ����������),
-- ����������� �� ������� �������� ����� ��������
if object_id('Tempdb..#PickedOutputs') is not Null drop table #PickedOutputs
select ID 
	into #PickedOutputs 
	from Outputs 
	where	(DateConfirm is Null or DateConfirm > @dDateEnd) and 
			(ID in (select distinct OutputID from OutputsItems where DateConfirm < @dDateEnd))
	order by 1
--select * from #PickedOutputs

-- �������� ���������� ��������� ������� �� ���� �������
if object_id('Tempdb..#PickedGoods') is not Null drop table #PickedGoods
select OI.CellID, 
		case when P.SeparatePicking = 1 then O.OwnerID else Null end as OwnerID, 
		OI.GoodStateID, 
		OI.PackingID, 
		sum(OI.Qnt) as Qnt 
	into #PickedGoods 
	from #PickedOutputs X 
	inner join Outputs O on O.ID = X.ID 
	inner join OutputsItems OI on OI.OutputID = O.ID 
	left join Partners P on O.OwnerID = P.ID 
	where OI.DateConfirm < @dDateEnd 
	group by OI.CellID, case when P.SeparatePicking = 1 then O.OwnerID else Null end, OI.GoodStateID, OI.PackingID 
	order by 1,2,3,4
--select * from #PickedGoods

-- ���������� �������� ��� ������������ ��������������
if object_id('__Differences') is not Null drop table __Differences
create table __Differences (OwnerID int, GoodStateID int, PackingID int, Qnt dec(18,3))
	
-- �������� ������ � ������ �������
declare @nOutID int, @nLFID int, @nOutQnt dec(18,3), @nLFQnt dec(18,3), @nDiff dec(18,3)
declare @nCellID int, @nOwnerID int, @nGoodStateID int, @nPackingID int, @nQnt dec(18,3)
declare _Goods cursor for 
	select CellID, OwnerID, GoodStateID, PackingID, Qnt 
		from #PickedGoods 
		order by CellID, OwnerID, GoodStateID, PackingID
open _Goods
fetch next from _Goods into @nCellID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt

while @@fetch_status = 0 begin
	-- ��������� ����������
	select @nOutID = Null, @nLFID = Null, @nOutQnt = 0, @nLFQnt = 0
	
	-- ����� � ����� �������� ������ � ������� ��������
	select @nOutID = ID, @nOutQnt = Qnt 
		from CellsContentsSnapshotsEnd 
		where	CellContentSnapshotID = @nCCSnapshotID and 
				CellID = @nCellID and 
				IsNull(OwnerID, 0) = IsNull(@nOwnerID, 0) and 
				GoodStateID = @nGoodStateID and 
				PackingID = @nPackingID
	
	-- ����� � ����� �������� ������ � ������� LOST&FOUND
	select @nLFID = ID, @nLFQnt = Qnt 
		from CellsContentsSnapshotsEnd 
		where	CellContentSnapshotID = @nCCSnapshotID and 
				CellID = 4 and 
				IsNull(OwnerID, 0) = IsNull(@nOwnerID, 0) and 
				GoodStateID = @nGoodStateID and 
				PackingID = @nPackingID
	
	-- ��������� ��������
	set @nDiff = IsNull(@nQnt, 0) - IsNull(@nOutQnt, 0)
	if (@nDiff <> 0) begin
		print str(@nPackingID) + str(@nDiff, 18, 3) + str(IsNull(@nOutID, -1)) + str(IsNull(@nLFID, -1))
		begin tran
			-- ������������� ��������
			insert __Differences (OwnerID, GoodStateID, PackingID, Qnt) 
				select @nOwnerID, @nGoodStateID, @nPackingID, @nDiff
			
			-- ��������� ���-�� � ������� ��������
			if (@nOutID is not Null) 
				update CellsContentsSnapshotsEnd set Qnt = Qnt + @nDiff where ID = @nOutID
			else
				insert CellsContentsSnapshotsEnd (CellContentSnapshotID, 
						CellID, Locked, FrameID, OwnerID, GoodStateID, PackingID, 
						DateValid, Qnt, DateLastOperation) 
					select @nCCSnapshotID, @nCellID, 0, Null, @nOwnerID, @nGoodStateID, @nPackingID, 
						Null, @nDiff, GetDate()
			if @@Error <> 0 goto Tr_Error
			
			-- ��������� ���-�� � ������ LOST&FOUND
			if (@nLFID is not Null) 
				update CellsContentsSnapshotsEnd set Qnt = Qnt - @nDiff where ID = @nLFID
			else
				insert CellsContentsSnapshotsEnd (CellContentSnapshotID, 
						CellID, Locked, FrameID, OwnerID, GoodStateID, PackingID, 
						DateValid, Qnt, DateLastOperation) 
					select @nCCSnapshotID, 4, 0, Null, @nOwnerID, @nGoodStateID, @nPackingID, 
						Null, -@nDiff, GetDate()
			if @@Error <> 0 goto Tr_Error
		commit tran
		goto Tr_Next
		
		Tr_Error:
		rollback
	end
	
	Tr_Next:
	fetch next from _Goods into @nCellID, @nOwnerID, @nGoodStateID, @nPackingID, @nQnt
end

close _Goods
deallocate _Goods
