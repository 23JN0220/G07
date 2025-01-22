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
    public partial class frmGokanseiMotherboard : Form
    {
        public frmGokanseiMotherboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiMotherboard_Load(object sender, EventArgs e)
        {
           MotherboardChipsetTable motherboardChipsetTable = new MotherboardChipsetTable();
           MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
            WirelessLanTable wirelessLanTable = new WirelessLanTable();

            DataTable dataTable = motherboardChipsetTable.GetMotherboardChipset();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstChipset.Items.Add(dr[1].ToString());
            }
           dataTable = motherboardSizeTable.GetMotherboardSize();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSize.Items.Add(dr[1].ToString());
            }
            dataTable = wirelessLanTable.GetWirelessLan();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstWirelessLan.Items.Add(dr[1].ToString());
            }
        }

        private void lstChipset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChipset.Text = lstChipset.SelectedItem.ToString();
        }

        private void lstSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSize.Text = lstSize.SelectedItem.ToString();
        }

        private void lstWirelessLan_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtWirelessLan.Text = lstWirelessLan.SelectedItem.ToString();    
        }

        private void btnCadd_Click(object sender, EventArgs e)
        {
            if (txtChipset.Text != "")
            {
                if (!lstChipset.Items.Contains(txtChipset.Text))
                {
                   MotherboardChipsetTable motherboardChipsetTable = new MotherboardChipsetTable();
                    int ret = motherboardChipsetTable.Insert(txtChipset.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstChipset.Items.Clear();
                        DataTable dataTable = motherboardChipsetTable.GetMotherboardChipset();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstChipset.Items.Add(dr[1].ToString());
                        }

                        txtChipset.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のチップセットが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("チップセットの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCchange_Click(object sender, EventArgs e)
        {
            if (txtChipset.Text != "" && lstChipset.SelectedIndex != -1)
            {
                if (!lstChipset.Items.Contains(txtChipset.Text))
                {
                    MotherboardChipsetTable motherboardChipsetTable = new MotherboardChipsetTable();
                    int ret = motherboardChipsetTable.Update(txtChipset.Text, lstChipset.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstChipset.Items.Clear();
                        DataTable dataTable = motherboardChipsetTable.GetMotherboardChipset();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstChipset.Items.Add(dr[1].ToString());
                        }

                        txtChipset.Text = "";
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

        private void btnSadd_Click(object sender, EventArgs e)
        {
            if (txtSize.Text != "")
            {
                if (!lstSize.Items.Contains(txtSize.Text))
                {
                   MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
                    int ret = motherboardSizeTable.Insert(txtSize.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSize.Items.Clear();
                        DataTable dataTable = motherboardSizeTable.GetMotherboardSize();
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
                    MessageBox.Show("同じ名称の大きさが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("大きさの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSchange_Click(object sender, EventArgs e)
        {
            if (txtSize.Text != "" && lstSize.SelectedIndex != -1)
            {
                if (!lstSize.Items.Contains(txtSize.Text))
                {
                    MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
                    int ret = motherboardSizeTable.Update(txtSize.Text, lstSize.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSize.Items.Clear();
                        DataTable dataTable = motherboardSizeTable.GetMotherboardSize();
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
                    MessageBox.Show("同じ名称の大きさが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更する大きさが選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSpAdd_Click(object sender, EventArgs e)
        {
            if (txtWirelessLan.Text != "")
            {
                if (!lstWirelessLan.Items.Contains(txtWirelessLan.Text))
                {
                 WirelessLanTable wirelessLanTable = new WirelessLanTable();
                    int ret =wirelessLanTable.Insert(txtWirelessLan.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstWirelessLan.Items.Clear();
                        DataTable dataTable = wirelessLanTable.GetWirelessLan();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstWirelessLan.Items.Add(dr[1].ToString());
                        }

                        txtWirelessLan.Text = "";
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

        private void btnSpChange_Click(object sender, EventArgs e)
        {
            if (txtWirelessLan.Text != "" && lstWirelessLan.SelectedIndex != -1)
            {
                if (!lstWirelessLan.Items.Contains(txtWirelessLan.Text))
                {
                    WirelessLanTable wirelessLanTable = new WirelessLanTable();
                    int ret = wirelessLanTable.Update(txtWirelessLan.Text, lstWirelessLan.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstWirelessLan.Items.Clear();
                        DataTable dataTable = wirelessLanTable.GetWirelessLan();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstWirelessLan.Items.Add(dr[1].ToString());
                        }

                        txtWirelessLan.Text = "";
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
    }
}
