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
    public partial class frmGokanseiCooler : Form
    {
        public frmGokanseiCooler()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiCooler_Load(object sender, EventArgs e)
        {
            CoolerTypeTable coolerTypeTable = new CoolerTypeTable();

            DataTable dataTable = coolerTypeTable.GetCoolerType();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstType.Items.Add(dr[1].ToString());
            }
        }

        private void lstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCPUcooler.Text = lstType.SelectedItem.ToString();
        }

        private void btnCPUcAdd_Click(object sender, EventArgs e)
        {
            if (txtCPUcooler.Text != "")
            {
                if (!lstType.Items.Contains(txtCPUcooler.Text))
                {
                    CoolerTypeTable coolerTypeTable = new CoolerTypeTable();
                    int ret = coolerTypeTable.Insert(txtCPUcooler.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstType.Items.Clear();
                        DataTable dataTable = coolerTypeTable.GetCoolerType();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstType.Items.Add(dr[1].ToString());
                        }

                        txtCPUcooler.Text = "";
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
                MessageBox.Show("種類の名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCPUcChange_Click(object sender, EventArgs e)
        {
            if (txtCPUcooler.Text != "" && lstType.SelectedIndex != -1)
            {
                if (!lstType.Items.Contains(txtCPUcooler.Text))
                {
                    CoolerTypeTable coolerTypeTable = new CoolerTypeTable();    
                    int ret = coolerTypeTable.Update(txtCPUcooler.Text, lstType.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstType.Items.Clear();
                        DataTable dataTable = coolerTypeTable.GetCoolerType();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstType.Items.Add(dr[1].ToString());
                        }

                        txtCPUcooler.Text = "";
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
                MessageBox.Show("変更する種類が選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
