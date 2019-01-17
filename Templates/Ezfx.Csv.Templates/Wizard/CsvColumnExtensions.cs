namespace Ezfx.Csv.ItemWizards
{
    public static class CsvColumnExtensions
    {
        public static string ToCSCode(this CsvColumn col)
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

        public static string ToVBCode(this CsvColumn col)
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
