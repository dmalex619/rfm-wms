SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_OutputsSelect] 
	@nOutputID		int, 
	@nOutputCellID	int = Null, 
	@nError			int output, 
	@cErrorText		varchar(50) output
AS
-- Подбор товаров для заданного расхода
set nocount on

-- Переменные для отгрузки
declare	@bIsSelecting bit, @nOwnerID int, @nPartnerID int, @cPartnerName varchar(100), 
		@bSeparatePicking bit, @nOwnerOdd_ID int, @nGoodStateID int

-- Получение данных об отгрузке
select	@nOutputCellID	= CellID, 
		@bIsSelecting	= IsSelecting, 
		@nOwnerID		= OwnerID, 
		@nGoodStateID	= GoodStateID, 
		@nPartnerID		= PartnerID 
	from Outputs 
	where ID = IsNull(@nOutputID, 0)

-- Проверка наличия в задании ячейки отгрузки
if @nOutputCellID is Null return

-- Проверка на одновременный подбор с нескольких рабочих мест
if @bIsSelecting = 1 return

-- Получение "документарного" владельца отгрузки для расчета остатков
set @nOwnerOdd_ID = @nOwnerID

-- Получение признака пофигиста и замена (при необходимости) владельца
select @bSeparatePicking = SeparatePicking 
	from Partners with (nolock) 
	where ID = IsNull(@nOwnerID, 0)
if @bSeparatePicking = 0 set @nOwnerID = Null

-- Получение наименования партнера для записи примечания в создаваемые трафики
select @cPartnerName = Name 
	from Partners with (nolock) 
	where ID = IsNull(@nPartnerID, 0)

-- Установка приоритета трафика по умолчанию
declare @nPriority tinyint
set @nPriority = 5

-- Получение установок системы
declare @bEasyConfirm bit, @bAutoRecruiting bit
select  @bEasyConfirm = IsNull(cast(dbo._SettingsGetValue('bEasyConfirm') as bit), 0)
select  @bAutoRecruiting = IsNull(cast(dbo._SettingsGetValue('bAutoRecruiting') as bit), 0)

-- Если @bEasyConfirm = 1, то при невозможности автоподбора товара (но при его наличиии где-либо ВСЕ РАВНО) 
-- создаются коробочные трафики на весь заказанный товар из ячейки пикинга в ячейку отгрузки, 
-- исходя из того, что вокруг одни геи. Если ячейки пикинга для товара нет, то трафик создается из Lost&Found

-- Если bAutoRecruiting = 1, то будем создавать трафики для автоподпитки пикинга

-- Ячейка Lost&Found - в случае @bEasyConfirm глупо предполагать ее отсутствие, но все-таки: 
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20)
select  @cLostFoundAddress = IsNull(.dbo._SettingsGetValue('sLostFoundAddress'), '')
if @bEasyConfirm = 1 and @cLostFoundAddress = '' begin
	select	@nError = -3, 
			@cErrorText = 'Не задан адрес виртуальной ячейки Lost&Found...'
	return
end
select  @nLostFoundCellID = ID 
        from    Cells with (nolock) 
        where   Address = @cLostFoundAddress
if @bEasyConfirm = 1 and IsNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -4, 
			@cErrorText = 'Не найдена виртуальная ячейка (Lost&Found)...'
	return
end

-- Переводим отгрузку в состояние "Идет подбор товаров"
update Outputs set IsSelecting = 1 
	where ID = IsNull(@nOutputID, 0)

-- прочие переменные
declare @nTrafficID int
declare @nTargetFrameID int, @nTargetCellID int, @nSourceCellID int
declare @cPreviousRill varchar(4), @bRecruit bit, @cCellTypeShortCode varchar(10)
declare @nQntSelected decimal(12,3), @nQntPicked decimal(12,3), 
		@nQntRecruited decimal(12,3), @nQntForRecruit decimal(12,3)

declare @bIsPicking bit		-- наличие хотя бы одной ячейки пикинга
if exists (select top 1 C.ID 
			from Cells C with (nolock) 
			inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
			where SZT.ForPicking = 1 and C.Deleted = 0 
			order by C.ID)
	set @bIsPicking = 1
else
	set @bIsPicking = 0
	
declare @nI int, @cNoteX varchar(200)

-- переменные для курсора
declare @nID int, @nPackingID int, @nQnt decimal(12,3)
declare @nBoxInPal int, @nInBox decimal(12,3), @dDateValid smalldatetime, @bHalfStuff bit, @bWeighting bit
declare @nOwnerOdd decimal(12,3), @nQntOdd  decimal(12,3)
declare @bTrySelectTail bit, @bIsSelectedTail bit
declare @bInStorage bit  -- признак наличия товара в зоне хранения
declare @bInPicking bit  -- признак принудительного поиска товар в пикинге 



-- Изменение от 18.11.2011
-- Получение документарных остатков по всем неподобранным товарам в заказе,
-- чтобы уйти от расчета остатков по каждой позиции отдельно
-- через функцию dbo.GetOwnersOdds() (долго работает).
-- Формируем остатки путем сложения всех приходов, расходов и актов с начала времен.

-- 1. Формирование таблицы упаковок из текущего задания
select OG.PackingID, cast(0 as dec(18,3)) as Odd 
	into #Oddments 
	from OutputsGoods OG with (nolock) 
	where OG.OutputID = IsNull(@nOutputID, 0) and OG.QntWished - OG.QntSelected > 0 
	order by 1

-- 2. Добавление приходов
update #Oddments set Odd = Odd + X.Qnt 
	from (select	IG.PackingID, sum(IG.QntConfirmed) as Qnt 
			from Inputs I with (nolock) 
			inner join InputsGoods IG with (nolock) on I.ID = IG.InputID 
			where I.OwnerID = IsNull(@nOwnerOdd_ID, 0) and IG.GoodStateID = IsNull(@nGoodStateID, 0) 
			group by IG.PackingID) X 
	where #Oddments.PackingID = X.PackingID

-- 3. Вычитание расходов, включая текущий
update #Oddments set Odd = Odd - X.Qnt 
	from (select	OG.PackingID, 
					sum(case when O.DateConfirm is not Null 
						then OG.QntConfirmed 
						else OG.QntSelected end) as Qnt 
				from Outputs O with (nolock) 
				inner join OutputsGoods OG with (nolock) on O.ID = OG.OutputID 
				where O.OwnerID = IsNull(@nOwnerOdd_ID, 0) and OG.GoodStateID = IsNull(@nGoodStateID, 0) 
				group by OG.PackingID) X 
	where #Oddments.PackingID = X.PackingID

-- 4. Добавление актов
update #Oddments set Odd = Odd + X.Qnt 
	from (select AG.PackingID, sum(AG.QntConfirmed) as Qnt 
				from  AuditActs A with (nolock) 
				inner join AuditActsGoods AG with (nolock) on A.ID = AG.AuditActID 
				where A.OwnerID = IsNull(@nOwnerOdd_ID, 0) and A.GoodStateID = IsNull(@nGoodStateID, 0) 
			group by AG.PackingID) X 
	where #Oddments.PackingID = X.PackingID



-- Создаем пустую временную таблицу с данными о всех ячейках, содержащих заданный товар
create table #OddsWithTraffics (CellID int not Null, FrameID int Null, DateValid datetime null, 
	Qnt numeric(12, 3) not Null default (0), 
	QntInTraffics numeric(12, 3) not Null default (0), 
	IsInMove bit not Null default (0)) 
-- Создаем пустую временную таблицу с данными о всех остатках и перемещениях
create table #OddsGrouped (ID int identity(1,1), 
	CellID int not Null, FixedPackingID int Null, 
	CLine varchar(2), CRack varchar(2), CLevel varchar(2), 
	FrameID int Null, ByOrder int default (0), 
	DateValid datetime null, 
	Qnt numeric(12, 3) not Null default (0), 
	QntInTraffics numeric(12, 3) not Null default (0), 
	Selected numeric(12, 3) not Null default (0), 
	ShortCode varchar(10) default (''),
	IsInMove bit not Null default (0))

-- Переменные для формирования траффиков
declare @nRecExists bit, @nRecId int

-- Переменная для определения алгоритма подюора товаров (новый/старый).
-- Старый оставляем для Шебекино
declare @bUseOldAlgorithm bit
if exists (select top 1 SZ.ID 
			from StoresZones SZ with (nolock) 
			inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
			where SZT.ShortCode = 'Rill')
	set @bUseOldAlgorithm = 1
else
	set @bUseOldAlgorithm = 0

-- Создание курсора для подбора товаров
declare _OutputsGoods cursor static for 
	select	OG.ID, O.GoodStateID, OG.PackingID, OG.QntWished - OG.QntSelected as QntWished, 
			P.BoxInPal, P.InBox, OG.DateValid, G.HalfStuff, G.Weighting 
		from OutputsGoods OG  with (nolock) 
		inner join Outputs O  with (nolock) on O.ID = OG.OutputID 
		inner join Packings P with (nolock) on P.ID = OG.PackingID 
		inner join Goods G    with (nolock) on G.ID = P.GoodID 
		where OG.OutputID = @nOutputID and OG.QntWished - OG.QntSelected > 0 
		--order by OG.ID desc
		order by OG.ID
open _OutputsGoods
fetch next from _OutputsGoods 
	into @nID, @nGoodStateID, @nPackingID, @nQnt, @nBoxInPal, @nInBox, @dDateValid, @bHalfStuff, @bWeighting
set  @bInPicking = 0

while @@fetch_status = 0 begin
	-- Получение документарных остатков хранителя
	-- Функция вычитает из остатков все подобранные товары из всех отгрузок, включая текущий
--	set @nOwnerOdd = IsNull(dbo.GetOwnersOdds(@nPackingID, @nOwnerOdd_ID, @nGoodStateID), 0)
--	set @nOwnerOdd = 1000000
	-- Изменение от 18.11.2011
	select @nOwnerOdd = IsNull(Odd, 0) 
		from #Oddments 
		where PackingID = IsNull(@nPackingID, 0)
	
	-- Запись документарных остатков на момент подбора в расшифровку отгрузки
	update OutputsGoods 
		set QntOdd = QntSelected + @nOwnerOdd 
		where ID = IsNull(@nID, 0)
	
	-- Если товар не числится в документарных остатках,
	-- мы записали эту информацию и переходим к следующей расшифровке
	if @nOwnerOdd <= 0 goto NEXT_FETCH
	
	-- В случае превышения желаемого количества над остатками
	-- уменьшаем его до документарного количества (с учетом признака "Весовой")
	if @nQnt > @nOwnerOdd 
		select @nQnt = case when @bWeighting = 0 then floor(@nOwnerOdd) else @nOwnerOdd end
	
	-- Если на остатках числится только "хвостик" для невесового товара - отваливаем
	if @nQnt = 0 goto NEXT_FETCH
	
	-- Теперь @nQnt содержит то количество товара, которое мы хотим подобрать
	-- Проверили остатки - начинаем подбор
	
	-- В цикле возможна замена ячейки отгрузки на ячейку пикинга.
	set @nTargetCellID = @nOutputCellID
	
	-- Обнуление внутренних переменных
	select	@nSourceCellID = Null, @cPreviousRill = Null, @nQntPicked = 0, @bRecruit = 0, 
			@nQntForRecruit = 0, @nQntRecruited = 0, @bTrySelectTail = 0
	
	set @nQntSelected = 0
	
	select @nQntOdd = case when QntWished <= QntOdd then QntWished else QntOdd end
		from OutputsGoods 
		where ID = IsNull(@nID, 0)

	-- Проверка на применяемый алгоритм (новый или старый).
	-- Новый должен работать в Жуковском и Всеволожске, старый - в Шебекино
		if @bUseOldAlgorithm = 1
			goto OLD_ALGORITHM





	-- Начало нового алгоритма
	-- Изменения от 26.12.2018 Александров
	-- Вводим принципиально новый алгоритм подбора товаров в расход
	
	-- Очищаем временные таблицы
	truncate table #OddsWithTraffics
	truncate table #OddsGrouped

	-- Шаг 1: заполняем временную таблицу с данными о всех ячейках, содержащих заданный товар.
	-- Учитываем ячейки, предназначенные только одля хранения ('PICK', 'STOR', 'RILL')
	insert #OddsWithTraffics (CellID, FrameID, DateValid, Qnt, IsInMove) 
		select	CC.CellID, CC.FrameID, CC.DateValid, CC.Qnt, 0 
			from CellsContents CC 
			inner join Cells C on CC.CellID = C.ID 
			inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
			where	SZT.ForStorage = 1 and 
					C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 and 
					CC.PackingID = @nPackingID and 
					CC.GoodStateID = @nGoodStateID and 
					IsNull(CC.DateValid, '20000101') >= IsNull(@dDateValid, '20000101') and 
					IsNull(CC.OwnerID, 0) = IsNull(@nOwnerID, 0) 

	-- Шаг 2: получаем все контейнерные траффики
	;	-- Обобщенное табличное выражение для ускорения расчетов
	with CTE_TF as (
		select	TF.CellSourceID, TF.CellTargetID, TF.FrameID, CC.DateValid, CC.Qnt 
			from TrafficsFrames TF 
			inner join Frames F on F.ID = TF.FrameID 
			inner join CellsContents CC on TF.CellSourceID = CC.CellID and TF.FrameID = CC.FrameID 
			inner join Cells C on C.ID = TF.CellSourceID 
			where	TF.DateConfirm is Null and 
					F.Locked = 0 and 
					C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 and 
					CC.PackingID = @nPackingID and 
					CC.GoodStateID = @nGoodStateID and 
					IsNull(CC.DateValid, '20000101') >= IsNull(@dDateValid, '20000101') and 
					IsNull(CC.OwnerID, 0) = IsNull(@nOwnerID, 0) 
	)
	insert #OddsWithTraffics (CellID, FrameID, DateValid, QntInTraffics, IsInMove) 
		-- исходящие контейнерные траффики
		select	T.CellSourceID, T.FrameID, T.DateValid, -T.Qnt, 1 
			from CTE_TF T 
			inner join Cells C on C.ID = T.CellSourceID 
			inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 
			where	SZT.ForStorage = 1 
		union all 
		-- входящие контейнерные траффики
		select	T.CellTargetID, T.FrameID, T.DateValid, T.Qnt, 1 
			from CTE_TF T 
			inner join Cells C on C.ID = T.CellTargetID 
			inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 
			where	SZT.ForStorage = 1
	
	-- Шаг 3: получаем все коробочные траффики
	;	-- Обобщенное табличное выражение для ускорения расчетов
	with CTE_TG as (
		select	TG.CellSourceID, TG.CellTargetID, 
				TG.FrameID, CC.DateValid, TG.QntWished as Qnt 
			from TrafficsGoods TG 
			inner join CellsContents CC on TG.CellSourceID = CC.CellID 
			inner join Cells C on C.ID = TG.CellSourceID 
			where	TG.DateConfirm is Null and 
					C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 and 
					CC.PackingID = @nPackingID and 
					CC.GoodStateID = @nGoodStateID and 
					IsNull(CC.DateValid, '20000101') >= IsNull(@dDateValid, '20000101') and 
					IsNull(CC.OwnerID, 0) = IsNull(@nOwnerID, 0) 
	)
	insert #OddsWithTraffics (CellID, FrameID, DateValid, QntInTraffics, IsInMove) 
		-- исходящие коробочные траффики
		select	T.CellSourceID, T.FrameID, T.DateValid, -T.Qnt, 1 
			from CTE_TG T 
			inner join Cells C on C.ID = T.CellSourceID 
			inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 
			where	SZT.ForStorage = 1 
		union all
		-- входящие коробочные траффики
		select	T.CellTargetID, T.FrameID, T.DateValid, T.Qnt, 1 
			from CTE_TG T 
			inner join Cells C on C.ID = T.CellTargetID 
			inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 
			where	SZT.ForStorage = 1

	-- Шаг 3. получаем сгруппированные остатки
	insert #OddsGrouped (CellID, FixedPackingID, 
			CLine, CRack, CLevel, 
			FrameID, ByOrder, 
			DateValid, Qnt, QntInTraffics, Selected, 
			ShortCode, IsInMove) 
		select	X.CellID, C.FixedPackingID, 
				C.CLine, C.CRack, C.CLevel, 
				X.FrameID, IsNull(CC.ByOrder, 0), 
				X.DateValid, X.Qnt, X.QntInTraffics, 0, 
				SZT.ShortCode, X.IsInMove 
			from (select CellID, FrameID, DateValid, 
						sum(Qnt) as Qnt, 
						sum(QntInTraffics) as QntInTraffics, 
						cast(sum(cast(IsInMove as int)) as bit) as IsInMove 
					from #OddsWithTraffics 
					group by CellID, FrameID, DateValid) X 
			inner join Cells C on X.CellID = C.ID 
			left join CellsContents CC on C.ID = CC.CellID 
			inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 

	--SELECT * from #OddsWithTraffics
	--SELECT * from #OddsGrouped

	-- Шаг 4: начинаем формирование контейнерных и коробочных траффиков

	-- Шаг 4а: контейнерные траффики
	set @nRecExists = 1
	while (@nRecExists = 1) begin
		-- Выбираем одну запись по условиям: контейнер, нет траффиков, в зоне хранения, с нужным количеством.
		-- По пожеланию Ширяева, сначала освобождаем высокие паллетоместа
		select	top 1 
				@nRecId			= ID, 
				@nSourceCellID	= CellID, 
				@nTargetFrameID	= FrameID, 
				@nQntSelected	= Qnt 
			from #OddsGrouped 
			where	FrameID is not Null and 
					QntInTraffics = 0 and 
					ShortCode in ('STOR', 'RILL') and 
					Qnt <= @nQnt 
			order by DateValid, CLevel desc, Qnt desc
		-- Проверяем успешность поиска
		if @@RowCount = 1 begin
			-- создаем контейнерный траффик...
			exec up_TrafficsFramesOneCreate @nTargetFrameID, @nSourceCellID, @nOutputCellID, 
				@nPriority, Null, @nOutputID, @nID, 1, @cPartnerName, 
				@nError output, @nTrafficID output
			if @nError > 0 begin
				update Outputs set IsSelecting = 0 
					where ID = IsNull(@nOutputID, 0)
				set @cErrorText = 'Ошибка создания операции транспортировки контейнера...' + 
					cast(@nTargetFrameID as varchar(10)) + '...'
				raiserror(@cErrorText, 11, 1)
				return
			end

			-- ...меняем уже подобранное количество в отгрузке...
			update OutputsGoods set QntSelected = QntSelected + @nQntSelected 
				where ID = IsNull(@nID, 0)

			-- ...уменьшаем количество к подбору...
			set @nQnt = @nQnt - @nQntSelected

			-- ...удаляем более ненужную строку в таблице
			delete #OddsGrouped where ID = @nRecId
		end
		else begin
			-- ничего не нашли - выходим
			set @nRecExists = 0
		end
	end

	-- Проверяем - нужно ли подбирать этот товар дальше
	if @nQnt = 0
		goto NEXT_FETCH

	-- Шаг 4б: коробочные траффики из ячеек пикинга
	set @nRecExists = 1
	while (@nRecExists = 1) begin
		-- Выбираем одну запись по условиям: НЕ контейнер, в зоне пикинга, с нужным количеством
		-- При сортировке сначала берем закрепленные ячейки
		select	top 1 
				@nRecId			= ID, 
				@nSourceCellID	= CellID, 
				@dDateValid		= DateValid, 
				@nQntSelected	= Qnt + QntInTraffics 
			from #OddsGrouped 
			where	FrameID is Null and 
					Qnt + QntInTraffics > 0 and 
					ShortCode in ('PICK')
			order by FixedPackingID desc, DateValid, Qnt + QntInTraffics desc
		-- Проверяем успешность поиска
		if @@RowCount = 1 begin
			-- Уменьшаем подобранное количество, если нужно...
			if @nQntSelected > @nQnt
				set @nQntSelected = @nQnt

			-- создаем коробочный траффик...
			set @cNoteX = @cPartnerName + ': подбор из пикинга'
			exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
				@nQntSelected, @dDateValid, 
				@nSourceCellID,  @nTargetCellID, Null, 
				Null, @nOutputID, @nID, @cNoteX, 
				@nError output, @nTrafficID output
			if @nError > 0 begin
				update Outputs set IsSelecting = 0 
					where ID = IsNull(@nOutputID, 0)
				set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
				raiserror(@cErrorText, 11, 1)
				return
			end

			-- ...меняем уже подобранное количество в отгрузке...
			update OutputsGoods set QntSelected = QntSelected + @nQntSelected 
				where ID = IsNull(@nID, 0)

			-- ...уменьшаем количество к подбору...
			set @nQnt = @nQnt - @nQntSelected
			if @nQnt = 0
				goto NEXT_FETCH

			-- ...удаляем более ненужную строку в таблице
			delete #OddsGrouped where ID = @nRecId
		end
		else begin
			-- ничего не нашли - выходим
			set @nRecExists = 0
		end
	end

	-- Проверяем - нужно ли подбирать этот товар дальше
	if @nQnt = 0
		goto NEXT_FETCH

	-- Шаг 4в: коробочные траффики из ячеек хранения
	set @nRecExists = 1
	while (@nRecExists = 1) begin
		-- Выбираем одну запись по условиям: контейнер, в зоне хранения, с нужным количеством
		-- При сортировке учитываем количество в контейнере - чем меньше, тем лучше
		-- По пожеланию Ширяева, стараемся подбирать места на 1-м ярусе
		select	top 1 
				@nRecId			= ID, 
				@nSourceCellID	= CellID, 
				@nTargetFrameID	= FrameID, 
				@dDateValid		= DateValid, 
				@nQntSelected	= Qnt + QntInTraffics 
			from #OddsGrouped 
			where	FrameID is not Null and 
					Qnt + QntInTraffics > 0 and 
					ShortCode in ('STOR', 'RILL')
			order by DateValid, CLevel, Qnt + QntInTraffics
		-- Проверяем успешность поиска
		if @@RowCount = 1 begin
			-- Уменьшаем подобранное количество, если нужно...
			if @nQntSelected > @nQnt
				set @nQntSelected = @nQnt

			-- создаем коробочный траффик...
			set @cNoteX = @cPartnerName + ': подбор из зоны хранения'
			exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
				@nQntSelected, @dDateValid, 
				@nSourceCellID,  @nTargetCellID, @nTargetFrameID, 
				Null, @nOutputID, @nID, @cNoteX, 
				@nError output, @nTrafficID output
			if @nError > 0 begin
				update Outputs set IsSelecting = 0 
					where ID = IsNull(@nOutputID, 0)
				set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
				raiserror(@cErrorText, 11, 1)
				return
			end

			-- ...меняем уже подобранное количество в отгрузке...
			update OutputsGoods set QntSelected = QntSelected + @nQntSelected 
				where ID = IsNull(@nID, 0)

			-- ...уменьшаем количество к подбору...
			set @nQnt = @nQnt - @nQntSelected
			if @nQnt = 0
				goto NEXT_FETCH

			-- ...удаляем более ненужную строку в таблице
			delete #OddsGrouped where ID = @nRecId
		end
		else begin
			-- ничего не нашли - выходим
			set @nRecExists = 0
		end
	end
	goto NEXT_FETCH
	-- Конец нового алгоритма





	-- Начало старого алгоритма
	-- Последние изменения - октябрь 2010
	OLD_ALGORITHM:
	while 1 = 1 begin
		select @nTrafficID = Null, @bIsSelectedTail = 0 , @bInStorage = 0

		if exists (select CC.CellID 
						from CellsContents CC with (nolock) 
						inner join Frames F   with (nolock) on F.ID = CC.FrameID 
						inner join Cells C    with (nolock) on C.ID = CC.CellID 
						inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
						inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
						where	CC.PackingID = @nPackingID and 
								CC.GoodStateID = @nGoodStateID and 
								IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1) and 
								F.Locked = 0 and F.State in ('S', '') and F.HasTraffic = 0 and
								C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 and 
								SZT.ForStorage = 1 and SZT.ForPicking = 0) and @bInPicking = 0
				set @bInStorage = 1						
		if  @bInStorage = 0  or (((@nQnt - @nQntPicked) < @nBoxInPal * @nInBox) and @bRecruit = 0) begin
			-- или товара нет в высотке или осталось собрать меньше паллеты - должны искать коробки в пикинге,
			-- но сначала поищем "хвосты" в высотке если он там есть
			if @bTrySelectTail = 0 and 
				(((@nQnt - @nQntPicked) < @nBoxInPal * @nInBox) and @bRecruit = 0) and
				@bInStorage = 1	
			begin
				set @bTrySelectTail = 1
				goto BODY
			end
			else begin
				-- (если пикинг есть вообще)
				if @bIsPicking = 1 begin
					-- Ищем закрепленную ячейку пикинга
					select top 1 @nSourceCellID = C.ID 
						from Cells C with (nolock) 
						inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
						inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
						where	SZT.ForPicking = 1 and 
								C.Deleted = 0 and 
								C.FixedPackingID = @nPackingID and C.FixedGoodStateID = @nGoodStateID and 
								IsNull(C.FixedOwnerID, -1) = IsNull(@nOwnerID, -1) 
						order by C.ID
					if @@RowCount = 0 begin
						-- не нашли жестко закрепленной за товаром ячейки пикинга, ищем динамически закрепленную
						select top 1 @nSourceCellID = CC.CellID 
							from CellsContents CC with (nolock) 
							inner join Cells C with (nolock) on C.ID = CC.CellID 
							inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
							inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT .ID 
							where	CC.PackingID = @nPackingID and 
									C.Deleted = 0 and 
									CC.GoodStateID = @nGoodStateID and 
									SZT.ForPicking = 1 and 
									IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1) 
							order by C.ID
						if @@RowCount = 0 begin
							if @bHalfStuff = 0 begin
								-- нет и никогда не было этого товара в пикинге, 
								-- хвост не догрузили, переходим к следующему, но!
								if 1=1 begin -- в случае работы с документарных остатков товар точно где-то есть
--								if @bEasyConfirm = 1 begin
--									if dbo.GetCellsContentsQnt(@nPackingID, @nGoodStateID, @nOwnerID, 0, 1) > 0 begin
										-- проверка наличия товара
										select @nQntSelected = @nQntOdd - QntSelected 
											from OutputsGoods 
											where ID = IsNull(@nID, 0)
										set @cNoteX = @cPartnerName + ' Нет ячейки пикинга для товара (' + ltrim(str(@nQntSelected))+ ')'
										exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
											@nQntSelected, @dDateValid, 
											@nLostFoundCellID,  @nTargetCellID, Null, 
											Null, @nOutputID, @nID, @cNoteX, 
											@nError output, @nTrafficID output
										if @nError > 0 begin
											update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
											set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
											raiserror(@cErrorText, 11, 1)
											return
										end
										update OutputsGoods set QntSelected = QntSelected + @nQntSelected where ID = IsNull(@nID, 0)
--									end
								end
								break
							end
							else begin
								-- полуфабриката в пикинге нет в принципе, поэтому подбираем целую паллету
								goto BODY
							end
						end
					end
					
					-- Нашли ячейку пикинга, откуда можно взять товар (@nSourceCellID is not Null)
					if @bAutoRecruiting = 1 begin
						set @nQntSelected = IsNull(dbo.GetPickingCellGoodQnt(@nSourceCellID, @nPackingID, @nOwnerID, @nGoodStateID), 0)
						if @nQntSelected < (@nQnt - @nQntPicked)
							-- нужна подпитка							
							set @nQntForRecruit = @nQnt - @nQntPicked
					end
					
					if 1 = 1 begin
						select @nError = 0, @nQntSelected = @nQnt - @nQntPicked
						-- если нашли больше перемещаем в @nTargetCellID из ячейки пикинга, то что нужно (в буфер)
						exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
							@nQntSelected, @dDateValid, 
							@nSourceCellID, @nTargetCellID, Null, 
							Null, @nOutputID, @nID,  @cPartnerName, 
							@nError output, @nTrafficID output
						if @nError > 0 begin
							update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
							set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
							raiserror(@cErrorText, 11, 1)
							return
						end
						
						-- Необходимое кол-во товара подобрано, переходим к следующей расшифровке
						update OutputsGoods 
							set QntSelected = QntSelected + @nQntSelected 
							where ID = IsNull(@nID, 0)
						
						if @bAutoRecruiting = 1  and @nQntForRecruit> 0  begin
							select @bRecruit = 1,@nTargetCellID = @nSourceCellID
							select @nQntPicked =  QntSelected 
								from OutputsGoods 
								where ID = IsNull(@nID, 0)
							goto BODY
						end
						else							
							break
					end
				end
				else begin
					-- если пикинга нет вообще, можно отвалиться совсем, можно перейти к следующему товару, 
					-- а можно направить в зону отгрузки целую палету(если идти дальше в программе)
					-- а можно и не целую
	--				update Outputs set IsSelecting = 0 where ID = @nOutputID
	--				set @cErrorText = 'Ошибка поиска ячейки пикинга...' 
	--				raiserror(@cErrorText, 11, 1)
	--				return
	--              закомментированный текст заканчивает работу процедуры подбора, в случае отсутствия зоны "пикинг"
	--              с соответствующей ошибкой 
	--              в текущей версии процедура переходит на след. товар 
					break
				end
			end
		end
		
		BODY:
		set @nSourceCellID = Null
		exec up_CellOneSelection @nPackingID, @nSourceCellID output, @nOwnerID, @nGoodStateID, @cPreviousRill, @dDateValid
		if @nSourceCellID = -1 begin	-- нет товара в зоне хранения в принципе
			if @bRecruit = 1
				goto NEXT_FETCH
				-- нечем подпитывать, переходим на сл. товар				
			if @bEasyConfirm = 1 begin
				if 1 = 1 begin -- в случае работы с документарных остатков товар точно где-то есть
					-- проверка наличия товара где-либо
					select @nQntSelected = @nQntOdd - QntSelected
						from OutputsGoods 
						where ID = IsNull(@nID, 0)
						-- при подпитке пикинга товара нет в зоне хранения - никакого трафика не создаем, в голове цикла ячейки все равно переопределим
						
						set @nTargetCellID = @nOutputCellID
						-- делаем трафик либо из ячейки пикинга, либо из L&F - в ячейку отгрузки 
						select @nSourceCellID = ID 
							from Cells with (nolock)  
							where	FixedPackingID = @nPackingID and 
									FixedGoodStateID = @nGoodStateID and 
									IsNull(FixedOwnerID, -1) = IsNull(@nOwnerID, -1)
						if @@rowcount = 0
							set @nSourceCellID = @nLostFoundCellID	
					
					set @cNoteX = @cPartnerName + ': при автоподборе обнаружена нехватка товара (' + ltrim(str(@nQntSelected))+ ')'
					exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
						@nQntSelected, @dDateValid, 
						@nSourceCellID,  @nTargetCellID, Null, 
						Null, @nOutputID, @nID, @cNoteX, 
						@nError output, @nTrafficID output
					if @nError > 0 begin
						update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
						set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
						raiserror(@cErrorText, 11, 1)
						return
					end
					update OutputsGoods 
						set QntSelected = QntSelected + @nQntSelected 
						where ID = IsNull(@nID, 0)
				end
				break
			end
			else begin
				-- перейдем в пикинг для подбора остального товара, в случае работы с документарными остатками товар точно где-то есть
				select @bInStorage = 0,@bInPicking = 1
				continue
			end
		end
		if @nSourceCellID = -2 begin	-- товар есть, но не подходит по сроку годности
			if @cPreviousRill is Null begin
				if @bRecruit = 0   --  помечаем запиь в OutputGoood, если товар НЕ для подпитки
					update OutputsGoods  set IsExists = 1 
						where ID = IsNull(@nID, 0)
				else ----- @bRecruit = 1
					goto NEXT_FETCH
				-- нет для подпитки тоара с нужным сроком годности, переходим к сл. товару				
			end
			else begin
				set @cPreviousRill = Null
				goto BODY
			end
		end
		
		if @nSourceCellID is Null begin
			if @cPreviousRill is not Null begin
				set @cPreviousRill = Null
				goto BODY
			end
			else begin
				-- кажется, что мы сюда никогда не должны попасть.
				break
			end
		end
		else begin
			select @cCellTypeShortCode = SZT.ShortCode 
				from Cells C  with (nolock) 
				inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
				inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
				where C.ID = @nSourceCellID
			if @cCellTypeShortCode = 'RillDirect'
				select top 1 @nTargetFrameID = FrameID, @nQntSelected = Qnt 
					from CellsContents C with (nolock) 
					inner join Frames F with (nolock) on F.ID = C.FrameID 
					where	C.CellID = @nSourceCellID and C.PackingID = @nPackingID and F.State in ('S', '') 
					order by C.DateValid
			else	
				select top 1 @nTargetFrameID = FrameID, @nQntSelected = Qnt 
					from CellsContents C with (nolock) 
					inner join Frames F with (nolock) on F.ID = C.FrameID 
					where	C.CellID = @nSourceCellID and C.PackingID = @nPackingID and F.State in ('S', '') 
					order by IsNull(ByOrder, -1)
			if @@RowCount = 0 begin
				if @cPreviousRill is not Null begin
					set @cPreviousRill = Null
					continue
				end
				else begin
					break
				end
			end
			-- в случае работы с ручьем стараемся брать товар из одной и той же ячейки.
			if @cCellTypeShortCode = 'Rill'
				select @cPreviousRill = IsNull(CBuilding, '') + IsNull(CLine, '') + IsNull(CRack, '') + IsNull(CLevel, '') 
					from Cells with (nolock)
					where ID = @nSourceCellID
			select @nError = 0, @cErrorText = ''
			if @bRecruit = 0 begin
			-- если при попытке поиска хвоста нашли хвост больше, чем нужно или целый контейнер  -> 
			-- трафик не делаем и будем добирать в пикинге 	
			-- И ВСЕ ЭТО ТОЛЬКО ДЛЯ ТОВАРА, НО НЕ ПОЛУФАБРИКАТА !!!
				if  ((@bHalfStuff = 1) or (@bTrySelectTail = 0) or (@bTrySelectTail = 1 and @nQnt >= ( @nQntPicked + @nQntSelected )))  begin	
					exec up_TrafficsFramesOneCreate @nTargetFrameID, @nSourceCellID, @nTargetCellID, 
						@nPriority, Null, @nOutputID, @nID, 1, @cPartnerName, @nError output, @nTrafficID output
					if @nError > 0 begin
						update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
						set @cErrorText = 'Ошибка создания операции транспортировки контейнера...' + 
							cast(@nTargetFrameID as varchar(10)) + '...'
						raiserror(@cErrorText, 11, 1)
						return
					end
				end
			end
			else begin
				-- если для подпитки нашли неполную паллету, ее сразу в отгрузку
				if @nQnt > (@nQntPicked + @nQntSelected) begin
					exec up_TrafficsFramesOneCreate @nTargetFrameID, @nSourceCellID, @nOutputCellID, 
						@nPriority, Null, @nOutputID, @nID, 1, @cPartnerName, @nError output, @nTrafficID output
					if @nError > 0 begin
						update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
						set @cErrorText = 'Ошибка создания операции транспортировки контейнера...' + 
							cast(@nTargetFrameID as varchar(10)) + '...'
						raiserror(@cErrorText, 11, 1)
						return
					end
					select @nQntForRecruit = @nQntForRecruit - @nQntSelected
					update OutputsGoods set QntSelected = QntSelected + @nQntSelected where ID = IsNull(@nID, 0)
					set @nQntPicked = @nQntPicked + @nQntSelected
					continue
				end
				else begin
					if @bAutoRecruiting = 1 begin
						exec up_TrafficsFramesOneCreate @nTargetFrameID, @nSourceCellID, @nTargetCellID, 
							@nPriority, Null, Null, Null, 1, 'Подпитка пикинга', @nError output, @nTrafficID output
						-- в случае подпитки пикинга OutputID = Null
						if @nError > 0 begin
							update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
							set @cErrorText = 'Ошибка создания операции транспортировки контейнера...' + 
								cast(@nTargetFrameID as varchar(10)) + '...'
							raiserror(@cErrorText, 11, 1)
							return
						end
					end
				end
			end
			if @bRecruit = 0 begin
				-- если при попытке поиска хвоста нашли хвост больше, чем нужно или целый контейнер будем искать в пикинге
				-- И ВСЕ ЭТО ТОЛЬКО ДЛЯ ТОВАРА, НО НЕ ПОЛУФАБРИКАТА !!!
				if  ( (@bHalfStuff = 1) or (@bTrySelectTail = 0) or (@bTrySelectTail = 1 and @nQnt >= ( @nQntPicked + @nQntSelected ))) begin	
					update OutputsGoods set QntSelected = QntSelected + @nQntSelected where ID = IsNull(@nID, 0)
					set @nQntPicked = @nQntPicked + @nQntSelected
					if @bTrySelectTail = 1
						set @bIsSelectedTail = 1
				end
			end
			else begin
				set @nQntRecruited = @nQntRecruited + @nQntSelected
					if @nQnt < @nQntPicked begin														
						if @nQnt < (@nQntPicked + @nQntSelected) begin	-- положили в пикинг больше, чем нужно
							select @nQnt = @nQntOdd - QntSelected 
								from OutputsGoods 
								where ID = IsNull(@nID, 0)
							select @nQntPicked = @nQnt
						end
						else
							select @nQntPicked = @nQntPicked + @nQntSelected
					end		
			if @nQnt < @nQntPicked		
					update OutputsGoods set QntSelected = QntSelected + @nQntPicked where ID = IsNull(@nID, 0)
			if @nQntForRecruit > @nQntRecruited		
				goto BODY		
			end
		end
		if ((@nQnt <= @nQntPicked) and (@nQntForRecruit <= @nQntRecruited)) begin
			break
		end
		else begin
			if  @bTrySelectTail = 1 and @bIsSelectedTail = 1
				set @bTrySelectTail = 0
		end
	end
	-- Конец старого алгоритма


	
	NEXT_FETCH:
	fetch next from _OutputsGoods 
		into @nID, @nGoodStateID, @nPackingID, @nQnt, @nBoxInPal, @nInBox, @dDateValid, @bHalfStuff, @bWeighting
	set  @bInPicking = 0
end

close _OutputsGoods
deallocate _OutputsGoods

update Outputs set IsSelecting = 0 
	where ID = IsNull(@nOutputID, 0)
select @nError = @@Error
if @nError <> 0 goto ERR

update Outputs set DateStart = GetDate() 
	where ID = IsNull(@nOutputID, 0) and DateStart is Null
select @nError = @@Error
if @nError <> 0 goto ERR

if exists(select ID from OutputsGoods with (nolock) where OutputID = IsNull(@nOutputID, 0) and QntSelected > 0) begin
	update Outputs set DateSelect = GetDate() 
		where ID = IsNull(@nOutputID, 0)
	select @nError = @@Error
	if @nError <> 0 goto ERR
end

exec up_OutputsTrafficsCheck @nOutputID
return

-- ошибка 
ERR:
return