SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_OutputsGoodsTrafficsGoodsFromFrameCreate]
	@nOutputGoodID	int,    
	@nFrameID		int,
	@nPackingID		int, 
	@nQnt			decimal, 
	@nError			int	= 0 output,
	@cErrorText		varchar(200) = '' output 
AS

set nocount on

declare @nPriority tinyint
set @nPriority	= 5

declare @nOutputID int, @nGoodStateID int, 
		@nQntSelected decimal(15,3), @dDateValid smalldatetime
select @nOutputID = OutputID, @nGoodStateID = GoodStateID, 
		@nQntSelected = QntSelected, @dDateValid = DateValid  
	from OutputsGoods 
	where ID = IsNull(@nOutputGoodID, 0)

declare @nTargetCellID int, @nOwnerID int, @nOwnerID_Odd int, @bSeparatePicking bit
select @nTargetCellID = CellID, @nOwnerID = OwnerID, @nOwnerID_Odd = OwnerID 
	from Outputs 
	where ID = IsNull(@nOutputID, 0)

select @bSeparatePicking = SeparatePicking 
	from Partners 
	where ID = IsNull(@nOwnerID, 0)
if @bSeparatePicking = 0
	set @nOwnerID = Null

if not exists(select ID from Frames 
				where ID = @nFrameID and 
					Actual = 1 and 
					State = 'S' and 
					GoodStateID = @nGoodStateID and 
					IsNull(OwnerID,-1) = IsNull(@nOwnerID,-1)) begin
	select	@nError = -1, 
			@cErrorText = 'Контейнер не может быть перемещен...'
	RaisError(@cErrorText, 11, 1)
	return
end

-- имеется в контейнере
declare @nQntInFrame decimal(12, 3), @nQntInTrafficsGoods decimal(12, 3), @nSourceCellID int
select @nQntInFrame = sum(Qnt), @nSourceCellID = max(CellID), @dDateValid = min(DateValid) 
	from CellsContents 
	where FrameID = @nFrameID and 
		PackingID = @nPackingID
select @nQntInTrafficsGoods = dbo.GetFrameQntInTrafficsGoods(@nFrameID)		
if isnull(@nQntInFrame, 0) - isnull(@nQntInTrafficsGoods, 0) < @nQnt begin
	select	@nError = -2, 
			@cErrorText = 'В контейнере недостаточно товара для перемещения...'
	RaisError(@cErrorText, 11, 1)
	return
end

-- документарные остатки 
update OutputsGoods 
	set QntOdd = IsNull(dbo.GetOwnersOdds(@nPackingID, @nOwnerID_Odd, @nGoodStateID), 0) 
	where ID = IsNull(@nOutputGoodID, 0)

declare @nTrafficGoodID int, @cNote varchar(1000)
select @cNote = 'Подбор контейнера вручную для расхода с кодом ' + ltrim(str(@nOutputID))
exec up_TrafficsGoodsOneCreate  @nOwnerID, @nGoodStateID, 
		@nPackingID, @nQnt, Null, /*@dDateValid, */
		@nSourceCellID,	@nTargetCellID, 
		Null, @nOutputID, @nOutputGoodID, 
		@cNote, 
		@nError	output, @nTrafficGoodID output
if @nError > 0 or @nTrafficGoodID is Null begin
	select @cErrorText = 'Ошибка при создании перемещения коробок/штук...'
	RaisError(@cErrorText, 11, 1)
	return
end

update TrafficsGoods 
	set FrameID = @nFrameID	
	where ID = @nTrafficGoodID 
	
update OutputsGoods set QntSelected = QntSelected + @nQnt 
	where ID = @nOutputGoodID

if exists (select ID from Outputs 
			where ID = IsNull(@nOutputID, 0) and DateSelect is Null) begin
	update Outputs set DateSelect = GetDate() 
		where ID = @nOutputID
end
return