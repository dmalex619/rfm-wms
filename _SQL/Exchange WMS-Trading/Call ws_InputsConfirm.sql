declare @cXML varchar(max), @cReport varchar(max)

if object_id('Tempdb..#Text') is not Null drop table #Text
create table #Text (TextValue varchar(max))
bulk insert #Text from 'E:\WMSInputs.xml' with (codepage = 'ACP')
select @cXML = TextValue from #Text

exec ws_InputConfirm @cXML, @cReport output
select @cReport
