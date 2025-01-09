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
    public partial class frmGoodsHdd : Form
    {
        public Goods goods;
        public GoodsHdd goodsHdd;

        public bool changedPic = false;
        public string format = null;
        public frmGoodsHdd()
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
                //False = 3.5インチ, True = 2.5インチ
                if (goodsHdd.size)
                {
                    lstSize.SelectedIndex = 0;
                }
                else
                {
                    lstSize.SelectedIndex = 1;
                }

                pictureBox1.ImageLocation = "http://10.32.97.1/SOTSU/2024/23JN02/G07/images/goods/" + goods.goods_image;
            }
        }
    }
}
