set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsGoodsFillAnytime] 
	@nOutputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS
-- выборка товаров для расходов для накладной подтверждения. 
-- анализ выполнения всех операций по каждому товару 

set nocount on

if @nOutputID <> 0 and 
		not exists (select ID from Outputs with (nolock) where ID = IsNull(@nOutputID, 0)) begin
	select	@nError = -1, 
			@cErrorText = 'Не найден расход с кодом ' + ltrim(str(@nOutputID)) + '...'
	RaisError(@cErrorText, 16, 1)
	return
end

declare @nCellTargetID int
if @nOutputID = 0 begin 
	set @nCellTargetID = 0 
end
else begin
	select @nCellTargetID = CellID 
		from Outputs with (nolock) 
		where ID = IsNull(@nOutputID, 0)
	if @nCellTargetID is Null begin
		select	@nError = -2, 
				@cErrorText = 'Не определена ячейка отгрузки для расхода с кодом ' + ltrim(str(@nOutputID)) + '...'
		RaisError(@cErrorText, 16, 1)
		return
	end
end

-- товары в задании
select * 
	into #OutputsGoods 
	from OutputsGoods with (nolock)
	where OutputID = IsNull(@nOutputID, 0)
-- собранные товары (уже в ячейке отгрузки)
select * 
	into #OutputsItems 
	from OutputsItems with (nolock)
	where OutputID = IsNull(@nOutputID, 0)

declare @bTrafficsGoodsExists bit, @bTrafficsFramesExists bit, 
		@bTrafficsGoodsNotConfirmed bit, @bTrafficsFramesNotConfirmed bit
select  @bTrafficsGoodsExists = 0, @bTrafficsFramesExists = 0, 
		@bTrafficsGoodsNotConfirmed = 0, @bTrafficsFramesNotConfirmed = 0

select  TG.*
	into #TrafficsGoods 
	from TrafficsGoods TG with (nolock)
	where TG.OutputID = IsNull(@nOutputID, 0) and TG.ErrorID is Null
if @@RowCount > 0 
	set @bTrafficsGoodsExists = 1
if exists (select ID from #TrafficsGoods where DateConfirm is Null) 
	set @bTrafficsGoodsNotConfirmed = 1
	
select  TF.*, 
		cast(0 as int) as PackingID, cast(0 as decimal(15, 3)) as Qnt 
	into #TrafficsFrames 
	from TrafficsFrames TF with (nolock) 
	where TF.OutputID = IsNull(@nOutputID, 0) and 
			(TF.DateConfirm is Null or TF.DateConfirm is not Null and TF.Success = 1)
if @@RowCount > 0 
	set @bTrafficsFramesExists = 1
if exists (select ID from #TrafficsFrames where DateConfirm is Null) 
	set @bTrafficsGoodsNotConfirmed = 1
update #TrafficsFrames
	set PackingID = OI.PackingID, Qnt = OI.Qnt
	from #OutputsItems OI
	where #TrafficsFrames.FrameID = OI.FrameID 
update #TrafficsFrames -- для тех, которые еще не поехали (нет в OutputsItems)
	set PackingID = CC.PackingID, Qnt = CC.Qnt
	from CellsContents CC with (nolock) 
	where #TrafficsFrames.FrameID = CC.FrameID and #TrafficsFrames.PackingID = 0

-- состояние сбора товаров
declare @cOutputsGoodsState varchar(200)
if @bTrafficsGoodsExists = 0 and @bTrafficsFramesExists = 0 begin 
	set @cOutputsGoodsState = 'Нет ни одного перемещения коробок/штук и ни одной транспортировки паллет'
end
else begin 
	if @bTrafficsGoodsNotConfirmed = 0 and @bTrafficsFramesNotConfirmed = 0 begin 
		if @bTrafficsGoodsExists = 1 and @bTrafficsFramesExists = 1 begin
			set @cOutputsGoodsState = 'Все перемещения коробок/штук и транспортировки паллет выполнены'
		end
		else begin
			if @bTrafficsGoodsExists = 1 begin
				set @cOutputsGoodsState = 'Все перемещения коробок/штук выполнены'
			end
			else begin
				set @cOutputsGoodsState = 'Все транспортировки паллет выполнены'
			end
		end 
	end 
	else begin 
		if @bTrafficsGoodsNotConfirmed = 1 and @bTrafficsFramesNotConfirmed = 1 begin 
			set @cOutputsGoodsState = 'Не все перемещения коробок/штук и транспортировки паллет выполнены'
		end
		else begin 
			if @bTrafficsGoodsNotConfirmed = 1 begin 
				set @cOutputsGoodsState = 'Нe все перемещения коробок/штук выполнены'
			end
			else begin
				set @cOutputsGoodsState = 'Не все транспортировки паллет выполнены'
			end
		end 
	end
end 

-- всего собрано (по OutputsItems)
select  ID as OutputGoodID, 
		PackingID, 
		QntWished, QntSelected, QntOdd, 
		IsExists,  
		cast(0 as decimal(15, 3)) as Qnt, 
		cast('' as varchar(100)) as DateValidProblem, 
		cast(1 as bit) as FullPicked, 
		cast('' as varchar(100))  as FramesCntText,
		cast('' as varchar(1000)) as FramesText, 
		cast('' as varchar(100))  as BoxesCntText,
		cast('' as varchar(100))  as BoxesText 
	into #Picked 
	from #OutputsGoods
/*
update #Picked 
	set Qnt = X.Qnt 
	from (select OI.PackingID, sum(OI.Qnt) as Qnt
			from #OutputsItems OI 
			group by OI.PackingID) X
	where #Picked.PackingID = X.PackingID 
*/
update #Picked set Qnt = X.Qnt 
	from (select OI.OutputGoodID, sum(OI.Qnt) as Qnt
			from #OutputsItems OI 
			group by OI.OutputGoodID) X
	where #Picked.OutputGoodID = X.OutputGoodID

declare @nPackingID int, @nOutputGoodID int,
		@nInBox decimal(12, 3), @bWeighting bit, @nNetto decimal(12, 3), 
		@bFullPicked bit, @nAllPackingQnt decimal(15, 3), 
		@nFrameID int, @nAllQntInFrames decimal(15, 3), 
		@nQntInFrame decimal(15, 3), 
		@nBoxInFrame int, @nRestQntInFrame decimal(15, 3), 
		@nBoxInBoxes int, @nRestQntInBoxes decimal(15, 3), 
		@nFramesCnt int, 
		@cFramesCntText varchar(max), @cFramesText varchar(max),  
		@cBoxesCntText varchar(max), @cBoxesText varchar(max), 
		@nQntWished decimal(15, 3), @nQntSelected decimal(15, 3), @nQntOdd decimal(15, 3), @bIsExists bit
declare C_ cursor for 
	select PackingID, OutputGoodID, QntWished, QntSelected, QntOdd, IsExists, Qnt 
		from #Picked
open C_ 
fetch next from C_ into @nPackingID, @nOutputGoodID, @nQntWished, @nQntSelected, @nQntOdd, @bIsExists, @nAllPackingQnt 

while @@fetch_status = 0 begin
	set @bFullPicked = 1
	if exists (select ID 
				from #TrafficsGoods 
				where OutputGoodID = @nOutputGoodID and DateConfirm is Null) begin
		set @bFullPicked = 0
	end
	else begin 
		if exists (select ID 
					from #TrafficsFrames 
					where OutputGoodID = @nOutputGoodID and DateConfirm is Null) begin
			set @bFullPicked = 0
		end
		else begin 
			if not exists (select ID 
							from #TrafficsGoods 
							where OutputGoodID = @nOutputGoodID
						) and 
			   not exists (select ID 
							from #TrafficsFrames 
							where OutputGoodID = @nOutputGoodID
						) begin
				set @bFullPicked = 0
			end 
		end
	end
	update #Picked set FullPicked = @bFullPicked 
		where OutputGoodID = @nOutputGoodID

	-- контейнеры
	select  @nFramesCnt = 0, @nAllQntInFrames = 0, 
			@cFramesCntText = '', @cFramesText = '', 
			@cBoxesCntText = '', @cBoxesText = ''
	if exists (select ID 
				from #TrafficsFrames 
				where OutputGoodID = @nOutputGoodID
			) begin
		select @nInBox = P.InBox, @bWeighting = G.Weighting, @nNetto = G.Netto 
			from Packings P with (nolock) 
			inner join Goods G with (nolock) on P.GoodID = G.ID
			where P.ID = IsNull(@nPackingID, 0)

		declare F_ cursor for 
			select FrameID, Qnt from #TrafficsFrames 
					where OutputGoodID = @nOutputGoodID and CellTargetID = @nCellTargetID 
					order by 1
		open F_ 
		fetch next from F_ into @nFrameID, @nQntInFrame
		
		while @@fetch_status = 0 begin
			select  @nFramesCnt = @nFramesCnt + 1, 
					@nAllQntInFrames = @nAllQntInFrames + @nQntInFrame
			select @cFramesText = @cFramesText + ' ' + rtrim(ltrim(str(@nFrameID))) + ': '

			if @bWeighting = 0 begin
				-- штучный товар
				select @nBoxInFrame = Floor(@nQntInFrame / @nInBox)
				select @nRestQntInFrame = @nQntInFrame - @nBoxInFrame * @nInBox

				if @nBoxInFrame > 0 
					select @cFramesText = @cFramesText + rtrim(ltrim(str(@nBoxInFrame))) + ' кор.'
				if @nBoxInFrame > 0 and @nRestQntInFrame > 0  
					select @cFramesText = @cFramesText + ' + '
				if @nRestQntInFrame > 0  
					select @cFramesText = @cFramesText + rtrim(ltrim(str(@nRestQntInFrame))) + ' шт.'
			end 
			else begin 
				-- весовой товар
				select @cFramesText = @cFramesText + rtrim(ltrim(str(@nQntInFrame * @nNetto))) + ' кг'
			end 

			select @cFramesText = @cFramesText + ', '
			fetch next from F_ into @nFrameID, @nQntInFrame
		end
		
		close F_ 
		deallocate F_ 

		select @cFramesCntText = 'В т.ч. паллеты (' + rtrim(ltrim(str(@nFramesCnt))) + '):'
		select @cFramesText = rtrim(ltrim(@cFramesText))
		if right(@cFramesText, 1) = ','
			select @cFramesText = left(@cFramesText, len(@cFramesText) - 1)

		-- переделать на анализ QntOdd вместо QntWished
		if @nAllQntInFrames <> 0 and @nAllQntInFrames <> @nQntWished begin
			if @bWeighting = 0 begin
				-- штучный товар
				select @nBoxInBoxes = Floor((@nQntWished - @nAllQntInFrames) / @nInBox)
				select @nRestQntInBoxes = (@nQntWished - @nAllQntInFrames) - @nBoxInBoxes * @nInBox

				if @nBoxInBoxes > 0 
					select @cBoxesText = @cBoxesText + rtrim(ltrim(str(@nBoxInBoxes))) + ' кор.'
				if @nBoxInBoxes > 0 and @nRestQntInBoxes > 0  
					select @cBoxesText = @cBoxesText + ' + '
				if @nRestQntInBoxes > 0  
					select @cBoxesText = @cBoxesText + rtrim(ltrim(str(@nRestQntInBoxes))) + ' шт.'
			end
			else begin
				select @cBoxesText = @cBoxesText + rtrim(ltrim(str(@nQntWished - @nAllQntInFrames))) + ' кг'
			end 
			if @cBoxesText > '' 
				select @cBoxesCntText = 'Коробки:'
		end
	end	

	if @cFramesText is not Null and @cFramesText > ''
		update #Picked 
			set FramesCntText = @cFramesCntText, 
				FramesText = @cFramesText,
				BoxesCntText = @cBoxesCntText, 
				BoxesText = @cBoxesText
			where OutputGoodID = @nOutputGoodID

	-- проблемы со сроком годности
	if @nQntWished > @nQntSelected and @bIsExists = 1 begin
		update #Picked 
			set DateValidProblem = 'Товар не был подобран по сроку годности'
			where OutputGoodID = @nOutputGoodID
	end

	fetch next from C_ into @nPackingID, @nOutputGoodID, @nQntWished, @nQntSelected, @nQntOdd, @bIsExists, @nAllPackingQnt 
end

close C_ 
deallocate C_ 

declare @nOwnerID int, @nGoodStateID int, @bSeparatePicking bit
select @nOwnerID = OwnerID, @nGoodStateID = GoodStateID 
	from Outputs with (nolock) 
	where ID = IsNull(@nOutputID, 0)
select @bSeparatePicking = SeparatePicking 
	from Partners with (nolock) 
	where ID = IsNull(@nOwnerID, 0)
if @bSeparatePicking = 0 set @nOwnerID = Null

-- соотв. ячейки пикинга
select	ID as OutputGoodID, 
		.dbo.GetPackingPickingCellID(PackingID, @nOwnerID, @nGoodStateID) as CellID 
	into #TableCells 
	from OutputsGoods with (nolock) 
	where OutputID = @nOutputID

select  OG.ID, OG.ID as OutputGoodID, 
		OG.OutputID, 
		@cOutputsGoodsState as OutputsGoodsState, 
		OG.PackingID, P.GoodID, 
		OG.QntWished, OG.QntSelected, OG.QntConfirmed, OG.QntOdd, 
		OG.QntSelected - OG.QntWished as QntSelDiff, 
		OG.QntConfirmed - OG.QntWished as QntDiff, 
		OG.QntWished / P.InBox as BoxWished, 
		cast(OG.QntWished / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished, 
		OG.QntSelected / P.InBox as BoxSelected, 
		cast(OG.QntSelected / P.InBox / P.BoxInPal as decimal(12, 4)) as PalSelected, 
		OG.QntConfirmed / P.InBox as BoxConfirmed, 
		cast(OG.QntConfirmed / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
		OG.QntOdd / P.InBox as BoxOdd, 
		cast(OG.QntOdd / P.InBox / P.BoxInPal as decimal(12, 4)) as PalOdd, 
		(OG.QntSelected - OG.QntWished) / P.InBox as BoxSelDiff, 
		cast((OG.QntSelected - OG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalSelDiff, 
		(OG.QntConfirmed - OG.QntWished) / P.InBox as BoxDiff, 
		cast((OG.QntConfirmed - OG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalDiff, 
		IsNull(case when TG.FullPicked = 1 then TG.Qnt else OG.QntSelected end, 0) as QntPicked, 
		IsNull(case when TG.FullPicked = 1 then TG.Qnt else OG.QntSelected end, 0) / P.InBox as BoxPicked, 
		cast(IsNull(case when TG.FullPicked = 1 then TG.Qnt else OG.QntSelected end, 0) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalPicked, 
		OG.DateValid, OG.IsExists, OG.GoodStateID, 

		OG.ERPIndex, OG.ERPNote, 

		dbo.GetCellsContentsQnt(OG.PackingID, @nGoodStateID, @nOwnerID, 1, 1) as CCQnt, 

		P.InBox, P.BoxInPal, P.BoxInRow, 

		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, G.HalfStuff, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
		P.BoxHeight, 
		G.Netto, 
		
		cast((case when G.Weighting = 1 or floor(1.00 * P.InBox) != (1.00 * P.InBox) then 1 else 0 end) as bit) as PrintDecimals, 

		TG.FramesCntText, TG.FramesText, 
		TG.BoxesCntText, TG.BoxesText, 
		TG.DateValidProblem, 
		
		C.Address, C.Rank, C.CLine, 
		C.StoreZoneID, IsNull(SZ.Name, '_неизвестен') as StoreZoneName 
	
	from OutputsGoods OG with (nolock) 
	inner join Packings P with (nolock) on OG.PackingID = P.ID 
	inner join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	left join #Picked TG on OG.ID = TG.OutputGoodID 
	left join #TableCells TX on OG.ID = TX.OutputGoodID 
	left join Cells C with (nolock) on TX.CellID = C.ID 
	left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	where OutputID = IsNull(@nOutputID, 0) 
	order by G.Alias, OG.ID
return