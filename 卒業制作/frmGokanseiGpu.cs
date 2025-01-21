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
    public partial class frmGokanseiGpu : Form
    {
        public frmGokanseiGpu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGokanseiGpu_Load(object sender, EventArgs e)
        {
            GpuSeriesTable gpuSeriesTable = new GpuSeriesTable();
            GpuInterfaceTable gpuInterfaceTable = new GpuInterfaceTable();
            GpuResolutionTable gpuResolutionTable = new GpuResolutionTable();

            DataTable dataTable = gpuSeriesTable.GetGpuSeries();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstSeries.Items.Add(dr[1].ToString());
            }
            dataTable = gpuInterfaceTable.GetGpuInterface();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstInterface.Items.Add(dr[1].ToString());
            }
            dataTable = gpuResolutionTable.GetGpuResolution();
            foreach (DataRow dr in dataTable.Rows)
            {
                lstRes.Items.Add(dr[1].ToString());
            }
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeries.Text = lstSeries.SelectedItem.ToString();
        }

        private void lstInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInterface.Text = lstInterface.SelectedItem.ToString();
        }

        private void lstRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRes.Text = lstRes.SelectedItem.ToString();
        }
    }
}
