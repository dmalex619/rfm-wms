-- Calc data for salary (Inputs)
--if object_id('Temp..#InputsFiltered') is not Null drop table #InputsFiltered
if object_id('Temp..#Inputs1') is not Null drop table #Inputs1
if object_id('Temp..#Inputs2') is not Null drop table #Inputs2
drop table #Inputs1
drop table #Inputs2
drop table #InputsFiltered

declare @nMode tinyint, @bSummary bit
select @nMode = 1, @bSummary = 0

declare @dDateBeg smalldatetime, @dDateEnd smalldatetime
select @dDateBeg = '20080903', @dDateEnd = '20080903'

-- Get confirmed Inputs 
select ID 
	into #InputsFiltered 
	from Inputs 
	where DateConfirm is not Null and 
		InputTypeID = 6 and 
		DateDiff(Day, DateConfirm, @dDateBeg) <= 0 and 
		DateDiff(Day, DateConfirm, @dDateEnd) >= 0

if @nMode = 1 begin
	-- Inputs prepare
	select B.Name as BrigadeAlias, U.Name as UserAlias, 
		convert(varchar, I.DateConfirm, 112) as DateConfirm, 
		I.ERPCode, W.Netto, 
		case when W.Netto < 5000 then 3.0 when W.Netto > 12000 then 1.0 else 2.0 end as KU, 
		U.BrigadeID, X.UserID 
		into #Inputs1 
		from #InputsFiltered T 
		inner join Inputs I on T.ID = I.ID 
		inner join (select II.InputID, max(II.UserID) as UserID
					from InputsItems II 
					inner join #InputsFiltered T1 on II.InputID = T1.ID 
					where II.UserID is not Null
					group by II.InputID) X on X.InputID = I.ID 
		inner join _Users U on X.UserID = U.ID 
		inner join Brigades B on U.BrigadeID = B.ID
		inner join (select IG.InputID, sum(IG.QntConfirmed * G.Netto) as Netto
					from InputsGoods IG 
					inner join #InputsFiltered T2 on IG.InputID = T2.ID 
					inner join Packings P on IG.PackingID = P.ID
					inner join Goods G on P.GoodID = G.ID
					group by IG.InputID) W on W.InputID = I.ID
		order by BrigadeAlias, UserAlias, ERPCode
		
		if @bSummary = 0 
			select * from #Inputs1
		else
			select BrigadeAlias, sum(Netto * KU) as Points 
				from #Inputs1 group by BrigadeAlias
end
else begin
	-- Inputs
	select B.Name as BrigadeAlias, U.Name as UserAlias, 
		convert(varchar, I.DateConfirm, 112) as DateConfirm, 
		I.ERPCode, X.RecCount, U.BrigadeID, X.UserID 
		into #Inputs2 
		from #InputsFiltered T 
		inner join Inputs I on T.ID = I.ID 
		inner join (select II.InputID, II.UserID, count(*) as RecCount 
					from InputsItems II 
					inner join #InputsFiltered T1 on II.InputID = T1.ID 
					where II.UserID is not Null
					group by II.InputID, II.UserID) X on X.InputID = I.ID 
		inner join _Users U on X.UserID = U.ID 
		inner join Brigades B on U.BrigadeID = B.ID
		order by BrigadeAlias, UserAlias, ERPCode
		
		if @bSummary = 0 
			select * from #Inputs2
		else
			select BrigadeAlias, sum(RecCount) as Points 
				from #Inputs2 group by BrigadeAlias
end

