SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_TrafficsFramesFact_Confirm]
	@nFrameID		int, 
	@nCellTargetID	int, 
	@nUserID		int, 
	@nDeviceID		int, 
	@nBanchmarkID	int = Null
AS
-- Процедура подтверждения ручного перемещения поддона

set nocount on

-- Проверка параметров
-- Данные о контейнере
declare @nID int, @bActual bit
select @nID = ID, @bActual = Actual 
	from Frames with (nolock) 
	where ID = IsNull(@nFrameID, 0)

-- Проверка наличия контейнера
if @nID is Null begin
	raiserror(N'Неизвестный контейнер!', 16, 1)
	return
end

-- Проверка состояния контейнера
if @bActual = 0 begin
	raiserror(N'Контейнер уже удален!', 16, 1)
	return
end

-- Проверка того, что контейнер не пуст
-- и получение исходной ячейки
declare @nCellSourceID int
select @nCellSourceID = CellID 
	from CellsContents with (nolock) 
	where FrameID = IsNull(@nFrameID, 0) and Qnt <> 0
if @nCellSourceID is Null begin
	raiserror(N'Контейнер пуст!', 16, 1)
	return
end

-- Проверка целевой ячейки
-- На вместимость не проверяем, полагаемся на кладовщика - 
-- он видит, что делает
if not exists (select ID from Cells where ID = @nCellTargetID) begin
	raiserror(N'Отсутствует целевая ячейка!', 16, 1)
	return
end

-- Проверка существования неподтвержденного трафика (в случае автоподбора места)
declare @nTrafficID int
select top 1 @nTrafficID = ID 
	from TrafficsFrames with (nolock) 
	where FrameID = IsNull(@nFrameID, 0) and DateConfirm is Null
	order by ID desc

declare @nTrafficErrorID int, @nError int, @cErrorStr varchar(max)

-- Создание трафика (ручной подбор)
if @nTrafficID is Null begin
	begin tran MakeTraffic
		insert into TrafficsFrames (PreviousTrafficID, FrameID, 
			CellSourceID, CellTargetID, Priority, InputID, OutputID, 
			DateBirth, UserID, DeviceID, Note) 
			values (Null, @nFrameID, 
				@nCellSourceID, @nCellTargetID, 1, Null, Null, 
				GetDate(), @nUserID, @nDeviceID, 'Перемещение по факту')
		select @nError = @@Error,  @nTrafficID = @@Identity
		if @nError	<> 0 begin
			set @cErrorStr = 'Перемещение не создано...'
			goto ERR
		end
		
		exec up_TrafficsFramesConfirm 
			@nTrafficID, 1, @nCellTargetID, @nTrafficErrorID, @nError output, @cErrorStr output, @nBanchmarkID
		if @nError <> 0 begin
			set @cErrorStr = 'Перемещение создано, но не подтверждено по причине: ' + @cErrorStr
			goto ERR	
		end
	commit tran MakeTraffic
end
return

ERR:
if @nError = 0 or @@trancount = 0 return	
rollback tran MakeTraffic
raiserror(@cErrorStr, 16, 1)
return