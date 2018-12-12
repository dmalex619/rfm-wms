-- Вычисление гомосеков
if object_id('Tempdb.dbo.#Pidors') is not Null drop table #Pidors

create table #Pidors 
	(ID int, Name varchar(100), 
	InBuf int, InBufSum money, 
	OutBuf int, OutBufSum money, 
	StorBuf int, StorBufSum money, 
	FullSum money)

insert #Pidors (ID, Name, InBuf, InBufSum, OutBuf, OutBufSum, StorBuf, StorBufSum, FullSum) 
	select ID, Name, 0, 0, 0, 0, 0, 0, 0 
		from _Users with (nolock)

-- Операции из IN.1 в IN.1.BUF
update #Pidors set InBuf = X.InBuf, InBufSum = X.InBuf * 5.70 
	from (select UserID, count(*) as InBuf 
			from TrafficsFrames with (nolock) 
			where	DateConfirm is not Null and DateConfirm >= '20100701' and 
					CellSourceID = (select ID from Cells where Address = 'IN.1') and 
					CellTargetID = (select ID from Cells where Address = 'IN.1.BUF') 
			group by UserID
		) X 
		where #Pidors.ID = X.UserID

-- Операции из OUT.1 в OUT.1.BUF
update #Pidors set OutBuf = X.OutBuf, OutBufSum = X.OutBuf * 5.70 
	from (select UserID, count(*) as OutBuf 
			from TrafficsFrames with (nolock) 
			where	DateConfirm is not Null and DateConfirm >= '20100701' and 
					CellTargetID = (select ID from Cells where Address = 'OUT.1') and 
					CellSourceID = (select ID from Cells where Address = 'OUT.1.BUF') 
			group by UserID
		) X 
		where #Pidors.ID = X.UserID

-- Операции между буферными ячейками внутри одной высотки
update #Pidors set StorBuf = X.StorBuf, StorBufSum = X.StorBuf * 5.70 
	from (select UserID, count(*) as StorBuf 
			from TrafficsFrames with (nolock) 
			where	DateConfirm is not Null and DateConfirm >= '20100701' and 
						(	(CellSourceID in (select ID from Cells where Address like '3_.BUF') and 
							CellTargetID in (select ID from Cells where Address like '3_.BUF')) 
							or  
							(CellSourceID in (select ID from Cells where Address like '4_.BUF') and 
							CellTargetID in (select ID from Cells where Address like '4_.BUF')) 
						)
			group by UserID
		) X 
		where #Pidors.ID = X.UserID



update #Pidors set FullSum = InBufSum + OutBufSum + StorBufSum
delete #Pidors where FullSum = 0
select * from #Pidors order by FullSum desc

