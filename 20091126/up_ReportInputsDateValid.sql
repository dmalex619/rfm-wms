set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_ReportInputsDateValid]
	@dDateBeg			smalldatetime	= Null, -- начало периода
	@dDateEnd			smalldatetime	= Null, -- окончание периода
	@cPartnersList		varchar(max)	= Null, 
	@cPackingsList		varchar(max)	= Null, 
	@nPercents			int				= Null,
	@nMonths			int				= Null,
	@bFromNow			bit				= 0 -- 0 от даты прихода / 1 от текущей даты 
AS

set nocount on

declare @dNow smalldatetime
set @dNow = GetDate()

if @dDateBeg is Null set @dDateBeg = '19900101'
if @dDateEnd is Null set @dDateEnd = '20501231'

select	@cPartnersList = ',' + replace(@cPartnersList, ' ', '') + ',', 
		@cPackingsList = ',' + replace(@cPackingsList,	' ', '') + ','

select	ID 
	into	#Partners 
	from	Partners with (nolock) 
	where	IsNull(@cPartnersList, '') = '' or 
			charindex(',' + ltrim(str(ID)) + ',', @cPartnersList) > 0

select	P.ID, P.GoodID, P.InBox, P.BoxInPal 
	into	#Packings 
	from	Packings  P with (nolock) 
	inner   join Goods G on G.ID = P.GoodID 
	where	Retention > 0 and 
			(IsNull(@cPackingsList, '') = '' or 
			 charindex(',' + ltrim(str(P.ID)) + ',', @cPackingsList) > 0)

select	II.InputID, II.ID as InputGoodsID, 
		I.DateInput, I.DateConfirm, 
		I.PartnerID, 
		II.GoodStateID, 
		I.OwnerID, 
		II.FrameID, 
		II.PackingID, P.GoodID, 
		II.Qnt, 
		II.DateValid, 
		P.InBox, P.BoxInPal, 
		G.Retention, 
		cast(Null as smalldatetime) as NormDateValid, 
		cast(0 as decimal(6, 1)) as DateValidRestPercent, 
		cast(0 as int) as CellID 
	into #Report 
	from InputsItems II with (nolock) 
	inner join Inputs I with (nolock) on II.InputID = I.ID 
	inner join #Partners Ps with (nolock) on I.PartnerID = Ps.ID 
	inner join #Packings P with (nolock) on II.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where   datediff(day, @dDateBeg, I.DateConfirm) >= 0 and 
			datediff(day, I.DateConfirm, @dDateEnd) >= 0 and 
			II.DateValid is not Null

update #Report 
	set DateValidRestPercent = datediff(day, 
		(case when @bFromNow = 0 
			then DateInput 
			else @dNow end), DateValid) * 100.0 / Retention 
if @nPercents > 0 begin
	-- удаляем те, что не подходят по сроку годности 
	delete #Report 
		where DateValidRestPercent > @nPercents
end
if @nMonths > 0 begin
	delete #Report 
		where datediff(day, DateValid, 
			dateadd(month, @nMonths, 
			(case when @bFromNow = 0 then DateInput else @dNow end))) < 0
end

update #Report 
	set CellID = CC.CellID 
	from CellsContents CC 
	where #Report.FrameID is not Null and #Report.FrameID = CC.FrameID

-- конечная выборка
select	R.InputID, R.InputGoodsID, 
		R.DateInput, R.DateConfirm, 
		R.PartnerID, Ps.Name as PartnerName, 
		R.OwnerID, Ow.Name as OwnerName, 
		R.GoodStateID, GS.Name as GoodStateName, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		R.FrameID, 
		R.PackingID, R.GoodID, 
		R.Qnt, 
		R.Qnt / R.InBox as Box, 
		cast(R.Qnt / R.InBox / R.BoxInPal as decimal(12, 4)) as Pal, 
		R.DateValid, 
		R.InBox, R.BoxInPal, 
		R.NormDateValid, 
		R.DateValidRestPercent, 
		R.CellID, C.Address as CellAddress, 
		C.StoreZoneID, SZ.Name as StoreZoneName 
	from #Report R 
	left  join GoodsStates GS with (nolock) on R.GoodStateID = GS.ID 
	left  join Partners Ps with (nolock) on R.PartnerID = Ps.ID 
	left  join Partners Ow with (nolock) on R.OwnerID = Ow.ID 
	inner join Packings P with (nolock) on R.PackingID = P.ID 
	left  join Goods G with (nolock) on R.GoodID = G.ID 
	left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	left  join Cells C with (nolock) on R.CellID = C.ID 
	left  join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	order by G.Alias, R.DateInput, Ps.Name, GS.Name
return