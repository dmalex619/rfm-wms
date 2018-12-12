-- Получение коэффициентов сложности прихода из Trading
-- Предварительно необходимо добавить в таблицу Inputs поле CoefficientUnload dec(5,1),
-- а также добавить таблицу InputsUnloaders (ID, InputID, UserID)
--set nocount on

if object_id('Tempdb..#TInputs') is not Null drop table #TInputs
if object_id('Tempdb..#Brigades') is not Null drop table #Brigades

select cast(Uniq as varchar(50)) as ERPCode, BrigadeUnload, CoefficientUnload 
	into #TInputs 
	from [TSQL-SRV].Trading.dbo.WHInputs 
	where DateInput >= '20080901' and 
		InputsType in (1,2) and 
		BrigadeUnload is not Null and 
		cast(Uniq as varchar(50)) in (select ERPCode from Inputs)

select BrigadeID, min(ID) as UserID 
	into #Brigades 
	from _Users 
	group by BrigadeID

update Inputs set CoefficientUnload = 1
update Inputs set CoefficientUnload = 
	case when X.CoefficientUnload < 1 then 1 else X.CoefficientUnload end 
	from #TInputs X 
	where Inputs.ERPCode = X.ERPCode
insert InputsUnloaders (InputID, UserID) 
	select I.ID, B.UserID 
	from Inputs I 
	inner join #TInputs X on I.ERPCode = X.ERPCode 
	inner join #Brigades B on X.BrigadeUnload = B.BrigadeID 
	where I.ID not in (select distinct InputID from InputsUnloaders)
