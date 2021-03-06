SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_FillPackingManual_Save]
	@nCellSourceID	int,
	@nCellTargetID	int
AS
-- Процедура создания ручной подпитки ячейки пикинга

set nocount on

-- Проверка параметров
if @nCellSourceID is Null or @nCellTargetID is Null begin
	raiserror(N'Отсутствуют параметры процедуры!', 16, 1)
	return
end

-- Получение данных об исходной и целевой ячейках и их проверка
declare @nSourcePackingID int, @nSourceGoodStateID int, @nSourceOwnerID int, 
		@nTargetPackingID int, @nTargetGoodStateID int, @nTargetOwnerID int, 
		@nFrameID int
select	@nSourcePackingID = CC.PackingID, 
		@nSourceGoodStateID = CC.GoodStateID, 
		@nSourceOwnerID = CC.OwnerID, 
		@nFrameID = CC.FrameID 
	from Cells C with (nolock) 
	inner join CellsContents CC with (nolock) on CC.CellID = C.ID 
	where C.ID = @nCellSourceID
if @@RowCount <> 1 begin
	raiserror(N'Обнаружена неуникальность записей в ячейке высотной зоны!', 16, 1)
	return
end
if @nFrameID is Null begin
	raiserror(N'В ячейке высотной зоны отстуствует контейнер!', 16, 1)
	return
end
if @nSourcePackingID is Null or @nSourceGoodStateID is Null begin
	raiserror(N'В ячейке высотной зоны отстуствует товар!', 16, 1)
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
	raiserror(N'Несовпадение товаров в пикинге и высотной зоне!', 16, 1)
	return
end

-- Все проверки пройдены, создаем перемещение
declare @nDefaultPriority int
set @nDefaultPriority = 2 -- взять из _Settings 

begin tran
	insert TrafficsFrames 
			(FrameID, CellSourceID, CellTargetID, 
			InputID, OutputID, 
			DateBirth, Priority, Note)
		values 
			(@nFrameID, @nCellSourceID, @nCellTargetID, 
			Null, Null, 
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