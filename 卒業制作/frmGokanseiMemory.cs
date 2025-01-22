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
            txtMemoryStandard.Text = lstMemoryStandard.SelectedItem.ToString();
        }

        private void lstModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModule.Text = lstModule.SelectedItem.ToString(); 
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
    }
}
