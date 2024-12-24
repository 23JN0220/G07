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
    public partial class frmGoodsOs : Form
    {
        public Goods goods;
        public GoodsOs goodsOs;


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
    }
}
