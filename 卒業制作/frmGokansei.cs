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

        private void btnPowerUnit_Click(object sender, EventArgs e)
        {
            frmGokanseiPowerUnit frmGokanseiPowerUnit = new frmGokanseiPowerUnit();
            frmGokanseiPowerUnit.ShowDialog();
        }

        private void btnFan_Click(object sender, EventArgs e)
        {
            frmGokanseiFan frmGokanseiFan = new frmGokanseiFan();
            frmGokanseiFan.ShowDialog();
        }

        private void btnOs_Click(object sender, EventArgs e)
        {
            frmGokanseiOs frmGokanseiOs = new frmGokanseiOs();
            frmGokanseiOs.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("設定できる項目はありません", "項目なし", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("それぞれの互換性管理にて設定してください\n" +
                "対応マザーボード→互換性管理：マザーボード\n" + "ケースファン対応サイズ→互換性管理：ケースファン\n" + "対応電源ユニット→互換性管理：電源ユニット", "項目なし", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
