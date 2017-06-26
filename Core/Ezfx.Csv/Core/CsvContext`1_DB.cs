using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Ezfx.Csv
{
    public static partial class CsvContext
    {
        public static T[] ReadFile<T>(string path, string tableName, CsvConfig config)
            where T : new()
        {
            if (path.GetIsOleDb())
            {
                DataTable table = CsvContext.GetDataTable(path, tableName);
                return ReadDataTable<T>(table, config);
            }
            else
            {
                return ReadFile<T>(path, config);
            }
        }

        public static T[] ReadDataTable<T>(DataTable table, CsvConfig config)
            where T : new()
        {
            List<T> ts = new List<T>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ts.Add(Read<T>(table.Rows[i], config));
            }
            return ts.ToArray();
        }

        private static T Read<T>(DataRow dataRow, CsvConfig config) where T : new()
        {
            if (config == null)
            {
                return ReadByTitle<T>(dataRow);
            }

            switch (config.MappingType)
            {
                case CsvMappingType.Title:
                    return ReadByTitle<T>(dataRow);
                case CsvMappingType.Order:
                    return ReadByOrder<T>(dataRow);
                default:
                    return ReadByTitle<T>(dataRow);
            }
        }

        private static T ReadByOrder<T>(DataRow dataRow) where T : new()
        {
            T result = new T();
            Type t = typeof(T);
            List<PropertyInfo> pis = t.GetProperties().ToList();
            for (int i = 0; i < dataRow.ItemArray.Length; i++)
            {
                PropertyInfo pi = GetPropertyInfo(pis, i);
                if (pi != null)
                {
                    pi.SetValue(result, dataRow[i].ToString());
                }
            }
            return result;
        }


        private static T ReadByTitle<T>(DataRow dataRow) where T : new()
        {
            T result = new T();
            Type t = typeof(T);
            List<PropertyInfo> pis = t.GetProperties().ToList();
            for (int i = 0; i < dataRow.ItemArray.Length; i++)
            {
                PropertyInfo pi = GetPropertyInfo(pis, dataRow.Table.Columns[i].ColumnName);
                if (pi != null)
                {
                    pi.SetValue(result, dataRow[i].ToString());
                }
            }
            return result;
        }
    }
}
