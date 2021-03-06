SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellOneSelection]
	@nPacking		int, 
	@nSourceCell	int = Null output,
	@nOwner			int = Null, 
	@nGoodStateID	int = Null,
	@cPreviousRill	varchar(10) = Null,
	@dDateValid		smallDateTime  = Null
AS

set nocount on

declare @cCommand nvarchar(max)
declare @cOwnerTest varchar(150), @cPreviousRillTest varchar(250), @cDateValidTest varchar(100)
select  @cOwnerTest =  case when @nOwner is null then  ' and CC.OwnerID is Null ' else ' and CC.OwnerID = ' + cast(@nOwner as Varchar(10)) end
select  @cPreviousRillTest = case when @cPreviousRill is Null then  '' 
	else ' and IsNull(C.CBuilding, "") + IsNull(C.CLine, "") + IsNull(C.CRack, "") + IsNull(C.CLevel, "") = "' + @cPreviousRill + '"' end
select @cDateValidTest = case when @dDateValid is Null then '' 
	else ' and datediff(day, "' + convert(char(10), @dDateValid, 112) + '", CC.DateValid) >= 0 ' end

create table #_Cells (CellID int, Cnt int, Qnt decimal(15,3))
create index #_IX_Cells_CellID on #_Cells (CellID)

set @cCommand = ' insert #_Cells ' +
	'select CC.CellID, count(CC.FrameID) as Cnt, min(CC.Qnt) as Qnt ' + 
	'from CellsContents CC with (nolock) ' +
	'inner join Frames F with (nolock) on F.ID = CC.FrameID ' +
	'inner join Cells C with (nolock) on C.ID = CC.CellID ' +
	'inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID ' +
	'inner join StoresZonesTypes SZT with (nolock) on SZT.ID = SZ.StoreZoneTypeID ' +	
	'where CC.PackingID = ' + cast(@nPacking as varchar(10)) + 
		' and CC.GoodStateID = ' + cast(@nGoodStateID as varchar(10)) +  
		@cOwnerTest +  
		' and F.State in ("S", "") and F.Locked = 0 ' + 
		' and C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 ' +
		' and SZT.ForStorage = 1 and SZT.ForPicking = 0 ' +
		' group by CC.CellID '
set @cCommand = replace (@cCommand, char(34), char(39))
exec (@cCommand)

if not exists (select * from #_Cells) begin
	set @nSourceCell = -1
	return
end

select @nSourceCell = Null, @cCommand = ''
select @cCommand = ' select top 1 @nSourceCell = C.ID ' +
	'from Cells C with (nolock) ' +
	'inner join #_Cells _C on _C.CellID = C.ID ' +
	'inner join CellsContents CC with (nolock) on C.ID = CC.CellID ' +
	'inner join Frames F with (nolock) on F.ID = CC.FrameID ' +	
	'where CC.PackingID = ' + cast(@nPacking  as varchar(10)) + 
		' and CC.GoodStateID = ' + cast(@nGoodStateID as varchar(10)) + 
		@cOwnerTest +  
		' and F.State in ("S", "") and F.Locked = 0 ' + 
		@cPreviousRillTest + 
		@cDateValidTest + 
		' order by CC.DateValid, _C.Cnt, _C.Qnt ' 
set @cCommand = replace (@cCommand, char(34), char(39))

exec sp_executesql @cCommand, N'@nSourceCell int out', @nSourceCell = @nSourceCell out
if @nSourceCell is Null and @dDateValid is not Null
	set @nSourceCell = -2
return