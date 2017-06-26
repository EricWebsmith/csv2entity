using System;

namespace Ezfx.Csv
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CsvObjectAttribute : Attribute
    {
        public int CodePage { get; set; }
        public bool HasHeader { get; set; }
        /// <summary>
        /// For Business Users
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// For Table/Sheet Name
        /// </summary>
        public string Name { get; set; }
        public string Delimiter { get; set; }
        public CsvMappingType MappingType { get; set; }
    }
}
