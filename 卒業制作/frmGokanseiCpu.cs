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
    public partial class frmGokanseiCpu : Form
    {
        public frmGokanseiCpu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiCpu_Load(object sender, EventArgs e)
        {
            ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();
            CpuGenerationTable generationTable = new CpuGenerationTable();
            CpuSocketTable socketTable = new CpuSocketTable();
            CpuSeriesTable seriesTable = new CpuSeriesTable();


            DataTable dataTable = chipSetSeriesTable.GetChipsetSeries();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstChipset.Items.Add(dr[1].ToString());
            }

            dataTable = generationTable.GetCPUGeneration();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstGen.Items.Add(dr[1].ToString());
            }

            dataTable = socketTable.GetCPUSocket();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSocket.Items.Add(dr[1].ToString());
            }
            dataTable = seriesTable.GetCpuSeries();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSeries.Items.Add(dr[1].ToString());
            }
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSeries.SelectedItem != null)
            {
                txtSeries.Text = lstSeries.SelectedItem.ToString();
            }
        }

        private void lstGen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGen.SelectedItem != null)
            {
                txtGen.Text = lstGen.SelectedItem.ToString();
            }
        }

        private void lstSocket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSocket.SelectedItem != null)
            {
                txtSocket.Text = lstSocket.SelectedItem.ToString();
            }
        }

        private void lstChipset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChipset.SelectedItem != null)
            {
                txtChipset.Text = lstChipset.SelectedItem.ToString();
            }
        }

        private void btnSeAdd_Click(object sender, EventArgs e)
        {
            if (txtSeries.Text != "")
            {
                if (!lstSeries.Items.Contains(txtSeries.Text))
                {
                    CpuSeriesTable cpuSeriesTable = new CpuSeriesTable();
                    int ret = cpuSeriesTable.Insert(txtSeries.Text);

                    if (ret == 1)
                    {

                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSeries.Items.Clear();
                        DataTable dataTable = cpuSeriesTable.GetCpuSeries();
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
                    MessageBox.Show("同じ名称のタイプが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    CpuSeriesTable cpuSeriesTable = new CpuSeriesTable();
                    int ret = cpuSeriesTable.Update(txtSeries.Text, lstSeries.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSeries.Items.Clear();
                        DataTable dataTable = cpuSeriesTable.GetCpuSeries();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSeries.Items.Add(dr[1].ToString());
                        }

                        txtSeries.Text = "";
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

        private void btnSeDelete_Click(object sender, EventArgs e)
        {
            if (lstSeries.SelectedIndex != -1)
            {
                GoodsCpuTable goodsCpuTable = new GoodsCpuTable();
                CpuSeriesTable cpuSeriesTable = new CpuSeriesTable();

                string series_name = lstSeries.SelectedItem.ToString();
                int series_id = cpuSeriesTable.GetCpuSeriesIdByName(series_name);

                DataTable dataTable = goodsCpuTable.GetGoodsCpuBySeriesId(series_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + series_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret = cpuSeriesTable.Delete(series_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstSeries.Items.Clear();
                            DataTable table = cpuSeriesTable.GetCpuSeries();
                            foreach (DataRow dr in table.Rows)
                            {
                                lstSeries.Items.Add(dr[1].ToString());
                            }

                            txtSeries.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("データを削除できませんでした。", "削除失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnGadd_Click(object sender, EventArgs e)
        {
            if (txtGen.Text != "")
            {
                if (!lstGen.Items.Contains(txtGen.Text))
                {
                    CpuGenerationTable cpuGenerationTable = new CpuGenerationTable();
                    int ret = cpuGenerationTable.Insert(txtGen.Text);

                    if (ret == 1)
                    {

                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstGen.Items.Clear();
                        DataTable dataTable = cpuGenerationTable.GetCPUGeneration();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstGen.Items.Add(dr[1].ToString());
                        }

                        txtGen.Text = "";
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
                MessageBox.Show("世代の名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGchange_Click(object sender, EventArgs e)
        {
            if (txtGen.Text != "" && lstGen.SelectedIndex != -1)
            {
                if (!lstGen.Items.Contains(txtGen.Text))
                {
                    CpuGenerationTable cpuGenerationTable = new CpuGenerationTable();
                    int ret = cpuGenerationTable.Update(txtGen.Text, lstGen.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstGen.Items.Clear();
                        DataTable dataTable = cpuGenerationTable.GetCPUGeneration();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstGen.Items.Add(dr[1].ToString());
                        }

                        txtGen.Text = "";
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

        private void btnGdelete_Click(object sender, EventArgs e)
        {
            if (lstGen.SelectedIndex != -1)
            {
                GoodsCpuTable goodsCpuTable = new GoodsCpuTable();
                CpuGenerationTable cpuGenerationTable = new CpuGenerationTable();

                string generation_name = lstGen.SelectedItem.ToString();
                int generation_id = cpuGenerationTable.GetCPUGenerationIdByName(generation_name);

                DataTable dataTable = goodsCpuTable.GetGoodsCpuByGenerationId(generation_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + generation_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret = cpuGenerationTable.Delete(generation_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstGen.Items.Clear();
                            DataTable table = cpuGenerationTable.GetCPUGeneration();
                            foreach (DataRow dr in table.Rows)
                            {
                                lstGen.Items.Add(dr[1].ToString());
                            }

                            txtGen.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("データを削除できませんでした。", "削除失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSoAdd_Click(object sender, EventArgs e)
        {
            if (txtSocket.Text != "")
            {
                if (!lstSocket.Items.Contains(txtSocket.Text))
                {
                    CpuSocketTable cpuSocketTable = new CpuSocketTable();
                    int ret = cpuSocketTable.Insert(txtSocket.Text);

                    if (ret == 1)
                    {

                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSocket.Items.Clear();
                        DataTable dataTable = cpuSocketTable.GetCPUSocket();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSocket.Items.Add(dr[1].ToString());
                        }

                        txtSocket.Text = "";
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
                MessageBox.Show("ソケットの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSoChange_Click(object sender, EventArgs e)
        {
            if (txtSocket.Text != "" && lstSocket.SelectedIndex != -1)
            {
                if (!lstSocket.Items.Contains(txtSocket.Text))
                {
                    CpuSocketTable cpuSocketTable = new CpuSocketTable();
                    int ret = cpuSocketTable.Update(txtSocket.Text, lstSocket.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstSocket.Items.Clear();
                        DataTable dataTable = cpuSocketTable.GetCPUSocket();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            lstSocket.Items.Add(dr[1].ToString());
                        }

                        txtSocket.Text = "";
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

        private void btnSoDelete_Click(object sender, EventArgs e)
        {
            if (lstSocket.SelectedIndex != -1)
            {
                GoodsCpuTable goodsCpuTable = new GoodsCpuTable();
                GoodsMotherboardTable goodsMotherboardTable = new GoodsMotherboardTable();
                CpuSocketTable cpuSocketTable = new CpuSocketTable();
                CoolerSocketTable coolerSocketTable = new CoolerSocketTable();

                string socket_name = lstSocket.SelectedItem.ToString();
                int socket_id = cpuSocketTable.GetCPUSocketIdByName(socket_name);

                DataTable dataTable = goodsCpuTable.GetGoodsCpuBySocketId(socket_id);
                DataTable dataTable2 = goodsMotherboardTable.GetGoodsMotherboardBySocketId(socket_id);

                if (dataTable == null && dataTable2 == null)
                {
                    DialogResult result = MessageBox.Show("「" + socket_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret2 = coolerSocketTable.DeleteBySocketId(socket_id);
                        int ret = cpuSocketTable.Delete(socket_name);
                        
                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstSocket.Items.Clear();
                            DataTable table = cpuSocketTable.GetCPUSocket();
                            foreach (DataRow dr in table.Rows)
                            {
                                lstSocket.Items.Add(dr[1].ToString());
                            }

                            txtSocket.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("データを削除できませんでした。", "削除失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("変更する項目が選択されていません。\n", "未選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCadd_Click(object sender, EventArgs e)
        {
            if (txtChipset.Text != "")
            {
                if (!lstChipset.Items.Contains(txtChipset.Text))
                {
                    ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();
                    int ret = chipSetSeriesTable.Insert(txtChipset.Text);

                    if (ret == 1)
                    {
                        MessageBox.Show("データを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstChipset.Items.Clear();
                        DataTable dataTable = chipSetSeriesTable.GetChipsetSeries();
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
                    MessageBox.Show("同じ名称のタイプが既に存在します。\n別の名称を入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("チップセットシリーズの名称が入力されていません。\n名称を入力してください。", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCchange_Click(object sender, EventArgs e)
        {
            if (txtChipset.Text != "" && lstChipset.SelectedIndex != -1)
            {
                if (!lstChipset.Items.Contains(txtChipset.Text))
                {
                    ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();
                    int ret = chipSetSeriesTable.Update(txtChipset.Text, lstChipset.SelectedItem.ToString());

                    if (ret == 1)
                    {
                        MessageBox.Show("データを変更しました。", "変更完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstChipset.Items.Clear();
                        DataTable dataTable = chipSetSeriesTable.GetChipsetSeries();
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

        private void btnCdelete_Click(object sender, EventArgs e)
        {
            if (lstChipset.SelectedIndex != -1)
            {
                GoodsMotherboardTable goodsMotherboardTable = new GoodsMotherboardTable();
                ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();

                string series_name = lstChipset.SelectedItem.ToString();
                int series_id = chipSetSeriesTable.GetChipSetIdByName(series_name);

                DataTable dataTable = goodsMotherboardTable.GetGoodsMotherboardByChipsetSeriesId(series_id);

                if (dataTable == null)
                {
                    DialogResult result = MessageBox.Show("「" + series_name + "」を削除します。\n削除すると元に戻せません。\n本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int ret = chipSetSeriesTable.Delete(series_name);

                        if (ret == 1)
                        {
                            MessageBox.Show("データを削除しました。", "削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstChipset.Items.Clear();
                            DataTable table = chipSetSeriesTable.GetChipsetSeries();
                            foreach (DataRow dr in table.Rows)
                            {
                                lstChipset.Items.Add(dr[1].ToString());
                            }

                            txtChipset.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("データを削除できませんでした。", "削除失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

