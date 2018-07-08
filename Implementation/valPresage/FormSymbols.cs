using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using DataProvider;
using DataHostServices;

namespace valPresage
{
    public partial class FormSymbols : Form
    {
        MainForm parent;
        string currentSymbol;

        public FormSymbols(MainForm _parent)
        {
            InitializeComponent();

            parent = _parent;
        }

        private void FormSymbols_Shown(object sender, EventArgs e)
        {
            this.AddSymbols();

            foreach (DataTypes.AvailablePlugin plugin in parent.dataServices.AvailablePlugins)
            {
                cmbDataSource.Items.Add(plugin.Instance.Name);
            }
        }

        private void listSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSymbols.SelectedItem != null)
            {
                cmbDataSource.Enabled = true;
                btnChange.Enabled = true;
                btnDelete.Enabled = true;

                currentSymbol = listSymbols.SelectedItem.ToString();

                if ((parent.config.Symbols.ContainsKey(currentSymbol)) && (cmbDataSource.Items.Contains(parent.config.Symbols[currentSymbol])))
                {
                    cmbDataSource.SelectedItem = parent.config.Symbols[currentSymbol];
                }
                else
                {
                    cmbDataSource.SelectedIndex = 0;
                }
            }
            else
            {
                cmbDataSource.Enabled = false;
                btnChange.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(parent.config.Symbols.ContainsKey(currentSymbol))
            {
                parent.config.Symbols[currentSymbol] = cmbDataSource.SelectedItem.ToString();
            }
            else
            {
                parent.config.Symbols.Add(currentSymbol, cmbDataSource.SelectedItem.ToString());
            }

            parent.SerializeConfig();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (parent.config.Symbols.ContainsKey(currentSymbol))
            {
                parent.config.Symbols.Remove(currentSymbol);

                parent.SerializeConfig();
            }

            parent.symbolManager.DropSymbol(currentSymbol);
            parent.DisposeChart(currentSymbol);

            this.AddSymbols();
        }
        
        void BtnCloseClick(object sender, EventArgs e)
        {
        	this.Close();
        }

        private void AddSymbols()
        {
            listSymbols.Items.Clear();

            List<string> symbols = parent.symbolManager.GetSymbols();

            foreach (string symbol in symbols)
            {
                listSymbols.Items.Add(symbol);
            }

            cmbDataSource.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
