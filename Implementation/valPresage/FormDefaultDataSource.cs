/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 22.10.2008
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

using DataHostServices;

namespace valPresage
{
	/// <summary>
	/// Description of FormDefaultDataSource.
	/// </summary>
	public partial class FormDefaultDataSource : Form
	{
		MainForm parent;
		
		public FormDefaultDataSource(MainForm _parent)
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
		
		void FormDefaultDataSourceShown(object sender, EventArgs e)
		{
			foreach(DataTypes.AvailablePlugin plugin in parent.dataServices.AvailablePlugins)
			{
				listDataSources.Items.Add(plugin.Instance.Name);
			}
			
			if((parent.config.DefaultDataSource != null)&&(listDataSources.Items.Contains(parent.config.DefaultDataSource)))
			{
				listDataSources.SelectedItem = parent.config.DefaultDataSource;
			}
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			parent.config.DefaultDataSource = listDataSources.SelectedItem.ToString();
			parent.SerializeConfig();
			
			this.Close();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
