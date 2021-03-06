SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_TrafficsGoodsDelete]
	@nTrafficID		int = 0, 
	@nError			int = 0 output,
	@cErrorText		varchar(200) = '' output 
AS
-- удаление задания на перемещение коробок/штук 

-- есть задание?
if not exists(select ID from TrafficsGoods where ID = @nTrafficID) begin
	select	@nError = -1, 
			@cErrorText = 'Не найдено задание на перемещение коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + '...'
	raiserror(@cErrorText, 16, 1)
	return
end 

-- не выполнено? не выполняется?
declare @dDateConfirm datetime, @dDateAccept datetime, 
		@nInputID int, @nOutputID int, @nOutputGoodID int, @nFromFrameID int, 
		@nOwnerID int, @nGoodStateID int, 
		@nPackingID int, @nQnt decimal(15,3) 
select	@dDateConfirm = DateConfirm, @dDateAccept = DateAccept, 
		@nInputID = InputID, @nOutputID = OutputID, @nOutputGoodID = OutputGoodID,
		@nFromFrameID = FromFrameID,  
		@nOwnerID = OwnerID, @nGoodStateID = GoodStateID, 
		@nPackingID = PackingID, @nQnt = QntWished 
	from	TrafficsGoods with (nolock) 
	where	ID = @nTrafficID
if @dDateConfirm is not Null begin
	select	@nError = -2, 
			@cErrorText = 'Задание на перемещение коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' уже выполнено...'
	raiserror(@cErrorText, 16, 1)
	return
end
if @dDateAccept is not Null begin
	select	@nError = -2, 
			@cErrorText = 'Задание на перемещение коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' уже выполняется...'
	raiserror(@cErrorText, 16, 1)
	return
end

begin transaction
	-- удаление данных
	delete	TrafficsGoods 
		where	ID = @nTrafficID
	if @@Error > 0 goto ERR
	
	-- связанный приход
	if @nInputID is not Null begin
		-- удаление составляющей прихода
		delete InputsItems 
			where InputID = @nOutputID and 
					PackingID = @nPackingID and 
					FrameID is null and 
					Qnt = @nQnt
		if @@Error > 0 goto ERR
	end
	
	-- связанный расход
	if @nOutputID is not Null begin
		-- удаление составляющей расхода
		delete OutputsItems 
			where OutputGoodID = @nOutputGoodID 
		if @@Error > 0 goto ERR
		
		update OutputsGoods 
			set QntSelected = QntSelected - @nQnt 
			where ID = @nOutputGoodID 
		if @@Error > 0 goto ERR
		
		exec up_OutputsTrafficsCheck @nOutputID
	end
	
	-- связанный контейнер
	if @nFromFrameID is not Null begin
		declare @bForStorage bit, @bForInputs bit, @bForOutputs bit 
		select top 1 @bForStorage = SZT.ForStorage, 
				@bForInputs = SZT.ForInputs, @bForOutputs = SZT.ForOutputs 
			from CellsContents CC 
			inner join Cells C on CC.CellID = C.ID
			inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID
			where CC.FrameID = isNull(@nFromFrameID, 0)
		update Frames 
			set HasTraffic = 0, 
			State = case when @bForStorage = 1 then 'S'
						 when @bForInputs  = 1 then 'I'
						 when @bForOutputs = 1 then 'O'
					end 
			where ID = isNull(@nFromFrameID, 0)
		if @@Error > 0 goto ERR
	end	

commit transaction
return

ERR:
rollback transaction
return