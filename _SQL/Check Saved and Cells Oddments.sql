-- —равнение сохраненных остатков и остатков в €чейках
USE WMS
GO

if object_id('Tempdb.dbo.#Oddments') is not Null drop table #Oddments
select GS.ID as GoodStateID, P.ID as PackingID, 
	P.InBox, P.BoxInPal, 
	cast(0 as dec(15,3)) as QntSaved, 
	cast(0 as dec(15,3)) as QntCells, 
	cast(0 as dec(15,3)) as QntInputs 
	into #Oddments 
	from GoodsStates GS with (nolock) 
	inner join Packings P with (nolock) on 1 = 1 
	order by 1,2

update #Oddments set QntSaved = X.Qnt 
	from (select GoodStateID, PackingID, sum(Qnt) as Qnt 
			from Oddments with (nolock) 
			group by GoodStateID, PackingID) X 
	where #Oddments.GoodStateID = X.GoodStateID and #Oddments.PackingID = X.PackingID
update #Oddments set QntCells = X.Qnt 
	from (select GoodStateID, PackingID, sum(Qnt) as Qnt 
			from CellsContents with (nolock) 
			group by GoodStateID, PackingID) X 
	where #Oddments.GoodStateID = X.GoodStateID and #Oddments.PackingID = X.PackingID
update #Oddments set QntInputs = X.Qnt 
	from (select IG.GoodStateID, IG.PackingID, sum(IG.Qnt) as Qnt 
			from Inputs I with (nolock) 
			inner join InputsItems IG with (nolock) on IG.InputID = I.ID 
			where I.DateConfirm is Null and I.DateInput >= '20081027' 
			group by IG.GoodStateID, IG.PackingID) X 
	where #Oddments.GoodStateID = X.GoodStateID and #Oddments.PackingID = X.PackingID

select GG.Name as GroupName, 
		G.Alias as GoodName, 
		GS.Name as GoodStateName, 
		O.PackingID, 
		O.QntSaved, O.QntCells, O.QntInputs 
	from #Oddments O 
	inner join GoodsStates GS with (nolock) on O.GoodStateID = GS.ID 
	inner join Packings P with (nolock) on O.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	where O.QntSaved - O.QntCells + O.QntInputs <> 0 
	order by 1,2,3
