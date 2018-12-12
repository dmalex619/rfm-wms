--use trading

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

alter PROCEDURE [dbo].[ws_WHStorage_FromWms]
-- получение данных о €чейках, размещении контейнеров, исправлении ошибок высотной зоны
AS

set nocount on
-- ѕроверка существовани€ таблицы (создаетс€ в ?WebService)
if object_id('Tempdb.dbo.#Cells') is Null begin
	RaisError(N'ќтсутствует временна€ таблица #Cells', 16, 1)
	return
end
if object_id('Tempdb.dbo.#Traffics') is Null begin
	RaisError(N'ќтсутствует временна€ таблица #Traffics', 16, 1)
	return
end
if object_id('Tempdb.dbo.#Changes') is Null begin
	RaisError(N'ќтсутствует временна€ таблица #Changes', 16, 1)
	return
end

-- delete #Cells where isNull(Address, '') = '' 
-- create index IX_Address on #Cells (Address)

declare @nWeUniq int 
select	@nWeUniq = cast(Meaning as int)
	from	_General
	where	Variable = 'gnInco' 

-- ќбновление и добавление данных
begin tran

-- 1. √еометри€, актуальность, блокировка €чеек
-- обновить существующие
update	WHStorage 
	set		PalletWidth = C.CellWidth, -- ?? PT.PalletWidth
			MaxWeight = C.MaxWeight, 
			Locked = C.Locked,
			Actual = C.Actual
	from	#Cells C
	where	C.Address = WHStorage.Address
if @@Error <> 0 goto Tr_Error

-- удалить удаленные 
if exists (select Uniq	
				from	WHStorage
				where	Address not in (select Address from #Cells) 
			) begin
	-- пр€мо сразу удалить? может, хот€ бы снимем актуальность? 
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

-- добавить новые 
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

-- дл€ перекодировки
declare @nOwnerID int, @nGoodStateID int, @bGoodStateBasic bit--, @nPackingID int
declare @nOwnerUniq int, @nGoodStateUniq int--, @nPackingUniq int  
declare @cErpCode varchar(50), @nErpError int
set @nErpError = 0

-- дл€ подъема контейнеров и исправлени€ ошибок
declare @nOwner int, @nWmsGoodState int, @bWmsGoodStateBasic bit, 
		@nDepotUniq int, @cDepotName varchar(100), 
		@nCellUniq int,  @cCellAddress varchar(20) 

-- 2. ѕодъем контейнеров
declare @nTrafficID int, @dDateConfirm datetime
declare @nDraftUniq int 
if exists (select ID from #Traffics) begin
	-- идем по выполненным операци€м подъема контейнеров
	declare T_Cursor cursor for 
		select	ID, DateConfirm, ErpOwner, ErpGoodState, GoodStateBasic 
			from	#Traffics 
			order by DateConfirm
	open T_cursor
	fetch next from T_cursor into @nTrafficID, @dDateConfirm, 
								  @nOwner, @nWmsGoodState, @bWmsGoodStateBasic 
	while @@fetch_status = 0
	begin
		-- 2.1. создаем задание на подъем, если такого нет

		-- определ€ем виртуальный склад
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
			-- так и не нашелс€ склад
			-- ƒќЅј¬Ћя≈ћ — Ћјƒ!
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

		-- определ€ем €чейку
		set	@nCellUniq = Null
		select	@nCellUniq = S.Uniq, @cCellAddress = T.CellTargetAddress
			from	WHStorage S, #Traffics T
			where	S.Address = T.CellTargetAddress and	
					T.ID = @nTrafficID
		if @nCellUniq is Null begin 
			set	@nErpError = -1	-- не найдена €чейка с адресом
			break
		end 

		-- нет ли уже созданного задани€?
		set @nDraftUniq = Null
		select @nDraftUniq = Uniq
			from	WHDrafts
			where	DraftType = 'U' and 
					datediff(day, DateConfirm, @dDateConfirm) = 0 and 
					Depot = @nDepotUniq and 
					Note = 'WMS'
		if @nDraftUniq is Null begin
			-- не нашлось задани€. добавл€ем новое
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

		-- 2.2. добавл€ем расшифровку задани€ - на подъем контейнера
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

		-- 2.3. исправл€ем наполнение €чейки
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

		-- 2.4. поднимаем признак успешной передачи записи в Trd
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

-- 3. »справление ошибок
declare @nChangeID int, @dDateEdit smalldatetime
if exists (select ID from #Changes) begin
	-- идем по выполненным операци€м исправлени€ ошибок в €чейках 
	declare H_cursor cursor for 
		select	ID, DateEdit, ErpOwner, ErpGoodState, GoodStateBasic  
			from	#Changes 
			order by DateEdit
	open H_cursor
	fetch next from H_cursor into @nChangeID, @dDateEdit,  
								  @nOwner, @nWmsGoodState, @bWmsGoodStateBasic 
	while @@fetch_status = 0
	begin

		-- 3.1. создаем новую запись - исправление ошибки 

		-- определ€ем виртуальный склад
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
			-- так и не нашелс€ склад
			-- ƒќЅј¬Ћя≈ћ — Ћјƒ!
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

		-- определ€ем €чейку
		set	@nCellUniq = Null
		select	@nCellUniq = S.Uniq, @cCellAddress = H.CellAddress
			from	WHStorage S, #Changes H
			where	S.Address = H.CellAddress and	
					H.ID = @nChangeID
		if @nCellUniq is Null begin 
			set	@nErpError = -2	-- не найдена €чейка с адресом
			break
		end 

		if (select Qnt from #Changes where ID = @nChangeID) > 0 begin 
			-- приход товара в €чейку 
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
			-- расход товара из €чейки
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

		-- 3.2. исправл€ем наполнение €чейки
		update	WHStorage
			set		Depot = @nDepotUniq, 
					Packing = H.ErpPacking, Qnt = H.Qnt, DateValid = H.DateValid
			from	#Changes H 
			inner join Packings Ps on H.ErpPacking = Ps.Uniq -- !!!
			where	WHStorage.Uniq = @nCellUniq and 
					H.ID = @nChangeID
		select @nErpError = @@error
		if @nErpError <> 0 break
		-- если получилось количество = 0 - очищаем €чейку
		update	WHStorage
			set		Depot = Null, 
					Packing = Null, Qnt = Null, DateValid = Null
			where	Uniq = @nCellUniq and 
					Qnt = 0
		select @nErpError = @@error
		if @nErpError <> 0 break

		-- 3.3. поднимаем признак успешной передачи записи в Trd
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
raiserror('ќшибка %d', 16, 1, @nErpError)
rollback
return



