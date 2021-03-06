SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_ReportCellsStateInZones]
	@cZonesIdList	varchar(256), 
	@bIsShowDetail	bit = 0
as
set nocount on

declare @cSql VarChar(MAX)
if @bIsShowDetail = 1
	set @cSql =
		'select max( SZ.Name) as ZoneName, 
				max(C.Address) as Address, 
				max(G.Alias) GoodName, 
				max(isnull(C.MaxPalletQnt, SZ.MaxPalletQnt)) - max(X.Qnt) as QntFreeInCell, 
				max(X.Qnt) as QntFillInCell, 
				count(*) as QntFillByGood, 
				max(G.ABCRank) as ABCRank 
			from CellsContents CS with (nolock) 
			inner join Cells C with (nolock) on C.ID = CS.CellID 
			inner join StoresZones with (nolock) SZ on C.StoreZoneID = SZ.ID 
			inner join Packings P with (nolock) on P.ID = CS.PackingID 
			inner join Goods G with (nolock) on G.ID = P.GoodID 
			inner join (select CellID, count(*) as Qnt 
							from CellsContents CS with (nolock) 
							inner join Cells C with (nolock) on C.ID =  CS.CellID 
							inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
						where SZ.ID in (' +  @cZonesIdList + ') and FrameID is not Null group by CellID) X on X.CellID = CS.CellID 
			where SZ.ID in (' + @cZonesIdList + ') and FrameID is not Null 
			group by SZ.ID, CS.CellID, CS.PackingID 
			order by 1,2,7'
else
	set @cSql =
		'select max(C.Address) as Address, 
				max( SZ.Name) as ZoneName, 
				max(isnull(C.MaxPalletQnt, SZ.MaxPalletQnt)) - count(*) as QntFreeInCell, 
				count(*) as QntFillInCell, 
				max(isnull(C.MaxPalletQnt, SZ.MaxPalletQnt)) as QntSumInCell 
			from CellsContents CC with (nolock) 
			inner join Cells C with (nolock) on C.ID = CC.CellID 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			where  SZ.ID in (' + @cZonesIdList + ') and FrameID is not Null 
			group by CC.CellID 
			order by 1'
execute (@cSql)
return