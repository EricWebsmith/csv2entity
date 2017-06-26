using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguageConfigSample
{
    public partial class ConfigForm : Form
    {
        Ezfx.Csv.CsvConfig config = new Ezfx.Csv.CsvConfig();

        public ConfigForm()
        {
            InitializeComponent();
            LoadEncoding();
            config = new Ezfx.Csv.CsvConfig(typeof(LanguagePopularity));
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            csvConfigBindingSource.DataSource = this.config;
            dataGridView1.DataSource = config.Columns;
            config.PropertyChanged += new PropertyChangedEventHandler(config_PropertyChanged);
        }

        void config_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            changedLabel.ForeColor = Color.Red;
            changedPropertyLabel.ForeColor = Color.Red;
            changedPropertyLabel.Text = e.PropertyName;
        }

        private void LoadEncoding()
        {
            config.CodePage = Encoding.Default.CodePage;
            List<EncodingInfo> infos = Encoding.GetEncodings().ToList();
            infos.Sort((a, b) => a.DisplayName.CompareTo(b.DisplayName));
            foreach (EncodingInfo info in infos)
            {
                encodingComboBox.Items.Add(info.DisplayName);
            }
        }
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changedLabel.ForeColor = Color.Red;
            config.IsChanged = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(config.IsChanged)
            {
                if (DialogResult.OK == MessageBox.Show("Changes have been made, Save changes?", "", MessageBoxButtons.OKCancel))
                {
                    Save();
                }
            }
            this.Close();
        }

        private void okeyButton_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {
            MessageBox.Show("Save Not Implement.");
        }
    }
}
