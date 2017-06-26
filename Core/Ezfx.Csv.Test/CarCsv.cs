using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezfx.Csv.Test
{
    [CsvObject(Delimiter="\t",HasHeader=true)]
    class CarCsv
    {
        [SystemCsvColumn(Ordinal=0)]
        public string Name { get; set; }
        [SystemCsvColumn(Ordinal = 1)]
        public int Year { get; set; }
        [SystemCsvColumn(Ordinal = 2)]
        public decimal Price { get; set; }
        [SystemCsvColumn(Ordinal = 3)]
        public DateTime ExpireDate { get; set; }
    }
}
