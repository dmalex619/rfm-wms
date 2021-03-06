SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetFrameQntInTrafficsGoods] 
(
	@nFrameID int
)
RETURNS decimal(12, 3)
-- Подсчет количества товара, изымаемого из контейнера в коробочные перемещения 
-- не конкретного товара, а товара вообще
AS
BEGIN
declare @nQnt decimal(12, 3)
select	@nQnt = sum(QntWished) 
	from TrafficsGoods with (nolock) 
	where FrameID = @nFrameID and DateConfirm is Null
return IsNull(@nQnt, 0)
END