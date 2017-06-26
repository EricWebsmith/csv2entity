using System.Reflection;

namespace Ezfx.Csv
{
    public class CsvPropertyInfo
    {
        public SystemCsvColumnAttribute Attribute { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}
