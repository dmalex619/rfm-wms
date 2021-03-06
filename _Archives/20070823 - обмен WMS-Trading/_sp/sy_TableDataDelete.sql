set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[sy_TableDataDelete]
-- сохранение данных записи таблицы 
	@cTable			varchar(100),	-- имя таблицы
	@nId			int,			-- Id конкретной записи
	@nError			int = 0 output, 
	@cErrorText		varchar(1000) = '' output 
AS

if object_id(@cTable) is Null begin 
	select	@nError = -1, 
			@cErrorText = 'Не найдена таблица "' + @cTable + '"...'
	return
end

declare @cTableName varchar(1000)
select  @cTableName = TableName + ' (' + Name + ')'
	from _Tables 
	where TableName = @cTableName
if @cTableName is Null
	set @cTableName = @cTable

if @nId <= 0 begin 
	select	@nError = -2, 
			@cErrorText = 'Для удаления из таблицы "' + @cTableName + '" не указан код записи (' + ltrim(str(@nId)) + ')...'
	return
end 

-- список полей таблицы (для проверки наличия поля), identity-поле
select * 
	into	#Structure
	from	Sys.Columns 
	where	Object_ID = object_id(@cTable)
	order by Column_Id
declare @cIdentityField varchar(100) 
select top 1 @cIdentityField = Name
	from	#Structure 
	order by ~Is_Identity, Column_Id

declare @cSql varchar(8000)
set @cSql = ''

-- есть ли нужная запись
if @nId > 0 begin
-- взять поле identity
	set @cSql = 'select * from ' + @cTable + ' where ' + @cIdentityField + ' = ' + str(@nId)
	exec (@cSql)
	if @@RowCount = 0 begin
		select	@nError = -3, 
				@cErrorText = 'В таблице "' + @cTable + '" не найдена запись с кодом ' + ltrim(str(@nId)) + '...'
		return
	end
end

-- проверить связи
create table #KeyInfo -- врем.таблица классификаторов для основной таблицы
	(PKTable_Qualifier sysname, 
	PKTable_Owner sysname, 
	PKTable_Name sysname, 
	PKColumn_Name sysname, 
	FKTable_Qualifier sysname, 
	FKTable_Owner sysname, 
	FKTable_Name sysname, 
	FKColumn_Name varchar(50), 
	Key_Seq smallint, 
	Update_Rule smallint, 
	Delete_Rule smallint, 
	FK_Name sysname, 
	PK_Name sysname, 
	DeferrAbility smallint,
	IsTree Bit)
insert into #KeyInfo 
		(PKTable_Qualifier, PKTable_Owner, PKTable_Name, PKColumn_Name,
		FKTable_Qualifier, FKTable_Owner, FKTable_Name, FKColumn_Name,
		Key_Seq, Update_Rule, Delete_Rule, 
		FK_Name, PK_Name, DeferrAbility)
	execute sp_fKeys @cTable

declare @cFKTable_Name varchar(100), @cFKColumn_Name varchar(100), @cFKTable_FullName varchar(200)
declare C_FKFields cursor for 
	select K.FKTable_Name, K.FKColumn_Name, isNull(T.Name, K.FKTable_Name)
		from #KeyInfo K
		left join _Tables T on K.FKTable_Name = T.TableName
		order by 1
open C_FKFields
fetch next from C_FKFields into @cFKTable_Name, @cFKColumn_Name, @cFKTable_FullName
while @@fetch_status = 0
begin
	-- есть ли запись со ссылкой именно на удаляемый код
	set @cSql = 'select * from ' + @cFKTable_Name + ' where ' + @cFKColumn_Name + ' = ' + str(@nId)
	exec (@cSql)
	if @@RowCount > 0 begin
		select	@nError = -10, 
				@cErrorText = 'В таблице "' + @cFKTable_Name + ' (' + @cFKTable_FullName+ ')' + char(13) + 
					'есть записи, ссылающиеся на запись с кодом ' + ltrim(str(@nId)) + ' в таблице "' + @cTableName + '"...'
		break
	end
	fetch next from C_FKFields into @cFKTable_Name, @cFKColumn_Name, @cFKTable_FullName
end 
close C_FKFields
deallocate C_FKFields

if @nError <> 0
	return

set @cSql = 'delete ' + @cTable + ' where ' + @cIdentityField + ' = ' + str(@nId)
exec (@cSql)
return