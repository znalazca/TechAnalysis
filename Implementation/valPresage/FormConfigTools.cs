/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 17.09.2008
 * Time: 14:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

using DataProvider;
using GraphicsHostServices;

namespace valPresage
{
	/// <summary>
	/// Description of FormConfigTools.
	/// </summary>
	public partial class FormConfigTools : Form
	{
		GraphicsServices graphicsServices;
		
		public FormConfigTools(GraphicsServices _graphicsServices)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			graphicsServices = _graphicsServices;
		}
		
		void FormConfigToolsShown(object sender, EventArgs e)
		{
			foreach(GraphicsTypes.AvailablePlugin plugin in graphicsServices.AvailablePlugins)
			{
				listTools.Items.Add(plugin.Instance.Name);
			}
		}
		
		void BtnDropConfigClick(object sender, EventArgs e)
		{
			if(listTools.SelectedIndex != -1)
			{
				ConfigManager configManager = new ConfigManager((string)listTools.SelectedItem);
				configManager.DropConfig();
			}
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			if(listTools.SelectedIndex != -1)
			{
				GraphicsTypes.AvailablePlugin plugin = graphicsServices.GetPlugin((string)listTools.SelectedItem);
				if(plugin.Instance.Name != null)
				{
					plugin.Instance.Config = new ConfigManager((string)listTools.SelectedItem);
					plugin.Instance.Configure();
				}
			}
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
