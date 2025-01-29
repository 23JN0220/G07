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
    public partial class frmGoodsCase : Form
    {
        public Goods goods;
        public GoodsCase goodsCase;

        public List<int> idList = new List<int>();
        public bool changedPic = false;
        public string format = null;

        private bool processed = false;

        public frmGoodsCase()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnMotherboard_Click(object sender, EventArgs e)
        {
            frmGoodsGokanseiMotherBoard frmGoodsGokanseiMotherBoard = new frmGoodsGokanseiMotherBoard();

            if (idList.Count > 0)
            {
                frmGoodsGokanseiMotherBoard.idList = idList;
            }

            frmGoodsGokanseiMotherBoard.ShowDialog();
            idList = frmGoodsGokanseiMotherBoard.idList;
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

        private void frmGoodsCase_Load(object sender, EventArgs e)
        {
            MakerTable makerTable = new MakerTable();
            CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();
            PowerSizeTable powerSizeTable = new PowerSizeTable();
            MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
            CaseMotherboardSizeTable caseMotherboardSizeTable = new CaseMotherboardSizeTable();

            DataTable table = makerTable.GetMaker();
            foreach (DataRow dr in table.Rows)
            {
                lstMaker.Items.Add(dr[1].ToString());
            }

            table = caseFanSizeTable.GetCaseFanSize();
            foreach (DataRow dr in table.Rows)
            {
                lstCaseFan.Items.Add(dr[1].ToString());
            }

            table = powerSizeTable.GetPowerSize();
            foreach (DataRow dr in table.Rows)
            {
                lstUnit.Items.Add(dr[1].ToString());
            }

            if (goods != null)
            {
                txtName.Text = goods.goods_name;
                txtPrice.Text = goods.price.ToString();
                lstMaker.SelectedIndex = lstMaker.FindStringExact(makerTable.GetMakerNameById(goods.maker_id));
                lstCaseFan.SelectedIndex = lstCaseFan.FindStringExact(caseFanSizeTable.GetCaseFanSizeNameById(goodsCase.fan_size_id));
                lstUnit.SelectedIndex = lstUnit.FindStringExact(powerSizeTable.GetPowerSizeNameById(goodsCase.power_size_id));

                txtBayNumber.Text = goodsCase.bay_number.ToString();
                txt3ShadowBayNumber.Text = goodsCase.shadowbay3_number.ToString();
                txt2ShadowBayNumber.Text = goodsCase.shadowbay2_number.ToString();
                txtMaxGpu.Text = goodsCase.gpu_size.ToString();
                txtCaseNumber.Text = goodsCase.fan_number.ToString();
                txtSlotNumber.Text = goodsCase.slot_number.ToString();
                txtCooler.Text = goodsCase.cooler_size.ToString();
                txtWidth.Text = goodsCase.width.ToString();
                txtDepth.Text = goodsCase.depth.ToString();
                txtHeight.Text = goodsCase.height.ToString();
                txtColor.Text = goodsCase.color;

                idList = caseMotherboardSizeTable.GetCaseMotherboardSizeById(goodsCase.goods_code);

                if (goodsCase.lowpro)
                {
                    chkLowPro.Checked = true;
                }
                else
                {
                    chkLowPro.Checked = false;
                }
                if (goodsCase.water_cooling)
                {
                    chkWaterCooler.Checked = true;
                }
                else
                {
                    chkWaterCooler.Checked = false;
                }

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && lstMaker.SelectedIndex != -1 && lstCaseFan.SelectedIndex != -1 && lstUnit.SelectedIndex != -1 && txtColor.Text != "")
            {
                bool retBay = int.TryParse(txtBayNumber.Text, out int bay);
                bool ret3ShadowBay = int.TryParse(txt3ShadowBayNumber.Text, out int shadowbay3);
                bool ret2ShadowBay = int.TryParse(txt2ShadowBayNumber.Text, out int shadowbay2);
                bool retMaxGpu = int.TryParse(txtMaxGpu.Text, out int gpu);
                bool retCaseFanNumber = int.TryParse(txtCaseNumber.Text, out int caseFanNumber);
                bool retSlotNumber = int.TryParse(txtSlotNumber.Text, out int slotNumber);
                bool retCooler = int.TryParse(txtCooler.Text, out int cooler_size);
                bool retWidth = int.TryParse(txtWidth.Text, out int width);
                bool retDepth = int.TryParse(txtDepth.Text, out int depth);
                bool retHeight = int.TryParse(txtHeight.Text, out int height);
                bool retPrice = int.TryParse(txtPrice.Text, out int price);

                if (retBay && ret3ShadowBay && ret2ShadowBay && retMaxGpu && retCaseFanNumber && retSlotNumber && retWidth && retDepth && retHeight && retPrice)
                {
                    GoodsTable goodsTable = new GoodsTable();
                    GoodsCaseTable goodsCaseTable = new GoodsCaseTable();
                    MakerTable makerTable = new MakerTable();
                    CaseFanSizeTable caseFanSizeTable = new CaseFanSizeTable();
                    PowerSizeTable powerSizeTable = new PowerSizeTable();
                    MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
                    CaseMotherboardSizeTable caseMotherboardSizeTable = new CaseMotherboardSizeTable();

                    if (goods == null)
                    {
                        if (!goodsTable.ExistGoodsName(txtName.Text))
                        {
                            goods = new Goods();

                            goods.goods_name = txtName.Text;
                            goods.maker_id = makerTable.GetMakerIdByName(lstMaker.Text);
                            goods.price = price;
                            goods.group_code = 9;
                            goods.power_consumption = 0;

                            int retGoods = goodsTable.Insert(goods);

                            if (retGoods == 1)
                            {
                                goods.goods_code = goodsTable.GetGoodsCodeByName(goods.goods_name);
                                goods.goods_image = goods.goods_code + ".jpg";

                                int retPic = goodsTable.UpdatePicture(goods);

                                if (retPic == 1)
                                {
                                    goodsCase = new GoodsCase();
                                    goodsCase.goods_code = goods.goods_code;
                                    goodsCase.bay_number = bay;
                                    goodsCase.shadowbay3_number = shadowbay3;
                                    goodsCase.shadowbay2_number = shadowbay2;
                                    goodsCase.gpu_size = gpu;
                                    goodsCase.fan_size_id = caseFanSizeTable.GetCaseFanSizeIdByName(lstCaseFan.Text);
                                    goodsCase.fan_number = caseFanNumber;
                                    goodsCase.slot_number = slotNumber;
                                    goodsCase.power_size_id = powerSizeTable.GetPowerSizeIdByName(lstUnit.Text);
                                    goodsCase.cooler_size = cooler_size;
                                    goodsCase.width = width;
                                    goodsCase.depth = depth;
                                    goodsCase.height = height;
                                    goodsCase.color = txtColor.Text;
                                    if (chkLowPro.Checked)
                                    {
                                        goodsCase.lowpro = true;
                                    }
                                    else
                                    {
                                        goodsCase.lowpro = false;
                                    }
                                    if (chkWaterCooler.Checked)
                                    {
                                        goodsCase.water_cooling = true;
                                    }
                                    else
                                    {
                                        goodsCase.water_cooling = false;
                                    }

                                    int retCase = goodsCaseTable.Insert(goodsCase);

                                    if (retCase == 1)
                                    {
                                        bool retMotherboard = true;

                                        for (int i = 0; i < idList.Count; i++)
                                        {
                                            int MotherboardSizeId = idList[i];
                                            int ret = caseMotherboardSizeTable.Insert(goodsCase.goods_code, idList[i]);

                                            if (ret != 1)
                                            {
                                                retMotherboard = false;
                                            }
                                        }

                                        if (retMotherboard)
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
                                            MessageBox.Show("Cマザーボードサイズ対応データの追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("商品のケースのデータの追加に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            goods.group_code = 9;
                            goods.power_consumption = 0;

                            int retGoods = goodsTable.Update(goods);

                            if (retGoods == 1)
                            {
                                goodsCase = new GoodsCase();
                                goodsCase.goods_code = goods.goods_code;
                                goodsCase.bay_number = bay;
                                goodsCase.shadowbay3_number = shadowbay3;
                                goodsCase.shadowbay2_number = shadowbay2;
                                goodsCase.gpu_size = gpu;
                                goodsCase.fan_size_id = caseFanSizeTable.GetCaseFanSizeIdByName(lstCaseFan.Text);
                                goodsCase.fan_number = caseFanNumber;
                                goodsCase.slot_number = slotNumber;
                                goodsCase.power_size_id = powerSizeTable.GetPowerSizeIdByName(lstUnit.Text);
                                goodsCase.cooler_size = cooler_size;
                                goodsCase.width = width;
                                goodsCase.depth = depth;
                                goodsCase.height = height;
                                goodsCase.color = txtColor.Text;
                                if (chkLowPro.Checked)
                                {
                                    goodsCase.lowpro = true;
                                }
                                else
                                {
                                    goodsCase.lowpro = false;
                                }
                                if (chkWaterCooler.Checked)
                                {
                                    goodsCase.water_cooling = true;
                                }
                                else
                                {
                                    goodsCase.water_cooling = false;
                                }

                                int retCase = goodsCaseTable.Update(goodsCase);

                                if (retCase == 1)
                                {
                                    int delData = caseMotherboardSizeTable.Delete(goodsCase.goods_code);

                                    bool retMotherboard = true;

                                    for (int i = 0; i < idList.Count; i++)
                                    {
                                        int MotherboardSizeId = idList[i];
                                        int ret = caseMotherboardSizeTable.Insert(goodsCase.goods_code, idList[i]);

                                        if (ret != 1)
                                        {
                                            retMotherboard = false;
                                        }
                                    }

                                    if (retMotherboard)
                                    {
                                        if (changedPic)
                                        {
                                            File.Copy(pictureBox1.ImageLocation, "\\\\10.32.97.1\\Web\\SOTSU\\2024\\23JN02\\G07\\images\\goods\\" + goods.goods_code + format, true);
                                        }


                                        MessageBox.Show("商品を更新しました。", "追加完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        processed = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("マザーボードサイズ対応データの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("商品のケースのデータの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("名前・カラー以外のテキストボックスには数値を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("未入力の項目があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmGoodsCase_FormClosing(object sender, FormClosingEventArgs e)
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
