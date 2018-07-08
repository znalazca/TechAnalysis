using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DataInterface;
using DataProvider;
using HttpProvider;

public class DataNull : IDataProvider
{
	string myPluginName = "DataNull";
	string myPluginAuthor = "Dzmitry Hatouka";
	string myPluginDescription = "This plugin is to test a host desing for DataProvider";
	string myPluginVersion = "1.0.0";

	QuotesManager quotesManager;
	HttpManager httpManager;
	ConfigManager configManager;

	public DataNull()
	{
	}

	public void Initialize()
	{
	}
		
	public void Dispose()
	{
	}

	public void Configure()
	{
	}

	public QuotesManager Quotes
	{
		get { return quotesManager; }
		set { quotesManager = value; }
	}

	public HttpManager Http
	{
		get { return httpManager; }
		set { httpManager = value; }
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
		get	{ return myPluginVersion; }
	}

	public string Name
	{
		get { return myPluginName; }
	}
}
