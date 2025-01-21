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
    public partial class FrmGokanseiWarning : Form
    {
        public DataTable dataTable;

        public FrmGokanseiWarning()
        {
            InitializeComponent();
        }

        private void FrmGokanseiWarning_Load(object sender, EventArgs e)
        {
            if (dataTable != null)
            {
                dgvGoods.DataSource = dataTable;
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
