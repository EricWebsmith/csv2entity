using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
            ImdbCsv[] imdbs = CsvContext.ReadFile<ImdbCsv>("imdb.csv");
            Assert.AreEqual(8, imdbs[3].rating);
            Assert.AreEqual("Adventure,Comedy,Drama", imdbs[8].genres);
            Assert.AreEqual("Interstellar", imdbs[50].title);
            //linux removes \r 
            Assert.AreEqual("Comedy,\r\nDrama,\r\nMusic".Replace("\r", ""), imdbs[3].genres.Replace("\r", ""));

            Assert.AreEqual("In 1862, Amsterdam Vallon returns to the Five Points area of \"New York\" City seeking revenge against Bill the Butcher, his father's killer.", imdbs[10].summary);
        }

        [TestMethod]
        public void ReadWriteTest()
        {
            var items = Ezfx.Csv.CsvContext.ReadFile<ImdbCsv>("imdb.csv");
            var newfile = Guid.NewGuid().ToString();
            Ezfx.Csv.CsvContext.WriteFile(newfile, items);
            var newItems = Ezfx.Csv.CsvContext.ReadFile<ImdbCsv>(newfile);
            Assert.AreEqual(items.Length, newItems.Length);
            Assert.AreEqual(items[0].author, newItems[0].author);
            Assert.AreEqual(items[0].chinese_name, newItems[0].chinese_name);
            Assert.AreEqual(items[0].country, newItems[0].country);
            Assert.AreEqual(items[0].end_year, newItems[0].end_year);
            Assert.AreEqual(items[0].genres, newItems[0].genres);
            Assert.AreEqual(items[0].poster, newItems[0].poster);
            Assert.AreEqual(items[0].published, newItems[0].published);
            Assert.AreEqual(items[0].rating, newItems[0].rating);
            Assert.AreEqual(items[0].start_year, newItems[0].start_year);
            Assert.AreEqual(items[0].summary, newItems[0].summary);
            Assert.AreEqual(items[0].title, newItems[0].title);
            Assert.AreEqual(items[0].video_poster, newItems[0].video_poster);
            Assert.AreEqual(items[0].video_url, newItems[0].video_url);
            File.Delete(newfile);
        }
    }
}
