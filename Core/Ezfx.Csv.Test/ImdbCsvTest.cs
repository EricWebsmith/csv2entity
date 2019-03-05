using Ezfx.Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ezfx.Csv.Test
{

    [CsvObject(CodePage = 1252, Description = "", HasHeader = true, Name = "", MappingType = CsvMappingType.Title, Delimiter = ",")]
    public class ImdbCsv
    {

        /// <summary>
        /// 0, author
        /// </summary>
        [SystemCsvColumn(Name = "author", Ordinal = 0, Alias = "")]
        public string author { get; set; }


        /// <summary>
        /// 1, chinese_name
        /// </summary>
        [SystemCsvColumn(Name = "chinese_name", Ordinal = 1, Alias = "")]
        public string chinese_name { get; set; }


        /// <summary>
        /// 2, country
        /// </summary>
        [SystemCsvColumn(Name = "country", Ordinal = 2, Alias = "")]
        public string country { get; set; }


        /// <summary>
        /// 3, end_year
        /// </summary>
        [SystemCsvColumn(Name = "end_year", Ordinal = 3, Alias = "")]
        public string end_year { get; set; }


        /// <summary>
        /// 4, genres
        /// </summary>
        [SystemCsvColumn(Name = "genres", Ordinal = 4, Alias = "")]
        public string genres { get; set; }


        /// <summary>
        /// 5, poster
        /// </summary>
        [SystemCsvColumn(Name = "poster", Ordinal = 5, Alias = "")]
        public string poster { get; set; }


        /// <summary>
        /// 6, published
        /// </summary>
        [SystemCsvColumn(Name = "published", Ordinal = 6, Alias = "")]
        public string published { get; set; }


        /// <summary>
        /// 7, rating
        /// </summary>
        [SystemCsvColumn(Name = "rating", Ordinal = 7, Alias = "")]
        public float rating { get; set; }


        /// <summary>
        /// 8, start_year
        /// </summary>
        [SystemCsvColumn(Name = "start_year", Ordinal = 8, Alias = "")]
        public string start_year { get; set; }


        /// <summary>
        /// 9, summary
        /// </summary>
        [SystemCsvColumn(Name = "summary", Ordinal = 9, Alias = "")]
        public string summary { get; set; }


        /// <summary>
        /// 10, title
        /// </summary>
        [SystemCsvColumn(Name = "title", Ordinal = 10, Alias = "")]
        public string title { get; set; }


        /// <summary>
        /// 11, video_poster
        /// </summary>
        [SystemCsvColumn(Name = "video_poster", Ordinal = 11, Alias = "")]
        public string video_poster { get; set; }


        /// <summary>
        /// 12, video_url
        /// </summary>
        [SystemCsvColumn(Name = "video_url", Ordinal = 12, Alias = "")]
        public string video_url { get; set; }


    }

    [TestClass]
    public class ImdbCsvTest
    {
        [TestMethod]
        public void ReadTest()
        {
            var imdbItems = Ezfx.Csv.CsvContext.ReadFile<ImdbCsv>("imdb.csv");
        }
    }
}
