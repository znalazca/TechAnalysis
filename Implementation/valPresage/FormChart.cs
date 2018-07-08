/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 22.10.2008
 * Time: 15:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

//
// Custom namespaces
//

using DataProvider;
using GraphicsProvider;
using HttpProvider;

using DataInterface;
using GraphicsInterface;

using DataHostServices;

using Configuration;

//
// New in alpha-2
//

//

namespace valPresage
{
	/// <summary>
	/// Description of FormChart.
	/// </summary>
	public partial class FormChart : Form
	{
		//
		//  Arguments
		//
		
		private string symbol;
		private string path;
		List<string> symbols;
		valPresageConfig config;
		
		//
		// Global objects
		//
		
		private SymbolManager symbolManager;
		
		//
		// Symbol dependent objects
		//
		
		// For GraphicsServices
		
		private LayerManager layerManager;
		
		//
		// Layers for current symbol
		//
		
		private XElement layers;
		private QuotesManager quotesManager;
		
		//
		// Other propherties
		//
		
		private XElement data;

        private bool wasMaximized = false;
        
        //private int oldHeight; // TO REMOVE
        
        // New in Alpha-2
        
        //private List<Guid> DisplayedUIDs;
        
        //int iSubHeight; // TO REMOVE
        //bool notResize; // TO REMOVE
        
        // end
        
        //
        // Instances for plugins
        //
        
        private GraphicsInterface.IGraphicsProvider instance;
        private List<IGraphicsProvider> instances;
        
        List<string> plugins;
        
        string currentPlugin;
        
		//
		// Event handlers
		//
		
		EventHandler<XObjectChangeEventArgs> layersChanged;
		
		EventHandler sizeChanged;
		
		public FormChart(string _symbol, string _path, List<string> _symbols, valPresageConfig _config)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			symbol = _symbol;
			path = _path;
			symbols = _symbols;
			config = _config;
			
			symbolManager = new SymbolManager();
			
			plugins = new List<string>();
			
			// New in Alpha-2
			
			panel.chartBox = this.chartBox;
			panel.config = config;
			
			//DisplayedUIDs = new List<Guid>();
			
			//
			
			this.toolStripComboBoxPeriod.SelectedIndex = config.Period;

			this.GetTools();
			this.GetData();
			this.DrawChart();
			
			this.chartBox.ToolColor = config.ToolColor;
			this.ChangeToolColor();
			
			sizeChanged = new EventHandler(this.ChartBoxSizeChanged);
			chartBox.SizeChanged += sizeChanged;
		}
		
		//
		// Get environment
		//
		
		private void GetTools()
		{
			string[] files = Directory.GetFiles("plugins", "*.dll");
			
			foreach(string file in files)
			{
				plugins.Add(Path.GetFileNameWithoutExtension(file));
			}
			
			toolStripDropDownButtonTools.DropDownItems.Clear();
			
			foreach(string plugin in plugins)
			{
				ToolStripMenuItem item = new ToolStripMenuItem();
				item.Text = plugin;
				item.Click += new System.EventHandler(this.ToolSelected);
				
				toolStripDropDownButtonTools.DropDownItems.Add(item);
			}
		}
		
		private void GetData()
		{
			try
			{
				//data = XElement.Load(path + @"Data\" + symbol + ".XML");
				
				// New in alpha-2
				
				quotesManager = new QuotesManager(symbol);
				
				data = quotesManager.Data;
				
				if(toolStripComboBoxPeriod.SelectedIndex == 0)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddMonths(-1) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 1)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddMonths(-2) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 2)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddMonths(-3) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 3)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddMonths(-4) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 4)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddMonths(-6) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 5)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddYears(-1) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 6)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddYears(-2) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 7)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddYears(-3) select c);
					
					data = new XElement("quotes", newdata);
				}
				else if(toolStripComboBoxPeriod.SelectedIndex == 8)
				{
					IEnumerable<XElement> newdata = (from c in data.Elements("quote") where (DateTime)c.Element("date") >= quotesManager.GetLastDate().AddYears(-5) select c);
					
					data = new XElement("quotes", newdata);
				}
				
				layers = symbolManager.GetLayers(symbol);
				
				layersChanged = new EventHandler<XObjectChangeEventArgs>(Layers_Changed);
				layers.Changed += layersChanged;
				
				toolStripButtonSave.Enabled = false;
				
				if(layers.Nodes().Count() != 0)
				{
					toolStripButtonUndoLast.Enabled = true;
					toolStripButtonUndoAll.Enabled = true;
				}
				else
				{
					toolStripButtonUndoLast.Enabled = false;
					toolStripButtonUndoAll.Enabled = false;
				}
			}
			catch(IOException ex)
			{
				MessageBox.Show(this, "Can not load symbol: " +  ex.Message, "Error");
			}
		}
		
		//
		// Events
		//
		
		// Delete Layers
		
		void ToolStripButtonUndoLastClick(object sender, EventArgs e)
		{
			layers.Changed -= layersChanged;
			//layers.Elements("layer").Last().Remove();
			
			int i = (from c in layers.Elements("layer").Attributes("count") select (int)c).Max();
			Guid uid = (from c in layers.Elements("layer") where (int)c.Attribute("count") == i select (Guid)c.Attribute("uid")).First();
			(from c in layers.Elements("layer") where (int)c.Attribute("count") == i select c).Remove();
			
			layers.Changed += layersChanged;
			
			//instances.RemoveAt(layers.Nodes().Count());
			
			instances.Remove((from c in instances where c.UID == uid select c).First());
			panel.DisplayedUIDs.Remove(uid);
			
			if(instance != null)
			{
				instance.Deactivate();
				
				instance = this.GetPlugin(currentPlugin);
			}
			
			//this.RedrawLayers();
			this.DrawLayers();
			this.ActivateToolInstance();
			
			if(layers.Nodes().Count() == 0)
			{
				toolStripButtonUndoLast.Enabled = false;
				toolStripButtonUndoAll.Enabled = false;
			}
			
			toolStripButtonSave.Enabled = true;
		}
		
		void ToolStripButtonUndoAllClick(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Do you want to delete all layers?", "Warning", MessageBoxButtons.YesNo);
			
			if(result == DialogResult.Yes)
			{
				if(symbolManager.GetLayersCount(symbol) != 0)
				{
					symbolManager.DropAllLayers(symbol);
				}

				layers = new XElement("layer");
				layers.Changed += layersChanged;
			
				toolStripButtonUndoLast.Enabled = false;
				toolStripButtonUndoAll.Enabled = false;
                toolStripButtonSave.Enabled = false;

                MessageBox.Show("cleared");
                instances = new List<IGraphicsProvider>();
                //this.RedrawLayers();
                this.DrawLayers();
                this.ActivateToolInstance();
			}
		}
		
		// Related to Save Layers
		
		void ToolStripButtonSaveClick(object sender, EventArgs e)
		{
			try
			{
                if (layers.Nodes().Count() != 0)
                {
                    symbolManager.SaveLayers(symbol, layers);
                }
                else
                {
                    symbolManager.DropAllLayers(symbol);
                }
				
				toolStripButtonSave.Enabled = false;
				
				if(symbolManager.GetLayersCount(symbol) == 0)
				{

					toolStripButtonUndoLast.Enabled = false;
					toolStripButtonUndoAll.Enabled = false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("The layers could not be saved: " + ex.Message, "Error");
			}
		}
		
		void FormChartFormClosing(object sender, FormClosingEventArgs e)
		{
			if(!SaveDialog())
			{
				e.Cancel = true;
			}
			else
			{
				this.DisposeChart();
			}
		}
		
		private bool SaveDialog()
		{
			if(toolStripButtonSave.Enabled)
			{
				DialogResult result = MessageBox.Show("Do you want to save the changes?", "Warning", MessageBoxButtons.YesNoCancel); 
			
				if(result == DialogResult.Yes)
				{
                    if (layers.Nodes().Count() != 0)
                    {
                        symbolManager.SaveLayers(symbol, layers);
                    }
                    else
                    {
                        symbolManager.DropAllLayers(symbol);
                    }

					return true;
				}
				else if(result == DialogResult.No)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return true;
			}
		}
		
		private void Layers_Changed(Object sender, XObjectChangeEventArgs cea)
		{
			if(layers.Nodes().Count() > 0)
			{
				toolStripButtonUndoLast.Enabled = true;
				toolStripButtonUndoAll.Enabled = true;
			}
			else
			{
				toolStripButtonUndoLast.Enabled = false;
				toolStripButtonUndoAll.Enabled = false;
			}
			
			toolStripButtonSave.Enabled = true;
			
			if(instance != null)
			{
				instance.Deactivate();
				//instances.Add(instance);
				instance = this.GetPlugin(currentPlugin);
				this.ActivateToolInstance();
			}
			
			//this.RedrawLayers();
			this.DrawLayers();
		}
		
		void ChartBoxMouseDown(object sender, MouseEventArgs e)
		{
			foreach(ChartBox smallBox in panel.Controls)
			{
				smallBox.RemoveTick();
			}
			
			ChartBox box = (ChartBox)sender;
			
			toolStripStatusLabelDate.Text = box.GetDate(e.X).ToShortDateString();
			toolStripStatusLabelPrice.Text = Decimal.Round(box.GetPrice(e.Y), 2).ToString();
			
			box.PutTick(e.X, e.Y);
		}

		void ToolStripButtonPointerClick(object sender, EventArgs e)
		{
			this.DeselectTools();
			
			if(instance != null)
			{
				instance.Deactivate();
				instance = null;
			}
		}
		
		void ToolSelected(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			
			this.DeselectTools();
			
			item.Checked = true;
			
			if(instance != null)
			{
				instance.Deactivate();
			}

			currentPlugin = item.Text;
			instance = this.GetPlugin(currentPlugin);
			this.ActivateToolInstance();
		}
		
		void FormChartResizeEnd(object sender, EventArgs e)
		{
			this.ResizePanel();
			
			//this.chartBox.Visible = true;
		}
		
		void FormChartSizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				wasMaximized = true;
				this.ResizePanel();
				return;
			}
			if((this.WindowState == FormWindowState.Normal)&&(wasMaximized))
			{
				wasMaximized = false;
				this.ResizePanel();
				return;
			}

			//this.chartBox.Visible = false;
		}
		
		void ToolStripButtonPreviousClick(object sender, EventArgs e)
		{
			if(this.SaveDialog())
			{
				this.ClearStatus();
				
				int index = symbols.IndexOf(symbol);
			
				if(index == 0)
				{
					symbol = symbols[symbols.Count - 1];
				}
				else
				{
					symbol = symbols[index - 1];
				}
				
				this.DisposeChart();
			
				this.GetData();
				chartBox.Width = panel.Width;
				this.DrawChart();
			
				if(instance != null)
				{
					instance.Deactivate();
					this.ActivateToolInstance();
				}
			}
		}
		
		void ToolStripButtonNextClick(object sender, EventArgs e)
		{
			if(this.SaveDialog())
			{
				this.ClearStatus();
				
				int index = symbols.IndexOf(symbol);
			
				if(index == symbols.Count - 1)
				{
					symbol = symbols[0];
				}
				else
				{
					symbol = symbols[index + 1];
				}
			
				this.DisposeChart();
				
				this.GetData();
				chartBox.Width = panel.Width;
				this.DrawChart();
			
				if(instance != null)
				{
					instance.Deactivate();
					this.ActivateToolInstance();
				}
			}
		}
		
		void ToolStripButtonColorClick(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			cd.Color = this.chartBox.ToolColor;
			DialogResult result = cd.ShowDialog();
			
			if(result == DialogResult.OK)
			{
				this.chartBox.ToolColor = cd.Color;
				this.ChangeToolColor();
			}
		}
		
		void ToolStripComboBoxPeriodSelectedIndexChanged(object sender, EventArgs e)
		{
			this.DisposeChart();
			this.GetData();
			this.DrawChart();
		}
		
		//
		// Private methods
		//
		
		private void ClearStatus()
		{
			toolStripStatusLabelDate.Text = String.Empty;
			toolStripStatusLabelPrice.Text = String.Empty;
		}
		
		private void DisposeChart()
		{
			panel.AutoScroll = false;
			panel.AutoScroll = true;
				
			chartBox.Reset();
			
			if(chartBox.PureImage != null)
			{
				chartBox.PureImage.Dispose();
			}
			
			wasMaximized = false;
			
			if(panel.Controls.Count > 1)
			{
				for(int i = 1; i < panel.Controls.Count; i++)
				{
					ChartBox box = (ChartBox)panel.Controls[i];
					box.DisposePrice();
					panel.Controls.RemoveAt(i);
				}
	
				chartBox.Height = panel.Height - 19;
				//panel.ResizeMainChart(false);
			}
			
			//MessageBox.Show("cleared");
			instances = new List<IGraphicsProvider>();
			panel.DisplayedUIDs = new List<Guid>();
		}
		
		private void ActivateToolInstance()
		{
			if(instance != null)
			{
				layerManager = new LayerManager(currentPlugin, layers);
			
				instance.Chart = chartBox;
				instance.Data = null;
				instance.Layer = layerManager;
				instance.Config = new ConfigManager(instance.Name);
				
				instance.Activate();
			}
		}
		
		private void DeselectTools()
		{
			foreach(ToolStripMenuItem item in toolStripDropDownButtonTools.DropDownItems)
			{
				item.Checked = false;
			}
		}

		private void ResizePanel()
		{
			panel.Size = new Size(this.Width - 8, this.Height - 77);
			
			//oldHeight = chartBox.Height;
			chartBox.Height = chartBox.Parent.Height - 19;
			/*if(panel.Controls.Count != 1)
			{
				this.ResizeMainChart(false);
				this.ResizeSubCharts(false);
			}
			
			if(((config.Type == Chart.ChartType.Line)&&(chartBox.Width > data.Nodes().Count())||
			    ((config.Type == Chart.ChartType.Bar)&&(chartBox.Width > data.Nodes().Count() * 6))||
			    ((config.Type == Chart.ChartType.Candle)&&(chartBox.Width > data.Nodes().Count() * 8)))||
			    (chartBox.Width < panel.Width))
			{
				chartBox.Width = panel.Width;
				
				if(panel.Controls.Count != 1)
				{
					this.ChangeSubChartsWidth();
				}
				
				this.DrawChart();
				return;
			}
			
			if(chartBox.Height != oldHeight)
			{
        		this.DrawChart();
       			return;
			}

			if(instance != null)
			{
				instance.Deactivate();
				this.ActivateToolInstance();
			}*/
		}
		
		//
		// GetPlugin
		//
		
		private IGraphicsProvider GetPlugin(string FileName)
		{
			Assembly pluginAssembly = Assembly.LoadFrom(@"Plugins\" + FileName + ".dll");
						
			foreach (Type pluginType in pluginAssembly.GetTypes())
			{
				if (pluginType.IsPublic)
				{
					if (!pluginType.IsAbstract)
					{
						Type typeInterface = pluginType.GetInterface("GraphicsInterface.IGraphicsProvider", true);
						
						if(typeInterface != null)
						{
							IGraphicsProvider plugin = (IGraphicsProvider)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
							pluginAssembly = null;
							return plugin;
						}
					}
				}
			}
			
			return null;
		}
		
		private void ChangeToolColor()
		{
			Bitmap bitmap = new Bitmap(16,16);
			Graphics g = Graphics.FromImage(bitmap);
			g.DrawRectangle(new Pen(Color.Black, 1), 0,0,15,15);
			g.FillRectangle(new SolidBrush(chartBox.ToolColor), new Rectangle(3,3,10,10));
			g.Dispose();
			toolStripButtonColor.Image = bitmap;
		}
		
		//
		// Public methods
		//
		
		public void DrawChart()
		{
			chartBox.Reset();
			
			this.Text = symbol;
                
			if(config.IsVolume)
			{
				Chart volume = new Chart(data);
				volume.Type = Chart.ChartType.Volume;
				volume.VolumeColor = config.VolumeColor;
				chartBox.Charts.Add(volume);
                chartBox.BaseChartIndex = 1;
			}
                
            Chart chart = new Chart(data);
			chart.Type = config.Type;
			chart.LineColor = config.LineColor;
			chart.UpColor = config.UpColor;
			chart.DownColor = config.DownColor;
			chartBox.Charts.Add(chart);
				
			chartBox.HorizontalValues = config.IsHorizontalValues;
			chartBox.VerticalValues = config.IsVerticalValues;
			chartBox.HorizontalGrid = config.IsHorizontalGrid;
			chartBox.VerticalGrid = config.IsVerticalGrid;
			chartBox.HGridLines = config.HGridLines;
			chartBox.VGridLines = config.VGridLines;
				
			chartBox.GridColor = config.GridColor;
			chartBox.TickColor = config.TickColor;
			chartBox.TextColor = config.TextColor;
			chartBox.GridTextColor = config.GridTextColor;
			chartBox.FrameColor = config.FrameColor;
			chartBox.BackColor = config.BackColor;

			chartBox.CalculateAll();
			this.DrawCommonLayers();
			chartBox.DrawAll();
			
			chartBox.Width = chartBox.PureImage.Width;
											
			// Draw Layers
			
			this.DrawLayers();
			
			chartBox.DisposePrice();
			chartBox.DrawPrice();
		}
		
		/*public void RedrawLayers()
		{
			chartBox.Image = (Bitmap)chartBox.PureImage.Clone();
			
			foreach(IGraphicsProvider plugin in instances)
			{
				plugin.Activate();
			}
		}*/
		
		public void DrawLayers()
        {
			chartBox.SizeChanged -= sizeChanged;
			
			chartBox.Image = (Bitmap)chartBox.PureImage.Clone();
			instances = new List<IGraphicsProvider>();
			
            foreach (XElement x in layers.Elements())
            {
            	//
				// New in Alpha-2
				//
				
				// Не хочет нормально итерировать layers
				
				if((bool)x.Attribute("chart") == true)
            	{
            		Guid uid = (Guid)x.Attribute("uid");

	           		if(panel.DisplayedUIDs.Contains(uid))
            		{
            			return;
            		}
            	}
            	
            	// end
            	
                string plugin = x.Attribute("plugin").Value;
                
                IGraphicsProvider tool = this.GetPlugin(plugin);

                if (tool != null)
                {
                    tool.Chart = chartBox;
                    tool.Data = x;
                    tool.Config = new ConfigManager(plugin);

                    panel.DisplayedUIDs.Add((Guid)x.Attribute("uid"));
                    instances.Add(tool);
                                
                    tool.Activate();
                    
                    if((bool)x.Attribute("chart") == true)
            		{
                    	chartBox.CalculateAll();
                    	this.DrawCommonLayers();
                    	chartBox.DrawAll();
                    	
                    	chartBox.Image = (Bitmap)chartBox.PureImage.Clone();
                    	
                    	chartBox.DisposePrice();
                    	chartBox.DrawPrice();
                    }
                }
                else
                {
                	MessageBox.Show("Can not find plugin: " + x.Attribute("plugin").Value);
                }
            }
            
            chartBox.SizeChanged += sizeChanged;
        }
		
		public void DrawCommonLayers()
		{
			XElement commonLayers = symbolManager.GetCommonLayers();
			
			foreach(XElement commonLayer in commonLayers.Elements())
			{
				string plugin = commonLayer.Attribute("plugin").Value;
				
				IGraphicsProvider tool = this.GetPlugin(plugin);
				
				if(tool != null)
				{
					tool.Chart = chartBox;
					tool.Data = commonLayer;
					tool.Config = new ConfigManager(plugin);
					tool.ActivateCommon();
				}
			}
		}
		
		//
		// New in alpha-2
		//
		
		void ToolStripButtonAddClick(object sender, EventArgs e)
		{
			panel.AddSubChart();
		}
		
		void ToolStripButtonRemoveClick(object sender, EventArgs e)
		{
			panel.RemoveSubChart();
		}
		
		void ChartBoxSizeChanged(object sender, EventArgs e)
		{
			if((panel.Controls.Count != 1)&&(!panel.NotResize))
			{
				panel.ResizeMainChart(false);
				panel.ResizeSubCharts(false);
			}
			
			if(((config.Type == Chart.ChartType.Line)&&(chartBox.Width > data.Nodes().Count())||
			    ((config.Type == Chart.ChartType.Bar)&&(chartBox.Width > data.Nodes().Count() * 6))||
			    ((config.Type == Chart.ChartType.Candle)&&(chartBox.Width > data.Nodes().Count() * 8)))||
			    (chartBox.Width < panel.Width))
			{
				chartBox.Width = panel.Width;
				
				if(panel.Controls.Count != 1)
				{
					panel.ChangeSubChartsWidth();
				}
				
				this.DrawChart();
				return;
			}
			
			this.DrawChart();

			if(instance != null)
			{
				instance.Deactivate();
				this.ActivateToolInstance();
			}
		}
		
		void PanelControlAdded(object sender, ControlEventArgs e)
		{
			ChartBox box = (ChartBox)panel.Controls[panel.Controls.Count - 1];
			box.MouseDown += new MouseEventHandler(this.ChartBoxMouseDown);
		}
	}
}
