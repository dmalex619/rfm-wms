SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_FillPackingManual_GetTraffics]
	@nCellID	int
AS
-- Получение списка контейнерных трафиков в заданную ячейку

set nocount on

select	C.Address, 
		convert(varchar(10), CC.DateValid, 4) as DateValid, 
		CC.Qnt / P.Inbox as Boxes 
	from TrafficsFrames T with (nolock) 
	inner join Cells C with (nolock) on T.CellSourceID = C.ID 
	inner join CellsContents CC with (nolock) on CC.CellID = C.ID 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	where	T.CellTargetID = @nCellID and T.DateConfirm is Null and 
			T.FrameID not in (select distinct FrameID 
								from TrafficsFrames with (nolock) 
								where DateConfirm is Null and ErrorID is not Null) 
	order by CC.DateValid desc, Boxes
return