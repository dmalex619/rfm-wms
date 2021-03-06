SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_TrafficsGoodsCreateManual]
	@nPackingID		int,			-- товар
	@nQntWished		decimal(18, 3), -- количество
	@dDateValid		smalldatetime,  -- срок годности
	@nGoodStateID	int,			-- состояние товара
	@nOwnerID		int,			-- владелец
	@nCellSourceID	int,			-- исходная ячейка
	@nCellTargetID	int = Null, 
	@nError			int = 0 output, 
	@cErrorText		varchar(200) = '' output 
AS
-- вызов процедуры для создания операции перемещения коробок/штук

if @nPackingID is Null or
	not exists (select ID from Packings with (nolock) where ID = @nPackingID) begin
	select	@nError = -1, 
			@cErrorText = 'Не определен товар...'
	RaisError(@cErrorText, 16, 1)
	return
end
if IsNull(@nQntWished, 0) = 0 begin
	select	@nError = -2, 
			@cErrorText = 'Не определено количество...'
	RaisError(@cErrorText, 16, 1)
	return
end
if @nGoodStateID is Null or
	not exists (select ID from GoodsStates where ID = @nGoodStateID) begin
	select	@nError = -3, 
			@cErrorText = 'Не определено состояние товара...'
	RaisError(@cErrorText, 16, 1)
	return
end
if  @nOwnerID is not Null and 
	not exists (select ID from Partners where ID = @nOwnerID) begin
	select	@nError = -4, 
			@cErrorText = 'Не определен владелец...'
	RaisError(@cErrorText, 16, 1)
	return
end

declare @bCellLocked bit, 
		@bCellActual bit, 
		@bCellDeleted bit, 
		@bForFrames bit
-- исходная ячейка? 
select  @bCellLocked = C.Locked, 
		@bCellActual = C.Actual, 
		@bCellDeleted = C.Deleted, 
		@bForFrames = SZT.ForFrames
	from	Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID
	where	C.ID = @nCellSourceID 
if @@RowCount = 0 begin 
	select	@nError = -11, 
			@cErrorText = 'Не определена исходная ячейка...'
	return
end
if @bCellActual = 0 begin 
	select	@nError = -12, 
			@cErrorText = 'Исходная ячейка не актуальна...'
	RaisError(@cErrorText, 16, 1)
	return
end 
if @bCellLocked = 1 begin 
	select	@nError = -13, 
			@cErrorText = 'Исходная ячейка блокирована...'
	RaisError(@cErrorText, 16, 1)
	return
end 
if @bCellDeleted = 1 begin 
	select	@nError = -14, 
			@cErrorText = 'Исходная ячейка удалена...'
	RaisError(@cErrorText, 16, 1)
	return
end 
if @bForFrames is not Null and @bForFrames = 1 begin
	select	@nError = -15, 
			@cErrorText = 'Исходная ячейка предназначена только для контейнеров...'
	RaisError(@cErrorText, 16, 1)
	return 
end 

-- есть товар?
declare @nQnt decimal(18, 3)
select	@nQnt = sum(Qnt)
	from	CellsContents with (nolock) 
	where	CellID = @nCellSourceID and
			PackingID = @nPackingID and 
			GoodStateID = @nGoodStateID and 
			IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
if IsNull(@nQnt, 0) < @nQntWished begin
	select	@nError = -40, 
			@cErrorText = 'Исходная ячейка не содержит необходимого количества товара...'
	RaisError(@cErrorText, 16, 1)
	return 
end

-- конечная ячейка? 
select  @bCellLocked = C.Locked, 
		@bCellActual = C.Actual, 
		@bCellDeleted = C.Deleted, 
		@bForFrames = SZT.ForFrames
	from	Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID
	where	C.ID = @nCellTargetID 
if @@RowCount = 0 begin 
	select	@nError = -21, 
			@cErrorText = 'Не определена конечная ячейка...'
	return
end
if @bCellActual = 0 begin 
	select	@nError = -22, 
			@cErrorText = 'Конечная ячейка не актуальна...'
	RaisError(@cErrorText, 16, 1)
	return
end 
if @bCellLocked = 1 begin 
	select	@nError = -23, 
			@cErrorText = 'Конечная ячейка блокирована...'
	RaisError(@cErrorText, 16, 1)
	return
end 
if @bCellDeleted = 1 begin 
	select	@nError = -24, 
			@cErrorText = 'Конечная ячейка удалена...'
	RaisError(@cErrorText, 16, 1)
	return
end 
if @bForFrames is not Null and @bForFrames = 1 begin
	select	@nError = -25, 
			@cErrorText = 'Конечная ячейка предназначена только для контейнеров...'
	RaisError(@cErrorText, 16, 1)
	return 
end

-- Передаем управление процедуре создания перемещения
exec up_TrafficsGoodsOneCreate 
	@nOwnerID, @nGoodStateID, 
	@nPackingID, @nQntWished, @dDateValid, 
	@nCellSourceID, @nCellTargetID, Null, -- @nFrameID
	Null, Null, Null, -- @nInputID, @nOutputID, @nOutputGoodID 
	'', -- @cNote
	@nError output
if @nError <> 0 
	set @nError = @nError - 100
return