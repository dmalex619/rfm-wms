set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_FramesContentsFill]
	@nFrameContentID	int = Null, -- код записи о содержимом контейнера
	@nFrameID			int = Null, -- код записи о контейнере
	@nGoodID			int = Null, -- код товара
	@nPackingID			int = Null, -- код упаковки
	@dDateValidLess		smalldatetime = Null -- срок годности (дата), не более 
AS
BEGIN

select	FC.ID, FC.ID as FrameContentID, 
		F.ID as FrameID, F.BarCode, 
		F.OwnerID, Ow.Name as OwnerName, 
		F.GoodStateID, GS.Name as GoodStateName, 
		F.State as FrameState, 
		G.ID as GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode,
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Name + ': ' + cast(P.InBox as varchar(30)) as PackingName, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal
	from FramesContents FC
	inner join Frames F on FC.FrameID = F.ID
	left join Partners Ow on F.OwnerID = OW.ID
	left join GoodsStates GS on F.GoodStateID = GS.ID
	left join Packings P on FC.PackingID = P.Id 
	left join Goods G on P.GoodID = G.Id 
	left join GoodsGroups GG on G.GoodGroupID = GG.Id 
	left join GoodsBrands GB on G.GoodBrandID = GB.Id 
	where	(
			(@nFrameContentID is not Null or @nFrameID is not Null 
			) and 
			(@nFrameContentID is Null or 
				FC.ID = @nFrameContentID) and
			(@nFrameID is Null or 
				F.ID = @nFrameID) 
			)
		or 
			(
			  @nFrameContentID is Null and @nFrameID is Null and 
			 (@nGoodID is Null or 
				G.ID = @nGoodID) and 
			 (@nPackingID is Null or 
				P.ID = @nPackingID) and 
			 (@dDateValidLess is Null or 
				datediff(day, FC.DateValid, @dDateValidLess) >=0) 
			)
	order by F.BarCode, G.Alias, FC.ID
END
