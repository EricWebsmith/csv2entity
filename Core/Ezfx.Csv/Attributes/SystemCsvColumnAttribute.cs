using System;

namespace Ezfx.Csv
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SystemCsvColumnAttribute : Attribute
    {

        private CsvColumn _Column = new CsvColumn();
        public CsvColumn Column
        {
            get
            {
                return _Column;
            }
        }

        public string Name
        {
            get
            {
                return Column.Name;
            }
            set
            {
                Column.Name = value;
            }
        }

        public int Ordinal
        {
            get
            {
                return Column.Ordinal;
            }
            set
            {
                Column.Ordinal = value;
            }
        }

        public string Alias
        {
            get
            {
                return Column.Alias;
            }
            set
            {
                Column.Alias = value;
            }
        }
    }
}
