SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_UpdatePartners]
	@nHostID int
-- SuitableWMSWebService
-- Обновление данных о партнерах
AS

set nocount on

-- Проверка существования таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_Partners') is Null begin
	RaisError(N'Отсутствует временная таблица #_Partners', 16, 1)
	return
end

-- Проверка дублирования ключевого поля
if exists (select ERPCode, count(*) from #_Partners group by ERPCode having count(*) > 1) begin
	RaisError(N'Повторяющиеся коды в таблице партнеров!', 16, 1)
	return
end

-- Обновление и добавление данных
begin tran
	update Partners set 
		Name = X.Name, Owner = X.Owner, 
		SeparatePicking = X.SeparatePicking, Actual = X.Actual 
		from #_Partners X 
		where Partners.ERPCode = X.ERPCode
	if @@Error <> 0 goto Tr_Error
	
	insert into Partners (HostID, ERPCode, Name, Owner, SeparatePicking, Actual) 
		select @nHostID, X.ERPCode, X.Name, X.Owner, X.SeparatePicking, X.Actual 
			from #_Partners X 
			where X.ERPCode not in (select ERPCode from Partners where ERPCode is not Null) 
			order by X.ERPCode
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
return