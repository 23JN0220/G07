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
    public partial class frmGoodsGokanseiSocket : Form
    {
        public List<int> idList = new List<int>();

        public frmGoodsGokanseiSocket()
        {
            InitializeComponent();
        }

        private void frmGoodsGokanseiSocket_Load(object sender, EventArgs e)
        {
            CpuSocketTable cpuSocketTable = new CpuSocketTable();
            DataTable dataTable = cpuSocketTable.GetCPUSocket();

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

            foreach (string socket_name in lstData.SelectedItems)
            {
                CpuSocketTable cpuSocketTable = new CpuSocketTable();
                int socket_id = cpuSocketTable.GetCPUSocketIdByName(socket_name);

                idList.Add(socket_id);
            }

            this.Close();
        }
    }
}
