using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ezfx.Csv
{
    public static partial class CsvContext
    {

        public static T[] ReadFile<T>(string path) where T : new()
        {
            return ReadFile<T>(path, null);
        }

        public static T[] ReadFile<T>(string path, CsvConfig config) where T : new()
        {
            if (path.GetIsOleDb())
            {
                return ReadFile<T>(path, GetTableName<T>(), config);
            }

            if (config == null)
            {
                config = new CsvConfig();

                if (typeof(T).IsDefined(typeof(CsvObjectAttribute), false))
                {
                    CsvObjectAttribute attr = (CsvObjectAttribute)(typeof(T).GetCustomAttributes(typeof(CsvObjectAttribute), false)[0]);
                    config.CodePage = attr.CodePage;
                    config.HasHeader = attr.HasHeader;
                    config.Delimiter = attr.Delimiter;
                    config.MappingType = attr.MappingType;
                }
            }

            Encoding encoding = Encoding.Default;
            if (config.CodePage != 0)
            {
                encoding = Encoding.GetEncoding(config.CodePage);
            }

            using (StreamReader sr = new StreamReader(path, encoding))
            {
                return ReadContext<T>(sr.ReadToEnd(), config);
            }
        }

        public static string GetTableName<T>() where T : new()
        {
            Type t = typeof(T);
            object[] attrs = t.GetCustomAttributes(typeof(CsvObjectAttribute), false);
            if (attrs.Length == 1)
            {
                return ((CsvObjectAttribute)attrs[0]).Name;
            }
            return null;
        }

        //added a new overload of this method  1/27/2019
        public static T[] ReadContext<T>(string context) where T : new()
        {
            return ReadContext<T>(context, CsvConfig.Default);
        }
        
        public static T[] ReadContext<T>(string context, CsvConfig config) where T : new()
        {
            return ReadContext<T>(context, config, null, null);
        }

        //modify this to abey rfc4180 https://tools.ietf.org/html/rfc4180
        public static T[] ReadContext<T>(string context, CsvConfig config, Predicate<string> preFilter, Predicate<T> postFilter) where T : new()
        {
            List<string> lines = context.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string newContent = string.Empty;
            if(preFilter!=null)
            {
                lines.RemoveAll(preFilter);
                newContent = string.Join("\r\n", lines.ToArray());
            }
            else
            {
                newContent = context;
            }

            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            var items = new List<T>();
            var recoreds = GetRecords(newContent, config.Delimiter).ToList();
            if(config.HasHeader)
            {
                recoreds.RemoveAt(0);
            }
            foreach(var record in recoreds)
            {
                var item = ReadRecord<T>(record, properties);
                items.Add(item);
            }

            if(postFilter!=null)
            {
                items.RemoveAll(postFilter);
            }

            return items.ToArray();
        }

        private static T ReadRecord<T>(CsvRecord record, List<PropertyInfo> properties) where T : new()
        {
            T result = new T();
            for (int i = 0; i < record.Count; i++)
            {
                properties[i].SetValueEx(result, record[i]);
            }
            return result;
        }

        public static T ReadRecord<T>(string line, string[] titles, CsvConfig config) where T : new()
        {
            CsvRecord record = CsvContext.GetRecords(line, config.Delimiter).First();
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            return ReadRecord<T>(record, properties);
        }

        //public static T ReadByOrder<T>(string line, CsvConfig config) where T : new()
        //{
        //    string[] fields = CsvContext.GetFields(line, config.Delimiter);
        //    T result = new T();
        //    Type t = typeof(T);
        //    List<PropertyInfo> pis = t.GetProperties().ToList();

        //    for (int i = 0; i < fields.Length; i++)
        //    {
        //        PropertyInfo pi = GetPropertyInfo(pis, i);
        //        if (pi != null)
        //        {
        //            pi.SetValue(result, fields[i]);
        //        }
        //    }
        //    return result;
        //}


        private static bool Contains(string alias, string title)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return false;
            }
            return alias.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Contains(title);
        }

        #region GetPropertyInfo

        private static PropertyInfo GetPropertyInfo(List<PropertyInfo> pis, int ordial, string title, CsvConfig config)
        {
            switch (config.MappingType)
            {
                case CsvMappingType.Title:
                    return GetPropertyInfoBase(pis, attr =>
                    {
                        if (attr.Name == title)
                        {
                            return true;
                        }

                        if (Contains(attr.Alias, title))
                        {
                            return true;
                        }

                        if (config.ContainsColumn(attr.Name))
                        {
                            return Contains(config.GetAlias(attr.Name), title);
                        }
                        return false;
                    });
                case CsvMappingType.Order:
                default:
                    return GetPropertyInfoBase(pis, attr => attr.Ordinal == ordial);
            }
        }

        private static PropertyInfo GetPropertyInfo(List<PropertyInfo> properties, string title)
        {
            return GetPropertyInfoBase(properties, attr =>
            {
                if (attr.Name == title)
                {
                    return true;
                }

                if (!string.IsNullOrEmpty(attr.Alias) && attr.Alias.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Contains(title))
                {
                    return true;
                }

                return false;
            });
        }

        private static PropertyInfo GetPropertyInfo(List<PropertyInfo> pis, int i)
        {
            return GetPropertyInfoBase(pis, attr => attr.Ordinal == i);
        }

        private static PropertyInfo GetPropertyInfoBase(List<PropertyInfo> properties, Predicate<SystemCsvColumnAttribute> predicate)
        {
            PropertyInfo result = null;
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    object[] attrs = pi.GetCustomAttributes(typeof(SystemCsvColumnAttribute), false);
                    if (attrs.Count() == 1)
                    {
                        SystemCsvColumnAttribute attr = (SystemCsvColumnAttribute)attrs[0];
                        if (predicate.Invoke(attr))
                        {
                            result = pi;
                        }
                    }
                }
            }
            if (result != null)
            {
                properties.Remove(result);
            }

            return result;
        }
        #endregion
    }
}
