close all
clear all
clear

SQLDisconnect(0)

lcDsnLess = [DRIVER={SQL Server};] + ;
			[SERVER=Local-WMS;] + ;
			[DATABASE=WMS;] + ;
			[UID=sa;] + ;
			[PWD=malibu;]
lnConn = SqlStringConnect(lcDsnLess)
if lnConn < 0
	pcMess = 'Cannot connect to SQL server!'
	*Fputs(pnHandle, pcMess)
	MessageBox(pcMess, 16, 'Error', 15000)
	return .F.
endif

local lcPath, lcMask
*lcPath = 'H:\SuitableWMS\Setup Mobile\SymbolReplace\Application\WMSMobile\'
*lcPath = 'E:\VS Projects\WMSMobile\WMSMobileCAB\Release\'
lcPath = 'C:\'
lcMask = 'WMSMobile.CAB'

private pcName, pcPath, pnSize, pdDate, pcBody

local AFiles(1)
ADir(AFiles, lcPath + lcMask)

if Vartype(AFiles(1)) = 'C'
	for i = 1 to Alen(AFiles, 1)
		? AFiles(i, 1) + Space(5) + Str(AFiles(i, 2)) + Space(5) + Dtoc(AFiles(i, 3))
		pcName	= AFiles(i, 1)
		pcPath	= '\Application\WMSMobile\'
		pnSize	= AFiles(i, 2)
		pdDate	= AFiles(i, 3)
		pcBody	= CreateBinary(FileToStr(lcPath + AFiles(i, 1)))
		
		lcStr = [declare @nID int; select top 1 @nID = ID from _MobileFiles where FileName = ?pcName; ] + ;
				[if @nID is Null begin ] + ;
					[insert into _MobileFiles (FileName, FilePath, FileSize, FileDate, FileBody) ] + ;
					[values (?pcName, ?pcPath, ?pnSize, ?pdDate, ?pcBody); ] + ;
					[select @nID = @@Identity; end; ] + ;
				[else update _MobileFiles set FileSize = ?pnSize, FileDate = ?pdDate, FileBody = ?pcBody where ID = @nID; ] + ;
				[select FileBody from _MobileFiles where ID = @nID;]
		if SQLExec(lnConn, lcStr) <> 1
			AError(laError)
			MessageBox('Cannot fill table _MobileFiles!' + Chr(13) + Chr(10) + laError(2), 16, 'Error', 15000)
			exit
		else
			select SQLResult
			*StrToFile(SQLResult.FileBody, 'E:\123.cab')
		endif
	next
endif


SQLDisconnect(0)
