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

public class Line : IGraphicsProvider
{
	string myPluginName = "Line";
	string myPluginAuthor = "Dzmitry Hatouka";
	string myPluginDescription = "This plugin draws a line at specified positions";
	string myPluginVersion = "Pre-Alpha 2";

	bool isCommon = false;
	
	Guid uid;
	
	ChartBox chartBox;
	LayerManager layerManager;
	ConfigManager configManager;
	
	XElement x;

	//
	// Plugin specific members
	//
	
	private MouseEventHandler mouseDown;
	
	private int x1Pos;
	private int x2Pos;
	private int y1Pos;
	private int y2Pos;

	private DateTime x1Date;
	private decimal y1Price;
	private bool isFirst;
	
	private Color color;
	
	// isActual
	
	int iWidth;
	int iHeight;
	string firstDate;
	string lastDate;

	public Line()
	{

	}

	public void Activate()
	{
		if(this.IsActual)
		{
			this.DrawLine();
		}
		else
		{
			iWidth = this.chartBox.Width;
			iHeight = this.chartBox.Height;
			firstDate = chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").First().Value;
			lastDate = chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").Last().Value;
			
			isFirst = true;

			if(x == null)
			{
				uid = layerManager.NewUID();
				
				mouseDown = new System.Windows.Forms.MouseEventHandler(this.chartBox_MouseDown);
				chartBox.MouseDown += mouseDown;
			}
			else
			{
				uid = (Guid)x.Attribute("uid");
				
				x1Pos = chartBox.GetX((DateTime)x.Element("x1"));
				y1Pos = chartBox.GetY((float)x.Element("y1"));

				x2Pos = chartBox.GetX((DateTime)x.Element("x2"));
				y2Pos = chartBox.GetY((float)x.Element("y2"));
			
				color = Color.FromArgb(Convert.ToInt32(x.Element("color").Value));
			
				this.DrawLine();
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
		MessageBox.Show("This plugin is not configurable");
	}

	public void ConfigureCommon()
	{
	}
	
	//
	// Private methods
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
		get { return x; }
		set { x = value; }
	}

	public ConfigManager Config
	{
		get { return configManager; }
		set { configManager = value; }
	}

	public string Description
	{
		get	{ return myPluginDescription; }
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
		get{ return myPluginName; }
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
	// Plugin specific methods
	//
	
	private void chartBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		if(isFirst)
		{
			x1Date = chartBox.GetDate(e.X);
			y1Price = chartBox.GetPrice(e.Y);

			isFirst = false;
		}
		else
		{
			x2Pos = e.X;
			y2Pos = e.Y;

			x1Pos = chartBox.GetX(x1Date);
			y1Pos = chartBox.GetY(Convert.ToSingle(y1Price));
			
			color = this.chartBox.ToolColor;

			x = new XElement("layer");
			x.Add(new XElement("x1", x1Date));
			x.Add(new XElement("y1", y1Price));
			x.Add(new XElement("x2", chartBox.GetDate(x2Pos)));
			x.Add(new XElement("y2", chartBox.GetPrice(y2Pos)));
			x.Add(new XElement("color", color.ToArgb()));

			layerManager.AddLayer(x);

			isFirst = true;
			
			//DrawLine();
		}
	}

	private void DrawLine()
	{
		Pen linePen = new Pen(color, 1);
		
		Graphics g = Graphics.FromImage(chartBox.Image);
		g.DrawLine(linePen, x1Pos, y1Pos, x2Pos, y2Pos);
		g.Dispose();
	}
}
