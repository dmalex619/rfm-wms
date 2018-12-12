set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE FUNCTION [dbo].[GetSalaryTariff] 
(
	@dDate	smalldatetime, 
	@cMode	varchar(100), 
	@bMoney	bit 
)
RETURNS money
AS
BEGIN
	declare @nTariff money
	if @bMoney = 0
		select @nTariff = 1
	else
		select top 1 @nTariff = case 
				when @cMode = 'InputsItemsRelative' then InputsItemsRelative 
				when @cMode = 'AccInputsOperations' then AccInputsOperations 
				when @cMode = 'MovesUpOperations' then MovesUpOperations 
				when @cMode = 'MovesDownOperations' then MovesDownOperations 
				when @cMode = 'MovesFloorOperations' then MovesFloorOperations 
				when @cMode = 'PickOutputsLines' then PickOutputsLines 
				when @cMode = 'PickOutputsBoxes' then PickOutputsBoxes 
				when @cMode = 'PickOutputsNetto' then PickOutputsNetto 
				when @cMode = 'OutputsLines' then OutputsLines 
				when @cMode = 'OutputsBoxes' then OutputsBoxes 
				when @cMode = 'OutputsNetto' then OutputsNetto 
				when @cMode = 'MovingsBoxes' then MovingsBoxes  
				when @cMode = 'InventoriesCells' then InventoriesCells 
				else 0 end 
			from SalaryTariffs with (nolock) 
			where datediff(day, DateBeg, @dDate) >= 0 
			order by DateBeg desc
	return isNull(@nTariff, 0)
END