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

using System.Data;
using System.Drawing;
using System.Xml.Linq;

namespace GraphicsProvider
{
	public class Chart
	{
		private Color lineColor;
		private Color upColor;
		private Color downColor;
		private Color volumeColor;

		private XElement values;
		
		private int firstElement;
		
		private DataTable calculated;
		
		private bool isCommon;
		
		private Bitmap bitmap;

		public Color LineColor
		{
			get { return lineColor; }
			set { lineColor = value; }
		}
		public Color UpColor
		{
			get { return upColor; }
			set { upColor = value; }
		}
		public Color DownColor
		{
			get { return downColor; }
			set { downColor = value; }
		}
		public Color VolumeColor
		{
			get { return volumeColor; }
			set { volumeColor = value; }
		}

		public XElement Values
		{
			get { return values; }
		}
		
		public int FirstElement
		{
			get { return firstElement; }
			set { firstElement = value; }
		}
		
		public DataTable Calculated
		{
			get { return calculated; }
			set { calculated = value; }
		}
		
		public bool IsCommon
		{
			get { return isCommon; }
			set { isCommon = value; }
		}
		
		public Bitmap Bitmap
		{
			get { return bitmap; }
			set { bitmap = value; }
		}

		public enum ChartType
		{
			Line,
			Bar,
			Candle,
			Volume
		}

		public ChartType Type;

		public Chart(XElement _values)
		{
			this.lineColor = Color.Black;
			this.upColor = Color.Green;
			this.downColor = Color.Red;
			this.volumeColor = Color.Silver;

			this.values = _values;
			
			this.firstElement = 0;

			this.Type = ChartType.Line;
			
			this.IsCommon = true;
		}
	}
}
