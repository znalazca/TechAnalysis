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

public class SubChartNull : IGraphicsProvider
{
	string myPluginName = "SubChartNull";
	string myPluginAuthor = "Dzmitry Hatouka";
	string myPluginDescription = "This plugin tests subcharts design";
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
	
	//
	// IMPLEMENTATION
	//
	
	private MouseEventHandler mouseDown;
	
	
	
	public SubChartNull()
	{
		uid = Guid.NewGuid();
	}

	public void Activate()
	{
		iWidth = 0;
		iHeight = 0;
		firstDate = String.Empty;
		lastDate = String.Empty;
		
		mouseDown = new System.Windows.Forms.MouseEventHandler(this.chartBox_MouseDown);
		chartBox.MouseDown += mouseDown;
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
	
	//
	// Implementation
	//
	
	private void chartBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		chartBox.AddSubChart();
	}
}