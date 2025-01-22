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
    public partial class frmGokanseiPowerUnit : Form
    {
        public frmGokanseiPowerUnit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiPowerUnit_Load(object sender, EventArgs e)
        {
            PowerSizeTable powerSizeTable = new PowerSizeTable();

            DataTable dataTable = powerSizeTable.GetPowerSize();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSize.Items.Add(dr[1].ToString());
            }
        }

        private void lstSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSize.SelectedItem != null)
            {
                txtSize.Text = lstSize.SelectedItem.ToString();
            }
        }

        private void btnSadd_Click(object sender, EventArgs e)
        {
            if (txtSize.Text != "")
            {
                if (!lstSize.Items.Contains(txtSize.Text))
                {
                    PowerSizeTable powerSizeTable = new PowerSizeTable();
                    int ret = powerSizeTable.Insert(txtSize.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSize.Items.Clear();
                        DataTable dataTable = powerSizeTable.GetPowerSize();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSize.Items.Add(dr[1].ToString());
                        }

                        txtSize.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称の規格が既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("規格の名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSchange_Click(object sender, EventArgs e)
        {
            if (txtSize.Text != "" &&　lstSize.SelectedIndex != -1)
            {
                if (!lstSize.Items.Contains(txtSize.Text))
                {
                    PowerSizeTable powerSizeTable = new PowerSizeTable();
                    int ret = powerSizeTable.Update(txtSize.Text, lstSize.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSize.Items.Clear();
                        DataTable dataTable = powerSizeTable.GetPowerSize();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSize.Items.Add(dr[1].ToString());
                        }

                        txtSize.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを変更できませんでした。", "変更エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称の接続方法が既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更する項目が選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSdelete_Click(object sender, EventArgs e)
        {
            if (lstSize.SelectedIndex != -1)
            {
                GoodsPowerTable goodsPowerTable = new GoodsPowerTable();
                GoodsCaseTable goodsCaseTable = new GoodsCaseTable();
                PowerSizeTable powerSizeTable = new PowerSizeTable();

                string size_name = lstSize.SelectedItem.ToString();
                int size_id = powerSizeTable.GetPowerSizeIdByName(size_name);

                DataTable dataTable = goodsPowerTable.GetGoodsPowerBySizeId(size_id);
                DataTable dataTable2 = goodsCaseTable.GetGoodsCaseByPowerSizeId(size_id);

                if (dataTable == null && dataTable2 == null)
                {
                    DialogResult result = MessageBox.Show("「" + size_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret = powerSizeTable.Delete(size_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstSize.Items.Clear();
                            DataTable dataTable3 = powerSizeTable.GetPowerSize();
                            foreach (DataRow dr in dataTable3.Rows)
                            {
                                lstSize.Items.Add(dr[1].ToString());
                            }
                            txtSize.Text = "";
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
                MessageBox.Show("削除する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
