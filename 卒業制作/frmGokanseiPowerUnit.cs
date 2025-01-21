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
    public partial class frmGokanseiPowerUnit : Form
    {
        public frmGokanseiPowerUnit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiPowerUnit_Load(object sender, EventArgs e)
        {
            PowerSizeTable powerSizeTable = new PowerSizeTable();

            DataTable dataTable = powerSizeTable.GetPowerSize();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSize.Items.Add(dr[1].ToString());
            }
        }

        private void lstSize_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtSize.Text = lstSize.SelectedItem.ToString();
        }
    }
}
