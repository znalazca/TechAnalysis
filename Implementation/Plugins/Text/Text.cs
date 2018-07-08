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

public class Text : IGraphicsProvider
{
	string myPluginName = "Text";
	string myPluginAuthor = "Dzmitry Hatouka";
	string myPluginDescription = "This plugin displays text at specified position";
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
	private SolidBrush textBrush;
	
	private string text;
	
	private int X;
	private int Y;
	
	private Color color;
	
	// isActual
	
	int iWidth;
	int iHeight;
	string firstDate;
	string lastDate;

	public Text()
	{

	}

	public void Activate()
	{
		if(this.IsActual)
		{
			DrawText(text, X, Y);
		}
		else
		{
			iWidth = this.chartBox.Width;
			iHeight = this.chartBox.Height;
			firstDate = chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").First().Value;
			lastDate = chartBox.Charts[chartBox.BaseChartIndex].Values.Element("quote").Elements("date").Last().Value;
			
			if(x == null)
			{
				uid = layerManager.NewUID();
				
				mouseDown = new System.Windows.Forms.MouseEventHandler(this.chartBox_MouseDown);
				chartBox.MouseDown += mouseDown;
			}
			else
			{
				uid = (Guid)x.Attribute("uid");
				
				X = chartBox.GetX((DateTime)x.Element("x"));
				Y = chartBox.GetY((float)x.Element("y"));
				text = x.Element("text").Value;
				
				color = Color.FromArgb(Convert.ToInt32(x.Element("color").Value));
				textBrush = new SolidBrush(color);

				DrawText(text, X, Y);
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
	// Plugin specific methods
	//
	
	private void chartBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		X = e.X;
		Y = e.Y;
		
		TextForm textForm = new TextForm();
		textForm.Closed += new EventHandler(TextForm_Closed);
		textForm.ShowDialog();
	}
	
	private void TextForm_Closed(object sender, EventArgs e)
	{
		Form textForm = (Form)sender;
		text = textForm.Controls[1].Text;
		
		color = this.chartBox.ToolColor;
		textBrush = new SolidBrush(color);
		
		x = new XElement("layer");
		x.Add(new XElement("text", text));
		x.Add(new XElement("color", color.ToArgb()));
		x.Add(new XElement("x", chartBox.GetDate(X)));
		x.Add(new XElement("y", chartBox.GetPrice(Y)));
		layerManager.AddLayer(x);
	}

	private void DrawText(string szText, int iX, int iY)
	{
		Graphics g = Graphics.FromImage(chartBox.Image);
		g.DrawString(szText, new System.Drawing.Font("Courier", 12F, System.Drawing.FontStyle.Bold), textBrush, iX, iY);
		g.Dispose();
	}
}

// Form

public class TextForm : Form
{
	public TextForm()
	{
		this.Text = "Text";
		this.Size = new Size(180, 90);
		this.FormBorderStyle = FormBorderStyle.FixedDialog;
		this.StartPosition = FormStartPosition.CenterParent;
		this.ControlBox = false;
		this.ShowInTaskbar = false;
			
		Label label = new Label();
		label.Location = new Point(3,1);
		label.Size = new Size(60,20);
		label.Text = "Text:";
			
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