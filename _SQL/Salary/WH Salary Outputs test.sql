-- Calc data for salary (Outputs)
--if object_id('Temp..#OutputsFiltered') is not Null drop table #OutputsFiltered
if object_id('Temp..#Outputs1') is not Null drop table #Outputs1
if object_id('Temp..#Outputs2') is not Null drop table #Outputs2
drop table #Outputs1
drop table #Outputs2
drop table #OutputsFiltered

declare @nMode tinyint, @bSummary bit
select @nMode = 2, @bSummary = 1

declare @dDateBeg smalldatetime, @dDateEnd smalldatetime
select @dDateBeg = '20080903', @dDateEnd = '20080903'

-- Get confirmed Outputs 
select ID 
	into #OutputsFiltered 
	from Outputs 
	where case when @nMode = 1 then DatePick else DateConfirm end is not Null and 
		DateDiff(Day, case when @nMode = 1 then DatePick else DateConfirm end, @dDateBeg) <= 0 and 
		DateDiff(Day, case when @nMode = 1 then DatePick else DateConfirm end, @dDateEnd) >= 0

if @nMode = 1 begin
	-- Outputs pick
	select B.Name as BrigadeAlias, U.Name as UserAlias, 
		convert(varchar, I.DatePick, 112) as DatePick, 
		I.ERPCode, X.RecCount, U.BrigadeID, X.UserID 
		into #Outputs2 
		from #OutputsFiltered T 
		inner join Outputs I on T.ID = I.ID 
		inner join (select II.OutputID, II.UserID, count(*) as RecCount 
					from OutputsItems II 
					inner join #OutputsFiltered T1 on II.OutputID = T1.ID 
					where II.FrameID is Null and II.UserID is not Null
					group by II.OutputID, II.UserID) X on X.OutputID = I.ID 
		inner join _Users U on X.UserID = U.ID 
		inner join Brigades B on U.BrigadeID = B.ID
		order by BrigadeAlias, UserAlias, ERPCode
		
		if @bSummary = 0 
			select * from #Outputs2
		else
			select BrigadeAlias, sum(RecCount) as Points 
				from #Outputs2 group by BrigadeAlias
end
else begin
	-- Outputs load
	select B.Name as BrigadeAlias, U.Name as UserAlias, 
		convert(varchar, I.DateConfirm, 112) as DateConfirm, 
		I.ERPCode, W.Netto, 
		case when W.Netto < 100 then 6.0 when W.Netto > 1000 then 2.0 else 4.0 end as KU, 
		U.BrigadeID, X.UserID 
		into #Outputs1 
		from #OutputsFiltered T 
		inner join Outputs I on T.ID = I.ID 
		inner join (select II.OutputID, max(II.UserID) as UserID
					from OutputsItems II 
					inner join #OutputsFiltered T1 on II.OutputID = T1.ID 
					where II.UserID is not Null
					group by II.OutputID) X on X.OutputID = I.ID 
		inner join _Users U on X.UserID = U.ID 
		inner join Brigades B on U.BrigadeID = B.ID
		inner join (select IG.OutputID, sum(IG.QntConfirmed * G.Netto) as Netto
					from OutputsGoods IG 
					inner join #OutputsFiltered T2 on IG.OutputID = T2.ID 
					inner join Packings P on IG.PackingID = P.ID
					inner join Goods G on P.GoodID = G.ID
					group by IG.OutputID) W on W.OutputID = I.ID
		order by BrigadeAlias, UserAlias, ERPCode
		
		if @bSummary = 0 
			select * from #Outputs1
		else
			select BrigadeAlias, sum(Netto * KU) as Points 
				from #Outputs1 group by BrigadeAlias
end

