SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_ReportRillsDirectScheme]
	@nOutputID int = 0
as
set nocount on

if object_id('tempdb.dbo.#RillsDirect') is not null
	drop table #RillsDirect
create table #RillsDirect (Address varchar(25),
	F1 tinyint, F2 tinyint, F3 tinyint, F4 tinyint, F5 tinyint,
	F6 tinyint,	F7 tinyint, F8 tinyint, F9 tinyint,	F10 tinyint,
	F11 tinyint, F12 tinyint, F13 tinyint, F14 tinyint, F15 tinyint,
	F16 tinyint, F17 tinyint, F18 tinyint, F19 tinyint, F20 tinyint, F21 tinyint)

declare @cAddress varchar(25), @nByOrder int, @bIsOut bit
declare @cSql varchar(256), @cGroupAddress varchar(25), @nRecno int
select @cSql = '', @cGroupAddress = '', @nRecno = 0

declare _RillsDirect cursor for 
	select C.Address, CC.ByOrder, 
		cast(case when TF.FrameID is not Null then 1 else 0 end as bit) as ForOut 
		from CellsContents CC with (nolock) 
			inner join (select distinct TF.CellSourceID 
							from TrafficsFrames TF with (nolock) 
							where	TF.OutputID = @nOutputID and 
									TF.DateConfirm is Null) X on X.CellSourceID = CC.CellID 
			inner join Cells C with (nolock) on C.ID = CC.CellID 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
			left outer join TrafficsFrames TF with (nolock) on CC.FrameID = TF.FrameID and TF.OutputID = @nOutputID and TF.DateConfirm is Null 
		where  SZT.ShortCode = 'RILLDIRECT' 
		order by C.Address, CC.ByOrder
open _RillsDirect
fetch next from _RillsDirect into @cAddress, @nByOrder, @bIsOut
while @@fetch_status = 0 begin
	if not @cGroupAddress = @cAddress begin
		set @cGroupAddress = @cAddress
		insert into #RillsDirect (Address, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, F13, F14, F15, F16, F17, F18, F19, F20, F21) 
			values (@cGroupAddress, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
		set @nRecno = 1
	end
	set @cSql = 'update #RillsDirect set F' + ltrim(cast(@nRecno as int)) + ' = ' + (case when @bIsOut = 1 then '2' else '1' end) + ' where Address = ''' + @cAddress + ''''
	execute (@cSql)
	set @nRecno = @nRecno + 1
	fetch next from _RillsDirect into @cAddress, @nByOrder, @bIsOut
end
close _RillsDirect
deallocate _RillsDirect

select * from #RillsDirect where F1 > 0
return