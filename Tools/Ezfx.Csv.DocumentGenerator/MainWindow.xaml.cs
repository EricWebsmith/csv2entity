using Microsoft.Win32;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Ezfx.Csv.DocumentGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        string[] tableNames ;
        CsvColumn[] cols = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv|Access Files(*.mdb;*.accdb)|*.mdb;*.accdb|Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (true == ofd.ShowDialog())
            {
                pathTextBox.Text = ofd.FileName;
                if (System.IO.Path.GetExtension(pathTextBox.Text).ToUpper(CultureInfo.InvariantCulture) == ".CSV")
                {
                    tableComboBox.Items.Clear();
                    Display();
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
                //Display();
            }
        }

        private void Display()
        {
            //cols = CsvContext.GetColumnDefinition(pathTextBox.Text, (tableComboBox.SelectedValue ?? "").ToString());
            
            //mainListView.ItemsSource = cols;
        }

        private void tableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.SafeFileName))
                {
                    sw.Write(CsvContext.GetColumnDefinitionCsv(cols));
                }
            }
        }
    }
}
