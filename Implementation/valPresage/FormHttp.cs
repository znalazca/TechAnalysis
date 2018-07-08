/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 04.06.2008
 * Time: 13:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using HttpProvider;

namespace valPresage
{
	/// <summary>
	/// Description of FormHttp.
	/// </summary>
	public partial class FormHttp : Form
	{
		MainForm parent;
		
		public FormHttp(MainForm _parent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			parent = _parent;
			
			checkHttp.Checked = parent.config.IsProxy;
			
			tbServer.Text = parent.config.Server;
			tbPort.Text = parent.config.Port;
			tbLogin.Text = parent.config.Login;
			tbPassword.Text = parent.config.Password;
		}
		
		void Button1Click(object sender, EventArgs e) // OK
		{
			parent.config.IsProxy = checkHttp.Checked;
			
			parent.config.Server = tbServer.Text;
			parent.config.Port = tbPort.Text;
			parent.config.Login = tbLogin.Text;
			parent.config.Password = tbPassword.Text;
			
			if(parent.config.IsProxy)
			{
				parent.httpManager.Server = parent.config.Server;
				parent.httpManager.Port = parent.config.Port;
				parent.httpManager.Login = parent.config.Login;
				parent.httpManager.Password = parent.config.Password;
			}
			
			try
			{
				parent.SerializeConfig();
			}
			catch(Exception ex)
			{
				MessageBox.Show("The config could not be saved " + ex.Message, "Error!");
			}
			finally
			{
				this.Close();
			}
		}
		
		void Button2Click(object sender, EventArgs e) // Cancel
		{
			this.Close();
		}
	}
}
