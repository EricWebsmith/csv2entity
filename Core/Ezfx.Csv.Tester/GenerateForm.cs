using System;
using System.IO;
using System.Windows.Forms;

using Ezfx.Csv.Tester;

namespace Ezfx.Csv
{
    public partial class GenerateForm : Form
    {
        public GenerateForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //codeTextBox.Text= CsvContext.ToEntity(cvsPathTextBox.Text, namespaceTextBox.Text,System.Text.Encoding.GetEncoding(936));
        }

        private void cvsPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files|*.csv";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                cvsPathTextBox.Text = ofd.FileName;
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(codeTextBox.Text);
        }

    }
}
