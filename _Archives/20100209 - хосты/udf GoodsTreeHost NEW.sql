set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go 
CREATE FUNCTION [dbo].[GoodsTreeHost]
(	
	@cMode		varchar(100) = Null, 
	@bActual	bit = Null,
	@cHostsList	varchar(200) = Null
)
RETURNS @tTable table 
	(ID int, 
	 ParentID int, 
	 Name varchar(500), 
	 Actual bit, 
	 Child bit)
AS
BEGIN 
	declare @nShift int
	select	@nShift = 1000000
	
	declare @nHostID int
	select @nHostID = Null
	
	if @cHostsList is not Null begin
		select @cHostsList = .dbo._NormalizeList(@cHostsList)
		if charindex(',', @cHostsList) = 0 begin
			select @nHostID = cast(@cHostsList as int), @cHostsList	= Null
		end
		else begin
			select @cHostsList = ',' + @cHostsList + ','
		end
	end
	
	if charindex('BRAND', upper(IsNull(@cMode, ''))) > 0 begin
		insert @tTable (ID, ParentID, Name, Actual, Child) 
			select ID, GoodBrandID + @nShift, Alias, Actual, 0 
				from Goods with (nolock) 
				where	(IsNull(@bActual, 0) = 0 or Actual = @bActual) and 
						(IsNull(@nHostID, 0) = 0 or HostID = @nHostID) and 
						(IsNull(@cHostsList, '') = '' or charindex(',' + ltrim(rtrim(str(HostID))) + ',', @cHostsList) > 0) 
				order by Alias
		insert @tTable (ID, ParentID, Name, Actual, Child) 
			select ID + @nShift, 0,  Name, Actual, 1 
				from GoodsBrands with (nolock) 
				where	(IsNull(@bActual, 0) = 0 or Actual = @bActual) and 
						(IsNull(@nHostID, 0) = 0 or HostID = @nHostID)and 
						(IsNull(@cHostsList, '') = '' or charindex(',' + ltrim(rtrim(str(HostID))) + ',', @cHostsList) > 0) 
				order by Name
	end
	else begin
		insert @tTable (ID, ParentID, Name, Actual, Child) 
			select ID, GoodGroupID + @nShift, Alias, Actual, 0 
				from Goods with (nolock) 
				where	(IsNull(@bActual, 0) = 0 or Actual = @bActual) and 
						(IsNull(@nHostID, 0) = 0 or HostID = @nHostID) and 
						(IsNull(@cHostsList, '') = '' or charindex(',' + ltrim(rtrim(str(HostID))) + ',', @cHostsList) > 0) 
				order by Alias
		insert @tTable (ID, ParentID, Name, Actual, Child) 
			select ID + @nShift, 0,  Name, Actual, 1 
				from GoodsGroups with (nolock) 
				where	(IsNull(@bActual, 0) = 0 or Actual = @bActual) and 
						(IsNull(@nHostID, 0) = 0 or HostID = @nHostID) and 
						(IsNull(@cHostsList, '') = '' or charindex(',' + ltrim(rtrim(str(HostID))) + ',', @cHostsList) > 0) 
				order by Name
	end
	return
END