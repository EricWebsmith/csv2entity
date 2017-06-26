using Ezfx.Csv;
using System;

namespace Languages
{

    [CsvObject(CodePage = 936, Description = "", HasHeader = true, Name = "")]
    public class LanguagePopularity
    {
        /// <summary>
        /// 0, Position
        /// </summary>
        [SystemCsvColumn(Name = "Position", Ordinal = 0, Alias = "")]
        public int Position { get; set; }

        /// <summary>
        /// 1, Programming Language
        /// </summary>
        [SystemCsvColumn(Name = "Programming Language", Ordinal = 1, Alias = "")]
        public string ProgrammingLanguage { get; set; }

        /// <summary>
        /// 2, Ratings
        /// </summary>
        [SystemCsvColumn(Name = "Ratings", Ordinal = 2, Alias = "")]
        public float Ratings { get; set; }

        /// <summary>
        /// 3, Delta
        /// </summary>
        [SystemCsvColumn(Name = "Delta", Ordinal = 3, Alias = "")]
        public Nullable<float> Delta { get; set; }

        /// <summary>
        /// 4, Status
        /// </summary>
        [SystemCsvColumn(Name = "Status", Ordinal = 4, Alias = "")]
        public string Status { get; set; }

    }
}
