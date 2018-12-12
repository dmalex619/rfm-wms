-- Подготовка БД Trading к запуску WMS
if db_name() <> 'Trading' return

-- Clear all
update WHInputs set WMSPrepared = 0, WMSSent = 0

-- Set confirmed for not WMSPrepared
update WHInputs set WMSPrepared = 1, WMSSent = 1 
	where InputsType in (1,2) and DateConfirm is not Null

-- Set for WMSPrepared
declare @cDate varchar(20)
set @cDate = cast(GetDate() as varchar(20))
update WHInputs set WMSPrepared = 1, WMSSent = 0 
	where InputsType in (1,2) and DateConfirm is Null and 
		DateInput >= DateAdd(Day, -7, @cDate)
