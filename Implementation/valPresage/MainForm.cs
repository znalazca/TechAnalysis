/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 22.10.2008
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using System.Threading;
using System.Globalization;

//
// Custom namespaces
//

using DataProvider;
using GraphicsProvider;
using HttpProvider;

using DataInterface;
using GraphicsInterface;

using DataHostServices;
using GraphicsHostServices;

using Configuration;

namespace valPresage
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		//
		// Global environment public properties
		//
		
		public valPresageConfig config;
		public List<string> symbols;
		
		public DataServices dataServices;
		public GraphicsServices graphicsServices;
		
		public HttpManager httpManager;
		public SymbolManager symbolManager;
		
		//
		// Global environment private properties
		//
		
		// Application startup path
		private string path;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			// Get configuration for environment
			
			// Get startup path
			path = Directory.GetCurrentDirectory() + @"\";
			
			// Create http manager object
			httpManager = new HttpManager();
			
			// Get configuration					
			this.GetConfig();
			
			// Initialize SymbolManager
			symbolManager = new SymbolManager();
			
			// Initialize plugins services
			dataServices = new DataServices();
			graphicsServices = new GraphicsServices();
			
			// Get data and plugin's instances
			if(Directory.Exists(path + "Data"))
			{
				this.GetSymbols();
				this.DisplaySymbols();
			}
			else
			{
				Directory.CreateDirectory(path + "Data");
			}
			
			if(Directory.Exists(path + "Plugins"))
			{
				this.GetDataSources();
				this.GetTools();
			}
			else
			{
				Directory.CreateDirectory(path + @"Plugins");
			}
			
			// Check if directory Plugins\Config exists
			
			if(!Directory.Exists(path + @"Plugins\Config"))
			{
				Directory.CreateDirectory(path + @"Plugins\Config");
			}
		}
		
		//
		// Initialization related methods
		//
		
		private void GetConfig()
		{
			if(File.Exists("config.cfg"))
			{
				FileStream fs = new FileStream("config.cfg", FileMode.Open);
				BinaryFormatter bf = new BinaryFormatter();
				config = (valPresageConfig)bf.Deserialize(fs);
				fs.Close();
				
				if(config.IsProxy)
				{
					httpManager.Server = config.Server;
					httpManager.Port = config.Port;
					httpManager.Login = config.Login;
					httpManager.Password = config.Password;
				}
			}
			else
			{
				config = new valPresageConfig();
				
				config.IsHorizontalValues = true;
				config.IsVerticalValues = true;
				config.IsHorizontalGrid = true;
				config.IsVerticalGrid = true;
				config.IsVolume = true;
				
				config.Period = 7;
				
				config.GridColor = Color.Gray;
				config.TickColor = Color.Green;
				config.TextColor = Color.Gray;
				config.GridTextColor = Color.Black;
				config.FrameColor = Color.Black;
				config.BackColor = Color.White;
					
				config.LineColor = Color.Black;
				config.UpColor = Color.Green;
				config.DownColor = Color.Red;
				config.VolumeColor = Color.Silver;
				
				config.ToolColor = Color.Black;
					
				config.HGridLines = 3;
				config.VGridLines = 3;
				
				config.Type = Chart.ChartType.Line;
				
				config.IsProxy = false;
				
				config.Server = null;
				config.Port = null;
				config.Login = null;
				config.Password = null;
				
				config.DefaultDataSource = null;
			}
		}
		
		private void GetSymbols()
		{
			symbols = symbolManager.GetSymbols();
		}
		
		private void GetDataSources()
		{
			dataServices.FindPlugins(path + "Plugins");
		}
		
		private void GetTools()
		{
			graphicsServices.FindPlugins(path + "Plugins");
		}
		
		private void DisplaySymbols()
		{
			symbolsToolStripMenuItem.DropDownItems.Clear();
			foreach(string symbol in symbols)
			{
				ToolStripMenuItem menuItem = new ToolStripMenuItem();
				menuItem.Text = symbol;
				menuItem.Click += new System.EventHandler(this.SymbolSelected);
				symbolsToolStripMenuItem.DropDownItems.Add(menuItem);
			}
		}
		
		//
		// Event handling
		//
		
		void SymbolSelected(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			FormChart formChart = new FormChart(item.Text, path, symbols, config);
			formChart.MdiParent = this;
			formChart.Show();
		}
		
		// Common events for forms
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormAbout formAbout = new FormAbout();
			formAbout.ShowDialog();
		}
		
		void AppearanceToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormConfig formConfig = new FormConfig(this);
			formConfig.ShowDialog();
		}
		
		void NetworkToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormHttp formHttp = new FormHttp(this);
			formHttp.ShowDialog();
		}
		
		void ToolsToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormConfigTools formConfigTools = new FormConfigTools(graphicsServices);
			formConfigTools.ShowDialog();
		}
		
		void CommonToolsToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormCommonTools formCommonTools = new FormCommonTools(this);
			formCommonTools.ShowDialog();
		}
		
		void DataSourceToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormDefaultDataSource formDefaultDataSource = new FormDefaultDataSource(this);
			formDefaultDataSource.ShowDialog();
		}
		
		void ManageSymbolsToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormSymbols formSymbols = new FormSymbols(this);
			formSymbols.ShowDialog();
			this.GetSymbols();
			this.DisplaySymbols();
		}
		
		//
		// Public methods
		//
		
		public void InitializeCharts()
		{
			// TO IMPLEMENT
			// ???
		}
		
		public void DisposeChart(string symbol)
		{
			foreach(Form form in this.MdiChildren)
			{
				if(form.Text == symbol)
				{
					form.Close();
				}
			}
		}
		
		public void SerializeConfig()
		{
			FileStream fs = new FileStream("config.cfg", FileMode.Create);
			BinaryFormatter bf = new BinaryFormatter(); 
			bf.Serialize(fs, config);
			fs.Close();
		}
	}
}
