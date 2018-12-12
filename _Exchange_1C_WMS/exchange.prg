*-- Заполнение хранилища данными из 1С из готовых файлов
do Exchange_1C_SuitableWMS
*quit
cancel

*-------------------------------------------------------------------------------
procedure Exchange_1C_SuitableWMS
lparameters lcState

private pcXML as String
local lnSec
local loSOAP as MSSoap.SoapClient30
local llResult as Boolean, lcFile as String, lcStr as String, lcRet as String

SQLDisconnect(0)
close all
clear

lnSec = Seconds()
llResult = .T.
lcRet = ""

*-- Создание конектора SOAP
loSOAP = CreateObject("MSSoap.SoapClient30")
if Vartype(loSOAP) <> 'O'
	MessageBox('Cannot create SOAP object!', 16, 'Error', 15000)
	return .F.
endif

*-- Соединение с WebService
local llSuccess
try
	* На компе с установленным прокси команда может облажаться!!!
	loSOAP.MSSoapInit("http://Dalexandrov/SuitableWMS/SuitableWMSWebService.asmx?WSDL")
	llSuccess = .T.
catch
	MessageBox(loSOAP.FaultString + Chr(13) + loSOAP.Detail)
	llSuccess = .F.
endtry

if not llSuccess
	return .F.
endif

*-- Установка свойств соединения
*-- По умолчанию таймаут составляет ~30 сек, меняем на 600 сек
with loSOAP
	.ConnectorProperty("ConnectTimeout") = 600000
	.ConnectorProperty("Timeout") = 600000
endwith

lcFile = 'GoodsStates.xml'
if llSuccess and File(lcFile)
	lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	llSuccess = loSOAP.UpdateGoodsStates(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'GoodsGroups.xml'
if llSuccess and File(lcFile)
	*lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	lcStr = FileToStr(lcFile)
	llSuccess = loSOAP.UpdateGoodsGroups(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'GoodsBrands.xml'
if llSuccess and File(lcFile)
	*lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	lcStr = FileToStr(lcFile)
	llSuccess = loSOAP.UpdateGoodsBrands(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'Goods.xml'
if llSuccess and File(lcFile)
	*lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	lcStr = FileToStr(lcFile)
	llSuccess = loSOAP.UpdateGoods(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'Packings.xml'
if llSuccess and File(lcFile)
	*lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	lcStr = FileToStr(lcFile)
	llSuccess = loSOAP.UpdatePackings(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'Partners.xml'
if llSuccess and File(lcFile)
	lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	llSuccess = loSOAP.UpdatePartners(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'InputsTypes.xml'
if llSuccess and File(lcFile)
	lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	llSuccess = loSOAP.UpdateInputsTypes(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'OutputsTypes.xml'
if llSuccess and File(lcFile)
	lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	llSuccess = loSOAP.UpdateOutputsTypes(lcStr, @lcRet)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

local lcResult as String
lcResult = ''
lcFile = 'Inputs.xml'
if llSuccess and File(lcFile)
	lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	llSuccess = loSOAP.FillInputs(lcStr, @lcRet, @lcResult)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

lcFile = 'Outputs.xml'
if llSuccess and File(lcFile)
	lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
	llSuccess = loSOAP.FillOutputs(lcStr, @lcRet, @lcResult)
	if not llSuccess
		MessageBox(lcFile + ': ' + lcRet)
	endif
endif

*!*	lcFile = 'AuditActs.xml'
*!*	if llSuccess and File(lcFile)
*!*		lcStr = Substr(Strconv(FileToStr(lcFile), 11), 2)
*!*		llSuccess = loSOAP.FillAuditActs(lcStr, @lcRet, @lcResult)
*!*		if not llSuccess
*!*			MessageBox(lcFile + ': ' + lcRet)
*!*		else
*!*			if XMLToCursor(lcResult, '_Result') > 0
*!*				select _Result
*!*				scan all
*!*				? Alltrim(_Result.ERPCode) + ' - ' + Alltrim(_Result.Description)
*!*				endscan
*!*			endif
*!*		endif
*!*	endif



wait window timeout 3 'Fill Data OK!' + Chr(13) + 'Work time: ' + Alltrim(Str(Seconds() - lnSec)) + ' s.'
release loSOAP

close all
return .T.
