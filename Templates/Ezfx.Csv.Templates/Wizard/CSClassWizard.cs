using Microsoft.VisualStudio.TemplateWizard;

namespace Ezfx.Csv.Templates
{
    public class CSClassWizard : ClassWizard, IWizard
    {
        protected override string GetPropertyCode(CsvColumn col)
        {
            return col.ToCSCode();
        }
    }
}
