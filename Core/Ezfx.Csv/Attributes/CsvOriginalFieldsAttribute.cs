using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezfx.Csv
{
    /// <summary>
    /// can only be adorned to string[] property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvOriginalFieldsAttribute : Attribute { }
}
