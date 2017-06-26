using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ezfx.Csv.Templates;
using Microsoft.VisualStudio.TemplateWizard;

namespace Ezfx.Csv.Templates.Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VBClassWizard wizard = new VBClassWizard();
            Dictionary<string, string> dic= new Dictionary<string, string>();
            wizard.RunStarted(null,dic , WizardRunKind.AsNewItem, null);
            if (wizard.ShouldAddProjectItem(""))
            {
                textBox1.Text = dic["$properties$"];
            }
        }
    }
}
