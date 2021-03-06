SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_FillOneInput]
	@nHostID		int, 
	@cERPCode		varchar(50), 
	@cERPBarCode	varchar(50), 
	@dDateInput		smalldatetime, 
	@cERPPartner	varchar(50), 
	@cERPOwner		varchar(50), 
	@cERPInputType	varchar(50), 
	@cERPGoodState	varchar(50), 
	@cNote			varchar(250)
-- SuitableWMSWebService
-- Заполнение одного прихода
AS

set nocount on

-- Проверка существования временной таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_InputsGoods') is Null begin
	RaisError(N'Отсутствует временная таблица #_InputsGoods', 16, 1)
	goto Tr_Error
end

-- Внутренние переменные
declare @dDateStart smalldatetime, @dDateConfirm smalldatetime, @cState char(1), @nInputID int

-- Поиск данных о приходе по его ERPCode
select @nInputID = ID, @dDateStart = DateStart, @dDateConfirm = DateConfirm 
	from Inputs with (nolock) 
	where ERPCode = @cERPCode

declare @bItemsExists bit
if exists(select top 1 ID from InputsItems with (nolock) where InputID = IsNull(@nInputID, 0))
	set @bItemsExists = 1
else
	set @bItemsExists = 0

-- Определение дальнейшего режима работы (возвращаемая величина)
-- I - добавление, U - обновление, S - отказ от изменений, E - ошибка
set @cState = case 
	when @nInputID is Null then 'I' 
--	when (@dDateStart is not Null or @dDateConfirm is not Null) then 'S' 
	when (@dDateConfirm is not Null or @bItemsExists = 1) then 'S' 
	else 'U' end
if @cState = 'S' goto Tr_End

-- Переменные для поиска кодов поставщика и владельца
declare @nPartnerID int, @nOwnerID int

-- Поиск кодов поставщика и владельца
select @nPartnerID = ID 
	from Partners with (nolock) 
	where ERPCode = @cERPPartner
if @nPartnerID is Null begin
	RaisError(N'Не найден поставщик', 16, 1)
	goto Tr_Error
end

select @nOwnerID = ID 
	from Partners with (nolock) 
	where ERPCode = @cERPOwner
if @nOwnerID is Null begin
	RaisError(N'Не найден владелец', 16, 1)
	goto Tr_Error
end

-- Получение кода типа прихода
declare @nInputTypeID int
select @nInputTypeID = ID 
	from InputsTypes with (nolock) 
	where ERPCode = @cERPInputType
if @nInputTypeID is Null begin
	RaisError(N'Не найден тип прихода', 16, 1)
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
update #_InputsGoods set PackingID = X.MaxID 
	from (select G.ERPCode as ERPCode, P.InBox, max(P.ID) as MaxID 
			from Packings P 
			inner join Goods G on P.GoodID = G.ID 
			group by G.ERPCode, P.InBox) X 
	where #_InputsGoods.ERPGood = X.ERPCode and #_InputsGoods.InBox = X.InBox

-- Проверка поля PackingID
declare @cErrorPackingID varchar(max)
select top 1 @cErrorPackingID = 
	cast(ERPGood as varchar(max)) + ' (' + cast(InBox as varchar(max)) + ')' 
	from #_InputsGoods 
	where PackingID is Null
if @cErrorPackingID is not Null begin
	RaisError(N'Не найдена упаковка для товара %s', 16, 1, @cErrorPackingID)
	goto Tr_Error
end

begin tran
	-- Режим добавления
	if @cState = 'I' begin
		-- Приход
		insert into Inputs (HostID, ERPCode, ERPBarCode, DateInput, PartnerID, OwnerID, 
							InputTypeID, GoodStateID, Note) 
			select	@nHostID, @cERPCode, @cERPBarCode, @dDateInput, @nPartnerID, @nOwnerID, 
					@nInputTypeID, @nGoodStateID, @cNote
		if @@Error <> 0 goto Tr_Error
		
		-- Расшифровки прихода
		set @nInputID = @@Identity
		insert into InputsGoods (InputID, GoodStateID, PackingID, 
			QntWished, ERPCode) 
			select @nInputID, @nGoodStateID, PackingID, 
				QntWished, ERPCode 
				from #_InputsGoods
		if @@Error <> 0 goto Tr_Error
	end
	
	-- Режим обновления
	if @cState = 'U' begin
		-- Обновление прихода
		update Inputs set 
			ERPBarCode		= @cERPBarCode, 
			DateInput		= @dDateInput, 
			PartnerID		= @nPartnerID, 
			OwnerID			= @nOwnerID, 
			InputTypeID		= @nInputTypeID, 
			GoodStateID		= @nGoodStateID, 
			Note			= @cNote 
			where ID = @nInputID
		if @@Error <> 0 goto Tr_Error
		
		-- Удаление лишних расшифровок прихода
		delete InputsGoods 
			where InputID = @nInputID and 
				ERPCode not in (select ERPCode from #_InputsGoods X)
		
		-- Обновление расшифровок прихода
		update InputsGoods set 
			GoodStateID		= @nGoodStateID, 
			PackingID		= X.PackingID, 
			QntWished		= X.QntWished 
			from #_InputsGoods X 
			where InputID = @nInputID and InputsGoods.ERPCode = X.ERPCode
		if @@Error <> 0 goto Tr_Error
		
		-- Добавление расшифровок прихода
		insert into InputsGoods (InputID, GoodStateID, PackingID, 
			QntWished, ERPCode) 
			select @nInputID, @nGoodStateID, PackingID, 
				QntWished, ERPCode 
				from #_InputsGoods 
				where ERPCode not in 
					(select ERPCode from InputsGoods 
						where InputID = @nInputID and ERPCode is not Null)
		if @@Error <> 0 goto Tr_Error
	end

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