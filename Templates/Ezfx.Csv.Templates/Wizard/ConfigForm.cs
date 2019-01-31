using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ezfx.Csv.ItemWizards
{
    public class EncodingComboboxItem
    {
        public EncodingInfo Value { get; set; }
        public string Text
        {
            get { return Value.DisplayName; }
        }

        public int CodePage
        {
            get { return Value.CodePage; }
        }

        public override string ToString()
        {
            return Value.DisplayName;
        }
    }


    public partial class ConfigForm : Form
    {

        public CsvConfig Config { get; set; }

        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            Config = new CsvConfig();
            this.csvConfigBindingSource.DataSource = Config;
            Config.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Config_PropertyChanged);
            LoadEncoding();
        }

        void Config_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Display();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            Display();
            this.Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            BrowseFile();
        }

        private void BrowseFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv|Access Files(*.mdb;*.accdb)|*.mdb;*.accdb|Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                pathTextBox.Text = ofd.FileName;
                if (ofd.FileName.GetIsOleDb())
                {
                    foreach (string tableName in CsvContext.GetTableNames(ofd.FileName))
                    {
                        tableComboBox.Items.Add(tableName);
                    }
                    if (tableComboBox.Items.Count > 0)
                    {
                        tableComboBox.SelectedIndex = 0;
                        return;
                    }
                }
                Display();
            }
        }

        #region Encoding

        private void LoadEncoding()
        {
            Config.CodePage = Encoding.Default.CodePage;
            List<EncodingInfo> infos = Encoding.GetEncodings().ToList();
            infos.Sort((a, b) => a.DisplayName.CompareTo(b.DisplayName));
            foreach (EncodingInfo info in infos)
            {
                EncodingComboboxItem item = new EncodingComboboxItem() {  Value = info };
                encodingComboBox.Items.Add(item);
            }
            encodingComboBox.Text = Encoding.Default.EncodingName;
        }

        private void systemRadioButton_Click(object sender, EventArgs e)
        {
            Config.CodePage = Encoding.Default.CodePage;
            Display();
        }

        private void unicodeRadioButton_Click(object sender, EventArgs e)
        {
            Config.CodePage = Encoding.Unicode.CodePage;
            Display();
        }

        #endregion

        private void Display()
        {
            if (pathTextBox.Text == string.Empty)
            {
                return;
            }
            DataTable dt = null;
            if (pathTextBox.Text.GetIsOleDb())
            {
                if (tableComboBox.SelectedItem == null)
                {
                    return;
                }
                dt = CsvContext.GetDataTable(pathTextBox.Text, tableComboBox.SelectedItem.ToString());
            }
            else
            {
                dt = CsvContext.GetDataTable(pathTextBox.Text, Config.Delimiter, Encoding.GetEncoding(Config.CodePage));

            }
            Config.Columns.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Config.Columns.Add(new CsvColumn { Ordinal = i, Name = dt.Columns[i].ColumnName });
            }
            mainDataGridView.DataSource = dt;
            this.Refresh();
        }

        private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableComboBox.SelectedItem != null)
            {
                Config.Name = tableComboBox.SelectedItem.ToString();
            }

            Display();
        }

        private void encodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (encodingComboBox.SelectedItem != null)
            //{
            //    Config.Name = tableComboBox.SelectedItem.ToString();
            //encodingComboBox.SelectedItem
            //}
            Config.CodePage = ((EncodingComboboxItem)encodingComboBox.SelectedItem).CodePage;
            Display();
        }
    }
}
