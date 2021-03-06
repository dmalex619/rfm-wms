set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
CREATE PROCEDURE [dbo].[up_CellsSaveRank]
	@xCells	Xml = ''
as
set nocount on

declare @nHandle Int, @bIsCells bit
select @bIsCells = case when len(cast(IsNull(@xCells, '') as nvarchar(max))) > 0 then 1 else 0  end

if @bIsCells = 1 begin 
	execute sp_xml_preparedocument @nHandle output, @xCells
	select * into #Cells 
		from openxml (@nHandle, '/DocumentElement/ChangedCells', 1) 
		with (ID Int 'ID', Rank Int 'Rank')
	execute	sp_xml_removedocument @nHandle

	update Cells set Cells.Rank = #Cells.Rank 
		from #Cells 
		where #Cells.ID = Cells.ID
end
return