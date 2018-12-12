set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_AuditActsGoodsFill] 
	@nAuditActID	int, 
	@nError			int = 0 output, 
	@cErrorText		varchar(200) = '' output 
AS

set nocount on

if	@nAuditActID <> 0 and not exists (select ID from AuditActs where ID = @nAuditActID) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден акт с кодом ' + ltrim(str(@nAuditActID)) + '...'
	raiserror(@cErrorText, 16, 1)
	return
end

select  IG.ID, IG.ID as AuditActGoodID, 
		IG.AuditActID, 
		IG.PackingID, P.GoodID, 
		IG.QntConfirmed, 
		IG.QntConfirmed / P.InBox as BoxConfirmed, 
		cast(IG.QntConfirmed / P.InBox / P.BoxInPal as decimal(12, 4)) as PalConfirmed, 
		P.InBox, P.BoxInPal, P.BoxInRow, 
		P.PalletTypeID, PT.Name as PalletTypeName, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
		G.Articul, 
		G.BarCode as GoodBarCode, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName
	from AuditActsGoods IG with (nolock) 
	left join Packings P with (nolock) on IG.PackingID = P.ID 
	left join PalletsTypes PT with (nolock) on P.PalletTypeID = PT.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	where AuditActID = IsNull(@nAuditActID, 0) 
	order by G.Alias, IG.ID
return