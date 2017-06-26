using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ezfx.Csv.Tester
{
    public partial class ReadDataTableForm : Form
    {
        public ReadDataTableForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                pathTextBox.Text = ofd.FileName;
                DataTable dt = Ezfx.Csv.CsvContext.GetDataTable(pathTextBox.Text, "综合信息查询_交易所回购$");

                mainDataGridView.DataSource = dt;
            }
        }
    }
}
