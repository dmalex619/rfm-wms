-- Автоматическое создание актов ревизий в Trading
-- на основании расхождений, рассчитанных скриптом
-- "Compare oddments between Trading and WMS after full Inventory.sql"
use Trading
go

set nocount on

/*
if object_id('__InventoryResult') is Null begin
	raiserror(N'Отсутствует таблица __InventoryResult!', 16, 1)
	return
end
*/
if object_id('__InventoryResult2') is Null begin
	raiserror(N'Отсутствует таблица __InventoryResult2!', 16, 1)
	return
end


-- Проверка таблицы складов Trading на уникальность
if exists (select Owner, WMSGoodState, count(*) 
			from Depots 
			where RemoteDepot is Null 
			group by Owner, WMSGoodState 
			having count(*) > 1) begin
	raiserror(N'Неуникальное сочетание владельца склада и состояния товара в таблице Depots!', 16, 1)
	return
end

-- Разбираемся с кодами складов
-- На таблицу Trading.Depots наложен уникальный индекс (Owner + WMSGoodState + RemoteDepot)
-- Получаем список уникальных сочетаний Owner + WMSGoodState в обрабатываемых приходах
-- без учета удаленных складов (RemoteDepot is not Null)
-- и, при небходимости, автоматически создаем новые склады,
-- т.к. в WMS можно принять товар некоего владельца в состоянии, 
-- отсутствующем в справочнике складов!
if object_id('Tempdb.dbo.#NewDepots') is not Null drop table #NewDepots
select distinct I.ERPOwner, I.ERPGoodState 
	into #NewDepots 
--	from __InventoryResult I 
	from __InventoryResult2 I 
	where cast(I.ERPOwner as varchar(10)) + '_' + cast(I.ERPGoodState as varchar(10)) 
		not in (select 
				cast(Owner as varchar(10)) + '_' + cast(WMSGoodState as varchar(10)) 
				from Depots 
				where RemoteDepot is Null)
if exists (select top 1 * from #NewDepots) begin
	insert into Depots (Alias, Name, 
		Owner, Basic, NoControl, Actual, 
		Deposit, SeparatePicking, WMSGoodState, ICode, RemoteDepot) 
		select left('(WMS) ' + P.Alias + ': ' + S.Alias, 50), 
			left('(WMS) ' + P.Alias + ': ' + S.Alias, 100), 
			X.ERPOwner, 0, 1, 1, 
			1, 0, X.ERPGoodState, Null, Null 
			from #NewDepots X 
			inner join Partners P on X.ERPOwner = P.Uniq 
			inner join WMSGoodsStates S on X.ERPGoodState = S.Uniq
	if @@Error <> 0 begin
		raiserror(N'Не удалось автоматически создать новые склады (Depots)...', 11,1)
	end
end

-- Добавление поля "Код упаковки Trading"
if object_id('Tempdb.dbo.#Result') is not Null drop table #Result
select *, cast(Null as int) as Packing 
	into #Result 
--	from __InventoryResult
	from __InventoryResult2
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
	raiserror(N'Файл ревизии содержит неизвестный товар...', 11, 1)
	return
end



-- Создание курсора по сочетанию Владелец + Состояние товара
declare @cERPOwner varchar(50), @cERPGoodState  varchar(50), 
	@nDepot int, @nUniq int, @cActDate varchar(20), @cNote varchar(100)
declare _Depots cursor static for 
	select distinct ERPOwner, ERPGoodState 
--		from __InventoryResult 
		from __InventoryResult2 
		order by 1,2
open _Depots

fetch next from _Depots into @cERPOwner, @cERPGoodState
while @@fetch_status = 0 begin
	-- Подобрать склад
	set @nDepot = Null
	select @nDepot = Uniq 
		from Depots 
		where	Owner = cast(@cERPOwner as int) and 
				WMSGoodState = cast(@cERPGoodState as int) and 
				RemoteDepot is Null
	if @nDepot is Null begin
		raiserror(N'Неизвестный склад...', 11, 1)
		return
	end
	
	-- Склад "Виртуальный" обрабатываем по другому:
	-- мы просто списываем его в 0
	if @nDepot = 4
		--select @cActDate = '20081012 19:30:00', @cNote = 'Автоматическое обнуление склада "Виртуальный" по результатам ревизии от 12.10.2008'
		goto Tr_Next
	else
		--select @cActDate = '20081012 19:00:00', @cNote = 'Автоматический акт по результатам ревизии от 12.10.2008'
		select @cActDate = '20081012 19:40:00', @cNote = 'Автоматический акт (отсутствующий товар) по результатам ревизии от 12.10.2008'
	
	begin tran
		-- Внесение акта
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
		
		if @nDepot = 4
			-- Полное обнуление виртуального склада
			insert into WHInputsGoods (WHInput, Packing, QntWished, QntConfirmed, DateValid, Price)
				select @nUniq, Packing, -Qnt, 0, Null, 0.0 
					from WHOddments 
					where Depot = @nDepot and Qnt <> 0 
					order by Packing
		else
			-- Внесение разницы
			insert into WHInputsGoods (WHInput, Packing, QntWished, QntConfirmed, DateValid, Price)
				select @nUniq, Packing, WQnt - TQnt, 0, Null, 0.0 
					from #Result 
					where ERPOwner = @cERPOwner and ERPGoodState = @cERPGoodState 
					order by Packing
		if @@Error <> 0 goto Tr_Error
		goto Tr_OK
		
		Tr_Error:
		rollback
		goto Tr_Next
		
		Tr_OK:
		commit tran
		
	Tr_Next:
	fetch next from _Depots into @cERPOwner, @cERPGoodState
end

close _Depots
deallocate _Depots
