/* Copyright 2008-2012 Dzmitry Gotowka (Hatouka) htotatut@gmail.com

The MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
and associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, 
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or 
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE. */

/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 08.09.2008
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace valPresage
{
	partial class FormConfig
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbDefStyle = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.chVolume = new System.Windows.Forms.CheckBox();
			this.cmbVerLines = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbHorLines = new System.Windows.Forms.ComboBox();
			this.chVerGrid = new System.Windows.Forms.CheckBox();
			this.chHorGrid = new System.Windows.Forms.CheckBox();
			this.chVerValues = new System.Windows.Forms.CheckBox();
			this.chHorValues = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.pbVolumeColor = new System.Windows.Forms.PictureBox();
			this.label13 = new System.Windows.Forms.Label();
			this.pbBackColor = new System.Windows.Forms.PictureBox();
			this.label12 = new System.Windows.Forms.Label();
			this.pbDownColor = new System.Windows.Forms.PictureBox();
			this.pbUpColor = new System.Windows.Forms.PictureBox();
			this.pbLineColor = new System.Windows.Forms.PictureBox();
			this.pbFrameColor = new System.Windows.Forms.PictureBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.pbGridTextColor = new System.Windows.Forms.PictureBox();
			this.pbTextColor = new System.Windows.Forms.PictureBox();
			this.pbTickColor = new System.Windows.Forms.PictureBox();
			this.pbGridColor = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.gridColorDialog = new System.Windows.Forms.ColorDialog();
			this.tickColorDialog = new System.Windows.Forms.ColorDialog();
			this.textColorDialog = new System.Windows.Forms.ColorDialog();
			this.gridTextColorDialog = new System.Windows.Forms.ColorDialog();
			this.frameColorDialog = new System.Windows.Forms.ColorDialog();
			this.lineColorDialog = new System.Windows.Forms.ColorDialog();
			this.upColorDialog = new System.Windows.Forms.ColorDialog();
			this.downColorDialog = new System.Windows.Forms.ColorDialog();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.backColorDialog = new System.Windows.Forms.ColorDialog();
			this.volumeColorDialog = new System.Windows.Forms.ColorDialog();
			this.pbToolColor = new System.Windows.Forms.PictureBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbPeriod = new System.Windows.Forms.ComboBox();
			this.toolColorDialog = new System.Windows.Forms.ColorDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbVolumeColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbBackColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDownColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbUpColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbLineColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbFrameColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbGridTextColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbTextColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbTickColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbGridColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbToolColor)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbPeriod);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.cmbDefStyle);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.chVolume);
			this.groupBox1.Controls.Add(this.cmbVerLines);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmbHorLines);
			this.groupBox1.Controls.Add(this.chVerGrid);
			this.groupBox1.Controls.Add(this.chHorGrid);
			this.groupBox1.Controls.Add(this.chVerValues);
			this.groupBox1.Controls.Add(this.chHorValues);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(252, 232);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Grid And Values";
			// 
			// cmbDefStyle
			// 
			this.cmbDefStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDefStyle.FormattingEnabled = true;
			this.cmbDefStyle.Items.AddRange(new object[] {
									"Line",
									"Bar",
									"Candle"});
			this.cmbDefStyle.Location = new System.Drawing.Point(134, 170);
			this.cmbDefStyle.MaxDropDownItems = 3;
			this.cmbDefStyle.Name = "cmbDefStyle";
			this.cmbDefStyle.Size = new System.Drawing.Size(99, 21);
			this.cmbDefStyle.TabIndex = 14;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 173);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 13;
			this.label11.Text = "Default Style";
			// 
			// chVolume
			// 
			this.chVolume.Location = new System.Drawing.Point(6, 77);
			this.chVolume.Name = "chVolume";
			this.chVolume.Size = new System.Drawing.Size(104, 24);
			this.chVolume.TabIndex = 12;
			this.chVolume.Text = "Show Volume";
			this.chVolume.UseVisualStyleBackColor = true;
			// 
			// cmbVerLines
			// 
			this.cmbVerLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVerLines.FormattingEnabled = true;
			this.cmbVerLines.Items.AddRange(new object[] {
									"None",
									"2",
									"3",
									"5",
									"7",
									"10"});
			this.cmbVerLines.Location = new System.Drawing.Point(134, 142);
			this.cmbVerLines.MaxDropDownItems = 6;
			this.cmbVerLines.Name = "cmbVerLines";
			this.cmbVerLines.Size = new System.Drawing.Size(99, 21);
			this.cmbVerLines.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "Horizontal grid lines";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Vertical grid lines";
			// 
			// cmbHorLines
			// 
			this.cmbHorLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHorLines.FormattingEnabled = true;
			this.cmbHorLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cmbHorLines.Items.AddRange(new object[] {
									"None",
									"2",
									"3",
									"5",
									"7",
									"10"});
			this.cmbHorLines.Location = new System.Drawing.Point(134, 114);
			this.cmbHorLines.MaxDropDownItems = 6;
			this.cmbHorLines.Name = "cmbHorLines";
			this.cmbHorLines.Size = new System.Drawing.Size(99, 21);
			this.cmbHorLines.TabIndex = 8;
			// 
			// chVerGrid
			// 
			this.chVerGrid.Location = new System.Drawing.Point(134, 46);
			this.chVerGrid.Name = "chVerGrid";
			this.chVerGrid.Size = new System.Drawing.Size(99, 25);
			this.chVerGrid.TabIndex = 7;
			this.chVerGrid.Text = "Vertical Grid";
			this.chVerGrid.UseVisualStyleBackColor = true;
			// 
			// chHorGrid
			// 
			this.chHorGrid.Location = new System.Drawing.Point(134, 15);
			this.chHorGrid.Name = "chHorGrid";
			this.chHorGrid.Size = new System.Drawing.Size(99, 25);
			this.chHorGrid.TabIndex = 6;
			this.chHorGrid.Text = "Horizontal Grid";
			this.chHorGrid.UseVisualStyleBackColor = true;
			// 
			// chVerValues
			// 
			this.chVerValues.Location = new System.Drawing.Point(6, 46);
			this.chVerValues.Name = "chVerValues";
			this.chVerValues.Size = new System.Drawing.Size(104, 25);
			this.chVerValues.TabIndex = 5;
			this.chVerValues.Text = "VerticalValues";
			this.chVerValues.UseVisualStyleBackColor = true;
			// 
			// chHorValues
			// 
			this.chHorValues.Location = new System.Drawing.Point(6, 15);
			this.chHorValues.Name = "chHorValues";
			this.chHorValues.Size = new System.Drawing.Size(114, 25);
			this.chHorValues.TabIndex = 4;
			this.chHorValues.Text = "Horizontal Values";
			this.chHorValues.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pbToolColor);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.pbVolumeColor);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.pbBackColor);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.pbDownColor);
			this.groupBox2.Controls.Add(this.pbUpColor);
			this.groupBox2.Controls.Add(this.pbLineColor);
			this.groupBox2.Controls.Add(this.pbFrameColor);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.pbGridTextColor);
			this.groupBox2.Controls.Add(this.pbTextColor);
			this.groupBox2.Controls.Add(this.pbTickColor);
			this.groupBox2.Controls.Add(this.pbGridColor);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 250);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(252, 180);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Colors";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 150);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(68, 23);
			this.label14.TabIndex = 21;
			this.label14.Text = "Tool Color";
			// 
			// pbVolumeColor
			// 
			this.pbVolumeColor.Location = new System.Drawing.Point(211, 123);
			this.pbVolumeColor.Name = "pbVolumeColor";
			this.pbVolumeColor.Size = new System.Drawing.Size(20, 20);
			this.pbVolumeColor.TabIndex = 19;
			this.pbVolumeColor.TabStop = false;
			this.pbVolumeColor.Click += new System.EventHandler(this.PbVolumeColorClick);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(134, 123);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 18;
			this.label13.Text = "Volume Color";
			// 
			// pbBackColor
			// 
			this.pbBackColor.Location = new System.Drawing.Point(86, 123);
			this.pbBackColor.Name = "pbBackColor";
			this.pbBackColor.Size = new System.Drawing.Size(20, 20);
			this.pbBackColor.TabIndex = 17;
			this.pbBackColor.TabStop = false;
			this.pbBackColor.Click += new System.EventHandler(this.PbBackColorClick);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 123);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 23);
			this.label12.TabIndex = 16;
			this.label12.Text = "Back Color";
			// 
			// pbDownColor
			// 
			this.pbDownColor.Location = new System.Drawing.Point(211, 97);
			this.pbDownColor.Name = "pbDownColor";
			this.pbDownColor.Size = new System.Drawing.Size(20, 20);
			this.pbDownColor.TabIndex = 15;
			this.pbDownColor.TabStop = false;
			this.pbDownColor.Click += new System.EventHandler(this.PbDownColorClick);
			// 
			// pbUpColor
			// 
			this.pbUpColor.Location = new System.Drawing.Point(211, 71);
			this.pbUpColor.Name = "pbUpColor";
			this.pbUpColor.Size = new System.Drawing.Size(20, 20);
			this.pbUpColor.TabIndex = 14;
			this.pbUpColor.TabStop = false;
			this.pbUpColor.Click += new System.EventHandler(this.PbUpColorClick);
			// 
			// pbLineColor
			// 
			this.pbLineColor.Location = new System.Drawing.Point(211, 45);
			this.pbLineColor.Name = "pbLineColor";
			this.pbLineColor.Size = new System.Drawing.Size(20, 20);
			this.pbLineColor.TabIndex = 13;
			this.pbLineColor.TabStop = false;
			this.pbLineColor.Click += new System.EventHandler(this.PbLineColorClick);
			// 
			// pbFrameColor
			// 
			this.pbFrameColor.Location = new System.Drawing.Point(211, 19);
			this.pbFrameColor.Name = "pbFrameColor";
			this.pbFrameColor.Size = new System.Drawing.Size(20, 20);
			this.pbFrameColor.TabIndex = 12;
			this.pbFrameColor.TabStop = false;
			this.pbFrameColor.Click += new System.EventHandler(this.PbFrameColorClick);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(134, 97);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 22);
			this.label10.TabIndex = 11;
			this.label10.Text = "Down Color";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(134, 71);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 22);
			this.label9.TabIndex = 10;
			this.label9.Text = "Up Color";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(134, 45);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 23);
			this.label8.TabIndex = 9;
			this.label8.Text = "Line Color";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(134, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Frame Color";
			// 
			// pbGridTextColor
			// 
			this.pbGridTextColor.Location = new System.Drawing.Point(86, 97);
			this.pbGridTextColor.Name = "pbGridTextColor";
			this.pbGridTextColor.Size = new System.Drawing.Size(20, 20);
			this.pbGridTextColor.TabIndex = 7;
			this.pbGridTextColor.TabStop = false;
			this.pbGridTextColor.Click += new System.EventHandler(this.PbGridTextColorClick);
			// 
			// pbTextColor
			// 
			this.pbTextColor.Location = new System.Drawing.Point(86, 71);
			this.pbTextColor.Name = "pbTextColor";
			this.pbTextColor.Size = new System.Drawing.Size(20, 20);
			this.pbTextColor.TabIndex = 6;
			this.pbTextColor.TabStop = false;
			this.pbTextColor.Click += new System.EventHandler(this.PbTextColorClick);
			// 
			// pbTickColor
			// 
			this.pbTickColor.Location = new System.Drawing.Point(86, 45);
			this.pbTickColor.Name = "pbTickColor";
			this.pbTickColor.Size = new System.Drawing.Size(20, 20);
			this.pbTickColor.TabIndex = 5;
			this.pbTickColor.TabStop = false;
			this.pbTickColor.Click += new System.EventHandler(this.PbTickColorClick);
			// 
			// pbGridColor
			// 
			this.pbGridColor.Location = new System.Drawing.Point(86, 19);
			this.pbGridColor.Name = "pbGridColor";
			this.pbGridColor.Size = new System.Drawing.Size(20, 20);
			this.pbGridColor.TabIndex = 4;
			this.pbGridColor.TabStop = false;
			this.pbGridColor.Click += new System.EventHandler(this.PbGridColorClick);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 3;
			this.label6.Text = "Grid Text Color";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Text Color";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "Tick Color";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Grid Color";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(189, 436);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(108, 436);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// pbToolColor
			// 
			this.pbToolColor.Location = new System.Drawing.Point(86, 150);
			this.pbToolColor.Name = "pbToolColor";
			this.pbToolColor.Size = new System.Drawing.Size(20, 20);
			this.pbToolColor.TabIndex = 22;
			this.pbToolColor.TabStop = false;
			this.pbToolColor.Click += new System.EventHandler(this.PbToolColorClick);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(6, 203);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 15;
			this.label15.Text = "Default Period";
			// 
			// cmbPeriod
			// 
			this.cmbPeriod.DropDownHeight = 150;
			this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPeriod.FormattingEnabled = true;
			this.cmbPeriod.IntegralHeight = false;
			this.cmbPeriod.Items.AddRange(new object[] {
									"1 Month",
									"2 Months",
									"3 Months",
									"4 Months",
									"6 Months",
									"1 Year",
									"2 Years",
									"3 Years",
									"5 Years",
									"All Data"});
			this.cmbPeriod.Location = new System.Drawing.Point(134, 200);
			this.cmbPeriod.Name = "cmbPeriod";
			this.cmbPeriod.Size = new System.Drawing.Size(100, 21);
			this.cmbPeriod.TabIndex = 16;
			// 
			// FormConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(277, 466);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfig";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Gonfiguration";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbVolumeColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbBackColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDownColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbUpColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbLineColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbFrameColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbGridTextColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbTextColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbTickColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbGridColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbToolColor)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColorDialog toolColorDialog;
		private System.Windows.Forms.PictureBox pbToolColor;
		private System.Windows.Forms.ComboBox cmbPeriod;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ColorDialog volumeColorDialog;
		private System.Windows.Forms.ColorDialog backColorDialog;
		private System.Windows.Forms.CheckBox chVolume;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.PictureBox pbBackColor;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.PictureBox pbVolumeColor;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ColorDialog downColorDialog;
		private System.Windows.Forms.ColorDialog upColorDialog;
		private System.Windows.Forms.ColorDialog lineColorDialog;
		private System.Windows.Forms.ColorDialog frameColorDialog;
		private System.Windows.Forms.ColorDialog gridTextColorDialog;
		private System.Windows.Forms.ColorDialog textColorDialog;
		private System.Windows.Forms.ColorDialog tickColorDialog;
		private System.Windows.Forms.ColorDialog gridColorDialog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox pbGridColor;
		private System.Windows.Forms.PictureBox pbTickColor;
		private System.Windows.Forms.PictureBox pbTextColor;
		private System.Windows.Forms.PictureBox pbGridTextColor;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.PictureBox pbFrameColor;
		private System.Windows.Forms.PictureBox pbLineColor;
		private System.Windows.Forms.PictureBox pbUpColor;
		private System.Windows.Forms.PictureBox pbDownColor;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chHorValues;
		private System.Windows.Forms.CheckBox chVerValues;
		private System.Windows.Forms.CheckBox chHorGrid;
		private System.Windows.Forms.CheckBox chVerGrid;
		private System.Windows.Forms.ComboBox cmbHorLines;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbVerLines;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbDefStyle;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
