using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezfx.Csv.Tester
{
    //Year,Make,Model,Length
    [CsvObject(CodePage=936,Description="",HasHeader=true,MappingType=CsvMappingType.Order)]
    public class CarCsv
    {
        /// <summary>
        /// Year
        /// </summary>
        [SystemCsvColumn(Name = "Year", Alias = "Yr", Ordinal = 0)]
        public string Year { get; set; }
        [SystemCsvColumn(Name = "Make", Ordinal = 1)]
        public string Make { get; set; }
        [SystemCsvColumn(Name = "Model", Ordinal = 2)]
        public string Model { get; set; }
        [SystemCsvColumn(Name = "Length", Ordinal = 3)]
        public string Length { get; set; }
    }
}
