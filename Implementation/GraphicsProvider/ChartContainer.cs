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
 * Date: 29.05.2009
 * Time: 12:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Configuration;

namespace GraphicsProvider
{
	public class ChartContainer : Panel
	{
		//
		// private members
		//
		
		private int iSubHeight;
		
		private bool notResize = false;
		
		//
		//  Public members
		//
		
		public ChartBox chartBox;
		public valPresageConfig config;
		
		public List<Guid> DisplayedUIDs;
		
		public bool NotResize
		{
			get { return notResize; }
		}
		
		//
		// Constructor
		//
		
		public ChartContainer()
		{
			DisplayedUIDs = new List<Guid>();
		}
		
		//
		// Public members
		//
		
		public ChartBox AddSubChart()
		{
			this.ResizeMainChart(true);
			this.ResizeSubCharts(true);
			
			ChartBox newBox = this.AddChart();
			
			return newBox;
		}
		
		public void RemoveSubChart()
		{
			if(this.Controls.Count != 1)
			{
				ChartBox thisBox = (ChartBox)this.Controls[this.Controls.Count - 1];
				thisBox.DisposePrice();
				this.Controls.Remove(thisBox);
				
				if(this.Controls.Count == 1)
				{
					chartBox.Height = this.Height - 19;
				}
				else if(this.Controls.Count == 2)
				{
					decimal dHeight = this.Height - 19;
					dHeight = dHeight / 100 * 65;
					dHeight = Decimal.Round(dHeight, 0);
					chartBox.Height = Convert.ToInt32(dHeight);
					
					this.ResizeSubCharts(false);
				}
				else
				{
					this.ResizeSubCharts(false);
				}
			}
		}
		
		public void ResizeMainChart(bool isNew)
		{
			decimal dHeight = this.Height - 19;
			
			if(this.Controls.Count == 1)
			{
				dHeight = dHeight / 100 * 65;
			}
			else if(this.Controls.Count == 2)
			{
				if(isNew)
				{
					dHeight = dHeight / 100 * 50;
				}
				else
				{
					dHeight = dHeight / 100 * 65;
				}
			}
			else
			{
				dHeight = dHeight / 100 * 50;
			}
			
			dHeight = Decimal.Round(dHeight, 0);
			this.notResize = true;
			chartBox.Height = Convert.ToInt32(dHeight);
			this.notResize = false;
		}
		
		public void ResizeSubCharts(bool isNew)
		{
			iSubHeight = this.Height - 19 - chartBox.Height;
			
			if(this.Controls.Count != 1)
			{
				if(isNew)
				{
					iSubHeight = Convert.ToInt32(Decimal.Round(iSubHeight / (this.Controls.Count), 0));
				}
				else
				{
					iSubHeight = Convert.ToInt32(Decimal.Round(iSubHeight / (this.Controls.Count - 1), 0));
				}
				
				for(int i = 1; i < this.Controls.Count; i++)
				{
					PictureBox box = (PictureBox)this.Controls[i];
					
					box.Height = iSubHeight;
					box.Location = new Point(chartBox.Location.X, chartBox.Height + (iSubHeight * (i - 1)));
				}
				
				for(int i = 1; i < this.Controls.Count; i++)
				{
					ChartBox box = (ChartBox)this.Controls[i];
					
					box.CalculateAll();
					box.DrawAll();
					
					box.DisposePrice();
					box.DrawPrice();
					
					box.Image = box.PureImage;
				}
			}
		}
		
		public void ChangeSubChartsWidth()
		{
			for(int i = 1; i < this.Controls.Count; i++)
			{
				PictureBox box = (PictureBox)this.Controls[i];
				box.Width = chartBox.Width;
			}
		}
		
		public ChartBox AddChart()
		{
			ChartBox newBox = new ChartBox();
			
			//newBox.UID = Guid.NewGuid();
			
			newBox.HorizontalValues = config.IsHorizontalValues;
			newBox.VerticalValues = config.IsVerticalValues;
			newBox.HorizontalGrid = config.IsHorizontalGrid;
			newBox.VerticalGrid = config.IsVerticalGrid;
			newBox.HGridLines = config.HGridLines;
			newBox.VGridLines = config.VGridLines;
				
			newBox.GridColor = config.GridColor;
			newBox.TickColor = config.TickColor;
			newBox.TextColor = config.TextColor;
			newBox.GridTextColor = config.GridTextColor;
			newBox.FrameColor = config.FrameColor;
			newBox.BackColor = config.BackColor;
			
			//newBox.SetHPeriod(chartBox.HBasePeriod);
			
			newBox.Size = new Size(chartBox.Width, iSubHeight);
			newBox.Location = new Point(chartBox.Location.X, chartBox.Height + (iSubHeight * (this.Controls.Count - 1)));
			//newBox.BorderStyle = BorderStyle.FixedSingle; // TO REMOVE
			this.Controls.Add(newBox);
			
			return newBox;
		}
	}
}