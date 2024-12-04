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


        private void frmGoods_Load(object sender, EventArgs e)
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
            else
            {
                MessageBox.Show("商品が見つかりませんでした。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void frmGoods_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            GoodsTable goodsTable = new GoodsTable();
            DataTable table = goodsTable.GetGoodsByName(txtGoods.Text);
            
            if (table != null)
            {
                dgvGoods.AutoGenerateColumns = false;
                dgvGoods.DataSource = table;
            }
            else
            {
                dgvGoods.DataSource = null;
                MessageBox.Show("商品が見つかりませんでした。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGoodsAdd frmGoodsAdd = new frmGoodsAdd();
            frmGoodsAdd.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategory.Text == "すべて")
            {
                GoodsTable goodsTable = new GoodsTable();
                DataTable table = goodsTable.GetGoods();

                if (table != null)
                {
                    dgvGoods.AutoGenerateColumns = false;
                    dgvGoods.DataSource = table;
                }
                else
                {
                    dgvGoods.DataSource = null;
                    MessageBox.Show("商品が見つかりませんでした。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                GoodsTable goodsTable = new GoodsTable();
                DataTable table = goodsTable.GetGoodsByGroupCode(lstCategory.SelectedIndex);

                if (table != null)
                {
                    dgvGoods.AutoGenerateColumns = false;
                    dgvGoods.DataSource = table;
                }
                else
                {
                    dgvGoods.DataSource = null;
                    MessageBox.Show("商品が見つかりませんでした。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
    }
}
