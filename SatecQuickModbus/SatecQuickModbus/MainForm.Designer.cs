/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 31.01.2020
 * Time: 13:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SatecQuickModbus
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.tsSaveFile = new System.Windows.Forms.ToolStripButton();
			this.tsLoadFile = new System.Windows.Forms.ToolStripButton();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bUncheckAll = new System.Windows.Forms.Button();
			this.bCheckAllDev = new System.Windows.Forms.Button();
			this.bPackWrite = new System.Windows.Forms.Button();
			this.dgvDev = new System.Windows.Forms.DataGridView();
			this.Adr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Use = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.bSearchDev = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbComPort = new System.Windows.Forms.ComboBox();
			this.cbBaudrate = new System.Windows.Forms.ComboBox();
			this.cbParity = new System.Windows.Forms.ComboBox();
			this.cbStopBits = new System.Windows.Forms.ComboBox();
			this.bOpenPort = new System.Windows.Forms.Button();
			this.bClosePort = new System.Windows.Forms.Button();
			this.bReadTable = new System.Windows.Forms.Button();
			this.bWriteTable = new System.Windows.Forms.Button();
			this.bScanPorts = new System.Windows.Forms.Button();
			this.serialPort = new System.IO.Ports.SerialPort(this.components);
			this.dgvModbusAdr = new System.Windows.Forms.DataGridView();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.nSlaveAdr = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDev)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvModbusAdr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nSlaveAdr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tsSaveFile,
			this.tsLoadFile});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(587, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			// 
			// tsSaveFile
			// 
			this.tsSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("tsSaveFile.Image")));
			this.tsSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSaveFile.Name = "tsSaveFile";
			this.tsSaveFile.Size = new System.Drawing.Size(23, 22);
			this.tsSaveFile.Text = "Save file";
			this.tsSaveFile.Click += new System.EventHandler(this.TsSaveFileClick);
			// 
			// tsLoadFile
			// 
			this.tsLoadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsLoadFile.Image = ((System.Drawing.Image)(resources.GetObject("tsLoadFile.Image")));
			this.tsLoadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsLoadFile.Name = "tsLoadFile";
			this.tsLoadFile.Size = new System.Drawing.Size(23, 22);
			this.tsLoadFile.Text = "Open file";
			this.tsLoadFile.Click += new System.EventHandler(this.TsLoadFileClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bUncheckAll);
			this.groupBox1.Controls.Add(this.bCheckAllDev);
			this.groupBox1.Controls.Add(this.bPackWrite);
			this.groupBox1.Controls.Add(this.dgvDev);
			this.groupBox1.Controls.Add(this.bSearchDev);
			this.groupBox1.Location = new System.Drawing.Point(12, 156);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(104, 438);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Устройства";
			// 
			// bUncheckAll
			// 
			this.bUncheckAll.Location = new System.Drawing.Point(6, 380);
			this.bUncheckAll.Name = "bUncheckAll";
			this.bUncheckAll.Size = new System.Drawing.Size(92, 23);
			this.bUncheckAll.TabIndex = 4;
			this.bUncheckAll.Text = "Uncheck all";
			this.bUncheckAll.UseVisualStyleBackColor = true;
			this.bUncheckAll.Click += new System.EventHandler(this.BUncheckAllClick);
			// 
			// bCheckAllDev
			// 
			this.bCheckAllDev.Location = new System.Drawing.Point(6, 351);
			this.bCheckAllDev.Name = "bCheckAllDev";
			this.bCheckAllDev.Size = new System.Drawing.Size(92, 23);
			this.bCheckAllDev.TabIndex = 3;
			this.bCheckAllDev.Text = "Check all";
			this.bCheckAllDev.UseVisualStyleBackColor = true;
			this.bCheckAllDev.Click += new System.EventHandler(this.BCheckAllDevClick);
			// 
			// bPackWrite
			// 
			this.bPackWrite.Location = new System.Drawing.Point(6, 409);
			this.bPackWrite.Name = "bPackWrite";
			this.bPackWrite.Size = new System.Drawing.Size(92, 23);
			this.bPackWrite.TabIndex = 2;
			this.bPackWrite.Text = "Запись в ...";
			this.bPackWrite.UseVisualStyleBackColor = true;
			this.bPackWrite.Click += new System.EventHandler(this.BPackWriteClick);
			// 
			// dgvDev
			// 
			this.dgvDev.AllowUserToAddRows = false;
			this.dgvDev.AllowUserToDeleteRows = false;
			this.dgvDev.AllowUserToResizeColumns = false;
			this.dgvDev.AllowUserToResizeRows = false;
			this.dgvDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDev.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Adr,
			this.Use});
			this.dgvDev.Location = new System.Drawing.Point(6, 48);
			this.dgvDev.MultiSelect = false;
			this.dgvDev.Name = "dgvDev";
			this.dgvDev.RowHeadersVisible = false;
			this.dgvDev.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvDev.RowsDefaultCellStyle = dataGridViewCellStyle13;
			this.dgvDev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDev.Size = new System.Drawing.Size(92, 297);
			this.dgvDev.TabIndex = 1;
			// 
			// Adr
			// 
			this.Adr.HeaderText = "Adr";
			this.Adr.Name = "Adr";
			this.Adr.ReadOnly = true;
			this.Adr.Width = 35;
			// 
			// Use
			// 
			this.Use.HeaderText = "";
			this.Use.Name = "Use";
			this.Use.Width = 35;
			// 
			// bSearchDev
			// 
			this.bSearchDev.Location = new System.Drawing.Point(6, 19);
			this.bSearchDev.Name = "bSearchDev";
			this.bSearchDev.Size = new System.Drawing.Size(92, 23);
			this.bSearchDev.TabIndex = 0;
			this.bSearchDev.Text = "Найти";
			this.bSearchDev.UseVisualStyleBackColor = true;
			this.bSearchDev.Click += new System.EventHandler(this.BSearchDevClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "COM port";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Baud";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Parity";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "StopBits";
			// 
			// cbComPort
			// 
			this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbComPort.FormattingEnabled = true;
			this.cbComPort.Location = new System.Drawing.Point(74, 28);
			this.cbComPort.Name = "cbComPort";
			this.cbComPort.Size = new System.Drawing.Size(64, 21);
			this.cbComPort.TabIndex = 9;
			// 
			// cbBaudrate
			// 
			this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBaudrate.FormattingEnabled = true;
			this.cbBaudrate.Location = new System.Drawing.Point(74, 56);
			this.cbBaudrate.Name = "cbBaudrate";
			this.cbBaudrate.Size = new System.Drawing.Size(64, 21);
			this.cbBaudrate.TabIndex = 10;
			// 
			// cbParity
			// 
			this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbParity.FormattingEnabled = true;
			this.cbParity.Location = new System.Drawing.Point(74, 83);
			this.cbParity.Name = "cbParity";
			this.cbParity.Size = new System.Drawing.Size(64, 21);
			this.cbParity.TabIndex = 11;
			// 
			// cbStopBits
			// 
			this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStopBits.FormattingEnabled = true;
			this.cbStopBits.Location = new System.Drawing.Point(74, 110);
			this.cbStopBits.Name = "cbStopBits";
			this.cbStopBits.Size = new System.Drawing.Size(64, 21);
			this.cbStopBits.TabIndex = 12;
			// 
			// bOpenPort
			// 
			this.bOpenPort.Location = new System.Drawing.Point(420, 28);
			this.bOpenPort.Name = "bOpenPort";
			this.bOpenPort.Size = new System.Drawing.Size(75, 23);
			this.bOpenPort.TabIndex = 13;
			this.bOpenPort.Text = "Open";
			this.bOpenPort.UseVisualStyleBackColor = true;
			this.bOpenPort.Click += new System.EventHandler(this.BOpenPortClick);
			// 
			// bClosePort
			// 
			this.bClosePort.Location = new System.Drawing.Point(501, 28);
			this.bClosePort.Name = "bClosePort";
			this.bClosePort.Size = new System.Drawing.Size(75, 23);
			this.bClosePort.TabIndex = 14;
			this.bClosePort.Text = "Close";
			this.bClosePort.UseVisualStyleBackColor = true;
			this.bClosePort.Click += new System.EventHandler(this.BClosePortClick);
			// 
			// bReadTable
			// 
			this.bReadTable.Location = new System.Drawing.Point(420, 113);
			this.bReadTable.Name = "bReadTable";
			this.bReadTable.Size = new System.Drawing.Size(75, 23);
			this.bReadTable.TabIndex = 15;
			this.bReadTable.Text = "Read";
			this.bReadTable.UseVisualStyleBackColor = true;
			this.bReadTable.Click += new System.EventHandler(this.BReadTableClick);
			// 
			// bWriteTable
			// 
			this.bWriteTable.Location = new System.Drawing.Point(501, 113);
			this.bWriteTable.Name = "bWriteTable";
			this.bWriteTable.Size = new System.Drawing.Size(75, 23);
			this.bWriteTable.TabIndex = 16;
			this.bWriteTable.Text = "Write";
			this.bWriteTable.UseVisualStyleBackColor = true;
			this.bWriteTable.Click += new System.EventHandler(this.BWriteTableClick);
			// 
			// bScanPorts
			// 
			this.bScanPorts.Location = new System.Drawing.Point(339, 28);
			this.bScanPorts.Name = "bScanPorts";
			this.bScanPorts.Size = new System.Drawing.Size(75, 23);
			this.bScanPorts.TabIndex = 17;
			this.bScanPorts.Text = "Scan";
			this.bScanPorts.UseVisualStyleBackColor = true;
			this.bScanPorts.Click += new System.EventHandler(this.BScanPortsClick);
			// 
			// dgvModbusAdr
			// 
			this.dgvModbusAdr.AllowUserToAddRows = false;
			this.dgvModbusAdr.AllowUserToDeleteRows = false;
			this.dgvModbusAdr.AllowUserToResizeColumns = false;
			this.dgvModbusAdr.AllowUserToResizeRows = false;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvModbusAdr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.dgvModbusAdr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvModbusAdr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Adress,
			this.Reg,
			this.Comment});
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvModbusAdr.DefaultCellStyle = dataGridViewCellStyle18;
			this.dgvModbusAdr.Location = new System.Drawing.Point(122, 156);
			this.dgvModbusAdr.MultiSelect = false;
			this.dgvModbusAdr.Name = "dgvModbusAdr";
			this.dgvModbusAdr.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvModbusAdr.RowHeadersWidth = 40;
			this.dgvModbusAdr.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvModbusAdr.Size = new System.Drawing.Size(453, 438);
			this.dgvModbusAdr.TabIndex = 18;
			this.dgvModbusAdr.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModbusAdrCellEndEdit);
			this.dgvModbusAdr.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DgvModbusAdrCellValidating);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// nSlaveAdr
			// 
			this.nSlaveAdr.Location = new System.Drawing.Point(339, 114);
			this.nSlaveAdr.Maximum = new decimal(new int[] {
			254,
			0,
			0,
			0});
			this.nSlaveAdr.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nSlaveAdr.Name = "nSlaveAdr";
			this.nSlaveAdr.Size = new System.Drawing.Size(75, 20);
			this.nSlaveAdr.TabIndex = 19;
			this.nSlaveAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nSlaveAdr.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(275, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 23);
			this.label5.TabIndex = 20;
			this.label5.Text = "Slave adr.";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 600);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(563, 23);
			this.progressBar1.TabIndex = 21;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(170, 28);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(141, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 22;
			this.pictureBox1.TabStop = false;
			// 
			// Adress
			// 
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			this.Adress.DefaultCellStyle = dataGridViewCellStyle15;
			this.Adress.HeaderText = "Adr.";
			this.Adress.MaxInputLength = 10;
			this.Adress.Name = "Adress";
			this.Adress.ReadOnly = true;
			this.Adress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Adress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Adress.Width = 40;
			// 
			// Reg
			// 
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			this.Reg.DefaultCellStyle = dataGridViewCellStyle16;
			this.Reg.HeaderText = "Reg (DEC)";
			this.Reg.MaxInputLength = 5;
			this.Reg.Name = "Reg";
			this.Reg.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Reg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Reg.Width = 70;
			// 
			// Comment
			// 
			dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
			this.Comment.DefaultCellStyle = dataGridViewCellStyle17;
			this.Comment.HeaderText = "Comment";
			this.Comment.MaxInputLength = 50;
			this.Comment.Name = "Comment";
			this.Comment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Comment.Width = 325;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(587, 627);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nSlaveAdr);
			this.Controls.Add(this.dgvModbusAdr);
			this.Controls.Add(this.bScanPorts);
			this.Controls.Add(this.bWriteTable);
			this.Controls.Add(this.bReadTable);
			this.Controls.Add(this.bClosePort);
			this.Controls.Add(this.bOpenPort);
			this.Controls.Add(this.cbStopBits);
			this.Controls.Add(this.cbParity);
			this.Controls.Add(this.cbBaudrate);
			this.Controls.Add(this.cbComPort);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "SatecQuickModbus";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDev)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvModbusAdr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nSlaveAdr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.IO.Ports.SerialPort serialPort;
		private System.Windows.Forms.Button bScanPorts;
		private System.Windows.Forms.Button bWriteTable;
		private System.Windows.Forms.Button bReadTable;
		private System.Windows.Forms.Button bClosePort;
		private System.Windows.Forms.Button bOpenPort;
		private System.Windows.Forms.ComboBox cbStopBits;
		private System.Windows.Forms.ComboBox cbParity;
		private System.Windows.Forms.ComboBox cbBaudrate;
		private System.Windows.Forms.ComboBox cbComPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bSearchDev;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripButton tsLoadFile;
		private System.Windows.Forms.ToolStripButton tsSaveFile;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.DataGridView dgvModbusAdr;
		private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
		private System.Windows.Forms.DataGridViewTextBoxColumn Reg;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.DataGridView dgvDev;
		private System.Windows.Forms.Button bCheckAllDev;
		private System.Windows.Forms.Button bPackWrite;
		private System.Windows.Forms.DataGridViewTextBoxColumn Adr;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Use;
		private System.Windows.Forms.Button bUncheckAll;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.NumericUpDown nSlaveAdr;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
