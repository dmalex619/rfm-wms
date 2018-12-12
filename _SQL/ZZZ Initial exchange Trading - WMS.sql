-- Процедура начального обмена данными между БД Trading & WMS
if db_name() <> 'WMS' return

set nocount on

print 'Partners (Owners only!)'
if object_id('Tempdb.dbo.#_TPartners') is not Null drop table #_TPartners
select P.Alias as Name, 
	case when D.Uniq is Null then 0 else 1 end as Owner, 
	0 as SeparatePicking, 
	P.Actual, 
	cast(P.Uniq as varchar(max)) as ERPCode 
	into #_TPartners 
	from [TSQL-SRV].Trading.dbo.Partners P 
	inner join [TSQL-SRV].Trading.dbo.Depots D on D.Owner = P.Uniq and D.Basic = 1 
	where P.Actual = 1 -- ???
	order by P.Uniq

begin tran
	update Partners set 
		Name = X.Name, 
		Owner = X.Owner, 
		SeparatePicking = X.SeparatePicking, 
		Actual = X.Actual 
		from #_TPartners X 
		where Partners.ERPCode = X.ERPCode
if @@Error <> 0 rollback
else commit tran
	
begin tran
	insert into Partners (Name, Owner, SeparatePicking, Actual, ERPCode)
		select X.Name, X.Owner, X.SeparatePicking, X.Actual, X.ERPCode 
			from #_TPartners X 
			where X.ERPCode not in (select ERPCode from Partners)
if @@Error <> 0 rollback
else commit tran

print 'GoodsGroups'
if object_id('Tempdb.dbo.#_TGoodsGroups') is not Null drop table #_TGoodsGroups
select Alias as Name, Actual, cast(Uniq as varchar(max)) as ERPCode 
	into #_TGoodsGroups 
	from [TSQL-SRV].Trading.dbo.GoodsGroups 
	order by Uniq

begin tran
	update GoodsGroups set 
		Name = X.Name, 
		Actual = X.Actual 
		from #_TGoodsGroups X 
		where GoodsGroups.ERPCode = X.ERPCode
if @@Error <> 0 rollback
else commit tran
	
begin tran
	insert into GoodsGroups (Name, Actual, ERPCode)
		select X.Name, X.Actual, X.ERPCode 
			from #_TGoodsGroups X 
			where X.ERPCode not in (select ERPCode from GoodsGroups)
if @@Error <> 0 rollback
else commit tran

print 'GoodsBrands'
if object_id('Tempdb.dbo.#_TGoodsBrands') is not Null drop table #_TGoodsBrands
select Alias as Name, Actual, cast(Uniq as varchar(max)) as ERPCode 
	into #_TGoodsBrands 
	from [TSQL-SRV].Trading.dbo.Brands 
	order by Uniq

begin tran
	update GoodsBrands set 
		Name = X.Name, 
		Actual = X.Actual 
		from #_TGoodsBrands X 
		where GoodsBrands.ERPCode = X.ERPCode
if @@Error <> 0 rollback
else commit tran
	
begin tran
insert into GoodsBrands (Name, Actual, ERPCode)
	select X.Name, X.Actual, X.ERPCode 
		from #_TGoodsBrands X 
		where X.ERPCode not in (select ERPCode from GoodsBrands)
if @@Error <> 0 rollback
else commit tran
	
print 'Goods'
if object_id('Tempdb.dbo.#_TGoods') is not Null drop table #_TGoods
select G.Alias, G.Name, G.BarCode, 
	G.Netto, G.Brutto, G.Retention, G.Weighting, 
	GG.ID as GoodGroupID, 
	GB.ID as GoodBrandID, 
	G.Gravity, G.Actual, 
	cast(G.Uniq as varchar(max)) as ERPCode 
	into #_TGoods 
	from [TSQL-SRV].Trading.dbo.Goods G 
	inner join GoodsGroups GG on cast(G.GoodsGroup as varchar(max)) = GG.ERPCode 
	inner join GoodsBrands GB on cast(G.Brand as varchar(max)) = GB.ERPCode 
	order by G.Uniq

begin tran
	update Goods set 
		Alias = X.Alias, 
		Name = X.Name, 
		BarCode = X.BarCode, 
		Netto = X.Netto, 
		Brutto = X.Brutto, 
		Retention = X.Retention, 
		Weighting = X.Weighting, 
		GoodGroupID = X.GoodGroupID, 
		GoodBrandID = X.GoodBrandID, 
		Gravity = X.Gravity, 
		Actual = X.Actual 
		from #_TGoods X 
		where Goods.ERPCode = X.ERPCode
if @@Error <> 0 rollback
else commit tran

begin tran
	insert into Goods (Alias, Name, BarCode, Netto, Brutto, Retention, Weighting, 
		GoodGroupID, GoodBrandID, Actual, Gravity, ERPCode)
		select X.Alias, X.Name, X.BarCode, X.Netto, X.Brutto, X.Retention, X.Weighting, 
			X.GoodGroupID, X.GoodBrandID, X.Actual, X.Gravity, X.ERPCode
			from #_TGoods X 
			where X.ERPCode not in (select ERPCode from Goods)
if @@Error <> 0 rollback
else commit tran

print 'Packings (NOT one to one!)'
if object_id('Tempdb.dbo.#_TMaxPacks') is not Null drop table #_TMaxPacks
if object_id('Tempdb.dbo.#_TPackings') is not Null drop table #_TPackings
select Good, InBox, max(Uniq) as MaxUniq 
	into #_TMaxPacks 
	from [TSQL-SRV].Trading.dbo.Packings 
	group by Good, InBox
select G.ID as GoodID, 
	case when P.PalletWidth = 0.8 then 1 else 2 end as PalletTypeID, 
	P.InBox, P.BoxInPal, P.InRow as BoxInRow, 
	P.Width as BoxWidth, P.Length as BoxLength, 
	P.Height as BoxHeight, P.Weight as BoxWeight, 
	P.Actual, 
	cast(P.Good as varchar(max)) + '/' + cast(ltrim(str(P.InBox)) as varchar(max)) as ERPCode 
	into #_TPackings 
	from [TSQL-SRV].Trading.dbo.Packings P 
	inner join Goods G on cast(P.Good as varchar(max)) = G.ERPCode 
	inner join #_TMaxPacks T on P.Uniq = T.MaxUniq 
	order by P.Good, P.Uniq

begin tran
	update Packings set 
		GoodID = X.GoodID, 
		PalletTypeID = X.PalletTypeID, 
		InBox = X.InBox, 
		BoxInPal = X.BoxInPal, 
		BoxInRow = X.BoxInRow, 
		BoxWidth = X.BoxWidth, 
		BoxLength = X.BoxLength, 
		BoxHeight = X.BoxHeight, 
		BoxWeight = X.BoxWeight, 
		Actual = X.Actual 
		from #_TPackings X 
		where Packings.ERPCode = X.ERPCode
if @@Error <> 0 rollback
else commit tran

begin tran
	insert into Packings (GoodID, PalletTypeID, InBox, BoxInPal, BoxInRow, 
		BoxWidth, BoxLength, BoxHeight, BoxWeight, Actual, ERPCode)
		select X.GoodID, X.PalletTypeID, X.InBox, X.BoxInPal, X.BoxInRow, 
			X.BoxWidth, X.BoxLength, X.BoxHeight, X.BoxWeight, X.Actual, X.ERPCode 
			from #_TPackings X 
			where X.ERPCode not in (select ERPCode from Packings)
if @@Error <> 0 rollback
else commit tran
