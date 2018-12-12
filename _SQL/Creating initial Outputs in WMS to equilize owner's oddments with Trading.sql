-- Процедура создания "начальных" расходов в WMS
-- для выравнивания остатков по хранителям с Trading
-- Проверено 20.11.2008
if db_name() <> 'WMS' return

set nocount on

-- Получение конечных остатков в разрезе хранителей и состояний товаров на 27.07.2008
if object_id('Tempdb..#CalcOdds') is not Null drop table #CalcOdds
if object_id('Tempdb..#TOdds') is not Null drop table #TOdds
if object_id('Tempdb..#TExtraI') is not Null drop table #TExtraI
if object_id('Tempdb..#TExtraO') is not Null drop table #TExtraO
if object_id('Tempdb..#Finish') is not Null drop table #Finish
if object_id('Tempdb..#ActsForDelete') is not Null drop table #ActsForDelete

-- Дата выравнивания
declare @dDate smalldatetime
set @dDate = '20081026'

-- Удаление ранее созданных актов
select ID 
	into #ActsForDelete 
	from AuditActs 
	where DateDiff(Day, DateAudit, @dDate) = 0 and ERPCode is Null
if @@RowCount > 0 begin
	begin tran
		delete AuditActsGoods 
			where AuditActID in (select ID from #ActsForDelete)
		if @@Error <> 0 goto Tr_DelError
		delete AuditActs 
			where ID in (select ID from #ActsForDelete)
		if @@Error <> 0 goto Tr_DelError
	commit tran
	goto Tr_DelOK
	
	Tr_DelError:
	rollback
	raiserror(N'Delete error!', 16, 1)
	return
	
	Tr_DelOK:
end

-- Создание таблицы для расчета расхождений
create table #CalcOdds 
	(OwnerID int, OwnerName varchar(50), SeparatePicking bit, 
	GoodStateID int, GoodStateName varchar(50), 
	PackingID int, GoodID int, 
	GoodBarCode varchar(13), PackingBarCode varchar(13), 
	GoodName varchar(250), GoodAlias varchar(50), Articul varchar(50), 
	Retention int, Weighting bit, Netto dec(15,3), Brutto dec(15,3), 
	GoodGroupID int, GoodGroupName varchar(50), 
	GoodBrandID int, GoodBrandName varchar(50),
	QntBeg dec(15,3), QntPlus dec(15,3), QntMinus dec(15,3), QntEnd dec(15,3), 
	QntInCells dec(15,3), PartnerID int, InBox dec(15,3), BoxInPal int)
insert into #CalcOdds --(OwnerID, GoodStateID, PackingID, GoodID, QntEnd) 
	exec up_ReportOddmentsBalance '20070101', @dDate

-- Добавление полей
alter table #CalcOdds add ERPOwner varchar(50)
alter table #CalcOdds add ERPGoodState varchar(50)
alter table #CalcOdds add ERPGood varchar(50)
alter table #CalcOdds add TQnt dec(15,3)

-- Получение кодов ERP по ID
update #CalcOdds set ERPOwner = P.ERPCode 
	from Partners P 
	where #CalcOdds.OwnerID = P.ID
update #CalcOdds set ERPGoodState = GS.ERPCode 
	from GoodsStates GS 
	where #CalcOdds.GoodStateID = GS.ID
update #CalcOdds set ERPGood = G.ERPCode 
	from Goods G 
	where #CalcOdds.GoodID = G.ID

-- Получение сохраненных остатков Trading на заданную дату
declare @nUniq int
select @nUniq = Uniq 
	from Trading.dbo.WHSavedOddments 
	where DateDiff(Day, DateSave, @dDate) = 0
if @nUniq is Null begin
	raiserror(N'There is no oddments for that date!', 16, 1)
	return
end
--select @nUniq

select D.Owner as ERPOwner, D.WMSGoodState as ERPGoodState, P.Good as ERPGood, P.InBox, sum(O.Qnt) as Qnt 
	into #TOdds 
	from Trading.dbo.WHSavedOddmentsGoods O 
	inner join Trading.dbo.Depots D on O.Depot = D.Uniq 
	inner join Trading.dbo.Packings P on O.Packing = P.Uniq 
	inner join Trading.dbo.Goods G on P.Good = G.Uniq 
	where	O.WHSavedOddment = @nUniq and D.RemoteDepot is Null and 
			G.GoodsGroup <> 5 and G.Tare = 0 
	group by D.Owner, D.WMSGoodState, P.Good, P.InBox
select * from #TOdds

-- Получение приходов и расходов того же дня,
-- но вошедших в следующие остатки
select D.Owner as ERPOwner, D.WMSGoodState as ERPGoodState, P.Good as ERPGood, P.InBox, sum(IG.QntConfirmed) as Qnt 
	into #TExtraI 
	from Trading.dbo.WHInputs I 
	inner join Trading.dbo.WHInputsGoods IG on IG.WHInput = I.Uniq 
	inner join Trading.dbo.Depots D on I.Depot = D.Uniq 
	inner join Trading.dbo.Packings P on IG.Packing = P.Uniq 
	inner join Trading.dbo.Goods G on P.Good = G.Uniq 
	where	DateDiff(Day, I.DateConfirm, @dDate) = 0 and 
			I.WHSavedOddment > @nUniq and D.RemoteDepot is Null and 
			G.GoodsGroup <> 5 and G.Tare = 0 
	group by D.Owner, D.WMSGoodState, P.Good, P.InBox
select * from #TExtraI
select D.Owner as ERPOwner, D.WMSGoodState as ERPGoodState, P.Good as ERPGood, P.InBox, sum(OG.QntConfirmed) as Qnt 
	into #TExtraO 
	from Trading.dbo.WHOutputs O 
	inner join Trading.dbo.WHOutputsGoods OG on OG.WHOutput = O.Uniq 
	inner join Trading.dbo.Depots D on O.Depot = D.Uniq 
	inner join Trading.dbo.Packings P on OG.Packing = P.Uniq 
	inner join Trading.dbo.Goods G on P.Good = G.Uniq 
	where	DateDiff(Day, O.DateConfirm, @dDate) = 0 and 
			O.WHSavedOddment > @nUniq and D.RemoteDepot is Null and 
			G.GoodsGroup <> 5 and G.Tare = 0 
	group by D.Owner, D.WMSGoodState, P.Good, P.InBox
select * from #TExtraO

-- Добавление "поздних" приходов и расходов к сохраненным остаткам
-- Считаем, что все товары уже есть в таблице
update #TOdds set Qnt = #TOdds.Qnt + X.Qnt 
	from #TExtraI X 
	where	#TOdds.ERPOwner = X.ERPOwner and 
			#TOdds.ERPGoodState = X.ERPGoodState and 
			#TOdds.ERPGood = X.ERPGood and 
			#TOdds.InBox = X.InBox
update #TOdds set Qnt = #TOdds.Qnt - X.Qnt 
	from #TExtraO X 
	where	#TOdds.ERPOwner = X.ERPOwner and 
			#TOdds.ERPGoodState = X.ERPGoodState and 
			#TOdds.ERPGood = X.ERPGood and 
			#TOdds.InBox = X.InBox

-- Проверка наличия "левых" товаров
/*
select * from #TOdds 
	where	cast(ERPOwner as varchar(50)) + '_' + 
			cast(ERPGoodState as varchar(50)) + '_' + 
			cast(ERPGood as varchar(50)) 
	not in (select 
			cast(ERPOwner as varchar(50)) + '_' + 
			cast(ERPGoodState as varchar(50)) + '_' + 
			cast(ERPGood as varchar(50)) from #CalcOdds)
*/

-- Добавление товаров, отсутствующих в WMS
insert into #CalcOdds (ERPOwner, ERPGoodState, ERPGood, InBox)
	select ERPOwner, ERPGoodState, ERPGood, InBox 
	from #TOdds 
	where	cast(ERPOwner as varchar(50)) + '_' + 
			cast(ERPGoodState as varchar(50)) + '_' + 
			cast(ERPGood as varchar(50)) + '_' + 
			str(Inbox, 15, 3) 
	not in (select 
			cast(ERPOwner as varchar(50)) + '_' + 
			cast(ERPGoodState as varchar(50)) + '_' + 
			cast(ERPGood as varchar(50)) + '_' + 
			str(Inbox, 15, 3) 
			from #CalcOdds)

-- Установка остатков, полученных из Trading
update #CalcOdds set TQnt = T.Qnt 
	from #TOdds	T 
	where	#CalcOdds.ERPOwner = T.ERPOwner and 
			#CalcOdds.ERPGoodState = T.ERPGoodState and 
			#CalcOdds.ERPGood = T.ERPGood and 
			#CalcOdds.InBox = T.InBox

-- Получение внутренних кодов ID по ERP
update #CalcOdds set OwnerID = P.ID 
	from Partners P 
	where #CalcOdds.ERPOwner = P.ERPCode
update #CalcOdds set GoodStateID = GS.ID 
	from GoodsStates GS 
	where #CalcOdds.ERPGoodState = GS.ERPCode
update #CalcOdds set GoodID = G.ID 
	from Goods G 
	where #CalcOdds.ERPGood = G.ERPCode

-- Получение кода упаковки
update #CalcOdds set PackingID = P.ID 
	from Packings P
	where #CalcOdds.GoodID = P.GoodID and #CalcOdds.InBox = P.InBox
if exists (select top 1 * from #CalcOdds where PackingID is Null) begin
	raiserror(N'Unknown packings!', 16, 1)
	return
end

-- Получение суммарных расхождений
select OwnerID, GoodStateID, PackingID, QntEnd, TQnt, 
	IsNull(QntEnd, 0) - IsNull(TQnt, 0) as Diff 
	into #Finish 
	from #CalcOdds 
	where IsNull(QntEnd, 0) <> IsNull(TQnt, 0)

-- Тестовый просмотр
select * from #Finish 
	order by OwnerID, GoodStateID, PackingID

-- Создание актов
declare @nOwnerID int, @nGoodStateID int, @nNewID int
declare _Acts cursor static for 
	select distinct OwnerID, GoodStateID 
		from #Finish 
		order by OwnerID, GoodStateID
open _Acts
fetch next from _Acts into @nOwnerID, @nGoodStateID
while @@fetch_status = 0 begin
	begin tran
		insert into AuditActs (DateAudit, OwnerID, GoodStateID, Note, DateConfirm, ERPCode) 
			select @dDate, @nOwnerID, @nGoodStateID, 
				'Автоматический акт WMS для выравнивания остатков по хранителям', @dDate, Null
		if @@Error <> 0 goto Tr_InsError
		select @nNewID = @@Identity
		print str(@nNewID)
		
		insert into AuditActsGoods (AuditActID, PackingID, QntConfirmed) 
			select @nNewID, PackingID, -Diff 
				from #Finish 
				where OwnerID = @nOwnerID and GoodStateID = @nGoodStateID
		if @@Error <> 0 goto Tr_InsError
	commit tran
	goto Tr_InsOK
	
	Tr_InsError:
	rollback
	raiserror(N'Insert error!', 16, 1)
	return

	Tr_InsOK:
	fetch next from _Acts into @nOwnerID, @nGoodStateID
end

-- Закрытие курсора
close _Acts
deallocate _Acts
