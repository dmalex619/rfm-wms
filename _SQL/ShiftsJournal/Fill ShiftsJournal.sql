set nocount on
set datefirst 1

truncate table ShiftsJournal

declare @bIsNight bit, @dDateBeg smalldatetime, @dDateEnd smalldatetime
select @bIsNight = 1, @dDateBeg = '2010-08-31T21:00:00'

while @dDateBeg <= '2010-10-01T08:00:00' begin
-- Жук - 13 часов ночью и 11 днем, Питер - 12 всегда
--	set @dDateEnd = DATEADD(hour, case when @bIsNight = 1 then 13 else 11 end, @dDateBeg)
	set @dDateEnd = DATEADD(hour, 12, @dDateBeg)
	insert ShiftsJournal(DateBeg, DateEnd, MajorID, IsNight) 
		select @dDateBeg, @dDateEnd, 1, @bIsNight
	set @bIsNight = case when @bIsNight = 1 then 0 else 1 end
	
	set @dDateBeg = @dDateEnd
	if DATEPART(WEEKDAY, @dDateBeg) = 6 and DATEPART(hour, @dDateBeg) = 21 
		set @dDateBeg = DATEADD(day, 1, @dDateBeg)
end
