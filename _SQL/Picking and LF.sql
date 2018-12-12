-- ¬заимное сокращение €чеек пикинга и Lost&Found

-- €чейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	RaisError (N'Ќе задан адрес виртуальной €чейки Lost&Found...', 11, 1)
	return 
end 
select	@nLostFoundCellID = ID 
	from	Cells 
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	RaisError(N'Ќе найдена виртуальна€ €чейка (Lost&Found)', 11, 1)
	return 
end 

if object_id('Tempdb.dbo.#Packs') is not Null drop table #Packs
select C.FixedPackingID, C.FixedGoodStateID, CC.CellID as PickingCellID, 
	CC.ID as PickingCellsContentsID, LF.LFCellsContentsID, 
	CC.Qnt as PickingQnt, LF.Qnt as LFQnt, 
	G.Alias, P.InBox, C.Address, 
	cast(CC.Qnt / P.InBox / P.BoxInPal as dec(12,1)) as Pallets, 
	cast(CC.Qnt / P.InBox  as dec(12,1)) as Boxes, 
	cast(LF.Qnt / P.InBox  as dec(12,1)) as LF 
into #Packs 
from Cells C 
inner join CellsContents CC on CC.CellID = C.ID
inner join Packings P on C.FixedPackingID = P.ID
inner join Goods G on P.GoodID = G.ID
inner join (select ID as LFCellsContentsID, PackingID, GoodStateID, Qnt 
			from CellsContents 
			where CellID = @nLostFoundCellID and FrameID is Null and GoodStateID = 1) LF 
	on LF.PackingID = C.FixedPackingID and LF.GoodStateID = C.FixedGoodStateID 
where CC.Qnt > 0 and LF.Qnt < 0 --and CC.Qnt >= abs(LF.Qnt)
order by Pallets desc, Boxes desc
select * from #Packs

if 0 = 1 begin
	declare @nPCCID int, @nLFID int, @nPQ dec(15,3), @nLFQ dec(15,3), @nDiff dec(15,3)
	declare _Packs cursor for 
		select PickingCellsContentsID, LFCellsContentsID, PickingQnt, LFQnt 
			from #Packs order by 1
	open _Packs
	fetch next from _Packs into @nPCCID, @nLFID, @nPQ, @nLFQ
	while @@fetch_status = 0 begin
		set @nDiff = @nPQ + @nLFQ
		if @nDiff >= 0 begin
			update CellsContents set Qnt = @nDiff where ID = @nPCCID
			delete CellsContents where ID = @nLFID
		end
		else begin
			update CellsContents set Qnt = 0 where ID = @nPCCID
			update CellsContents set Qnt = @nDiff where ID = @nLFID
		end
		
		fetch next from _Packs into @nPCCID, @nLFID, @nPQ, @nLFQ
	end
	
	close _Packs
	deallocate _Packs
end
