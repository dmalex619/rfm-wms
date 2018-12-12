-- Warm cells on MBK depot (March 2012)
--if db_name() <> 'WMS' return

set nocount on

if object_id('Tempdb.dbo.#CP') is not Null drop table #CP
create table #CP (CLine varchar(1), Racks int, Levels int, Places int)

declare @nMaxID int
select @nMaxID = max(ID) from Cells where len(CBuilding) = 0
delete Cells 
	where ID > @nMaxID

declare @nID int, @nRack int, @nLevel int, @nPlace int
declare @cCLine varchar(1), @nRacks int, @nLevels int, @nPlaces int

-- Высотка
insert StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, 
		NamePrefix, NameSuffix, TemperatureMode, Actual, ERPCode) 
	select 'Высотка теплая', 6, '', 1, '', '', 'W', 1, Null
select @nID = @@identity

truncate table #CP
insert into #CP (CLine, Racks, Levels, Places) select 'A', 10, 2, 3
insert into #CP (CLine, Racks, Levels, Places) select 'B', 9, 1, 3
insert into #CP (CLine, Racks, Levels, Places) select 'C', 9, 1, 3
insert into #CP (CLine, Racks, Levels, Places) select 'D', 9, 1, 3
insert into #CP (CLine, Racks, Levels, Places) select 'E', 4, 2, 3 

declare _P cursor for 
	select CLine, Racks, Levels, Places 
		from #CP 
		order by 1
open _P
fetch next from _P into @cCLine, @nRacks, @nLevels, @nPlaces
while @@fetch_status = 0 begin
	select @nRack = 0, @nLevel = 0, @nPlace = 0
	while @nRack < @nRacks begin
		set @nRack = @nRack + 1
		set @nLevel = 0
		
		while @nLevel < @nLevels begin
			set @nLevel  = @nLevel  + 1
			set @nPlace = 0
			
			while @nPlace < @nPlaces begin
				set @nPlace = @nPlace + 1
				insert Cells (FixedOwnerID, FixedGoodStateID, FixedPackingID, StoreZoneID, PalletTypeID, 
						CBuilding, CLine, CRack, CLevel, CPlace, 
						Address, 
						MaxWeight, CellWidth, CellHeight, GoodsMono, MaxPalletQnt, 
						BufferCellID, Rank, State, 
						IsFull, Locked, Actual, Deleted, ERPCode)
					select Null, Null, Null, @nID, 1, 
						'2', @cCLine, right('0' + cast(@nRack as varchar(2)), 2), cast(@nLevel + 1 as varchar(1)), cast(@nPlace as varchar(1)), 
						'2' + @cCLine + '.' + 
							right('0' + cast(@nRack as varchar(2)), 2) + '.' + 
							cast(@nLevel + 1 as varchar(1)) + '.' + 
							cast(@nPlace as varchar(1)), 
						0, 0.8, 2.0, 1, 1, 
						Null, 0, Null, 
						0, 1, 1, 0, Null
			end
		end
	end
	
	fetch next from _P into @cCLine, @nRacks, @nLevels, @nPlaces
end

close _P
deallocate _P

select @nID = count(*) from Cells where ID > @nMaxID
print cast(@nID as varchar(10)) + ' storage cells inserted'



-- Пикинг
insert StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, 
		NamePrefix, NameSuffix, TemperatureMode, Actual, ERPCode) 
	select 'Пикинг теплый', 7, '', 1, '', '', 'W', 1, Null
select @nID = @@identity

truncate table #CP
insert into #CP (CLine, Racks, Levels, Places) select 'A', 10, 1, 18 
insert into #CP (CLine, Racks, Levels, Places) select 'B', 9, 1, 9 
insert into #CP (CLine, Racks, Levels, Places) select 'C', 9, 1, 9 
insert into #CP (CLine, Racks, Levels, Places) select 'D', 9, 1, 6 
insert into #CP (CLine, Racks, Levels, Places) select 'E', 4, 1, 3 

declare _P cursor for 
	select CLine, Racks, Levels, Places 
		from #CP 
		order by 1
open _P
fetch next from _P into @cCLine, @nRacks, @nLevels, @nPlaces
while @@fetch_status = 0 begin
	select @nRack = 0, @nLevel = 0, @nPlace = 0
	while @nRack < @nRacks begin
		set @nRack = @nRack + 1
		set @nLevel = 0
		
		while @nLevel < @nLevels begin
			set @nLevel  = @nLevel  + 1
			set @nPlace = 0
			
			while @nPlace < @nPlaces begin
				set @nPlace = @nPlace + 1
				insert Cells (FixedOwnerID, FixedGoodStateID, FixedPackingID, StoreZoneID, PalletTypeID, 
						CBuilding, CLine, CRack, CLevel, CPlace, 
						Address, 
						MaxWeight, CellWidth, CellHeight, GoodsMono, MaxPalletQnt, 
						BufferCellID, Rank, State, 
						IsFull, Locked, Actual, Deleted, ERPCode)
					select Null, Null, Null, @nID, Null, 
						'2', @cCLine, right('0' + cast(@nRack as varchar(2)), 2), cast(@nLevel as varchar(1)), right('0' + cast(@nPlace as varchar(2)), 2), 
						'2' + @cCLine + '.' + 
							right('0' + cast(@nRack as varchar(2)), 2) + '.' + 
							cast(@nLevel as varchar(1)) + '.' + 
							right('0' + cast(@nPlace as varchar(2)), 2), 
						0, 0.8, 0.5, 1, 1, 
						Null, 0, Null, 
						0, 1, 1, 0, Null
			end
		end
	end
	
	fetch next from _P into @cCLine, @nRacks, @nLevels, @nPlaces
end

close _P
deallocate _P

select @nID = count(*) from Cells where ID > @nMaxID
print cast(@nID as varchar(10)) + ' picking cells inserted'
