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
    public partial class frmGoodsCpu : Form
    {
        public frmGoodsCpu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChipSetSelect_Click(object sender, EventArgs e)
        {
            frmGoodsGokanseiChipSet frmGoodsGokansei = new frmGoodsGokanseiChipSet();
            frmGoodsGokansei.ShowDialog();
        }
    }
}
