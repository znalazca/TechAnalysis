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
 * Date: 11.04.2008
 * Time: 10:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

using DataProvider;
using GraphicsInterface;
using GraphicsProvider;

namespace GraphicsHostServices
{
	/// <summary>
	/// Description of GraphicsProviderServices.
	/// </summary>
	public class GraphicsServices
	{
		public DataTable dataTable;
		public LayerManager layerManager;
		public ChartBox chartBox;
		
		public GraphicsServices()
		{
		}
		
		private GraphicsTypes.AvailablePlugins colAvailablePlugins = new GraphicsTypes.AvailablePlugins();
		
		public GraphicsTypes.AvailablePlugins AvailablePlugins
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
		
		public GraphicsTypes.AvailablePlugin GetPlugin(string pluginName)
		{
			foreach(GraphicsTypes.AvailablePlugin plugin in colAvailablePlugins)
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
			foreach (GraphicsTypes.AvailablePlugin pluginOn in colAvailablePlugins)
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
							if (typeInterface.ToString() == "GraphicsInterface.IGraphicsProvider")
							{
								GraphicsTypes.AvailablePlugin newPlugin = new GraphicsTypes.AvailablePlugin();
								newPlugin.AssemblyPath = FileName;
								newPlugin.Instance = (IGraphicsProvider)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
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
	
namespace GraphicsTypes
{
	public class AvailablePlugins : List<GraphicsTypes.AvailablePlugin>
	{
		public GraphicsTypes.AvailablePlugin Find(string pluginNameOrPath)
		{
			GraphicsTypes.AvailablePlugin toReturn = null;
			
			foreach (GraphicsTypes.AvailablePlugin pluginOn in this)
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
		private IGraphicsProvider myInstance = null;
		private string myAssemblyPath = "";
			
		public IGraphicsProvider Instance
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
