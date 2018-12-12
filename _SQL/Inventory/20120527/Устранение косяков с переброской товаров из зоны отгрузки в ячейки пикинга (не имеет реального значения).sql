-- Устранение косяков с переброской товаров из зоны отгрузки в ячейки пикинга
-- Ошибка была в ХП up_MovingsGoodsFillInCell:
-- процедура ошибочно предлагала переместить товары, 
-- попавшие в зону отгрузки целыми паллетами, минуя пикинг (с ним было всю в порядке)

set nocount on

-- Выбрать все ячейки отгрузки
if object_id('Tempdb.dbo.#OutCells') is not Null drop table #OutCells
select C.ID 
	into #OutCells 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ShortCode = 'OUT'

-- Выбрать все перемещения, в которых начальной ячейкой была одна из ячеек отгрузки
-- Проблема возникает только в том случае, когда порядок действий следующий:
-- сбор заказа, обратное перемещение, актирование, отгрузка
-- В случае последовательности:
-- сбор заказа, обратное перемещение, отгрузка, актирование
-- проблема не возникает.
-- Проверено простым разложением операция по времени
-- Поэтому учитываем только перемещения в день начала ревизии (список от Хоменко)
if object_id('Tempdb.dbo.#Mov') is not Null drop table #Mov
select	ID, DateMoving, DateConfirm as MovDateConfirm, OwnerID, GoodStateID, CellSourceID 
	into #Mov 
	from Movings with (nolock) 
	where	DateConfirm is not Null and 
			DateConfirm >= '20090129' and 	-- Дата доработки ХП up_MovingsGoodsFillInCell под перемещение товаров вне расходов
			/*ConfirmUserID = 77 and*/			-- Только перемещения, подтвержденные Юрловым М.Н. 
			GoodStateID = 1 and				-- Только перемещения в состоянии "_Основной"
			OwnerID is Null	and 			-- Только перемещения ИНКО и пофигистов
			ID in (select distinct MovingID from MovingsGoods with (nolock) where QntConfirmed > 0) and 
			CellSourceID in (select ID from #OutCells) 
--AND DateDiff(Day, DateMoving, '20120526') = 0
--AND DateDiff(Day, DateMoving, '20120128') = 0
--AND DateDiff(Day, DateMoving, '20111015') = 0
--AND DateDiff(Day, DateMoving, '20110514') = 0
--AND DateDiff(Day, DateMoving, '20110212') = 0
--AND DateDiff(Day, DateMoving, '20101023') = 0
--AND DateDiff(Day, DateMoving, '20100424') = 0		--0
--AND DateDiff(Day, DateMoving, '20100123') = 0		--0
--AND DateDiff(Day, DateMoving, '20091107') = 0
--AND DateDiff(Day, DateMoving, '20090704') = 0
/*
AND (
   DateDiff(Day, DateMoving, '20120526') = 0
or DateDiff(Day, DateMoving, '20120128') = 0
or DateDiff(Day, DateMoving, '20111015') = 0
or DateDiff(Day, DateMoving, '20110514') = 0
or DateDiff(Day, DateMoving, '20110212') = 0
or DateDiff(Day, DateMoving, '20101023') = 0
or DateDiff(Day, DateMoving, '20100424') = 0		--0
or DateDiff(Day, DateMoving, '20100123') = 0		--0
or DateDiff(Day, DateMoving, '20091107') = 0
or DateDiff(Day, DateMoving, '20090704') = 0
)
*/
-- заменяем ручной выбор дат ревизий на запрос
AND convert(varchar(25), DateMoving, 112) in 
	(select distinct convert(varchar(25), DateBeg, 112) 
		from CellsContentsSnapshots 
		where DateDiff(Day, DateBeg, DateEnd) > 0)

-- Создаем таблицу для учета перемещенных товаров
-- Считаем сколько товара было в итоге выдано, и сколько из них было собрано пикерами
if object_id('Tempdb.dbo.#Goods') is not Null drop table #Goods
create table #Goods (MovingID int, 
	OutputID int, DatePick smalldatetime, DateConfirm smalldatetime, 
	PackingID int, QntConfirmed dec(18,3), QntMovedByTG dec(18,3), QntInFrames dec(18,3), QntReturned dec(18,3))

-- Начинаем цикл поиска отгрузок, которые могли попасть в перемещения
declare @nMovID int, @dMovDateConfirm smalldatetime, @nMovGoodStateID int, @nMovCellSourceID int
declare _Mov cursor for 
	select ID, MovDateConfirm, GoodStateID, CellSourceID 
	from #Mov
open _Mov
fetch next from _Mov into @nMovID, @dMovDateConfirm, @nMovGoodStateID, @nMovCellSourceID
while @@fetch_status = 0 begin
	insert #Goods (MovingID, OutputID, DatePick, DateConfirm, PackingID, QntConfirmed, QntMovedByTG, QntInFrames, QntReturned) 
		select	@nMovID, O.ID, O.DatePick, O.DateConfirm, 
				OG.PackingID, 
				case when O.DateConfirm is Null then OG.QntSelected else OG.QntConfirmed end as QntConfirmed, 
				IsNull(X.QntConfirmed, 0) as QntMovedByTG, 
				OI.QntInFrames, 
				MG.QntReturned 
			from Outputs O with (nolock) 
			inner join OutputsGoods OG with (nolock) on OG.OutputID = O.ID 
			inner join (select OutputID, PackingID, sum(Qnt) as QntInFrames 
						from OutputsItems 
						where FrameID is not Null 
						group by OutputID, PackingID) OI on OG.OutputID = OI.OutputID and OG.PackingID = OI.PackingID 
			left join (select TG.OutputID, TG.GoodStateID, TG.PackingID, sum(TG.QntConfirmed) as QntConfirmed 
						from TrafficsGoods TG with (nolock) 
						where	TG.OutputID is not Null and 
								TG.DateConfirm is not Null 
						group by TG.OutputID, TG.GoodStateID, TG.PackingID) X 
						on O.ID = X.OutputID and O.GoodStateID = X.GoodStateID and OG.PackingID = X.PackingID 
			inner join (select PackingID, QntConfirmed as QntReturned 
						from MovingsGoods with (nolock) 
						where MovingID = @nMovID) MG 
						on OG.PackingID = MG.PackingID and OI.QntInFrames <= MG.QntReturned 
			where	O.DatePick is not Null and O.DatePick < @dMovDateConfirm and 
					--((O.DateConfirm is not Null and O.DateConfirm > @dMovDateConfirm) or O.DateConfirm is Null) and 
					((O.DateConfirm is not Null and DateDiff(Day, @dMovDateConfirm, O.DateConfirm) > 0) or O.DateConfirm is Null) and 
					O.GoodStateID = @nMovGoodStateID and 
					O.CellID = @nMovCellSourceID and 
					OG.QntConfirmed > IsNull(X.QntConfirmed, 0) /*and 
					OI.QntInItems > 0 and 
					OG.PackingID in (select PackingID from MovingsGoods with (nolock) where MovingID = @nMovID)*/
	
	fetch next from _Mov into @nMovID, @dMovDateConfirm, @nMovGoodStateID, @nMovCellSourceID
end

close _Mov
deallocate _Mov

select	Z.*, Z.QntConfirmed - Z.QntMovedByTG as QntDiff, 
		M.MovDateConfirm, 
		C.Address, 
		Ow.Name as PartnerAlias, 
		GG.Name as GroupAlias, G.Alias as GoodAlias, 
		Trading.dbo.GetOneGoodCost(G.ERPCode, M.MovDateConfirm, 1) as Cost 
	--into __AlexInventory20120526 
	from #Goods Z 
	inner join #Mov M on Z.MovingID = M.ID 
	inner join Outputs O with (nolock) on Z.OutputID = O.ID 
	inner join Partners Ow with (nolock) on O.PartnerID = Ow.ID 
	inner join Cells C with (nolock) on M.CellSourceID = C.ID 
	inner join Packings P with (nolock) on Z.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	where G.HostID = 1		
	--and OutputID = 309734
	--and Z.PackingID = 6528
	order by GG.Name, G.Alias
	--order by MovingID, OutputID, PackingID
