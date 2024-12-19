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
    public partial class frmGokanseiSsd : Form
    {
        public frmGokanseiSsd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiSsd_Load(object sender, EventArgs e)
        {
            SsdConnectionTable ssdConnectionTable = new SsdConnectionTable();
            SsdStandardTable ssdStandardTable = new SsdStandardTable();
            SsdTypeTable ssdTypeTable = new SsdTypeTable();

            DataTable dataTable = ssdConnectionTable.GetSsdConnection();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstPlugs.Items.Add(dr[1].ToString());
            }

            dataTable = ssdStandardTable.GetSsdStandard();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSpec.Items.Add(dr[1].ToString());
            }

            dataTable = ssdTypeTable.GetSsdType();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstType.Items.Add(dr[1].ToString());
            }
        }

        private void lstSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSpec.Text = lstSpec.SelectedItem.ToString();
        }

        private void lstPlugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlugs.Text = lstPlugs.SelectedItem.ToString();
        }

        private void lstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtType.Text = lstType.SelectedItem.ToString();
        }

        private void btnTadd_Click(object sender, EventArgs e)
        {
            if (txtType.Text != "")
            {
                SsdTypeTable ssdTypeTable = new SsdTypeTable();
                int ret = ssdTypeTable.Insert(txtType.Text);

                if (ret == 1)
                {
                    MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lstType.Items.Clear();
                    DataTable dataTable = ssdTypeTable.GetSsdType();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        lstType.Items.Add(dr[1].ToString());
                    }

                    txtType.Text = "";
                }
                else
                {
                    MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("タイプの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTchange_Click(object sender, EventArgs e)
        {
            if (txtType.Text != "" && lstType.SelectedIndex != -1)
            {
                SsdTypeTable ssdTypeTable = new SsdTypeTable();
                int ret = ssdTypeTable.Update(txtType.Text, lstType.SelectedItem.ToString());

                if (ret == 1)
                {
                    MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lstType.Items.Clear();
                    DataTable dataTable = ssdTypeTable.GetSsdType();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        lstType.Items.Add(dr[1].ToString());
                    }

                    txtType.Text = "";
                }
                else
                {
                    MessageBox.Show("データを変更できませんでした。", "変更エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更する項目が選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTdelete_Click(object sender, EventArgs e)
        {
            if (lstType.SelectedIndex != -1)
            {
                string type_name = lstType.SelectedItem.ToString();

                DialogResult result = MessageBox.Show("「" + type_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                   //削除処理を書いてね
                }

            }
            else
            {
                MessageBox.Show("変更する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
