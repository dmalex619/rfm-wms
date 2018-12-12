declare @cXML varchar(max), @nError int, @cReport varchar(max)

if object_id('Tempdb..#Text') is not Null drop table #Text
create table #Text (TextValue varchar(max))
bulk insert #Text from 'E:\WMSCells.xml' with (codepage = 'ACP')
select @cXML = TextValue from #Text

exec ws_CellsConvertWMS @cXML, @nError output, @cReport output
select @nError, @cReport
