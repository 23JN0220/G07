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
    public partial class frmGoods : Form
    {
        public frmGoods()
        {
            InitializeComponent();
        }

        private void frmGoods_Shown(object sender, EventArgs e)
        {
            CategoryGroupTable categoryGroupTable = new CategoryGroupTable();
            GoodsTable goodsTable = new GoodsTable();

            DataTable table = categoryGroupTable.GetCategoryGroup();

            foreach (DataRow dr in table.Rows)
            {
                lstCategory.Items.Add(dr[1].ToString());
            }

            DataTable table1 = goodsTable.GetGoods();
            if (table1 != null)
            {
                dgvGoods.AutoGenerateColumns = false;
                dgvGoods.DataSource = table1;
            }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGoodsAdd frmGoodsAdd = new frmGoodsAdd();
            frmGoodsAdd.ShowDialog();
        }

    }
}
