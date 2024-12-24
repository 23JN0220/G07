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
    public partial class frmGoodsOs : Form
    {
        public Goods goods;
        public GoodsOs goodsOs;

        public bool changedPic = false;
        public string format = null;


        public frmGoodsOs()
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

        private void frmGoodsOs_Load(object sender, EventArgs e)
        {
            OsVersionTable osVersionTable = new OsVersionTable();

            DataTable table = osVersionTable.GetOsVersion();
            foreach (DataRow dr in table.Rows)
            {
                lstVersion.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();

                lstVersion.SelectedIndex = lstVersion.FindStringExact(osVersionTable.GetOsVersionNameById(goodsOs.version_id));

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
            if (txtName.Text != "" && lstVersion.SelectedIndex != -1 && txtPrice.Text != "")
            {


                bool exist_Microsoft = true;
                MakerTable makerTable = new MakerTable();
                GoodsTable goodsTable = new GoodsTable();
                OsVersionTable osVersionTable = new OsVersionTable();
                GoodsOsTable GoodsOsTable = new GoodsOsTable();

                //if (!goodsTable.ExistGoodsName(txtName.Text) || goods != null)
                //{
                if (goods == null)
                {
                    if (!goodsTable.ExistGoodsName(txtName.Text))
                    {
                        if (makerTable.GetMakerIdByName("Microsoft") == 0)
                        {
                            Maker maker = new Maker();
                            maker.maker_name = "Microsoft";
                            makerTable.Insert(maker);

                            exist_Microsoft = false;
                        }

                        goods = new Goods();

                        goods.goods_name = txtName.Text;
                        goods.maker_id = makerTable.GetMakerMicrosoftId();
                        goods.price = int.Parse(txtPrice.Text);
                        goods.group_code = 11;
                        goods.power_consumption = 0;

                        int retGoods = goodsTable.Insert(goods);

                        if (retGoods == 1)
                        {
                            goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                            goods.goods_image = goods.goods_code + ".jpg";
                            int retPic = goodsTable.UpdatePicture(goods);

                            if (retPic == 1)
                            {
                                goodsOs = new GoodsOs();

                                goodsOs.goods_code = goods.goods_code;
                                goodsOs.version_id = osVersionTable.GetOsVersionIdByName(lstVersion.SelectedItem.ToString());

                                int retGoodsOs = GoodsOsTable.Insert(goodsOs);

                                if (retGoodsOs == 1 && exist_Microsoft)
                                {
                                    if (changedPic)
                                    {
                                        File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                    }

                                    MessageBox.Show("商品を追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (retGoodsOs == 1 && !exist_Microsoft)
                                {
                                    if (changedPic)
                                    {
                                        File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                    }

                                    MessageBox.Show("商品を追加しました。\nメーカーのデータベースにMicrosoftが存在しなかったため、メーカーのデータベースにMicrosoftを追加しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("商品のOSデータの追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品の画像の追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("商品の追加に失敗しました\n同じ商品名の商品が既に追加されている場合があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        goods.price = int.Parse(txtPrice.Text);

                        int retGoods = goodsTable.Update(goods);

                        if (retGoods == 1)
                        {
                            goodsOs.goods_code = goods.goods_code;
                            goodsOs.version_id = new OsVersionTable().GetOsVersionIdByName(lstVersion.SelectedItem.ToString());

                            int retGoodsOs = GoodsOsTable.Update(goodsOs);

                            if (retGoodsOs == 1)
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
                                MessageBox.Show("商品のOSデータの更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("商品データの更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("未入力の項目があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
