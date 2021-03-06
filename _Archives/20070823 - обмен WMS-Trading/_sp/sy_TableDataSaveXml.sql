set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[sy_TableDataSaveXml]
	@cTable			varchar(100),	-- имя таблицы
	@nId			int = 0 output,  
	@xXml			xml = Null, 
	@cTableRecordToSave varchar(100) = 'TableRecordToSave', -- имя сохраняемой таблицы в DS
	@nError			int = 0 output, 
	@cErrorText		varchar(1000) = '' output
AS

/*
declare	
	@cTable		varchar(100),
	@nId		int ,  
	@xXml		xml , 
	@nError		int , 
	@cErrorText	varchar(1000) 
select 
	@cTable		= 'XYZ', 
	@nId		= 0,  
	@nError		= 0, 
	@cErrorText	= '', 
	@xXml		= 
'<?xml version="1.0" standalone="yes"?>
<NewDataSet>
  <RecordToSave>
    <name>QQQ</name>
    <code>.Null.</code>
    <value>22,00</value>
    <dt>25.12.2006 0:00:00</dt>
    <actual>True</actual>
  </RecordToSave>
</NewDataSet>'
drop table #structure
*/

if object_id(@cTable) is Null begin 
	select	@nError = -1, 
			@cErrorText = 'Не найдена таблица "' + @cTable + '"...'
	return
end

-- структура
select  Name, Object_Id, Column_Id, 
		System_Type_Id, upper(Type_Name(System_Type_Id)) as System_Type, 
		Max_Length, Precision, Scale,
		Is_Identity, Is_RowGuidCol, Is_Computed, Is_NullAble, 
		Default_Object_Id
	into #Structure
	from	Sys.Columns 
	where	Object_ID = object_id(@cTable)
	order by ~Is_Identity, Column_Id

declare @сFieldIdentity varchar(100)
select	@сFieldIdentity = Name
	from	#Structure 
	where	Is_Identity = 1
if @сFieldIdentity is Null begin 
	select	@nError = -2, 
			@cErrorText = 'В таблице "' + @cTable + '" отсутствует identity-поле...'
	return
end

-- получили xml
declare @nDoc as int
execute sp_xml_preparedocument @nDoc output, @xXml
if @nDoc < 0 begin
	select	@nError = -3, 
			@cErrorText = 'Неверный xml-файл для сохранения данных в таблицу "' + @cTable + '"...'
	return
end

declare @cFieldsStructure varchar(4000), 
		@cFieldsList varchar(4000), 
		@cSqlInsert varchar(4000), @cSqlUpdate varchar(4000),  
		@cField varchar(100), @cSystemType varchar(100), 
		@nMaxLen int, @nPrecision int, @nScale int 
select	@cFieldsStructure = '', @cFieldsList = '', 
		@cSqlInsert = '', @cSqlUpdate = ''
declare C_Fields cursor for 
	select	Name, System_Type, 
			Max_Length, Precision, Scale
		from #Structure
		where Is_Identity = 0 and Is_Computed = 0
open C_Fields
fetch next from C_Fields into @cField, @cSystemType, @nMaxLen, @nPrecision, @nScale
while @@fetch_status = 0
begin
	select @cFieldsList = @cFieldsList + ',' + @cField
	if charindex('DECIMAL', @cSystemType) > 0 or charindex('NUMERIC', @cSystemType) > 0 
		-- преобразовать десятичный разделитель из , в .
		select	@cSqlInsert = @cSqlInsert + ',replace(' + @cField + ', '','', ''.'') as ' + @cField, 
				@cSqlUpdate = @cSqlUpdate + ',' + @cField + '=replace(X.' + @cField + ', '','', ''.'')'
	else 
		if charindex('DATE', @cSystemType) > 0
			-- преобразовать дату из 25.03.2007->20070325
			select	@cSqlInsert = @cSqlInsert + ',cast(substring(' + @cField + ',7,4)+substring(' + @cField + ',4,2)+substring(' + @cField + ',1,2) as datetime) as ' + @cField, 
					@cSqlUpdate = @cSqlUpdate + ',' + @cField + '=cast(substring(X.' + @cField + ',7,4)+substring(X.' + @cField + ',4,2)+substring(X.' + @cField + ',1,2) as datetime)'
		else 
			select	@cSqlInsert = @cSqlInsert + ',' + @cField, 
					@cSqlUpdate = @cSqlUpdate+ ',' + @cField + '=X.' + @cField

	select  @cFieldsStructure = @cFieldsStructure + ',' + @cField + ' ' + 
			case when charindex('CHAR', @cSystemType) > 0 
					then @cSystemType + ' (' + ltrim(str(@nMaxLen)) + ')' 
				 when charindex('DECIMAL', @cSystemType) > 0 or charindex('NUMERIC', @cSystemType) > 0 or 
						charindex('DATE', @cSystemType) > 0
					then 'nvarchar (100)' 
				else @cSystemType end + 
			' ''' + @cField + ''''
	fetch next from C_Fields into @cField, @cSystemType, @nMaxLen, @nPrecision, @nScale
end 
close C_Fields
deallocate C_Fields
if left(@cFieldsStructure, 1) = ','
	set @cFieldsStructure = substring(@cFieldsStructure, 2, len(@cFieldsStructure) - 1)
if left(@cFieldsList, 1) = ','
	set @cFieldsList = substring(@cFieldsList, 2, len(@cFieldsList) - 1)
if left(@cSqlInsert, 1) = ','
	set @cSqlInsert = substring(@cSqlInsert, 2, len(@cSqlInsert) - 1)
if left(@cSqlUpdate, 1) = ','
	set @cSqlUpdate = substring(@cSqlUpdate, 2, len(@cSqlUpdate) - 1)

declare @cESql nvarchar(4000) -- специально для использования sp_executesql 
if @nId > 0 
	-- редактирование записи
	select @cESql = 'update ' + @cTable + ' set ' + @cSqlUpdate + ' ' + 
		'from (' + 
			'select ' + @cFieldsList + ' ' + 
				'from openxml (@nDoc, ''//' + @cTableRecordToSave + ''', 0) ' +
				'with (' + @cFieldsStructure + ')' + 
				') X ' +
		'where ' + @cTable + '.' + @сFieldIdentity + '=' + ltrim(str(@nId))
else
	-- добавление записи
	select @cESql = 'insert ' + @cTable + ' (' + @cFieldsList + ') ' + 
		'select ' + @cSqlInsert + ' ' + 
			'from openxml (@nDoc, ''//' + @cTableRecordToSave + ''', 0) ' +
			'with (' + @cFieldsStructure + ')'
exec sp_executesql @cESql, N'@nDoc int', @nDoc = @nDoc

if @nId = 0 begin
	-- добавление записи
	select @nId = @@identity
end
return