using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using GraphicsInterface;
using GraphicsProvider;
using DataProvider;

using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class SMA : IGraphicsProvider
{
	private string myPluginName = "SMA";
	private string myPluginAuthor = "Dzmitry Hatouka";
	private string myPluginDescription = "Simple Moving Average";
	private string myPluginVersion = "Alpha 1";

	private bool isCommon = true;
	
	Guid uid;
	
	private int period;

	private ChartBox chartBox;
	private LayerManager layerManager;
	private ConfigManager configManager;
	
	private XElement xElement;
	
	private Chart chart;
	
	private MouseEventHandler mouseDown;
	
	private SMAForm smaForm;
	
	private bool isUsedAsCommon;
	
	private Color color;
	
	// isActual
	
	int iWidth;
	int iHeight;
	string firstDate;
	string lastDate;

	public SMA()
	{

	}

	public void Activate()
	{
		isUsedAsCommon = false;
		
		if(!IsActual)
		{
			if(xElement == null)
			{
				uid = layerManager.NewUID();
				
				if(period == 0)
				{
					mouseDown = new MouseEventHandler(chartBoxClick);
					chartBox.MouseDown += mouseDown;
				}
				else
				{
					this.GetBounds();
					
					this.DrawSMA();
					
					this.DrawNC();
				}
			}
			else
			{
				uid = (Guid)xElement.Attribute("uid");
				
				period = (int)xElement.Element("period");
				color = Color.FromArgb(Convert.ToInt32(xElement.Element("color").Value));
				
				this.DrawSMA();
				
				this.DrawNC();
			}
		}
		else
		{
			this.DrawNC();
		}
	}
	
	private void DrawNC()
	{
		chartBox.DrawChart(chart);
		Graphics g = Graphics.FromImage(chartBox.Image);
		g.DrawImage(chart.Bitmap, new Point(0,0));
		g.Dispose();
	}
	
	private void GetBounds()
	{
		// IsActual
		iWidth = this.chartBox.Width;
		iHeight = this.chartBox.Height;
		firstDate = chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").First().Value;
		lastDate = chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").Last().Value;
	}
	
	private void chartBoxClick(object sender, MouseEventArgs e)
	{
		this.GetBounds();
		
		smaForm = new SMAForm();
		smaForm.Closed += new EventHandler(NCSMAForm_Closed);
		smaForm.ShowDialog();
	}

	public void ActivateCommon()
	{
		isUsedAsCommon = true;
		
		period = (int)xElement.Element("period");
		color = Color.DarkGreen;
			
		this.DrawSMA();
	}
		
	public void Deactivate()
	{
		chartBox.MouseDown -= mouseDown;
	}

	public void Configure()
	{
		MessageBox.Show("This plugin is not configurable");
	}

	public void ConfigureCommon()
	{
		smaForm = new SMAForm();
		smaForm.Closed += new EventHandler(SMAForm_Closed);
		smaForm.ShowDialog();
	}
	
	private void SMAForm_Closed(object sender, EventArgs e)
	{
		string text = smaForm.Controls[1].Text;
		
		if(Regex.IsMatch(text, @"^[0-9]+$"))
		{
			period = Convert.ToInt32(text);
			
			XElement x = new XElement("layer");
			x.Add(new XElement("period", period));
			layerManager.AddLayer(x);
		}
		else
		{
			MessageBox.Show("Incorrect SMA period", "Error");
		}
	}
	
	private void NCSMAForm_Closed(object sender, EventArgs e)
	{
		string text = smaForm.Controls[1].Text;
		
		if(Regex.IsMatch(text, @"^[0-9]+$"))
		{
			period = Convert.ToInt32(text);
			color = this.chartBox.ToolColor;
			
			this.DrawSMA();
			
			XElement x = new XElement("layer");
			x.Add(new XElement("period", period));
			x.Add(new XElement("color", color.ToArgb()));
			layerManager.AddLayer(x);
		}
		else
		{
			MessageBox.Show("Incorrect SMA period", "Error");
		}
	}
	
	/*private void GetConfig()
	{
		config = configManager.GetConfig();
		
		if(config.Nodes().Count() == 0)
		{
			period = 9;
		}
		else
		{
			period = Convert.ToInt32(config.Element("period").Value);
		}
	}*/
	
	//
	// Interface implementation
	//
	
	public ChartBox Chart
	{
		get { return chartBox; }
		set { chartBox = value; }
	}
	
	public LayerManager Layer
	{
		get { return layerManager; }
		set { layerManager = value; }
	}

	public XElement Data
	{
		get { return xElement; }
		set { xElement = value; }
	}

	public ConfigManager Config
	{
		get { return configManager; }
		set { configManager = value; }
	}

	public string Description
	{
		get { return myPluginDescription; }
	}

	public string Author
	{
		get { return myPluginAuthor; }
	}

	public string Version
	{
		get { return myPluginVersion; }
	}

	public string Name
	{
		get { return myPluginName; }
	}

	public bool IsCommon
	{
		get { return isCommon; }
	}
	public bool IsActual
	{
		get
		{
			if((this.chartBox.Width == iWidth)&&(chartBox.Height == iHeight)&&(chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").First().Value == firstDate)&&(chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").Last().Value == lastDate))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
	
	public Guid UID
	{
		get
		{
			return uid;
		}
	}
	
	private void DrawSMA()
	{
		XElement data = chartBox.Charts[chartBox.BaseChartIndex].Values;
		int  iElements = data.Nodes().Count();
		
		if(iElements <= period)
		{
			MessageBox.Show("Period is too big. Decrease period by Settings/Common tools", "Warning");
			return;
		}
		
		List<float> ticks = new List<float>();
		//int iCount = 0;
		
		float dFirst = Convert.ToSingle(data.Elements("quote").ElementAt(0).Element("close").Value);
		float dFirstSum = 0;
		float dNext = 0;
		float dNextSum = 0;
		
		int t;
		
		for(t = 0; t < period; t++)
		{
			dFirstSum += Convert.ToSingle(data.Elements("quote").ElementAt(t).Element("close").Value);
		}
		
		ticks.Add(dFirstSum / period);
		
		for(t = 1; t < iElements - period; t++)
		{
			
			dNext = Convert.ToSingle(data.Elements("quote").ElementAt(t + period - 1).Element("close").Value);
			dNextSum = dFirstSum + dNext - dFirst;
			
			dFirst = Convert.ToSingle(data.Elements("quote").ElementAt(t).Element("close").Value);
			dFirstSum = dNextSum;
			
			ticks.Add(dFirstSum / period);
		}
		
		XElement x = new XElement("quotes");
		
		foreach(float i in ticks)
		{
			x.Add(new XElement("quote", new XAttribute("TYPE", "EOD"), new XElement("close", i)));
		}
		
		chart = new Chart(x);
		chart.Type = GraphicsProvider.Chart.ChartType.Line;
		chart.LineColor = color;
		chart.UpColor = Color.Green;
		chart.DownColor = Color.Red;
		chart.FirstElement = period;
		chart.IsCommon = isUsedAsCommon;
		chartBox.Charts.Add(chart);
		chartBox.Calculate(chart);
	}
}

public class SMAForm : Form
{
	public SMAForm()
	{
		this.Text = "Period";
		this.Size = new Size(180, 90);
		this.FormBorderStyle = FormBorderStyle.FixedDialog;
		this.StartPosition = FormStartPosition.CenterParent;
		this.ControlBox = false;
		this.ShowInTaskbar = false;
			
		Label label = new Label();
		label.Location = new Point(3,1);
		label.Size = new Size(60,20);
		label.Text = "Period:";
			
		TextBox textBox = new TextBox();
		textBox.Location = new Point(70,1);
		textBox.Size = new Size(100,20);
		
		Button close = new Button();
		close.Location = new Point(1,35);
		close.Size = new Size(60,20);
		close.Text = "Close";
		close.Click += new EventHandler(Close_Click);
			
		this.Controls.Add(label);
		this.Controls.Add(textBox);
		this.Controls.Add(close);
	}
	
	private void Close_Click(object sender, EventArgs e)
	{
		this.Close();
	}
}