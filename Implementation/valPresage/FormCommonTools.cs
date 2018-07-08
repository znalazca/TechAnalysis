/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 17.09.2008
 * Time: 15:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Linq;

using GraphicsHostServices;
using DataProvider;

namespace valPresage
{
	/// <summary>
	/// Description of FormCommonTools.
	/// </summary>
	public partial class FormCommonTools : Form
	{
		private SymbolManager symbolManager;
		
		private MainForm parent;
		private FormAddCommonLayer formAdd;
		
		private XElement layers;
		
		public FormCommonTools(MainForm _parent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			parent = _parent;
			
			symbolManager = new SymbolManager();
		}
		
		void FormCommonToolsShown(object sender, EventArgs e)
		{
			this.RefreshLayers();
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			formAdd = new FormAddCommonLayer(parent);
			formAdd.Closed += new EventHandler(formAddClosed);
			formAdd.ShowDialog();
		}
		
		void formAddClosed(object sender, EventArgs e)
		{
			if(formAdd.plugin != null)
			{
				GraphicsTypes.AvailablePlugin plugin = parent.graphicsServices.GetPlugin(formAdd.plugin);
			
				plugin.Instance.Layer = new LayerManager(formAdd.plugin, layers);
				plugin.Instance.ConfigureCommon();
				
				symbolManager.SaveCommonLayers(layers);
				
				this.RefreshLayers();
			}
		}
		
		void BtnDropClick(object sender, EventArgs e)
		{
			if(listTools.SelectedItems[0] != null)
			{
				symbolManager.DropCommonLayer(Convert.ToInt32(listTools.SelectedItems[0].SubItems[0].Text));
				
				this.RefreshLayers();
			}
		}
		
		void RefreshLayers()
		{
			listTools.Items.Clear();
			
			layers = symbolManager.GetCommonLayers();
			
			foreach(XElement x in layers.Elements("layer"))
			{
				ListViewItem item = new ListViewItem(x.Attribute("count").Value);
				item.SubItems.Add(x.Attribute("plugin").Value);
				listTools.Items.Add(item);
			}
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
