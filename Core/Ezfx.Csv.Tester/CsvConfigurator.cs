using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Ezfx.Csv.Tester
{
    public partial class CsvConfigurator : UserControl
    {
        private List<Type> cvsTypes = new List<Type>();
        private List<SystemCsvColumnAttribute> attrs = new List<SystemCsvColumnAttribute>();
        private Type currentType = null;
        private CsvConfig currentConfig = new CsvConfig();

        public CsvConfigurator()
        {
            InitializeComponent();
        }

        private void csvClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentType = (Type)csvClassComboBox.SelectedItem;
            attrs.Clear();
            foreach (PropertyInfo pi in currentType.GetProperties())
            {
                SystemCsvColumnAttribute attr = GetCsvFieldAttribute(pi);
                if (attr != null)
                {
                    attrs.Add(attr);
                }
            }
        }

        private static SystemCsvColumnAttribute GetCsvFieldAttribute(PropertyInfo pi)
        {
            object[] objs = pi.GetCustomAttributes(typeof(SystemCsvColumnAttribute), false);
            if (objs.Length != 1)
            {
                return null;
            }
            return (SystemCsvColumnAttribute)objs.First();
        }

        private void CsvConfigurator_Load(object sender, EventArgs e)
        {
            cvsTypes.Add(typeof(CarCsv));
            if (cvsTypes.Count > 0)
            {
                currentType = cvsTypes[0];
            }
            foreach (Type t in cvsTypes)
            {
                csvClassComboBox.Items.Add(t);
            }
        }

        private void systemRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = attrs;
        }

        private void titleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshColumns();
            //mainDataGridView.DataSource = currentConfig.Columns;
        }

        private void RefreshColumns()
        {
            currentConfig.Columns.Clear();
            foreach (SystemCsvColumnAttribute attr in attrs)
            {
                currentConfig.Columns.Add(new CsvColumn { Name = attr.Name, Alias = attr.Alias });
            }
        }

        private void orderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshMapping();
            //mainDataGridView.DataSource = currentConfig.Mappings;
        }


        private void mainDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in mainDataGridView.Columns)
            {
                if (col.HeaderText == "Title")
                {
                    col.ReadOnly = true;
                }

                if (col.HeaderText == "TypeId")
                {
                    col.Visible = false;
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files|*.csv";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                pathTextBox.Text = ofd.FileName;
                string firstLine = null;

                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    firstLine = sr.ReadLine();
                }
                string[] titles = CsvContext.GetFields(firstLine,",");
                RefreshColumns();
                for (int i = 0; i < titles.Length; i++)
                {
                    if (currentConfig.ContainsColumn(titles[i]))
                    {
                        currentConfig.Columns[i].Ordinal = i;
                    }
                }
                mainDataGridView.DataSource = currentConfig.Columns;
                this.Refresh();
            }
        }
    }
}
