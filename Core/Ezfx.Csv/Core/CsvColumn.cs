using System.Collections.ObjectModel;
using System.Data;

namespace Ezfx.Csv
{
    public class CsvColumn
    {

        public CsvColumn()
        {

        }

        public CsvColumn(DataColumn col)
        {
            this.Name = col.ColumnName;
            this.Ordinal = col.Ordinal;
            this.Alias = string.Empty;
            this.Description = string.Empty;
            this.IsRequired = false;
        }

        public string Name { get; set; }
        public int Ordinal { get; set; }
        public string Alias { get; set; }

        public string Description { get; set; }
        public bool IsRequired { get; set; }
    }

    public class CsvColumnCollection : ObservableCollection<CsvColumn>
    {
        
    }
}
