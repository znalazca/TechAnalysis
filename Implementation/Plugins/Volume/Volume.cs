using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using GraphicsInterface;
using GraphicsProvider;
using DataProvider;

public class Volume : IGraphicsProvider
{
	string myPluginName = "Volume";
	string myPluginAuthor = "Dzmitry Hatouka";
	string myPluginDescription = "This plugin displays volume in a separate chart";
	string myPluginVersion = "Alpha 2";

	bool isCommon = false;
	
	Guid uid;
	
	ChartBox chartBox;
	LayerManager layerManager;
	ConfigManager configManager;
	
	XElement xElement;
	
	// isActual
	
	int iWidth;
	int iHeight;
	string firstDate;
	string lastDate;
	bool isDrawn;
	
	//
	// IMPLEMENTATION
	//
	
	private MouseEventHandler mouseDown;
	
	Color color;
	
	public Volume()
	{

	}

	public void Activate()
	{
		if(this.IsActual)
		{
			return;
		}
		else
		{
			iWidth = 0;
			iHeight = 0;
			firstDate = String.Empty;
			lastDate = String.Empty;
		
			if(xElement == null)
			{
				uid = layerManager.NewUID();
			
				mouseDown = new System.Windows.Forms.MouseEventHandler(this.chartBox_MouseDown);
				chartBox.MouseDown += mouseDown;
			}
			else
			{
				color = Color.FromArgb(Convert.ToInt32(xElement.Element("color").Value));
				uid = (Guid)xElement.Attribute("uid");
			
				this.AddChart();
			}
		}
	}

	public void ActivateCommon()
	{
	}
		
	public void Deactivate()
	{
		chartBox.MouseDown -= mouseDown;
	}

	public void Configure()
	{
	}

	public void ConfigureCommon()
	{
	}
	
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
			if((this.chartBox.Width == iWidth)&&(chartBox.Height == iHeight)&&(chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").First().Value == firstDate)&&(chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").Last().Value == lastDate)&&(isDrawn))
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
	
	//
	// Implementation
	//
	
	private void chartBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		color = chartBox.ToolColor;
		
		xElement = new XElement("layer");
		xElement.Add(new XElement("color", color.ToArgb()));
		layerManager.AddLayer(xElement, true);
	}
	
	private void AddChart()
	{
		ChartBox subChart = chartBox.AddSubChart();
		subChart.UID = uid;
		//uid = subChart.UID;
		
		Chart volume = new Chart(chartBox.Charts[0].Values);
		volume.Type = GraphicsProvider.Chart.ChartType.Volume;
		volume.VolumeColor = color;
		
		subChart.Charts.Add(volume);
		
		subChart.BaseChartIndex = 0;
		
		subChart.CalculateAll();
		subChart.DrawAll();
		
		subChart.Image = subChart.PureImage;
		
		subChart.DrawPrice();
		
		isDrawn = true;
	}
}