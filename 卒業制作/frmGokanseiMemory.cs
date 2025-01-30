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
    public partial class frmGokanseiMemory : Form
    {
        public frmGokanseiMemory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiMemory_Load(object sender, EventArgs e)
        {
            MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
            MemoryModuleTable memoryModuleTable = new MemoryModuleTable();

            DataTable dataTable = memoryStandardTable.GetMemoryStandard();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstMemoryStandard.Items.Add(dr[1].ToString());
            }

            dataTable = memoryModuleTable.GetMemoryModule();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstModule.Items.Add(dr[1].ToString());
            }
        }

        private void lstMemoryStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMemoryStandard.SelectedItem != null)
            {
                txtMemoryStandard.Text = lstMemoryStandard.SelectedItem.ToString();
            }
        }

        private void lstModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstModule.SelectedItem != null)
            {
                txtModule.Text = lstModule.SelectedItem.ToString();
            }
        }

        private void btnSadd_Click(object sender, EventArgs e)
        {
            if (txtMemoryStandard.Text != "")
            {
                if (!lstMemoryStandard.Items.Contains(txtMemoryStandard.Text))
                {
                    MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
                    int ret = memoryStandardTable.Insert(txtMemoryStandard.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstMemoryStandard.Items.Clear();
                        DataTable dataTable = memoryStandardTable.GetMemoryStandard();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstMemoryStandard.Items.Add(dr[1].ToString());
                        }

                        txtMemoryStandard.Text = "";
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
            if (txtMemoryStandard.Text != "" && lstMemoryStandard.SelectedIndex != -1)
            {
                if (!lstMemoryStandard.Items.Contains(txtMemoryStandard.Text))
                {
                    MemoryStandardTable memoryStandardTable = new MemoryStandardTable();    
                    int ret = memoryStandardTable.Update(txtMemoryStandard.Text, lstMemoryStandard.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstMemoryStandard.Items.Clear();
                        DataTable dataTable = memoryStandardTable.GetMemoryStandard();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstMemoryStandard.Items.Add(dr[1].ToString());
                        }

                        txtMemoryStandard.Text = "";
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

        private void btnMadd_Click(object sender, EventArgs e)
        {
            if (txtModule.Text != "")
            {
                if (!lstModule.Items.Contains(txtModule.Text))
                {
                    MemoryModuleTable memoryModuleTable = new MemoryModuleTable();
                    int ret = memoryModuleTable.Insert(txtModule.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstModule.Items.Clear();
                        DataTable dataTable = memoryModuleTable.GetMemoryModule();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstModule.Items.Add(dr[1].ToString());
                        }

                        txtModule.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のモジュールが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("モジュールの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnMchange_Click(object sender, EventArgs e)
        {
            if (txtModule.Text != "" && lstModule.SelectedIndex != -1)
            {
                if (!lstModule.Items.Contains(txtModule.Text))
                {
                    MemoryModuleTable memoryModuleTable = new MemoryModuleTable(); 
                    int ret = memoryModuleTable.Update(txtModule.Text, lstModule.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstModule.Items.Clear();
                        DataTable dataTable = memoryModuleTable.GetMemoryModule();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstModule.Items.Add(dr[1].ToString());
                        }

                        txtModule.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを変更できませんでした。", "変更エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のモジュールが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更するモジュールが選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSdelete_Click(object sender, EventArgs e)
        {
            if (lstMemoryStandard.SelectedIndex != -1)
            {
                GoodsMemoryTable goodsMemoryTable = new GoodsMemoryTable();
                MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
                GoodsMotherboardTable goodsMotherboardTable = new GoodsMotherboardTable();

                string standard_name = lstMemoryStandard.SelectedItem.ToString();
                int standard_id = memoryStandardTable.GetMemoryStandardIdByName(standard_name);

                DataTable dataTable = goodsMemoryTable.GetGoodsMemoryByStandardId(standard_id);
                DataTable dataTable2 = goodsMotherboardTable.GetGoodsMotherboardByStandardId(standard_id);

                if (dataTable == null && dataTable2 == null)
                {
                    DialogResult result = MessageBox.Show("「" + standard_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        int ret = memoryStandardTable.Delete(standard_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstMemoryStandard.Items.Clear();
                            DataTable dataTable3 = memoryStandardTable.GetMemoryStandard();
                            foreach (DataRow dr in dataTable3.Rows)
                            {
                                lstMemoryStandard.Items.Add(dr[1].ToString());
                            }
                            txtMemoryStandard.Text = "";
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

        private void btnMdelete_Click(object sender, EventArgs e)
        {
            if (lstModule.SelectedIndex != -1)
            {
                GoodsMemoryTable goodsMemoryTable = new GoodsMemoryTable();
                MemoryModuleTable memoryModuleTable = new MemoryModuleTable();

                string module_name = lstModule.SelectedItem.ToString();
                int module_id = memoryModuleTable.GetMemoryModuleIdByName(module_name);

                DataTable dataTable = goodsMemoryTable.GetGoodsMemoryByModuleId(module_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + module_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        int ret = memoryModuleTable.Delete(module_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstModule.Items.Clear();
                            DataTable dataTable2 = memoryModuleTable.GetMemoryModule();
                            foreach (DataRow dr in dataTable2.Rows)
                            {
                                lstModule.Items.Add(dr[1].ToString());
                            }
                            txtModule.Text = "";
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
                MessageBox.Show("削除するモジュールが選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
