set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[ws_DraftsConvertWMS]
as 
-- выполняем в WMS съем контейнеров из ячеек на основании Trd.WH_Drafts 

-- предварительно надо заполнить 
-- update WHDrafts set WMSSent = 1 where DraftType = 'D' and DateConfirm is not Null 

-- 1. получение данных о выполненных WHDrafts (из БД Trd)
select	Uniq
	into	#WHDraftsList 
	from	WHDrafts D
	where	DateConfirm is not Null and 
			WMSSent = 0 and 
			datediff(day, DateConfirm, getdate()) <= 2 -- ? дата выполнения съема 

select	D.Uniq, 
		D.DateConfirm, 
		D.Depot, Dp.Owner, Dp.WMSGoodState
	into	#WHDrafts 
	from	WHDrafts D
	inner join #WHDraftsList TD on D.Uniq = TD.Uniq 
	left join Depots Dp on D.Depot = Dp.Uniq

select	DG.Uniq, 
		DG.WHDraft, 
		DG.Packing, P.Good, P.InBox, 
		DG.Cell, DG.CellAddress, 
		DG.QntWished, DG.QntConfirmed, DG.DateValid
	into	#WHDraftsGoods 
	from	WHDraftsGoods DG
	inner join #WHDrafts TD on DG.WHDraft = TD.Uniq
	left join Packings P on DG.Packing = P.Uniq
	where	DG.QntConfirmed > 0 

/*
update	WHDrafts 
	set		WMSSent = 1
	from	#WHDrafts TD
	where	WHDrafts.Uniq = TD.Uniq
*/

-------------------------------------------------------------------------------

-- 2. Получение данных о съеме контейнеров из высотной зоны 
-- (в БД WMS)

begin tran 
-- таблица ячеек высотной зоны
select	C.ID, C.ErpCode, C.StoreZoneID, 
		substring(C.Address, len(SZ.NamePrefix) + 1, len(C.Address)) as AddressT
	into	#Cells
	from	WMS.dbo.Cells C 
	inner join WMS.dbo.StoresZones SZ on C.StoreZoneID = SZ.ID
	inner join WMS.dbo.StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID
	where	SZT.ShortCode = 'STOR'
-- приводим адрес к виду как в Trading
update	#Cells
	set AddressT = left(#Cells.AddressT, charindex(SZ.NameSuffix, #Cells.AddressT) - 1)
	from	WMS.dbo.StoresZones SZ 
	where	SZ.NameSuffix > '' and 
			charindex(SZ.NameSuffix, AddressT) > 0 and 
			#Cells.StoreZoneID = SZ.ID

-- ячейки, которые надо очистить
select	C.ID
	into	#CellsClear 
	from	#Cells C
	inner join #WHDraftsGoods DG on C.AddressT = DG.CellAddress
	
-- контейнеры, которые надо удалить
select	distinct CC.FrameID
	into	#FramesClear 
	from	WMS.dbo.CellsContents CC
	inner join #CellsClear C on CC.CellID = C.ID

-- снимаем товар с остатков 
update	WMS.dbo.Oddments
	set Qnt = WMS.dbo.Oddments.Qnt - X.Qnt
	from	(select OwnerID, GoodStateID, PackingID, sum(Qnt) as Qnt 
				from WMS.dbo.CellsContents CC 
				inner join #CellsClear C on C.ID = CC.CellID
				group by OwnerID, GoodStateID, PackingID) X 
	where	isNull(Oddments.OwnerID, -1) = isNull(X.OwnerID, -1) and 
			Oddments.GoodStateID = X.GoodStateID and 
			Oddments.PackingID = X.PackingID
if @@Error <> 0 goto Tr_Error

-- очищаем содержимое ячеек
delete WMS.dbo.CellsContents 
	from	#CellsClear C 
	where	WMS.dbo.CellsContents.CellID = C.ID
if @@Error <> 0 goto Tr_Error
	
-- ? состояние ячейки
update	WMS.dbo.Cells 
	set		State = Null
	from	#CellsClear C
	where	Cells.ID = C.ID
if @@Error <> 0 goto Tr_Error

-- ? если используем временную блокировку ячеек 
update	WMS.dbo.Cells 
	set		Locked = 0
	from	#CellsClear C
	where	WMS.dbo.Cells.ID = C.ID
if @@Error <> 0 goto Tr_Error

-- делаем контейнеры неактуальнымии
update WMS.dbo.Frames
	set		Actual = 0, State = ' ' 
	from	#FramesClear FC 
	where	WMS.dbo.Frames.ID = FC.FrameID
if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
return