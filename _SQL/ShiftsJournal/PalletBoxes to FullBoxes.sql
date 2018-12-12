-- Отношение кол-ва коробок, отгруженных с высотки,
-- к общему количеству отгруженных коробок
if OBJECT_ID('Tempdb.dbo.#O') is not Null drop table #O
if OBJECT_ID('Tempdb.dbo.#F') is not Null drop table #F

-- все расходы за период
select ID 
	into #O 
	from Outputs 
	where DateConfirm between '20100901' and '20100930'

-- общее кол-во отгруженных коробок
select SUM(OG.QntConfirmed / P.InBox) as FullBoxes 
	from #O O 
	inner join OutputsGoods OG on OG.OutputID = O.ID 
	inner join Packings P on OG.PackingID = P.ID 

-- список контейнеров в расходах
select distinct FrameID 
	into #F 
	from TrafficsFrames 
	where OutputID in (select ID from #O)

select SUM(II.Qnt / P.InBox) as PalletBoxes 
	from #F 
	inner join InputsItems II on II.FrameID = #F.FrameID
	inner join Packings P on II.PackingID = P.ID 
