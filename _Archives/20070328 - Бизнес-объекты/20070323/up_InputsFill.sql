set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsFill]
	@nID				int = Null, 
	@bConfirmed			bit = Null, -- подтвержденные приходы?
	@dDateBeg			smalldatetime = Null, -- дата нач.периода
	@dDateEnd			smalldatetime = Null, -- дата кон.периода
	@cInputsTypesList	varchar(max) = Null, -- список типов приходов (через,)
	@cPartnersList		varchar(max) = Null, -- список поставщиков (через ,)
	@cPartnerContext	varchar(max) = Null, -- контекст названия поставщика
	@cOwnersList		varchar(max) = Null  -- список владельцев (через ,)
AS
BEGIN

	select	@cInputsTypesList = replace(@cInputsTypesList, ' ', ''),
			@cPartnersList = replace(@cPartnersList, ' ', '')

	select	I.ID, I.ID as InputID,
			I.BarCode, 
			I.DateInput, I.DateStart, I.DateConfirm, 
			I.PartnerID, I.OwnerID, I.GoodStateID, I.StoreZoneID, I.CellID, 
			I.UserID, I.DeviceID,  
			I.Note, 
			P.Name as PartnerName, 
			P1.Name as OwnerName, 
			IT.Name as InputTypeName,
			GS.Name as GoodStateName, 
			U.Name as UserName, 
			D.Name as DeviceName, 
			cast(case when DateConfirm is null then 0 else 1 end as bit) as IsConfirmed
		from Inputs I 
		left join Partners P	 on P.ID  = I.PartnerID 
		left join Partners P1    on P1.ID = I.OwnerID
		left join GoodsStates GS on GS.ID = I.GoodStateID
		left join InputsTypes IT on IT.ID = I.InputTypeID
		left join _Users U		 on U.ID  = I.UserID
		left join Devices D		 on D.ID  = I.DeviceID
		where	(@nID is not Null and @nID = I.ID) 
			or 
				(
				  @nId is Null and 
				 (@bConfirmed is Null or 
					@bConfirmed = 1 and I.DateConfirm is not Null or 
					@bConfirmed = 0 and I.DateConfirm is Null) and 
				 (@dDateBeg is Null or 
					datediff(day, @dDateBeg, I.DateInput) >= 0) and 
				 (@dDateEnd is Null or 
					datediff(day, I.DateInput, @dDateEnd) >= 0) and 
				 (@cInputsTypesList is Null or 
					charindex(',' + ltrim(str(I.InputTypeID)) + ',', ',' + @cInputsTypesList + ',') > 0) and 
				 (@cPartnersList is Null or 
					charindex(',' + ltrim(str(I.PartnerID)) + ',', ',' + @cPartnersList + ',') > 0) and 
				 (@cPartnerContext is Null or 
					charindex(upper(@cPartnerContext), upper(P.Name)) > 0) and 
				 (@cOwnersList is Null or 
					charindex(',' + ltrim(str(I.OwnerID)) + ',', ',' + @cOwnersList + ',') > 0)
				)
		order by I.DateInput, P.Name, I.Id
END
