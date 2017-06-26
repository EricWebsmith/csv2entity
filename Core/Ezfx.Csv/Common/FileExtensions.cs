using System.Globalization;

namespace Ezfx.Csv
{
    public static class FileExtensions
    {
        public static bool GetIsOleDb(this string path)
        {
            string ext = System.IO.Path.GetExtension(path).ToUpper(CultureInfo.InvariantCulture);
            return (ext == ".MDB" ||
                ext == ".ACCDB" ||
                ext == ".XLS" ||
                ext == ".XLSX");
        }
    }
}
