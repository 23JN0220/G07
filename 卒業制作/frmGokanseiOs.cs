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
    public partial class frmGokanseiOs : Form
    {
        public frmGokanseiOs()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiOs_Load(object sender, EventArgs e)
        {
            OsVersionTable osVersionTable = new OsVersionTable();

            DataTable dataTable = osVersionTable.GetOsVersion();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstVersion.Items.Add(dr[1].ToString());
            }
        }

        private void lstVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVersion.SelectedItem != null)
            {
                txtVersion.Text = lstVersion.SelectedItem.ToString();
            }
        }

        private void btnVadd_Click(object sender, EventArgs e)
        {
            if (txtVersion.Text != "")
            {
                if (!lstVersion.Items.Contains(txtVersion.Text))
                {
                    OsVersionTable osVersionTable = new OsVersionTable();

                    int ret = osVersionTable.Insert(txtVersion.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("バージョンの名称を追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstVersion.Items.Clear();
                        DataTable dataTable = osVersionTable.GetOsVersion();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstVersion.Items.Add(dr[1].ToString());
                        }
                        txtVersion.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("バージョンの名称が既に登録されています。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("バージョンの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnVchange_Click(object sender, EventArgs e)
        {
            if (txtVersion.Text != "" && lstVersion.SelectedIndex != -1)
            {
                if (!lstVersion.Items.Contains(txtVersion.Text))
                {
                    OsVersionTable osVersionTable = new OsVersionTable();

                    int ret = osVersionTable.Update(txtVersion.Text, lstVersion.SelectedItem.ToString());

                    if (ret != 0)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstVersion.Items.Clear();
                        DataTable dataTable = osVersionTable.GetOsVersion();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstVersion.Items.Add(dr[1].ToString());
                        }
                        txtVersion.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを変更できませんでした。", "変更エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称の規格が既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更する項目が選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnVdelete_Click(object sender, EventArgs e)
        {
            if (lstVersion.SelectedIndex != -1)
            {
                GoodsOsTable goodsOsTable = new GoodsOsTable();
                OsVersionTable osVersionTable = new OsVersionTable();

                string version_name = lstVersion.SelectedItem.ToString();
                int version_id = osVersionTable.GetOsVersionIdByName(version_name);

                DataTable dataTable = goodsOsTable.GetGoodsOsByVersionId(version_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + version_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret = osVersionTable.Delete(version_id);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstVersion.Items.Clear();
                            DataTable dataTable2 = osVersionTable.GetOsVersion();
                            foreach (DataRow dr in dataTable2.Rows)
                            {
                                lstVersion.Items.Add(dr[1].ToString());
                            }
                            txtVersion.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("データを削除できませんでした。", "削除エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    frmGokanseiWarning frmGokanseiWarning = new frmGokanseiWarning();
                    frmGokanseiWarning.dataTable = dataTable;
                    frmGokanseiWarning.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("削除する項目が選択されていません。", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
