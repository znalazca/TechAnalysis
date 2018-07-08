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
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace valPresage
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
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageSymbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.symbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.appearanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commonToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.dataToolStripMenuItem,
									this.symbolsToolStripMenuItem,
									this.settingsToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(622, 24);
			this.mainMenu.TabIndex = 1;
			this.mainMenu.Text = "MainMenu";
			// 
			// dataToolStripMenuItem
			// 
			this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addSymbolToolStripMenuItem,
									this.updateToolStripMenuItem,
									this.manageSymbolsToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
			this.dataToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.dataToolStripMenuItem.Text = "Data";
			// 
			// addSymbolToolStripMenuItem
			// 
			this.addSymbolToolStripMenuItem.Name = "addSymbolToolStripMenuItem";
			this.addSymbolToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.addSymbolToolStripMenuItem.Text = "Add Symbol...";
			// 
			// updateToolStripMenuItem
			// 
			this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
			this.updateToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.updateToolStripMenuItem.Text = "Update";
			// 
			// manageSymbolsToolStripMenuItem
			// 
			this.manageSymbolsToolStripMenuItem.Name = "manageSymbolsToolStripMenuItem";
			this.manageSymbolsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.manageSymbolsToolStripMenuItem.Text = "Manage Symbols...";
			this.manageSymbolsToolStripMenuItem.Click += new System.EventHandler(this.ManageSymbolsToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// symbolsToolStripMenuItem
			// 
			this.symbolsToolStripMenuItem.Name = "symbolsToolStripMenuItem";
			this.symbolsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.symbolsToolStripMenuItem.Text = "Symbols";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.appearanceToolStripMenuItem,
									this.networkToolStripMenuItem,
									this.toolsToolStripMenuItem,
									this.commonToolsToolStripMenuItem,
									this.dataSourceToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// appearanceToolStripMenuItem
			// 
			this.appearanceToolStripMenuItem.Name = "appearanceToolStripMenuItem";
			this.appearanceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.appearanceToolStripMenuItem.Text = "Appearance...";
			this.appearanceToolStripMenuItem.Click += new System.EventHandler(this.AppearanceToolStripMenuItemClick);
			// 
			// networkToolStripMenuItem
			// 
			this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
			this.networkToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.networkToolStripMenuItem.Text = "Network...";
			this.networkToolStripMenuItem.Click += new System.EventHandler(this.NetworkToolStripMenuItemClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.toolsToolStripMenuItem.Text = "Tools...";
			this.toolsToolStripMenuItem.Click += new System.EventHandler(this.ToolsToolStripMenuItemClick);
			// 
			// commonToolsToolStripMenuItem
			// 
			this.commonToolsToolStripMenuItem.Name = "commonToolsToolStripMenuItem";
			this.commonToolsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.commonToolsToolStripMenuItem.Text = "Common Tools...";
			this.commonToolsToolStripMenuItem.Click += new System.EventHandler(this.CommonToolsToolStripMenuItemClick);
			// 
			// dataSourceToolStripMenuItem
			// 
			this.dataSourceToolStripMenuItem.Name = "dataSourceToolStripMenuItem";
			this.dataSourceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.dataSourceToolStripMenuItem.Text = "Default Data Source...";
			this.dataSourceToolStripMenuItem.Click += new System.EventHandler(this.DataSourceToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 373);
			this.Controls.Add(this.mainMenu);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "valPresage EOD";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem dataSourceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commonToolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem appearanceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem symbolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageSymbolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addSymbolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenu;
	}
}
