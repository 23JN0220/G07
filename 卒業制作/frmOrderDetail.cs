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
    public partial class frmOrderDetail : Form
    {
        public int order_id = 0;

        public frmOrderDetail()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchNumber.Text != "")
            {
                int order_id;

                if (int.TryParse(txtSearchNumber.Text, out order_id))
                {
                    OrderDetailTable orderDetailTable = new OrderDetailTable();

                    DataTable dataTable = orderDetailTable.GetGoodsOrderDetailByOrderId(order_id);

                    if (dataTable != null)
                    {
                        dgvOrder.AutoGenerateColumns = false;
                        dgvOrder.DataSource = dataTable;
                    }
                    else
                    {
                        dgvOrder.DataSource = null;
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvOrder.DataSource = null;
            txtSearchNumber.Text = "";
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            if (order_id != 0)
            {
                txtSearchNumber.Text = order_id.ToString();
                btnSearch.PerformClick();
                txtSearchNumber.Enabled = false;
                btnSearch.Enabled = false;
                btnReset.Enabled = false;
            }
            
        }
    }
}
