set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_FramesFill]
	@nId				int = Null, 
	@cBarCode			varchar(100) = Null, -- штрих-код контейнера
	@bActual			bit = Null, -- актуальные контейнеры?
	@cOwnersList		varchar(max) = Null, -- список владельцев через ,
	@cGoodsStatesList	varchar(max) = Null, -- список состояний товара через ,
	@cFramesStatesStr	varchar(max) = Null  -- строка статусов контейнера
AS
BEGIN

-- получение выборки по динамически составленной строке (exec)

if @cOwnersList is not Null begin 
	if left(@cOwnersList, 1) = ','
		set @cOwnersList = substring(@cOwnersList, 2, len(@cOwnersList))
	if right(@cOwnersList, 1) = ','
		set @cOwnersList = left(@cOwnersList, len(@cOwnersList) - 1)
end 
if @cGoodsStatesList is not null begin 
	if left(@cGoodsStatesList, 1) = ','
		set @cGoodsStatesList = substring(@cGoodsStatesList, 2, len(@cGoodsStatesList))
	if right(@cGoodsStatesList, 1) = ','
		set @cGoodsStatesList = left(@cGoodsStatesList, len(@cGoodsStatesList) - 1)
end
if @cFramesStatesStr is not null begin 
	if charindex(',', @cFramesStatesStr) > 0
		set @cFramesStatesStr = replace(@cFramesStatesStr, ',', '')
end

declare @cSql varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)
select @cSql = 
	'select	F.ID, F.ID as FrameID, F.BarCode, F.DateBirth, F.DateLAstOperation, F.GoodsMono, ' + 
			'F.State, F.Actual, ' +
			'F.OwnerID, Ow.Name as OwnerName, ' +
			'F.GoodStateID, GS.Name as GoodStateName ' +
		'from Frames F ', 
	@cWhere = 'where 1 = 1 ', 
	@cOrderBy = 'order by F.BarCode, F.ID '

if isNull(@nId, 0) > 0 or isNull(@cBarCode, '') > '' 

	select @cSql = @cSql + 
			'left join Partners Ow on F.OwnerID = Ow.ID ' +
			'left join GoodsStates GS on F.GoodStateID = GS.ID '
	if @nId is not null 
		select @cWhere = @cWhere + ' and F.ID = ' + str(@nId) 
	if @cBarCode is not null 
		select @cWhere = @cWhere + ' and F.BarCode = ''' + rtrim(ltrim(@cBarCode)) + ''''

else begin

	if @bActual is not Null
		select @cWhere = @cWhere + 'and F.Actual = ' + ltrim(str(@bActual))

	if isNull(@cOwnersList, '') > '' 
		select @cSql = @cSql + 
			'inner join Partners Ow on F.OwnerID = Ow.ID ', 
			@cWhere = @cWhere + 'and Ow.ID in (' + @cOwnersList + ') '
	else 
		select @cSql = @cSql + 
			'left join Partners Ow on F.OwnerID = Ow.ID '

	if isNull(@cGoodsStatesList , '') > '' 
		select @cSql = @cSql + 
			'inner join GoodsStates GS on F.GoodStateID = GS.ID ', 
			@cWhere = @cWhere + 'and GS.ID in (' + @cGoodsStatesList + ') '
	else 
		select @cSql = @cSql + 
			'left join GoodsStates GS on F.GoodStateID = GS.ID '

	if len(isNull(@cFramesStatesStr, '')) > 0
		select @cWhere = @cWhere + 'and charindex(F.State,''' + @cFramesStatesStr + ''') > 0 '

end

exec (@cSql + @cWhere + @cOrderBy)

END
