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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            GoodsOrderTable goodsOrderTable = new GoodsOrderTable();

            DataTable dataTable = goodsOrderTable.GetGoodsOrder();

            if (dataTable != null)
            {
                dgvPayment.AutoGenerateColumns = false;
                dgvPayment.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("現在、支払い情報は登録されていません。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtNumber.Text != "")
            {
                int order_id;

                if (int.TryParse(txtNumber.Text, out order_id))
                {
                    GoodsOrderTable goodsOrderTable = new GoodsOrderTable();

                    DataTable dataTable = goodsOrderTable.GetGoodsOrderByOrderId(order_id);

                    if (dataTable != null)
                    {
                        dgvPayment.AutoGenerateColumns = false;
                        dgvPayment.DataSource = dataTable;
                    }
                    else
                    {
                        dgvPayment.DataSource = null;
                        MessageBox.Show("この番号の支払い情報は登録されていません。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("注文番号は半角数字を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("検索したい注文番号を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearchReset_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "";
            GoodsOrderTable goodsOrderTable = new GoodsOrderTable();

            DataTable dataTable = goodsOrderTable.GetGoodsOrder();

            if (dataTable != null)
            {
                dgvPayment.AutoGenerateColumns = false;
                dgvPayment.DataSource = dataTable;
            }
            else
            {
                dgvPayment.DataSource = null;
                MessageBox.Show("現在、支払い情報は登録されていません。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail();
            frmOrderDetail.order_id = int.Parse(dgvPayment.CurrentRow.Cells["order_id"].Value.ToString());
            frmOrderDetail.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPayment.SelectedCells.Count > 0)
            {
                string order_id = dgvPayment.CurrentRow.Cells["order_id"].Value.ToString();
                DialogResult result = MessageBox.Show("注文番号「" + order_id + "」のデータを削除します。\n" +
                                                      "この注文番号の明細データも一緒に削除されます。\n\n" + 
                                                      "削除すると元に戻せません。\n" +
                                                      "本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    OrderDetailTable orderDetailTable = new OrderDetailTable();
                    int ret = orderDetailTable.DeleteByOrderId(order_id);

                    if (ret != 0)
                    {
                        GoodsOrderTable goodsOrderTable = new GoodsOrderTable();
                        int ret2 = goodsOrderTable.DeleteByOrderId(order_id);

                        if (ret2 != 0)
                        {
                            MessageBox.Show("データは正常に削除されました。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtNumber.Text = "";
                            DataTable dataTable = goodsOrderTable.GetGoodsOrder();
                            

                            if (dataTable != null)
                            {
                                dgvPayment.AutoGenerateColumns = false;
                                dgvPayment.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("現在、支払い情報は登録されていません。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("支払い情報の削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("注文明細情報の削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("削除する注文番号のデータを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
