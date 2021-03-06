set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_PackingsFixedSave]
	@nPackingID		int, 
	@nCellID		int, 
	@nGoodStateID	int = Null, 
	@nOwnerID		int = Null,
	@nError			int = 0 output,
	@cErrorStr		varchar(200) = '' output 
AS
-- сохранение фиксированных привязок товара

declare @cCellAddress varchar(20), @bForPicking bit, @cTemperatureMode varchar(1)
-- проверки...
-- есть ячейка?
select @cCellAddress = C.Address, @bForPicking = SZT.ForPicking, 
		@cTemperatureMode = SZ.TemperatureMode 
	from Cells C with (nolock)
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where C.ID = @nCellID and C.Deleted = 0
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Не найдена ячейка с кодом ' + ltrim(str(@nCellID)) + '...'
	RaisError (@cErrorStr, 11, 1)
	return
end
-- ячейка пикинга?
if @bForPicking = 0 begin
	select	@nError = -2, 
			@cErrorStr = 'Ячейка ' + @cCellAddress + ' не является ячейкой пикинга...'
	RaisError (@cErrorStr, 11, 1)
	return
end
-- ячейка пуста?
-- (чтобы изменение фиксированных привязок не нарушило динамические привязки для товара, который уже в ней лежит)... 
if exists (select ID from CellsContents with (nolock) where CellID = @nCellID) begin
	select	@nError = -3, 
			@cErrorStr = 'Ячейка ' + @cCellAddress + ' не пуста...'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- подходит по температурному режиму?
if @cTemperatureMode is not Null begin
	if isNull((select G.TemperatureMode 
				from Packings P with (nolock) 
				inner join Goods G with (nolock) on P.GoodID = G.ID 
				where P.ID = @nPackingID), ' ') <> @cTemperatureMode begin 
		select	@nError = -4, 
				@cErrorStr = 'Температурный режим ячейки ' + @cCellAddress + ' не соответствует температурному режиму товара...'
		RaisError (@cErrorStr, 11, 1)
		return
	end 
end 

-- состояние товара - обязательно
if @nGoodStateID is Null 
	select  top 1 @nGoodStateID = ID
		from GoodsStates with (nolock)
		where Basic = 1

-- уже есть такая привязка? 
if exists (select ID from Cells with (nolock)
			where FixedPackingID = @nPackingID and  
				FixedGoodStateID = @nGoodStateID and  
				isNull(FixedOwnerID, -1) = isNull(@nOwnerID, -1) ) begin
	select	@nError = -5, 
			@cErrorStr = 'При привязке ячейки ' + @cCellAddress + ' обнаружена другая ячейка пикинга, закрепленая за тем же владельцем, состоянием и товаром....'
	RaisError (@cErrorStr, 11, 1)
	return
end

-- собственно привязка
update Cells 
	set FixedPackingID = @nPackingID, 
		FixedGoodStateID = @nGoodStateID, 
		FixedOwnerID = @nOwnerID 
	where ID = @nCellID
if @@Error > 0 begin
	select	@nError = @@Error, 
			@cErrorStr = 'Ошибка при закреплении ячейки ' + ltrim(str(@nCellID)) + '...'
	RaisError (@cErrorStr, 11, 1)
	return
end
return