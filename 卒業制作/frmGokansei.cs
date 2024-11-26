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
    public partial class frmGokansei : Form
    {
        public frmGokansei()
        {
            InitializeComponent();
        }

        private void btnCpu_Click(object sender, EventArgs e)
        {
            frmGokanseiCpu frmGokanseiCpu = new frmGokanseiCpu();
            frmGokanseiCpu.ShowDialog();        
        }

        private void btnCooler_Click(object sender, EventArgs e)
        {
            frmGokanseiCooler frmGokianseiCooler = new frmGokanseiCooler();
            frmGokianseiCooler.ShowDialog();
        }


        private void btnMemory_Click(object sender, EventArgs e)
        {
            frmGokanseiMemory frmGokanseiMemory = new frmGokanseiMemory();
            frmGokanseiMemory.ShowDialog();
            }

        private void btnMotherboard_Click(object sender, EventArgs e)
        {
            frmGokanseiMotherboard frmGokanseiMotherboard = new frmGokanseiMotherboard();
            frmGokanseiMotherboard.ShowDialog();
        }

        private void btnGpu_Click(object sender, EventArgs e)
        {
            frmGokanseiGpu frmGokanseiGpu = new frmGokanseiGpu();
            frmGokanseiGpu.ShowDialog();
        }

        private void btnSsd_Click(object sender, EventArgs e)
        {
            frmGokanseiSsd frmGokanseiSsd = new frmGokanseiSsd();
            frmGokanseiSsd.ShowDialog();
        }
    }
}
