set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[ws_WHDraftsD_ToWms]
-- Процедура для выгрузки данных о съеме контейнеров 
-- выполняется в Trading, строит xml
-- можно использовать только select-ы
AS
set nocount on

select	Uniq
	into	#WHDrafts 
	from	WHDrafts D
	where	DateConfirm is not Null and 
			WMSSent = 0 and 
			datediff(day, DateConfirm, getdate()) <= 2 -- ? дата выполнения съема 
			-- предварительно надо заполнить 
			-- update WHDrafts set WMSSent = 1 where DraftType = 'D' and DateConfirm is not Null 

select	D.Uniq, 
		D.DateConfirm, 
		D.Depot, Dp.Owner, Dp.WMSGoodState
	from	WHDrafts D
	inner join #WHDrafts TD on D.Uniq = TD.Uniq 
	left join Depots Dp on D.Depot = Dp.Uniq

select	DG.Uniq, 
		DG.WHDraft, 
		DG.Packing, P.Good, P.InBox, 
		DG.Cell, DG.CellAddress, 
		DG.QntWished, DG.QntConfirmed, DG.DateValid
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


