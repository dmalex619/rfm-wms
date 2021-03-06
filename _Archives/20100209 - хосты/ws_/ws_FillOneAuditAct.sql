SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_FillOneAuditAct]
	@nHostID		int, 
	@cERPCode		varchar(50), 
	@dDateAudit		smalldatetime, 
	@cERPOwner		varchar(50), 
	@cERPGoodState	varchar(50), 
	@cNote			varchar(250)
-- SuitableWMSWebService
-- Заполнение одного акта на списание товара через LOST&FOUND
AS

set nocount on

-- Проверка существования временной таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_AuditActsGoods') is Null begin
	RaisError(N'Отсутствует временная таблица #_AuditActsGoods', 16, 1)
	goto Tr_Error
end

-- Внутренние переменные
declare @dDateConfirm smalldatetime, @cState char(1), @nAuditActID int

-- Поиск данных об акте по его ERPCode
select @nAuditActID = ID, @dDateConfirm = DateConfirm 
	from AuditActs with (nolock) 
	where ERPCode = @cERPCode

-- Определение дальнейшего режима работы (возвращаемая величина)
-- I - добавление, U - обновление, S - отказ от изменений, E - ошибка
set @cState = case 
	when @nAuditActID is Null then 'I' 
	when (@dDateConfirm is not Null) then 'S' 
	else 'U' end
if @cState = 'S' goto Tr_End

-- Переменные для поиска кода владельца
declare @nOwnerID int

select @nOwnerID = ID 
	from Partners with (nolock) 
	where ERPCode = @cERPOwner
if @nOwnerID is Null begin
	RaisError(N'Не найден владелец', 16, 1)
	goto Tr_Error
end

-- Получение кода состояния товара
declare @nGoodStateID int
select @nGoodStateID = ID 
	from GoodsStates with (nolock) 
	where ERPCode = @cERPGoodState
if @nGoodStateID is Null begin
	RaisError(N'Не найдено состояние товара', 16, 1)
	goto Tr_Error
end

-- Заполнение поля PackingID во временной таблице
update #_AuditActsGoods set PackingID = X.MaxID 
	from (select G.ERPCode as ERPCode, P.InBox, max(P.ID) as MaxID 
			from Packings P 
			inner join Goods G on P.GoodID = G.ID 
			group by G.ERPCode, P.InBox) X 
	where #_AuditActsGoods.ERPGood = X.ERPCode and #_AuditActsGoods.InBox = X.InBox

-- Проверка поля PackingID
declare @cErrorPackingID varchar(max)
select top 1 @cErrorPackingID = 
	cast(ERPGood as varchar(max)) + ' (' + cast(InBox as varchar(max)) + ')' 
	from #_AuditActsGoods 
	where PackingID is Null
if @cErrorPackingID is not Null begin
	RaisError(N'Не найдена упаковка для товара %s', 16, 1, @cErrorPackingID)
	goto Tr_Error
end

begin tran
	-- Режим добавления
	if @cState = 'I' begin
		-- Акт
		insert into AuditActs (HostID, ERPCode, DateAudit, OwnerID, GoodStateID, Note) 
			select @nHostID, @cERPCode, @dDateAudit, @nOwnerID, @nGoodStateID, @cNote
		if @@Error <> 0 goto Tr_Error
		
		-- Расшифровки акта
		set @nAuditActID = @@Identity
		insert into AuditActsGoods (AuditActID, PackingID, QntConfirmed, ERPCode) 
			select @nAuditActID, PackingID, Qnt, ERPCode 
				from #_AuditActsGoods
		if @@Error <> 0 goto Tr_Error
	end
	
	-- Режим обновления
	if @cState = 'U' begin
		-- Обновление акта
		update AuditActs set 
			DateAudit		= @dDateAudit, 
			OwnerID			= @nOwnerID, 
			GoodStateID		= @nGoodStateID, 
			Note			= @cNote 
			where ID = @nAuditActID
		if @@Error <> 0 goto Tr_Error
		
		-- Удаление лишних расшифровок акта
		delete AuditActsGoods 
			where AuditActID = @nAuditActID and 
				ERPCode not in (select ERPCode from #_AuditActsGoods X)
		
		-- Обновление расшифровок акта
		update AuditActsGoods set 
			PackingID		= X.PackingID, 
			QntConfirmed	= X.Qnt 
			from #_AuditActsGoods X 
			where AuditActID = @nAuditActID and AuditActsGoods.ERPCode = X.ERPCode
		if @@Error <> 0 goto Tr_Error
		
		-- Добавление расшифровок акта
		insert into AuditActsGoods (AuditActID, PackingID, QntConfirmed, ERPCode) 
			select @nAuditActID, PackingID, Qnt, ERPCode 
				from #_AuditActsGoods 
				where ERPCode not in 
					(select ERPCode from AuditActsGoods 
						where AuditActID = @nAuditActID and ERPCode is not Null)
		if @@Error <> 0 goto Tr_Error
	end
	
	-- Автоматическое проведение акта
	declare @nError int, @cError varchar(200)
	exec up_AuditActsConfirm @nAuditActID, @nError output, @cError output
	if @nError <> 0 goto Tr_Error

commit tran
goto Tr_End

-- Установка режима "Ошибка"
Tr_Error:
set @cState = 'E'
if @@TranCount > 0 rollback

-- Выход с отображением режима
Tr_End:
select @cState
return