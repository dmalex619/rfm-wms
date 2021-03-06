set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsSave]
	@nOutputID		int = 0 output,   --   Outputs.ID
	@nHostID		int,  
	@dDateOutput	smalldatetime,
	@nOutputTypeID	int,
	@nOwnerID		int,
	@nGoodStateID	int,
	@nCellID		int,
	@cNote			varchar(250), 
	@cBarCode		varchar(25), 
	@nError			int = 0 output,
	@cErrorText		varchar(200) = '' output 
AS

set nocount on

if	isNull(@nOutputID, 0) <> 0 and 
		not exists (select ID from Outputs with (nolock) where ID = @nOutputID) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден расход с кодом ' + ltrim(str(@nOutputID)) + '...'
	raiserror (@cErrorText, 11, 1);
	return
end

-- владелец-пофигист?
declare @bSeparatePicking bit
set @bSeparatePicking = 0
select	@bSeparatePicking = SeparatePicking
	from	Partners with (nolock) 
	where	ID = @nOwnerID

begin transaction Outtran
	if isNull(@nOutputID, 0) = 0 begin
		-- найти умолчальные значения: владелец, состояние
		if @dDateOutput is Null begin
			select @dDateOutput = convert(smalldatetime, convert(varchar, GetDate(), 1), 1) 
		end 
		if @nOutputTypeID is Null begin 
			select @nOutputTypeID = cast(.dbo._SettingsGetValue('nDefOutputTypeID') as int)
		end
		if @nOwnerID is Null begin
			select @nOwnerID = cast(.dbo._SettingsGetValue('nDefOutputOwnerID') as int)
		end
		if @nGoodStateID is Null begin
			select @nGoodStateID = cast(.dbo._SettingsGetValue('nDefOutputGoodStateID') as int)
			if @nGoodStateID is Null 
				select top 1 @nGoodStateID = ID
					from	GoodsStates 
					where	Basic = 1
		end 
		
		-- добавляем запись о расходе
		insert Outputs (HostID, 
				DateOutput, OutputTypeID, 
				OwnerID, GoodStateID, 
				CellID)
			values (@nHostID, 
				@dDateOutput, @nOutputTypeID, 
				@nOwnerID, @nGoodStateID, 
				@nCellID)
		select	@nOutputID = @@identity, 
				@nError = @@Error
		if @nError <> 0 goto ERR 
	end 
	else begin
		update Outputs 
			set DateOutput = @dDateOutput, 
				OutputTypeID = @nOutputTypeID,  
				OwnerID = @nOwnerID, GoodStateID = @nGoodStateID, 
				CellID = @nCellID
			where ID = @nOutputID
		if @@error > 0 goto ERR
	end 
	
	-- Примечание и Ш/К производственного задания
	if @cNote is not Null 
		update Outputs 
			set Note = @cNote 
			where ID = @nOutputID
	if @cBarCode is not Null
		update Outputs 
			set ERPBarCode = @cBarCode
			where ID = @nOutputID
	
	-- товары-контейнеры
	-- пришел новый товар, который не был заявлен в расходе (#OutputsPallets.OutputGoodID is Null)
	insert	OutputsGoods 
			(OutputID, PackingID, 
			QntWished, QntConfirmed)
		select	@nOutputID, PackingID, 
				0, 0
			from	#OutputsPallets 
			where	/*OutputGoodID is null and */QntConfirmed > 0 and 
					PackingID not in 
						(select PackingID
							from OutputsGoods 
							where OutputID = @nOutputID)
			group by PackingID
	if @@error > 0 goto ERR
	
	-- в тек.контейнерах - ссылка на товар в расходе (незав.от состояния)
	update	#OutputsPallets 
		set		OutputGoodID = IG.ID
		from	OutputsGoods IG 
		where	IG.OutputID = @nOutputID and 
				#OutputsPallets.PackingID = IG.PackingID
	if @@error > 0 goto ERR
	
	-- общее кол-во выданного товара
	update	OutputsGoods 
		set		QntConfirmed = IP.QntConfirmed 
		from	(select OutputGoodID, sum(QntConfirmed) as QntConfirmed
					from	#OutputsPallets 
					group by OutputGoodID
				) IP 
		where OutputID = @nOutputID and OutputsGoods.ID = IP.OutputGoodID
	if @@error > 0 goto ERR
	
	-- удаленные
	delete OutputsGoods 
		where OutputID = @nOutputID and QntWished = 0 and QntConfirmed = 0
	if @@error > 0 goto ERR
	
commit transaction Outtran
return
ERR:
rollback transaction Outtran
