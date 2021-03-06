USE [Trading]
GO
/****** Object:  StoredProcedure [dbo].[ws_InputConfirm]    Script Date: 10/25/2007 16:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_InputConfirm]
	@xInputAll		varchar(max), 
	@cReport		varchar(max) output
AS
-- Процедура подтверждения прихода по данным из БД WMS
-- Входной параметр является таблицей в формате XML,
-- полученной от SuitableWMSWebService
-- Последние изменения: Александров 25.10.2007

set nocount on

-- Проверка режима работы
if not exists (select Uniq from _GENERAL where Variable = 'glWMS' and Meaning = '.T.') begin
	raiserror(N'WMS не активна...', 11, 1)
	return	
end

declare @nError int
set @nError  = 0
set @cReport   = ''

if @xInputAll is Null or len(@xInputAll) = 0 begin
	raiserror(N'XML-файл пуст...', 11, 1)
	return	
end

declare @nHandle int
execute sp_xml_preparedocument @nHandle output, @xInputAll

if @nHandle < 0 begin
	raiserror(N'Ошибка чтения XML-файла...', 11, 1)
	return	
end

-- Создание временной таблицы для записи кодов успешно обработанных приходов
create table #_WHInputs (Uniq int)

-- .NET WebService возвращает дату в формате "YYYY-MM-DDTHH:MM:SS+TS:MS"
-- где +TS:MS означает смещение часового пояса
-- SQL стандартно такую дату не воспринимает!
-- Для обхода ошибки все поля типа DateTime считываются как varchar(19)
select * 
	into #Inputs 
	from openxml (@nHandle, '//Inputs', 1) 
	with (	ID int 'ID', 
			ERPDateInput varchar(19) 'ERPDateInput', 
			ERPInputType int 'ERPInputType', 
			ERPPartner int 'ERPPartner', 
			ERPOwner int 'ERPOwner', 
			DateStart varchar(19) 'DateStart', 
			DateConfirm varchar(19) 'DateConfirm', 
			ERPBarCode varchar(50) 'ERPBarCode', 
			ERPCode int 'ERPCode')
if object_id('tempdb..#Inputs') is Null begin
	raiserror(N'XML-файл не содержит ни одного прихода...', 11, 1)
	return	
end

select * 
	into #InputsGoods 
	from openxml (@nHandle, '//InputsGoods', 1) 
	with (	ID int 'ID', 
			InputID int 'InputID', 
			ERPGood int 'ERPGood', 
			ERPInBox decimal(18,3) 'ERPInBox',
			QntWished decimal(18,3) 'QntWished',
			QntConfirmed decimal(18,3) 'QntConfirmed',
			ERPGoodState int 'ERPGoodState', 	
			DateValid varchar(19) 'DateValid',
			ERPCode int 'ERPCode') 	
if object_id('tempdb..#InputsGoods') is Null begin
	raiserror(N'XML-файл не содержит ни одной расшифровки прихода...', 11, 1)
	return	
end

-- Добавление поля "Код упаковки Trading"
alter table #InputsGoods add Packing int Null

-- Двойная привязка (актуальные/все)
update #InputsGoods 
	set Packing = 
		(select max(Uniq) 
		from Packings P 
		where	P.Good = #InputsGoods.ERPGood and
				P.InBox = #InputsGoods.ERPInBox and P.Actual = 1)
	where Packing is Null
update #InputsGoods 
	set Packing = 
		(select max(Uniq) 
		from Packings P 
		where	P.Good = #InputsGoods.ERPGood and
				P.InBox = #InputsGoods.ERPInBox)
	where Packing is Null
if exists(select top 1 * from #InputsGoods where Packing is Null) begin
	raiserror(N'XML-файл содержит неизвестный товар...', 11,1)
end

-- Проверка таблицы складов на уникальность
if exists (select Owner, WMSGoodState, count(*) 
			from Depots 
			group by Owner, WMSGoodState 
			having count(*) > 1) begin
	raiserror(N'Неуникальное сочетание владельца склада и состояния товара в таблице Depots!', 16, 1)
	return
end

-- Разбираемся с кодами складов
-- На таблицу Trading.Depots наложен уникальный индекс (Owner + WMSGoodState)
-- Получаем список уникальных сочетаний Owner + WMSGoodState в обрабатываемых приходах
-- и, при небходимости, автоматически создаем новые склады,
-- т.к. в WMS можно принять товар некоего владельца в состоянии, 
-- отсутствующем в справочнике складов!
select distinct I.ERPOwner, IG.ERPGoodState 
	into #NewDepots 
	from #Inputs I 
	inner join #InputsGoods IG on IG.InputID = I.ID 
	where cast(I.ERPOwner as varchar(10)) + '_' + cast(IG.ERPGoodState as varchar(10)) 
		not in (select 
				cast(Owner as varchar(10)) + '_' + cast(WMSGoodState as varchar(10)) 
				from Depots)
if exists (select top 1 * from #NewDepots) begin
	insert into Depots (Alias, Name, 
		Owner, Basic, NoControl, Actual, 
		Deposit, SeparatePicking, WMSGoodState, ICode) 
		select left('(WMS) ' + P.Alias + ': ' + S.Alias, 50), 
			left('(WMS) ' + P.Alias + ': ' + S.Alias, 100), 
			X.ERPOwner, 0, 1, 1, 
			1, 0, X.ERPGoodState, Null 
			from #NewDepots X 
			inner join Partners P on X.ERPOwner = P.Uniq 
			inner join WMSGoodsStates S on X.ERPGoodState = S.Uniq
	if @@Error <> 0 begin
		raiserror(N'Не удалось автоматически создать новые склады (Depots)...', 11,1)
	end
end

-- просто переменные
declare @nERPGoodState int, @nDepot int, @nWMSGoodState int, @nParentUniq  int, @nOwner_Tr int

-- переменные для курсора
declare @nID int, @dDateStart smalldatetime, @dDateConfirm smalldatetime, @nUniq int

declare _Inputs cursor static for 
	select ID, DateStart, DateConfirm, ERPCode 
		from #Inputs 
open _Inputs 
fetch next from _Inputs into @nID, @dDateStart, @dDateConfirm, @nUniq

begin transaction
	while @@fetch_status = 0 begin 
		if not exists (select Uniq from WHInputs where Uniq = @nUniq) begin
			set @cReport = @cReport + 'Приход ' + cast(@nUniq as varchar(10)) +
				'(' + cast(@nID as varchar(10)) +')' + ' не найден!' + char(13) + char(10)
			goto FetchNextInput
		end
		
		if not exists (select Uniq from WHInputs where Uniq = @nUniq and DateConfirm is Null) begin
			set @cReport = @cReport + 'Приход ' + cast(@nUniq as varchar(10)) +
				'(' + cast(@nID as varchar(10)) +')' + ' уже подтвержден!'	+ char(13) + char(10)
			goto FetchNextInput
		end
		
		set @nParentUniq = @nUniq
		-- сохранили ERPCode текущего прихода, 
		-- если будем добавлять приходы, то в @nUniq будет Uniq нового
		
		declare _InputsStates cursor static for
			select distinct ERPGoodState 
				from #InputsGoods 
				where InputID = @nID
		open _InputsStates
		fetch next from _InputsStates into @nERPGoodState
		
		while @@fetch_status = 0 begin
			select @nDepot = Depot from WHInputs where Uniq = @nUniq
			select @nWMSGoodState = WMSGoodState from Depots where Uniq = @nDepot
			if @nWMSGoodState = @nERPGoodState begin 
				update WHInputs 
					set DateConfirm = @dDateConfirm, ConfirmPerson = 0 
					where Uniq = @nUniq
				set @nError =  @@Error
				if @nError > 0 goto Close_Cursor1 	
				
				update WHInputsGoods 
					set QntConfirmed = I.QntConfirmed,
						DateValid = I.DateValid
					from #InputsGoods I 
					where WHInput = @nUniq and
						I.InputID = @nID and I.ERPCode = Uniq and 
						I.ERPGoodState = @nERPGoodState
				set @nError =  @@Error
				if @nError > 0 goto Close_Cursor1
				
				insert WHInputsGoods 
					(WHInput, Packing, QntWished, QntConfirmed, DateValid)
					select @nUniq, Packing, 0, QntConfirmed, DateValid
						from #InputsGoods 
						where ERPGoodState = @nERPGoodState and InputID = @nID and 
							(
							QntWished = 0  
							or  
							ERPCode not in 
								(select Uniq from WHInputsGoods where WHInput = @nUniq)
							)
				set @nError =  @@Error
				if @nError > 0 goto Close_Cursor1
				
				insert #_WHInputs (Uniq) values (@nUniq)
				set @cReport = @cReport + 'Приход ' + cast(@nUniq as varchar(10)) +
					'(' + cast(@nID as varchar(10)) +')' + ' OK' + char(13) + char(10)
			end
			else begin
				-- определяем @nDepot для нового прихода
				select  @nOwner_Tr = Owner from Depots where Uniq = @nDepot
				select top 1 @nDepot = Uniq from Depots 
					where Owner = @nOwner_Tr and WMSGoodState = @nERPGoodState
					order by Uniq
				insert WHInputs
					(DateInput, InputsType, Supplier, Depot, Amount, Currency, 
					Netto, Brutto, IndentPerson, DateIndent, DatePrint, DateConfirm, 
					ConfirmPerson, FullConfirm, Parent, TripList, WHRetMoving, 
					WHSavedOddment, DateCharge, PlaceCharge, TimeCharge, Delivery, 
					BrigadeUnload, CoefficientUnload, CarNumber, 
					Note, 
					ISource, ISUniq, ISBill, 
					TPL, WMSPrepared, WMSSent, ICode)
				select DateInput, InputsType, Supplier, @nDepot, 0, Currency, 
					0, 0, 0, GetDate(), Null, @dDateConfirm, 
					0, 0, @nParentUniq, Null, Null, 
					Null, Null, '', '', Delivery, 
					BrigadeUnload, CoefficientUnload, CarNumber, 
					'Добавлено из WMS ' + convert(varchar(20), GetDate(), 120), 
					Null, Null, Null, 
					TPL, 1, 1, Null
					from WHInputs 
					where Uniq = @nParentUniq
				select @nUniq = @@Identity, @nError =  @@Error  
				if @nError > 0 goto Close_Cursor1
				
				insert WHInputsGoods 
					(WHInput, Packing, QntWished, QntConfirmed, DateValid)
					select @nUniq, Packing, 0, QntConfirmed, DateValid
					from #InputsGoods 
					where ERPGoodState = @nERPGoodState and
						QntConfirmed > 0 and InputID = @nID
				set @nError =  @@Error
				if @nError > 0 goto Close_Cursor1
				
				insert #_WHInputs (Uniq) values (@nUniq)
				set @cReport = @cReport + 'Приход ' + cast(@nUniq as varchar(10)) +
						'(' + cast(@nID as varchar(10)) +')' + ' добавлен' + char(13) + char(10)
			end
			
			fetch next from _InputsStates into @nERPGoodState
		end
		
		Close_cursor1:	
		close _InputsStates
		deallocate _InputsStates 
		if @nError > 0 goto Close_Cursor
		
		FetchNextInput:
		fetch next from _Inputs into @nID, @dDateStart, @dDateConfirm, @nUniq
	end
	
	update WHInputs 
		set Amount = X.Amount, Netto = X.Netto, Brutto = X.Brutto, FullConfirm = X.FullConfirm 
		from ( select IG.WHInput, 
					sum(IG.QntConfirmed * IG.Price) as Amount, 
					sum(IG.QntConfirmed * G.Netto)  as Netto, 
					sum(IG.QntConfirmed * G.Brutto) as Brutto, 
					min(case when QntWished <> QntConfirmed then 0 else 1 end) as FullConFirm 
				from #_WHInputs I 
				inner join WHInputsGoods IG with (nolock) on I.Uniq = IG.WHInput 
				inner join Packings P with (nolock) on IG.Packing = P.Uniq 
				inner join Goods G with (nolock) on P.Good = G.Uniq 
				group by IG.WHInput ) X 
		where WHInputs.Uniq = X.WHInput
	set @nError =  @@Error
	if @nError > 0 goto Close_Cursor
	
	-- Обновление данных об остатках
	update WHOddments 
		set 	Qnt = WHOddments.Qnt + IG.QntConfirmed 
		from 	WHInputsGoods IG 
		inner join WHInputs I on I.Uniq = IG.WHInput 
		inner join #_WHInputs T on T.Uniq = IG.WHInput 
		where 	IG.QntConfirmed <> 0 and 
				WHOddments.Depot = I.Depot and 
				WHOddments.Packing = IG.Packing 
	set @nError =  @@Error
	if @nError > 0 goto Close_Cursor
	
	-- Дополнение таблицы остатков новыми товарами
	insert 	WHOddments (Depot, Packing, Qnt) 
		select I.Depot, IG.Packing, IG.QntConfirmed 
			from 	WHInputsGoods IG 
			inner join WHInputs I on I.Uniq = IG.WHInput 
			inner join #_WHInputs T on T.Uniq = IG.WHInput 
			where IG.QntConfirmed <> 0 and 
				str(I.Depot) + '_' + str(IG.Packing) not in 
					(select distinct str(Depot) + '_' + str(Packing) from WHOddments)
	set @nError =  @@Error
	if @nError > 0 goto Close_Cursor

if @@TranCount > 0 commit transaction

Close_Cursor:
close _Inputs
deallocate _Inputs 
if @nError = 0 return

if @@TranCount > 0 rollback transaction
return