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
            frmGokianseiCooler frmGokianseiCooler = new frmGokianseiCooler();
            frmGokianseiCooler.ShowDialog();
        }
    }
}
