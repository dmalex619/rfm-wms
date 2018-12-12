-- ����� ���������� ���� ����� ������� �� 12.10.2008
-- �� ��������� ������� �������� ������
-- ������ ���:
-- 1. � Trading ���� ��� ��������, ������������ ������ ������������
--    ������� � ����� �� ��������� ����� + � ���. ��� ���� ����� >= 0
--    ��������, "������ ������� �� 200�":
--    � �������� 6731 (30�88) 1440 ��.
--    � �������� 6681 (30�77)  -60 ��.
-- 2. �������� ����, �� ����������� ������ ����������
--    ��������, "������� � ������� �� 350�", �������� 7591 (10�98)
--    _���� ��������		-450 ��.
--    �������������������	1310 ��.
--
-- ������ ������ ��������� 1-� �������
-- 2-� ������� ������ ���� ��������� ����� ������/������ �����

if object_id('Tempdb.dbo.#Goods') is not Null drop table #Goods
if object_id('Tempdb.dbo.#Result') is not Null drop table #Result
if object_id('Tempdb.dbo.#Odds') is not Null drop table #Odds

-- ��������� ������ ���� �������
select distinct GS.Alias as GoodStateAlias, GG.Alias as GoodGroupAlias, G.Alias as GoodAlias, 
	G.Uniq as ERPGood, P.InBox, GS.Uniq as ERPGoodState, G.Actual as GoodActual 
into #Goods 
from 
	Trading.dbo.Goods G with (nolock), 
	Trading.dbo.WMSGoodsStates GS with (nolock), 
	Trading.dbo.Packings P with (nolock), 
	Trading.dbo.GoodsGroups GG with (nolock)  
where P.Good = G.Uniq and G.GoodsGroup = GG.Uniq and 
	G.Tare = 0 and G.GoodsGroup <> 5 and G.Uniq <> 4602 
order by 1,2

-- ���������� ���� "��� �������� Trading"
select *, cast(Null as int) as Packing 
	into #Result 
	from #Goods
update #Result 
	set Packing = 
		(select max(Uniq) 
		from Packings P 
		where	P.Good = #Result.ERPGood and
				P.InBox = #Result.InBox and P.Actual = 1)
	where Packing is Null
update #Result 
	set Packing = 
		(select max(Uniq) 
		from Packings P 
		where	P.Good = #Result.ERPGood and
				P.InBox = #Result.InBox)
	where Packing is Null
if exists(select top 1 * from #Result where Packing is Null) begin
	raiserror(N'���� ������� �������� ����������� �����...', 11, 1)
	return
end

-- ��������� ���������� �������� � ��������
select D.WMSGoodState, P.Good, P.InBox, O.Packing, O.Qnt 
	into #Odds 
	from WHOddments O 
	inner join Depots D on O.Depot = D.Uniq 
	inner join Packings P on O.Packing = P.Uniq 
	where D.Owner = 4 and D.RemoteDepot is Null and O.Qnt <> 0
	order by D.WMSGoodState, P.Good, P.InBox
delete #Odds 
	where str(WMSGoodState) + '_' + str(Good) + '_' + str(InBox,10,3) not in 
		(select str(WMSGoodState) + '_' + str(Good) + '_' + str(InBox,10,3) 
			from #Odds 
			group by WMSGoodState, Good, InBox
			having count(*) > 1)

-- �������� ������� ��� ��������� ����������
if object_id('Trading.dbo.__InventoryResult3') is not Null drop table Trading.dbo.__InventoryResult3
create table __InventoryResult3 (WMSGoodState int, Packing int, Qnt dec(18,3))

-- �������� ������� �� ���������� ���������
declare @nMainPacking int
declare @nWMSGoodState int, @nGood int, @nInBox dec (10,3), @nPacking int, @nQnt dec (18,3)
declare _Double cursor static for 
	select WMSGoodState, Good, InBox, Packing, Qnt 
		from #Odds 
		order by 1,2
open _Double
fetch next from _Double into @nWMSGoodState, @nGood, @nInBox, @nPacking, @nMainPacking

while @@fetch_status = 0 begin
	-- �������� �� ������������� ��������
	if exists (select Packing from #Result where Packing = @nPacking) goto Tr_Next
	
	-- �������� ���: ���� �������� ��������
	-- � ������ �� ���� "+", � �� ������ ����� "-"
	set @nMainPacking = Null
	select @nMainPacking = Packing 
		from #Result 
		where ERPGoodState = @nWMSGoodState and ERPGood = @nGood and InBox = @nInBox
	if @nMainPacking is Null begin
		raiserror(N'Unknown packing!', 16,1)
		return
	end
	
	-- MainPacking
	if exists (select Packing from __InventoryResult3 
		where WMSGoodState = @nWMSGoodState and Packing = @nMainPacking)
		update __InventoryResult3 set Qnt = Qnt + @nQnt 
			where WMSGoodState = @nWMSGoodState and Packing = @nMainPacking
	else
		insert into __InventoryResult3 (WMSGoodState, Packing, Qnt) 
			values (@nWMSGoodState, @nMainPacking, @nQnt)
	
	-- Current Packing
	insert into __InventoryResult3 (WMSGoodState, Packing, Qnt) 
		values (@nWMSGoodState, @nPacking, -@nQnt)
	
	-- ��������� ��������
	Tr_Next:
	fetch next from _Double into @nWMSGoodState, @nGood, @nInBox, @nPacking, @nQnt
end

close _Double
deallocate _Double

-- ���������, ��� ����� � ������ = 0
select sum(Qnt) from __InventoryResult3



-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
-- ������� ���� �� "�����������" ��������
--declare @nWMSGoodState int
if object_id('Trading.dbo.__InventoryResult3') is Null begin
		raiserror(N'Unknown table __InventoryResult3!', 16,1)
		return
end

-- ������ � ����������� ����������� �������
declare _GoodStates cursor static for 
	select distinct WMSGoodState from __InventoryResult3

open _GoodStates
fetch next from _GoodStates into @nWMSGoodState

declare @nDepot int, @cActDate varchar(20), @cNote varchar(100), @nUniq int
while @@fetch_status = 0 begin
	-- ����� ���� ������
	set @nDepot = Null
	select @nDepot = Uniq 
		from Depots 
		where Owner = 4 and WMSGoodState = @nWMSGoodState and RemoteDepot is Null
	if @nDepot is Null begin
		raiserror(N'Unknown depot!', 16,1)
		return
	end
	
	select @cActDate = '20081012 19:50:00', @cNote = '�������������� ��� (������� ��������) �� ����������� ������� �� 12.10.2008'

	begin tran
		-- �������� ����
		insert into WHInputs (DateInput, InputsType, Supplier, Depot, 
			Amount, Currency, Netto, Brutto, 
			IndentPerson, DateIndent, DatePrint, DateConfirm, ConfirmPerson, FullConfirm, 
			Parent, TripList, WHRetMoving, WHSavedOddment, 
			DateCharge, PlaceCharge, TimeCharge, Delivery, 
			BrigadeUnload, CoefficientUnload, 
			CarNumber, Note, 
			ISource, ISUniq, ISBill, TPL, 
			WMSPrepared, WMSSent, 
			ICode, DocNumber, InvNumber, OriginalDate, In_1C)
			select @cActDate, 6, 11109, @nDepot, 
				0.0, 1, 0.0, 0.0, 
				0, GetDate(), Null, Null, Null, 0, 
				Null, Null, Null, Null, 
				Null, '', '', 0, 
				Null, 1, 
				'', @cNote, 
				Null, Null, Null, 0, 
				0, 0, 
				Null, '', '', Null, 0
		if @@Error <> 0 goto Tr_Error
		select @nUniq = @@Identity
		
		-- �������� �������
		insert into WHInputsGoods (WHInput, Packing, QntWished, QntConfirmed, DateValid, Price)
			select @nUniq, Packing, Qnt, 0, Null, 0.0 
				from __InventoryResult3 
				where WMSGoodState = @nWMSGoodState 
				order by Packing
		if @@Error <> 0 goto Tr_Error
		goto Tr_OK
		
		Tr_Error:
		rollback
		goto Tr_Next2
		
		Tr_OK:
		commit tran
		
	Tr_Next2:
	fetch next from _GoodStates into @nWMSGoodState
end

close _GoodStates
deallocate _GoodStates
