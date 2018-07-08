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
 * User: kuhalska
 * Date: 16.05.2008
 * Time: 10:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataProvider
{
	//
	// Quotes Manager
	//
	
	public class QuotesManager
	{
		private string szPath;
		private string szSymbol;
		
		private bool isExists;
		
		private XElement element;
		
		public string Symbol
		{
			get { return szSymbol; }
		}
		
		public bool IsExists
		{
			get { return isExists; }
		}
		
		public XElement Data
		{
			get { return element; }
		}
		
		public QuotesManager(string symbol)
		{
			szSymbol = symbol;
			szPath = Directory.GetCurrentDirectory() + @"\Data\" + symbol + ".XML";
			isExists = File.Exists(szPath);
			
			if(!isExists)
			{
				element = new XElement("quotes");
			}
			else
			{
				element = XElement.Load(szPath);
			}
		}
		
		public int GetRowsCount()
		{
			return element.Nodes().Count();
		}
		
		public DateTime GetFirstDate()
		{
			return (DateTime)element.Elements("quote").First().Element("date");
		}
		
		public DateTime GetLastDate()
		{
			return (DateTime)element.Elements("quote").Last().Element("date");
		}
		
		public bool IsEOD()
		{
			if(element.Elements("quote").Last().Attribute("type").Value == "EOD")
			{
				return true;
			}
			else
			{
				return false;	
			}
		}
		
		public void AddRow(XElement x)
		{
			element.Add(x);
		}
		
		public void RemoveLastRow()
		{
			element.Elements("quote").Last().Remove();
		}
		
		public void SaveData()
		{
			element.Save(szPath);
		}
	}

	//
	// Layer Manager
	//
	
	public class LayerManager
	{
		private string szPlugin;
		
		private XElement element;
		
		private Guid uid;
		
		public XElement Data
		{
			get { return element; }
		}
		
		public Guid UID
		{
			get { return uid; }
		}
		
		public LayerManager(string plugin, XElement el)
		{
			szPlugin = plugin;
			element = el;
		}
		
		public Guid AddLayer(XElement x)
		{
			return AddLayer(x, false);
		}
		
		public Guid AddLayer(XElement x, bool isChart)
		{
			int iCount = 0;
			
			if(element.Nodes().Count() != 0)
			{
				iCount = (from c in element.Elements("layer").Attributes("count") select (int)c).Max();
			}

			x.SetAttributeValue("plugin", szPlugin);
			x.SetAttributeValue("count", iCount + 1);
			x.SetAttributeValue("chart", isChart);
			x.SetAttributeValue("uid", uid);
			element.Add(x);
			
			return uid;
		}
		
		public Guid NewUID()
		{
			uid = Guid.NewGuid();
			return uid;
		}
	}

	//
	// Symbol Manager
	//

	public class SymbolManager
	{
		private XElement element;
		
		public SymbolManager()
		{
		
		}

		public void DropAllLayers(string symbol)
		{
			if(File.Exists(GetLayerPath(symbol)))
			{
				File.Delete(GetLayerPath(symbol));
			}
		}
		
		// New in alpha-2
		
		public void DropAllCommonLayers()
		{
			if(File.Exists("layers.xml"))
			{
			   	File.Delete("layers.xml");
			}
		}
		
		public void DropLastLayer(string symbol)
		{
			if(File.Exists(GetLayerPath(symbol)))
			{
				element = XElement.Load(GetLayerPath(symbol));
				//element.Elements("layer").Last().Remove();
				int i = (from c in element.Elements("layer").Attributes("count") select (int)c).Max();
				(from c in element.Elements("layer") where (int)c.Attribute("count") == i select c).Remove();
				element.Save(GetLayerPath(symbol));
			}
			else
			{
				throw new DataProviderException("No layers for symbol " + symbol);
			}
		}
		
		// New in alpha-2
		
		public void DropCommonLayer(int iCount)
		{
			if(File.Exists("layers.xml"))
			{
				element = XElement.Load("layers.xml");
				
				string sCount = iCount.ToString();
				
				(from c in element.Elements("layer") where (string)c.Attribute("count").Value == sCount select c).First().Remove();
				
				element.Save("layers.xml");
			}
			else
			{
				throw new DataProviderException("No common layers");
			}
		}
			
		public void DropSymbol(string symbol)
		{
			string szSymbol;
			string szLayer;
			
			szSymbol = GetSymbolPath(symbol);
			szLayer = GetLayerPath(symbol);
			
			if(File.Exists(szSymbol))
			{
				File.Delete(szSymbol);
			}
			else
			{
				throw new DataProviderException("Symbol " + symbol + "could not be found");
			}
			
			if(File.Exists(szLayer))
			{
				File.Delete(szLayer);
			}
		}
		
		public List<string> GetSymbols()
		{
			List<string> listFiles = new List<string>();
			
			string[] szFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Data\", "*.XML");
			
			foreach(string file in szFiles)
			{
				string szFile = Regex.Replace(file, @"[^\\]+[\\]+|.XML|.xml", "");
				if(!Regex.IsMatch(szFile, @"\.layers$"))
				{
                    szFile = szFile.ToUpper();
					listFiles.Add(szFile);
				}
			}

			return listFiles;
		}

		public XElement GetLayers(string symbol)
		{
			if(File.Exists(GetLayerPath(symbol)))
			{
				element = XElement.Load(GetLayerPath(symbol));
			}
			else
			{
				element = new XElement("layer");
			}
			
			return element;
		}
		
		// New in alpha-2
		
		public XElement GetCommonLayers()
		{
			if(File.Exists("layers.xml"))
			{
				element = XElement.Load("layers.xml");
			}
			else
			{
				element = new XElement("layer");
			}
			
			return element;
		}

		public int GetLayersCount(string symbol)
		{
			if(File.Exists(GetLayerPath(symbol)))
			{
				element = XElement.Load(GetLayerPath(symbol));
				return element.Nodes().Count();
			}
			else
			{
				return 0;
			}
		}
		
		public void SaveLayers(string symbol, XElement el)
		{
			if(el != null)
			{
				el.Save(GetLayerPath(symbol));
			}
			else
			{
				throw new DataProviderException("Layers are null");
			}
		}
		
		// New in alpha-2
		
		public void SaveCommonLayers(XElement el)
		{
			if(el != null)
			{
				el.Save("layers.xml");
			}
			else
			{
				throw new DataProviderException("Common layers are null");
			}
		}
		
		//
		// Private methods
		//
		
		private string GetSymbolPath(string symbol)
		{
			return Directory.GetCurrentDirectory() + @"\Data\" + symbol + ".XML";
		}
		
		private string GetLayerPath(string symbol)
		{
			return Directory.GetCurrentDirectory() + @"\Data\" + symbol + ".layers.XML";
		}
	}

	//
	// Config Manager
	//
	
	public class ConfigManager
	{
		string szPath;
		
		XElement element;
		
		public ConfigManager(string pluginName)
		{
			szPath = Directory.GetCurrentDirectory() + @"\Plugins\Config\" + pluginName + ".XML";
			
			if(File.Exists(szPath))
			{
				element = XElement.Load(szPath);
			}
			else
			{
				element = new XElement("config");
			}
		}
		
		public XElement GetConfig()
		{
			return element;
		}
		
		public void SaveConfig(XElement el)
		{
			el.Save(szPath);
		}
		
		public XElement DropConfig()
		{
			if(File.Exists(szPath))
			{
				File.Delete(szPath);
			}
			
			element = new XElement("config");
			
			return element;
		}
	}
}
