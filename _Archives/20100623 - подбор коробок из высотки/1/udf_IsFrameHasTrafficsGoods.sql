SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IsFrameHasTrafficsGoods] 
(
	@nFrameID int
)
RETURNS bit
-- Есть ли неподтвержденные операции коробочных перемещений из этого контейнера?
AS
BEGIN
	return (case when exists (select ID 
								from TrafficsGoods with (nolock)
								where FrameID = @nFrameID and DateConfirm is Null)
			 then 1 
			 else 0 
		end)
END