USE [WMS]
GO
/****** Object:  StoredProcedure [dbo].[up_CellsContentsSnapshotsPrepareInventoryAct]    Script Date: 02/07/2012 11:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellsContentsSnapshotsPrepareInventoryAct]
	@nCellContentSnapshotID	int, 
	@cHostsList				varchar(max), 
	@cGoodsStatesList		varchar(max), 
	@cPackingsList			varchar(max), 
	@nError					int = 0 output, 
	@cErrorStr				varchar(max) = '' output
AS
-- Подготовка списка товаров для актирования по результатам ревизии

set nocount on

-- Проверка параметра
if @nCellContentSnapshotID is Null begin
	select	@nError = -1, 
			@cErrorStr = 'Неправильный параметр @nCellContentSnapshotID...'
	--RaisError (@cErrorStr, 11, 1)
	return 
end

-- Проверка наличия конечного среза остатков
if not exists (select top 1 ID 
				from CellsContentsSnapshotsEnd 
				where CellContentSnapshotID = @nCellContentSnapshotID) begin
	select	@nError = -2, 
			@cErrorStr = 'Отсутствует конечный срез остатков с кодом ' + str(@nCellContentSnapshotID)
	--RaisError (@cErrorStr, 11, 1)
	return 
end

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -11, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	--RaisError (@cErrorStr, 11, 1)
	return 
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from	Cells
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -12, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	--RaisError(@cErrorStr, 11, 1)
	return 
end 

create table #Diff (HostID int, 
	OwnerID int, GoodStateID int, PackingID int, CellID int, 
	QntBeg dec(18,3) default 0, QntEnd dec(18,3) default 0)

-- Получение полного сочетания всех кодов
insert #Diff (OwnerID, GoodStateID, PackingID, CellID) 
	select distinct OwnerID, GoodStateID, PackingID, CellID 
		from CellsContentsSnapshotsBeg with (nolock) 
		where CellContentSnapshotID = @nCellContentSnapshotID 
	union 
	select distinct OwnerID, GoodStateID, PackingID, CellID 
		from CellsContentsSnapshotsEnd with (nolock) 
		where CellContentSnapshotID = @nCellContentSnapshotID 
	order by OwnerID, GoodStateID, PackingID, CellID

-- Получение кодов хостов
update #Diff set HostID = G.HostID 
	from Packings P with (nolock) 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where #Diff.PackingID = P.ID

-- Переменная для макрокоманды
declare @cScript varchar(max)

-- Удаление хостов вне заданного списка
if Len(IsNull(@cHostsList, '')) > 0 begin
	set @cScript = 'delete #Diff where HostID not in (' + dbo._NormalizeList(@cHostsList) + ')'
	exec (@cScript)
end

-- Удаление состояний товаров вне заданного списка
if Len(IsNull(@cGoodsStatesList, '')) > 0 begin
	set @cScript = 'delete #Diff where GoodStateID not in (' + dbo._NormalizeList(@cGoodsStatesList) + ')'
	exec (@cScript)
end

-- Удаление товаров вне заданного списка
-- Для длинных строк через таблицу получается существенно быстрее
set @cGoodsStatesList = dbo._NormalizeList(@cGoodsStatesList)
if Len(IsNull(@cPackingsList, '')) > 0 begin
	-- Создаем таблицу с кодами обрабатываемых заказов
	create table #FilteredPackings (ID int)
	
	-- Обрабатываем поданный список кодов упаковок
	declare @nCurPackingID int, @nPos int, @nLen int
	while len(@cPackingsList) > 0 begin
		set @nPos = charindex(',', @cPackingsList)
		if @nPos > 0 set @nCurPackingID = cast(left(@cPackingsList, @nPos - 1) as int)
		else set @nCurPackingID = cast(@cPackingsList as int)
		insert into #FilteredPackings (ID) values (@nCurPackingID)
		
		if @nPos > 0 select @cPackingsList = substring(@cPackingsList, @nPos + 1, len(@cPackingsList))
		else set @cPackingsList = ''
	end
	
	-- Создаем индекс для ускорения поиска
	create index IX_TMP_FilteredPackings on #FilteredPackings (ID)
	
	-- Удаляем лишние упаковки
	delete #Diff 
		where PackingID not in (select ID from #FilteredPackings)
end

-- Заполнение начального и конечного количеств
update #Diff set QntBeg = X.Qnt 
	from CellsContentsSnapshotsBeg X 
	where	X.CellContentSnapshotID = @nCellContentSnapshotID and 
			IsNull(#Diff.OwnerID, -1) = IsNull(X.OwnerID, -1) and 
			#Diff.GoodStateID = X.GoodStateID and 
			#Diff.PackingID = X.PackingID and 
			#Diff.CellID = X.CellID
update #Diff set QntEnd = X.Qnt 
	from CellsContentsSnapshotsEnd X 
	where	X.CellContentSnapshotID = @nCellContentSnapshotID and 
			IsNull(#Diff.OwnerID, -1) = IsNull(X.OwnerID, -1) and 
			#Diff.GoodStateID = X.GoodStateID and 
			#Diff.PackingID = X.PackingID and 
			#Diff.CellID = X.CellID

-- Удаление всех ячеек с неизменившимся количеством
-- Либо их не пересчитывали, либо проблем нет
/*delete #Diff 
	where QntBeg = QntEnd*/

-- Получаем все возможные сочетания хоста, владельца, состояния и товара
select distinct I.HostID, I.OwnerID, IG.GoodStateID, IG.PackingID 
	into #Inputs 
	from Inputs I with (nolock) 
	inner join InputsGoods IG with (nolock) on IG.InputID = I.ID 
	where IG.QntConfirmed > 0 
	order by I.HostID, I.OwnerID, IG.GoodStateID, IG.PackingID
create index IX_TMP_Inputs on #Inputs (HostID, GoodStateID, PackingID)

-- Создаем таблицу для вычисления владельцев
create table #Owners (OwnerID int)

-- Пытаемся вычислить из приходов документарного владельца 
-- для товаров с пустым владельцем
declare @nHostID int, @nGoodStateID int, @nPackingID int
declare _Diff cursor for 
	select HostID, GoodStateID, PackingID 
		from #Diff 
		where OwnerID is Null
open _Diff

fetch next from _Diff into @nHostID, @nGoodStateID, @nPackingID
while @@fetch_status = 0 begin
	-- очищаем таблицу...
	truncate table #Owners
	
	-- ...получаем всех владельцев через приходы
	insert into #Owners (OwnerID) 
		select distinct OwnerID 
			from #Inputs 
			where	HostID = @nHostID and 
					GoodStateID = @nGoodStateID and 
					PackingID = @nPackingID
	
	-- ...и подставляем владельца только если он единственный
	if @@RowCount = 1 begin
		update #Diff set OwnerID = X.OwnerID 
			from #Owners X 
			where	#Diff.HostID = @nHostID and 
					#Diff.GoodStateID = @nGoodStateID and 
					#Diff.PackingID = @nPackingID
	end
	
	fetch next from _Diff into @nHostID, @nGoodStateID, @nPackingID
end

close _Diff
deallocate _Diff

--* ATTENSION!!!
-- Get wrong acts from 16.10.2011 with different sign
UPDATE #Diff SET QntEnd = QntEnd - X.QntConfirmed 
	from (select	A.HostID, A.OwnerID, A.GoodStateID, 
					AG.PackingID, AG.QntConfirmed 
				from AuditActs A with (nolock) 
				inner join AuditActsGoods AG with (nolock) on AG.AuditActID = A.ID 
				where A.ID between 43534 and 43540) X
	where	#Diff.HostID = X.HostID and 
			#Diff.OwnerID = X.OwnerID and 
			#Diff.GoodStateID = X.GoodStateID and 
			#Diff.PackingID = X.PackingID
--* ATTENSION!!!

-- Получение списка товаров для актирования
select	X.HostID, H.Name as HostName, 
		X.OwnerID, IsNull(O.Name, '') as OwnerName, 
		X.GoodStateID, GS.Name as GoodStateName, 
		X.PackingID, P.GoodID, 
		GG.Name as GoodGroupName, G.Alias as GoodName, 
		P.InBox, 
		-X.QntEnd as Qnt, round(-X.QntEnd / P.InBox, 1) as Boxes 
	from #Diff X 
	inner join Hosts H with (nolock) on X.HostID = H.ID 
	left join Partners O with (nolock) on X.OwnerID = O.ID 
	inner join GoodsStates GS with (nolock) on X.GoodStateID = GS.ID 
	inner join Packings P with (nolock) on X.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	where	X.CellID  = @nLostFoundCellID and 
			X.QntEnd <> 0 
	order by HostName, OwnerName, GoodStateName, GoodGroupName, GoodName
return