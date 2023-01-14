using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ezfx.Csv.ItemWizards
{
    public abstract class ClassWizard:IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {
            
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            //try
            //{
                ConfigForm configFrm = new ConfigForm();
                if (DialogResult.OK == configFrm.ShowDialog())
                {
                    CsvConfig config = configFrm.Config;
                    if (config == null)
                    {
                        _shouldAddProjectItem = false;
                        return;
                    }

                    replacementsDictionary.Add("$codepage$", config.CodePage.ToString());
                    replacementsDictionary.Add("$tableName$", config.Name??"");
                    replacementsDictionary.Add("$Delimiter$", config.Delimiter??",");
                    replacementsDictionary.Add("$MappingType$", config.MappingType.ToString());
                    //GetProperties
                    StringBuilder properties = new StringBuilder();
                    foreach (CsvColumn col in config.Columns)
                    {
                        properties.Append(GetPropertyCode(col));
                        properties.AppendLine();
                    }

                    replacementsDictionary.Add("$properties$", properties.ToString());
                    //attr.Title
                }
                else
                {
                    //Exit???
                    _shouldAddProjectItem = false;
                }
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.Message + "\r\n" + e.StackTrace);
            //}
        }

        protected abstract string GetPropertyCode(CsvColumn col);

        private bool _shouldAddProjectItem = true;
        public bool ShouldAddProjectItem(string filePath)
        {
            return _shouldAddProjectItem;
        }

    }
}
