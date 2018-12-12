set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsGoodsItemsFill] 
	@nInputID	int, 
	@bTotalQnt	bit = 0, -- только товар и кол-во, без учета состояния товара
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
-- получение списка товаров в приходе без учета реального и фактического состояния (только кол-во)
AS

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs where ID = IsNull(@nInputID, 0)) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден приход с кодом ' + ltrim(str(@nInputID)) + '...'
	raiserror(@cErrorText, 16, 1)
	return
end

select	ID * 1 as ID, @nInputID as InputID, 
		PackingID, GoodStateID, QntWished, QntConfirmed 
	into #InputsGoods 
	from InputsGoods with (nolock) 
	where InputID = IsNull(@nInputID, 0)

if exists(select ID from InputsItems 
			where InputID = IsNull(@nInputID, 0) and 
					str(PackingID) + str(GoodStateID) not in 
						(select str(PackingID) + str(GoodStateID) 
							from #InputsGoods)
		) begin
	insert #InputsGoods 
			(ID, InputID, PackingID, GoodStateID, QntWished, QntConfirmed) 
		select	-min(ID), @nInputID, 
				PackingID, GoodStateID, 0, 0 
			from InputsItems with (nolock) 
			where InputID = IsNull(@nInputID, 0) and 
					str(PackingID) + str(GoodStateID) not in 
						(select str(PackingID) + str(GoodStateID) 
							from #InputsGoods) 
			group by PackingID, GoodStateID
end

if @bTotalQnt = 0 begin
	select PackingID, GoodStateID, sum(Qnt) as Qnt 
		into #InputsItems 
		from InputsItems with (nolock) 
		where InputID = IsNull(@nInputID, 0) 
		group by PackingID, GoodstateID
	
	select  IG.ID, IG.ID as InputGoodID, 
			IG.InputID, 
			IG.GoodStateID, GS.Name as GoodStateName, 
			IG.PackingID, P.GoodID, 
			IG.QntWished, IG.QntConfirmed, 
			IG.QntConfirmed - IG.QntWished as QntDiff,  
			isNull(IA.Qnt, 0) as QntArranged, 
			isNull(IA.Qnt, 0) - IG.QntWished as QntArrangedDiff, 
			IG.QntWished / P.InBox as BoxWished, 
			cast(IG.QntWished / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished, 
			isNull(IA.Qnt, 0) / P.InBox as BoxArranged, 
			cast(isNull(IA.Qnt, 0) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalArranged, 
			IG.QntConfirmed / P.InBox as BoxConfirmed, 
			cast(IG.QntConfirmed / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
			(IG.QntConfirmed - IG.QntWished) / P.InBox as BoxDiff, 
			cast((IG.QntConfirmed - IG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalDiff, 
			(isNull(IA.Qnt, 0) - IG.QntWished) / P.InBox as BoxArrangedDiff, 
			cast((isNull(IA.Qnt, 0) - IG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalArrangedDiff, 
			P.InBox, P.BoxInPal, P.BoxInRow, 
			P.PalletTypeID, PT.Name as PalletTypeName, 
			G.Alias as GoodAlias, G.Name as GoodName, 
			G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
			G.BarCode as GoodBarCode, 
			G.Articul, 
			G.Weighting, G.Retention, 
			GG.Name as GoodGroupName, 
			GB.Name as GoodBrandName, 
			P.BoxHeight 
		from #InputsGoods IG 
		left join #InputsItems IA on IG.PackingID = IA.PackingID and IG.GoodStateID = IA.GoodStateID 
		left join GoodsStates GS with (nolock) on IG.GoodStateID = GS.ID 
		left join Packings P with (nolock) on IG.PackingID = P.ID 
		left join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
		left join Goods G with (nolock) on P.GoodID = G.ID 
		left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
		left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
		where InputID = IsNull(@nInputID, 0) 
		order by G.Alias, IG.ID
end
else begin
	select	IG.PackingID, 
			sum(IG.QntWished) as QntWished, 
			sum(IG.QntConfirmed) as QntConfirmed 
		into	#InputsGoodsQnt 
		from	#InputsGoods IG with (nolock) 
		where	IG.InputID = IsNull(@nInputID, 0) 
		group by IG.PackingID
	
	select PackingID, sum(Qnt) as Qnt 
		into #InputsItemsTotal 
		from InputsItems with (nolock) 
		where InputID = IsNull(@nInputID, 0) 
		group by PackingID
	
	select	@nInputID as InputID, 
			IG.PackingID, P.GoodID, 
			IG.QntWished, IG.QntConfirmed, 
			IG.QntConfirmed - IG.QntWished as QntDiff, 
			isNull(IA.Qnt, 0) as QntArranged, 
			isNull(IA.Qnt, 0) - IG.QntWished as QntArrangedDiff, 
			IG.QntWished / P.InBox as BoxWished, 
			cast(IG.QntWished / P.InBox / P.BoxInPal as decimal(12, 4)) as PalWished, 
			isNull(IA.Qnt, 0) / P.InBox as BoxArranged, 
			cast(isNull(IA.Qnt, 0) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalArranged, 
			IG.QntConfirmed / P.InBox as BoxConfirmed, 
			cast(IG.QntConfirmed / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
			(IG.QntConfirmed - IG.QntWished) / P.InBox as BoxDiff, 
			cast((IG.QntConfirmed - IG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalDiff, 
			(isNull(IA.Qnt, 0) - IG.QntWished) / P.InBox as BoxArrangedDiff, 
			cast((isNull(IA.Qnt, 0) - IG.QntWished) / P.InBox / P.BoxInPal as decimal(12, 4)) as PalArrangedDiff, 
			P.InBox, P.BoxInPal, P.BoxInRow, 
			P.PalletTypeID, PT.Name as PalletTypeName, 
			G.Alias as GoodAlias, G.Name as GoodName, 
			G.Name  + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingName, 
			G.Alias + ' (' + ltrim(str(round(P.InBox, 0))) + ')' as PackingAlias, 
			G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
			G.BarCode as GoodBarCode, 
			G.Weighting, G.Retention, 
			GG.Name as GoodGroupName, 
			GB.Name as GoodBrandName, 
			P.BoxHeight 
		from	#InputsGoodsQnt IG 
		left join #InputsItemsTotal IA on IG.PackingID = IA.PackingID 
		inner join Packings P with (nolock) on IG.PackingID = P.ID 
		left  join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
		inner join Goods G with (nolock) on P.GoodID = G.ID 
		left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
		left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
		-- where 
		order by G.Alias
end
return