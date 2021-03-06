set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_PartnersFill]
	@nID				int = Null, 
	@bActual			bit = Null, 
	@bOwner				bit = Null, -- владелец?
	@bSeparatePicking	bit = Null  -- учет остатков для владельца?
AS
BEGIN

	select	P.ID, P.ID as PartnerID, 
			P.Name, 
			P.Owner, P.SeparatePicking, P.Actual
		from	Partners P
		where	(@nID is not Null and @nID = P.ID) 
			or 
				(
				  @nId is Null and 
				 (@bActual is Null or 
					Actual = @bActual) and 
				 (@bOwner is Null or 
					Owner = @bOwner) and
				 (@bSeparatePicking is Null or 
					SeparatePicking = @bSeparatePicking)
				)
		order by P.Name, P.Id
END
