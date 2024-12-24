using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace 卒業制作
{
    public partial class frmGoodsCooler : Form
    {
        public Goods goods;
        public GoodsCooler goodsCooler;
        public List<int> idList = new List<int>();
        public bool changedPic = false;
        public string format = null;

        public frmGoodsCooler()
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

        private void btnSocket_Click(object sender, EventArgs e)
        {
            frmGoodsGokanseiSocket frmGoodsGokanseiSocket = new frmGoodsGokanseiSocket();

            if (idList.Count > 0)
            {
                frmGoodsGokanseiSocket.idList = idList;
            }

            frmGoodsGokanseiSocket.ShowDialog();
            idList = frmGoodsGokanseiSocket.idList;
        }

        private void frmGoodsCooler_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            CoolerTypeTable coolerTypeTable = new CoolerTypeTable();
            CoolerSocketTable coolerSocketTable = new CoolerSocketTable();

            DataTable table = makerTable.GetMaker();
            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = coolerTypeTable.GetCoolerType();
            foreach (DataRow dr in table.Rows)
            {
                lstType.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();
                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                lstType.SelectedIndex = lstType.FindStringExact(coolerTypeTable.GetCoolerTypeNameById(goodsCooler.cooler_type_id));
                txtSize.Text = goodsCooler.height.ToString();
                idList = coolerSocketTable.GetCoolerSocketById(goods.goods_code);

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstType.SelectedIndex != -1 && txtSize.Text != "" && txtPrice.Text != "")
            {
                GoodsTable goodsTable = new GoodsTable();
                GoodsCoolerTable goodsCoolerTable = new GoodsCoolerTable();
                MakerTable makerTable = new MakerTable();
                CoolerTypeTable coolerTypeTable = new CoolerTypeTable();
                CoolerSocketTable coolerSocketTable = new CoolerSocketTable();

                bool retSize = int.TryParse(txtSize.Text, out int size);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retSize && retPrice)
                {
                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 2;
                            goods.power_consumption = 10;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    goodsCooler = new GoodsCooler();
                                    goodsCooler.goods_code = goods.goods_code;
                                    goodsCooler.cooler_type_id = coolerTypeTable.GetCoolerTypeIdByName(lstType.Text);
                                    goodsCooler.height = size;

                                    int retCooler = goodsCoolerTable.Insert(goodsCooler);

                                    if (retCooler == 1)
                                    {
                                        bool retSocket = true;

                                        for (int i = 0; i < idList.Count; i++)
                                        {
                                            int socket_id = idList[i];
                                            int ret = coolerSocketTable.Insert(goods.goods_code, socket_id);

                                            if (ret != 1)
                                            {
                                                retSocket = false;
                                                break;
                                            }

                                        }

                                        if (retSocket)
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
                                            MessageBox.Show("商品の対応ソケットデータの追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("商品のCPUクーラーのデータの追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("商品の画像パスのデータ追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品の追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("同じ商品名の商品が既に追加されているため、追加できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text) || goods.goods_name == txtName.Text)
                        {
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 2;
                            goods.power_consumption = 10;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsCooler.goods_code = goods.goods_code;
                                goodsCooler.cooler_type_id = coolerTypeTable.GetCoolerTypeIdByName(lstType.Text);
                                goodsCooler.height = size;

                                int retCooler = goodsCoolerTable.Update(goodsCooler);

                                if (retCooler == 1)
                                {
                                    int delData = coolerSocketTable.Delete(goods.goods_code);

                                    bool retSocket = true;

                                    for (int i = 0; i < idList.Count; i++)
                                    {
                                        int socket_id = idList[i];
                                        int ret = coolerSocketTable.Insert(goods.goods_code, socket_id);

                                        if (ret != 1)
                                        {
                                            retSocket = false;
                                            break;
                                        }
                                    }

                                    if (retSocket)
                                    {
                                        if (changedPic)
                                        {
                                            File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                        }

                                        MessageBox.Show("商品情報を更新しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("商品の対応ソケットデータの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("商品のCPUクーラーのデータの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品データの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("同じ商品名の商品が既に追加されているため、追加できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("高さと価格の入力欄には半角数字を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }    
            }
            else
            {
                MessageBox.Show("未入力の項目があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
