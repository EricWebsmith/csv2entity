using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Ezfx.Csv
{
    public static partial class CsvContext
    {
        public const string DialogFilter = "CSV Files (*.csv)|*.csv| Access Files(*.mdb;*.accdb) |*.mdb;*.accdb| Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";

        public static string FixField(string value, string delimiter)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value.Contains(delimiter))
            {
                return "\"" + value + "\"";
            }
            return value;
        }

        public static string FixField(string value)
        {
            return FixField(value, ",");
        }

        public static string[] GetFields(string line, string delimiter)
        {
            //string tempLine = line;
            Dictionary<string, string> specialFields = new Dictionary<string, string>();
            int quotationAt = line.IndexOf("\"", StringComparison.Ordinal);
            while (quotationAt >= 0)
            {
                int pairAt = line.IndexOf("\"", quotationAt + 1, StringComparison.Ordinal);
                string guid = Guid.NewGuid().ToString();
                string specialField = line.Substring(quotationAt + 1, pairAt - quotationAt - 1);
                //tempLine = tempLine.Substring(0, quotationAt)
                //    + guid
                //    + tempLine.Substring(pairAt + 1);
                specialFields.Add(guid, specialField);
                quotationAt = line.IndexOf("\"", pairAt + 1, StringComparison.Ordinal);
            }

            StringBuilder tempLine =new StringBuilder( line);
            foreach (KeyValuePair<string, string> pair in specialFields)
            {
                tempLine.Replace("\""+pair.Value+"\"", pair.Key);
            }

            string[] result = tempLine.ToString().Split(delimiter.ToArray(),StringSplitOptions.None);
            for (int i = 0; i < result.Length; i++)
            {

                if (specialFields.ContainsKey(result[i]))
                {
                    result[i] = specialFields[result[i]];
                }
            }
            return result.ToArray();
        }

        public static string ToVariant(string name)
        {
            string result = name;
            result = result.Replace(" ", "");
            result = result.Replace(".", "");
            result = result.Replace("/", "");
            result = result.Replace("\\", "");
            return result;
        }

        public static string GetConnectionString(string path, bool hasHeader)
        {
            switch (Path.GetExtension(path).ToUpper(CultureInfo.InvariantCulture))
            {
                case ".MDB":
                    return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";";
                case ".XLS":
                    return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR="+(hasHeader?"Yes":"NO")+";IMEX=1\"";
                case ".XLSX":
                    return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0 Xml;HDR=" + (hasHeader ? "Yes" : "NO") + "\";";
                case ".ACCDB":
                    return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
            }
            return null;
        }

        public static string GetConnectionString(string path)
        {
            return GetConnectionString(path, true);
        }

        public static string[] GetTableNames(string path)
        {
            List<string> result = new List<string>();
            string connectionString = GetConnectionString(path);  
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //DataTable ctable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
                foreach (DataRow row in table.Rows)
                {
                    if (row.Field<string>("TABLE_TYPE") == "TABLE")
                    {
                        result.Add(row["Table_Name"].ToString());
                    }
                }
                connection.Close();
            }
            return result.ToArray();
        }

        public static CsvColumn[] GetMappings(DataTable table)
        {
            List<CsvColumn> result = new List<CsvColumn>();
            foreach (DataColumn dc in table.Columns)
            {
                result.Add(new CsvColumn(dc));
            }
            return result.ToArray();
        }
        
        public static string GetMappingsCsv(DataTable table)
        {
            CsvColumn[] mappings = GetMappings(table);
            StringBuilder result = new StringBuilder();
            result.AppendLine("Ordinal,Name,Description");
            foreach (CsvColumn mapping in mappings)
            {
                result.AppendLine(mapping.Ordinal.ToString(CultureInfo.InvariantCulture) + "," + FixField(mapping.Name));
            }
            return result.ToString();
        }

        public static string GetColumnDefinitionCsv(CsvColumn[] cols)
        {
            //CsvColumn[] cols = GetColumnDefination(path, tableName);
            StringBuilder result = new StringBuilder();
            result.AppendLine("Ordinal,Name,Description");
            foreach (CsvColumn col in cols)
            {
                result.AppendLine(col.Ordinal.ToString(CultureInfo.InvariantCulture) + "," + FixField(col.Name) + "," + FixField(col.Description));
            }
            return result.ToString();
        }

        public static string GetColumnDefinitionCsv(string path, string delimiter, string tableName)
        {
            CsvColumn[] cols = GetColumnDefinition(path,delimiter, tableName);
            return GetColumnDefinitionCsv(cols);
        }

        /// <summary>
        /// By OleDb Schema
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static CsvColumn[] GetColumnDefinition(string path, string delimiter, string tableName)
        {
            List<CsvColumn> result = new List<CsvColumn>();
            if (!path.GetIsOleDb())
            {
                string[] titles = GetTitles(path, delimiter,Encoding.Default);
                for (int i = 0; i < titles.Length;i++ )
                {
                    result.Add(new CsvColumn { Ordinal = i, Name = titles[i] });
                }
                
                return result.ToArray();
            }
             
            string connectionString = GetConnectionString(path);
            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable columnsTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
                connection.Close();


                foreach (DataRow row in columnsTable.Rows)
                {
                    if (row["table_Name"].ToString().ToUpper(CultureInfo.InvariantCulture) == tableName.ToUpper(CultureInfo.InvariantCulture))
                    {
                        CsvColumn col = new CsvColumn();
                        col.Ordinal = (int)(row.Field<long>("ORDINAL_POSITION") - 1);
                        col.Name = row.Field<string>("COLUMN_NAME");
                        col.IsRequired = false;
                        col.Description = row.Field<string>("DESCRIPTION");
                        result.Add(col);
                    }
                }
            }
            result.Sort((a, b) => a.Ordinal.CompareTo(b.Ordinal));
            return result.ToArray();
        }

        private static string[] GetTitles(string path,string delimiter, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(path, encoding))
            {
                return GetFields(sr.ReadLine(), delimiter).Select(c => ToVariant(c)).ToArray();
            }
        }

        public static DataTable GetFirstTable(string path)
        {
            string connectionString = GetConnectionString(path);
            DataTable result = new DataTable();
            result.Locale = CultureInfo.InvariantCulture;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                result.TableName = table.Rows[0]["Table_Name"].ToString();
                string strExcel = "select * from " + "[" + result.TableName + "]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, connectionString);
                adapter.Fill(result);
                connection.Close();
            }
            return result;
        }

        public static DataTable GetDataTable(string path, string tableName)
        {
            if (!path.GetIsOleDb())
            {
                return GetDataTable(path,",", Encoding.Default);
            }
            string sheetName = tableName;
            if (string.IsNullOrEmpty(sheetName))
            {
                return GetFirstTable(path);
            }
            string strConn = GetConnectionString(path);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", strConn);
            DataTable table = new DataTable(tableName);
            table.Locale = CultureInfo.InvariantCulture;
            da.Fill(table);
            return table;
        }

        //public static DataTable GetDataTable(string path)
        //{
        //    return GetDataTable(path,",", Encoding.Default);
        //}

        public static DataTable GetDataTable(string path,string delimiter, Encoding encoding)
        {
            if (path.GetIsOleDb())
            {

            }
                        
            DataTable dt = new DataTable();
            dt.Locale = CultureInfo.InvariantCulture;
            using (StreamReader sr = new StreamReader(path, encoding))
            {
                string firstLine = sr.ReadLine();
                string[] titles = CsvContext.GetFields(firstLine, delimiter);

                for (int i = 0; i < titles.Length; i++)
                {
                    dt.Columns.Add(titles[i]);
                }

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] fields = CsvContext.GetFields(line, delimiter);
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < fields.Length && i < dt.Columns.Count; i++)
                    {
                        dr[i] = fields[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
