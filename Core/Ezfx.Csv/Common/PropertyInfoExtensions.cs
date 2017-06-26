using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Ezfx.Csv
{
    static class PropertyInfoExtensions
    {
        public static void SetValueEx(this PropertyInfo propertyInfo, object obj, string value)
        {
            if (value == null)
            {
                propertyInfo.SetValue(obj, null, null);
                return;
            }

            Type t = propertyInfo.PropertyType;
            bool isNullable = false;
            if (t.IsGenericType)
            {
                if (t.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    isNullable = true;
                }
                else
                {
                    throw new DataTypeNotSupportException("Data type not support. " + t.Name);
                }
            }

            string typeString = t.Name;
            if (isNullable)
            {
                typeString = t.GetGenericArguments()[0].Name;
            }
            switch (typeString)
            {
                case "String":
                    propertyInfo.SetValue(obj, value, null);
                    break;
                case "Int16":
                case "Int32":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, IntTryParse);
                    break;
                case "Int64":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, LongTryParse);
                    break;
                case "Single":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, SingleTryParse);
                    break;
                case "Double":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, DoubleParse);
                    break;
                case "Decimal":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, DecimalParse);
                    break;
                case "DateTime":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, DateTimeParse);
                    break;
                case "Boolean":
                    SetValueInternal(propertyInfo, obj, value, isNullable, typeString, BooleanParse);
                    break;
                default:
                    throw new DataTypeNotSupportException("DateType:" + typeString + " Value:" + value);
            }
        }

        delegate bool TryParse(string value, ref object oValue);

        private static void SetValueInternal(this PropertyInfo propertyInfo, object obj, string value, bool isNullable, string typeString, TryParse tryParse)
        {
            object oValue = null;
            if (tryParse.Invoke(value, ref oValue))
            {
                propertyInfo.SetValue(obj, oValue, null);
                return;
            }
            else if (isNullable)
            {
                propertyInfo.SetValue(obj, null, null);
            }
            else
            {
                throw new ParseException(typeString, value);
            }
        }

        private static bool IntTryParse(string value, ref object o)
        {
            int i = 0;
            if (int.TryParse(value, out i))
            {
                o = i;
                return true;
            }
            return false;
        }

        private static bool LongTryParse(string value, ref object o)
        {
            long l = 0L;
            if (long.TryParse(value, out l))
            {
                o = l;
                return true;
            }
            return false;
        }

        private static bool SingleTryParse(string value, ref object o)
        {
            bool isPercentage = value.EndsWith("%", StringComparison.Ordinal);
            string temp = value.Trim().Replace("%", "").Trim();
            float f = 0;
            if (float.TryParse(temp, out f))
            {
                o = isPercentage ? f / 100 : f;
                return true;
            }
            return false;
        }

        private static bool DoubleParse(string value, ref object o)
        {
            bool isPercentage = value.EndsWith("%", StringComparison.Ordinal);
            string temp = value.Trim().Replace("%", "").Trim();
            double d = 0;
            if (double.TryParse(temp, out d))
            {
                o = isPercentage ? d / 100 : d;
                return true;
            }
            return false;
        }

        private static bool DecimalParse(string value, ref object o)
        {
            bool isPercentage = value.EndsWith("%", StringComparison.Ordinal);
            string temp = value.Trim().Replace("%", "").Trim();
            decimal d = 0;
            if (decimal.TryParse(temp, out d))
            {
                o = isPercentage ? d / 100 : d;
                return true;
            }
            return false;
        }

        private static bool DateTimeParse(string value, ref object o)
        {
            if (Regex.IsMatch(value, "^\\d{8}"))
            {
                try
                {
                    o = new DateTime(Convert.ToInt32(value.Substring(0, 4)), Convert.ToInt32(value.Substring(4, 2)), Convert.ToInt32(value.Substring(6, 2)));
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            DateTime d = new DateTime();
            if (DateTime.TryParse(value, out d))
            {
                o = d;
                return true;
            }
            return false;
        }

        private static bool BooleanParse(string value, ref object o)
        {
            switch(value.ToUpper())
            {
                case "1":
                case "YES":
                case "T":
                case "TRUE":
                    o = true;
                    return true;
                case "0":
                case "NO":
                case "F":
                case "FALSE":
                    o = false;
                    return true;
                default:
                    return false;
            }
        }
    }
}
