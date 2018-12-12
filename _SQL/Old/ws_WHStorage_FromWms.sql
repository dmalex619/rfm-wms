--use trading

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

alter PROCEDURE [dbo].[ws_WHStorage_FromWms]
-- ��������� ������ � �������, ���������� �����������, ����������� ������ �������� ����
AS

set nocount on
-- �������� ������������� ������� (��������� � ?WebService)
if object_id('Tempdb.dbo.#Cells') is Null begin
	RaisError(N'����������� ��������� ������� #Cells', 16, 1)
	return
end
if object_id('Tempdb.dbo.#Traffics') is Null begin
	RaisError(N'����������� ��������� ������� #Traffics', 16, 1)
	return
end
if object_id('Tempdb.dbo.#Changes') is Null begin
	RaisError(N'����������� ��������� ������� #Changes', 16, 1)
	return
end

-- delete #Cells where isNull(Address, '') = '' 
-- create index IX_Address on #Cells (Address)

declare @nWeUniq int 
select	@nWeUniq = cast(Meaning as int)
	from	_General
	where	Variable = 'gnInco' 

-- ���������� � ���������� ������
begin tran

-- 1. ���������, ������������, ���������� �����
-- �������� ������������
update	WHStorage 
	set		PalletWidth = C.CellWidth, -- ?? PT.PalletWidth
			MaxWeight = C.MaxWeight, 
			Locked = C.Locked,
			Actual = C.Actual
	from	#Cells C
	where	C.Address = WHStorage.Address
if @@Error <> 0 goto Tr_Error

-- ������� ��������� 
if exists (select Uniq	
				from	WHStorage
				where	Address not in (select Address from #Cells) 
			) begin
	-- ����� ����� �������? �����, ���� �� ������ ������������? 
	/*
	update	WHStorage 
		set		Actual = 0 
		from	#Cells 
		where	Address not in (select Address from #Cells)
	*/ 
	
	delete	WHStorage 
		where	Address not in (select Address from #Cells)
	if @@Error <> 0 goto Tr_Error
end 

-- �������� ����� 
if exists (select ID 	
				from	#Cells 
				where	-- isNull(ErpCell, '') = '' or 
						Address not in (select Address from WHStorage)
			) begin
	insert	WHStorage
			(Address, WHZone, PalletWidth, PalletHeight, MaxWeight, Depot, State, Packing, Qnt, DateValid, Locked, Actual)
		select	C.Address, 
				0 as WHZone, 
				CellWidth, CellHeight, MaxWeight, 
				Null as Depot, 
				Null as State, 
				Null as Packing, Null as Qnt, Null as DateValid, 
				C.Locked, C.Actual
			from	#Cells C
			where	-- isNull(C.ErpCell, '') = '' or 
					C.Address not in (select Address from WHStorage)
	if @@Error <> 0 goto Tr_Error

	update	#Cells
		set		ErpCell = S.Uniq
		from	WHStorage S
		where	isNull(#Cells.ErpCell, '') = '' and #Cells.Address = S.Address
end 

-- ��� �������������
declare @nOwnerID int, @nGoodStateID int, @bGoodStateBasic bit--, @nPackingID int
declare @nOwnerUniq int, @nGoodStateUniq int--, @nPackingUniq int  
declare @cErpCode varchar(50), @nErpError int
set @nErpError = 0

-- ��� ������� ����������� � ����������� ������
declare @nOwner int, @nWmsGoodState int, @bWmsGoodStateBasic bit, 
		@nDepotUniq int, @cDepotName varchar(100), 
		@nCellUniq int,  @cCellAddress varchar(20) 

-- 2. ������ �����������
declare @nTrafficID int, @dDateConfirm datetime
declare @nDraftUniq int 
if exists (select ID from #Traffics) begin
	-- ���� �� ����������� ��������� ������� �����������
	declare T_Cursor cursor for 
		select	ID, DateConfirm, ErpOwner, ErpGoodState, GoodStateBasic 
			from	#Traffics 
			order by DateConfirm
	open T_cursor
	fetch next from T_cursor into @nTrafficID, @dDateConfirm, 
								  @nOwner, @nWmsGoodState, @bWmsGoodStateBasic 
	while @@fetch_status = 0
	begin
		-- 2.1. ������� ������� �� ������, ���� ������ ���

		-- ���������� ����������� �����
		set @nDepotUniq = Null 
		select top 1 @nDepotUniq = Uniq
			from	Depots 
			where	Owner = @nOwner and
					WmsGoodState = @nWmsGoodState and 
					Actual = 1
		if @nDepotUniq is Null 
			select top 1 @nDepotUniq = Uniq
				from	Depots 
				where	Owner = @nOwner and
						WmsGoodState = @nWmsGoodState and 
						Actual = 1
		if @nDepotUniq is Null begin
			-- ��� � �� ������� �����
			-- ��������� �����!
			select	@cDepotName = P.Alias
				from	Partners P
				where	P.Uniq = @nOwner
			select	@cDepotName = isNull(@cDepotName, '') + ' ' + GS.Alias
				from	WmsGoodsStates GS
				where	GS.Uniq = @nWmsGoodState
			select	@cDepotName = isNull(@cDepotName, '') + ' (WMS)'

			insert	Depots 
					(Alias, Name, Owner, Basic, NoControl, Actual, Deposit, WmsGoodState)
				select	left(@cDepotName, 25) as Alias,  
						left(@cDepotName, 50) as Name, 
						@nOwner as Owner, 
						@bWmsGoodStateBasic, 
						case when @nOwner = @nWeUniq then 1 else 0 end as NoControl, 
						1 as Actual, 
						case when @nOwnerUniq = @nWeUniq then 0 else 1 end as Deposit, 
						@nWmsGoodState as WmsGoodState
			select	@nDepotUniq = @@identity, 
					@nErpError = @@error
			if @nErpError <> 0 break
		end

		-- ���������� ������
		set	@nCellUniq = Null
		select	@nCellUniq = S.Uniq, @cCellAddress = T.CellTargetAddress
			from	WHStorage S, #Traffics T
			where	S.Address = T.CellTargetAddress and	
					T.ID = @nTrafficID
		if @nCellUniq is Null begin 
			set	@nErpError = -1	-- �� ������� ������ � �������
			break
		end 

		-- ��� �� ��� ���������� �������?
		set @nDraftUniq = Null
		select @nDraftUniq = Uniq
			from	WHDrafts
			where	DraftType = 'U' and 
					datediff(day, DateConfirm, @dDateConfirm) = 0 and 
					Depot = @nDepotUniq and 
					Note = 'WMS'
		if @nDraftUniq is Null begin
			-- �� ������� �������. ��������� �����
			insert	WHDrafts
					(DateDraft, DraftType, Depot, 
					IndentPerson, DateArrange, DatePrint, 
					DateConfirm, ConfirmPerson, FullConfirm, BrigadeStore, CoefficientStore, 
					Note)
				select	T.DateBirth, 'U', @nDepotUniq, 
						0 as IndentPerson, T.DateBirth as DateArrange, Null as DatePrint, 
						T.DateConfirm, 0 as ConfirmPerson, 1 as FullConfirm, 
						Null as BrigadeStore, 0 as CoefficientStore, 
						'WMS' as Note
					from	#Traffics T
					where	T.ID = @nTrafficID
			select	@nDraftUniq = @@identity, 
					@nErpError = @@error
			if @nErpError <> 0 break
		end

		-- 2.2. ��������� ����������� ������� - �� ������ ����������
		insert	WHDraftsGoods
				(WHDraft, Cell, CellAddress, 
				Packing, QntWished, QntConfirmed, DateValid)
			select	@nDraftUniq, @nCellUniq, @cCellAddress, 
					T.ErpPacking, T.Qnt, T.Qnt, T.DateValid
				from	#Traffics T 
				inner join Packings Ps on T.ErpPacking = Ps.Uniq -- !!!
				where	T.ID = @nTrafficID
		select	@cErpCode = @@identity, 
				@nErpError = @@error
		if @nErpError <> 0 break

		-- 2.3. ���������� ���������� ������
		update	WHStorage
			set		Depot = @nDepotUniq, 
					Packing = T.ErpPacking, Qnt = T.Qnt, DateValid = T.DateValid, 
					State = 'S' 
			from	#Traffics T 
			inner join Packings Ps on T.ErpPacking = Ps.Uniq -- !!!
			where	WHStorage.Uniq = @nCellUniq and 
					T.ID = @nTrafficID
		select @nErpError = @@error
		if @nErpError <> 0 break

		-- 2.4. ��������� ������� �������� �������� ������ � Trd
		update	#Traffics
			set		ErpTraffic = @cErpCode
			where	ID = @nTrafficID
		select @nErpError = @@error
		if @nErpError <> 0 break

		fetch next from T_cursor into @nTrafficID, @dDateConfirm, 
									  @nOwner, @nWmsGoodState, @bWmsGoodStateBasic 
	end
	close T_cursor
	deallocate T_cursor
	
	if @nErpError <> 0 goto Tr_Error
end 

-- 3. ����������� ������
declare @nChangeID int, @dDateEdit smalldatetime
if exists (select ID from #Changes) begin
	-- ���� �� ����������� ��������� ����������� ������ � ������� 
	declare H_cursor cursor for 
		select	ID, DateEdit, ErpOwner, ErpGoodState, GoodStateBasic  
			from	#Changes 
			order by DateEdit
	open H_cursor
	fetch next from H_cursor into @nChangeID, @dDateEdit,  
								  @nOwner, @nWmsGoodState, @bWmsGoodStateBasic 
	while @@fetch_status = 0
	begin

		-- 3.1. ������� ����� ������ - ����������� ������ 

		-- ���������� ����������� �����
		set	@nDepotUniq = Null 
		select top 1 @nDepotUniq = Uniq
			from	Depots 
			where	Owner = @nOwner and
					WmsGoodState = @nWmsGoodState and 
					Actual = 1
		if @nDepotUniq is Null 
			select top 1 @nDepotUniq = Uniq
				from	Depots 
				where	Owner = @nOwner and
						WmsGoodState = @nWmsGoodState and 
						Actual = 1
		if @nDepotUniq is Null begin
			-- ��� � �� ������� �����
			-- ��������� �����!
			select	@cDepotName = P.Alias
				from	Partners P
				where	P.Uniq = @nOwner
			select	@cDepotName = isNull(@cDepotName, '') + ' ' + GS.Alias
				from	WmsGoodsStates GS
				where	GS.Uniq = @nWmsGoodState
			select	@cDepotName = isNull(@cDepotName, '') + ' (WMS)'

			insert	Depots 
					(Alias, Name, Owner, Basic, NoControl, Actual, Deposit, WmsGoodState)
				select	left(@cDepotName, 25) as Alias,  
						left(@cDepotName, 25) as Name, 
						@nOwner as Owner, 
						@bWmsGoodStateBasic, 
						case when @nOwner = @nWeUniq then 1 else 0 end as NoControl, 
						1 as Actual, 
						case when @nOwnerUniq = @nWeUniq then 0 else 1 end as Deposit, 
						@nWmsGoodState as WmsGoodState
			select	@nDepotUniq = @@identity, 
					@nErpError = @@error
			if @nErpError <> 0 break
		end

		-- ���������� ������
		set	@nCellUniq = Null
		select	@nCellUniq = S.Uniq, @cCellAddress = H.CellAddress
			from	WHStorage S, #Changes H
			where	S.Address = H.CellAddress and	
					H.ID = @nChangeID
		if @nCellUniq is Null begin 
			set	@nErpError = -2	-- �� ������� ������ � �������
			break
		end 

		if (select Qnt from #Changes where ID = @nChangeID) > 0 begin 
			-- ������ ������ � ������ 
			insert	WHStorageErrors 
					(ErrorDate, Cell, Depot, 
					State_B, Qnt_B, Packing_B, DateValid_B, 
					State_E, Qnt_E, Packing_E, DateValid_E, 
					ActDate, Number, UserID)
				select	@dDateEdit, @nCellUniq, @nDepotUniq, 
						Null, Null, Null, Null, 
						'S', H.Qnt, H.ErpPacking, H.DateValid, 
						Null as ActDate, '' as Number, 0 as UserID
					from	#Changes H
					inner join Packings Ps on H.ErpPacking = Ps.Uniq -- !!!
					where	H.ID = @nChangeID
		end
		else begin
			-- ������ ������ �� ������
			insert	WHStorageErrors 
					(ErrorDate, Cell, Depot, 
					State_B, Qnt_B, Packing_B, DateValid_B, 
					State_E, Qnt_E, Packing_E, DateValid_E, 
					ActDate, Number, UserID)
				select	@dDateEdit, @nCellUniq, @nDepotUniq, 
						'S', -H.Qnt, H.ErpPacking, H.DateValid, 
						Null, Null, Null, Null, 
						Null as ActDate, '' as Number, 0 as UserID
					from	#Changes H
					inner join Packings Ps on H.ErpPacking = Ps.Uniq -- !!! 
					where	H.ID = @nChangeID
		end 
		select	@cErpCode = @@identity,
				@nErpError = @@error
		if @nErpError <> 0 break

		-- 3.2. ���������� ���������� ������
		update	WHStorage
			set		Depot = @nDepotUniq, 
					Packing = H.ErpPacking, Qnt = H.Qnt, DateValid = H.DateValid
			from	#Changes H 
			inner join Packings Ps on H.ErpPacking = Ps.Uniq -- !!!
			where	WHStorage.Uniq = @nCellUniq and 
					H.ID = @nChangeID
		select @nErpError = @@error
		if @nErpError <> 0 break
		-- ���� ���������� ���������� = 0 - ������� ������
		update	WHStorage
			set		Depot = Null, 
					Packing = Null, Qnt = Null, DateValid = Null
			where	Uniq = @nCellUniq and 
					Qnt = 0
		select @nErpError = @@error
		if @nErpError <> 0 break

		-- 3.3. ��������� ������� �������� �������� ������ � Trd
		update	#Changes 
			set		ErpChange = @cErpCode
			where	ID = @nChangeID
		select @nErpError = @@error
		if @nErpError <> 0 break

		fetch next from H_cursor into @nChangeID, @dDateEdit, 
									  @nOwner, @nWmsGoodState, @bWmsGoodStateBasic 
	end
	close H_cursor
	deallocate H_cursor

	if @nErpError <> 0 goto Tr_Error
end 

select	ID, isNull(ErpCell, '') as ErpCode 
	from	#Cells
select ID, isNull(ErpTraffic, '') as ErpCode 
	from	#Traffics
select ID, isNull(ErpChange, '') as ErpCode 
	from	#Changes

commit tran
return

Tr_Error:
raiserror('������ %d', 16, 1, @nErpError)
rollback
return



