using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Ezfx.Csv.Entities;

namespace Ezfx.Csv.Tester
{
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
        }

        private void cvsPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv | Access Files(*.mdb;*.accdb) | *.mdb;*.accdb | Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                cvsPathTextBox.Text = ofd.FileName;
            }
        }

        private void byOrderButton_Click(object sender, EventArgs e)
        {
            csvDataGridView.DataSource = CsvContext.ReadFile<CarCsv>(cvsPathTextBox.Text, CsvConfig.Default);
        }

        private void customButton_Click(object sender, EventArgs e)
        {
            CsvConfig config = new CsvConfig();
            config.HasHeader = true;
            config.MappingType = CsvMappingType.Order;
            //config.Mappings = new CsvMappings();
            //config.Mappings.Add(new CsvMapping { Order = 1, Title = "Year" });
            //config.Mappings.Add(new CsvMapping { Order = 3, Title = "Model" });
            csvDataGridView.DataSource = CsvContext.ReadFile<CarCsv>(cvsPathTextBox.Text, config);
        }

        private void byTitleButton_Click(object sender, EventArgs e)
        {
            CsvConfig config = new CsvConfig();
            config.HasHeader = true;
            config.MappingType = CsvMappingType.Title;
            //config.AliasMappings.Add(new AliasMapping { Title = "Model", Alias = "M" });
            if (System.IO.Path.GetExtension(cvsPathTextBox.Text).ToUpper() == ".CSV")
            {
                csvDataGridView.DataSource = CsvContext.ReadFile<CarCsv>(cvsPathTextBox.Text, config);
            }
            else
            {
                csvDataGridView.DataSource = CsvContext.ReadFile<CarCsv>(cvsPathTextBox.Text,tableTextBox.Text, config);
            }
        }
    }
}
