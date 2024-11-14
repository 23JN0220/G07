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
            //コミットテスト
            frmMember frmMember = new frmMember();
            frmMember.ShowDialog();

        }
    }
}
