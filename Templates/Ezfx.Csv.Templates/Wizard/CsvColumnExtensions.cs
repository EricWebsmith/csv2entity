using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                //"\r\n" +
                //"    Private _{0} As String\r\n" +
                "    ''' <summary>\r\n" +
                "    ''' {1}, {0}\r\n" +
                "    ''' </summary>\r\n" +
                "    <SystemCsvColumn(Alias:=\"\", Ordinal:={1}, Name:=\"{0}\")> _\r\n" +
                "    Public Property {0}() As String\r\n" +
                //"        Get\r\n" +
                //"            Return _{0}\r\n" +
                //"        End Get\r\n" +
                //"        Set(ByVal value As String)\r\n" +
                //"            _{0} = value\r\n" +
                //"        End Set\r\n" +
                //"    End Property\r\n" +
                "\r\n",
                CsvContext.ToVariant(col.Name),
                col.Ordinal
                );
        }
    }
}
