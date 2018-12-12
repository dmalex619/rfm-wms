update WHOutputs set BrigadePick = Null
WHERE DateOutput >= '20080728' and DateConfirm is not Null and
Uniq in (select distinct OI.WHOutput from WHOutputsGoods OI where Packing in (6463,6464))

/*
update WHOutputs set BrigadePick = 1
WHERE DateOutput >= '20080728' and DateConfirm is not Null and
(DatePick between 
'20080731 10:00:00' and 
'20080731 21:00:00' 
)and
Uniq not in (select distinct OI.WHOutput from WHOutputsGoods OI where Packing in (6463,6464))
*/