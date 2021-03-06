SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_UpdateGoodsBrands]
	@nHostID int
-- SuitableWMSWebService
-- Обновление данных о торговых марках
AS

set nocount on

-- Проверка существования таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_GoodsBrands') is Null begin
	RaisError(N'Отсутствует временная таблица #_GoodsBrands', 16, 1)
	return
end

-- Проверка дублирования ключевого поля
if exists (select ERPCode, count(*) from #_GoodsBrands group by ERPCode having count(*) > 1) begin
	RaisError(N'Повторяющиеся коды в таблице товарных брендов!', 16, 1)
	return
end

-- Обновление и добавление данных
begin tran
	update GoodsBrands set 
		Name = X.Name, Actual = X.Actual 
		from #_GoodsBrands X 
		where GoodsBrands.ERPCode = X.ERPCode
	if @@Error <> 0 goto Tr_Error

	insert into GoodsBrands (HostID, ERPCode, Name, Actual) 
		select @nHostID, ERPCode, Name, Actual 
		from #_GoodsBrands 
		where ERPCode not in (select ERPCode from GoodsBrands where ERPCode is not Null) 
		order by ERPCode
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
return