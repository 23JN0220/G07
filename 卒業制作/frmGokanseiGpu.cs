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
    public partial class frmGokanseiGpu : Form
    {
        public frmGokanseiGpu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiGpu_Load(object sender, EventArgs e)
        {
            GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();
            GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();
            GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();

            DataTable dataTable = gpuSeriesTable.GetGpuSeries();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSeries.Items.Add(dr[1].ToString());
            }
            dataTable = gpuInterfaceTable.GetGpuInterface();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstInterface.Items.Add(dr[1].ToString());
            }
            dataTable = gpuResolutionTable.GetGpuResolution();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstRes.Items.Add(dr[1].ToString());
            }
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSeries.SelectedItem != null)
            {
                txtSeries.Text = lstSeries.SelectedItem.ToString();
            }

        }

        private void lstInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInterface.SelectedItem != null)
            {
                txtInterface.Text = lstInterface.SelectedItem.ToString();
            }
        }

        private void lstRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRes.SelectedItem != null)
            {
                txtRes.Text = lstRes.SelectedItem.ToString();
            }
        }

        private void btnSeAdd_Click(object sender, EventArgs e)
        {
            if (txtSeries.Text != "")
            {
                if (!lstSeries.Items.Contains(txtSeries.Text))
                {
                    GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();
                    int ret = gpuSeriesTable.Insert(txtSeries.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSeries.Items.Clear();
                        DataTable dataTable = gpuSeriesTable.GetGpuSeries();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSeries.Items.Add(dr[1].ToString());
                        }

                        txtSeries.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のシリーズが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("シリーズの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSeChange_Click(object sender, EventArgs e)
        {
            if (txtSeries.Text != "" && lstSeries.SelectedIndex != -1)
            {
                if (!lstSeries.Items.Contains(txtSeries.Text))
                {
                    GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();
                    int ret = gpuSeriesTable.Update(txtSeries.Text, lstSeries.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSeries.Items.Clear();
                        DataTable dataTable = gpuSeriesTable.GetGpuSeries();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSeries.Items.Add(dr[1].ToString());
                        }

                        lstSeries.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを変更できませんでした。", "変更エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のシリーズが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更するシリーズが選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnIadd_Click(object sender, EventArgs e)
        {
            if (txtInterface.Text != "")
            {
                if (!lstInterface.Items.Contains(txtInterface.Text))
                {
                    GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();
                    int ret = gpuInterfaceTable.Insert(txtInterface.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstInterface.Items.Clear();
                        DataTable dataTable = gpuInterfaceTable.GetGpuInterface();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstInterface.Items.Add(dr[1].ToString());
                        }

                        lstInterface.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを追加できませんでした。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のインターフェイスが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("インターフェイスの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnIchange_Click(object sender, EventArgs e)
        {
            if (txtInterface.Text != "" && lstInterface.SelectedIndex != -1)
            {
                if (!lstInterface.Items.Contains(txtInterface.Text))
                {
                    GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();
                    int ret = gpuInterfaceTable.Update(txtInterface.Text, lstInterface.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstInterface.Items.Clear();
                        DataTable dataTable = gpuInterfaceTable.GetGpuInterface();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstInterface.Items.Add(dr[1].ToString());
                        }

                        txtInterface.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("データを変更できませんでした。", "変更エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("同じ名称のインターフェイスが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("変更するインターフェイスが選択されていないか、変更後の名称が未入力です。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRadd_Click(object sender, EventArgs e)
        {
            if (txtRes.Text != "")
            {
                if (!lstRes.Items.Contains(txtRes.Text))
                {
                    GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();
                    int ret = gpuResolutionTable.Insert(txtRes.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstRes.Items.Clear();
                        DataTable dataTable = gpuResolutionTable.GetGpuResolution();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstRes.Items.Add(dr[1].ToString());
                        }

                        txtRes.Text = "";
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

        private void btnRchange_Click(object sender, EventArgs e)
        {
            if (txtRes.Text != "" && lstRes.SelectedIndex != -1)
            {
                if (!lstRes.Items.Contains(txtRes.Text))
                {
                    GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();
                    int ret = gpuResolutionTable.Update(txtRes.Text, lstRes.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstRes.Items.Clear();
                        DataTable dataTable = gpuResolutionTable.GetGpuResolution();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstRes.Items.Add(dr[1].ToString());
                        }

                        txtRes.Text = "";
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

        private void btnSeDelete_Click(object sender, EventArgs e)
        {
            if (lstSeries.SelectedIndex != -1)
            {
                GoodsGpuTable goodsGpuTable = new GoodsGpuTable();
                GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();

                string gpu_series_name = lstSeries.SelectedItem.ToString();
                int gpu_series_id = gpuSeriesTable.GetGpuSeriesIdByName(gpu_series_name);

                DataTable dataTable = goodsGpuTable.GetGoodsGpuBySeriesId(gpu_series_id);
                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + gpu_series_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        int ret = gpuSeriesTable.Delete(gpu_series_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstSeries.Items.Clear();
                            dataTable = gpuSeriesTable.GetGpuSeries();
                            foreach (DataRow dr in dataTable.Rows)
                            {
                                lstSeries.Items.Add(dr[1].ToString());
                            }
                            txtSeries.Text = "";
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
                MessageBox.Show("削除するシリーズが選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnIdelete_Click(object sender, EventArgs e)
        {
            if (lstInterface.SelectedIndex != -1)
            {
                GoodsGpuTable goodsGpuTable = new GoodsGpuTable();
                GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();

                string interface_name = lstInterface.SelectedItem.ToString();
                int interface_id = gpuInterfaceTable.GetGpuInterfaceIdByName(interface_name);

                DataTable dataTable = goodsGpuTable.GetGoodsGpuByInterfaceId(interface_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + interface_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        int ret = gpuInterfaceTable.Delete(interface_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstInterface.Items.Clear();
                            dataTable = gpuInterfaceTable.GetGpuInterface();
                            foreach (DataRow dr in dataTable.Rows)
                            {
                                lstInterface.Items.Add(dr[1].ToString());
                            }
                            txtInterface.Text = "";
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
                MessageBox.Show("削除するインターフェイスが選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRdelete_Click(object sender, EventArgs e)
        {
            if (lstRes.SelectedIndex != -1)
            {
                GoodsGpuTable goodsGpuTable = new GoodsGpuTable();
                GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();

                string resolution_name = lstRes.SelectedItem.ToString();
                int resolution_id = gpuResolutionTable.GetGpuResolutionIdByName(resolution_name);

                DataTable dataTable = goodsGpuTable.GetGoodsGpuByResolutionId(resolution_id);
                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + resolution_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        int ret = gpuResolutionTable.Delete(resolution_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstRes.Items.Clear();
                            dataTable = gpuResolutionTable.GetGpuResolution();
                            foreach (DataRow dr in dataTable.Rows)
                            {
                                lstRes.Items.Add(dr[1].ToString());
                            }
                            txtRes.Text = "";
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
                MessageBox.Show("削除する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
