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
		not exists (select ID from Inputs where ID = @nInputID) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден приход № ' + ltrim(str(@nInputID)) + '...'
	RAISERROR (@cErrorText, 11, 1);
	return
end

-- все товары прихода
select	IG.InputID, IG.ID * 1 as InputGoodID, 
		IG.PackingID, 
		(case when I.DateConfirm is null then IG.QntWished else IG.QntConfirmed end) as Qnt, 
		P.InBox, IG.BoxInPal, 
		floor((case when I.DateConfirm is null then IG.QntWished else IG.QntConfirmed end) / (P.InBox * IG.BoxInPal)) as FullPallets
	into	#InputsGoodsFullPallets
	from	InputsGoods IG
	inner join Inputs I on IG.InputID = I.ID
	inner join Packings P on IG.PackingID = P.ID
	where	IG.InputID = @nInputID
-- все паллеты прихода
select	InputID, InputGoodID, PackingID, Qnt, InBox, BoxInPal, FullPallets
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

select	T.InputID, T.InputGoodID, 
		G.Alias as GoodAlias, G.Name as GoodName,
		G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingAlias,
		G.Name + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName,
		T.PackingID, T.InBox, T.BoxInPal, 
		IG.BoxInRow, IG.PalletTypeID, 
		T.Qnt, 
		T.Qnt / T.InBox as Box, 
		T.Qnt / T.InBox / T.BoxInPal as Pal, 
		G.Weighting
	from	#InputsGoodsPallets T
	inner join InputsGoods IG on T.InputGoodID = IG.ID
	inner join Packings P on T.PackingID = P.ID
	inner join Goods G on P.GoodID = G.ID
	order by G.Alias, IG.ID