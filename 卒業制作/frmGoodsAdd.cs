﻿using System;
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
    }
}
