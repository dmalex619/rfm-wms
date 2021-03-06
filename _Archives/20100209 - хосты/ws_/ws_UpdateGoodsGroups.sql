SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_UpdateGoodsGroups]
	@nHostID int
-- SuitableWMSWebService
-- Обновление данных о товарных группах
AS

set nocount on

-- Проверка существования таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_GoodsGroups') is Null begin
	RaisError(N'Отсутствует временная таблица #_GoodsGroups', 16, 1)
	return
end

-- Проверка дублирования ключевого поля
if exists (select ERPCode, count(*) from #_GoodsGroups group by ERPCode having count(*) > 1) begin
	RaisError(N'Повторяющиеся коды в таблице товарных групп!', 16, 1)
	return
end

-- Обновление и добавление данных
begin tran
	update GoodsGroups set 
		Name = X.Name, Actual = X.Actual 
		from #_GoodsGroups X 
		where GoodsGroups.ERPCode = X.ERPCode
	if @@Error <> 0 goto Tr_Error

	insert into GoodsGroups (HostID, ERPCode, Name, Actual) 
		select @nHostID, ERPCode, Name, Actual 
		from #_GoodsGroups 
		where ERPCode not in (select ERPCode from GoodsGroups where ERPCode is not Null) 
		order by ERPCode
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
return