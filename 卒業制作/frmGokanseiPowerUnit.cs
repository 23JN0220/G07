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
           txtSize.Text = lstSize.SelectedItem.ToString();
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
    }
}
