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
    public partial class frmGoodsAdd : Form
    {
        public frmGoodsAdd()
        {
            InitializeComponent();
        }

        private void btnCpu_Click(object sender, EventArgs e)
        {
            frmGoodsCpu frmGoodsCpu = new frmGoodsCpu();
            frmGoodsCpu.ShowDialog();
        }

        private void btnCooler_Click(object sender, EventArgs e)
        {
            frmGoodsCooler frmGoodsCooler = new frmGoodsCooler();
            frmGoodsCooler.ShowDialog();
        }

        private void btnMotherboard_Click(object sender, EventArgs e)
        {
            frmGoodsMotherboard frmGoodsMotherboard = new frmGoodsMotherboard();
            frmGoodsMotherboard.ShowDialog();
        }

        private void btnMemory_Click(object sender, EventArgs e)
        {
            frmGoodsMemory frmGoodsMemory = new frmGoodsMemory();
            frmGoodsMemory.ShowDialog();
        }

        private void btnGpu_Click(object sender, EventArgs e)
        {
            frmGoodsGpu frmGoodsGpu = new frmGoodsGpu();
            frmGoodsGpu.ShowDialog();
        }

        private void btnSsd_Click(object sender, EventArgs e)
        {
            frmGoodsSsd frmGoodsSsd = new frmGoodsSsd();
            frmGoodsSsd.ShowDialog();
        }

        private void btnHdd_Click(object sender, EventArgs e)
        {
            frmGoodsHdd frmGoodsHdd = new frmGoodsHdd();
            frmGoodsHdd.ShowDialog();
        }

        private void btnPowerUnit_Click(object sender, EventArgs e)
        {
            frmGoodsPowerUnit frmGoodsPowerUnit = new frmGoodsPowerUnit();
            frmGoodsPowerUnit.ShowDialog();
        }

        private void btnCase_Click(object sender, EventArgs e)
        {
            frmGoodsCase frmGoodsCase = new frmGoodsCase();
            frmGoodsCase.ShowDialog();
        }

        private void btnFan_Click(object sender, EventArgs e)
        {
            frmGoodsFan frmGoodsFan = new frmGoodsFan();
            frmGoodsFan.ShowDialog();
        }
    }
}
