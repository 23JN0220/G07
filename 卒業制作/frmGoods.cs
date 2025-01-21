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
            btnSearch.PerformClick();
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
                        frmGoodsCooler frmGoodsCooler = new frmGoodsCooler();
                        GoodsCoolerTable goodsCoolerTable = new GoodsCoolerTable();

                        frmGoodsCooler.goods = goods;

                        frmGoodsCooler.goodsCooler = goodsCoolerTable.GetGoodsCoolerById(goods.goods_code);

                        frmGoodsCooler.ShowDialog();

                        break;
                    case 3:
                        frmGoodsMotherboard frmGoodsMotherboard = new frmGoodsMotherboard();
                        GoodsMotherboardTable goodsMotherboardTable = new GoodsMotherboardTable();

                        frmGoodsMotherboard.goods = goods;

                        frmGoodsMotherboard.goodsMotherboard = goodsMotherboardTable.GetGoodsMotherboardById(goods.goods_code);

                        frmGoodsMotherboard.ShowDialog();

                        break;
                    case 4:
                        frmGoodsMemory frmGoodsMemory = new frmGoodsMemory();
                        GoodsMemoryTable goodsMemoryTable = new GoodsMemoryTable();

                        frmGoodsMemory.goods = goods;

                        frmGoodsMemory.goodsMemory = goodsMemoryTable.GetGoodsMemoryById(goods.goods_code);

                        frmGoodsMemory.ShowDialog();

                        break;
                    case 5:
                        frmGoodsGpu frmGoodsGpu = new frmGoodsGpu();
                        GoodsGpuTable goodsGpuTable = new GoodsGpuTable();

                        frmGoodsGpu.goods = goods;

                        frmGoodsGpu.goodsGpu = goodsGpuTable.GetGoodsGpuById(goods.goods_code);
                        frmGoodsGpu.ShowDialog();

                        break;
                    case 6:
                        frmGoodsSsd frmGoodsSsd = new frmGoodsSsd();
                        GoodsSsdTable goodsSsdTable = new GoodsSsdTable();

                        frmGoodsSsd.goods = goods;

                        frmGoodsSsd.goodsSsd = goodsSsdTable.GetGoodsSsdById(goods.goods_code);
                        frmGoodsSsd.ShowDialog();

                        break;
                    case 7:
                        frmGoodsHdd frmGoodsHdd = new frmGoodsHdd();
                        GoodsHddTable goodsHddTable = new GoodsHddTable();

                        frmGoodsHdd.goods = goods;

                        frmGoodsHdd.goodsHdd = goodsHddTable.GetGoodsHddById(goods.goods_code);
                        frmGoodsHdd.ShowDialog();

                        break;
                    case 8:
                        frmGoodsPowerUnit frmGoodsPowerUnit = new frmGoodsPowerUnit();
                        GoodsPowerTable goodsPowerTable = new GoodsPowerTable();

                        frmGoodsPowerUnit.goods = goods;

                        frmGoodsPowerUnit.goodsPower = goodsPowerTable.GetGoodsPowerById(goods.goods_code);
                        frmGoodsPowerUnit.ShowDialog();

                        break;
                    case 9:
                        frmGoodsCase frmGoodsCase = new frmGoodsCase();
                        GoodsCaseTable goodsCaseTable = new GoodsCaseTable();

                        frmGoodsCase.goods = goods;

                        frmGoodsCase.goodsCase = goodsCaseTable.GetGoodsCaseById(goods.goods_code);
                        frmGoodsCase.ShowDialog();

                        break;
                    case 10:
                        frmGoodsFan frmGoodsFan = new frmGoodsFan();
                        GoodsFanTable goodsFanTable = new GoodsFanTable();

                        frmGoodsFan.goods = goods;
                        frmGoodsFan.goodsFan = goodsFanTable.GetGoodsFanById(goods.goods_code);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int goods_code = int.Parse(dgvGoods.CurrentRow.Cells["goods_code"].Value.ToString());

            DialogResult ret = MessageBox.Show("商品番号「"+ goods_code +"」を削除します\n\n" +
                                               "利用者がカートや構成チェック、ブックマークにこの商品を追加している場合、これらのデータも削除されます\n" +
                                               "また、注文明細からもこの商品のデータが削除されます\n" +
                                               "この商品を発送していない場合は注意してください\n\n" +
                                               "削除を続行すると、元に戻すことはできません\n" +
                                               "本当に削除しますか？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.Yes)
            {
                
            }
        }
    }
}
