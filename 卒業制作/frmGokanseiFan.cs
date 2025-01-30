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
    public partial class frmGokanseiFan : Form
    {
        public frmGokanseiFan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiFan_Load(object sender, EventArgs e)
        {
        CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();

            DataTable dataTable = caseFanSizeTable.GetCaseFanSize();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSizeStandards.Items.Add(dr[1].ToString());
            }
        }

        private void lstSizeStandards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSizeStandards.SelectedItem != null)
            {
                txtSizeStandards.Text = lstSizeStandards.SelectedItem.ToString();
            }
            
        }

        private void btnSadd_Click(object sender, EventArgs e)
        {
            if (txtSizeStandards.Text != "")
            {
                if (!lstSizeStandards.Items.Contains(txtSizeStandards.Text))
                {
                    CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();
                    int ret = caseFanSizeTable.Insert(txtSizeStandards.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("サイズ規格の名称を追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        lstSizeStandards.Items.Clear();
                        DataTable dataTable = caseFanSizeTable.GetCaseFanSize();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSizeStandards.Items.Add(dr[1].ToString());
                        }
                        txtSizeStandards.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("サイズ規格の名称が既に登録されています。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("サイズ規格の名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSchange_Click(object sender, EventArgs e)
        {
            if (txtSizeStandards.Text != "" && lstSizeStandards.SelectedIndex != -1)
            {
                if (!lstSizeStandards.Items.Contains(txtSizeStandards.Text))
                {
                    CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();
                    int ret = caseFanSizeTable.Update(txtSizeStandards.Text, lstSizeStandards.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSizeStandards.Items.Clear();
                        DataTable dataTable = caseFanSizeTable.GetCaseFanSize();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSizeStandards.Items.Add(dr[1].ToString());
                        }
                        txtSizeStandards.Text = "";
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

        private void btnSdelete_Click(object sender, EventArgs e)
        {
            if (lstSizeStandards.SelectedIndex != -1)
            {
                GoodsFanTable goodsFanTable = new GoodsFanTable();
                GoodsCaseTable goodsCaseTable = new GoodsCaseTable();
                CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();

                string size_name = lstSizeStandards.SelectedItem.ToString();
                int size_id = caseFanSizeTable.GetCaseFanSizeIdByName(size_name);

                DataTable dataTable = goodsFanTable.GetGoodsFanBySizeId(size_id);
                DataTable dataTable2 = goodsCaseTable.GetGoodsCaseBySizeId(size_id);

                if (dataTable == null && dataTable2 == null)
                {
                    DialogResult result = MessageBox.Show("「" + size_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        int ret = caseFanSizeTable.Delete(size_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstSizeStandards.Items.Clear();
                            DataTable dataTable3 = caseFanSizeTable.GetCaseFanSize();
                            foreach (DataRow dr in dataTable3.Rows)
                            {
                                lstSizeStandards.Items.Add(dr[1].ToString());
                            }
                            txtSizeStandards.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("データを削除できませんでした。", "削除エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    if (dataTable != null && dataTable2 != null)
                    {
                        dataTable.Merge(dataTable2);
                    }
                    else if (dataTable2 != null)
                    {
                        dataTable = dataTable2;
                    }

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
