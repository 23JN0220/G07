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
    public partial class frmGoodsMotherboard : Form
    {
        public Goods goods;
        public GoodsMotherboard goodsMotherboard;

        public bool changedPic = false;
        public string format = null;

        public frmGoodsMotherboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("編集中の内容は保存されません。\n本当に閉じますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("画像は320×320のものを使用してください", "画像サイズについて", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult ret = ofdPicture.ShowDialog();

            if (ret == DialogResult.OK)
            {
                string fileName = ofdPicture.FileName;
                pictureBox1.ImageLocation = fileName;
                format = System.IO.Path.GetExtension(fileName);

                changedPic = true;
            }
        }

        private void frmGoodsMotherboard_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
            ChipSetSeriesTable chipsetSeriesTable = new ChipSetSeriesTable();
            MotherboardChipsetTable motherboardChipsetTable = new MotherboardChipsetTable();
            CpuSocketTable socketTable = new CpuSocketTable();
            SsdStandardTable ssdStandardTable = new SsdStandardTable();
            WirelessLanTable wirelessLanTable = new WirelessLanTable();
            MemoryStandardTable memoryStandardTable = new MemoryStandardTable();

            DataTable table = makerTable.GetMaker();

            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = motherboardSizeTable.GetMotherboardSize();

            foreach (DataRow dr in table.Rows)
            {
                lstSize.Items.Add(dr[1].ToString());
            }

            table = chipsetSeriesTable.GetChipsetSeries();

            foreach (DataRow dr in table.Rows)
            {
                lstChipSetSeries.Items.Add(dr[1].ToString());
            }

            table = motherboardChipsetTable.GetMotherboardChipset();

            foreach (DataRow dr in table.Rows)
            {
                lstChipSet.Items.Add(dr[1].ToString());
            }

            table = socketTable.GetCPUSocket();

            foreach (DataRow dr in table.Rows)
            {
                lstSocket.Items.Add(dr[1].ToString());
            }

            table = ssdStandardTable.GetSsdStandard();

            foreach (DataRow dr in table.Rows)
            {
                lstM2ssdsStandard.Items.Add(dr[1].ToString());
            }

            table = wirelessLanTable.GetWirelessLan();

            foreach (DataRow dr in table.Rows)
            {
                lstLan.Items.Add(dr[1].ToString());
            }

            table = memoryStandardTable.GetMemoryStandard();

            foreach (DataRow dr in table.Rows)
            {
                lstMemoryStandard.Items.Add(dr[1].ToString());
            }

        }
    }
}
