-- Получение коэффициентов сложности расхода из Trading
-- Предварительно необходимо добавить в таблицу Outputs поле CoefficientLoad dec(5,1),
-- а также добавить таблицу OutputsLoaders (ID, OutputID, UserID)
--set nocount on

if object_id('Tempdb..#TOutputs') is not Null drop table #TOutputs
if object_id('Tempdb..#Brigades') is not Null drop table #Brigades

select cast(Uniq as varchar(50)) as ERPCode, BrigadeLoad 
	into #TOutputs 
	from [TSQL-SRV].Trading.dbo.WHOutputs 
	where	BrigadeLoad is not Null and 
			cast(Uniq as varchar(50)) in (select ERPCode from Outputs)

select BrigadeID, min(ID) as UserID 
	into #Brigades 
	from _Users 
	group by BrigadeID

update Outputs set CoefficientLoad = 
	case when len(CarAlias) = 0 then 4 when BackDoor = 1 then 6 else 2 end 
insert OutputsLoaders (OutputID, UserID) 
	select I.ID, B.UserID 
	from Outputs I 
	inner join #TOutputs X on I.ERPCode = X.ERPCode 
	inner join #Brigades B on X.BrigadeLoad = B.BrigadeID 
	where I.ID not in (select distinct OutputID from OutputsLoaders)
