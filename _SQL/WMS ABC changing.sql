-- ABC-уходимость товаров ИНКО по количеству операций
-- и "перетекание" товаров между разными категориями
use WMS
go

declare @dBeg datetime, @dEnd datetime
declare @nPackingID int, @nCount dec(12,5), @nSum dec(12,5)
declare @nFullCount int

-- Первый интервал
select @dBeg = '20090601', @dEnd = '20090831'

-- Получение количества операций коробочного отбора
if object_id('Tempdb.dbo.#Goods1') is not Null drop table #Goods1
select PackingID, count(*) as OCount, cast(0 as dec(12,5)) as Prc, cast(' ' as varchar(1)) as ABC 
	into #Goods1 
	from TrafficsGoods 
	where	DateConfirm between @dBeg and @dEnd and 
			PackingID in (select ID from Packings where left(ERPCode, 2) <> 'TM')
	group by PackingID 
	order by 2 desc
select @nFullCount = sum(OCount) from #Goods1

set @nSum = 0

-- Вычисление наростающего %%
declare _Goods1 cursor for 
	select PackingID, OCount from #Goods1 order by OCount desc
open _Goods1
fetch next from _Goods1 into @nPackingID, @nCount
while @@fetch_status = 0 begin
	set @nSum = @nSum + cast(100 * @nCount / @nFullCount as dec(9,5))
	update #Goods1 set Prc = @nSum where PackingID = @nPackingID
	fetch next from _Goods1 into @nPackingID, @nCount
end
close _Goods1
deallocate _Goods1

-- Установка ABC
update #Goods1 set ABC = 'A' where Prc < 60
update #Goods1 set ABC = 'C' where Prc >= 90
update #Goods1 set ABC = 'B' where len(ABC) = 0
--select * from #Goods1



-- Второй интервал
select @dBeg = '20090901', @dEnd = '20091130'

-- Получение количества операций коробочного отбора
if object_id('Tempdb.dbo.#Goods2') is not Null drop table #Goods2
select PackingID, count(*) as OCount, cast(0 as dec(12,5)) as Prc, cast(' ' as varchar(1)) as ABC 
	into #Goods2 
	from TrafficsGoods 
	where	DateConfirm between @dBeg and @dEnd and 
			PackingID in (select ID from Packings where left(ERPCode, 2) <> 'TM')
	group by PackingID 
	order by 2 desc
select @nFullCount = sum(OCount) from #Goods2

set @nSum = 0

-- Вычисление наростающего %%
declare _Goods2 cursor for 
	select PackingID, OCount from #Goods2 order by OCount desc
open _Goods2
fetch next from _Goods2 into @nPackingID, @nCount
while @@fetch_status = 0 begin
	set @nSum = @nSum + cast(100 * @nCount / @nFullCount as dec(9,5))
	update #Goods2 set Prc = @nSum where PackingID = @nPackingID
	fetch next from _Goods2 into @nPackingID, @nCount
end
close _Goods2
deallocate _Goods2

-- Установка ABC
update #Goods2 set ABC = 'A' where Prc < 60
update #Goods2 set ABC = 'C' where Prc >= 90
update #Goods2 set ABC = 'B' where len(ABC) = 0
--select * from #Goods2



-- Поиск пересечений
if object_id('Tempdb.dbo.#Cross') is not Null drop table #Cross
create table #Cross (ABC varchar(1), Period1 int, Period2 int, Common int)

declare @cABC varchar(1), @nPeriod1 int, @nPeriod2 int, @nCommon int
set @cABC = 'A'
while @cABC <= 'C' begin
	select @nPeriod1 = count(*) from #Goods1 where ABC = @cABC
	select @nPeriod2 = count(*) from #Goods2 where ABC = @cABC
	select @nCommon = count(*) 
		from #Goods1 G1 
		inner join #Goods2 G2 on G1.PackingID = G2.PackingID and G1.ABC = @cABC and G2.ABC = @cABC
	insert into #Cross (ABC, Period1, Period2, Common) 
		values (@cABC, @nPeriod1, @nPeriod2, @nCommon)
	set @cABC = char(ascii(@cABC) + 1)
end
select * from #Cross
