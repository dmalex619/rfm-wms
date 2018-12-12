SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE up_ShiftsSave
	@nShiftID		int = 0 output, 
	@dDateBeg		smalldatetime,
	@dDateEnd		smalldatetime,
	@nMajorID		int,
	@bIsNight		bit = Null,
	@cNote			varchar(50) = Null, 
	@nError			int = 0 output, 
	@cErrorText		varchar(200) = '' output
AS
-- Сохранение данных о смене

-- Проверка параметров
if	IsNull(@nShiftID, 0) <> 0 and 
		not exists (select ID from Movings where ID = @nShiftID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найдена смена с кодом ' + ltrim(str(@nShiftID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

if	@dDateBeg is Null or @dDateEnd is Null or 
		@dDateEnd <= @dDateBeg or 
		DateDiff(Hour, @dDateBeg, @dDateEnd) < 1 or 
		DateDiff(Hour, @dDateBeg, @dDateEnd) > 23 begin
	select	@nError = -1, 
			@cErrorText = 'Неправильно заданы границы смены'
	RaisError(@cErrorText, 16, 1)
	return
end

if @nMajorID is Null begin
	select	@nError = -2, 
			@cErrorText = 'Не задан старший сотрудник в смене'
	RaisError(@cErrorText, 16, 1)
	return
end

if @bIsNight is Null
	set @bIsNight = case when 
						DateDiff(Day, @dDateBeg, @dDateEnd) <> 0 or 
						DatePart(Hour, @dDateBeg) >= 20 
						then 1 else 0 end
if @cNote is Null
	set @cNote = ''

-- Проверка непересечения смен
if	dbo.GetShiftID(@dDateBeg) is not Null or dbo.GetShiftID(@dDateEnd) is not Null begin
	select	@nError = -3, 
			@cErrorText = 'Заданная смена пересекается с одной из уже существующих'
	RaisError(@cErrorText, 16, 1)
	return
end

-- Сохранение данных о смене
begin transaction
	if IsNull(@nShiftID, 0) = 0 begin
		insert Shifts (DateBeg, DateEnd, MajorID, IsNight, Note) 
			select @dDateBeg, @dDateEnd, @nMajorID, @bIsNight, @cNote
		select @nShiftID = @@Identity, @nError = @@Error
		if @nError > 0 goto ERR
	end
	else begin
		update Shifts set 
				DateBeg	= @dDateBeg, 
				DateEnd	= @dDateEnd, 
				MajorID = @nMajorID, 
				IsNight	= @bIsNight, 
				Note	= @cNote 
			where ID = @nShiftID
		select @nError = @@Error
		if @nError > 0 goto ERR
	end

commit transaction
return

ERR:
rollback transaction
return