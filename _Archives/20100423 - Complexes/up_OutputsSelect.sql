set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsSelect] 
	@nOutputID		int, 
	@nOutputCellID	int = Null, 
	@nError			int output, 
	@cErrorText		varchar(50) output
AS
-- Подбор товаров для заданного расхода

set nocount on

-- Переменные для отгрузки
declare @bIsSelecting bit, @nOwnerID int, @nPartnerID int, @cPartnerName varchar(100), 
	@bSeparatePicking bit, @nOwnerOdd_ID int, @nComplexID int

-- Получение данных об отгрузке
select	@nOutputCellID = CellID, 
		@bIsSelecting = IsSelecting, 
		@nOwnerID = OwnerID, 
		@nPartnerID = PartnerID, 
		@nComplexID = ComplexID 
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
select @nLostFoundCellID = ID 
	from Cells with (nolock) 
	where Address = @cLostFoundAddress
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

declare @bIsPicking bit		-- наличие хотя бы одной ячейки пикинга в том же комплексе
if exists (select top 1 C.ID 
			from Cells C with (nolock) 
			inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
			inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
			where SZT.ForPicking = 1 and C.Deleted = 0 and 
				(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)) 
			order by C.ID)
	set @bIsPicking = 1
else
	set @bIsPicking = 0

-- Буфер для записи перемещения коробок из пикинга.
-- Создание этого перемещения (запись из буфера) произойдет только при создании трафиков
-- на все кол-во товара из высотки в пикинг.
select OwnerID, GoodStateID, PackingID, QntWished, CellSourceID, CellTargetID, InputID, OutputID 
	into #TrafficsGoods 
	from TrafficsGoods 
	where 1 = 2

declare @nI int, @cNoteX varchar(200)

-- переменные для курсора
declare @nID int, @nGoodStateID int, @nPackingID int, @nQnt decimal(12,3)
declare @nBoxInPal int, @nInBox decimal(12,3), @dDateValid smalldatetime, @bHalfStuff bit, @bWeighting bit
declare @nOwnerOdd decimal(12,3), @nQntOdd  decimal(12,3)

declare _OutputsGoods cursor static for 
	select	OG.ID, O.GoodStateID, OG.PackingID, OG.QntWished - OG.QntSelected as QntWished, 
			P.BoxInPal, P.InBox, OG.DateValid, G.HalfStuff, G.Weighting 
		from OutputsGoods OG  with (nolock) 
		inner join Outputs O  with (nolock) on O.ID = OG.OutputID 
		inner join Packings P with (nolock) on P.ID = OG.PackingID 
		inner join Goods G    with (nolock) on G.ID = P.GoodID 
		where OG.OutputID = @nOutputID and OG.QntWished - OG.QntSelected > 0 
		order by OG.ID
open _OutputsGoods
fetch next from _OutputsGoods 
	into @nID, @nGoodStateID, @nPackingID, @nQnt, @nBoxInPal, @nInBox, @dDateValid, @bHalfStuff, @bWeighting

DECLARE @DTStep DATETIME
SELECT @DTStep = GETDATE()
while @@fetch_status = 0 begin
	-- Получение документарных остатков хранителя
	-- Функция вычитает из остатков все подобранные товары из всех отгрузок, включая текущий
	set @nOwnerOdd = IsNull(dbo.GetOwnersOdds(@nPackingID, @nOwnerOdd_ID, @nGoodStateID), 0)
	
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
			@nQntForRecruit = 0, @nQntRecruited = 0
	
	-- Очищаем буфер перемещения коробок
	truncate table #TrafficsGoods
	
	set @nQntSelected = 0
	
	select @nQntOdd = case when QntWished <= QntOdd then QntWished else QntOdd end 
		from OutputsGoods where ID = IsNull(@nID, 0)
	while 1 = 1 begin
		set @nTrafficID = Null
		if (((not exists (select CC.CellID 
							from CellsContents CC with (nolock) 
							inner join Frames F   with (nolock) on F.ID = CC.FrameID 
							inner join Cells C    with (nolock) on C.ID = CC.CellID 
							inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
							inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
							where	CC.PackingID = @nPackingID and 
									CC.GoodStateID = @nGoodStateID and 
									IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1) and 
									F.Locked = 0 and F.State in ('S', '') and 
									C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 and 
									SZT.ForStorage = 1 and SZT.ForPicking = 0 and 
									(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)) )) 
				or 
				((@nQnt - @nQntPicked) < @nBoxInPal * @nInBox)) and @bRecruit = 0) begin
			-- товара нет в высотке или осталось собрать меньше паллеты - ищем коробки в пикинге, 
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
							IsNull(C.FixedOwnerID, -1) = IsNull(@nOwnerID, -1) and 
							(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1))
					order by C.ID
				if @@RowCount = 0 begin
					-- не нашли жестко закрепленной за товаром ячейки пикинга, ищем динамически закрепленную
					select top 1 @nSourceCellID = CC.CellID 
						from CellsContents CC with (nolock) 
						inner join Cells C with (nolock) on C.ID = CC.CellID 
						inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
						inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
						where	CC.PackingID = @nPackingID and 
								C.Deleted = 0 and 
								CC.GoodStateID = @nGoodStateID and 
								SZT.ForPicking = 1 and 
								IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1) and 
								(@nComplexID is Null or IsNull(SZ.ComplexID, -1) = IsNull(@nComplexID, -1)) 
						order by C.ID
					if @@RowCount = 0 begin
						if @bHalfStuff = 0 begin
							-- нет и никогда не было этого товара в пикинге, 
							-- хвост не догрузили, переходим к следующему, но!
							if @bEasyConfirm = 1 begin
								if dbo.GetCellsContentsComplexQnt(@nPackingID, @nGoodStateID, @nOwnerID, @nComplexID, 0, 1) > 0 begin
									-- проверка наличия товара
									select @nQntSelected = @nQntOdd - QntSelected 
										from OutputsGoods where ID = IsNull(@nID, 0)
									set @cNoteX = @cPartnerName + ' Нет ячейки пикинга для товара (' + ltrim(str(@nQntSelected))+ ')'
									exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
										@nQntSelected, @dDateValid, @nLostFoundCellID,  @nTargetCellID, Null, 
										@nOutputID, @nID, @cNoteX, @nError output, @nTrafficID output
									if @nError > 0 begin
										update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
										set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
										raiserror(@cErrorText, 11, 1)
										return
									end
									update OutputsGoods set QntSelected = @nQntSelected where ID = IsNull(@nID, 0)
								end
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
				set @nQntSelected = IsNull(dbo.GetPickingCellGoodQnt(@nSourceCellID, @nPackingID, @nOwnerID, @nGoodStateID), 0)
				
				if @nQntSelected > (@nQnt - @nQntPicked) begin
					select @nError = 0, @nQntSelected = @nQnt - @nQntPicked
					-- если нашли больше перемещаем в @nTargetCellID из ячейки пикинга, то что нужно (в буфер)
					exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, @nQntSelected, @dDateValid, 
						@nSourceCellID, @nTargetCellID, Null, @nOutputID, @nID, @cPartnerName, @nError output, @nTrafficID output
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
					break
				end
				else begin
					-- если нашли меньше или не нашли вовсе: формируем трафик из пикинга на все количество из пикинга
					-- осуществляем подпитку пикинга целыми палетами пока не наберем нужное количество @nQntForRecruit
					-- если наберем, сформируем перемещение оставшегося кол-ва (всего!) из пикинга в яч. отгрузки
					-- @bRecruit - признак необходимости подпитки пикинга
					if @nQntSelected > 0 begin
						exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, @nQntSelected, @dDateValid, 
							@nSourceCellID, @nTargetCellID, Null, @nOutputID, @nID, @cPartnerName, @nError output, @nTrafficID output
						if @nError > 0 begin
							update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
							set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
							raiserror(@cErrorText, 11, 1)
							return
						end
						update OutputsGoods 
							set QntSelected = QntSelected + @nQntSelected 
							where ID = IsNull(@nID, 0)
						set @nQntPicked = @nQntPicked + @nQntSelected
					end
					
					-- дальше подпитка
					select @bRecruit = 1, @nQntForRecruit = @nQnt - @nQntPicked
					insert #TrafficsGoods (OwnerID, GoodStateID, PackingID, QntWished, 
						CellSourceID, CellTargetID, InputID, OutputID) 
						values (@nOwnerID, @nGoodStateID, @nPackingID, @nQntForRecruit, 
							@nSourceCellID, @nTargetCellID, Null, @nOutputID)
					-- заполнили буфер
					if @@Error > 0 begin
						update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
						set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
						raiserror(@cErrorText, 11, 1)
						return
					end
					-- теперь трафики нужно создавать в соответст. ячейку пикинга!
					set @nTargetCellID = @nSourceCellID
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
--              в текущей версии процедура переходит на сл. товар 
				break
			end
		end
		
		BODY:
		set @nSourceCellID = Null
		exec up_CellOneSelection @nPackingID, @nSourceCellID output, @nOwnerID, @nGoodStateID, @cPreviousRill, @dDateValid, @nComplexID
		--print @nSourceCellID
		--print 'Pallet'
		
		if @nSourceCellID = -1 begin  -- нет товара в принципе
			if @bEasyConfirm = 1 begin
				if dbo.GetCellsContentsComplexQnt(@nPackingID, @nGoodStateID, @nOwnerID, @nComplexID, 0, 1) > 0 begin
					-- проверка наличия товара где-либо
					select @nQntSelected = @nQntOdd - QntSelected 
						from OutputsGoods where ID = IsNull(@nID, 0)
--					select @nQntSelected = @nQnt
					
					if @bRecruit = 1
						select @nSourceCellID = @nTargetCellID, @nTargetCellID = @nOutputCellID
					set @cNoteX = @cPartnerName + ': при автоподборе обнаружена нехватка товара (' + ltrim(str(@nQntSelected))+ ')'
					exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, 
						@nQntSelected, @dDateValid, @nSourceCellID,  @nTargetCellID, Null, 
						@nOutputID, @nID, @cNoteX, @nError output, @nTrafficID output
					if @nError > 0 begin
						update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
						set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...'
						raiserror(@cErrorText, 11, 1)
						return
					end
--					update OutputsGoods set QntSelected = @nQntOdd where ID = IsNull(@nID, 0)
					update OutputsGoods 
						set QntSelected = QntSelected + @nQntSelected 
						where ID = IsNull(@nID, 0)
				end
			end
			break
		end
		if @nSourceCellID = -2 begin    -- товар есть, но не подходит по сроку годности
			if @cPreviousRill is Null begin
				if @bRecruit = 0   --  помечаем запиь в OutputGoood, если товар НЕ для подпитки
					update OutputsGoods  set IsExists = 1 
						where ID = IsNull(@nID, 0) and QntSelected < @nQntOdd
				break
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
			select top 1 @nTargetFrameID = FrameID, @nQntSelected = Qnt 
				from CellsContents C with (nolock) 
				inner join Frames F with (nolock) on F.ID = C.FrameID 
				where C.CellID = @nSourceCellID and C.PackingID = @nPackingID and F.State in ('S', '') 
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
			select @cCellTypeShortCode = SZT.ShortCode 
				from Cells C with (nolock) 
				inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
				inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID 
				where C.ID = @nSourceCellID
			-- в случае работы с ручьем стараемся брать товар из одной и той же ячейки.
			if @cCellTypeShortCode = 'Rill'
				select @cPreviousRill = IsNull(CBuilding, '') + IsNull(CLine, '') + IsNull(CRack, '') + IsNull(CLevel, '') 
					from Cells with (nolock) 
					where ID = @nSourceCellID
			select @nError = 0, @cErrorText = ''
			if @bRecruit = 0 begin
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
					update #TrafficsGoods set QntWished = QntWished - @nQntSelected
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
				update OutputsGoods set QntSelected = QntSelected + @nQntSelected where ID = IsNull(@nID, 0)
				set @nQntPicked = @nQntPicked + @nQntSelected
			end
			else begin
				set @nQntRecruited = @nQntRecruited + @nQntSelected
					if @nQnt < (@nQntPicked + @nQntSelected) begin          -- положили в пикинг больше, чем нужно
						select @nQnt = @nQntOdd - QntSelected 
							from OutputsGoods 
							where ID = IsNull(@nID, 0)
						select @nQntPicked = @nQnt
					end
					else
						select @nQntPicked = @nQntPicked + @nQntSelected
				update OutputsGoods set QntSelected = QntSelected + @nQntPicked where ID = IsNull(@nID, 0)
			end
		end
		
		if ((@nQnt <= @nQntPicked) and (@nQntForRecruit <= @nQntRecruited)) begin
			if @bRecruit > 0 begin
				select	@nOwnerID = OwnerID, @nGoodStateID = GoodStateID, @nPackingID = PackingID, 
						@nQntSelected = QntWished, @nSourceCellID = CellSourceID, 
						@nTargetCellID = CellTargetID, @nOutputID = OutputID 
						from #TrafficsGoods
				select @nError = 0
				exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, @nQntSelected, @dDateValid, 
					@nSourceCellID, @nTargetCellID, Null, @nOutputID, @nID, @cPartnerName, @nError output, @nTrafficID output
				if @nError > 0 begin
					update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
					set @cErrorText = 'Ошибка формирования операции перемещения коробок/штук...' 
					raiserror(@cErrorText, 11, 1)
					return
				end
			end
			break
		end
	end
	
	NEXT_FETCH:
	--PRINT STR(@nPackingID) + ' ' + STR(DATEDIFF(MS, @DTStep, GETDATE()))
	SELECT @DTStep = GETDATE()
	fetch next from _OutputsGoods 
		into @nID, @nGoodStateID, @nPackingID, @nQnt, @nBoxInPal, @nInBox, @dDateValid, @bHalfStuff, @bWeighting
end

close _OutputsGoods
deallocate _OutputsGoods

update Outputs set IsSelecting = 0 where ID = IsNull(@nOutputID, 0)
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