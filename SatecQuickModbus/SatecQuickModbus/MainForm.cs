/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 31.01.2020
 * Time: 13:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;

using Modbus.Device;
using Modbus.Data;

namespace SatecQuickModbus
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string pathToFile;
		int sRetry;
		int sTimeout;
		
		bool tableModified;
		
		IModbusSerialMaster master;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			InitFormCombobox();
			InitDataGridView();
			GetComPorts();
			LoadSettings();
			SetVisible();
			
			tableModified = false;
			
			timer1.Interval = 200;
			timer1.Start();
		}
		
		
		
		public void InitFormCombobox()
		{
			
			// Baudrate
			//1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200
			cbBaudrate.Items.Add("1200");
			cbBaudrate.Items.Add("2400");			
			cbBaudrate.Items.Add("4800");
			cbBaudrate.Items.Add("9600");
			cbBaudrate.Items.Add("19200");
			cbBaudrate.Items.Add("38400");
			cbBaudrate.Items.Add("57600");
			cbBaudrate.Items.Add("115200");
			cbBaudrate.SelectedIndex = 3;
			
			// Parity
			cbParity.Items.Add("None");
			cbParity.Items.Add("Even");
			cbParity.Items.Add("Odd");
			cbParity.SelectedIndex = 0;
			
			// StopBits
			cbStopBits.Items.Add("1");
			cbStopBits.Items.Add("1.5");
			cbStopBits.Items.Add("2");
			cbStopBits.SelectedIndex = 0;
		}
		
		public void InitDataGridView()
		{
			// Main settings
			//dgvModbusAdr.Columns[1].ValueType = typeof(int);
			
			for (int row = 0; row < 120; row++) {
				dgvModbusAdr.Rows.Add();
				dgvModbusAdr[0, row].Value = row.ToString();
				dgvModbusAdr[1, row].Value = 11776;
				dgvModbusAdr[2, row].Value = "";
			}
		}
		
		// Load settings from exe config
		public void LoadSettings()
		{
			
			string sPortName = ConfigurationManager.AppSettings["sComPort"] ?? "COM1";
			int i = cbComPort.FindString(sPortName);
			if (i >= 0) {
				cbComPort.SelectedIndex = i;
			} else {
				if (cbComPort.Items.Count > 0) {
					cbComPort.SelectedIndex = 0;
					if (sPortName != " ") {
						MessageBox.Show("Порт " + sPortName + " не найден в списке доступных портов в всистеме!");
					}
				} 
			}
			
			cbBaudrate.SelectedIndex = cbBaudrate.FindString(ConfigurationManager.AppSettings["sBaudeate"] ?? "9600");
			cbParity.SelectedIndex = cbParity.FindString(ConfigurationManager.AppSettings["sParity"] ?? "None");
			cbStopBits.SelectedIndex = cbStopBits.FindString(ConfigurationManager.AppSettings["sStopBits"] ?? "1");
			pathToFile = ConfigurationManager.AppSettings["sPathToFile"] ?? "";
			sTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["sTimeout"] ?? "200");
			sRetry = Convert.ToInt32(ConfigurationManager.AppSettings["sRetry"] ?? "2");
			
		}
		
		// save settings to exe config
		public void SaveSettings()
		{
			
			if (cbComPort.Items.Count > 0) {
				AddUpdateAppSettings("sComPort", cbComPort.SelectedItem.ToString());
			} 
			
			AddUpdateAppSettings("sBaudeate", cbBaudrate.SelectedItem.ToString());
			AddUpdateAppSettings("sParity", cbParity.SelectedItem.ToString());
			AddUpdateAppSettings("sStopBits", cbStopBits.SelectedItem.ToString());
			AddUpdateAppSettings("sPathToFile", pathToFile);
			AddUpdateAppSettings("sTimeout", sTimeout.ToString());
			AddUpdateAppSettings("sRetry", sRetry.ToString());
			
		}
		
		// ф-ция для работы с файлом настроек app.Exe.Config (xml)
		bool AddUpdateAppSettings(string key, string value)
		{
			try {
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				var settings = configFile.AppSettings.Settings;
				if (settings[key] == null) {
					settings.Add(key, value);
				} else {
					settings[key].Value = value;
				}
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
				return true;
			} catch (ConfigurationErrorsException) {
				//MessageBox.Show("Error writing app settings");
				return false;
			}
		}
		
		// Serch COM ports in system
		void GetComPorts()
		{
			cbComPort.Items.Clear();
			foreach (string portName in SerialPort.GetPortNames()) {
				cbComPort.Items.Add(portName);
			}
			
			if (cbComPort.Items.Count > 0) {
				cbComPort.SelectedIndex = 0;
			}
			
		}
		
		void BScanPortsClick(object sender, EventArgs e)
		{
			GetComPorts();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();	
			
			if (tableModified && (e.CloseReason == CloseReason.UserClosing)) {
				e.Cancel = false;
				DialogResult dr = MessageBox.Show("Есть не сохраненные данные. Выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No) {
					e.Cancel = true;
				}
			}
		}
		
		void BOpenPortClick(object sender, EventArgs e)
		{
			OpenComPort();
			InitMbMaster();
		}
		
		void OpenComPort()
		{
			if (cbComPort.SelectedIndex < 0) {
				MessageBox.Show("В системе отсутствуют COM порты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			serialPort.PortName = cbComPort.SelectedItem.ToString();
			serialPort.BaudRate = Int32.Parse(cbBaudrate.SelectedItem.ToString());
			
			switch (cbParity.SelectedIndex) {
				case 0:
					serialPort.Parity = Parity.None;
					break;
				case 1:
					serialPort.Parity = Parity.Even;
					break;
				case 2:
					serialPort.Parity = Parity.Odd;
					break;
			}
			
			switch (cbStopBits.SelectedIndex) {
				case 0:
					serialPort.StopBits = StopBits.One;
					break;
				case 1:
					serialPort.StopBits = StopBits.OnePointFive;
					break;
				case 2:
					serialPort.StopBits = StopBits.Two;
					break;
			}
			
			try {
				serialPort.Open();
			} catch {
				MessageBox.Show("Ошибка открытия COM порта", "Ошибка");
			}
			
		}
		
		void InitMbMaster()
		{
			master = ModbusSerialMaster.CreateRtu(serialPort);
			master.Transport.ReadTimeout = sTimeout;
			master.Transport.Retries = sRetry;
		}
		
		void BClosePortClick(object sender, EventArgs e)
		{
			try {
				if (serialPort.IsOpen) {
					serialPort.Close();
				}
			} catch {
				
			}
		}
		
		void SetVisible()
		{
			bool v = false;
			
			v = serialPort.IsOpen;
			
			cbBaudrate.Enabled = !v;
			cbComPort.Enabled = !v;
			cbParity.Enabled = !v;
			cbStopBits.Enabled = !v;
			
			bOpenPort.Enabled = !v;
			bClosePort.Enabled = v;
			bScanPorts.Enabled = !v;
			
			bReadTable.Enabled = v;
			bWriteTable.Enabled = v;
			
			bSearchDev.Enabled = v;
			bPackWrite.Enabled = v;
		}
		
		void TsSaveFileClick(object sender, EventArgs e)
		{
			string p;
			
			if (pathToFile == "") {
				pathToFile = @"C:\";
			}
			
			saveFileDialog.InitialDirectory = pathToFile;
			saveFileDialog.FileName = "modbus_satec";
			saveFileDialog.DefaultExt = "xml";
			saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			saveFileDialog.OverwritePrompt = true;
			if (saveFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}
			
			pathToFile = Path.GetDirectoryName(saveFileDialog.FileName);
			ExportXML(saveFileDialog.FileName);
			
			tableModified = false;
			
		}
		
		void TsLoadFileClick(object sender, EventArgs e)
		{
			// предупреждение
			if (tableModified) {
				var answer = MessageBox.Show("Есть не сохраненные данные. Прочитать файл?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (answer == DialogResult.No) {
					return;
				}
			}
			
			if (pathToFile == "") {
				pathToFile = @"C:\";
			}
			
			openFileDialog.InitialDirectory = pathToFile;
			openFileDialog.Title = "Browse XML files"; 
			openFileDialog.Filter = "XML files (*.xml)|*.xml";			

			if (openFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}
			
			pathToFile = Path.GetDirectoryName(openFileDialog.FileName);
			ImportXML(openFileDialog.FileName);
			
			tableModified = false;
		}
		
		void ExportXML(string path)
		{
			XmlTextWriter writer = null;
			
			try {
				writer = new XmlTextWriter(path, Encoding.Unicode);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument();
				//Запись общих данных
				writer.WriteStartElement("Root");
				
				//Запись данных таблицы
				for (int i = 0; i < (dgvModbusAdr.Rows.Count); i++) {
					writer.WriteStartElement("Row");
						
					writer.WriteAttributeString("n", dgvModbusAdr.Rows[i].Cells[0].Value.ToString());
					writer.WriteAttributeString("adr", dgvModbusAdr.Rows[i].Cells[1].Value.ToString());
					writer.WriteAttributeString("com", dgvModbusAdr.Rows[i].Cells[2].Value.ToString());
					
					writer.WriteEndElement();
				}
				writer.WriteEndElement();

				writer.WriteEndDocument();
			} catch (Exception ex) {
				MessageBox.Show("Ошибка записи файла настроек: " + ex.Message);
			} finally {
				if (writer != null)
					writer.Close();
			}
		}
		
		// XML
		void ImportXML(string path)
		{
			int i = 0;
			int row = 0;
			int adr = 0;
			string com = "";
			bool err = false;
			
			XmlTextReader reader = null;
				
			try {
				
				reader = new XmlTextReader(path);
				reader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы
				while (reader.Read()) {
					if (reader.Name == "Row") {
						row = Convert.ToInt32(reader.GetAttribute("n") ?? "0");
						adr = Convert.ToInt32(reader.GetAttribute("adr") ?? "11776");
						com = reader.GetAttribute("com") ?? "";
						
						if ((row < 0) || (row > 119)) {
							err = true;
						}
						
						//dgvModbusAdr[0, row].Value = row.ToString();
						dgvModbusAdr[1, row].Value = adr;
						dgvModbusAdr[2, row].Value = com;
					}
				}
				
			} catch (Exception ex) {
				MessageBox.Show("Ошибка чтения файла настроек: " + ex.Message);
			} finally {
				if (reader != null)
					reader.Close();
				tableModified = false;
			}
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			SetVisible();
		}
		
		void BPackWriteClick(object sender, EventArgs e)
		{
			if (dgvDev.Rows.Count == 0) {
				MessageBox.Show("Error in adr. table, count = 0 !!");
				return;
			}
			
			foreach (DataGridViewRow row in dgvDev.Rows) {
				if (Convert.ToBoolean(row.Cells[1].Value)) {
					row.Selected = true;
					writeToDevice(Convert.ToInt32(row.Cells[0].Value));
				}
			}	
			
			
		}
			
		void BReadTableClick(object sender, EventArgs e)
		{
			bool err = false;
			ushort uAdr = 0;
			
			if (!serialPort.IsOpen) {
				MessageBox.Show("Port isn`t open");
				return;
			}
			
			var answer = MessageBox.Show("Чтение из устройства обновит данные в таблице, Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (answer == DialogResult.No) {
				return;
			}
			
			progressBar1.Minimum = 0;
			progressBar1.Maximum = 120;
			for (int i = 0; i < 120; i++) {
				progressBar1.Value = i;
				try {
					uAdr = (ushort)(120 + i);
					ushort[] t1 = master.ReadHoldingRegisters((byte)nSlaveAdr.Value, uAdr, 1);
					dgvModbusAdr[1, i].Value = (int)t1[0];
					dgvModbusAdr[2, i].Value = "";
				} catch {
					err = true;
				}
				
				if (err) {
					MessageBox.Show("Ошибка чтения с устройства № " + nSlaveAdr.Value.ToString() + ". Чтение прервано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					progressBar1.Value = 0;
					return;
				}
			}	
			progressBar1.Value = 0;
		}
		
		void BWriteTableClick(object sender, EventArgs e)
		{
	
			var answer = MessageBox.Show("Запись обновит данные в устройстве. Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (answer == DialogResult.No) {
				return;
			}
			
			writeToDevice((int)nSlaveAdr.Value);
		}
		
		void writeToDevice(int slaveadr)
		{
			
			ushort val;
			ushort uAdr = 120;
			bool err = false;
			
			if (!serialPort.IsOpen) {
				MessageBox.Show("Port isn`t open", "Error");
				return;
			}
			
			progressBar1.Minimum = 0;
			progressBar1.Maximum = 120;
			for (int i = 0; i < 120; i++) {
				progressBar1.Value = i;
				val = Convert.ToUInt16(dgvModbusAdr[1, i].Value);
				try {
					uAdr = (ushort)(120 + i);
					master.WriteSingleRegister((byte)slaveadr, uAdr, val);
				} catch {
					err = true;
				}
				
				if (err) {
					MessageBox.Show("Ошибка записи в устройство № " + slaveadr.ToString() + ". Адрес регистра " + uAdr.ToString() + ". Запись прервана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					progressBar1.Value = 0;
					return;
				}
			}
			progressBar1.Value = 0;
		}
		
		void BSearchDevClick(object sender, EventArgs e)
		{
			int count = 0;
			
			dgvDev.Rows.Clear();
			if (!serialPort.IsOpen) {
				MessageBox.Show("Port isn`t open", "Error!");
				return;
			}
			
			master.Transport.Retries = 1;
			master.Transport.ReadTimeout = 100;
			progressBar1.Maximum = 254;
			progressBar1.Minimum = 1;
			
			for (int i = 1; i < 254; i++) {
				progressBar1.Value = i;
				try {
					ushort[] t1 = master.ReadHoldingRegisters((byte)i, 120, 1);
					dgvDev.Rows.Add();
					dgvDev[0, count].Value = i.ToString();
					count++;
				} catch {
					
				}
			}
			
			master.Transport.ReadTimeout = sTimeout;
			master.Transport.Retries = sRetry;
			progressBar1.Value = 1;
		}
		
		void BCheckAllDevClick(object sender, EventArgs e)
		{
			if (dgvDev.Rows.Count == 0) {
				return;
			}
			
			foreach (DataGridViewRow row in dgvDev.Rows) {
				row.Cells[1].Value = true;
			}
		}
		
		void BUncheckAllClick(object sender, EventArgs e)
		{
			if (dgvDev.Rows.Count == 0) {
				return;
			}
			
			foreach (DataGridViewRow row in dgvDev.Rows) {
				row.Cells[1].Value = false;
			}	
		}
		
		void DgvModbusAdrCellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// костыль, нужно както правильнее 
			tableModified = true;
			
			dgvModbusAdr.Rows[e.RowIndex].ErrorText = String.Empty;
		}
		
		
		void DgvModbusAdrCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			bool err = false;
			int reg = 0;
			
			if (e.ColumnIndex != 1)
				return;
			
			try {
				reg = Convert.ToInt32(e.FormattedValue.ToString());
				if((reg < 240) || (reg > 65535)) {
				   	err = true;
				}
			} catch {
				err = true;
			}
			
			
			if(err){
				dgvModbusAdr.Rows[e.RowIndex].ErrorText = "Введите адрес в диапазоне 240 ... 65535";
				e.Cancel = true;
			}
		}

		


	}
}
