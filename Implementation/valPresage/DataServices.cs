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
 * User: NT40
 * Date: 10.04.2008
 * Time: 16:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using DataInterface;
using DataProvider;
using HttpProvider;

namespace DataHostServices
{
	public class DataServices
	{
		public QuotesManager quotesManager;
		public HttpManager httpManager;
		
		public DataServices()
		{
		}
		
		private DataTypes.AvailablePlugins colAvailablePlugins = new DataTypes.AvailablePlugins();

		public DataTypes.AvailablePlugins AvailablePlugins
		{
			get {return colAvailablePlugins;}
			set {colAvailablePlugins = value;}
		}
		
		public void FindPlugins(string Path)
		{
			colAvailablePlugins.Clear();
		
			foreach (string fileOn in Directory.GetFiles(Path))
			{
				FileInfo file = new FileInfo(fileOn);
				
				if (file.Extension.Equals(".dll"))
				{	
					this.AddPlugin(fileOn);				
				}
			}
		}
		
		public DataTypes.AvailablePlugin GetPlugin(string pluginName)
		{
			foreach(DataTypes.AvailablePlugin plugin in colAvailablePlugins)
			{
				if(plugin.Instance.Name == pluginName)
				{
					return plugin;
				}
			}
			
			return null;
		}
		
		public void ClosePlugins()
		{
			foreach (DataTypes.AvailablePlugin pluginOn in colAvailablePlugins)
			{
				pluginOn.Instance = null;
			}
			colAvailablePlugins.Clear();
		}
		
		private void AddPlugin(string FileName)
		{
			Assembly pluginAssembly = Assembly.LoadFrom(FileName);
			
			foreach (Type pluginType in pluginAssembly.GetTypes())
			{
				if (pluginType.IsPublic)
				{
					if (!pluginType.IsAbstract)
					{
						Type[] typeInterfaces = pluginType.GetInterfaces();
						
						foreach(Type typeInterface in typeInterfaces)
						{
							if (typeInterface.ToString() == "DataInterface.IDataProvider")
							{
								DataTypes.AvailablePlugin newPlugin = new DataTypes.AvailablePlugin();
								newPlugin.AssemblyPath = FileName;
								newPlugin.Instance = (IDataProvider)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
								this.colAvailablePlugins.Add(newPlugin);
							
								newPlugin = null;
							}
						}
					}				
				}			
			}
			
			pluginAssembly = null;
		}
	}
}
	
namespace DataTypes
{
	public class AvailablePlugins : List<AvailablePlugin>
	{
		public DataTypes.AvailablePlugin Find(string pluginNameOrPath)
		{
			DataTypes.AvailablePlugin toReturn = null;
			
			foreach (DataTypes.AvailablePlugin pluginOn in this)
			{
				if ((pluginOn.Instance.Name.Equals(pluginNameOrPath)) || pluginOn.AssemblyPath.Equals(pluginNameOrPath))
				{
					toReturn = pluginOn;
					break;		
				}
			}
			return toReturn;
		}
	}

	public class AvailablePlugin
	{
		private IDataProvider myInstance = null;
		private string myAssemblyPath = "";
			
		public IDataProvider Instance
		{
			get {return myInstance;}
			set	{myInstance = value;}
		}
		public string AssemblyPath
		{
			get {return myAssemblyPath;}
			set {myAssemblyPath = value;}
		}
	}
}
