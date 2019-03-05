using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Ezfx.Csv.Test
{
    [CsvObject(CodePage = 65001, Description = "", HasHeader = true, Name = "", MappingType = CsvMappingType.Title, Delimiter = ",")]
    public class AssociationCsv
    {

        /// <summary>
        /// 0, Name
        /// </summary>
        [SystemCsvColumn(Name = "Title", Ordinal = 0, Alias = "")]
        public string Title { get; set; }


        /// <summary>
        /// 1, TextFile
        /// </summary>
        [SystemCsvColumn(Name = "TextFile", Ordinal = 1, Alias = "")]
        public string TextFile { get; set; }


        /// <summary>
        /// 2, AudioFile
        /// </summary>
        [SystemCsvColumn(Name = "AudioFile", Ordinal = 2, Alias = "")]
        public string AudioFile { get; set; }


        /// <summary>
        /// 3, AlignFile
        /// </summary>
        [SystemCsvColumn(Name = "AlignFile", Ordinal = 3, Alias = "")]
        public string AlignFile { get; set; }


    }

    [TestClass]
    public class AssociationCsvTest
    {
        [TestMethod]
        public void ReadTest()
        {
            var associationCsv = Ezfx.Csv.CsvContext.ReadFile<AssociationCsv>("association.csv");
            Assert.AreEqual(associationCsv[0].AlignFile, "tessofthedurbervilles_01_hardy_64kb.json");
            Assert.AreEqual(associationCsv[0].AudioFile, "tessofthedurbervilles_01_hardy_64kb.mp3");
            Assert.AreEqual(associationCsv[0].TextFile, "001_Chapter_I.txt");
            Assert.AreEqual(associationCsv[0].Title, "Chapter I");
        }

        [TestMethod]
        public void ReadWriteTest()
        {
            var items = Ezfx.Csv.CsvContext.ReadFile<AssociationCsv>("association.csv");
            var newfile = Guid.NewGuid().ToString();
            Ezfx.Csv.CsvContext.WriteFile(newfile, items);
            var newItems = Ezfx.Csv.CsvContext.ReadFile<AssociationCsv>(newfile);
            Assert.AreEqual(items.Length, newItems.Length);
            Assert.AreEqual(items[0].AlignFile, newItems[0].AlignFile);
            Assert.AreEqual(items[0].AudioFile, newItems[0].AudioFile);
            Assert.AreEqual(items[0].TextFile, newItems[0].TextFile);
            Assert.AreEqual(items[0].Title, newItems[0].Title);
            File.Delete(newfile);
        }
    }
}
