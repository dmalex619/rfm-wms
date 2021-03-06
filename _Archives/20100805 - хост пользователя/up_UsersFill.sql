SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_UsersFill]
	@nID			int				= Null, 
	@cIDList		varchar(max)	= Null, -- список _Users.ID (через ,) 
	@cBarCode		varchar(100)	= Null, -- штрих-код пользователя (контекст)
	@bActual		bit				= Null, -- актуально?
	@cBrigadesList	varchar(max)	= Null  -- список бригад (через,)
AS

set nocount on

select	@cIDList		= ',' + replace(@cIDList,		' ', '') + ',', 
		@cBrigadesList	= ',' + replace(@cBrigadesList, ' ', '') + ','

select	U.ID, U.ID as UserID, 
		U.Name, U.BarCode,
		U.Password, U.Alias, 
		case when isNull(U.LocPath, '') > '' and right(rtrim(U.LocPath), 1) <> '\' 
			 then rtrim(U.LocPath) + '\' else U.LocPath end as LocPath, 
		case when isNull(U.NetPath, '') > '' and right(rtrim(U.NetPath), 1) <> '\' 
			 then rtrim(U.NetPath) + '\' else U.NetPath end as NetPath, 
		U.Photo, U.IsAdmin, U.Actual, 
		U.BrigadeID, B.Name as BrigadeName, 
		U.HostID, H.Name as HostName, 
		U.ERPCode 
	from	_Users U with (nolock) 
	left join Brigades B with (nolock) on U.BrigadeID = B.ID 
	left join Hosts H with (nolock) on U.HostID = H.ID 
	where	(@nID is not Null and @nID = U.ID) 
		or 
			(@nID is Null and 
			 (@cIDList is Null or 
				charindex(',' + ltrim(str(U.ID)) + ',', @cIDList) > 0) and 
			 (@cBarCode is Null or 
				charindex(@cBarCode, U.BarCode) > 0) and 
			 (@bActual is Null or 
				U.Actual = @bActual) and 
			 (@cBrigadesList is Null or 
				charindex(',' + ltrim(str(U.BrigadeID)) + ',', @cBrigadesList) > 0) 
			) 
	order by U.Name, U.ID
return