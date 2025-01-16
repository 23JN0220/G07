using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public frmGoodsCase()
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

        
    }
}
