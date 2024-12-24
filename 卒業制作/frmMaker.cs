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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 卒業制作
{
    public partial class frmMaker : Form
    {
        public frmMaker()
        {
            InitializeComponent();
        }

        private void frmMeker_Load(object sender, EventArgs e)
        {
            MakerTable MakerTable = new MakerTable();
            DataTable  table = MakerTable.GetMaker();

            DataTable dt = MakerTable.GetMaker(); {

                dgvMaker.AutoGenerateColumns = false;
                dgvMaker.DataSource = dt;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();

            DataTable dt1 = makerTable.GetMakerNameByName(txtMaker_Name.Text);

            if (dt1 != null)
            {

                dgvMaker.AutoGenerateColumns = false;
                dgvMaker.DataSource = dt1;
            }
            else {
                dgvMaker.DataSource = null;
                MessageBox.Show("メーカーは見つかりませんでした","検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnAddMaker_Click(object sender, EventArgs e)
        {
            frmMakerAdd frmMakerAdd = new frmMakerAdd();
            frmMakerAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaker.SelectedRows.Count != -1)
            {
                string maker_name = dgvMaker.SelectedRows.ToString();
                DialogResult result = MessageBox.Show(maker_name + "を削除します。よろしいですか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MakerTable makerTable = new MakerTable();

                    int ret = makerTable.Delete(maker_name);
                    if (ret != 0) {
                        MessageBox.Show("メーカーは正常に削除されました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaker_Name.Text = maker_name;
                        DataTable dataTable = makerTable.GetMaker();
                        dgvMaker.AutoGenerateColumns = false;
                        dgvMaker.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("メーカーの削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("メーカーが選択されていません。", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
