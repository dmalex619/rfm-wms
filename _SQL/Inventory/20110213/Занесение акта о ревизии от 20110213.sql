-- Занесение акта о ревизии от 13.02.2011
use WMS
go

set nocount on

if object_id('__Buffer') is not Null drop table __Buffer
if object_id('Tempdb.dbo.#Rev') is not Null drop table #Rev

-- Получение данных из текстового файла, полученного от Хоменко
-- (экспорт из Excel)
create table __Buffer 
	(GoodStateName varchar(50), GoodERPCode varchar(50), InBox dec(15,3), QntAct dec(18,3), 
		f1 varchar(50), f2 varchar(50), f3 varchar(50), f4 varchar(50), f5 varchar(50), f6 varchar(50), f7 varchar(50))
exec master..xp_cmdshell 'bcp WMS.dbo.__Buffer in "E:\VS Projects\SuitableWMS\_SQL\Inventory\20110213\Revision20110213Result.txt" -c -k -w -T';
--select * from __Buffer

-- Получение временной таблицы
select	cast(Null as int) as HostID, 
		cast(Null as int) as OwnerID, 
		cast(Null as int) as GoodStateID, X.GoodStateName, 
		cast(Null as int) as PackingID, 
		X.GoodERPCode, X.InBox, 
		X.QntAct 
	into #Rev 
	from __Buffer X 
	where X.QntAct <> 0
drop table __Buffer

-- Получение ID справочников
update #Rev set HostID = G.HostID 
	from Goods G 
	where #Rev.GoodERPCode = G.ERPCode
delete #Rev 
	where HostID = 2	/* С Тимаксом не работаем */
update #Rev set OwnerID = case when HostID = 1 then 1 else 31194 end

update #Rev set GoodStateID = GS.ID 
	from GoodsStates GS 
	where #Rev.GoodStateName = GS.Name
update #Rev set PackingID = P.ID 
	from Goods G 
	inner join Packings P on P.GoodID = G.ID 
	where #Rev.GoodERPCode = G.ERPCode and #Rev.InBox = P.InBox

-- Проверка корректности упаковок
if exists (select top 1 PackingID from #Rev where PackingID is Null) begin
	raiserror(N'Unknown packings!', 16, 1)
	return
end

-- Служебные переменные
declare @dAct smalldatetime, @nAuditActID int, @nError int
select @dAct = cast('2011-02-13T23:59:00' as smalldatetime)

-- Создаем курсор по сочетанию Владелец + Состояние товара
declare @nHostID int, @nOwnerID int, @nGoodStateID int
declare _Rev cursor for 
	select distinct HostID, OwnerID, GoodStateID 
		from #Rev 
		order by 1,2
open _Rev

-- Пошли писать акты
fetch next from _Rev into @nHostID, @nOwnerID, @nGoodStateID
while @@fetch_status = 0 begin
	begin tran
		insert into AuditActs (DateAudit, OwnerID, GoodStateID, Note, DateConfirm, OddmentSavedID, ERPCode, HostID) 
			select	@dAct, @nOwnerID, @nGoodStateID, 
					'Акт на основании ревизии от 13.02.2011 (залит напрямую из Excel в WMS)', Null, Null, Null, @nHostID
		select @nAuditActID = @@identity, @nError = @@error
		if @nError <> 0 goto tr_rollback
			
		insert into AuditActsGoods (AuditActID, PackingID, QntConfirmed, ERPCode) 
			select @nAuditActID, PackingID, QntAct, Null 
				from #Rev 
				where OwnerID = @nOwnerID and GoodStateID = @nGoodStateID 
				order by PackingID
		select @nError = @@error
		if @nError <> 0 goto tr_rollback
		
	declare @cError varchar(200)
	exec up_AuditActsConfirm @nAuditActID, @nError output, @cError output
	if @nError <> 0 goto tr_rollback
	
	commit tran
	goto tr_next
	
	tr_rollback:
	print str(@nError)
	rollback
	
	tr_next:
	fetch next from _Rev into @nHostID, @nOwnerID, @nGoodStateID
end

close _Rev
deallocate _Rev

/*
select R.*, G.Alias
	from #Rev R 
	inner join Packings P on R.PackingID = P.ID 
	inner join Goods G on P.GoodID = G.ID 
	where R.HostID <> 1
*/
