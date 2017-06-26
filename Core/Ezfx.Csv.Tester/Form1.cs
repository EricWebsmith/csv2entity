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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.ContainsKey
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadForm rf = new ReadForm();
            rf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GenerateForm().ShowDialog();
        }
    }
}
