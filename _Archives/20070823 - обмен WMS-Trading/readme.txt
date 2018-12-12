1. Проект WMSBarCode (VB) удален из солюшена.
Все ссылки на него удалены.
WMSSuitable:
	frmFrames
	frmInputs

2. Удалены лишние ссылки 
(появились, когда пробовали использовать стандартный ReportViewer)
WMSSuitable:
	Microsoft.ReportViewer.Common
	Microsoft.ReportViewer.WinForms

3. Проект WMSSyClasses (VB) удален из солюшена.
Ссылки на него и на Microsoft...VisualBasic в WMSSuitable удалены.
Вместо него появились новые:
WMSSuitable:
	frmSysLook
	frmSysEdit
	+ вызов frmSysLook из меню на frmMain
WMSBizObjects
	DBTable

4. Диапазоны дат и чисел
WMSBaseClasses\WMSUserControls
	WMSDateRange
	WMSNumericRange
Используются в формах на страницах фильтров
Для ввода пустого значения (Null) используем меню на правой кнопке на элементе "Выключить"
(пока в формах эти пустые значения не проверяются).
Обсудить.

5. Формы из 2-х страниц:
первая страница имеет custom-свойство IsFilter = true;
в классе: при переходе на вторую проверяется изменение всех элементов, лежащих на фильтровой странице, 
и если изменения есть - в перегруженном методе Selection вызывается метод с предопределнным именем <имястраницы_restore>, 
в котором и перестраивается источник grid.

6. Отчет по транспортировкам.

7. Если снова будет проблема с компиляцией из-за Excel
в WMSBaseClasses\WMSContextMenuStrip\WMSContextMenuUtilities.cs
закомментировать строчку 14
using Excel = Microsoft.Office.Interop.Excel;

8. В старых хр_пр (...Fill): 
order by G.Alias вместо G.Name

App.confirg - в архиве отстутсвует



