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

namespace valPresage
{
    partial class FormSymbols
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.listSymbols = new System.Windows.Forms.ListBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.cmbDataSource = new System.Windows.Forms.ComboBox();
        	this.btnChange = new System.Windows.Forms.Button();
        	this.btnDelete = new System.Windows.Forms.Button();
        	this.btnClose = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// listSymbols
        	// 
        	this.listSymbols.FormattingEnabled = true;
        	this.listSymbols.Location = new System.Drawing.Point(4, 3);
        	this.listSymbols.Name = "listSymbols";
        	this.listSymbols.Size = new System.Drawing.Size(136, 277);
        	this.listSymbols.TabIndex = 0;
        	this.listSymbols.SelectedIndexChanged += new System.EventHandler(this.listSymbols_SelectedIndexChanged);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(146, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(67, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Data Source";
        	// 
        	// cmbDataSource
        	// 
        	this.cmbDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cmbDataSource.Enabled = false;
        	this.cmbDataSource.FormattingEnabled = true;
        	this.cmbDataSource.Items.AddRange(new object[] {
        	        	        	"Default"});
        	this.cmbDataSource.Location = new System.Drawing.Point(149, 25);
        	this.cmbDataSource.Name = "cmbDataSource";
        	this.cmbDataSource.Size = new System.Drawing.Size(102, 21);
        	this.cmbDataSource.TabIndex = 2;
        	// 
        	// btnChange
        	// 
        	this.btnChange.Enabled = false;
        	this.btnChange.Location = new System.Drawing.Point(149, 53);
        	this.btnChange.Name = "btnChange";
        	this.btnChange.Size = new System.Drawing.Size(102, 23);
        	this.btnChange.TabIndex = 3;
        	this.btnChange.Text = "Change";
        	this.btnChange.UseVisualStyleBackColor = true;
        	this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
        	// 
        	// btnDelete
        	// 
        	this.btnDelete.Enabled = false;
        	this.btnDelete.Location = new System.Drawing.Point(149, 82);
        	this.btnDelete.Name = "btnDelete";
        	this.btnDelete.Size = new System.Drawing.Size(102, 23);
        	this.btnDelete.TabIndex = 4;
        	this.btnDelete.Text = "Delete Symbol";
        	this.btnDelete.UseVisualStyleBackColor = true;
        	this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        	// 
        	// btnClose
        	// 
        	this.btnClose.Location = new System.Drawing.Point(149, 112);
        	this.btnClose.Name = "btnClose";
        	this.btnClose.Size = new System.Drawing.Size(102, 23);
        	this.btnClose.TabIndex = 5;
        	this.btnClose.Text = "Close";
        	this.btnClose.UseVisualStyleBackColor = true;
        	this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
        	// 
        	// FormSymbols
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(259, 285);
        	this.Controls.Add(this.btnClose);
        	this.Controls.Add(this.btnDelete);
        	this.Controls.Add(this.btnChange);
        	this.Controls.Add(this.cmbDataSource);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.listSymbols);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormSymbols";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Manage Symbols";
        	this.Shown += new System.EventHandler(this.FormSymbols_Shown);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button btnClose;

        #endregion

        private System.Windows.Forms.ListBox listSymbols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDataSource;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
    }
}