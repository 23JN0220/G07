using ClassLibrary;
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
    public partial class frmGokanseiMemory : Form
    {
        public frmGokanseiMemory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiMemory_Load(object sender, EventArgs e)
        {
            MemoryStandardTable memoryStandardTable = new MemoryStandardTable();
            MemoryModuleTable memoryModuleTable = new MemoryModuleTable();

            DataTable dataTable = memoryStandardTable.GetMemoryStandard();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstMemoryStandard.Items.Add(dr[1].ToString());
            }

            dataTable = memoryModuleTable.GetMemoryModule();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstModule.Items.Add(dr[1].ToString());
            }
        }

        private void lstMemoryStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMemoryStandard.Text = lstMemoryStandard.SelectedItem.ToString();
        }

        private void lstModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModule.Text = lstModule.SelectedItem.ToString(); 
        }
    }
}
