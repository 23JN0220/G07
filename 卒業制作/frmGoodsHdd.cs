using ClassLibrary;
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

namespace 卒業制作
{
    public partial class frmGoodsHdd : Form
    {
        public Goods goods;
        public GoodsHdd goodsHdd;

        public bool changedPic = false;
        public string format = null;

        private bool processed = false;

        public frmGoodsHdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGoodsHdd_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();

            DataTable table = makerTable.GetMaker();

            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();

                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                txtCapacity.Text = goodsHdd.capacity.ToString();
                //False(0) = 3.5インチ, True(1) = 2.5インチ
                if (goodsHdd.size)
                {
                    lstSize.SelectedIndex = 0;  //2.5インチ
                }
                else
                {
                    lstSize.SelectedIndex = 1;  //3.5インチ
                }

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstSize.SelectedIndex != -1)
            {
                bool retcapacity = int.TryParse(txtCapacity.Text, out int capacity);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retcapacity && retPrice)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    MakerTable makerTable = new MakerTable();
                    GoodsHddTable goodsHddTable = new GoodsHddTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 7;
                            goods.power_consumption = 10;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    GoodsHdd goodsHdd = new GoodsHdd();
                                    goodsHdd.goods_code = goods.goods_code;
                                    goodsHdd.capacity = capacity;
                                    if (lstSize.SelectedIndex == 0)
                                    {
                                        goodsHdd.size = true;
                                    }
                                    else
                                    {
                                        goodsHdd.size = false;
                                    }

                                    int retHdd = goodsHddTable.Insert(goodsHdd);

                                    if (retHdd == 1)
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
                                        MessageBox.Show("商品のHDDデータの追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            goods.group_code = 7;
                            goods.power_consumption = 10;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsHdd.goods_code = goods.goods_code;
                                goodsHdd.capacity = capacity;
                                if (lstSize.SelectedIndex == 0)
                                {
                                    goodsHdd.size = true;
                                }
                                else
                                {
                                    goodsHdd.size = false;
                                }

                                int retHdd = goodsHddTable.Update(goodsHdd);

                                if (retHdd == 1)
                                {
                                    if (changedPic)
                                    {
                                        File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                    }

                                    MessageBox.Show("商品情報を更新しました", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    processed = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("商品のHDDデータの更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("容量と価格の入力欄には半角数字を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("未入力の項目があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmGoodsHdd_FormClosing(object sender, FormClosingEventArgs e)
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