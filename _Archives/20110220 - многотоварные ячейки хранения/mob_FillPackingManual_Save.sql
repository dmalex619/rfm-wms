SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_FillPackingManual_Save]
	@nFrameID		int, 
	@nCellSourceID	int, 
	@nCellTargetID	int
AS
-- Процедура создания ручной подпитки ячейки пикинга

set nocount on

-- Проверка параметров
if @nFrameID is Null or @nCellSourceID is Null or @nCellTargetID is Null begin
	raiserror(N'Отсутствуют параметры процедуры!', 16, 1)
	return
end

-- Получение данных об исходной и целевой ячейках и их проверка
declare @nSourcePackingID int, @nSourceGoodStateID int, @nSourceOwnerID int, 
		@nTargetPackingID int, @nTargetGoodStateID int, @nTargetOwnerID int 
select	@nSourcePackingID = CC.PackingID, 
		@nSourceGoodStateID = CC.GoodStateID, 
		@nSourceOwnerID = CC.OwnerID 
	from CellsContents CC with (nolock) 
	where CC.CellID = @nCellSourceID and CC.FrameID = @nFrameID
if @@RowCount > 1 begin
	raiserror(N'Обнаружена неуникальность товаров в контейнере!', 16, 1)
	return
end
if @nSourcePackingID is Null or @nSourceGoodStateID is Null begin
	raiserror(N'В контейнере отстуствует товар!', 16, 1)
	return
end

select	@nTargetPackingID = C.FixedPackingID, 
		@nTargetGoodStateID = C.FixedGoodStateID, 
		@nTargetOwnerID = C.FixedOwnerID 
	from Cells C with (nolock) 
	where C.ID = @nCellTargetID
if @nTargetPackingID is Null or @nTargetGoodStateID is Null begin
	raiserror(N'В ячейке пикинга отстуствует закрепленный товар!', 16, 1)
	return
end

if	@nSourcePackingID <> @nTargetPackingID or 
	@nSourceGoodStateID <> @nTargetGoodStateID or 
	IsNull(@nSourceOwnerID, -1) <> IsNull(@nTargetOwnerID, -1) begin
	raiserror(N'Несовпадение товаров в контейнере и ячейке пикинга!', 16, 1)
	return
end

-- Все проверки пройдены, создаем перемещение
declare @nDefaultPriority int
set @nDefaultPriority = 2 -- взять из _Settings 

begin tran
	insert TrafficsFrames 
		(FrameID, CellSourceID, CellTargetID, InputID, OutputID, 
		DateBirth, Priority, Note)
		values 
			(@nFrameID, @nCellSourceID, @nCellTargetID, Null, Null, 
			GetDate(), @nDefaultPriority, 'Ручная подпитка пикинга')
	if @@Error <> 0 goto Tr_Error
	
	update	Frames	
		set	 State = 'T', HasTraffic = 1, DateLastOperation = GetDate()
		where	ID = @nFrameID
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
raiserror(N'Ошибка при сохранении данных!', 16, 1)
return