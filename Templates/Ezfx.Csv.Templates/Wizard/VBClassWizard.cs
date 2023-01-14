using Microsoft.VisualStudio.TemplateWizard;

namespace Ezfx.Csv.ItemWizards
{
    public class VBClassWizard : ClassWizard, IWizard
    {
        protected override string GetPropertyCode(CsvColumn col)
        {
            return string.Format(
                "    ''' <summary>\r\n" +
                "    ''' {1}, {0}\r\n" +
                "    ''' </summary>\r\n" +
                "    <SystemCsvColumn(Alias:=\"\", Ordinal:={1}, Name:=\"{0}\")> _\r\n" +
                "    Public Property {0}() As String\r\n" +
                "\r\n",
                CsvContext.ToVariant(col.Name),
                col.Ordinal
                );
        }
    }
}
