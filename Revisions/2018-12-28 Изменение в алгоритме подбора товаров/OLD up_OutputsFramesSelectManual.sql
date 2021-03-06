SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_OutputsFramesSelectManual]
	@nID int,    -- OutputsGoods.ID
	@cCellIDList varchar(500), -- список CellsContents.ID для поиска контейнеров для создания трафиков
	@nError int  = 0 output,
	@cErrorText		varchar(200) = '' output 
AS

set nocount on
declare @nPriority tinyint
set @nPriority	= 5

declare @nOutputID int, @nPackingID int, @nGoodStateID int, @nTrafficID int
declare @nPartnerID int, @cPartnerName varchar(100)
select @nOutputID = OutputID, @nPackingID = PackingID, @nGoodStateID = GoodStateID 
	from OutputsGoods 
	where ID = @nID

declare @nTargetCellID int, @nOwnerID int, @bSeparatePicking bit
select @nTargetCellID = CellID, @nOwnerID = OwnerID, @nPartnerID = PartnerID 
	from Outputs 
	where ID = @nOutputID

select @bSeparatePicking = SeparatePicking 
	from Partners 
	where ID = @nOwnerID
if @bSeparatePicking = 0
	set @nOwnerID = Null

select @cPartnerName = Name
	from Partners 
	where ID = @nPartnerID


declare @nQntWished decimal(15,3), @nQntSelected decimal(15,3), @nQnt decimal(15,3), @dDateValid smalldatetime

select @nQntSelected = QntSelected, @nQntWished = QntWished, @dDateValid = DateValid  
	from OutputsGoods 
	where ID = @nID

declare @nFrameID int, @nSourceCellID int, @nI int, @nPickCellID int, @nCellID int, @bPicked bit


select @nPickCellID = Null, @bPicked = 0 

begin transaction
	while len(@cCellIDList) > 0 begin
		set @nTrafficID = null
		set @nI = charindex(',', @cCellIDList)
		if @nI = 0
			break
		select @nCellID = left(@cCellIDList, @nI - 1), 
			@cCellIDList = right(@cCellIDList, len(@cCellIDList) - @nI)

		select @nFrameID = FrameID 
			from CellsContents 
			where ID = @nCellID
		
		if not exists(select ID from Frames where ID = @nFrameID and State = 'S' 
				and GoodStateID = @nGoodStateID and IsNull(OwnerID,-1) = IsNull(@nOwnerID,-1))
			continue

		select @nQnt = sum(Qnt), @nSourceCellID = max(CellID), @dDateValid = min(DateValid) 
			from CellsContents 
			where PackingID = @nPackingID and FrameID = @nFrameID

		if (@nQnt + @nQntSelected) <= @nQntWished  begin
			set @nQntSelected = @nQntSelected + @nQnt	
			update OutputsGoods 
				set QntSelected = QntSelected + @nQnt 
				where ID = @nID
			exec up_TrafficsFramesOneCreate @nFrameID, @nSourceCellID, @nTargetCellID, 
				@nPriority, Null, @nOutputID, @nID, 1, @cPartnerName, @nError output, @nTrafficID output
			if @nError > 0
				break
			set @bPicked = 1
		end 
		else begin
--  подпитка
			if exists(select top 1 C.ID    -- есть ли пикинг вообще
						from Cells C 
						inner join StoresZones  SZ  on SZ.ID = C.StoreZoneID 
						inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 
						where SZT.ForPicking = 1 and C.Deleted = 0) begin
				select @nPickCellID = C.ID 
					from Cells C 
					inner join StoresZones  SZ  on SZ.ID = C.StoreZoneID 
					inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 	
					where SZT.ForPicking = 1 and 
						C.FixedPackingID = @nPackingID and 
						C.FixedGoodStateID = @nGoodStateID and
						IsNull(C.FixedOwnerID, -1) = IsNull(@nOwnerID, -1) and
						C.Deleted = 0
				if @@RowCount = 0  begin
					-- не нашли жестко закрепленной за товаром ячейки пикинга, ищем динамически закрепленную
					select top 1 @nPickCellID = CellID 
						from CellsContents CC 
						inner join Cells C on C.ID = CC.CellID 
						inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
						inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT .ID and ForPicking = 1 
						where CC.PackingID = @nPackingID and C.Deleted = 0 
						order by C.Address
				end
			end
			if @nPickCellID is Null begin
				select @nError = -1, @cErrorText = 'Товар не найден в пикинге'
				break
			end
			declare @bAutoRecruiting bit
			select  @bAutoRecruiting = IsNull(cast(dbo._SettingsGetValue('bAutoRecruiting') as bit), 0)
			if @bAutoRecruiting = 1 begin
				exec up_TrafficsFramesOneCreate @nFrameID, @nSourceCellID, @nPickCellID,
					@nPriority, Null, Null, Null, 1, 'Подпитка пикинга', @nError output, @nTrafficID output
				if @nError > 0
					break
			end
			select @nQnt = @nQntWished - @nQntSelected 
			exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, @nQnt, @dDateValid,
				@nPickCellID, @nTargetCellID, Null, @nOutputID, @nID, @cPartnerName, @nError output
			if @nError > 0 
				break
			update OutputsGoods 
				set QntSelected = QntWished 
				where ID = @nID
			set @bPicked = 1
			break	
		end
		if @nQntSelected >= @nQntWished begin
			update OutputsGoods 
				set IsExists = 0
				where ID = @nID
			break
		end
	end
	if @nError <> 0 begin
		rollback transaction
		return
	end
	if @bPicked = 0	
		select @nError = -2, @cErrorText = 'Товар не подобран'
	else begin
		if exists ( select top 1 ID from OutputsGoods where ID = @nID and IsExists = 1 )
			select @nError = -3, @cErrorText = 'Товар подобран частично'
	end
commit transaction					
return