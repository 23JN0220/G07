using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;


namespace 卒業制作
{
    public partial class frmMeker : Form
    {
        public frmMeker()
        {
            InitializeComponent();
        }

        private void frmMeker_Load(object sender, EventArgs e)
        {
            MakerTable MakerTable = new MakerTable();
            DataTable  table = MakerTable.GetMaker();

            DataTable dt = MakerTable.GetMaker(); {

                dgvMaker.AutoGenerateColumns = false;
                dgvMaker.DataSource = dt;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();

            DataTable dt1 = makerTable.GetMakerNameByName(txtMaker_Name.Text);

            if (dt1 != null)
            {

                dgvMaker.AutoGenerateColumns = false;
                dgvMaker.DataSource = dt1;
            }
            else {
                dgvMaker.DataSource = null;
                MessageBox.Show("メーカーは見つかりませんでした","検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


       
    }
}
