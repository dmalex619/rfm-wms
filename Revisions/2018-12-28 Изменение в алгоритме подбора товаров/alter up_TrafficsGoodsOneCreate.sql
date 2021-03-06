SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_TrafficsGoodsOneCreate]
	@nOwnerID		int,			-- владелец
	@nGoodStateID	int,			-- состояние товара
	@nPackingID		int,			-- товар
	@nQntWished		decimal(18, 3),	-- количество
	@dDateValid		smalldatetime,	-- срок годности
	@nSourceCellID	int,			-- исходная ячейка
	@nTargetCellID	int,			-- конечная ячейка
	@nFrameID		int,			-- контейнер, из которого изымается товар
	@nInputID		int = Null,		-- код прихода
	@nOutputID		int = Null,		-- код расхода    надо убрать
	@nOutputGoodID	int = Null,		-- код товара расхода   
	@cNote			varchar(250),	-- комментарий: код заказа 
	@nError			int output,
	@nTrafficID     int = Null output 
AS

set nocount on

declare @nDefaultPriority int, @nRowCount bigint
set @nDefaultPriority = 5 -- взять из _Settings 

if @nOutputGoodID is not Null begin
	if exists (select object_id from sys.indexes where name = 'IX_TrafficsGoods_DateConfirm')
		select top 1 @nTrafficID = ID 
			from TrafficsGoods with (index(IX_TrafficsGoods_DateConfirm))
			where	DateConfirm		is Null and 
					OutputGoodID	= @nOutputGoodID and 
					PackingID		= @nPackingID and
					CellTargetID	= @nTargetCellID and
					CellSourceID	= @nSourceCellID
	else
		select top 1 @nTrafficID = ID 
			from TrafficsGoods 
			where	DateConfirm		is Null and 
					OutputGoodID	= @nOutputGoodID and 
					PackingID		= @nPackingID and
					CellTargetID	= @nTargetCellID and
					CellSourceID	= @nSourceCellID
					
	select @nError = @@Error, @nRowCount = @@RowCount
	if @nRowCount = 0 set @nTrafficID = Null
	if @nError = 0 and @nTrafficID is not Null
			update TrafficsGoods set QntWished = QntWished + @nQntWished 
				where ID = @nTrafficID
end

if @nTrafficID is Null
	insert TrafficsGoods (OwnerID, GoodStateID, 
		PackingID, QntWished, DateValid, 
		CellSourceID, CellTargetID, FrameID, 
		InputID, OutputID, OutputGoodID, DateBirth, Priority, Note) 
	values (@nOwnerID, @nGoodStateID, 
			@nPackingID, @nQntWished, @dDateValid, 
 			@nSourceCellID, @nTargetCellID, @nFrameID, 
			@nInputID, @nOutputID, @nOutputGoodID, getdate(), @nDefaultPriority, @cNote)
	select @nError = @@Error, @nTrafficID = @@Identity
return