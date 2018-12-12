-- Процедура выравнивания остатков между БД Trading & WMS
-- Может проделываться практически в любой момент
if db_name() <> 'WMS' return

-- Очистка IN.1 (ID = 1) от бесконтейнерных товаров
-- Буфер IN.1.BUF (контейнерный, ID = 5) НЕ ОЧИЩАЕМ!
delete CellsContents 
	where CellID = 1 and FrameID is Null

-- Очистка ячеек OUT.1, OUT.1.BUF, DF.1 & LOST&FOUND
delete CellsContents 
	where CellID in (2, 3, 4, 6)

-- Получение списка ячеек пикинга и их буферов
if object_id('Tempdb..#PickAndBuf') is not Null drop table #PickAndBuf
select C.ID as CellID, C.BufferCellID 
	into #PickAndBuf 
	from Cells C 
	inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ShortCode = 'PICK'

-- Очистка этих ячеек
delete CellsContents 
	where	CellID in (select CellID from #PickAndBuf) or 
			CellID in (select BufferCellID from #PickAndBuf)

-- Проверка отсутствия любых неконтейнерных товаров
if exists (select top 1 CellID from CellsContents where FrameID is Null) begin
	raiserror(N'Non-frame goods exists', 16, 1)
	return
end

-- Получение остатков из Trading с группировкой по владельцу и состоянию
-- Отбрасываем нулевые остатки, тару и товары группы "Услуги"
if object_id('Tempdb..#FullOddments') is not Null drop table #FullOddments
select case when D.SeparatePicking = 0 then cast(Null as int) 
			else D.Owner end as ERPPartner, 
	D.WMSGoodState as ERPGoodState, 
	P.Good as ERPGood, P.InBox, 
	sum(O.Qnt - O.Picked) as Qnt, 
	sum(O.Picked) as Picked, 
	cast(Null as int) as OwnerID, 
	cast(Null as int) as GoodStateID, 
	cast(Null as int) as PackingID, 
	cast(Null as varchar(250)) as IndexStr 
	into #FullOddments 
	from Trading.dbo.Packings P 
	inner join Trading.dbo.Goods G on P.Good = G.Uniq 
	left join Trading.dbo.WHOddments O on O.Packing = P.Uniq 
	left join Trading.dbo.Depots D on O.Depot = D.Uniq 
	where O.Qnt <> 0 and G.Tare = 0 and G.GoodsGroup <> 5 and D.RemoteDepot is Null 
	group by case when D.SeparatePicking = 0 then cast(Null as int) else D.Owner end, 
		D.WMSGoodState, P.Good, P.InBox
	order by 1,2,3,4

-- Получение кодов партнера, состояния товара и кода упаковки
update #FullOddments set OwnerID = P.ID 
	from Partners P 
	where #FullOddments.ERPPartner is not Null and #FullOddments.ERPPartner = P.ERPCode
update #FullOddments set GoodStateID = S.ID 
	from GoodsStates S 
	where #FullOddments.ERPGoodState = S.ERPCode
update #FullOddments set PackingID = P.ID 
	from Packings P 
	inner join Goods G on P.GoodID = G.ID 
	where #FullOddments.ERPGood = G.ERPCode and #FullOddments.InBox = P.InBox 
update #FullOddments set IndexStr = str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID)
create index IX_Tmp_FullOddments on #FullOddments (IndexStr)
select * from #FullOddments

-- Запись всех товаров в состоянии "Набрано" в ячейку OUT.1
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select 2, Null, Null, O.GoodStateID, O.PackingID, Null, sum(O.Picked), GetDate() 
		from #FullOddments O 
		where O.Picked > 0
		group by O.GoodStateID, O.PackingID 



-- Получение остатков на контейнерах с группировкой по владельцу и состоянию
if object_id('Tempdb..#FramesOddments') is not Null drop table #FramesOddments
select OwnerID, GoodStateID, PackingID, sum(Qnt) as Qnt 
	into #FramesOddments 
	from CellsContents 
	where FrameID is not Null 
	group by OwnerID, GoodStateID, PackingID 
	order by OwnerID, GoodStateID, PackingID

-- Уменьшение остатков Trading на величину контейнерных остатков
update #FullOddments set Qnt = #FullOddments.Qnt - F.Qnt 
	from #FramesOddments F 
	where IsNull(#FullOddments.OwnerID, -1) = IsNull(F.OwnerID, -1) and 
		#FullOddments.GoodStateID = F.GoodStateID and 
		#FullOddments.PackingID = F.PackingID

-- Увеличение остатков Trading на величину контейнерных остатков, отсутствующих в Trading
-- Такое может быть, когда Юрлов поменял состояние товара в контейнере в WMS,
-- но не сделал межскладское перемещение в Trading
insert into #FullOddments (ERPPartner, ERPGoodState, ERPGood, InBox, 
	Qnt, OwnerID, GoodStateID, PackingID) 
	select '', '', '', 0, 
		-Qnt, OwnerID, GoodStateID, PackingID 
		from #FramesOddments 
		where str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) not in 
			(select IndexStr from #FullOddments)

-- Удаление остатков, ставших нулевыми
delete #FullOddments where Qnt = 0
--select * from #FullOddments
--where GoodStateID > 2



-- Приписка остатков в состоянии "_Основной" к закрепленным ячейкам пикинга
-- Qnt > 0 - в ячейки пикинга
-- Qnt < 0 - в ячейку LOST&FOUND
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select C.ID, Null, O.OwnerID, O.GoodStateID, O.PackingID, Null, O.Qnt, GetDate() 
		from Cells C 
		inner join #FullOddments O on 
			IsNull(C.FixedOwnerID, -1) = IsNull(O.OwnerID, -1) and 
			C.FixedGoodStateID = O.GoodStateID and 
			C.FixedPackingID = O.PackingID 
		where O.Qnt > 0
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select 4, Null, O.OwnerID, O.GoodStateID, O.PackingID, Null, O.Qnt, GetDate() 
		from Cells C 
		inner join #FullOddments O on 
			IsNull(C.FixedOwnerID, -1) = IsNull(O.OwnerID, -1) and 
			C.FixedGoodStateID = O.GoodStateID and 
			C.FixedPackingID = O.PackingID 
		where O.Qnt < 0

-- Уменьшение остатков Trading на величину остатков, только что приписанных к пикингу
-- (за исключением OUT.1)
update #FullOddments set Qnt = #FullOddments.Qnt - X.Qnt 
	from (select OwnerID, GoodStateID, PackingID, sum(Qnt) as Qnt 
			from CellsContents 
			where FrameID is Null and CellID <> 2 
			group by OwnerID, GoodStateID, PackingID) X 
	where IsNull(#FullOddments.OwnerID, -1) = IsNull(X.OwnerID, -1) and 
		#FullOddments.GoodStateID = X.GoodStateID and 
		#FullOddments.PackingID = X.PackingID

-- Удаление остатков, ставших нулевыми
delete #FullOddments where Qnt = 0
--select * from #FullOddments

-- Перемещение остатков в состоянии "_Основной" в ячейку LOST&FOUND
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select 4, Null, O.OwnerID, O.GoodStateID, O.PackingID, Null, O.Qnt, GetDate() 
		from #FullOddments O 
			where O.GoodStateID = 1
delete #FullOddments where GoodStateID = 1

-- Перемещение остатков в состоянии "Брак", "Виртуальный" и "Уценка"
-- Qnt > 0 - в ячейку DF.1
-- Qnt < 0 - в ячейку LOST&FOUND
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select 3, Null, O.OwnerID, O.GoodStateID, O.PackingID, Null, O.Qnt, GetDate() 
		from #FullOddments O 
			where O.GoodStateID in (2, 3, 6) and Qnt > 0
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select 4, Null, O.OwnerID, O.GoodStateID, O.PackingID, Null, O.Qnt, GetDate() 
		from #FullOddments O 
			where O.GoodStateID in (2, 3, 6) and Qnt < 0
delete #FullOddments where GoodStateID in (2, 3, 6)
--select * from #FullOddments

-- Перемещение всех остальных остатков в LOST&FOUND
insert into CellsContents (CellID, FrameID, OwnerID, GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
	select 4, Null, O.OwnerID, O.GoodStateID, O.PackingID, Null, O.Qnt, GetDate() 
		from #FullOddments O
delete #FullOddments
--select * from #FullOddments

-- Последний аккорд - заполнение остатков Oddments
truncate table Oddments
insert into Oddments (OwnerID, GoodStateID, PackingID, Qnt)
	select OwnerID, GoodStateID, PackingID, sum(Qnt) 
		from CellsContents 
		group by OwnerID, GoodStateID, PackingID

-- Отображение ячеек пикинга с товаром в количестве более 1 паллеты
select C.Address, G.Alias, P.InBox, 
	cast(CC.Qnt / P.InBox as dec(12,1)) as Boxes, 
	cast(CC.Qnt / P.InBox / P.BoxInPal as dec(12,1)) as Pallets 
	from CellsContents CC 
	inner join Cells C on CC.CellID = C.ID 
	inner join Packings P on CC.PackingID = P.ID 
	inner join Goods G on P.GoodID = G.ID 
	inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
	where SZT.ShortCode = 'PICK' and CC.Qnt <> 0 and 
		CC.Qnt / P.InBox / P.BoxInPal > 1 
	order by Pallets desc
