set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsPalletsEachFill]
	@nInputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs where ID = IsNull(@nInputID, 0)) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден приход с кодом ' + ltrim(str(@nInputID)) + '...'
	raiserror (@cErrorText, 11, 1)
	return
end

-- все товары прихода
select	IG.InputID, IG.ID * 1 as InputGoodID, 
		IG.PackingID, 
		(case when I.DateConfirm is null then IG.QntWished else IG.QntConfirmed end) as Qnt, 
		P.InBox, P.BoxInPal, 
		floor((case when I.DateConfirm is null 
					then IG.QntWished 
					else IG.QntConfirmed end) 
					/ (P.InBox * P.BoxInPal)) as FullPallets
	into	#InputsGoodsFullPallets
	from	InputsGoods IG with (nolock) 
	inner join Inputs I with (nolock) on IG.InputID = I.ID
	inner join Packings P with (nolock) on IG.PackingID = P.ID
	where	IG.InputID = IsNull(@nInputID, 0)
-- все паллеты прихода
select	InputID, InputGoodID, PackingID, Qnt, InBox, BoxInPal, FullPallets, 
		cast(0 as int) as RestBox, cast(0 as decimal(18, 3)) as RestQnt
	into	#InputsGoodsPallets
	from	#InputsGoodsFullPallets
	where	1 = 2 

-- все товары накладной, 1 строка на паллету
declare @nInputGoodID int, 
		@nPackingID smallint, @nQnt numeric(12, 3), @nInBox numeric(10, 3), @nBoxInPal int, 
		@nFullPallets int, @nQntIn numeric(12,3)
declare C_Pallets cursor for 
	select InputGoodID, PackingID, Qnt, InBox, BoxInPal, FullPallets
		from #InputsGoodsFullPallets
open  C_Pallets
fetch next from C_Pallets
	into @nInputGoodID, @nPackingID, @nQnt, @nInBox, @nBoxInPal, @nFullPallets

while @@fetch_status = 0 begin
	set @nQntIn = 0
	
	-- добавляем по 1 строке на каждую целую паллету
	while @nFullPallets > 0 begin	
		insert  #InputsGoodsPallets 
				(InputID, InputGoodID, PackingID, Qnt, InBox, BoxInPal, FullPallets)
			values 	(@nInputID, @nInputGoodID, @nPackingID, @nInBox * @nBoxInPal, @nInBox, @nBoxInPal, 1)
		set @nFullPallets = @nFullPallets - 1
		set @nQntIn = @nQntIn + @nInBox * @nBoxInPal
	end
	
	-- и еще 1 строку на остаток
	if @nQnt - @nQntIn > 0
		insert  #InputsGoodsPallets 
				(InputID, InputGoodID, PackingID, Qnt, InBox, BoxInPal, FullPallets)
			values 	(@nInputID, @nInputGoodID, @nPackingID, @nQnt - @nQntIn, @nInBox, @nBoxInPal, 0)
	fetch next from C_Pallets 
		into @nInputGoodID, @nPackingID, @nQnt, @nInBox, @nBoxInPal, @nFullPallets
end
close C_Pallets		
deallocate C_Pallets

update	#InputsGoodsPallets
	set RestBox = floor(Qnt / InBox)
update	#InputsGoodsPallets
	set RestQnt = Qnt - RestBox * InBox

select	T.InputID, T.InputGoodID, 
		T.PackingID, T.InBox, T.BoxInPal, P.BoxInRow, 
		T.Qnt, 
		T.Qnt / T.InBox as Box, 
		cast(T.Qnt / T.InBox / T.BoxInPal as decimal(12, 4)) as Pal, 
		T.RestBox, T.RestQnt, 
		T.FullPallets, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName
	from	#InputsGoodsPallets T
	inner join InputsGoods IG with (nolock) on T.InputGoodID = IG.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID
	left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID
	order by G.Alias, IG.ID
return