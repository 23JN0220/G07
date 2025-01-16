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
    public partial class frmGoodsGpu : Form
    {

        public Goods goods;
        public GoodsGpu goodsGpu;


        public bool changedPic = false;
        public string format = null;

        public frmGoodsGpu()
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

        private void frmGoodsGpu_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();
            GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();
            GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();

            DataTable table = makerTable.GetMaker();
            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = gpuInterfaceTable.GetGpuInterface();
            foreach (DataRow dr in table.Rows)
            {
                lstInterface.Items.Add(dr[1].ToString());
            }

            table = gpuResolutionTable.GetGpuResolution();
            foreach (DataRow dr in table.Rows)
            {
                lstResolution.Items.Add(dr[1].ToString());
            }

            table = gpuSeriesTable.GetGpuSeries();
            foreach (DataRow dr in table.Rows)
            {
                lstSeries.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();
                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                txtMemory.Text = goodsGpu.memory_size.ToString();
                txtCuda.Text = goodsGpu.cuda.ToString();
                txtPowerConsumption.Text = goods.power_consumption.ToString();
                txtSize.Text = goodsGpu.width.ToString();
                txtDp.Text = goodsGpu.dp_port.ToString();
                txtHdmi.Text = goodsGpu.hdmi_port.ToString();
                txtOutput.Text = goodsGpu.max_output.ToString();
                txtSlot.Text = goodsGpu.slot.ToString();
                lstSeries.SelectedIndex = lstSeries.FindStringExact(gpuSeriesTable.GetGpuSeriesNameById(goodsGpu.series_id));
                lstInterface.SelectedIndex = lstInterface.FindStringExact(gpuInterfaceTable.GetGpuInterfaceNameById(goodsGpu.interface_id));
                lstResolution.SelectedIndex = lstResolution.FindStringExact(gpuResolutionTable.GetGpuResolutionNameById(goodsGpu.resolution_id));

                if (goodsGpu.lowpro)
                {
                    chkLowPro.Checked = true;
                }
                else
                {
                    chkLowPro.Checked = false;
                }
                if (goodsGpu.auxiliary)
                {
                    chkAuxiliary.Checked = true;
                }
                else
                {
                    chkAuxiliary.Checked = false;
                }

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;


            }
        }
    }
}
