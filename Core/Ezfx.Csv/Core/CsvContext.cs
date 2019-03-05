//#define NETSTANDARD
#undef NETSTANDARD
using System;
using System.Data;
using System.Collections.Generic;

#if !NETSTANDARD
using System.Data.OleDb;
#endif
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

            if (new List<string> { delimiter, "\r", "\n" }.Any(s => value.Contains(s)))
            {
                return "\"" + value + "\"";
            }

            if (value.Contains("\""))
            {
                return "\"" + value.Replace("\"","\"\"") + "\"";
            }
            return value;
        }

        public static string FixField(string value)
        {
            return FixField(value, ",");
        }

        public static string[] GetFields(string content, string delimiter)
        {
            return GetRecords(content, delimiter).First().ToArray();
        }

        public static CsvRecord[] GetRecords(string content, string delimiter)
        {
            List<CsvRecord> records = new List<CsvRecord>();
            //List<string> fields = new List<string>();
            content = content + "\n";
            var charArray = content.ToArray();

            //the following variables are used in the for loop.
            var currentField = string.Empty;
            var concatenating = true; //meaning we are concatenating a field. or to say, we find the start but we are not at the end of a field yet.
            var startWithDoubleQuote = false;
            var startRecord = true;
            var currentRecord = new CsvRecord();
            records.Add(currentRecord);
            for (int i = 0; i < charArray.Length; i++)
            {

                var currentChar = charArray[i];
                var nextChar = i + 1 < charArray.Length? charArray[i + 1] : '\0';

                if (startRecord)
                {
                    switch (currentChar)
                    {
                        case '\r':
                            continue;
                        case '\n':
                            continue;
                        case ',':
                            currentRecord.Add(string.Empty);
                            concatenating = false;
                            break;
                        case '"':
                            startWithDoubleQuote = true;
                            concatenating = true;
                            break;
                        default:
                            currentField += currentChar;
                            startWithDoubleQuote = false;
                            concatenating = true;
                            break;
                    }
                    startRecord = false;
                }
                else if (concatenating)
                {
                    if (startWithDoubleQuote)
                    {
                        if (currentChar == '"')
                        {
                            //if this is the last char
                            if (i + 1 == charArray.Length)
                            {
                                currentField += currentChar;
                                AddField(currentRecord, ref currentField, ref concatenating);
                                
                                continue;
                            }

                            if (nextChar == '"')
                            {
                                currentField += currentChar;
                                i++;
                            }
                            else //nextChar != '"'
                            {
                                AddField(currentRecord, ref currentField, ref concatenating);
                                if (nextChar == ',') i++;
                            }
                        }
                        else // currentChar!='"'
                        {
                            if (i + 1 == charArray.Length)
                            {
                                throw new CsvFormatException();
                            }
                            currentField += currentChar;
                        }

                    }
                    else //not startWithDoubleQuote
                    {
                        //if this is the last char
                        if (i + 1 == charArray.Length)
                        {
                            currentField += currentChar;
                            currentField = currentField.Trim();
                            currentRecord.Add(currentField);
                            continue;
                        }

                        switch(currentChar)
                        {
                            case '\r':
                            case '\n':
                                currentRecord.Add(currentField);
                                currentRecord = new CsvRecord();
                                currentField = string.Empty;
                                records.Add(currentRecord);
                                startRecord = true;
                                continue;
                            case ',':
                                AddField(currentRecord, ref currentField, ref concatenating);
                                break;
                            default:
                                currentField += currentChar;
                                break;
                        }
                    }
                }
                else // not concatenating
                {

                    switch (currentChar)
                    {
                        case '\r':
                        case '\n':
                            var previousChar =i>0? charArray[i - 1]:'\0';
                            if (previousChar==',')
                            {
                                currentRecord.Add(string.Empty);
                                currentRecord = new CsvRecord();
                                records.Add(currentRecord);
                                startRecord = true;
                            }
                            else
                            {
                                currentRecord = new CsvRecord();
                                records.Add(currentRecord);
                                startRecord = true;
                            }

                            continue;
                        case ',':
                            currentRecord.Add(string.Empty);
                            break;
                        case '"':
                            startWithDoubleQuote = true;
                            concatenating = true;
                            break;
                        default:
                            startWithDoubleQuote = false;
                            concatenating = true;
                            currentField += currentChar;
                            break;
                    }
                }
            }

            //checked if the last record is empty
            var last = records.Last();
            var isEmpty = false;
            if(last.Count==0)
            {
                isEmpty = true;
            }
            else
            {
                foreach (string s in last)
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        isEmpty = true;
                        break;
                    }
                }
            }


            if (isEmpty)
            {
                records.Remove(last);
            }

            return records.ToArray();
        }
        
        private static void AddField(CsvRecord currentRecord, ref string currentField, ref bool concatenating)
        {
            currentRecord.Add(currentField.Trim());
            currentField = string.Empty;
            concatenating = false;
        }

        //private static void AddField(CsvRecord currentRecord, char nextChar, ref string currentField, ref bool concatenating, ref int i)
        //{
        //    currentRecord.Add(currentField);
        //    currentField = string.Empty;
        //    concatenating = false;
        //    if (nextChar == ',')
        //    {
        //        i++;
        //    }
        //}

        public static string ToVariant(string name)
        {
            string result = name;
            result = result.Replace(" ", "");
            result = result.Replace(".", "");
            result = result.Replace("/", "");
            result = result.Replace("\\", "");
            return result;
        }
#if !NETSTANDARD
        public static string GetConnectionString(string path, bool hasHeader)
        {
            switch (Path.GetExtension(path).ToUpper())
            {
                case ".MDB":
                    return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";";
                case ".XLS":
                    return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=" + (hasHeader ? "Yes" : "NO") + ";IMEX=1\"";
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
                string[] titles = GetTitles(path, delimiter, Encoding.Default);
                for (int i = 0; i < titles.Length; i++)
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

        public static string GetColumnDefinitionCsv(string path, string delimiter, string tableName)
        {
            CsvColumn[] cols = GetColumnDefinition(path, delimiter, tableName);
            return GetColumnDefinitionCsv(cols);
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
                return GetDataTable(path, ",", Encoding.Default);
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
#endif
        private static string[] GetTitles(string path, string delimiter, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(path, encoding))
            {
                return GetRecords(sr.ReadLine(), delimiter).First().Select(c => ToVariant(c)).ToArray();
            }
        }

        public static DataTable GetDataTable(string path)
        {
            return GetDataTable(path, ",", Encoding.Default);
        }

        public static DataTable GetDataTable(string path, string delimiter, Encoding encoding)
        {
            if (path.GetIsOleDb())
            {

            }

            DataTable dt = new DataTable();
            dt.Locale = CultureInfo.InvariantCulture;
            using (StreamReader sr = new StreamReader(path, encoding))
            {
                string firstLine = sr.ReadLine().Trim();
                string[] titles = CsvContext.GetRecords(firstLine, delimiter).First().ToArray();

                for (int i = 0; i < titles.Length; i++)
                {
                    dt.Columns.Add(titles[i]);
                }

                string fixedLine = string.Empty;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                    //skip empty lines
                    if (line == string.Empty)
                    {
                        continue;
                    }
                    //read lines continuously
                    int lastDoubleQuote = line.LastIndexOf('"');
                    { }
                    string[] fields = CsvContext.GetRecords(line, delimiter).First().ToArray();
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
