SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_GoodsABCRankFill]
	@dDateBeg	smalldatetime, 
	@dDateEnd	smalldatetime,
	@nError		int output,
	@cErrorText	varchar(100) output
as

set nocount on

declare @nAPercent int, @nBPercent int, @nDays int
select @nAPercent = 80, @nBPercent = 15, @nDays = 90

if datediff(day, @dDateEnd, getdate()) < 0 begin
	select @nError = -1, @cErrorText = 'Дата окончания расчета должна равняться сегодняшнему числу'
	return
end
if datediff(day, @dDateBeg, @dDateEnd) < 90 begin
	select @nError = -2, @cErrorText = 'Интервал расчета не должен быть меньше 90 дней'
	return
end
	
set @nError = 0

declare @nTotalOutNetto decimal (20,3)
select  @nTotalOutNetto = IsNull(sum(OG.QntConfirmed * G.Netto), 0) 
	from OutputsGoods OG 
	inner join Outputs O on OG.OutputID = O.ID 
	inner join Packings P on P.ID = OG.PackingID 
	inner join Goods G on G.ID = P.GoodID 
	where	datediff(day,Dateconfirm, @dDateBeg) < 0 and 
			datediff(day,Dateconfirm, @dDateEnd) > 0 and 
			G.Actual = 1 and P.Actual = 1

select P.GoodID, (sum(OG.QntConfirmed * G.Netto)/@nTotalOutNetto) * 100 as RankPercent 
	into #_Ranking 
	from OutputsGoods OG 
	inner join Outputs O on OG.OutputID = O.ID 
	inner join Packings P on P.ID = OG.PackingID 
	inner join Goods G on G.ID = P.GoodID 
	where	datediff(day,Dateconfirm, @dDateBeg) < 0 and 
			datediff(day,Dateconfirm, @dDateEnd) > 0 and 
			G.Actual = 1  and P.Actual = 1 
	group by P.GoodID

declare @nTemp decimal(8,4), @cRank char(1), @nI int
select @nTemp = 0, @cRank = 'A', @nI = 1

declare @nGoodID int, @nRankPercent decimal(7,4)
declare _Ranking cursor static
	for select GoodID, RankPercent 
	from #_Ranking 
	order by  RankPercent desc
open _RanKing
begin transaction
	update Goods set ABCRank = ''
	fetch next from _Ranking into @nGoodID, @nRankPercent
	while @@fetch_status = 0 begin
		if @nTemp > @nAPercent and @nTemp <= (@nAPercent + @nBPercent) begin
			if @cRank <> 'B'
				select @cRank = 'B', @nI = 1
		end
		else begin
			if @nTemp > @nAPercent + @nBPercent begin
				if @cRank <> 'C'
					select @cRank = 'C', @nI = 1
			end
		end
		update Goods 
			set ABCRank = @cRank + right('0000'+cast(@nI as varchar(4)), 4) 
			where 	Goods.ID = @nGoodID
		set @nError = @@Error
		if @nError <> 0
			goto _END	
		select @nTemp = @nTemp + @nRankPercent, @nI = @nI + 1
		fetch next from _Ranking into @nGoodID, @nRankPercent
	end
	update Goods set ABCRank = 'C9999' 
		where len(ABCRank) = 0 and Actual = 1
	
_END:	
	close _RanKing
	deallocate _RanKing
	if @nError <> 0 begin
		if @@trancount > 0
			rollback transaction
		return
	end
commit transaction
return