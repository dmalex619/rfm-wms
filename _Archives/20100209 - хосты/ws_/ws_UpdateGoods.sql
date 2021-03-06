SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_UpdateGoods]
	@nHostID int
-- SuitableWMSWebService
-- Обновление данных о товарах
AS

set nocount on

-- Проверка существования таблицы (создается в WebService)
if object_id('Tempdb.dbo.#_Goods') is Null begin
	RaisError(N'Отсутствует временная таблица #_Goods', 16, 1)
	return
end

-- Проверка наличия ссылок на товарные группы и торговые марки
if exists (select top 1 * from #_Goods 
		where ERPGoodGroup not in (select ERPCode from GoodsGroups)) begin
	RaisError(N'Неизвестные товарные группы во временной таблице товаров!', 16, 1)
	return
end
if exists (select top 1 * from #_Goods 
		where ERPGoodBrand not in (select ERPCode from GoodsBrands)) begin
	RaisError(N'Неизвестные торговые марки во временной таблице товаров!', 16, 1)
	return
end

-- Проверка дублирования ключевого поля
if exists (select ERPCode, count(*) from #_Goods group by ERPCode having count(*) > 1) begin
	RaisError(N'Повторяющиеся коды в таблице товаров!', 16, 1)
	return
end

-- Обновление и добавление данных
begin tran
	update Goods set 
		GoodGroupID = GG.ID, 
		GoodBrandID = GB.ID, 
		Alias = X.Alias, Name = X.Name, Articul = X.Articul, 
		BarCode = X.BarCode, Netto = X.Netto, Brutto = X.Brutto, 
		Retention = X.Retention, Weighting = X.Weighting, 
		HalfStuff = X.HalfStuff, TemperatureMode = X.TemperatureMode, 
		Gravity = X.Gravity, Actual = X.Actual 
		from #_Goods X 
		inner join GoodsGroups GG on X.ERPGoodGroup = GG.ERPCode 
		inner join GoodsBrands GB on X.ERPGoodBrand = GB.ERPCode 
		where Goods.ERPCode = X.ERPCode
	if @@Error <> 0 goto Tr_Error
	
	insert into Goods (HostID, ERPCode, GoodGroupID, GoodBrandID, 
			Alias, Name, Articul, BarCode, Netto, Brutto, 
			Retention, Weighting, HalfStuff, TemperatureMode, Gravity, Actual) 
		select	@nHostID, X.ERPCode, GG.ID, GB.ID, 
				X.Alias, X.Name, X.Articul, X.BarCode, X.Netto, X.Brutto, 
				X.Retention, X.Weighting, X.HalfStuff, X.TemperatureMode, X.Gravity, X.Actual 
			from #_Goods X 
			inner join GoodsGroups GG on X.ERPGoodGroup = GG.ERPCode 
			inner join GoodsBrands GB on X.ERPGoodBrand = GB.ERPCode 
			where X.ERPCode not in (select ERPCode from Goods where ERPCode is not Null) 
			order by X.ERPCode
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
return