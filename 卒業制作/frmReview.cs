using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string member_id = dgvReview.CurrentRow.Cells["member_id"].Value.ToString();
            string goods_code = dgvReview.CurrentRow.Cells["goods_code"].Value.ToString();

            DialogResult result = MessageBox.Show("会員番号「" + member_id + "」、商品番号が「" + goods_code + "」のレビューを削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ReviewTable reviewTable = new ReviewTable();

                int ret = reviewTable.Delete(member_id, goods_code);

                if (ret != 0)
                {
                    MessageBox.Show("データは正常に削除されました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable dataTable = reviewTable.GetReview();

                    if (dataTable != null)
                    {
                        dgvReview.AutoGenerateColumns = false;
                        dgvReview.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show("データの削除に失敗しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
    }
}
