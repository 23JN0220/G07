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
    public partial class frmMember : Form
    {
        public frmMember()
        {
            InitializeComponent();
        }

        private void txtMember_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMember_Shown(object sender, EventArgs e)
        {
            MemberTable memberTable = new MemberTable();

            DataTable dataTable = memberTable.GetMember();

            if (dataTable != null)
            {
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = dataTable;
            }
        }
    }
}
