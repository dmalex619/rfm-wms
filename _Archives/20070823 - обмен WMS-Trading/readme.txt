1. ������ WMSBarCode (VB) ������ �� ��������.
��� ������ �� ���� �������.
WMSSuitable:
	frmFrames
	frmInputs

2. ������� ������ ������ 
(���������, ����� ��������� ������������ ����������� ReportViewer)
WMSSuitable:
	Microsoft.ReportViewer.Common
	Microsoft.ReportViewer.WinForms

3. ������ WMSSyClasses (VB) ������ �� ��������.
������ �� ���� � �� Microsoft...VisualBasic � WMSSuitable �������.
������ ���� ��������� �����:
WMSSuitable:
	frmSysLook
	frmSysEdit
	+ ����� frmSysLook �� ���� �� frmMain
WMSBizObjects
	DBTable

4. ��������� ��� � �����
WMSBaseClasses\WMSUserControls
	WMSDateRange
	WMSNumericRange
������������ � ������ �� ��������� ��������
��� ����� ������� �������� (Null) ���������� ���� �� ������ ������ �� �������� "���������"
(���� � ������ ��� ������ �������� �� �����������).
��������.

5. ����� �� 2-� �������:
������ �������� ����� custom-�������� IsFilter = true;
� ������: ��� �������� �� ������ ����������� ��������� ���� ���������, ������� �� ���������� ��������, 
� ���� ��������� ���� - � ������������� ������ Selection ���������� ����� � ��������������� ������ <�����������_restore>, 
� ������� � ��������������� �������� grid.

6. ����� �� ����������������.

7. ���� ����� ����� �������� � ����������� ��-�� Excel
� WMSBaseClasses\WMSContextMenuStrip\WMSContextMenuUtilities.cs
���������������� ������� 14
using Excel = Microsoft.Office.Interop.Excel;

8. � ������ ��_�� (...Fill): 
order by G.Alias ������ G.Name

App.confirg - � ������ �����������



