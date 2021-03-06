SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_FillOneOutput]
	@nHostID		int, 
	@cERPCode		varchar(50), 
	@cERPBarCode	varchar(50), 
	@dDateOutput	smalldatetime, 
	@cERPPartner	varchar(50), 
	@cERPOwner		varchar(50), 
	@cERPOutputType	varchar(50), 
	@cERPGoodState	varchar(50), 
	@cNote			varchar(250), 
	@cCarAlias		varchar(50), 
	@bBackDoor		bit, 
	@cChargeOrder	varchar(50)
-- SuitableWMSWebService
-- Заполнение одного расхода
AS

set nocount on

-- Проверка существования временной таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_OutputsGoods') is Null begin
	RaisError(N'Отсутствует временная таблица #_OutputsGoods', 16, 1)
	goto Tr_Error
end

-- Внутренние переменные
declare @dDateStart smalldatetime, @dDateConfirm smalldatetime, @cState char(1), @nOutputID int

-- Поиск данных об отгрузке по его ERPCode
select @nOutputID = ID, @dDateStart = DateStart, @dDateConfirm = DateConfirm 
	from Outputs with (nolock) 
	where ERPCode = @cERPCode

-- Определение дальнейшего режима работы (возвращаемая величина)
-- I - добавление, U - обновление, S - отказ от изменений, E - ошибка
set @cState = case 
	when @nOutputID is Null then 'I' 
	when (@dDateStart is not Null or @dDateConfirm is not Null) then 'S' 
	else 'U' end
if @cState = 'S' goto Tr_End

-- Переменные для поиска кодов поставщика и владельца
declare @nPartnerID int, @nOwnerID int

-- Поиск кодов поставщика и владельца
select @nPartnerID = ID 
	from Partners with (nolock) 
	where ERPCode = @cERPPartner
if @nPartnerID is Null set @nPartnerID = dbo._SettingsGetValue('gnWe')
if @nPartnerID is Null begin
	RaisError(N'Не найден получатель', 16, 1)
	goto Tr_Error
end

select @nOwnerID = ID 
	from Partners with (nolock) 
	where ERPCode = @cERPOwner
if @nOwnerID is Null begin
	RaisError(N'Не найден владелец', 16, 1)
	goto Tr_Error
end

-- Получение кода типа расхода
declare @nOutputTypeID int
select @nOutputTypeID = ID 
	from OutputsTypes with (nolock) 
	where ERPCode = @cERPOutputType
if @nOutputTypeID is Null begin
	RaisError(N'Не найден тип расхода', 16, 1)
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
update #_OutputsGoods set PackingID = X.MaxID 
	from (select G.ERPCode as ERPCode, P.InBox, max(P.ID) as MaxID 
			from Packings P 
			inner join Goods G on P.GoodID = G.ID 
			group by G.ERPCode, P.InBox) X 
	where #_OutputsGoods.ERPGood = X.ERPCode and #_OutputsGoods.InBox = X.InBox

-- Проверка поля PackingID
declare @cErrorPackingID varchar(max)
select top 1 @cErrorPackingID = 
	cast(ERPGood as varchar(max)) + ' (' + cast(InBox as varchar(max)) + ')' 
	from #_OutputsGoods 
	where PackingID is Null
if @cErrorPackingID is not Null begin
	RaisError(N'Не найдена упаковка для товара %s', 16, 1, @cErrorPackingID)
	goto Tr_Error
end

begin tran
	-- Режим добавления
	if @cState = 'I' begin
		-- Отгрузка
		insert into Outputs (HostID, ERPCode, ERPBarCode, DateOutput, PartnerID, OwnerID, 
							OutputTypeID, GoodStateID, Note, CarAlias, BackDoor, ChargeOrder) 
			select	@nHostID, @cERPCode, @cERPBarCode, @dDateOutput, @nPartnerID, @nOwnerID, 
					@nOutputTypeID, @nGoodStateID, @cNote, @cCarAlias, @bBackDoor, @cChargeOrder
		if @@Error <> 0 goto Tr_Error
		
		-- Расшифровки отгрузки
		set @nOutputID = @@Identity
		insert into OutputsGoods (OutputID, GoodStateID, PackingID, 
			QntWished, DateValid, ERPCode, ERPIndex, ERPNote) 
			select @nOutputID, @nGoodStateID, PackingID, 
				QntWished, DateValid, ERPCode, ERPIndex, ERPNote 
				from #_OutputsGoods
		if @@Error <> 0 goto Tr_Error
	end
	
	-- Режим обновления
	if @cState = 'U' begin
		-- Обновление отгрузки
		update Outputs set 
			ERPBarCode		= @cERPBarCode, 
			DateOutput		= @dDateOutput, 
			PartnerID		= @nPartnerID, 
			OwnerID			= @nOwnerID, 
			OutputTypeID	= @nOutputTypeID, 
			GoodStateID		= @nGoodStateID, 
			Note			= @cNote, 
			CarAlias		= @cCarAlias, 
			BackDoor		= @bBackDoor, 
			ChargeOrder		= @cChargeOrder 
			where ID = @nOutputID
		if @@Error <> 0 goto Tr_Error
		
		-- Удаление лишних расшифровок отгрузки
		delete OutputsGoods 
			where OutputID = @nOutputID and 
				ERPCode not in (select ERPCode from #_OutputsGoods X)
		
		-- Обновление расшифровок отгрузки
		update OutputsGoods set 
			GoodStateID		= @nGoodStateID, 
			PackingID		= X.PackingID, 
			QntWished		= X.QntWished, 
			DateValid		= X.DateValid, 
			ERPIndex		= X.ERPIndex, 
			ERPNote			= X.ERPNote 
			from #_OutputsGoods X 
			where OutputID = @nOutputID and OutputsGoods.ERPCode = X.ERPCode
		if @@Error <> 0 goto Tr_Error
		
		-- Добавление расшифровок отгрузки
		insert into OutputsGoods (OutputID, GoodStateID, PackingID, 
			QntWished, DateValid, ERPCode, ERPIndex, ERPNote) 
			select @nOutputID, @nGoodStateID, PackingID, 
				QntWished, DateValid, ERPCode, ERPIndex, ERPNote 
				from #_OutputsGoods 
				where ERPCode not in 
					(select ERPCode from OutputsGoods 
						where OutputID = @nOutputID and ERPCode is not Null)
		if @@Error <> 0 goto Tr_Error
	end

commit tran
goto Tr_End

-- Установка режима "Ошибка"
Tr_Error:
set @cState = 'E'
if @@TranCount > 0 rollback

Tr_End:
if @cState = 'S' begin
	-- Обновление только даты и справочной информации!
	update Outputs set 
		DateOutput		= @dDateOutput, 
		Note			= @cNote,  
		CarAlias		= @cCarAlias, 
		BackDoor		= @bBackDoor, 
		ChargeOrder		= @cChargeOrder 
		where ID = IsNull(@nOutputID, 0)
end

-- Выход с отображением режима
select @cState
return