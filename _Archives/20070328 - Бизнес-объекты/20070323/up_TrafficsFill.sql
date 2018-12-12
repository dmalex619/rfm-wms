set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

alter PROCEDURE [dbo].[up_TrafficsFill]
	@nID				int = Null, 
	@bSuccess			bit = Null, -- ������� �����������?
	@dDateBeg			smalldatetime = Null, -- ���� ���.������� (��� DateSend)
	@dDateEnd			smalldatetime = Null, -- ���� ���.������� (��� DateSend)
	@cUsersList			varchar(max)  = Null, -- ������ ����� �������� (�����,)
	@nFrameID			int = Null, -- ���������
	@nCellSourceID		int = Null, -- ������-��������
	@nCellTargetID		int = Null	-- ������-��������
AS
BEGIN

	select	@cUsersList = replace(@cUsersList, ' ', '')

	select	T.ID, T.ID as TrafficID,
			T.PreviousTrafficID, 
			T.FrameID, F.BarCode as FrameBarCode, 
			T.CellSourceID, CS.Address as CellSourceAddress, CS.BarCode as CellSourceBarCode, 
			T.CellTargetID, CS.Address as CellTargetAddress, CS.BarCode as CellTargetBarCode, 
			T.Priority, T.ByOrder, 
			T.DateBirth, T.DateSend, T.DateAccept, T.DateConfirm, 
			T.Success, 
			T.UserID, T.DeviceID, 
			T.ErrorID, TE.Name as TrafficErrorName, TE.Severity as TrafficErrorSeverity, 
			U.Name as UserName, 
			D.Name as DeviceName
		from Traffics T 
		left join Frames F on F.ID = T.FrameID
		left join Cells CS on CS.ID = T.CellSourceID
		left join Cells CT on CT.ID = T.CellTargetID
		left join TrafficsErrors TE on TE.ID = T.ErrorID
		left join _Users U on U.ID  = T.UserID
		left join Devices D	on D.ID  = T.DeviceID
		where	(@nID is not Null and @nID = T.ID) 
			or 
				(
				  @nId is Null and 
				 (@bSuccess is Null or
					T.Success = @bSuccess) and 
				 (@dDateBeg is Null or 
					datediff(day, @dDateBeg, T.DateSend) >= 0) and 
				 (@dDateEnd is Null or 
					datediff(day, T.DateSend, @dDateEnd) >= 0) and 
				 (@cUsersList is Null or 
					charindex(',' + ltrim(str(T.UserID)) + ',', ',' + @cUsersList + ',') > 0) and 
				 (@nFrameID is Null or 
					T.FrameID = FrameID) and 
				 (@nCellSourceID is Null or 
					T.CellSourceID = @nCellSourceID) and 
				 (@nCellTargetID is Null or 
					T.CellTargetID = @nCellTargetID) 
				)
		order by T.DateSend, U.Name, T.ID
END
