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

                //object[] attrs = typeof(T).GetCustomAttributes(typeof(CsvObjectAttribute), false);
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

        public static T[] ReadContext<T>(string all, CsvConfig config) where T : new()
        {
            return ReadContext<T>(all, config, null, null);
        }

        public static T[] ReadContext<T>(string all, CsvConfig config, Predicate<string> preFilter, Predicate<T> postFilter) where T : new()
        {
            string[] lines = all.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return ReadContext(lines, config, preFilter, postFilter);//
        }

        public static T[] ReadContext<T>(IEnumerable<string> lines, CsvConfig config) where T : new()
        {
            return ReadContext<T>(lines, config, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="config"></param>
        /// <param name="preFilter">Remove logically invalid lines</param>
        /// <param name="postFilter">Remove invalid business objects</param>
        /// <returns></returns>
        public static T[] ReadContext<T>(IEnumerable<string> lines, CsvConfig config, Predicate<string> preFilter, Predicate<T> postFilter) where T : new()
        {
            List<string> list = lines.ToList(); //all.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            list.RemoveAll(line => line.StartsWith("#"));
            if (preFilter != null)
            {
                list.RemoveAll(preFilter);
            }

            List<T> ts = new List<T>();

            if (config.IsCustomized)
            {
                throw new NotImplementedException("IsCustomized");
            }

            string[] titles = null;
            if (config.MappingType == CsvMappingType.Title)
            {
                titles = list[0].Split(new string[] { config.Delimiter }, StringSplitOptions.None);
            }

            for(int i=0;i<titles.Length;i++)
            {
                titles[i] = titles[i].Trim(new char[] { '"',' '});
            }

            for (int i = (config.HasHeader ? 1 : 0); i < list.Count; i++)
            {
                if (!list[i].StartsWith("#", StringComparison.OrdinalIgnoreCase))
                {
                    ts.Add(ReadLine<T>(list[i], titles, config));
                }
            }

            //if (config.MappingType == CsvMappingType.Order)
            //{
            //    for (int i = (config.HasHeader ? 1 : 0); i < list.Count; i++)
            //    {
            //        if (!list[i].StartsWith("#", StringComparison.OrdinalIgnoreCase))
            //        {
            //            ts.Add(ReadLine<T>(list[i], config));
            //        }
            //    }
            //}

            if (postFilter != null)
            {
                ts.RemoveAll(postFilter);
            }

            return ts.ToArray();
        }

        public static T ReadLine<T>(string line, string[] titles, CsvConfig config) where T : new()
        {
            string[] fields = CsvContext.GetFields(line, config.Delimiter);
            T result = new T();
            Type t = typeof(T);
            List<PropertyInfo> pis = t.GetProperties().ToList();
            for (int i = 0; i < fields.Length; i++)
            {
                PropertyInfo pi = null;
                if (config.MappingType == CsvMappingType.Title)
                {
                    pi = GetPropertyInfo(pis, i, titles[i], config);
                }

                if (config.MappingType == CsvMappingType.Order)
                {
                    pi = GetPropertyInfo(pis, i);
                }

                if (pi != null)
                {
                    pi.SetValueEx(result, fields[i]);
                }
            }

            foreach (PropertyInfo pi in pis)
            {
                //If the property is adorned with CsvOriginalFieldsAttribute, set the value to fields
                if (pi.IsDefined(typeof(CsvOriginalFieldsAttribute), true))
                {
                    pi.SetValue(result, fields, null);
                }
            }
            return result;
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
