set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[mob_MakeReturnForOutput] 
	@cOutputBarCode		varchar(max)
AS
-- Процедура автоматического создания возврата по Ш/К расхода
-- Возврат может создаваться для отгрузок в производство или клиенту

-- Проверка параметра @cOutputBarCode (Ш/К расхода)
if len(@cOutputBarCode) = 0 begin
	raiserror(N'Пустой штрих-код отгрузки!', 16, 1)
	return
end

-- Поиск расхода по его Ш/К
declare @nOutputID int
select top 1 @nOutputID = ID 
	from Outputs with (nolock) 
	where ERPBarCode = @cOutputBarCode
if @nOutputID is Null begin
	raiserror(N'Отгрузки с заданным штрих-кодом не существует!', 16, 1)
	return
end

-- Получение данных о расходе
declare	@cERPCode varchar(max), @nHostID int, @dDateOutput smalldatetime, 
		@nPartnerID int, @nOwnerID int, @nGoodStateID int
select	@nHostID		= HostID, 
		@cERPCode		= ERPCode, 
		@dDateOutput	= DateOutput, 
		@nPartnerID		= PartnerID, 
		@nOwnerID		= OwnerID, 
		@nGoodStateID	= GoodStateID 
	from Outputs with (nolock) 
	where ID = @nOutputID

-- Попытка получения типа прихода (пока первый попавшийся)
declare @nInputTypeID int
select top 1 @nInputTypeID = ID 
	from InputsTypes with (nolock) 
	where charindex(Name, 'возврат') > 0 
	order by ID
if @nInputTypeID is Null begin
	select top 1 @nInputTypeID = ID 
		from InputsTypes with (nolock) 
		order by ID
end

-- Создание нового прихода на основании отгрузки
declare @nInputID int
begin tran
	-- Сам приход
	insert into Inputs (HostID, DateInput, InputTypeID, PartnerID, OwnerID, GoodStateID, 
			Note, ERPCode, ERPBarCode) 
		values (@nHostID, @dDateOutput, @nInputTypeID, @nPartnerID, @nOwnerID, @nGoodStateID, 
			'Автоматический возврат к отгрузке № ' + @cERPCode, @cERPCode, @cOutputBarCode)
	if @@Error <> 0 goto tr_Error
	
	-- Получение кода прихода
	select @nInputID = @@Identity
	if @@Error <> 0 goto tr_Error
	
	-- Создание товарных расшифровок
	insert into InputsGoods (InputID, GoodStateID, PackingID, QntWished) 
		select @nInputID, @nGoodStateID, OG.PackingID, 0 
			from OutputsGoods OG with (nolock) 
			inner join Packings P with (nolock) on OG.PackingID = P.ID 
			where OG.OutputID = @nOutputID
	if @@Error <> 0 goto tr_Error

commit tran
select @nInputID as ID
return

tr_Error:
rollback
raiserror(N'Ошибка автоматического создания возврата!', 16, 1)
return