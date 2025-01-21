using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 卒業制作
{
    public partial class frmGokanseiMotherboard : Form
    {
        public frmGokanseiMotherboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiMotherboard_Load(object sender, EventArgs e)
        {
           MotherboardChipsetTable motherboardChipsetTable = new MotherboardChipsetTable();
           MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
            WirelessLanTable wirelessLanTable = new WirelessLanTable();

            DataTable dataTable = motherboardChipsetTable.GetMotherboardChipset();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstChipset.Items.Add(dr[1].ToString());
            }
           dataTable = motherboardSizeTable.GetMotherboardSize();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSize.Items.Add(dr[1].ToString());
            }
            dataTable = wirelessLanTable.GetWirelessLan();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstWirelessLan.Items.Add(dr[1].ToString());
            }
        }

        private void lstChipset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChipset.Text = lstChipset.SelectedItem.ToString();
        }

        private void lstSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSize.Text = lstSize.SelectedItem.ToString();
        }

        private void lstWirelessLan_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtWirelessLan.Text = lstWirelessLan.SelectedItem.ToString();    
        }
    }
}
