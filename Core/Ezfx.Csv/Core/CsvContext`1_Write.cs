﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Ezfx.Csv
{
    public static partial class CsvContext
    {
        public static string GetContent<T>(IEnumerable<T> entities, CsvConfig config) where T : new()
        {
            if (config == null)
            {
                config = new CsvConfig(typeof(T));
            }

            CsvPropertyInfo[] csvPropertyInfos = GetPropertyInfos<T>();
            StringBuilder sb = new StringBuilder();
            if (config.HasHeader)
            {
                List<string> titles = new List<string>();
                foreach (CsvPropertyInfo csvPi in csvPropertyInfos)
                {
                    titles.Add(FixField(csvPi.Attribute.Name, config.Delimiter));
                }
                sb.AppendLine(string.Join(config.Delimiter, titles.ToArray()));
            }

            foreach (T entity in entities)
            {
                sb.AppendLine(GetLine(entity, config, csvPropertyInfos));
            }
            return sb.ToString();
        }

        public static string GetLine<T>(T entity, CsvConfig config, CsvPropertyInfo[] csvPropertyInfos) where T : new()
        {
            if (config == null)
            {
                config = new CsvConfig(typeof(T));
            }

            List<string> fields = new List<string>();
            foreach (CsvPropertyInfo csvPi in csvPropertyInfos)
            {
                fields.Add(FixField(csvPi.PropertyInfo.GetValue(entity, null).ToString(), config.Delimiter));
            }
            return string.Join(config.Delimiter, fields.ToArray());
        }

        public static void WriteFile<T>(string path, IEnumerable<T> objects, Encoding encoding) where T : new()
        {
            CsvConfig config = new CsvConfig(typeof(T));
            WriteFile<T>(path, objects, config, encoding);
        }

        public static void WriteFile<T>(string path, IEnumerable<T> objects) where T : new()
        {
            CsvConfig config = new CsvConfig(typeof(T));
            WriteFile<T>(path, objects, config);
        }

        public static void WriteFile<T>(string path, IEnumerable<T> objects, CsvConfig config) where T : new()
        {
            Encoding encoding = Encoding.UTF8;
            
            if (config.CodePage != 0)
            {
                encoding = Encoding.GetEncoding(config.CodePage);
            }

            using (StreamWriter sw = new StreamWriter(path, false, encoding))
            {
                WriteFile(sw, objects, config);
            }
        }

        public static void WriteFile<T>(string path, IEnumerable<T> objects, CsvConfig config, Encoding encoding) where T : new()
        {

            if (config == null)
            {
                config = CsvConfig.Default;
            }

            using (StreamWriter sw = new StreamWriter(path, false, encoding))
            {
                WriteFile(sw, objects, config);
            }
        }

        private static void WriteFile<T>(StreamWriter sw, IEnumerable<T> objects, CsvConfig config) where T : new()
        {
            CsvPropertyInfo[] properties = GetPropertyInfos<T>();


            if (config.HasHeader)
            {
                for(int i=0;i< properties.Length-1;i++)
                {
                    sw.Write(FixField(properties[i].Attribute.Name, config.Delimiter) );
                    sw.Write(config.Delimiter);
                }
                sw.Write(FixField(properties[properties.Length - 1].Attribute.Name, config.Delimiter));
                sw.WriteLine();
            }

            foreach (T o in objects)
            {
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    sw.Write(FixField(properties[i].PropertyInfo.GetValue(o, null)?.ToString(), config.Delimiter));
                    sw.Write(config.Delimiter);
                }
                sw.Write(FixField(properties[properties.Length - 1].PropertyInfo.GetValue(o, null)?.ToString(), config.Delimiter));
                sw.WriteLine();
            }
            sw.Flush();
        }

        public static CsvPropertyInfo[] GetPropertyInfos<T>() where T : new()
        {
            List<CsvPropertyInfo> properties = new List<CsvPropertyInfo>();
            Type t = typeof(T);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                CsvPropertyInfo csvPi = new CsvPropertyInfo();
                csvPi.PropertyInfo = pi;
                if (pi.GetCustomAttributes(typeof(SystemCsvColumnAttribute), false).Length == 1)
                {
                    csvPi.Attribute = (SystemCsvColumnAttribute)pi.GetCustomAttributes(typeof(SystemCsvColumnAttribute), false)[0];
                    if (string.IsNullOrEmpty(csvPi.Attribute.Name))
                    {
                        csvPi.Attribute.Name = pi.Name;
                    }
                }
                else
                {
                    csvPi.Attribute = new SystemCsvColumnAttribute();
                    csvPi.Attribute.Alias = "";
                    csvPi.Attribute.Ordinal = int.MaxValue;
                    csvPi.Attribute.Name = pi.Name;
                }
                properties.Add(csvPi);
            }

            properties.Sort((a, b) =>
            {
                return a.Attribute.Ordinal.CompareTo(b.Attribute.Ordinal);
            });


            return properties.ToArray();
        }
    }
}
