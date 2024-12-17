using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace 卒業制作
{
    public partial class frmGoodsGokanseiChipSet : Form
    {

        public List<int> idList = new List<int>();


        public frmGoodsGokanseiChipSet()
        {
            InitializeComponent();
        }

        
        private void frmGoodsGokanseiChipSet_Load(object sender, EventArgs e)
        {
            ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();

            DataTable dataTable = chipSetSeriesTable.GetChipsetSeries();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];

                lstData.Items.Add(dr[1].ToString());

                if (idList.Contains(int.Parse(dr[0].ToString()))) {
                    //MessageBox.Show(dr[0].ToString());
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

            foreach (string series_name in lstData.SelectedItems)
            {
                //MessageBox.Show(series_name);

                ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();
                int series_id = chipSetSeriesTable.GetChipSetIdByName(series_name);

                idList.Add(series_id);
            }

            this.Close();
        }
    }
}
