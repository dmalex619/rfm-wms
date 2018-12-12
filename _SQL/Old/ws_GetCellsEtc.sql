--use wms

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

alter PROCEDURE [dbo].[ws_GetCellsEtc]
-- Процедура для выгрузки данных о ячейках, подъеме контейнеров, исправлении ошибок
-- выполняется в Wms, строит xml
AS
set nocount on

-- ID и Uniq организации
-- Внимание!
declare @nWeID int, @cErpWe varchar(50)
select	@nWeID = dbo._SettingsGetValue('gnWe') -- код владельца
select	@cErpWe = ErpCode
	from	Partners 
	where	ID = @nWeID

-- 1. Набор ячеек
-- все ячейки 
select	C.ID, C.ErpCode, 
		C.StoreZoneID, SZT.ShortCode, 
		substring(C.Address, len(SZ.NamePrefix) + 1, len(C.Address)) as AddressT
	into	#AllCells
	from	Cells C
	inner join StoresZones SZ on C.StoreZoneID = SZ.ID
	inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID
-- приводим адрес к виду как в Trading
update	#AllCells
	set AddressT = left(#AllCells.AddressT, charindex(SZ.NameSuffix, #AllCells.AddressT) - 1)
	from	StoresZones SZ 
	where	SZ.NameSuffix > '' and 
			charindex(SZ.NameSuffix, AddressT) > 0 and 
			#AllCells.StoreZoneID = SZ.ID

-- таблица ячеек высотной зоны только
select	* 
	into	#Cells
	from	#AllCells 
	where	ShortCode = 'STOR'

-- 1.1. Геометрия, актуальность, блокировка
select	C.ID, 
		C.ErpCode as ErpCell, 
		TC.AddressT as Address, 
		C.CellHeight, 
		C.CellWidth, 
		C.MaxWeight, 
		C.Locked,
		C.Actual, 
		PT.ErpCode as ErpPalletType
	from	Cells C
	inner join #Cells TC on C.ID = TC.ID
	left  join PalletsTypes PT on C.PalletTypeID = PT.ID

-- 2. Подъем контейнеров
select	T.ID, T.DateConfirm
	into	#Traffics 
	from	Traffics T
	inner join #Cells TC on T.CellTargetID = TC.ID 
	where	T.ErpCode is Null and -- не переданы
			T.DateConfirm is not Null
select	T.ID,
		T.ErpCode as ErpTraffic, 
		T.DateBirth, 
		T.DateConfirm, 
		T.FrameID as FrameID, 
		F.ErpCode as ErpFrame,
		F.GoodStateID, 
		GS.Basic as GoodStateBasic, 
		GS.ErpCode as ErpGoodState, 
		isNull(F.OwnerID, @nWeID) as OwnerID, 
		isNull(P.ErpCode, @cErpWe) as ErpOwner, 
		T.CellSourceID, 
		CS.ErpCode as ErpCellSource, 
		CS.AddressT as CellSourceAddress, 
		T.CellTargetID, 
		CT.ErpCode as ErpCellTarget, 
		CT.AddressT as CellTargetAddress, 
		CC.Qnt, 
		CC.PackingID, 
		Ps.ErpCode as ErpPacking, 
		Ps.GoodID,
		G.ErpCode as ErpGood,
		Ps.InBox, 
		CC.DateValid 
	from	Traffics T
	inner join #Traffics TT on T.ID = TT.ID
	left  join Frames F on T.FrameID = F.ID
	left  join GoodsStates GS on F.GoodStateID = GS.ID
	left  join Partners P on F.OwnerID = P.ID
	left  join #AllCells CS on T.CellSourceID = CS.ID
	inner join #Cells CT on T.CellTargetID = CT.ID
	left  join CellsContents CC on F.ID = CC.FrameID 
	left  join Packings Ps on CC.PackingID = Ps.ID
	left  join Goods G on Ps.GoodID = G.ID
	order by T.DateConfirm

-- 3. Исправление ошибок
select	H.ID, H.DateEdit
	into	#Changes 
	from	CellsChanges H
	inner join #Cells TC on H.CellID = TC.ID 
	where	H.ErpCode is Null and -- не переданы
			H.DateEdit is not Null
select	H.ID, 
		H.ErpCode as ErpChange, 
		H.CellID, 
		H.ErpCode as ErpCellChange, 
		H.DateEdit, 
		TC.ErpCode as ErpCell,
		TC.AddressT as CellAddress, 
		H.GoodStateID, 
		GS.Basic as GoodStateBasic, 
		GS.ErpCode as ErpGoodState, 
		isNull(H.OwnerID, @nWeID) as OwnerID, 
		isNull(P.ErpCode, @cErpWe) as ErpOwner, 
		H.Qnt, 
		H.PackingID, 
		Ps.ErpCode as ErpPacking, 
		Ps.GoodID,
		G.ErpCode as ErpGood,
		Ps.InBox, 
		H.DateValid 
	from	CellsChanges H
	inner join #Changes Ch on H.ID = Ch.ID 
	inner join #Cells TC on H.CellID = TC.ID 
	left join Partners P on H.OwnerID = P.ID
	left join GoodsStates GS on H.GoodStateID = GS.ID
	left  join Packings Ps on H.PackingID = Ps.ID
	left  join Goods G on Ps.GoodID = G.ID
	order by H.DateEdit
