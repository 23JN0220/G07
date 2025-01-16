using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace 卒業制作
{
    public partial class frmGoodsGokanseiMotherBoard : Form
    {
        public List<int> idList = new List<int>();

        public frmGoodsGokanseiMotherBoard()
        {
            InitializeComponent();
        }

        private void frmGoodsGokanseiMotherBoard_Load(object sender, EventArgs e)
        {
            MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();
            DataTable dataTable = motherboardSizeTable.GetMotherboardSize();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];

                lstData.Items.Add(dr[1].ToString());

                if (idList.Contains(int.Parse(dr[0].ToString())))
                {
                    lstData.SetSelected(i, true);
                }
                else
                {
                    lstData.SetSelected(i, false);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("内容を保存せずに戻ります。\n本当に戻りますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            idList.Clear();
            MotherboardSizeTable motherboardSizeTable = new MotherboardSizeTable();

            foreach (string size_name in lstData.SelectedItems)
            {
                int size_id = motherboardSizeTable.GetMotherboardSizeIdByName(size_name);
                idList.Add(size_id);
            }

            this.Close();
        }
    }
}
