using System;
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
    public partial class frmGoodsMemory : Form
    {
        public Goods goods;
        public GoodsMemory goodsMemory;
        public bool changedPic = false;
        public string format = null;

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
                lstMemoryStandards.Text = memoryStandardTable.GetMemoryStandardById(goodsMemory.standard_id);
                lstModule.Text = memoryModuleTable.GetMemoryModuleById(goodsMemory.module_id);
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
    }
}
