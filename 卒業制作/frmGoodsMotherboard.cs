using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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

        private bool processed = false;

        public frmGoodsMotherboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (goods != null) {
                txtName.Text = goods.goods_name;
                lstMaker.Text = makerTable.GetMakerNameById(goods.maker_id);
                lstSize.SelectedIndex = lstSize.FindStringExact(motherboardSizeTable.GetMotherboardSizeNameById(goodsMotherboard.size));
                lstChipSetSeries.SelectedIndex = lstChipSetSeries.FindStringExact(chipsetSeriesTable.GetChipSetNameById(goodsMotherboard.chipset_series_id));
                lstChipSet.SelectedIndex = lstChipSet.FindStringExact(motherboardChipsetTable.GetMotherboardChipsetNameById(goodsMotherboard.chipset_id));
                lstSocket.SelectedIndex = lstSocket.FindStringExact(socketTable.GetCPUSocketNameById(goodsMotherboard.socket_id));
                lstM2ssdsStandard.SelectedIndex = lstM2ssdsStandard.FindStringExact(ssdStandardTable.GetSsdStandardNameById(goodsMotherboard.m2ssd_standard_id));
                lstLan.SelectedIndex = lstLan.FindStringExact(wirelessLanTable.GetWirelessLanNameById(goodsMotherboard.lan_standerd_id));
                lstMemoryStandard.SelectedIndex = lstMemoryStandard.FindStringExact(memoryStandardTable.GetMemoryStandardNameById(goodsMotherboard.standerd_id));

                txtPciNumber.Text = goodsMotherboard.pci_number.ToString();
                txtM2SSDNumber.Text = goodsMotherboard.m2ssd_number.ToString();
                txtSataNumber.Text = goodsMotherboard.sata_number.ToString();
                txtMaxNumber.Text = goodsMotherboard.max_number.ToString();
                txtPrice.Text = goods.price.ToString();

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstSize.SelectedIndex != -1 && lstChipSetSeries.SelectedIndex != -1 && lstChipSet.SelectedIndex != -1 && lstSocket.SelectedIndex != -1 && lstM2ssdsStandard.SelectedIndex != -1 && lstLan.SelectedIndex != -1 && lstMemoryStandard.SelectedIndex != -1)
            {
                bool retPci = int.TryParse(txtPciNumber.Text, out int pci_number);
                bool retM2SSD = int.TryParse(txtM2SSDNumber.Text, out int m2ssd_number);
                bool retSata = int.TryParse(txtSataNumber.Text, out int sata_number);
                bool retMax = int.TryParse(txtMaxNumber.Text, out int max_number);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retPci && retM2SSD && retSata && retMax && retPrice)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    MakerTable makerTable = new MakerTable();
                    MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
                    ChipSetSeriesTable chipsetSeriesTable = new ChipSetSeriesTable();
                    MotherboardChipsetTable motherboardChipsetTable = new MotherboardChipsetTable();
                    CpuSocketTable socketTable = new CpuSocketTable();
                    SsdStandardTable ssdStandardTable = new SsdStandardTable();
                    WirelessLanTable wirelessLanTable = new WirelessLanTable();
                    MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
                    GoodsMotherboardTable goodsMotherboardTable = new GoodsMotherboardTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 3;
                            goods.power_consumption = 30;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    goodsMotherboard = new GoodsMotherboard();
                                    goodsMotherboard.goods_code = goods.goods_code;
                                    goodsMotherboard.size = motherboardSizeTable.GetMotherboardSizeIdByName(lstSize.Text);
                                    goodsMotherboard.chipset_series_id = chipsetSeriesTable.GetChipSetIdByName(lstChipSetSeries.Text);
                                    goodsMotherboard.chipset_id = motherboardChipsetTable.GetMotherboardChipsetIdByName(lstChipSet.Text);
                                    goodsMotherboard.socket_id = socketTable.GetCPUSocketIdByName(lstSocket.Text);
                                    goodsMotherboard.pci_number = pci_number;
                                    goodsMotherboard.m2ssd_standard_id = ssdStandardTable.GetSsdStandardIdByName(lstM2ssdsStandard.Text);
                                    goodsMotherboard.m2ssd_number = m2ssd_number;
                                    goodsMotherboard.sata_number = sata_number;
                                    goodsMotherboard.lan_standerd_id = wirelessLanTable.GetWirelessLanIdByName(lstLan.Text);
                                    goodsMotherboard.max_number = max_number;
                                    goodsMotherboard.standerd_id = memoryStandardTable.GetMemoryStandardIdByName(lstMemoryStandard.Text);

                                    int retMotherBoard = goodsMotherboardTable.Insert(goodsMotherboard);

                                    if (retMotherBoard == 1)
                                    {
                                        if (changedPic)
                                        {
                                            File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                        }

                                        MessageBox.Show("商品を追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        processed = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("商品のマザーボードのデータの追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            goods.group_code = 3;
                            goods.power_consumption = 30;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsMotherboard.goods_code = goods.goods_code;
                                goodsMotherboard.size = motherboardSizeTable.GetMotherboardSizeIdByName(lstSize.Text);
                                goodsMotherboard.chipset_series_id = chipsetSeriesTable.GetChipSetIdByName(lstChipSetSeries.Text);
                                goodsMotherboard.chipset_id = motherboardChipsetTable.GetMotherboardChipsetIdByName(lstChipSet.Text);
                                goodsMotherboard.socket_id = socketTable.GetCPUSocketIdByName(lstSocket.Text);
                                goodsMotherboard.pci_number = pci_number;
                                goodsMotherboard.m2ssd_standard_id = ssdStandardTable.GetSsdStandardIdByName(lstM2ssdsStandard.Text);
                                goodsMotherboard.m2ssd_number = m2ssd_number;
                                goodsMotherboard.sata_number = sata_number;
                                goodsMotherboard.lan_standerd_id = wirelessLanTable.GetWirelessLanIdByName(lstLan.Text);
                                goodsMotherboard.max_number = max_number;
                                goodsMotherboard.standerd_id = memoryStandardTable.GetMemoryStandardIdByName(lstMemoryStandard.Text);

                                int retMotherBoard = goodsMotherboardTable.Update(goodsMotherboard);

                                if (retMotherBoard == 1)
                                {
                                    if (changedPic)
                                    {
                                        File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                    }

                                    MessageBox.Show("商品情報を更新しました", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    processed = true;
                                    this.Close();
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
                MessageBox.Show("未入力の項目があります。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void frmGoodsMotherboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!processed)
            {
                DialogResult ret = MessageBox.Show("編集中の内容は保存されません。\n本当に閉じますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ret != DialogResult.Yes)
                {
                    e.Cancel = true;

                }
            }
        }
    }
}
