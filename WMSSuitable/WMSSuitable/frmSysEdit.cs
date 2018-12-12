using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RFMBaseClasses;
using RFMPublic;

using WMSBizObjects;

namespace WMSSuitable 
{
	/// <summary>
	/// Форма для отображения одной записи
	/// </summary>
	public partial class frmSysEdit : RFMFormChild
	{
		private DBTable oDBTable = new DBTable();
		private Form parentForm;   
		//private bool bLoaded = false;

		RFMTextBox controlFirst = null;

		public frmSysEdit(string _sTable, int _nID, Form _parentForm)
		{
			InitializeComponent();
			oDBTable.MainTableName = _sTable;
			oDBTable.recordID = _nID;
			parentForm = _parentForm;
		}

		private void frmSysEdit_Load(object sender, EventArgs e)
		{
			if (oDBTable.MainTableName == null || oDBTable.MainTableName.Length == 0)
			{
				RFMMessage.MessageBoxError("Не задана таблица...");
				return; 
			}

			if (oDBTable.recordID == null)
			{
				oDBTable.recordID = 0;
			}

			oDBTable.FillNames();

			Text = "Таблица " + oDBTable.MainTableName + " (" + oDBTable.RusTableName + ")";
			if (oDBTable.recordID.HasValue)
			{
				if ((int)oDBTable.recordID > 0)
				{
					Text = Text + ", запись с кодом " + oDBTable.recordID.ToString();
				}
				else
				{
					if ((int)oDBTable.recordID < 0)
					{
						Text = Text + ", копия записи";
					}
					else
					{
						Text = Text + ", новая запись";
					}
				}
			}	

			// структура таблицы
			oDBTable.GetStructure(false);

			// выбранная запись таблицы
			int nID = Math.Abs((int)oDBTable.recordID);
			oDBTable.GetRecordsList(nID, false);

			// переменные, которые нам понадобятся
			int fieldsCount = oDBTable.TableStructure.Rows.Count;
			Object value; 
			string tempValue, defaultValue, tempChar;
			int rowNumber, columnNumber;
			string fieldName, fieldDescription;
			bool isFieldEnabled, isFieldNullAble, isNull;
			string fieldTypeChar;
			int maxLength, customLength, scale;
			string identityFieldName; 
			bool isFKID; string tableNameFK;
			Graphics grafics_;

			// identity-поле
			identityFieldName = "";
			for(columnNumber = 0; columnNumber < fieldsCount; columnNumber++)
			{
				if (Convert.ToBoolean(oDBTable.TableStructure.Rows[columnNumber]["Is_Identity"])) 
				{
					identityFieldName = oDBTable.TableStructure.Rows[columnNumber]["FieldName"].ToString();
					break;
				}
			}

			// сдвиг полей по вертикали и горизонтали
			int nShift = lblForShift2.Top - lblForShift1.Bottom;
			int nCurTop = lblForShift1.Top;
			lblForShift1.Visible = false;
			lblForShift2.Visible = false;
			// длина/высота стд.метки с названием-описанием поля 
			int nLabelLength = lblNull.Left - lblFields.Left - 1;
			int nLabelHeight = Convert.ToInt32(Math.Ceiling((new RFMLabel()).CreateGraphics().MeasureString("X", Font).Height));
			// длина/высота стд.текстового поля (с учетом правой полосы прокрутки)
			int nVScrollWidth = (new VScrollBar()).Width;
			int nTextBoxLength = pnlData.Width - lblValues.Left - nShift - nVScrollWidth;
			int nTextBoxHeight = (new RFMTextBox()).Height;
		
			Control control;
			RFMCheckBox controlCheckBox;
			RFMComboBox controlFK;
			
			// показываем описание полей и их значения: 1 строка - 1 поле 
			for(rowNumber = 0; rowNumber < oDBTable.TableStructure.Rows.Count; rowNumber++)
			{
				DataRow rs = oDBTable.TableStructure.Rows[rowNumber];
				fieldName = rs["FieldName"].ToString();
				fieldDescription = rs["FieldDescription"].ToString();
				fieldTypeChar = rs["FieldTypeChar"].ToString();
				isFKID = Convert.ToBoolean(rs["Is_FKID"]);
				isFieldNullAble = Convert.ToBoolean(rs["Is_NullAble"]);
				if (rs["DefaultValue"] == DBNull.Value)
				{
					defaultValue = null;
				}
				else
				{
					defaultValue = rs["DefaultValue"].ToString();
				}
				maxLength = Convert.ToInt32(rs["Max_Length"]);
				customLength = Convert.ToInt32(rs["Custom_Len"]);
				scale = Convert.ToInt32(rs["Scale"]);

				value = null; // DBNull.Value

				if (nID == 0)
				{
					// добавление
					if (defaultValue == null) 
					{
						if (isFieldNullAble)
						{
							value = null;
							isNull = true;
						}
						else
						{
							switch (fieldTypeChar)
							{
								case "L":
									value = false;
									break;
								case "N":
									value = 0;
									break;
								case "D":
									value = DateTime.Now.Date;
									break;
								case "C":
									value = "";
									break;
							}
							isNull = false;
						}
					}
					else
					{
						isNull = false;
						// убираем скобки из значения по умолчанию
						while(defaultValue.IndexOf("(") == 0)
						{
							defaultValue = defaultValue.Substring(1);
						}
						while(defaultValue.LastIndexOf(")") == defaultValue.Length - 1)
						{
							defaultValue = defaultValue.Substring(0, defaultValue.Length - 1);
						}
						switch (fieldTypeChar)
						{
							case "L":
								if (defaultValue == "1") 
								{
									value = true;
								}
								else
								{
									value = false;
								}
								break;
							case "N":
								try
								{
									value = Convert.ToDecimal(defaultValue); // в зависимости от типа
								}
								catch { }
								break;
							case "D":
								try
								{
									value = Convert.ToDateTime(defaultValue);
								}
								catch { }
								break;
							case "C":
								if (defaultValue == "''")
								{
									defaultValue = "";
								}
								value = defaultValue;
								break;
						}
						isNull = false;
					}
				}
				else
				{
					//редактирование
					value = oDBTable.MainTable.Rows[0][fieldName];
					if (value == DBNull.Value)
					{
						value = null;
						isNull = true;
					}
					else
					{
						isNull = false;
					}
				}

				// доступно ли поле для ввода/редактирования
				if (Convert.ToBoolean(rs["Is_Identity"]) || 
					Convert.ToBoolean(rs["Is_RowGuidCol"]) || 
					Convert.ToBoolean(rs["Is_Computed"]) ||
					"LNCD".IndexOf(fieldTypeChar) < 0)
				{
					isFieldEnabled = false;
					isFieldNullAble = false;
				}
				else
				{
					isFieldEnabled = true;
				}

				// название-описание поля, label
				RFMLabel lblTemp = new RFMLabel();
				lblTemp.Name = "lbl" + fieldName;
				lblTemp.Text = fieldDescription;
				lblTemp.Left = lblFields.Left;
				lblTemp.Top = nCurTop + (nTextBoxHeight - nLabelHeight) / 2;
				grafics_ = lblTemp.CreateGraphics();
				lblTemp.Width = Convert.ToInt32(Math.Ceiling(grafics_.MeasureString(lblTemp.Text, Font).Width));
				lblTemp.Height = Convert.ToInt32(Math.Ceiling(grafics_.MeasureString(lblTemp.Text, Font).Height));
				if (lblTemp.Width > nLabelLength)
				{
					lblTemp.Height = Convert.ToInt32(Math.Ceiling(lblTemp.Height * Math.Ceiling((decimal)lblTemp.Width / (decimal)nLabelLength))) + 1;
					lblTemp.Width = nLabelLength;
				}
				else
				{
					lblTemp.AutoSize = true;
				}
				pnlData.Controls.Add(lblTemp);

				// ячейка под управление Null
				RFMCheckBox chkTemp = new RFMCheckBox();
				chkTemp.Name = "chkNull" + fieldName;
				if (isFieldNullAble)
				{
					chkTemp.Checked = isNull;
					chkTemp.Text = (isNull) ? "Null" : " ";
					chkTemp.Enabled = isFieldEnabled;
				}
				else
				{
					chkTemp.Checked = false;
					chkTemp.Enabled = false;
					chkTemp.Visible = false;
				}
				chkTemp.Left = lblNull.Left;
				chkTemp.AutoSize = true;
				chkTemp.Top = nCurTop + (nTextBoxHeight - nLabelHeight) / 2;
				//AddHandler chkTemp.CheckedChanged, AddressOf chkNull_Changed;
				chkTemp.CheckedChanged += new System.EventHandler(chkNull_Changed);
				pnlData.Controls.Add(chkTemp);

				// ячейка для значения
				isFieldEnabled = (isFieldEnabled && !isNull);
				switch (fieldTypeChar)
				{
					case "L":
						controlCheckBox = new RFMCheckBox();
						if (isNull)
						{
							controlCheckBox.Checked = false;
						}
						else
						{
							if (value is Boolean)
							{
								controlCheckBox.Checked = Convert.ToBoolean(value);
							}
							else
							{
								if (value is String)
									controlCheckBox.Checked = (value.ToString() == "1");
							}
						}
						controlCheckBox.Text = (controlCheckBox.Checked) ? "Да" : "Нет";
						controlCheckBox.AutoSize = true;
						//AddHandler .CheckedChanged, AddressOf chkL_Changed
						controlCheckBox.CheckedChanged += new System.EventHandler(chkL_Changed);
						control = controlCheckBox;
						break;

					case "C":
						RFMTextBox controlText = new RFMTextBox();
						controlText.Font = Font;
						controlText.Multiline = true;
						controlText.MaxLength = maxLength;
						if (maxLength < 5)
						{
							tempChar = "W";
						}
						else
						{ 
							if (maxLength < 10)
							{
								tempChar = "M";
							}
							else
							{
								if (maxLength < 20)
								{
									tempChar = "O";
								}
								else
								{
									if (maxLength < 30)
									{
										tempChar = "A";
									}
									else
									{
										tempChar = "x";
									}
								}
							}
						}
						tempValue = "";
						for(int t = 1; t <= maxLength; t++)
						{
							tempValue += tempChar;
						}
						grafics_ = controlText.CreateGraphics();
						controlText.Width = Convert.ToInt32(Math.Ceiling(grafics_.MeasureString(tempValue, Font).Width)) + 1;
						controlText.Height = Convert.ToInt32(Math.Ceiling(controlText.Height * Math.Ceiling((decimal)controlText.Width / (decimal)nTextBoxLength))) + 1;
						if (controlText.Width > nTextBoxLength)
						{
							controlText.Width = nTextBoxLength;
						}
						controlText.Text = (value == null) ? "" : value.ToString();
						control = controlText;
						break;

					case "N":
						if (isFKID)
						{
							// код классификатора
							RFMTextBox controlNText = new RFMTextBox();
							controlNText.MaxLength = (customLength == 0) ? 1 : customLength;
							tempChar = "W";
							tempValue = "";
							for (int t = 1; t <= controlNText.MaxLength; t++)
							{
								tempValue += tempChar;
							}
							grafics_ = controlNText.CreateGraphics();
							controlNText.Width = Convert.ToInt32(Math.Ceiling(grafics_.MeasureString(tempValue, Font).Width));
							controlNText.Text = (value == null) ? " " : value.ToString();
							controlNText.TextAlign = HorizontalAlignment.Right;
							control = controlNText;
						}
						else
						{
							// числовое поле 
							RFMNumericUpDown controlNum = new RFMNumericUpDown();
							controlNum.Minimum = Int32.MinValue;
							controlNum.Maximum = Int32.MaxValue;
							controlNum.Value = Convert.ToDecimal(value);
							controlNum.DecimalPlaces = scale;
							controlNum.Width = 100;
							controlNum.TextAlign = HorizontalAlignment.Right;
							control = controlNum;
						}
						break;

					case "D":
						RFMDateTimePicker controlDate = new RFMDateTimePicker();
						controlDate.Value = (value == null) ? DateTime.Now.Date : Convert.ToDateTime(value);
						grafics_ = controlDate.CreateGraphics();
						controlDate.Width = Convert.ToInt32(Math.Ceiling(grafics_.MeasureString("".PadRight(10, '8'), Font).Width)) + nVScrollWidth;
						control = controlDate;
						break;

					default:
						RFMTextBox controlDefText = new RFMTextBox();
						controlDefText.Text = "...данные...";
						isFieldEnabled = false;
						control = controlDefText;
						break;
				}

				control.Name = "ctl" + fieldName;
				control.Left = lblValues.Left;
				control.Top = nCurTop;

				pnlData.Controls.Add(control);

				control.Enabled = isFieldEnabled;
				
				if (control is RFMDateTimePicker && fieldTypeChar == "D" && 
					isFieldNullAble && value == null)
				{
					((RFMDateTimePicker)control).HideControl(false);
				}
				
				if (control is RFMTextBox)
				{
					if (controlFirst == null && control.Enabled)
					{
						controlFirst = (RFMTextBox)control;
					}
				}

				// ячейка для классификатора
				if (isFKID)
				{
					control.Enabled = false;
					controlFK = new RFMComboBox();
					controlFK.Font = Font;
					controlFK.Name = "cbo" + fieldName;
					tableNameFK = oDBTable.TableStructure.Rows[rowNumber + 1]["TableName"].ToString();
					string tableNameFKinDS = tableNameFK + "_" + fieldName;
					oDBTable.GetFKRecordsList(tableNameFK, tableNameFKinDS);
					controlFK.DataSource = oDBTable.DS.Tables[tableNameFKinDS];
					controlFK.DisplayMember = oDBTable.DS.Tables[tableNameFKinDS].Columns[1].Caption;
					controlFK.ValueMember = oDBTable.DS.Tables[tableNameFKinDS].Columns[0].Caption;
					controlFK.MaxLength = maxLength = oDBTable.DS.Tables[tableNameFKinDS].Columns[1].MaxLength;
					if (maxLength < 5)
					{
						tempChar = "W";
					}
					else
					{ 
						if (maxLength < 10)
						{
							tempChar = "M";
						}
						else
						{
							if (maxLength < 20)
							{
								tempChar = "O";
							}
							else
							{
								if (maxLength < 30)
								{
									tempChar = "A";
								}
								else
								{
									tempChar = "x";
								}
							}
						}
					}
					tempValue = "";
					for(int t = 1; t <= maxLength; t++)
					{
						tempValue += tempChar;
					}
					grafics_ = controlFK.CreateGraphics();
					controlFK.Width = Convert.ToInt32(Math.Ceiling(grafics_.MeasureString(tempValue, Font).Width + nVScrollWidth));
					controlFK.Left = lblValues.Left + control.Width + nShift;
					controlFK.Top = nCurTop;
					pnlData.Controls.Add(controlFK);
					controlFK.Enabled = isFieldEnabled;
					if (nID > 0 && value != DBNull.Value && Convert.ToInt32(value) > 0)
					{
						controlFK.SelectedValue = value; // именно так: сначала добавить control на форму, а потом присвоить ему значение
					}
					if (nID == 0)
					{
						controlFK.SelectedIndex = -1;
					}
					//AddHandler controlFK.SelectedIndexChanged, AddressOf cboField_SelectedIndexChanged
					controlFK.SelectedIndexChanged += new System.EventHandler(cboField_SelectedIndexChanged);

					rowNumber = rowNumber + 1;
				}

				nCurTop = Math.Max(lblTemp.Bottom, control.Bottom) + nShift;
			}
			// все контролы добавлены и заполнены

			// подравниваем форму (вместе с панелью) по кол-ву заполненных полей
			if (nCurTop < pnlData.Height)
			{
				MinimumSize = new Size(Size.Width, 200);
				Height = Height - pnlData.Bottom + (pnlData.Top + nCurTop + nShift);
			}

			if ((int)oDBTable.recordID < 0)
			{
				oDBTable.recordID = 0; // копирование
			}

			//bLoaded = true;
		}

		private void frmSysLook_Shown(object sender, EventArgs e)
		{
			if (controlFirst != null)
			{
				controlFirst.Focus();
				controlFirst.Select(0, 0);
			}
		}

	#region Кнопки

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DataSavePrepare();
			oDBTable.RecordSave();
			if (oDBTable.ErrorNumber == 0)
			{
				// перевывод Grid в родительской форме sysLook
				if (parentForm != null)
				{
					if (oDBTable.recordID.HasValue)
					{
						((frmSysLook)parentForm).nRecordID = (int)oDBTable.recordID;
					}
					((frmSysLook)parentForm).btnRefresh_Click(null, null);
				}
			}
			Dispose();
		}

		private void DataSavePrepare()
		{ 
			// сохранение значений в таблице (_DS.Table["RecordToSave"])

			// создали таблицу в _DS для сохраняемых данных
			oDBTable.PrepareDataToSave();

			int rowNumber;
			Object value;
			string fieldName, fieldTypeChar;
			bool isFKID;
			string cntTempName, cntNullTempName, cntFKTempName;
			Array controlDim, controlNullDim, controlFKDim; 
			bool isFieldEnabled, isNull;

			for(rowNumber = 0; rowNumber < oDBTable.TableStructure.Rows.Count; rowNumber++)
			{
				DataRow rs = oDBTable.TableStructure.Rows[rowNumber];
				fieldName = rs["FieldName"].ToString();
				fieldTypeChar = rs["FieldTypeChar"].ToString();
				isFKID = Convert.ToBoolean(rs["Is_FKID"]);
				isNull = false;
				value = null; //DBNull.Value
				isFieldEnabled = false;


				// Null
				cntNullTempName = "chkNull" + fieldName;
				controlNullDim = pnlData.Controls.Find(cntNullTempName, false);
				if (controlNullDim.Length > 0)
				{
					Control controlNull = (Control)controlNullDim.GetValue(0);
					if (controlNull.Enabled && ((RFMCheckBox)controlNull).Checked)
					{
						// = Null
						isNull = true;
						value = DBNull.Value;
					}
				}

				if (!isNull)
				{
					// = value
					cntTempName = "ctl" + fieldName;
					controlDim = pnlData.Controls.Find(cntTempName, false);
					if (controlDim.Length > 0)
					{
						Control control = (Control)controlDim.GetValue(0);
						isFieldEnabled = control.Enabled;
						switch (fieldTypeChar)
						{
							case "L":
								value = ((RFMCheckBox)control).Checked;
								break;
							case "N":
								if (!isFKID)
								{
									value = ((RFMNumericUpDown)control).Value;	// NumberUpDown
								}
								else
								{
									value = control.Text; //TextBox
								}
								// классификатор
								cntFKTempName = "cbo" + fieldName;
								controlFKDim = pnlData.Controls.Find(cntFKTempName, false);
								if (controlFKDim.Length > 0)
								{
									Control controlFK = (Control)controlFKDim.GetValue(0);
									isFieldEnabled = controlFK.Enabled;
								}
								break;
							case "D":
								value = ((RFMDateTimePicker)control).Value;
								break;
							case "C":
								value = control.Text;
								break;
						}
					}
				}

				if ((isFieldEnabled || isNull) && !fieldName.Contains("$"))
				{
					// добавляем значение в ds.Table("RecordToSave") для сохранения
					oDBTable.TableRecordToSave.Columns.Add(fieldName);
					oDBTable.TableRecordToSave.Rows[0][fieldName] = value;
				}
			}
		}

	#endregion


	#region Спец. внутренняя обработка контролов

		private void chkL_Changed(object sender, EventArgs e)
		{
			// checker для L-поля
			if (sender is RFMCheckBox && 
				((RFMCheckBox)sender).Name.Substring(0, 3) == "ctl")
			{
				((RFMCheckBox)sender).Text = (((RFMCheckBox)sender).Checked) ? "Да" : "Нет";
			}
		} 

		private void chkNull_Changed(object sender, EventArgs e)
		{
			// checker "Null" для любого Nullable-поля  
			if (sender is RFMCheckBox &&
				((RFMCheckBox)sender).Name.Substring(0, 7) == "chkNull")
			{
				((RFMCheckBox)sender).Text = (((RFMCheckBox)sender).Checked) ? "Null" : " ";

				string cntTempName;
				Array controlDim;
				Control control = null;

				cntTempName = "ctl" + ((RFMCheckBox)sender).Name.Substring(7);
				controlDim = pnlData.Controls.Find(cntTempName, false);
				if (controlDim.Length > 0)
				{
					control = (Control)controlDim.GetValue(0);
					if (((RFMCheckBox)sender).Checked)
					{
						control.Enabled = false;
						// для даты 
						if (control is RFMDateTimePicker)
						{
							((RFMDateTimePicker)control).HideControl(false);
						}
					}
					else
					{
						control.Enabled = true;
						// для даты 
						if (control is RFMDateTimePicker)
						{
							((RFMDateTimePicker)control).HideControl(true);
						}
					}
				}

				// для классификатора
				cntTempName = "cbo" + ((RFMCheckBox)sender).Name.Substring(7);
				controlDim = pnlData.Controls.Find(cntTempName, false);
				if (controlDim.Length > 0)
				{
					if (control != null && control is RFMTextBox)
					{
						control.Enabled = false;
					}
					control = (Control)controlDim.GetValue(0);
					if (((RFMCheckBox)sender).Checked)
					{
						control.Enabled = false;
					}
					else
					{
						control.Enabled = true;
					}
				}
			}
		} 

		private void cboField_SelectedIndexChanged(object sender, EventArgs e)
		{
			// combobox - перевывод кода при смене значения в списке
			if (sender is RFMComboBox &&
				((RFMComboBox)sender).Name.Substring(0, 3) == "cbo")
			{
				string cntTempName = "ctl" + ((RFMComboBox)sender).Name.Substring(3);
				Array controlDim  = pnlData.Controls.Find(cntTempName, false);
				if (controlDim.Length > 0)
				{
					Control control = (Control)controlDim.GetValue(0);
					control.Text = ((RFMComboBox)sender).SelectedValue.ToString();
				}
			}
		}

	#endregion

	}

}