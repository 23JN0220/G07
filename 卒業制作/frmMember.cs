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

        private void frmMember_Load(object sender, EventArgs e)
        {
            MemberTable memberTable = new MemberTable();

            DataTable dataTable = memberTable.GetMember();

            if (dataTable != null)
            {
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = dataTable;
            }
        }

        private void brnSerch_Click(object sender, EventArgs e)
        {
            
            int id;

            if (txtMember.Text != "")
            {
                if (int.TryParse(txtMember.Text, out id))
                {
                    MemberTable memberTable = new MemberTable();

                    DataTable dataTable = memberTable.GetMemberbyMemberID(id);

                    if (dataTable != null)
                    {
                        dgvMember.AutoGenerateColumns = false;
                        dgvMember.DataSource = dataTable;
                    }
                    else
                    {
                        dgvMember.DataSource = null;
                        MessageBox.Show("この会員番号は存在しません。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("会員番号は半角数字を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("検索したい会員番号を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMember.Text = "";

            MemberTable memberTable = new MemberTable();

            DataTable dataTable = memberTable.GetMember();

            if (dataTable != null)
            {
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = dataTable;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dgvMember.CurrentRow.Cells["member_id"].Value.ToString();

            DialogResult result = MessageBox.Show("会員番号「" + id + "」の会員を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MemberTable memberTable = new MemberTable();

                int ret = memberTable.Delete(id);

                if (ret != 0)
                {
                    MessageBox.Show("会員は正常に削除されました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMember.Text = "";
                    DataTable dataTable = memberTable.GetMember();

                    if (dataTable != null)
                    {
                        dgvMember.AutoGenerateColumns = false;
                        dgvMember.DataSource = dataTable;
                    }

                }
                else
                {
                    MessageBox.Show("会員の削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
