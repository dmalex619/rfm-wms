-- �� ������ ���������� �������� 19.10.2008 19:55
-- ����������� ���������������� ������ � 12118 (ERPCode = 132635),
-- ������� ������� ��� ������ 18.10.2008 (�������� "����������").
-- ����� �������, ��� ������������� ������� 20.10.2008 ��� ����������
-- ������ � ��������� �������, �� �� ������ � ������, 
-- ��� ��� ��� ���������� ���!
-- ��������������, ��� ������������ �������� ����� Trading & WMS ����� 19.10.2008
-- ��� ������ �� ���� ������.
--
-- ��������� ���������� ������� � ���� �������, 
-- � ����������� �� ��� ���������� ���������� LOST&FOUND
set nocount on

declare @nGoodStateID int, @nPackingID int, @nQnt dec(15,3), @nCCID int

declare _Input cursor static for 
	select GoodStateID, PackingID, sum(Qnt) as Qnt 
		from InputsItems with (nolock) 
		where InputID = 12118 
		group by GoodStateID, PackingID
open _Input

begin tran
fetch next from _Input into @nGoodStateID, @nPackingID, @nQnt
while @@fetch_status = 0 begin
	PRINT str(@nQnt)
	set @nCCID = Null
	select @nCCID = ID 
		from CellsContents 
		where CellID = 4 and 
			OwnerID is Null and 
			GoodStateID = @nGoodStateID and 
			PackingID = @nPackingID
	
	if @nCCID is Null
		insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, 
			DateValid, Qnt, ByOrder, DateLastOperation, ERPCode) 
			select 4, Null, Null, @nGoodStateID, @nPackingID, 
				Null, @nQnt, Null, '20081019 19:59:00', Null
	else
		update CellsContents set 
			Qnt = Qnt + @nQnt, DateLastOperation = '20081019 19:59:00' 
			where ID = @nCCID
	if @@Error <> 0 goto Tr_Error
	
	insert into CellsChanges (CellID, FrameID, OwnerID, GoodStateID, PackingID, 
		Qnt, DateValid, DateEdit, 
		Note, 
		NoteManual, UserID, DeviceID, ParentID, ERPCode)
		select 4, Null, Null, @nGoodStateID, @nPackingID, 
			@nQnt, Null, '20081019 19:59:00', 
			'�������������� ����������� LOST&FOUND ��-�� ����������� ��� ��������� ������� � 12118 (132635)', 
			'', 1, Null, Null, Null
	
	fetch next from _Input into @nGoodStateID, @nPackingID, @nQnt
end

commit tran
goto Tr_Close

Tr_Error:
raiserror(N'Update Error!', 16, 1)
rollback

Tr_Close:
close _Input
deallocate _Input
