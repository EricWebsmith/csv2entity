using Microsoft.VisualStudio.TemplateWizard;

namespace Ezfx.Csv.ItemWizards
{
    public class CSClassWizard : ClassWizard, IWizard
    {
        protected override string GetPropertyCode(CsvColumn col)
        {
            return string.Format(
                "\r\n" +
                "\t\t/// <summary>\r\n" +
                "\t\t/// {1}, {0}\r\n" +
                "\t\t/// </summary>\r\n" +
                "\t\t[SystemCsvColumn(Name = \"{0}\", Ordinal = {1} , Alias = \"{2}\")]\r\n" +
                "\t\tpublic string {0}",
                CsvContext.ToVariant(col.Name),
                col.Ordinal,
                col.Alias
                ) + " { get;set; }\r\n";
        }
    }
}
