SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_OutputsGoodsTrafficsFramesCreate]
	@nOutputGoodID	int,    
	@nFrameID		int,
	@nError			int	= 0 output,
	@cErrorText		varchar(200) = '' output 
AS

set nocount on

declare @nPriority tinyint
set @nPriority	= 5

declare @nOutputID int, @nPackingID int, @nGoodStateID int
select @nOutputID = OutputID, @nPackingID = PackingID, @nGoodStateID = GoodStateID 
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

-- документарные остатки 
update OutputsGoods 
	set QntOdd = IsNull(dbo.GetOwnersOdds(@nPackingID, @nOwnerID_Odd, @nGoodStateID), 0) 
	where ID = IsNull(@nOutputGoodID, 0)

declare @nQntWished decimal(15,3), @nQntSelected decimal(15,3), @dDateValid smalldatetime
select @nQntWished = QntWished, @nQntSelected = QntSelected, @dDateValid = DateValid 
	from OutputsGoods 
	where ID = IsNull(@nOutputGoodID, 0)

declare @nQnt decimal(15,3), @nSourceCellID int
select @nQnt = sum(Qnt), @nSourceCellID = max(CellID), @dDateValid = min(DateValid) 
	from CellsContents 
	where FrameID = @nFrameID and PackingID = @nPackingID

declare @nTrafficFrameID int, @cNote varchar(1000)
select @cNote = 'Подбор контейнера вручную для расхода с кодом ' + ltrim(str(@nOutputID))
exec up_TrafficsFramesOneCreate @nFrameID, @nSourceCellID, @nTargetCellID, 
	@nPriority, Null, @nOutputID, @nOutputGoodID, 1, @cNote, 
	@nError output, @nTrafficFrameID output
if @nError > 0 or @nTrafficFrameID is Null begin
	select @cErrorText = 'Ошибка при создании перемещения контейнера...'
	RaisError(@cErrorText, 11, 1)
	return
end

update OutputsGoods set QntSelected = QntSelected + @nQnt 
	where ID = IsNull(@nOutputGoodID, 0)

if exists (select ID from Outputs 
			where ID = IsNull(@nOutputID, 0) and DateSelect is Null) begin
	update Outputs set DateSelect = GetDate() 
		where ID = IsNull(@nOutputID, 0)
end
return