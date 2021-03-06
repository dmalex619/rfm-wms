-- проверка текущих остатков в Trading

if object_id('tempdb..#oddments') is not Null 
	drop table #oddments
if object_id('tempdb..#Operations') is not Null 
	drop table #Operations 

-- текущие остатки
select 	Packing, Depot, Qnt,
	cast(0 as decimal(15,3)) as OldQnt, 
	cast(0 as decimal(15,3)) as CalcQnt
	into 	#Oddments
	from 	WHOddments with (nolock)--(tablock holdlock) 

-- выполненные операции, пока еще не сохраненные в остатках (изменившие последние остатки)
select 	X.Packing, X.Depot, sum(X.QntConfirmed) as Qnt, cast(0 as bit) as InOddment
	into	#Operations 
	from (	select 	IG.Packing, I.Depot, IG.QntConfirmed		-- приход
			from	WHInputs I with (nolock)
			left join WHInputsGoods IG with (nolock) on I.Uniq = IG.WHInput
			where	I.DateConfirm is not Null and I.WHSavedOddment is Null and IG.Packing is not Null
		union all
		select 	OG.Packing, O.Depot, -OG.QntConfirmed		-- расход
			from	WHOutputs O with (nolock) 
			left join WHOutputsGoods OG with (nolock) on O.Uniq = OG.WHOutput
			where	O.DateConfirm is not Null and O.WHSavedOddment is Null and OG.Packing is not Null
		union all
		select 	MG.Packing, M.FromDepot, -MG.QntConfirmed	-- перемещение из ...
			from	WHMovings M with (nolock) 
			left join WHMovingsGoods MG with (nolock) on M.Uniq = MG.WHMoving
			where	M.DateConfirm is not Null and M.WHSavedOddment is Null and MG.Packing is not Null
		union all
		select 	NG.Packing, N.ToDepot, NG.QntConfirmed		-- перемещение в ...
			from	WHMovings N with (nolock) 
			left join WHMovingsGoods NG with (nolock) on N.Uniq = NG.WHMoving
			where	N.DateConfirm is not Null and N.WHSavedOddment is Null and NG.Packing is not Null
		) X
	group by X.Packing, X.Depot

-- товар есть в операциях и есть в текущих остатках
update 	#Operations 
	set 	InOddment = 1
	from 	#Oddments O
	where 	#Operations.Packing = O.Packing and #Operations.Depot = O.Depot 

-- добавим в сохраняемые остатки товар, который есть в операциях, но нет в остатках
insert 	#Oddments
	(Packing, Depot, Qnt, OldQnt, CalcQnt)
	select	Packing, Depot, 
		cast(0 as decimal(15,3)) as Qnt, 
		cast(0 as decimal(15,3)) as OldQnt,
		cast(0 as decimal(15,3)) as CalcQnt
		from 	#Operations
		where 	InOddment = 0

-- последние сохраненные остатки (по созданию - Uniq, не глядя на дату)
declare @nLastSaved int 
select  @nLastSaved = max(Uniq)
	from 	WHSavedOddments

update	#Oddments
	set 	OldQnt  = isnull(SOG.Qnt, 0), 
			CalcQnt = isnull(SOG.Qnt, 0)
	from 	WHSavedOddmentsGoods SOG with (nolock) 
	where	#Oddments.Packing = SOG.Packing and 
		#Oddments.Depot = SOG.Depot and SOG.WHSavedOddment = @nLastSaved

-- расчетные остатки на текущий момент
update 	#Oddments
	set 	CalcQnt = OldQnt + isnull(OP.Qnt, 0)
	from 	#Operations OP
	where	#Oddments.Packing = OP.Packing and #Oddments.Depot = OP.Depot

select 	Packing, Depot, Qnt, CalcQnt, (Qnt - CalcQnt) / P.InBox, P.BoxInPal
	from 	#Oddments O 
	inner join Packings P on O.Packing = P.Uniq 
	where Qnt <> CalcQnt
