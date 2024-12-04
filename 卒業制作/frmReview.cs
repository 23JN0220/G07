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
    public partial class frmReview : Form
    {
        public frmReview()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReview_Load(object sender, EventArgs e)
        {
            ReviewTable reviewTable = new ReviewTable();

            DataTable dataTable = reviewTable.GetReview();

            if (dataTable != null)
            {
                dgvReview.AutoGenerateColumns = false;
                dgvReview.DataSource = dataTable;
            }
        }
    }
}
