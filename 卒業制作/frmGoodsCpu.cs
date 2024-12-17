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
    public partial class frmGoodsCpu : Form
    {
        public Goods goods;
        public GoodsCpu goodsCpu;

        public List<int> idList = new List<int>();

        public frmGoodsCpu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnChipSetSelect_Click(object sender, EventArgs e)
        {
            frmGoodsGokanseiChipSet frmGoodsGokanseiChipSet = new frmGoodsGokanseiChipSet();

            if (idList.Count > 0)
            {
                frmGoodsGokanseiChipSet.idList = idList;
            }

            frmGoodsGokanseiChipSet.ShowDialog();
            idList = frmGoodsGokanseiChipSet.idList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (goods == null)
            {
                //新規登録
                MessageBox.Show("新規登録");
            }
            else
            {
                //商品情報変更
                MessageBox.Show("商品情報変更");
            }
        }

        private void frmGoodsCpu_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            CpuChipsetSeriesTable cpuChipsetSeries = new CpuChipsetSeriesTable();
            CpuSeriesTable cpuSeriesTable = new CpuSeriesTable();
            CpuGenerationTable cpuGenerationTable = new CpuGenerationTable();
            CpuSocketTable cpuSocketTable = new CpuSocketTable();

            DataTable table = makerTable.GetMaker();
            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = cpuSeriesTable.GetCpuSeries();
            foreach (DataRow dr in table.Rows)
            {
                lstSeries.Items.Add(dr[1].ToString());
            }

            table = cpuGenerationTable.GetCPUGeneration();
            foreach (DataRow dr in table.Rows)
            {
                lstGenerational.Items.Add(dr[1].ToString());
            }

            table = cpuSocketTable.GetCPUSocket();
            foreach (DataRow dr in table.Rows)
            {
                lstSocket.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();
                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameByID(goods.maker_id));
                lstSeries.SelectedIndex = lstSeries.FindStringExact(cpuSeriesTable.GetCpuSeriesNameByID(goodsCpu.series_id));
                lstGenerational.SelectedIndex = lstGenerational.FindStringExact(cpuGenerationTable.GetCPUGenerationNameByID(goodsCpu.generation_id));
                lstSocket.SelectedIndex = lstSocket.FindStringExact(cpuSocketTable.GetCPUSocketNameByID(goodsCpu.socket_id));
                txtCore.Text = goodsCpu.core.ToString();
                txtThread.Text = goodsCpu.thread.ToString();
                txtClock.Text = goodsCpu.clock.ToString();
                txtPowerConsumption.Text = goods.power_consumption.ToString();
                idList = cpuChipsetSeries.GetCpuChipsetSeriesById(goods.goods_code);

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_code + ".jpg";

            }
        }
    }
}
