SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_InputGetMainData] 
	@nInputID	int
AS
-- Получение общих данных о приходе

set nocount on

select	I.DateInput, I.DateStart, I.DateConfirm, I.HostID, I.Note, 
		I.InputTypeID, IT.Name as InputTypeName, 
		I.PartnerID, P.Name as PartnerName, 
		I.OwnerID, O.Name as OwnerName, 
		I.GoodStateID, GS.Name as GoodStateName 
	from Inputs I with (nolock) 
	inner join InputsTypes IT with (nolock) on I.InputTypeID = IT.ID 
	inner join Partners P with (nolock) on I.PartnerID = P.ID 
	inner join Partners O with (nolock) on I.OwnerID = O.ID 
	inner join GoodsStates GS with (nolock) on I.GoodStateID = GS.ID 
	where I.ID = IsNull(@nInputID, 0)
return