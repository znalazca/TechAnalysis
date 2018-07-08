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
 * Date: 22.10.2008
 * Time: 15:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace valPresage
{
	partial class FormChart
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChart));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonPointer = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButtonTools = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonUndoLast = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonUndoAll = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripComboBoxPeriod = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonPrevious = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelPrice = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel = new GraphicsProvider.ChartContainer();
			this.chartBox = new GraphicsProvider.ChartBox();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartBox)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButtonPointer,
									this.toolStripButtonColor,
									this.toolStripDropDownButtonTools,
									this.toolStripSeparator2,
									this.toolStripButtonSave,
									this.toolStripButtonUndoLast,
									this.toolStripButtonUndoAll,
									this.toolStripSeparator1,
									this.toolStripComboBoxPeriod,
									this.toolStripSeparator3,
									this.toolStripButtonPrevious,
									this.toolStripButtonNext,
									this.toolStripButtonAdd,
									this.toolStripButtonRemove});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(592, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip";
			// 
			// toolStripButtonPointer
			// 
			this.toolStripButtonPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonPointer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPointer.Image")));
			this.toolStripButtonPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPointer.Name = "toolStripButtonPointer";
			this.toolStripButtonPointer.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonPointer.Text = "Pointer";
			this.toolStripButtonPointer.Click += new System.EventHandler(this.ToolStripButtonPointerClick);
			// 
			// toolStripButtonColor
			// 
			this.toolStripButtonColor.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripButtonColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColor.Image")));
			this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonColor.Name = "toolStripButtonColor";
			this.toolStripButtonColor.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonColor.Text = "Color";
			this.toolStripButtonColor.Click += new System.EventHandler(this.ToolStripButtonColorClick);
			// 
			// toolStripDropDownButtonTools
			// 
			this.toolStripDropDownButtonTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButtonTools.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTools.Image")));
			this.toolStripDropDownButtonTools.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButtonTools.Name = "toolStripDropDownButtonTools";
			this.toolStripDropDownButtonTools.Size = new System.Drawing.Size(29, 22);
			this.toolStripDropDownButtonTools.Text = "toolStripDropDownButtonTools";
			this.toolStripDropDownButtonTools.ToolTipText = "Tools";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonSave
			// 
			this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSave.Enabled = false;
			this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
			this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSave.Name = "toolStripButtonSave";
			this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSave.Text = "toolStripButtonSave";
			this.toolStripButtonSave.ToolTipText = "Save";
			this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSaveClick);
			// 
			// toolStripButtonUndoLast
			// 
			this.toolStripButtonUndoLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonUndoLast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndoLast.Image")));
			this.toolStripButtonUndoLast.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonUndoLast.Name = "toolStripButtonUndoLast";
			this.toolStripButtonUndoLast.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonUndoLast.Text = "toolStripButtonUndoLast";
			this.toolStripButtonUndoLast.ToolTipText = "Remove last layer";
			this.toolStripButtonUndoLast.Click += new System.EventHandler(this.ToolStripButtonUndoLastClick);
			// 
			// toolStripButtonUndoAll
			// 
			this.toolStripButtonUndoAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonUndoAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndoAll.Image")));
			this.toolStripButtonUndoAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonUndoAll.Name = "toolStripButtonUndoAll";
			this.toolStripButtonUndoAll.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonUndoAll.Text = "toolStripButtonUndoAll";
			this.toolStripButtonUndoAll.ToolTipText = "Remove all layers";
			this.toolStripButtonUndoAll.Click += new System.EventHandler(this.ToolStripButtonUndoAllClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripComboBoxPeriod
			// 
			this.toolStripComboBoxPeriod.AutoToolTip = true;
			this.toolStripComboBoxPeriod.DropDownHeight = 150;
			this.toolStripComboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolStripComboBoxPeriod.IntegralHeight = false;
			this.toolStripComboBoxPeriod.Items.AddRange(new object[] {
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
			this.toolStripComboBoxPeriod.Name = "toolStripComboBoxPeriod";
			this.toolStripComboBoxPeriod.Size = new System.Drawing.Size(121, 25);
			this.toolStripComboBoxPeriod.ToolTipText = "Period";
			this.toolStripComboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxPeriodSelectedIndexChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonPrevious
			// 
			this.toolStripButtonPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonPrevious.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrevious.Image")));
			this.toolStripButtonPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPrevious.Name = "toolStripButtonPrevious";
			this.toolStripButtonPrevious.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonPrevious.Text = "toolStripButtonPrevious";
			this.toolStripButtonPrevious.ToolTipText = "Previous symbol";
			this.toolStripButtonPrevious.Click += new System.EventHandler(this.ToolStripButtonPreviousClick);
			// 
			// toolStripButtonNext
			// 
			this.toolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNext.Image")));
			this.toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNext.Name = "toolStripButtonNext";
			this.toolStripButtonNext.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonNext.Text = "toolStripButtonNext";
			this.toolStripButtonNext.ToolTipText = "Next symbol";
			this.toolStripButtonNext.Click += new System.EventHandler(this.ToolStripButtonNextClick);
			// 
			// toolStripButtonAdd
			// 
			this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
			this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonAdd.Name = "toolStripButtonAdd";
			this.toolStripButtonAdd.Size = new System.Drawing.Size(30, 22);
			this.toolStripButtonAdd.Text = "Add";
			this.toolStripButtonAdd.Click += new System.EventHandler(this.ToolStripButtonAddClick);
			// 
			// toolStripButtonRemove
			// 
			this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemove.Image")));
			this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRemove.Name = "toolStripButtonRemove";
			this.toolStripButtonRemove.Size = new System.Drawing.Size(50, 22);
			this.toolStripButtonRemove.Text = "Remove";
			this.toolStripButtonRemove.Click += new System.EventHandler(this.ToolStripButtonRemoveClick);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabelDate,
									this.toolStripStatusLabelPrice});
			this.statusStrip.Location = new System.Drawing.Point(0, 301);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(592, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip";
			// 
			// toolStripStatusLabelDate
			// 
			this.toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
			this.toolStripStatusLabelDate.Size = new System.Drawing.Size(16, 17);
			this.toolStripStatusLabelDate.Text = "   ";
			// 
			// toolStripStatusLabelPrice
			// 
			this.toolStripStatusLabelPrice.Name = "toolStripStatusLabelPrice";
			this.toolStripStatusLabelPrice.Size = new System.Drawing.Size(16, 17);
			this.toolStripStatusLabelPrice.Text = "   ";
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.chartBox);
			this.panel.Location = new System.Drawing.Point(0, 25);
			this.panel.Name = "panel";
			this.panel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.panel.Size = new System.Drawing.Size(592, 276);
			this.panel.TabIndex = 2;
			this.panel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PanelControlAdded);
			// 
			// chartBox
			// 
			this.chartBox.BaseChartIndex = 0;
			this.chartBox.FrameColor = System.Drawing.Color.Black;
			this.chartBox.GridColor = System.Drawing.Color.Gray;
			this.chartBox.GridTextColor = System.Drawing.Color.Black;
			this.chartBox.HGridLines = 0;
			this.chartBox.HorizontalGrid = false;
			this.chartBox.HorizontalValues = false;
			this.chartBox.Location = new System.Drawing.Point(0, 0);
			this.chartBox.Name = "chartBox";
			this.chartBox.Size = new System.Drawing.Size(592, 257);
			this.chartBox.TabIndex = 0;
			this.chartBox.TabStop = false;
			this.chartBox.TextColor = System.Drawing.Color.Gray;
			this.chartBox.TickColor = System.Drawing.Color.Green;
			this.chartBox.ToolColor = System.Drawing.Color.Empty;
			this.chartBox.UID = new System.Guid("00000000-0000-0000-0000-000000000000");
			this.chartBox.VerticalGrid = false;
			this.chartBox.VerticalValues = false;
			this.chartBox.VGridLines = 0;
			this.chartBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChartBoxMouseDown);
			// 
			// FormChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 323);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.MinimumSize = new System.Drawing.Size(600, 350);
			this.Name = "FormChart";
			this.ShowIcon = false;
			this.SizeChanged += new System.EventHandler(this.FormChartSizeChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChartFormClosing);
			this.ResizeEnd += new System.EventHandler(this.FormChartResizeEnd);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
		private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBoxPeriod;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonColor;
		private GraphicsProvider.ChartBox chartBox;
		private GraphicsProvider.ChartContainer panel;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPrice;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripButton toolStripButtonNext;
		private System.Windows.Forms.ToolStripButton toolStripButtonPrevious;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolStripButtonUndoAll;
		private System.Windows.Forms.ToolStripButton toolStripButtonUndoLast;
		private System.Windows.Forms.ToolStripButton toolStripButtonSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTools;
		private System.Windows.Forms.ToolStripButton toolStripButtonPointer;
		private System.Windows.Forms.ToolStrip toolStrip;
	}
}
