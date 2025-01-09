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
using ClassLibrary;

namespace 卒業制作
{
    public partial class frmGoodsSsd : Form
    {
        public Goods goods;
        public GoodsSsd goodsSsd;

        public bool changedPic = false;
        public string format = null;

        public frmGoodsSsd()
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

        private void frmGoodsSsd_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            SsdStandardTable ssdStandardTable = new SsdStandardTable();
            SsdConnectionTable ssdConnectionTable = new SsdConnectionTable();
            SsdTypeTable ssdTypeTable = new SsdTypeTable();

            DataTable table = makerTable.GetMaker();
            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = ssdStandardTable.GetSsdStandard();
            foreach (DataRow dr in table.Rows)
            {
                lstStandards.Items.Add(dr[1].ToString());
            }

            table = ssdConnectionTable.GetSsdConnection();
            foreach (DataRow dr in table.Rows)
            {
                lstConnection.Items.Add(dr[1].ToString());
            }

            table = ssdTypeTable.GetSsdType();
            foreach (DataRow dr in table.Rows)
            {
                lstType.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();

                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                lstStandards.SelectedIndex = lstStandards.FindStringExact(ssdStandardTable.GetSsdStandardNameById(goodsSsd.standard_id));
                lstConnection.SelectedIndex = lstConnection.FindStringExact(ssdConnectionTable.GetSsdConnectionNameById(goodsSsd.connection_id));
                lstType.SelectedIndex = lstType.FindStringExact(ssdTypeTable.GetSsdTypeNameById(goodsSsd.type_id));
                txtCapacity.Text = goodsSsd.capacity.ToString();

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
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstStandards.SelectedIndex != -1 && lstConnection.SelectedIndex != -1 && lstType.SelectedIndex != -1)
            {
                bool retCapacity = int.TryParse(txtCapacity.Text, out int capacity);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);
                if (retCapacity && retPrice)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    MakerTable makerTable = new MakerTable();
                    SsdStandardTable ssdStandardTable = new SsdStandardTable();
                    SsdConnectionTable ssdConnectionTable = new SsdConnectionTable();
                    SsdTypeTable ssdTypeTable = new SsdTypeTable();
                    GoodsSsdTable goodsSsdTable = new GoodsSsdTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 6;
                            goods.power_consumption = 10;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    GoodsSsd goodsSsd = new GoodsSsd();
                                    goodsSsd.goods_code = goods.goods_code;
                                    goodsSsd.standard_id = ssdStandardTable.GetSsdStandardIdByName(lstStandards.Text);
                                    goodsSsd.connection_id = ssdConnectionTable.GetSsdConnectionIdByName(lstConnection.Text);
                                    goodsSsd.type_id = ssdTypeTable.GetSsdTypeIdByName(lstType.Text);
                                    goodsSsd.capacity = capacity;

                                    int retSsd = goodsSsdTable.Insert(goodsSsd);

                                    if (retSsd == 1)
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
                                        MessageBox.Show("商品のSSDデータの追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            goods.group_code = 6;
                            goods.power_consumption = 10;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsSsd.goods_code = goods.goods_code;
                                goodsSsd.standard_id = ssdStandardTable.GetSsdStandardIdByName(lstStandards.Text);
                                goodsSsd.connection_id = ssdConnectionTable.GetSsdConnectionIdByName(lstConnection.Text);
                                goodsSsd.type_id = ssdTypeTable.GetSsdTypeIdByName(lstType.Text);
                                goodsSsd.capacity = capacity;

                                int retSsd = goodsSsdTable.Update(goodsSsd);

                                if (retSsd == 1)
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
                                    MessageBox.Show("商品のSSDデータの更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
