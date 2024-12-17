﻿using System;
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
            MakerTable makerTable = new MakerTable();
            CpuSeriesTable cpuSeriesTable = new CpuSeriesTable();
            CpuGenerationTable cpuGenerationTable = new CpuGenerationTable();
            CpuSocketTable cpuSocketTable = new CpuSocketTable();
            GoodsTable goodsTable = new GoodsTable();
            GoodsCpuTable goodsCpuTable = new GoodsCpuTable();
            CpuChipsetSeriesTable cpuChipsetSeriesTable = new CpuChipsetSeriesTable();


            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstSeries.SelectedIndex != -1 && lstGenerational.SelectedIndex != -1 && lstSocket.SelectedIndex != -1 && txtPrice.Text != "" && idList.Count != 0)
            {
                bool retCore = int.TryParse(txtCore.Text, out int core);
                bool retThread = int.TryParse(txtThread.Text, out int thread);
                bool retClock = double.TryParse(txtClock.Text, out double clock);
                bool retPower = int.TryParse(txtPowerConsumption.Text, out int power);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);


                if (retCore && retThread && retPower && retPrice && retClock)
                {
                    if (goods == null)
                    {
                        //新規登録
                        goods = new Goods();
                        goods.goods_name = txtName.Text;
                        goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                        goods.price = price;
                        goods.group_code = 1;
                        goods.power_consumption = power;

                        int retGoods = goodsTable.Insert(goods);

                        if (retGoods == 1)
                        {
                            goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                            goods.goods_image = goods.goods_code + ".jpg";
                            int retPic = goodsTable.UpdatePicture(goods);

                            if (retPic == 1)
                            {
                                goodsCpu = new GoodsCpu();
                                goodsCpu.goods_code = goods.goods_code;
                                goodsCpu.series_id = cpuSeriesTable.GetCpuSeriesIdByName(lstSeries.Text);
                                goodsCpu.generation_id = cpuGenerationTable.GetCPUGenerationIdByName(lstGenerational.Text);
                                goodsCpu.socket_id = cpuSocketTable.GetCPUSocketIdByName(lstSocket.Text);
                                goodsCpu.core = core;
                                goodsCpu.thread = thread;
                                goodsCpu.clock = clock;

                                int retGoodsCpu = goodsCpuTable.Insert(goodsCpu);

                                if (retGoodsCpu == 1)
                                {
                                    bool retChip = true;

                                    for (int i = 0; i < idList.Count; i++)
                                    {
                                        int chipsetid = idList[i];
                                        int ret = cpuChipsetSeriesTable.Insert(goods.goods_code, chipsetid);

                                        if (ret != 1)
                                        {
                                            retChip = false;
                                            break;
                                        }
                                        
                                    }


                                    if (retChip)
                                    {
                                        MessageBox.Show("商品を追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("CPUとチップセットシリーズ対応データの追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("商品のCPUデータの追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                            }
                            else
                            {
                                MessageBox.Show("商品の画像パスのデータ追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }
                        else
                        {
                            MessageBox.Show("商品の追加に失敗しました。\n同じ商品名の商品が既に追加されている場合があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }







                    }
                    else
                    {
                        //商品情報変更
                        MessageBox.Show("商品情報変更");
                    }
                }
                else
                {
                    MessageBox.Show("入力された形式に誤りがあるか、未入力の項目があります。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } 
            }
            else
            {
                MessageBox.Show("入力された形式に誤りがあるか、未入力の項目があります。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                lstSeries.SelectedIndex = lstSeries.FindStringExact(cpuSeriesTable.GetCpuSeriesNameById(goodsCpu.series_id));
                lstGenerational.SelectedIndex = lstGenerational.FindStringExact(cpuGenerationTable.GetCPUGenerationNameById(goodsCpu.generation_id));
                lstSocket.SelectedIndex = lstSocket.FindStringExact(cpuSocketTable.GetCPUSocketNameById(goodsCpu.socket_id));
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
