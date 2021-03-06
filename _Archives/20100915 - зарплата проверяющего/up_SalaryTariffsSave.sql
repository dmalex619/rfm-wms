SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_SalaryTariffsSave]
	@nID		int = 0 output, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output
AS

set nocount on

if object_id('tempdb..#SalaryTariffs') is Null begin
	select	@nError = -1, 
			@cErrorText = 'Нет временной таблицы с тарифами...'
	RaisError(@cErrorText, 11, 1)
	return
end

if	IsNull(@nID, 0) <> 0 and 
		not exists (select ID from SalaryTariffs where ID = @nID) begin
	select	@nError = -2, 
			@cErrorText = 'Не найдены тарифы с кодом ' + ltrim(str(@nID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

begin tran
	if IsNull(@nID, 0) = 0 begin
		insert SalaryTariffs 
				(DateBeg, InputsItemsRelative, AccInputsOperations, 
				MovesUpOperations, MovesDownOperations, MovesFloorOperations, 
				PickOutputsLines, PickOutputsBoxes, PickOutputsNetto, 
				OutputsLines, OutputsBoxes, OutputsNetto, 
				ValidateOutputsLines, ValidateOutputsBoxes, ValidateOutputsNetto, 
				MovingsBoxes, InventoriesCells, 
				UserID, DateInput) 
			select top 1 
					DateBeg, InputsItemsRelative, AccInputsOperations, 
					MovesUpOperations, MovesDownOperations, MovesFloorOperations, 
					PickOutputsLines, PickOutputsBoxes, PickOutputsNetto, 
					OutputsLines, OutputsBoxes, OutputsNetto, 
					ValidateOutputsLines, ValidateOutputsBoxes, ValidateOutputsNetto, 
					MovingsBoxes, InventoriesCells, 
					UserID, GetDate() 
				from #SalaryTariffs
		select	@nID = @@Identity, @nError = @@Error
		if @nError <> 0 goto ERR
	end
	else begin
		update SalaryTariffs 
			set DateBeg = S.DateBeg, 
				InputsItemsRelative = S.InputsItemsRelative, AccInputsOperations = S.AccInputsOperations, 
				MovesUpOperations = S.MovesUpOperations, MovesDownOperations = S.MovesDownOperations, MovesFloorOperations = S.MovesFloorOperations, 
				PickOutputsLines = S.PickOutputsLines, PickOutputsBoxes = S.PickOutputsBoxes, PickOutputsNetto = S.PickOutputsNetto, 
				OutputsLines = S.OutputsLines, OutputsBoxes = S.OutputsBoxes, OutputsNetto = S.OutputsNetto, 
				ValidateOutputsLines = S.ValidateOutputsLines, ValidateOutputsBoxes = S.ValidateOutputsBoxes, ValidateOutputsNetto = S.ValidateOutputsNetto, 
				MovingsBoxes = S.MovingsBoxes, InventoriesCells = S.InventoriesCells, 
				UserID = S.UserID, DateInput = GetDate() 
			from #SalaryTariffs S 
			where SalaryTariffs.ID = @nID and S.ID = @nID
		select @nError = @@Error
		if @nError <> 0 goto ERR
	end

commit tran
return

ERR:
rollback
return