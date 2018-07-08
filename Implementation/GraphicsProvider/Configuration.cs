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
 * Time: 12:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Configuration
{
	[Serializable]
	public class valPresageConfig
	{
		public bool IsHorizontalValues;
		public bool IsVerticalValues;
		public bool IsHorizontalGrid;
		public bool IsVerticalGrid;
		public bool IsVolume;
		
		public Color GridColor;
		public Color TickColor;
		public Color TextColor;
		public Color GridTextColor;
		public Color FrameColor;
		public Color BackColor;
		
		public Color LineColor;
		public Color UpColor;
		public Color DownColor;
		public Color VolumeColor;
		
		public int HGridLines;
		public int VGridLines;

		public GraphicsProvider.Chart.ChartType Type;
		
		//
		// HTTP Config
		//
		
		public bool IsProxy;
		
		public string Server;
		public string Port;
		public string Login;
		public string Password;
		
		//
		// Common plugins config
		//
		
        //
        // Symbols config
        //

        public Dictionary<string, string> Symbols = new Dictionary<string, string>();
        
        //
        // Default data source
        //
        
        public string DefaultDataSource;
        
        //
        // ChartBox.ToolColor
        //
        
        public Color ToolColor;
        
        //
        // Default period index
        //
        
        public int Period;
	}
}