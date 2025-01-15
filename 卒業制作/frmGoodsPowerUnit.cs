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
    public partial class frmGoodsPowerUnit : Form
    {
        public Goods goods;
        public GoodsPower goodsPower;

        public bool changedPic = false;
        public string format = null;

        public frmGoodsPowerUnit()
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

        private void frmGoodsPowerUnit_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            PowerSizeTable powerSizeTable = new PowerSizeTable();

            DataTable table = makerTable.GetMaker();

            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = powerSizeTable.GetPowerSize();

            foreach (DataRow dr in table.Rows)
            {
                lstSizeStandard.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();

                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                lstSizeStandard.SelectedIndex = lstSizeStandard.FindStringExact(powerSizeTable.GetPowerSizeNameById(goodsPower.size_id));
                txtPowerCapacity.Text = goodsPower.power_capacity.ToString();
                lstPlus.SelectedIndex = lstPlus.FindStringExact(goodsPower.plus);
                txtPciconnector.Text = goodsPower.pciConnector.ToString();
                txtSataConnector.Text = goodsPower.sataConnector.ToString();

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstSizeStandard.SelectedIndex != -1 && lstPlus.SelectedIndex != -1)
            {
                bool retCapacity = int.TryParse(txtPowerCapacity.Text, out int power_capacity);
                bool retPci = int.TryParse(txtPciconnector.Text, out int pciConnector);
                bool retSata = int.TryParse(txtSataConnector.Text, out int sataConnector);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retCapacity && retPci && retSata && retPrice)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    MakerTable makerTable = new MakerTable();
                    PowerSizeTable powerSizeTable = new PowerSizeTable();
                    GoodsPowerTable goodsPowerTable = new GoodsPowerTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 8;
                            goods.power_consumption = 0;


                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    GoodsPower goodsPower = new GoodsPower();
                                    goodsPower.goods_code = goods.goods_code;
                                    goodsPower.size_id = powerSizeTable.GetPowerSizeIdByName(lstSizeStandard.Text);
                                    goodsPower.power_capacity = power_capacity;
                                    goodsPower.plus = lstPlus.Text;
                                    goodsPower.pciConnector = pciConnector;
                                    goodsPower.sataConnector = sataConnector;

                                    int retPower = goodsPowerTable.Insert(goodsPower);

                                    if (retPower == 1)
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
                                        MessageBox.Show("商品の画像パスのデータ追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            goods.group_code = 8;
                            goods.power_consumption = 0;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsPower.size_id = powerSizeTable.GetPowerSizeIdByName(lstSizeStandard.Text);
                                goodsPower.power_capacity = power_capacity;
                                goodsPower.plus = lstPlus.Text;
                                goodsPower.pciConnector = pciConnector;
                                goodsPower.sataConnector = sataConnector;

                                int retPower = goodsPowerTable.Update(goodsPower);

                                if (retPower == 1)
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
                                    MessageBox.Show("商品の電源ユニットのデータの更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品の更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("同じ商品名の商品が既に追加されているため、変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("電源容量・電源コネクタ数・価格の入力欄には半角数字を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("未入力の項目があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
