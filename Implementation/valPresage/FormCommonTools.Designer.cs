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
 * Date: 17.09.2008
 * Time: 15:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace valPresage
{
	partial class FormCommonTools
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDrop = new System.Windows.Forms.Button();
			this.listTools = new System.Windows.Forms.ListView();
			this.btnClose = new System.Windows.Forms.Button();
			this.columnNumber = new System.Windows.Forms.ColumnHeader();
			this.columnTool = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(4, 241);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnDrop
			// 
			this.btnDrop.Location = new System.Drawing.Point(85, 241);
			this.btnDrop.Name = "btnDrop";
			this.btnDrop.Size = new System.Drawing.Size(75, 23);
			this.btnDrop.TabIndex = 3;
			this.btnDrop.Text = "Drop";
			this.btnDrop.UseVisualStyleBackColor = true;
			this.btnDrop.Click += new System.EventHandler(this.BtnDropClick);
			// 
			// listTools
			// 
			this.listTools.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnNumber,
									this.columnTool});
			this.listTools.FullRowSelect = true;
			this.listTools.GridLines = true;
			this.listTools.Location = new System.Drawing.Point(4, 2);
			this.listTools.Name = "listTools";
			this.listTools.Size = new System.Drawing.Size(238, 233);
			this.listTools.TabIndex = 4;
			this.listTools.UseCompatibleStateImageBehavior = false;
			this.listTools.View = System.Windows.Forms.View.Details;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(167, 240);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// columnNumber
			// 
			this.columnNumber.Text = "Number";
			// 
			// columnTool
			// 
			this.columnTool.Text = "Tool";
			this.columnTool.Width = 174;
			// 
			// FormCommonTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(247, 269);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.listTools);
			this.Controls.Add(this.btnDrop);
			this.Controls.Add(this.btnAdd);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCommonTools";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Common Tools";
			this.Shown += new System.EventHandler(this.FormCommonToolsShown);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListView listTools;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ColumnHeader columnTool;
		private System.Windows.Forms.ColumnHeader columnNumber;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDrop;
	}
}
