using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 卒業制作
{
    public partial class frmMakerAdd : Form
    {
        public Maker maker;

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
          
            bool exist = makerTable.IsExistMaker(txtMaker_name.Text);
            if (!exist)
            {
            if (txtMaker_id.Text != "")
            {
                int maker_id = int.Parse(txtMaker_id.Text);

                int ret = makerTable.Update(maker_id,txtMaker_name.Text);
                if (ret == 1)
                {
                    MessageBox.Show("更新が完了しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新できませんでした", "更新エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
            else {
                    int ret = makerTable.Insert(maker);
                    if (ret == 1)
                    {
                        MessageBox.Show("登録が完了しました。", "登録完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登録できませんでした", "登録エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } }
            else
                {
                    MessageBox.Show("このメーカーはすでに存在しています。", "追加エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


        }

        private void frmMakerAdd_Load(object sender, EventArgs e)
        {
            if (maker != null)
            {
                txtMaker_id.Text = maker.maker_id.ToString();
                txtMaker_name.Text = maker.maker_name.ToString();

                MakerTable makerTable = new MakerTable();

               
              
            }
        }
    }
}
