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
            if (lstSpec.SelectedItem != null)
            {
                txtSpec.Text = lstSpec.SelectedItem.ToString();
            }

        }

        private void lstPlugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlugs.SelectedItem != null)
            {
                txtPlugs.Text = lstPlugs.SelectedItem.ToString();
            }
        }

        private void lstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstType.SelectedItem != null)
            {
                txtType.Text = lstType.SelectedItem.ToString();
            }
        }

        private void btnSpAdd_Click(object sender, EventArgs e)
        {
            if (txtSpec.Text != "")
            {
                if (!lstSpec.Items.Contains(txtSpec.Text))
                {
                    SsdStandardTable ssdStandardTable = new SsdStandardTable();
                    int ret = ssdStandardTable.Insert(txtSpec.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSpec.Items.Clear();
                        DataTable dataTable = ssdStandardTable.GetSsdStandard();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSpec.Items.Add(dr[1].ToString());
                        }

                        txtSpec.Text = "";
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
            if (txtSpec.Text != "" && lstSpec.SelectedIndex != -1)
            {
                if (!lstSpec.Items.Contains(txtSpec.Text))
                {
                    SsdStandardTable ssdStandardTable = new SsdStandardTable();
                    int ret = ssdStandardTable.Update(txtSpec.Text, lstSpec.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSpec.Items.Clear();
                        DataTable dataTable = ssdStandardTable.GetSsdStandard();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSpec.Items.Add(dr[1].ToString());
                        }

                        txtSpec.Text = "";
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

        private void btnSpDelete_Click(object sender, EventArgs e)
        {
            if (lstSpec.SelectedIndex != -1)
            {
                GoodsSsdTable goodsSsdTable = new GoodsSsdTable();
                SsdStandardTable ssdStandardTable = new SsdStandardTable();

                string standard_name = lstSpec.SelectedItem.ToString();
                int standard_id = ssdStandardTable.GetSsdStandardIdByName(standard_name);

                DataTable dataTable = goodsSsdTable.GetGoodsSsdByStandardId(standard_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + standard_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret = ssdStandardTable.Delete(standard_name);

                        if (ret != 0)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstSpec.Items.Clear();
                            DataTable table = ssdStandardTable.GetSsdStandard();
                            foreach (DataRow dr in table.Rows)
                            {
                                lstSpec.Items.Add(dr[1].ToString());
                            }

                            txtSpec.Text = "";
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
                MessageBox.Show("変更する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPadd_Click(object sender, EventArgs e)
        {
            if (txtPlugs.Text != "")
            {
                if (!lstPlugs.Items.Contains(txtPlugs.Text))
                {
                    SsdConnectionTable ssdConnectionTable = new SsdConnectionTable();
                    int ret = ssdConnectionTable.Insert(txtPlugs.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstPlugs.Items.Clear();
                        DataTable dataTable = ssdConnectionTable.GetSsdConnection();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstPlugs.Items.Add(dr[1].ToString());
                        }

                        txtPlugs.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称の接続方法が既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("接続方法の名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPchange_Click(object sender, EventArgs e)
        {
            if (txtPlugs.Text != "" && lstPlugs.SelectedIndex != -1)
            {
                if (!lstPlugs.Items.Contains(txtPlugs.Text))
                {
                    SsdConnectionTable ssdConnectionTable = new SsdConnectionTable();
                    int ret = ssdConnectionTable.Update(txtPlugs.Text, lstPlugs.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstPlugs.Items.Clear();
                        DataTable dataTable = ssdConnectionTable.GetSsdConnection();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstPlugs.Items.Add(dr[1].ToString());
                        }

                        txtPlugs.Text = "";
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

        private void btnPdelete_Click(object sender, EventArgs e)
        {
            if (lstPlugs.SelectedIndex != -1)
            {
                GoodsSsdTable goodsSsdTable = new GoodsSsdTable();
                SsdConnectionTable ssdConnectionTable = new SsdConnectionTable();
                string standard_name = lstPlugs.SelectedItem.ToString();
                int standard_id = ssdConnectionTable.GetSsdConnectionIdByName(standard_name);
                DataTable dataTable = goodsSsdTable.GetGoodsSsdByConnectionId(standard_id);
                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + standard_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (result == DialogResult.Yes)
                        {
                            int ret = ssdConnectionTable.Delete(standard_name);

                            if (ret != 0)
                            {
                                MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                lstPlugs.Items.Clear();
                                DataTable table = ssdConnectionTable.GetSsdConnection();
                                foreach (DataRow dr in table.Rows)
                                {
                                    lstPlugs.Items.Add(dr[1].ToString());
                                }

                                txtPlugs.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("データを削除できませんでした。", "削除エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
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
                MessageBox.Show("変更する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTadd_Click(object sender, EventArgs e)
        {
            if (txtType.Text != "")
            {
                if (!lstType.Items.Contains(txtType.Text))
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
                    MessageBox.Show("同じ名称のタイプが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!lstType.Items.Contains(txtType.Text))
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
                    MessageBox.Show("同じ名称のタイプが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                GoodsSsdTable goodsSsdTable = new GoodsSsdTable();
                SsdTypeTable ssdTypeTable = new SsdTypeTable();

                string type_name = lstType.SelectedItem.ToString();
                int type_id = ssdTypeTable.GetSsdTypeIdByName(type_name);

                DataTable dataTable = goodsSsdTable.GetGoodsSsdByTypeId(type_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + type_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int ret = ssdTypeTable.Delete(type_name);

                        if (ret != 0)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstType.Items.Clear();
                            DataTable table = ssdTypeTable.GetSsdType();
                            foreach (DataRow dr in table.Rows)
                            {
                                lstType.Items.Add(dr[1].ToString());
                            }

                            txtType.Text = "";
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
                MessageBox.Show("変更する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
