/*
 * Created by SharpDevelop.
 * User: chn
 * Date: 08.09.2008
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using Configuration;

namespace valPresage
{
	/// <summary>
	/// Description of FormConfig.
	/// </summary>
	public partial class FormConfig : Form
	{
		MainForm parent;
		valPresageConfig config;
		
		public FormConfig(MainForm _parent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			parent = _parent;
			config = parent.config;
			
			chHorValues.Checked = config.IsHorizontalValues;
			chHorGrid.Checked = config.IsHorizontalGrid;
			chVerValues.Checked = config.IsVerticalValues;
			chVerGrid.Checked = config.IsVerticalGrid;
			chVolume.Checked = config.IsVolume;
			
			if(config.HGridLines == 0)
			{
				cmbHorLines.SelectedIndex = 0;
			}
			else if(config.HGridLines == 2)
			{
				cmbHorLines.SelectedIndex = 1;
			}
			else if(config.HGridLines == 3)
			{
				cmbHorLines.SelectedIndex = 2;
			}
			else if(config.HGridLines == 5)
			{
				cmbHorLines.SelectedIndex = 3;
			}
			else if(config.HGridLines == 7)
			{
				cmbHorLines.SelectedIndex = 4;
			}
			else if(config.HGridLines == 10)
			{
				cmbHorLines.SelectedIndex = 5;
			}
			
			if(config.VGridLines == 0)
			{
				cmbVerLines.SelectedIndex = 0;
			}
			else if(config.VGridLines == 2)
			{
				cmbVerLines.SelectedIndex = 1;
			}
			else if(config.VGridLines == 3)
			{
				cmbVerLines.SelectedIndex = 2;
			}
			else if(config.VGridLines == 5)
			{
				cmbVerLines.SelectedIndex = 3;
			}
			else if(config.VGridLines == 7)
			{
				cmbVerLines.SelectedIndex = 4;
			}
			else if(config.VGridLines == 10)
			{
				cmbVerLines.SelectedIndex = 5;
			}
			
			if(config.Type == GraphicsProvider.Chart.ChartType.Line)
			{
				cmbDefStyle.SelectedIndex = 0;
			}
			else if(config.Type == GraphicsProvider.Chart.ChartType.Bar)
			{
				cmbDefStyle.SelectedIndex = 1;
			}
			else if(config.Type == GraphicsProvider.Chart.ChartType.Candle)
			{
				cmbDefStyle.SelectedIndex = 2;
			}
			
			cmbPeriod.SelectedIndex = config.Period;
			
			pbGridColor.BackColor = config.GridColor;
			pbTickColor.BackColor = config.TickColor;
			pbTextColor.BackColor = config.TextColor;
			pbGridTextColor.BackColor = config.GridTextColor;
			pbFrameColor.BackColor = config.FrameColor;
			pbBackColor.BackColor = config.BackColor;
			
			pbLineColor.BackColor = config.LineColor;
			pbUpColor.BackColor = config.UpColor;
			pbDownColor.BackColor = config.DownColor;
			pbVolumeColor.BackColor = config.VolumeColor;
			
			pbToolColor.BackColor = config.ToolColor;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void PbGridColorClick(object sender, EventArgs e)
		{
			if(gridColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbGridColor.BackColor = gridColorDialog.Color;
			}
		}
		
		void PbTickColorClick(object sender, EventArgs e)
		{
			if(tickColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbTickColor.BackColor = tickColorDialog.Color;
			}
		}
		
		void PbTextColorClick(object sender, EventArgs e)
		{
			if(textColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbTextColor.BackColor = textColorDialog.Color;
			}
		}
		
		void PbGridTextColorClick(object sender, EventArgs e)
		{
			if(gridTextColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbGridTextColor.BackColor = gridTextColorDialog.Color;
			}
		}
		
		void PbFrameColorClick(object sender, EventArgs e)
		{
			if(frameColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbFrameColor.BackColor = frameColorDialog.Color;
			}
		}
		
		void PbLineColorClick(object sender, EventArgs e)
		{
			if(lineColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbLineColor.BackColor = lineColorDialog.Color;
			}
		}
		
		void PbUpColorClick(object sender, EventArgs e)
		{
			if(upColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbUpColor.BackColor = upColorDialog.Color;
			}
		}
		
		void PbDownColorClick(object sender, EventArgs e)
		{
			if(downColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbDownColor.BackColor = downColorDialog.Color;
			}
		}
		
		void PbBackColorClick(object sender, EventArgs e)
		{
			if(backColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbBackColor.BackColor = backColorDialog.Color;
			}
		}
		
		void PbVolumeColorClick(object sender, EventArgs e)
		{
			if(volumeColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbVolumeColor.BackColor = volumeColorDialog.Color;
			}
		}
		
		void PbToolColorClick(object sender, EventArgs e)
		{
			if(toolColorDialog.ShowDialog() == DialogResult.OK)
			{
				pbToolColor.BackColor = toolColorDialog.Color;
			}
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			config.IsHorizontalValues = chHorValues.Checked;
			config.IsHorizontalGrid = chHorGrid.Checked;
			config.IsVerticalValues = chVerValues.Checked;
			config.IsVerticalGrid = chVerGrid.Checked;
			config.IsVolume = chVolume.Checked;
			
			config.GridColor = pbGridColor.BackColor;
			config.TickColor = pbTickColor.BackColor;
			config.TextColor = pbTextColor.BackColor;
			config.GridTextColor = pbGridTextColor.BackColor;
			config.FrameColor = pbFrameColor.BackColor;
			config.BackColor = pbBackColor.BackColor;
			
			config.LineColor = pbLineColor.BackColor;
			config.UpColor = pbUpColor.BackColor;
			config.DownColor = pbDownColor.BackColor;
			config.VolumeColor = pbVolumeColor.BackColor;
			
			config.ToolColor = pbToolColor.BackColor;
			
			if(cmbHorLines.SelectedIndex == 0)
			{
				config.HGridLines = 0;
			}
			else
			{
				config.HGridLines = Convert.ToInt16(cmbHorLines.SelectedItem);
			}
			
			if(cmbVerLines.SelectedIndex == 0)
			{
				config.VGridLines = 0;
			}
			else
			{
				config.VGridLines = Convert.ToInt16(cmbVerLines.SelectedItem);
			}
			
			if(cmbDefStyle.SelectedIndex == 0)
			{
				config.Type = GraphicsProvider.Chart.ChartType.Line;
			}
			else if(cmbDefStyle.SelectedIndex == 1)
			{
				config.Type = GraphicsProvider.Chart.ChartType.Bar;
			}
			else if(cmbDefStyle.SelectedIndex == 2)
			{
				config.Type = GraphicsProvider.Chart.ChartType.Candle;
			}
			
			config.Period = cmbPeriod.SelectedIndex;

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
				parent.InitializeCharts();
				this.Close();
			}
		}
	}
}
