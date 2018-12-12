-- пикинг 3-го склада, кроме неудаленных, но включая блокированные
set nocount on
declare @nID int, @nRank int
set @nRank = 0

declare _Cells cursor for 
	select ID 
		from Cells with (nolock) 
		where Deleted = 0 and StoreZoneID = 24 
		order by Address
open _Cells

fetch next from _Cells into @nID
while @@fetch_status = 0 begin
	set @nRank = @nRank + 1
	print 'Cell ' + str(@nRank)
	update Cells set Rank = @nRank where ID = @nID
	
	fetch next from _Cells into @nID
end

close _Cells
deallocate _Cells
