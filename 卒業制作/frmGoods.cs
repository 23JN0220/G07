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

            lstCategory.SelectedIndex = 0;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GoodsTable goodsTable = new GoodsTable();

            if (lstCategory.Text == "すべて")
            {
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
            else
            {
                int group_code = lstCategory.SelectedIndex;
                DataTable table = goodsTable.GetGoodsByGroupCode_Name(group_code, txtGoods.Text);

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
                DataTable table;

                if (txtGoods.Text == "")
                {
                    table = goodsTable.GetGoods();
                }
                else
                {
                    table = goodsTable.GetGoodsByName(txtGoods.Text);
                }

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
                DataTable table;

                if (txtGoods.Text == "")
                {
                    table = goodsTable.GetGoodsByGroupCode(lstCategory.SelectedIndex);
                }
                else
                {
                    table = goodsTable.GetGoodsByGroupCode_Name(lstCategory.SelectedIndex, txtGoods.Text);
                }

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

        private void txtGoods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)

        {
            if (dgvGoods.SelectedCells.Count > 0)
            {
                GoodsTable goodsTable = new GoodsTable();

                Goods goods = goodsTable.GetGoodsByGoodsCode(dgvGoods.CurrentRow.Cells["goods_code"].Value.ToString());


                //ここからそれぞれの画面に分岐
                //MessageBox.Show(dgvGoods.CurrentRow.Cells["group_code"].Value.ToString());
                switch (dgvGoods.CurrentRow.Cells["group_code"].Value)
                {
                    case 1:
                        frmGoodsCpu frmGoodsCpu = new frmGoodsCpu();
                        GoodsCpuTable goodsCpuTable = new GoodsCpuTable();

                        frmGoodsCpu.goods = goods;

                        frmGoodsCpu.goodsCpu = goodsCpuTable.GetGoodsCPUById(goods.goods_code);

                        frmGoodsCpu.ShowDialog();

                        break;
                    case 2:
                        frmGokanseiCooler frmGokanseiCooler = new frmGokanseiCooler();
                        frmGokanseiCooler.ShowDialog();

                        break;
                    case 3:
                        frmGoodsMotherboard frmGoodsMotherboard = new frmGoodsMotherboard();
                        frmGoodsMotherboard.ShowDialog();

                        break;
                    case 4:
                        frmGoodsMemory frmGoodsMemory = new frmGoodsMemory();
                        frmGoodsMemory.ShowDialog();

                        break;
                    case 5:
                        frmGoodsGpu frmGoodsGpu = new frmGoodsGpu();
                        frmGoodsGpu.ShowDialog();

                        break;
                    case 6:
                        frmGoodsSsd frmGoodsSsd = new frmGoodsSsd();
                        frmGoodsSsd.ShowDialog();

                        break;
                    case 7:
                        frmGoodsHdd frmGoodsHdd = new frmGoodsHdd();
                        frmGoodsHdd.ShowDialog();

                        break;
                    case 8:
                        frmGoodsPowerUnit frmGoodsPowerUnit = new frmGoodsPowerUnit();
                        frmGoodsPowerUnit.ShowDialog();

                        break;
                    case 9:
                        frmGoodsCase frmGoodsCase = new frmGoodsCase();
                        frmGoodsCase.ShowDialog();

                        break;
                    case 10:
                        frmGoodsFan frmGoodsFan = new frmGoodsFan();
                        frmGoodsFan.ShowDialog();

                        break;
                    case 11:
                        frmGoodsOs frmGoodsOs = new frmGoodsOs();
                        GoodsOsTable goodsOsTable = new GoodsOsTable();

                        frmGoodsOs.goods = goods;
                        frmGoodsOs.goodsOs = goodsOsTable.GetGoodsOSById(goods.goods_code);

                        frmGoodsOs.ShowDialog();

                        break;
                    default:
                        MessageBox.Show("この商品のカテゴリーが不明です", "商品エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                }

                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show("商品が選択されていません", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
