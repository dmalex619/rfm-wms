-- Автоматическое присвоение ранга ячейкам пикинга 
-- в определенных зонах склада ИНКО-Жуковский
-- Скрипт должен запускаться вручную администратором WMS
-- Назначение скрипта - реализация обхода "змейкой" 
-- зон пикинга 3-го и 4-го складов

-- Пикер начинает сбор коробок у ячейки 3P.01.1.1,
-- мечется между линиями P & O по возрастанию номеров стояков и ячеек,
-- у стенки склада переползает в следующий проход,
-- мечется между линиями N & M по убыванию номеров стояков и ячеек,
-- и так далее.
-- После окончания сбора коробок на складе 3 он переходит на склад 4,
-- и там повторяет всю процедуру, начиная с ячейки 4V.01.1.1

if db_name() <> 'WMS' return

set nocount on

-- Получение временной таблицы для сортировки ячеек пикинга
if object_id('Tempdb..#Cells') is not Null drop table #Cells
select ID, Rank, CBuilding, CLine, CRack, CLevel, CPlace, 
	Ascii(CLine) as LineNum, Ascii(CLine) as Aisle, 
	cast(CRack as int) as NRack, cast(CPlace as int) as NPlace 
	into #Cells 
	from Cells 
	where StoreZoneID in (24, 14) and Deleted = 0 
	order by CBuilding, CLine desc, CRack, CLevel, CPlace
alter table #Cells add constraint _PK_Cells primary key (ID)

-- Линия <P> склада 3 начинается со 2-го стояка,
-- поэтому увеличиваем нумерацию его стояков на 1
update #Cells set NRack = NRack + 1 where CBuilding = '3' and CLine = 'P'

-- "Левым" способом выравниваем номера проходов для соседних линий
update #Cells set Aisle = LineNum + 1 where LineNum % 2 = 1
update #Cells set Aisle = Aisle + 2 where CBuilding = '4'

-- Присваиваем проходам, в которых движение начинается от первого стояка,
-- четные номера, а остальным - нечетные
update #Cells set Aisle = Aisle / 2

-- Делаем номера стояков и ячеек отрицательными для нечетных проходов
update #Cells set NRack = -NRack, NPlace = -NPlace where Aisle % 2 = 1

-- Сортируем таблицу "змейкой" (проверка)
/*
select * 
	from #Cells 
	order by CBuilding, Aisle desc, NRack, CLevel, NPlace, CLine desc
*/

-- Создаем переменные для присвоения ранга
declare @nID int, @nRank int
set @nRank = 0

-- Создаем курсор для присвоения ранга
declare _Cells cursor for 
	select ID from #Cells 
		order by CBuilding, Aisle desc, NRack, CLevel, NPlace, CLine desc
open _Cells

-- Заменяем ранг во временной таблице
fetch next from _Cells into @nID
while @@fetch_status = 0 begin
	set @nRank = @nRank + 1
	update #Cells set Rank = @nRank where ID = @nID
	
	fetch next from _Cells into @nID
end

close _Cells
deallocate _Cells


-- Обнуляем и заменяем существующие ранги
update Cells set Rank = 0 
	where ID in (select ID from #Cells)
update Cells set Rank = X.Rank 
	from #Cells X 
	where Cells.ID = X.ID

select * 
	from #Cells 
	where ID in (select ID from #Cells) 
	order by Rank
