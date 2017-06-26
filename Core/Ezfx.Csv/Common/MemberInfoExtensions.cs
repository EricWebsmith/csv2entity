using System;
using System.Linq;
using System.Reflection;

namespace Ezfx.Csv
{
    public static class MemberInfoExtensions
    {
        public static T GetAttribute<T>(this MemberInfo pi)
            where T : Attribute
        {
            return GetAttribute<T>(pi,false);
        }

        public static T GetAttribute<T>(this MemberInfo pi, bool inherit)
            where T :Attribute
        {
            object[] objs = pi.GetCustomAttributes(typeof(T), inherit);
            if (objs.Length != 1)
            {
                return null;
            }
            return (T)objs.First();
        }
    }
}
