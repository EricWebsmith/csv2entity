using Ezfx.Csv;

namespace Cars.CS
{

    [CsvObject(CodePage = 936, Description = "", HasHeader = true, Name = "", MappingType = CsvMappingType.Title, Delimiter = ",")]
    public class CarCsv
    {

        /// <summary>
        /// 0, Year
        /// </summary>
        [SystemCsvColumn(Name = "Year", Ordinal = 0, Alias = "")]
        public string Year { get; set; }


        /// <summary>
        /// 1, Make
        /// </summary>
        [SystemCsvColumn(Name = "Make", Ordinal = 1, Alias = "")]
        public string Make { get; set; }


        /// <summary>
        /// 2, Model
        /// </summary>
        [SystemCsvColumn(Name = "Model", Ordinal = 2, Alias = "")]
        public string Model { get; set; }


        /// <summary>
        /// 3, Length
        /// </summary>
        [SystemCsvColumn(Name = "Length", Ordinal = 3, Alias = "")]
        public string Length { get; set; }


    }
}
