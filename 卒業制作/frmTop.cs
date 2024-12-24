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
    public partial class frmTop : Form
    {
        public frmTop()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            frmMember frmMember = new frmMember();
            frmMember.ShowDialog();

        }

        private void btnGoods_Click(object sender, EventArgs e)
        {
            frmGoods frmGoods = new frmGoods();
            frmGoods.ShowDialog();
        }

        private void btnCompatibility_Click(object sender, EventArgs e)
        {
            frmGokansei frmGokansei = new frmGokansei();
            frmGokansei.ShowDialog();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            frmReview frmReview = new frmReview();
            frmReview.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail();
            frmOrderDetail.ShowDialog();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmPayment payment = new frmPayment();
            payment.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaker_Click(object sender, EventArgs e)
        {
            frmMaker frmMeker = new frmMaker();
            frmMeker.ShowDialog();
        }
    }
}
