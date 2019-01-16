using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ezfx.Csv.Tools.DocumentGenerator
{
    public partial class MainForm : Form
    {
        string[] tableNames;
        CsvColumn[] cols = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv|Access Files(*.mdb;*.accdb)|*.mdb;*.accdb|Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pathTextBox.Text = ofd.FileName;
                if (System.IO.Path.GetExtension(pathTextBox.Text).ToUpper(CultureInfo.InvariantCulture) == ".CSV")
                {
                    tableComboBox.Items.Clear();
                    //Display();
                }
                else
                {
                    tableNames = CsvContext.GetTableNames(pathTextBox.Text);
                    tableComboBox.Items.Clear();
                    foreach (string tableName in tableNames)
                    {
                        tableComboBox.Items.Add(tableName);
                    }
                    tableComboBox.SelectedIndex = 0;
                }
                Display();
            }
        }

        private void Display()
        {
            cols = CsvContext.GetColumnDefinition(pathTextBox.Text,",", (tableComboBox.SelectedValue ?? "").ToString());
            csvColumnBindingSource.DataSource = cols;
            
        }
    }
}
