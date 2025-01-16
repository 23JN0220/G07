using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstSeries.SelectedIndex != -1 && lstInterface.SelectedIndex != -1 && lstResolution.SelectedIndex != -1)
            {
                bool retMemory = int.TryParse(txtMemory.Text, out int memory_size);
                bool retCuda = int.TryParse(txtCuda.Text, out int cuda);
                bool retPower = int.TryParse(txtPowerConsumption.Text, out int power_consumption);
                bool retSize = int.TryParse(txtSize.Text, out int width);
                bool retDp = int.TryParse(txtDp.Text, out int dp_port);
                bool retHdmi = int.TryParse(txtHdmi.Text, out int hdmi_port);
                bool retOutput = int.TryParse(txtOutput.Text, out int max_output);
                bool retSlot = int.TryParse(txtSlot.Text, out int slot);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retMemory && retCuda && retPower && retSize && retDp && retHdmi && retOutput && retSlot)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    MakerTable makerTable = new MakerTable();
                    GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();
                    GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();
                    GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();
                    GoodsGpuTable goodsGpuTable = new GoodsGpuTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 5;
                            goods.power_consumption = power_consumption;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    goodsGpu = new GoodsGpu();
                                    goodsGpu.goods_code = goods.goods_code;
                                    goodsGpu.series_id = gpuSeriesTable.GetGpuSeriesIdByName(lstSeries.Text);
                                    goodsGpu.memory_size = memory_size;
                                    goodsGpu.cuda = cuda;
                                    goodsGpu.width = width;
                                    goodsGpu.interface_id = gpuInterfaceTable.GetGpuInterfaceIdByName(lstInterface.Text);
                                    goodsGpu.hdmi_port = hdmi_port;
                                    goodsGpu.dp_port = dp_port;
                                    goodsGpu.max_output = max_output;
                                    goodsGpu.resolution_id = gpuResolutionTable.GetGpuResolutionIdByName(lstResolution.Text);
                                    goodsGpu.slot = slot;
                                    
                                    if (chkLowPro.Checked)
                                    {
                                        goodsGpu.lowpro = true;
                                    }
                                    else
                                    {
                                        goodsGpu.lowpro = false;
                                    }

                                    if (chkAuxiliary.Checked)
                                    {
                                        goodsGpu.auxiliary = true;
                                    }
                                    else
                                    {
                                        goodsGpu.auxiliary = false;
                                    }


                                    int retGpu = goodsGpuTable.Insert(goodsGpu);

                                    if (retGpu == 1)
                                    {
                                        if (changedPic)
                                        {
                                            File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                        }

                                        MessageBox.Show("商品を追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("商品のGPUデータの追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("商品の画像パスのデータ追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品の追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("同じ商品名の商品が既に追加されているため、追加できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text) || goods.goods_name == txtName.Text)
                        {
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 5;
                            goods.power_consumption = power_consumption;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsGpu.goods_code = goods.goods_code;
                                goodsGpu.series_id = gpuSeriesTable.GetGpuSeriesIdByName(lstSeries.Text);
                                goodsGpu.memory_size = memory_size;
                                goodsGpu.cuda = cuda;
                                goodsGpu.width = width;
                                goodsGpu.interface_id = gpuInterfaceTable.GetGpuInterfaceIdByName(lstInterface.Text);
                                goodsGpu.hdmi_port = hdmi_port;
                                goodsGpu.dp_port = dp_port;
                                goodsGpu.max_output = max_output;
                                goodsGpu.resolution_id = gpuResolutionTable.GetGpuResolutionIdByName(lstResolution.Text);
                                goodsGpu.slot = slot;

                                if (chkLowPro.Checked)
                                {
                                    goodsGpu.lowpro = true;
                                }
                                else
                                {
                                    goodsGpu.lowpro = false;
                                }
                                if (chkAuxiliary.Checked)
                                {
                                    goodsGpu.auxiliary = true;
                                }
                                else
                                {
                                    goodsGpu.auxiliary = false;
                                }

                                int retGpu = goodsGpuTable.Update(goodsGpu);

                                if (retGpu == 1)
                                {
                                    if (changedPic)
                                    {
                                        File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                    }

                                    MessageBox.Show("商品情報を更新しました", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("商品のGPU情報の更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品の更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }


                        }
                        else
                        {
                            MessageBox.Show("同じ商品名の商品が既に追加されているため、追加できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("名前以外のテキストボックスには半角数字を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("未入力の項目があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
