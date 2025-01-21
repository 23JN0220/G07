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
    public partial class frmGokanseiOs : Form
    {
        public frmGokanseiOs()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiOs_Load(object sender, EventArgs e)
        {
            OsVersionTable osVersionTable = new OsVersionTable();

            DataTable dataTable = osVersionTable.GetOsVersion();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstVersion.Items.Add(dr[1].ToString());
            }
        }

        private void lstVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVersion.Text = lstVersion.SelectedItem.ToString();
        }
    }
}
