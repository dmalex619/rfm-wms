set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_ReportOddmentsBalance]
	@dDateBeg			smalldatetime	= Null, -- начало периода
	@dDateEnd			smalldatetime	= Null, -- окончание периода
	@cOwnersList		varchar(max)	= Null, 
	@cGoodsStatesList	varchar(max)	= Null, 
	@cPackingsList		varchar(max)	= Null, 
	@bGroupOwner		bit				= 0,	-- общий товар считаем вместе 
	@nMode				int				= 1,	-- расчет в: 1 - штуках, 2 - коробках, 3 - паллетах, 4 - кг нетто
	@cFieldsList		varchar(max)	= Null	-- список полей для отображения
AS

set nocount on

if @dDateBeg is Null set @dDateBeg = '19900101'
if @dDateEnd is Null set @dDateEnd = '20501231'

select	@cOwnersList		= ',' + replace(@cOwnersList,		' ', '') + ',',
		@cGoodsStatesList	= ',' + replace(@cGoodsStatesList,	' ', '') + ',',
		@cPackingsList		= ',' + replace(@cPackingsList,		' ', '') + ','

select	ID + 0 as ID, SeparatePicking
	into	#Owners 
	from	Partners with (nolock) 
	where	(Owner = 1 or 
				ID in (select distinct OwnerID from Inputs with (nolock)) or 
				ID in (select distinct OwnerID from Outputs with (nolock)))
			and 
			(IsNull(@cOwnersList, '') = '' or 
			charindex(',' + ltrim(str(ID)) + ',', @cOwnersList) > 0)
if	@bGroupOwner = 1 and 
	(IsNull(@cOwnersList, '') = '' or charindex(',0,', @cOwnersList) > 0) begin 
	insert	#Owners (ID, SeparatePicking)
		select Null, 0
end
select	ID
	into	#GoodsStates
	from	GoodsStates with (nolock) 
	where	IsNull(@cGoodsStatesList, '') = '' or 
			charindex(',' + ltrim(str(ID)) + ',', @cGoodsStatesList) > 0
select	ID
	into	#Packings
	from	Packings with (nolock) 
	where	IsNull(@cPackingsList, '') = '' or 
			charindex(',' + ltrim(str(ID)) + ',', @cPackingsList) > 0
-- 

-- операции с "приведенным" владельцем
select	I.ID, I.DateConfirm, 
		case when @bGroupOwner = 1 and Ow.SeparatePicking = 0 
				 then Null else I.OwnerID end as OwnerID
	into #Inputs 
	from Inputs I
	left join Partners Ow on I.OwnerID = Ow.ID 
	where I.DateConfirm is not Null
select	O.ID, O.DateConfirm, O.GoodStateID, 
		case when @bGroupOwner = 1 and Ow.SeparatePicking = 0 
				 then Null else O.OwnerID end as OwnerID
	into #Outputs 
	from Outputs O
	left join Partners Ow on O.OwnerID = Ow.ID 
	where O.DateConfirm is not Null
select	A.ID, A.DateConfirm, A.GoodStateID, 
		case when @bGroupOwner = 1 and Ow.SeparatePicking = 0 
				 then Null else A.OwnerID end as OwnerID
	into #AuditActs
	from AuditActs A 
	left join Partners Ow on A.OwnerID = Ow.ID 
	where A.DateConfirm is not Null

--

create table #Report
	(OwnerID int, 
	 GoodStateID int, PackingID int, 
	 QntBeg	  decimal(16, 3), 
	 QntPlus  decimal(16, 3), 
	 QntMinus decimal(16, 3), 
	 QntEnd   decimal(16, 3), 
	 QntInCells decimal(16, 3), 
	 PartnerID int) 
create index IX_Report on #Report (OwnerID, GoodStateID, PackingID)

-- ПРИХОДЫ
-- приходы до даты_нач
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#PlusBeforeBeg
	from (
		select	I.OwnerID, 
				IG.GoodStateID, IG.PackingID, Ow.SeparatePicking, 
				IG.QntConfirmed 
			from	#Inputs I with (nolock) 
			inner join InputsGoods IG with (nolock) on I.ID = IG.InputID
			inner join #Owners Ow on IsNull(I.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on IG.GoodStateID = GS.ID
			inner join #Packings P on IG.PackingID = P.ID 
			where   datediff(day, I.DateConfirm, @dDateBeg) > 0
		) X
	group by OwnerID, GoodStateID, PackingID 
create index IX_PlusBeforeBeg on #PlusBeforeBeg (OwnerID, GoodStateID, PackingID)

-- приходы в период
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#PlusInDates
	from (
		select	I.OwnerID, 
				IG.GoodStateID, IG.PackingID, Ow.SeparatePicking, 
				IG.QntConfirmed 
			from	#Inputs I with (nolock) 
			inner join InputsGoods IG with (nolock) on I.ID = IG.InputID 
			inner join #Owners Ow on IsNull(I.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on IG.GoodStateID = GS.ID
			inner join #Packings P on IG.PackingID = P.ID
			where   datediff(day, @dDateBeg, I.DateConfirm) >= 0 and 
					datediff(day, I.DateConfirm, @dDateEnd) >= 0
		) X
	group by OwnerID, GoodStateID, PackingID 
create index IX_PlusInDates on #PlusInDates (OwnerID, GoodStateID, PackingID)

-- приходы после даты_кон до сейчас 
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#PlusAfterEnd
	from (
		select	I.OwnerID, 
				IG.GoodStateID, IG.PackingID, Ow.SeparatePicking, 
				IG.QntConfirmed 
			from	#Inputs I with (nolock) 
			inner join InputsGoods IG with (nolock) on I.ID = IG.InputID 
			inner join #Owners Ow on IsNull(I.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on IG.GoodStateID = GS.ID
			inner join #Packings P on IG.PackingID = P.ID
			where   datediff(day, @dDateEnd, I.DateConfirm) > 0
		) X
	group by OwnerID, GoodStateID, PackingID 
create index IX_PlusAfterEnd on #PlusAfterEnd (OwnerID, GoodStateID, PackingID)

-- РАСХОДЫ
-- расходы до даты_нач
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#MinusBeforeBeg
	from (
		select	O.OwnerID, 
				O.GoodStateID, OG.PackingID, Ow.SeparatePicking, 
				OG.QntConfirmed 
			from	#Outputs O with (nolock) 
			inner join OutputsGoods OG with (nolock) on O.ID = OG.OutputID
			inner join #Owners Ow on IsNull(O.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on O.GoodStateID = GS.ID
			inner join #Packings P on OG.PackingID = P.ID 
			where   datediff(day, O.DateConfirm, @dDateBeg) > 0
		) X 
	group by OwnerID, GoodStateID, PackingID 
create index IX_MinusBeforeBeg on #MinusBeforeBeg (OwnerID, GoodStateID, PackingID)

-- расходы в период
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#MinusInDates
	from (
		select	O.OwnerID, 
				O.GoodStateID, OG.PackingID, Ow.SeparatePicking, 
				OG.QntConfirmed 
			from	#Outputs O with (nolock) 
			inner join OutputsGoods OG with (nolock) on O.ID = OG.OutputID
			inner join #Owners Ow on IsNull(O.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on O.GoodStateID = GS.ID
			inner join #Packings P on OG.PackingID = P.ID 
			where   datediff(day, @dDateBeg, O.DateConfirm) >= 0 and 
					datediff(day, O.DateConfirm, @dDateEnd) >= 0
		) X 
	group by OwnerID, GoodStateID, PackingID 
create index IX_MinusInDates on #MinusInDates (OwnerID, GoodStateID, PackingID)

-- расходы после даты_кон до сейчас 
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#MinusAfterEnd
	from (
		select	O.OwnerID, 
				O.GoodStateID, OG.PackingID, Ow.SeparatePicking, 
				OG.QntConfirmed 
			from	#Outputs O with (nolock) 
			inner join OutputsGoods OG with (nolock) on O.ID = OG.OutputID
			inner join #Owners Ow on IsNull(O.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on O.GoodStateID = GS.ID
			inner join #Packings P on OG.PackingID = P.ID 
			where   datediff(day, @dDateEnd, O.DateConfirm) > 0
		) X 
	group by OwnerID, GoodStateID, PackingID 
create index IX_MinusAfterEnd on #MinusAfterEnd (OwnerID, GoodStateID, PackingID)

-- АКТЫ
-- акты до даты_нач
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#ActsBeforeBeg
	from (
		select	A.OwnerID, 
				A.GoodStateID, AG.PackingID, Ow.SeparatePicking, 
				AG.QntConfirmed 
			from	#AuditActs A with (nolock) 
			inner join AuditActsGoods AG with (nolock) on A.ID = AG.AuditActID
			inner join #Owners Ow on IsNull(A.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on A.GoodStateID = GS.ID
			inner join #Packings P on AG.PackingID = P.ID 
			where   datediff(day, A.DateConfirm, @dDateBeg) > 0
		) X
	group by OwnerID, GoodStateID, PackingID 
create index IX_ActsBeforeBeg on #ActsBeforeBeg (OwnerID, GoodStateID, PackingID)

-- акты в период
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#ActsInDates
	from (
		select	A.OwnerID, 
				A.GoodStateID, AG.PackingID, Ow.SeparatePicking, 
				AG.QntConfirmed 
			from	#AuditActs A with (nolock) 
			inner join AuditActsGoods AG with (nolock) on A.ID = AG.AuditActID 
			inner join #Owners Ow on IsNull(A.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on A.GoodStateID = GS.ID
			inner join #Packings P on AG.PackingID = P.ID
			where   datediff(day, @dDateBeg, A.DateConfirm) >= 0 and 
					datediff(day, A.DateConfirm, @dDateEnd) >= 0
		) X
	group by OwnerID, GoodStateID, PackingID 
create index IX_ActsInDates on #ActsInDates (OwnerID, GoodStateID, PackingID)

-- акты после даты_кон до сейчас 
select	OwnerID, GoodStateID, PackingID, sum(QntConfirmed) as Qnt  
	into	#ActsAfterEnd
	from (
		select	A.OwnerID, 
				A.GoodStateID, AG.PackingID, Ow.SeparatePicking, 
				AG.QntConfirmed 
			from	#AuditActs A with (nolock) 
			inner join AuditActsGoods AG with (nolock) on A.ID = AG.AuditActID 
			inner join #Owners Ow on IsNull(A.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on A.GoodStateID = GS.ID
			inner join #Packings P on AG.PackingID = P.ID
			where   datediff(day, @dDateEnd, A.DateConfirm) > 0
		) X
	group by OwnerID, GoodStateID, PackingID 
create index IX_ActsAfterEnd on #ActsAfterEnd (OwnerID, GoodStateID, PackingID)
--

-- остатки_кон расчетом от InCells 
-- остатки на сейчас по содержимому ячеек
select	OwnerID, GoodStateID, PackingID, sum(Qnt) as Qnt  
	into	#InCells
	from (
		select	OwnerID, 
				GoodStateID, PackingID, SeparatePicking, 
				Qnt
			from	CellsContents CC with (nolock) 
			inner join #Owners Ow on IsNull(CC.OwnerID, 0) = IsNull(Ow.ID, 0)
			inner join #GoodsStates GS on CC.GoodStateID = GS.ID
			inner join #Packings P on CC.PackingID = P.ID
			where	CC.Qnt <> 0 and 
					(@bGroupOwner = 1 or 1 = 2)
		) X 
	group by OwnerID, GoodStateID, PackingID 
create index IX_InCells on #InCells (OwnerID, GoodStateID, PackingID)

-- собираем все встреченные товары
insert	#Report
	(OwnerID, GoodStateID, PackingID, 
	 QntBeg, QntPlus, QntMinus, QntEnd, QntInCells, PartnerID)
	select distinct OwnerID, GoodStateID, PackingID, 
			 0, 0, 0, 0, 0, Null
		from (
			select  distinct OwnerID, GoodStateID, PackingID
				from #InCells
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #PlusBeforeBeg
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #PlusInDates
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #PlusAfterEnd
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #MinusBeforeBeg
				where Qnt <> 0
			union
			 select  distinct OwnerID, GoodStateID, PackingID
				from #MinusInDates
				where Qnt <> 0
			union
			 select  distinct OwnerID, GoodStateID, PackingID
				from #MinusAfterEnd
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #ActsBeforeBeg
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #ActsInDates
				where Qnt <> 0
			union 
			 select  distinct OwnerID, GoodStateID, PackingID
				from #ActsAfterEnd
				where Qnt <> 0
		) X

-- ПРИХОДЫ 
update	#Report
	set	 QntBeg = QntBeg + X.Qnt, 
		 QntEnd = QntEnd + X.Qnt    
	from #PlusBeforeBeg X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID
update	#Report
	set	 QntPlus = QntPlus + X.Qnt,  
		 QntEnd  = QntEnd + X.Qnt 
	from #PlusInDates X 
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID

-- РАСХОДЫ
update	#Report
	set	 QntBeg = QntBeg - X.Qnt, 
		 QntEnd = QntEnd - X.Qnt    
	from #MinusBeforeBeg X 
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID
update	#Report
	set	 QntMinus = QntMinus + X.Qnt, 
		 QntEnd   = QntEnd - X.Qnt 
	from #MinusInDates X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID

-- АКТЫ
update	#Report
	set	 QntBeg = QntBeg + X.Qnt, 
		 QntEnd = QntEnd + X.Qnt 
	from #ActsBeforeBeg X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID
update	#Report
	set	 QntPlus = QntPlus + X.Qnt, 
		 QntEnd  = QntEnd + X.Qnt 
	from #ActsInDates X 
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID and 
			X.Qnt > 0
update	#Report
	set	 QntMinus = QntMinus - X.Qnt, 
		 QntEnd  = QntEnd + X.Qnt 
	from #ActsInDates X 
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID and 
			X.Qnt < 0

-- расчет кон.
update	#Report
	set	QntInCells = X.Qnt 
	from #InCells X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID
update	#Report
	set	 QntInCells = QntInCells - X.Qnt 
	from #PlusAfterEnd X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID
update	#Report
	set	 QntInCells = QntInCells + X.Qnt 
	from #MinusAfterEnd X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID
update	#Report
	set	 QntInCells = QntInCells - X.Qnt 
	from #ActsAfterEnd X
	where	IsNull(#Report.OwnerID, 0) = IsNull(X.OwnerID, 0) and 
			#Report.GoodStateID = X.GoodStateID and 
			#Report.PackingID = X.PackingID

-- единица расчета
if @nMode > 1 begin
	if @nMode = 2
		update #Report set 
			QntBeg		= QntBeg		/ P.InBox,
			QntPlus		= QntPlus		/ P.InBox, 
			QntMinus	= QntMinus		/ P.InBox, 
			QntEnd		= QntEnd		/ P.InBox, 
			QntInCells	= QntInCells	/ P.InBox 
			from Packings P 
			where #Report.PackingID = P.ID
	if @nMode = 3
		update #Report set 
			QntBeg		= QntBeg		/ P.InBox / P.BoxInPal,
			QntPlus		= QntPlus		/ P.InBox / P.BoxInPal, 
			QntMinus	= QntMinus		/ P.InBox / P.BoxInPal, 
			QntEnd		= QntEnd		/ P.InBox / P.BoxInPal, 
			QntInCells	= QntInCells	/ P.InBox / P.BoxInPal
			from Packings P 
			where #Report.PackingID = P.ID
	if @nMode = 4
		update #Report set 
			QntBeg		= QntBeg		* G.Netto,
			QntPlus		= QntPlus		* G.Netto, 
			QntMinus	= QntMinus		* G.Netto, 
			QntEnd		= QntEnd		* G.Netto, 
			QntInCells	= QntInCells	* G.Netto
			from Packings P 
			inner join Goods G on P.GoodID = G.ID 
			where #Report.PackingID = P.ID
end

-- конечная выборка
select	T.OwnerID, 
		Ow.Name as OwnerName, Ow.ERPCode as OwnerERPCode, Ow.SeparatePicking, 
		T.GoodStateID, GS.Name as GoodStateName, GS.ERPCode as GoodStateERPCode, 
		T.PackingID, P.GoodID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode,
		G.Name as GoodName, G.Alias as GoodAlias, G.ERPCode as GoodERPCode, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, GG.ERPCode as GoodGroupERPCode, 
		G.GoodBrandID, GB.Name as GoodBrandName, GB.ERPCode as GoodBrandERPCode, 
		T.QntBeg,
		T.QntPlus, 
		T.QntMinus, 
		T.QntEnd, 
		T.QntInCells, 
		T.PartnerID,  
		P.InBox, P.BoxInPal 
	into #Result 
	from #Report T 
	left  join Partners Ow with (nolock) on T.OwnerID = Ow.ID
	left  join GoodsStates GS with (nolock) on T.GoodStateID = GS.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID 
	left  join Goods G with (nolock) on P.GoodID = G.ID 
	left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	where T.QntBeg <> 0 or T.QntPlus <> 0 or T.QntMinus <> 0 or T.QntEnd <> 0 or T.QntInCells <> 0 
	order by G.Alias, Ow.Name, GS.Name

-- Возврат всех полей или только части
if @cFieldsList is Null
	select * from #Result
else begin
	begin try
		declare @cSqlCommand varchar(max)
		set @cSqlCommand = 'select ' + @cFieldsList + ' from #Result'
		exec (@cSqlCommand)
	end try
	begin catch
		select * from #Result
	end catch
end
return