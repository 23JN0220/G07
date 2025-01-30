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
    public partial class frmGoodsMemory : Form
    {
        public Goods goods;
        public GoodsMemory goodsMemory;
        public bool changedPic = false;
        public string format = null;

        private bool processed = false;

        public frmGoodsMemory()
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
            MessageBox.Show("画像は320×320のJPG画像を使用してください", "画像サイズについて", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult ret = ofdPicture.ShowDialog();

            if (ret == DialogResult.OK)
            {
                string fileName = ofdPicture.FileName;
                pictureBox1.ImageLocation = fileName;
                format = System.IO.Path.GetExtension(fileName);

                changedPic = true;

            }
        }

        private void frmGoodsMemory_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
            MemoryModuleTable memoryModuleTable = new MemoryModuleTable();

            DataTable table = makerTable.GetMaker();
            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = memoryStandardTable.GetMemoryStandard();
            foreach (DataRow dr in table.Rows)
            {
                lstMemoryStandards.Items.Add(dr[1].ToString());
            }

            table = memoryModuleTable.GetMemoryModule();
            foreach (DataRow dr in table.Rows)
            {
                lstModule.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();
                lstMaker.Text = makerTable.GetMakerNameById(goods.maker_id);
                lstMemoryStandards.Text = memoryStandardTable.GetMemoryStandardNameById(goodsMemory.standard_id);
                lstModule.Text = memoryModuleTable.GetMemoryModuleNameById(goodsMemory.module_id);
                txtCapacity.Text = goodsMemory.capacity.ToString();
                txtNumber.Text = goodsMemory.number.ToString();

                if (goodsMemory.ecc)
                {
                    chkEcc.Checked = true;
                }
                else
                {
                    chkEcc.Checked = false;
                }

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstMemoryStandards.SelectedIndex != -1 && lstModule.SelectedIndex != -1)
            {
                bool retCapacity = int.TryParse(txtCapacity.Text, out int capacity);
                bool retNumber = int.TryParse(txtNumber.Text, out int number);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retCapacity && retNumber && retPrice)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    GoodsMemoryTable goodsMemoryTable = new GoodsMemoryTable();
                    MakerTable makerTable = new MakerTable();
                    MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
                    MemoryModuleTable memoryModuleTable = new MemoryModuleTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();
                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 4;
                            goods.power_consumption = 8;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    goodsMemory = new GoodsMemory();
                                    goodsMemory.goods_code = goods.goods_code;
                                    goodsMemory.standard_id = memoryStandardTable.GetMemoryStandardIdByName(lstMemoryStandards.Text);
                                    goodsMemory.module_id = memoryModuleTable.GetMemoryModuleIdByName(lstModule.Text);
                                    goodsMemory.capacity = capacity;
                                    goodsMemory.number = number;
                                    if (chkEcc.Checked)
                                    {
                                        goodsMemory.ecc = true;
                                    }
                                    else
                                    {
                                        goodsMemory.ecc = false;
                                    }

                                    int retMemory = goodsMemoryTable.Insert(goodsMemory);

                                    if (retMemory == 1)
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
                                        MessageBox.Show("商品のメモリ情報の追加に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            goods.group_code = 4;
                            goods.power_consumption = 8;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsMemory.goods_code = goods.goods_code;
                                goodsMemory.standard_id = memoryStandardTable.GetMemoryStandardIdByName(lstMemoryStandards.Text);
                                goodsMemory.module_id = memoryModuleTable.GetMemoryModuleIdByName(lstModule.Text);
                                goodsMemory.capacity = capacity;
                                goodsMemory.number = number;
                                if (chkEcc.Checked)
                                {
                                    goodsMemory.ecc = true;
                                }
                                else
                                {
                                    goodsMemory.ecc = false;
                                }

                                int retMemory = goodsMemoryTable.Update(goodsMemory);

                                if (retMemory == 1)
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
                                    MessageBox.Show("商品のメモリ情報の更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("入力された形式に誤りがあるか、未入力の項目があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("未入力の項目があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmGoodsMemory_FormClosing(object sender, FormClosingEventArgs e)
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
