set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OddmentsFill]
	@nID				int				= Null, -- ID записи в таблице Oddments 
	@cOwnersList		varchar(max)	= Null, -- список владельцев (через ,)
	@cGoodsStatesList	varchar(max)	= Null, -- список состояний товара (через ,)
	@cPackingsList		varchar(max)	= Null, -- список упаковок (через ,)
	@cGoodsList			varchar(max)	= Null, -- список товаров (через ,)
	@nIsExists			int				= Null, -- есть в остатках? (CellsContents)  0: =0, 1: >0, -1: <0
	-- по сроку годности
	@nCheckDateValid	int				= Null -- Null без анализа, % осталось менее, -1 просрочен, -2 завышен
AS

set nocount on

declare @dNow smalldatetime, @cNow varchar(8)
select	@dNow = GetDate()
select  @cNow = convert(varchar, @dNow, 112)

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- расчетные остатки, сумма по ячейкам
select	ID * 1 as ID, OwnerID, GoodStateID, PackingID, Qnt, DateValid 
	into #CellsContents
	from CellsContents with (nolock) 
	where 1 = 2

set @cSelect = 
'insert #CellsContents (ID, OwnerID, GoodStateID, PackingID, Qnt, DateValid) 
	select	CC.ID, CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid 
		from CellsContents CC with (nolock) 
		left join Packings P with (nolock) on CC.PackingID = P.ID
		left join Goods G with (nolock) on P.GoodID = G.ID '

set @cWhere = ' where 1 = 1 '
if @cOwnersList is not Null 
	set @cWhere = @cWhere + ' and CC.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
if @cGoodsStatesList is not Null 
	set @cWhere = @cWhere + ' and CC.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
if @cPackingsList is not Null
	set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
if @cGoodsList is not Null
	set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '

if @nCheckDateValid is not Null begin 
	if @nCheckDateValid = -1 -- просрочен
		set @cWhere = @cWhere + ' and CC.DateValid is not Null 
			and datediff(day, CC.DateValid, ''' + @cNow + ''') > 0 ' 
	if @nCheckDateValid = -2 -- завышен
		set @cWhere = @cWhere + ' and CC.DateValid is not Null 
			and G.Retention >= 30 
			and datediff(day, dateadd(day, G.Retention, ''' + @cNow + '''), CC.DateValid) > 0 '
	if @nCheckDateValid between 0 and 100 -- %
		set @cWhere = @cWhere + ' and CC.DateValid is not Null 
			and datediff(day, ''' + @cNow + ''', CC.DateValid) > 0 
			and datediff(day, CC.DateValid, dateadd(day, G.Retention * ' + str(@nCheckDateValid) + ' / 100, ''' + @cNow + ''')) > 0 '
end 
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select	min(ID) as ID, OwnerID, GoodStateID, PackingID, 
		sum(Qnt) as Qnt, cast(0 as decimal(15, 3)) as QntStor, 
		str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) as IndexStr 
	into	#CalcOddments 
	from	#CellsContents 
	group by OwnerID, GoodStateID, PackingID 
create index IX_Tmp_CalcOddments on #CalcOddments (IndexStr)

-- текущие остатки, по таблице Oddments
select ID * 1 as ID, OwnerID, GoodStateID, PackingID, Qnt, 
	str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) as IndexStr  
	into #Oddments 
	from Oddments with (nolock) 
	where 1 = 2
create index IX_Tmp_Oddments on #Oddments (IndexStr)

set @cSelect = 
'insert #Oddments (ID, OwnerID, GoodStateID, PackingID, Qnt) 
	select	O.ID, O.OwnerID, O.GoodStateID, O.PackingID, O.Qnt
		from	Oddments O with (nolock) 
		left join Packings P on O.PackingID = P.ID
		left join Goods G on P.GoodID = G.ID '
if @nID is not Null 
	set @cWhere = ' where O.ID = ' + str(@nID)
else begin 
	set @cWhere = ' where 1 = 1 '
	if @cOwnersList is not Null 
		set @cWhere = @cWhere + ' and O.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	if @cGoodsStatesList is not Null 
		set @cWhere = @cWhere + ' and O.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and O.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @cGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '
end 
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

if @nCheckDateValid is not Null begin
	delete #Oddments 
		where IndexStr not in (select IndexStr from #CalcOddments)
--		where str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) not in 
--					(select str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) from #CalcOddments)
end

select	ID * 1 as ID, OwnerID, GoodStateID, PackingID, 
		cast(0 as decimal(15, 3)) as Qnt, Qnt as QntStor, 
		str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) as IndexStr 
	into	#StorOddments 
	from	#Oddments with (nolock)
create index IX_Tmp_StorOddments on #StorOddments (IndexStr)

update	#StorOddments 
	set Qnt = CO.Qnt 
	from	#CalcOddments CO 
	where	IsNull(#StorOddments.OwnerID, -1) = IsNull(CO.OwnerID, -1) and 
			#StorOddments.GoodStateID = CO.GoodStateID and 
			#StorOddments.PackingID = CO.PackingID

-- есть расчетные остатки, но нет сохраненных
insert	#StorOddments 
		(ID, OwnerID, GoodStateID, PackingID, Qnt, QntStor) 
	select	 -ID, OwnerID, GoodStateID, PackingID, Qnt, 0 
		from	#CalcOddments 
		where	IndexStr not in (select IndexStr from #StorOddments)
--		where	str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) not in 
--					(select str(IsNull(OwnerID, -1)) + str(GoodStateID) + str(PackingID) from #StorOddments)

-- итоговая выборка
set @cSelect = 
'select	O.ID, O.ID as OddmentID, 
		O.OwnerID, Ow.Name as OwnerName, Ow.SeparatePicking, 
		O.GoodStateID, GS.Name as GoodStateName, 
		O.Qnt, O.QntStor, 
		O.Qnt / P.InBox as BoxQnt, 
		cast(O.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		O.Qnt * G.Netto as NettoQnt, 
		O.PackingID, P.GoodID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		cast(case	when G.Actual is Null or P.Actual is Null then Null 
					when G.Actual = 1 and P.Actual = 1 then 1 
					else 0 end as bit) as GoodAndPackingActual, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal 
	from	#StorOddments O 
	left join Partners Ow with (nolock) on O.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on O.GoodStateID = GS.ID 
	left join Packings P with (nolock) on O.PackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID '
if @nID is not Null 
	set @cWhere = ' where O.ID = ' + str(@nID)
else begin 
	set @cWhere = ' where 1 = 1 '
	if @nIsExists is not Null
		set @cWhere = @cWhere + (case when @nIsExists = 0  then ' and O.Qnt = 0 ' 
									  when @nIsExists = 1  then ' and O.Qnt > 0 ' 
									  when @nIsExists = -1 then ' and O.Qnt < 0 ' end)  
end
set @cOrderBy = ' order by Ow.Name, GS.Name, G.Alias, O.ID '

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return