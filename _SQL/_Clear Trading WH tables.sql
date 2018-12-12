-- Частичное обнуление складских данных в Trading
if db_name() <> 'Trading' return

update Orders set WHOutput = Null

select Uniq 
	into #_Inputs 
	from WHInputs 
	where DateInput < convert(varchar(20), GetDate(), 112) or DateConfirm is not Null
create unique index TMP_PK_Inputs on #_Inputs (Uniq)
delete WHInputsGoods 
	where WHInput in (select Uniq from #_Inputs)
delete WHInputs 
	where Uniq in (select Uniq from #_Inputs)
drop table #_Inputs

select Uniq 
	into #_Outputs 
	from WHOutputs 
	where DateOutput < convert(varchar(20), GetDate(), 112) or DateConfirm is not Null
create unique index TMP_PK_Outputs on #_Outputs (Uniq)
delete WHOutputsGoods 
	where WHOutput in (select Uniq from #_Outputs)
delete WHOutputs 
	where Uniq in (select Uniq from #_Outputs)
drop table #_Outputs

truncate table WHMovingsGoods
delete WHMovings

truncate table WHDraftsGoods
delete WHDrafts

--
truncate table WHOddments
truncate table WHSavedOddmentsGoods
delete WHSavedOddments

update WHStorage set 
	Depot = Null, State = Null, Packing = Null, Qnt = Null, DateValid = Null

truncate table WHStorageErrors
