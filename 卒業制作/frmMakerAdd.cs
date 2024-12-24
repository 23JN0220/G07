using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 卒業制作
{
    public partial class frmMakerAdd : Form
    {
        public frmMakerAdd()
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            Maker maker = new Maker();
            maker.maker_name = txtMaker_name.Text;

            MakerTable makerTable = new MakerTable();

             int ret = makerTable.Insert(maker);
            if (ret == 1)
            {
                MessageBox.Show("登録が完了しました。", "登録完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("登録できませんでした", "登録エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
