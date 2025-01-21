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
    public partial class frmGokanseiFan : Form
    {
        public frmGokanseiFan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiFan_Load(object sender, EventArgs e)
        {
        CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();

            DataTable dataTable = caseFanSizeTable.GetCaseFanSize();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSizeStandards.Items.Add(dr[1].ToString());
            }
        }

        private void lstSizeStandards_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSizeStandards.Text = lstSizeStandards.SelectedItem.ToString();
        }
    }
}
