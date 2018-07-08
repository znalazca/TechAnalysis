/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 14.01.2009
 * Time: 9:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using GraphicsHostServices;
using DataProvider;

namespace valPresage
{
	/// <summary>
	/// Description of FormAddCommonLayer.
	/// </summary>
	public partial class FormAddCommonLayer : Form
	{
		private MainForm parent;
		
		public string plugin;
		
		public FormAddCommonLayer(MainForm _parent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			parent = _parent;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void FormAddCommonLayerShown(object sender, EventArgs e)
		{
			foreach(GraphicsTypes.AvailablePlugin plugin in parent.graphicsServices.AvailablePlugins)
			{
				if(plugin.Instance.IsCommon)
				{
					listTools.Items.Add(plugin.Instance.Name);
				}
			}
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			if(listTools.SelectedItem != null)
			{
				plugin = listTools.SelectedItem.ToString();
				
				this.Close();
			}
			else
			{
				MessageBox.Show("Select common tool", "Warning");
			}
		}
	}
}
