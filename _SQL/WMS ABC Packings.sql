-- ABC-уходимость товаров ИНКО по количеству операций
-- и наличие товаров разных категорий в заданиях
use WMS
go

declare @dBeg datetime, @dEnd datetime
select @dBeg = '20090101', @dEnd = '20091130'

-- Получение количества операций коробочного отбора
if object_id('Tempdb.dbo.#Goods') is not Null drop table #Goods
select PackingID, count(*) as OCount, cast(0 as dec(12,5)) as Prc, cast(' ' as varchar(1)) as ABC 
	into #Goods 
	from TrafficsGoods 
	where	DateConfirm between @dBeg and @dEnd and 
			PackingID in (select ID from Packings where left(ERPCode, 2) <> 'TM')
	group by PackingID 
	order by 2 desc
declare @nFullCount int
select @nFullCount = sum(OCount) from #Goods

declare @nPackingID int, @nCount dec(12,5), @nSum dec(12,5)
set @nSum = 0

-- Вычисление наростающего %%
declare _Goods cursor for 
	select PackingID, OCount from #Goods order by OCount desc
open _Goods
fetch next from _Goods into @nPackingID, @nCount
while @@fetch_status = 0 begin
	set @nSum = @nSum + cast(100 * @nCount / @nFullCount as dec(9,5))
	update #Goods set Prc = @nSum where PackingID = @nPackingID
	fetch next from _Goods into @nPackingID, @nCount
end
close _Goods
deallocate _Goods

-- Установка ABC
update #Goods set ABC = 'A' where Prc < 60
update #Goods set ABC = 'C' where Prc >= 90
update #Goods set ABC = 'B' where len(ABC) = 0
select * from #Goods

declare @nOutFull dec (12,5), @nOutGoods dec (12,5)

-- Получение общего количества заданий
select @nOutFull = count(ID) 
	from Outputs 
	where	OwnerID = 1 and DateConfirm is not Null and 
			DateOutput between @dBeg and @dEnd
-- Получение количества заданий с товаром заданной категории
select @nOutGoods = count(distinct OG.OutputID) 
	from Outputs O 
	inner join OutputsGoods OG on OG.OutputID = O.ID
	where	OwnerID = 1 and DateConfirm is not Null and 
			DateOutput between @dBeg and @dEnd and 
			OG.PackingID in (select PackingID from #Goods where ABC in ('C'))
select @nOutFull, @nOutGoods, @nOutGoods / @nOutFull * 100
