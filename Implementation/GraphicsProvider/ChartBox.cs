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

using System;
using System.Drawing;
using System.Windows.Forms;

using System.Data;
using System.Linq;
using System.Xml.Linq;

using System.Collections.Generic;

namespace GraphicsProvider
{
	public class ChartBox : PictureBox
	{
		//
		// Private propherties
		//
		
		private bool isHorizontalValues;
		private bool isVerticalValues;
		private bool isHorizontalGrid;
		private bool isVerticalGrid;

		private Color frameColor;
		private Color gridColor;
		private Color textColor;
		private Color gridTextColor;
		private Color tickColor;
		
		// New in alpha-2
		
		private Color toolColor;
		private bool isFixedPeriod;
		private Guid uid;
		
		//
				
		private int iHGridLines;
		private int iVGridLines;
		private int baseChartIndex;
		private int X; // Nodes().Count();

		//
		// Other private propherties
		//
		
		private int iElements;
		private int iStHor;
		
		private float hPeriod;
		private float vPeriod;
		private float hPeriodVolume;
		private float vPeriodVolume;
		private float dMax;
		public float dMin;
		private float dMaxVolume;
		private float dMinVolume;
		private float dHorPos;
		
		// For base chart
		
		private int iBaseElements;
		private float hBasePeriod;
		private float vBasePeriod;
		private float dBaseMax;
		private float dBaseMin;
		
		private Bitmap pureImage;
				
		private Font gridFont;
		private SolidBrush gridBrush;
		private Pen gridPen;
		
		private List<Pixel> pixels;
		
		// New in Alpha-1
		
		Graphics graphics;
		
		List<PictureBox> priceList;
		
		//
		// Public propherties
		//
		
		public bool HorizontalValues
		{
			get { return isHorizontalValues; }
			set { isHorizontalValues = value; }
		}
		public bool VerticalValues
		{
			get { return isVerticalValues; }
			set { isVerticalValues = value; }
		}
		public bool HorizontalGrid
		{
			get { return isHorizontalGrid; }
			set { isHorizontalGrid = value; }
		}
		public bool VerticalGrid
		{
			get { return isVerticalGrid; }
			set { isVerticalGrid = value; }
		}
		
		public Color FrameColor
		{
			get { return frameColor; }
			set { frameColor = value; }
		}
		public Color GridColor
		{
			get { return gridColor; }
			set { gridColor = value; }
		}
		public Color TextColor
		{
			get { return textColor; }
			set { textColor = value; }
		}
		public Color GridTextColor
		{
			get { return gridTextColor; }
			set { gridTextColor = value; }
		}
		public Color TickColor
		{
			get { return tickColor; }
			set { tickColor = value; }
		}
		
		// New in alpha-2
		
		public Color ToolColor
		{
			get { return toolColor; }
			set { toolColor = value; }
		}
		
		public Guid UID
		{
			get { return uid; }
			set { uid = value; }
		}
		
		public bool IsPrimary	// TO REMOVE ?
		{
			get
			{
				Panel parentPanel = (Panel)this.Parent;
				
				if(this == parentPanel.Controls[0])
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		
		//
		
		public int HGridLines
		{
			get { return iHGridLines; }
			set { iHGridLines = value; }
		}
		public int VGridLines
		{
			get { return iVGridLines; }
			set { iVGridLines = value; }
		}
		public int BaseChartIndex
		{
			get { return baseChartIndex; }
			set { baseChartIndex = value; }
		}

		//
		// Full image
		//

		public Bitmap PureImage
		{
			get { return pureImage; }
		}
		
		//
		// For base chart
		//
		
		public int Elements
		{
			get { return iBaseElements; }
		}
		
		public float HBasePeriod
		{
			get { return hBasePeriod; }
		}
		public float VBasePeriod
		{
			get { return vBasePeriod; }
		}
		public float BaseMax
		{
			get { return dBaseMax; }
		}
		public float BaseMin
		{
			get { return dBaseMin; }
		}

		//
		// Layers
		//
		
		public ChartCollection Charts;
		
		//
		// Constructor
		//
		
		public ChartBox()
		{
			this.isHorizontalValues = false;
			this.isVerticalValues = false;
			this.isHorizontalGrid = false;
			this.isVerticalGrid = false;
			
			this.gridColor = Color.Gray;
			this.tickColor = Color.Green;
			this.textColor = Color.Gray;
			this.gridTextColor = Color.Black;
			this.frameColor = Color.Black;
			this.toolColor = Color.Black;
			
			this.iHGridLines = 0;
			this.iVGridLines = 0;
			
			Charts = new ChartCollection();
			
			//
			// New in alpha-2
			//
			
			isFixedPeriod = false;
			
			baseChartIndex = 0;
			
			// end
			
			this.Resize += new EventHandler(ChartBox_Resize);
		}
		
		//
		// Public methods
		//
		
		public void CalculateAll()
		{
			if((baseChartIndex > Charts.Count - 1)||(baseChartIndex < 0))
			{
				throw new ChartException("BaseChartIndex is out of range");
			}
			if((this.Charts[baseChartIndex] == null)||(this.Charts[baseChartIndex].Values == null))
			{
				throw new ChartException("BaseChartIndex is not set");
			}

			int iNodes = Charts[baseChartIndex].Values.Nodes().Count();

			if((Charts[baseChartIndex].Type == Chart.ChartType.Line)||(Charts[baseChartIndex].Type == Chart.ChartType.Volume))
			{
				X = iNodes;
			}
			else if(Charts[baseChartIndex].Type == Chart.ChartType.Bar)
			{
				X = iNodes * 6;
			}
			else if(Charts[baseChartIndex].Type == Chart.ChartType.Candle)
			{
				X = iNodes * 8;
			}
			//else
			//{
			//	throw new ChartException("BaseChartIndex Type is not correct");
			//}   // TO REMOVE

			if(X < this.Width)
			{
				X = this.Width;
			}

			if(Charts.Count == 0)
			{
				throw new ChartException("No charts were added");
			}
			
			// New in Alpha-1
			
			this.pureImage = new Bitmap(X, this.Height);
					
			IEnumerable<Chart> volumeCharts = (from c in this.Charts where (Chart.ChartType)c.Type == Chart.ChartType.Volume select c);
			
			if(volumeCharts.Count() > 1)
			{
				throw new ChartException("ChartBox can not contain more than one volume");
			}
			else if(volumeCharts.Count() == 1)
			{
				this.GetPeriods(volumeCharts.ElementAt(0));
				this.Calculate(volumeCharts.ElementAt(0));
			}
			
			Chart baseChart = Charts[BaseChartIndex];
			
			this.GetPeriods(baseChart);
			this.Calculate(baseChart);
			
			foreach(Chart currentChart in Charts)
			{
				if((currentChart != baseChart)&&(currentChart != volumeCharts.ElementAt(0)))
				{
					this.Calculate(currentChart);
				}
			}
		}
		
		public void DrawAll()
		{
			foreach(Chart currentChart in Charts)
			{
				Chart chart = currentChart;
				
				this.DrawChart(chart);
			}
			
			graphics = Graphics.FromImage(this.pureImage);
			
			if ((this.iVGridLines > 0) && ((this.isVerticalGrid) || (this.isVerticalValues)))
            {
                this.DrawVerticalGrid();
            }

            if ((this.iHGridLines > 0) && ((this.isHorizontalGrid) || (this.isHorizontalValues)))
            {
                this.DrawHorizontalGrid();
            }
            
            graphics.Dispose();
		}
		
		public void Calculate(Chart chart)
		{
			if(chart.Values == null)
			{
				throw new ChartException("Values for chart are not defined");
			}
			
			if(chart.Type == Chart.ChartType.Volume)
			{
				this.CalculateVolumeValues(chart);
			}
			else if(chart.Type == Chart.ChartType.Line)
			{
				this.CalculateLineChartValues(chart);
			}
			else
			{
				this.CalculateBarChartValues(chart);
			}
		}
		
		public void DrawChart(Chart chart)
		{
			if(!chart.IsCommon)
			{
				chart.Bitmap = new Bitmap(pureImage.Width, pureImage.Height);
				chart.Bitmap.MakeTransparent(this.BackColor);
			
				graphics = Graphics.FromImage(chart.Bitmap);
			}
			else
			{
				graphics = Graphics.FromImage(pureImage);
			}
			
			if(chart.Type == Chart.ChartType.Line)
			{
				this.DrawLineChart(chart);
			}
			else if(chart.Type == Chart.ChartType.Bar)
			{
				this.DrawBarChart(chart);
			}
			else if(chart.Type == Chart.ChartType.Candle)
			{
				this.DrawCandleChart(chart);
			}
			else if(chart.Type == Chart.ChartType.Volume)
			{
				this.DrawVolume(chart);
			}
			
			graphics.Dispose();
		}
		
		public decimal GetPrice(int y)
		{
			{
				return Convert.ToDecimal((this.Height - y) / vBasePeriod + dMin);
			}
		}
		
		public int GetY(float dPrice)
		{
			return Convert.ToInt32((dBaseMin - dPrice) * vBasePeriod + this.Height );
		}

		public DateTime GetDate(int x)
		{
       		int iDate = -1;

			iDate = Convert.ToInt32(x / hBasePeriod);
			
			if(iDate >= iBaseElements)
			{
				iDate = iBaseElements - 1;
			}

			if(iDate < 0)
			{
				iDate = 0;
			}
			
			return (DateTime)Charts[baseChartIndex].Values.Elements("quote").ElementAt(iDate).Element("date");
		}
		
		public int GetX(DateTime dateTime)
		{
			if((from c in Charts[baseChartIndex].Values.Elements("quote").Elements("date") select (DateTime)c).Contains(dateTime))
			{
                XElement x = (from c in Charts[baseChartIndex].Values.Elements("quote") where (DateTime)c.Element("date") == dateTime select c).Max();
                int iIndex = x.NodesBeforeSelf().Count();

                return Convert.ToInt32(iIndex * hBasePeriod);
			}
			else
			{
				return -1;
			}
		}
		
		public void PutTick(int x, int y)
		{
			int newX = x;
			int newY = y;
			
			while(newX > this.Width - 3)
			{
				newX--;
			}
			while(newX < 2)
			{
				newX++;
			}
			
			while(newY > this.Height - 3)
			{
				newY--;
			}
			while(newY < 2)
			{
				newY++;
			}
			
			Bitmap chartImage = (Bitmap)this.Image;
			
			if(pixels != null)
			{
				foreach(Pixel pixel in pixels)
				{
					chartImage.SetPixel(pixel.X, pixel.Y, pixel.Color);
				}
			}
			
			pixels = new List<Pixel>();
			
			pixels.Add(new Pixel(newX, newY, chartImage.GetPixel(newX, newY)));
			pixels.Add(new Pixel(newX, newY - 1, chartImage.GetPixel(newX, newY - 1)));
			pixels.Add(new Pixel(newX, newY - 2, chartImage.GetPixel(newX, newY - 2)));
			pixels.Add(new Pixel(newX, newY + 1, chartImage.GetPixel(newX, newY + 1)));
			pixels.Add(new Pixel(newX, newY + 2, chartImage.GetPixel(newX, newY + 2)));
			
			pixels.Add(new Pixel(newX - 1, newY, chartImage.GetPixel(newX - 1, newY)));
			pixels.Add(new Pixel(newX - 2, newY, chartImage.GetPixel(newX - 2, newY)));
			pixels.Add(new Pixel(newX + 1, newY, chartImage.GetPixel(newX + 1, newY)));
			pixels.Add(new Pixel(newX + 2, newY, chartImage.GetPixel(newX + 2, newY)));
			
			foreach(Pixel pixel in pixels)
			{
				chartImage.SetPixel(pixel.X, pixel.Y, tickColor);
			}
			
			this.Invalidate();
		}

		public void Reset()
		{
			this.Charts.Clear();
			pixels = null;
			
			this.DisposePrice();
		}
		
		public void DisposePrice()
		{
			if(priceList != null)
			{
				Form formChart = (Form)this.Parent.Parent;
			
				foreach(PictureBox pictureBox in priceList)
				{
					formChart.Controls.Remove(pictureBox);
					pictureBox.Dispose();
				}
				
				priceList = null;
			}
		}
		
		//
		// New in alpha-1
		//
		
		public void DrawPrice()
		{
			if(this.isHorizontalValues)
			{
				this.DisposePrice();
				
				priceList = new List<PictureBox>();
				
				Panel parentPanel = (Panel)this.Parent;
				Form parent = (Form)parentPanel.Parent;
			
				float dGridPeriod = this.Height / this.iHGridLines;
			
				gridFont = new Font("Courier", 6F, FontStyle.Regular);
				gridBrush = new SolidBrush(gridTextColor);
				
				for(int i = this.iHGridLines; i > 0; i--)
				{
					int iYPos = Convert.ToInt32(this.Height - i * dGridPeriod + 9 + this.Location.Y);
					
					decimal dPrice = GetPrice(iYPos - this.Location.Y);
					dPrice = Decimal.Round(dPrice, 2);
					string price = dPrice.ToString();
					
					PictureBox pictureBox = new PictureBox();
					pictureBox.BackColor = this.BackColor;
					pictureBox.Location = new Point(2, iYPos - 9 + 25);
					pictureBox.Size = new Size(5 * price.Length, 7);
					
					Bitmap smallBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
					pictureBox.Image = smallBitmap;
					
					Graphics smallGraphics = Graphics.FromImage(pictureBox.Image);
					smallGraphics.DrawString(price, gridFont, gridBrush,-1,-1);
					smallGraphics.Dispose();
					
					parent.Controls.Add(pictureBox);
					pictureBox.BringToFront();
					
					priceList.Add(pictureBox);
				}
			}
		}
		
		//
		// New in alpha-2
		//
		
		public void RemoveTick()
		{
			this.PutTick(0,0);
		}
		
		public void SetHPeriod(float period)
		{
			isFixedPeriod = true;
			hPeriod = period;
		}
		
		public ChartBox AddSubChart()
		{
			ChartContainer chartContainer = (ChartContainer)this.Parent;
			
			return chartContainer.AddSubChart();
		}
		
		public bool IsMainChart()
		{
			Panel parent = (Panel)this.Parent;
			
			return ((ChartBox)parent.Controls[0] == this);
		}
		
		//
		// Private methods
		//
		
		private void ChartBox_Resize(object sender, System.EventArgs e)
		{
			pixels = null;
		}
				
		private void CalculateLineChartValues(Chart chart)
		{
			chart.Calculated = new DataTable();
			chart.Calculated.Columns.Add("X", typeof(int));
			chart.Calculated.Columns.Add("Y", typeof(int));
			
			dHorPos = 1 + chart.FirstElement * hPeriod;
			
			foreach(XElement element in chart.Values.Elements())
			{
				iStHor = Convert.ToInt32(dHorPos);
				
				float close = (float)element.Element("close") - dMin;
				close *= vPeriod;
				
				close = this.Height - close - 3;
				
				chart.Calculated.Rows.Add(iStHor, Convert.ToInt32(close));
				
				dHorPos += hPeriod;
			}
		}
		
		private void CalculateBarChartValues(Chart chart)
		{
			chart.Calculated = new DataTable();
			chart.Calculated.Columns.Add("X", typeof(int));
			chart.Calculated.Columns.Add("Open", typeof(int));
			chart.Calculated.Columns.Add("Close", typeof(int));
			chart.Calculated.Columns.Add("High", typeof(int));
			chart.Calculated.Columns.Add("Low", typeof(int));
			
			if(chart.Type == Chart.ChartType.Bar)
			{
				dHorPos = 3;
			}
			else
			{
				dHorPos = 4;
			}
			
			dHorPos += chart.FirstElement * hPeriod;
			
			foreach(XElement element in chart.Values.Elements())
			{
				iStHor = Convert.ToInt32(dHorPos);
				
				float dLow = (float)element.Element("low") - dMin;
				float dHigh = (float)element.Element("high") - dMin;
			
				float dOpen = (float)element.Element("open") - dMin;
				float dClose = (float)element.Element("close") - dMin;
				
				int iLow = System.Convert.ToInt32(dLow * vPeriod);
				iLow = this.Height - iLow - 4;

				int iHigh = System.Convert.ToInt32(dHigh * vPeriod);
				iHigh = this.Height - iHigh - 4;

				int iOpen = System.Convert.ToInt32(dOpen * vPeriod);
				iOpen = this.Height - iOpen - 4;

				int iClose = System.Convert.ToInt32(dClose * vPeriod);
				iClose = this.Height - iClose - 4;

				chart.Calculated.Rows.Add(iStHor, iOpen, iClose, iHigh, iLow);
				
				dHorPos += hPeriod;
			}
		}
		
		private void CalculateVolumeValues(Chart chart)
		{
			chart.Calculated = new DataTable("VOLUME");
			chart.Calculated.Columns.Add("X", typeof(int));
			chart.Calculated.Columns.Add("Y", typeof(int));
			
			dHorPos = 1;
			iStHor = 1;
			
			foreach(XElement element in chart.Values.Elements())
			{
				long volume = (long)element.Element("volume");
				volume = Convert.ToInt32(volume * vPeriodVolume);
				
				volume = this.Height - volume - 2;
				
				chart.Calculated.Rows.Add(iStHor, volume);
				
				dHorPos += hPeriodVolume;
				iStHor = Convert.ToInt32(dHorPos);
			}
		}
		
		private void GetPeriods(Chart chart)
		{
			iElements = chart.Values.Elements().Count();
			
			iBaseElements = iElements;
			
			if(!isFixedPeriod)
			{
				if(chart.Type == Chart.ChartType.Volume)
				{
					hPeriodVolume = (X - 2) / Convert.ToSingle(iElements);
					
					dMaxVolume = (from c in chart.Values.Elements("quote") select (long)c.Element("volume")).Max();
					dMinVolume = (from c in chart.Values.Elements("quote") select (long)c.Element("volume")).Min();
				
					dMax = dMaxVolume;
					dMin = dMinVolume;

					if(!isFixedPeriod)
					{
						if(this.IsMainChart())
						{
							vPeriodVolume = this.Height / ((dMaxVolume - dMinVolume) * 2);
						}
						else
						{
							vPeriodVolume = this.Height / (dMaxVolume - dMinVolume);
						}
				
						if(this.baseChartIndex == this.Charts.IndexOf(chart))
						{
							hBasePeriod = hPeriodVolume;
							vBasePeriod = vPeriodVolume;
						}
					}
				}
				else
				{
					if((chart.Type == Chart.ChartType.Line)||(chart.Type == Chart.ChartType.Volume))
					{
						hPeriod = X / Convert.ToSingle(iElements);
					}
					else
					{	
						hPeriod = (X - 6) / Convert.ToSingle(iElements);
					}
	
					dMax = (from c in chart.Values.Elements("quote") select (float)c.Element("high")).Max();
					dMin = (from c in chart.Values.Elements("quote") select (float)c.Element("low")).Min();
			
					vPeriod = (this.Height - 8) / (dMax - dMin);
				
					hBasePeriod = hPeriod;
					vBasePeriod = vPeriod;
				
					dBaseMax = dMax;
					dBaseMin = dMin;
				}
			}
		}
		
		//
		// Private methods to draw charts
		//
		
		private void DrawVolume(Chart chart)
		{
			Pen volumePen = new Pen(chart.VolumeColor,1);
			
			foreach(DataRow row in chart.Calculated.Rows)
			{
				graphics.DrawLine(volumePen, (int)row["X"], this.Height - 2, (int)row["X"], (int)row["Y"]);
				// MessageBox.Show(row["X"].ToString() + " " + (this.Height - 2).ToString() + " " + row["X"].ToString() + " " + row["Y"].ToString()); // TO REMOVE
			}
		}
		
		private void DrawLineChart(Chart chart)
		{
			Pen linePen = new Pen(chart.LineColor,1);
			
			int X = -1;
			int Y = -1;
			
			foreach(DataRow row in chart.Calculated.Rows)
			{
				if(X == -1)
				{
					X = (int)row[0];
					Y = (int)row[1];
				}
				else
				{
					graphics.DrawLine(linePen, X,Y, (int)row[0], (int)row[1]);
					
					X = (int)row[0];
					Y = (int)row[1];
				}
			}
		}
		
		private void DrawBarChart(Chart chart)
		{
			Pen upPen = new Pen(chart.UpColor,1);
			Pen downPen = new Pen(chart.DownColor,1);
			
			foreach(DataRow row in chart.Calculated.Rows)
			{
				Pen barPen;
				
				int X = (int)row[0];
				int iOpen = (int)row[1];
				int iClose = (int)row[2];
				int iHigh = (int)row[3];
				int iLow = (int)row[4];
				
				if(iOpen < iClose)
				{
					barPen = downPen;
				}
				else
				{
					barPen = upPen;
				}
				
				graphics.DrawLine(barPen, X, iLow, X, iHigh);
				graphics.DrawLine(barPen, X - 2, iOpen, X, iOpen);
				graphics.DrawLine(barPen, X, iClose, X + 2, iClose);
			}
		}
		
		private void DrawCandleChart(Chart chart)
		{
			Pen linePen = new Pen(chart.LineColor,1);
			Pen upPen = new Pen(chart.UpColor,1);
			Pen downPen = new Pen(chart.DownColor,1);
			
			foreach(DataRow row in chart.Calculated.Rows)
			{
				int X = (int)row[0];
				int iOpen = (int)row[1];
				int iClose = (int)row[2];
				int iHigh = (int)row[3];
				int iLow = (int)row[4];
				
				if(iOpen == iClose)
				{
					graphics.DrawLine(linePen, X, iClose, X, iHigh);
					graphics.DrawLine(linePen, X, iLow, X, iOpen);
					graphics.DrawLine(linePen, X - 2, iOpen, X + 2, iOpen);
				}
				else if(iOpen < iClose)
				{
					graphics.DrawRectangle(linePen, X - 2, iOpen, 4, iClose - iOpen);
					graphics.DrawLine(linePen, X, iOpen, X, iHigh);
					graphics.DrawLine(linePen, X, iClose, X, iLow);
					graphics.FillRectangle(new SolidBrush(chart.DownColor),X - 1, iOpen + 1, 3 ,iClose - iOpen - 1);
				}
				else
				{
					graphics.DrawRectangle(linePen, X - 2, iClose, 4, iOpen - iClose);
					graphics.DrawLine(linePen, X, iClose, X, iHigh);
					graphics.DrawLine(linePen, X, iOpen, X, iLow);
					graphics.FillRectangle(new SolidBrush(chart.UpColor),X - 1, iClose + 1, 3 ,iOpen - iClose - 1);
				}
			}
		}
		
		// 
		// Draw grids and values
		//
		
		private void DrawVerticalGrid()
		{
			decimal lines = Convert.ToDecimal(iVGridLines) * (Convert.ToDecimal(pureImage.Width) / Convert.ToDecimal(this.Parent.Width));
			lines = Decimal.Round(lines);
			int iVLines = Convert.ToInt32(lines);
			float dGridPeriod = X / iVLines;
			
			gridFont = new Font("Courier", 6F, FontStyle.Regular);
			gridBrush = new SolidBrush(gridTextColor);
			gridPen = new Pen(gridColor, 1);
			
			for(int i = iVLines; i > 0; i--)
			{
				int iXPos = Convert.ToInt32(X - i * dGridPeriod + 9);
				
				if(this.isVerticalGrid)
				{
					for(int t = 6; t < this.Height - 3; t += 9)
					{
						graphics.DrawLine(gridPen, iXPos, t, iXPos, t + 4);
					}
				}
				
				if(this.isVerticalValues)
				{
					graphics.DrawString(this.GetDate(iXPos).ToShortDateString(), gridFont, gridBrush, iXPos + 2, this.Height - 10);
				}
			}
		}
		
		private void DrawHorizontalGrid()
		{
			float dGridPeriod = this.Height / this.iHGridLines;
			
			gridPen = new Pen(gridColor, 1);

			for(int i = this.iHGridLines; i > 0; i--)
			{
				int iYPos = Convert.ToInt32(this.Height - i * dGridPeriod + 9);
				
				if(this.isHorizontalGrid)
				{
					for(int t = 6; t < X - 3; t += 9)
					{
						graphics.DrawLine(gridPen, t, iYPos, t + 4, iYPos);
					}
				}
			}
		}
	}
}
