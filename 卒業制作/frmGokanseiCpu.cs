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
    public partial class frmGokanseiCpu : Form
    {
        public frmGokanseiCpu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmGokanseiCpu_Load(object sender, EventArgs e)
        {
           ChipSetSeriesTable chipSetSeriesTable = new ChipSetSeriesTable();
            CpuGenerationTable generationTable = new CpuGenerationTable();
            CpuSocketTable socketTable = new CpuSocketTable();
            CpuSeriesTable seriesTable = new CpuSeriesTable();


            DataTable dataTable = chipSetSeriesTable.GetChipsetSeries();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstChipset.Items.Add(dr[1].ToString());
            }

            dataTable = generationTable.GetCPUGeneration();
            foreach (DataRow dr in dataTable.Rows)
            {
               lstGen.Items.Add(dr[1].ToString());
            }

            dataTable = socketTable.GetCPUSocket();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSocket.Items.Add(dr[1].ToString());
            }
            dataTable = seriesTable.GetCpuSeries();
            foreach (DataRow dr in dataTable.Rows)
            { 
            lstSeries.Items.Add(dr[1].ToString());
            }
        }
    }
}
