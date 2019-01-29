using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Ezfx.Csv.Test
{
    [CsvObject(Delimiter = "\t", HasHeader = true)]
    class CarCsv
    {
        [SystemCsvColumn(Ordinal = 0)]
        public string Name { get; set; }
        [SystemCsvColumn(Ordinal = 1)]
        public int Year { get; set; }
        [SystemCsvColumn(Ordinal = 2)]
        public decimal Price { get; set; }
        [SystemCsvColumn(Ordinal = 3)]
        public DateTime ExpireDate { get; set; }
    }

    [TestClass]
    public class CsvContextTest
    {
        [TestMethod]
        public void GetFieldsSimpleTest()
        {
            string line = "12,34,FOREIGN EXCHANGE - PURCHASE,49000,22250114,IDR,77553252.00,9090.00,5-Apr-2012";
            string delimiter = ",";
            string[] arr = CsvContext.GetRecords(line, delimiter).First().ToArray();
            Assert.AreEqual(9, arr.Length);
            Assert.AreEqual("77553252.00", arr[6]);
            Assert.AreEqual("9090.00", arr[7]);
        }

        [TestMethod]
        public void GetFieldsTest()
        {
            string line = "5-Apr-2012,44526880,FOREIGN EXCHANGE - PURCHASE,49000,22250114,IDR,\"77,553,252.00\",\"9,090.00\",5-Apr-2012";
            string delimiter = ",";
            string[] arr=  CsvContext.GetRecords(line, delimiter).First().ToArray();
            Assert.AreEqual(9,arr.Length);
            Assert.AreEqual("77,553,252.00",arr[6]);
            Assert.AreEqual("9,090.00",arr[7]);
        }

        [TestMethod]
        public void GetFieldsWithLineBreakTest()
        {
            string line = "5-Apr-2012,44526880,FOREIGN EXCHANGE - PURCHASE,49000,22250114,IDR,\"77\r\n,553,252.00\",\"9,090.00\",5-Apr-2012";
            string delimiter = ",";
            string[] arr = CsvContext.GetFields(line, delimiter);
            Assert.AreEqual(9, arr.Length);
            Assert.AreEqual("77\r\n,553,252.00", arr[6]);
            Assert.AreEqual("9,090.00", arr[7]);
        }

        [TestMethod]
        public void ReadImdbCsvTest()
        {
            ImdbCsv[] imdbs = CsvContext.ReadFile<ImdbCsv>("imdb.csv");
            Assert.AreEqual(8, imdbs[3].rating);
            Assert.AreEqual("Adventure,Comedy,Drama",imdbs[8].genres);
            Assert.AreEqual("Interstellar", imdbs[50].title);
            Assert.AreEqual("Comedy,\r\nDrama,\r\nMusic".Replace('\r','r'), imdbs[3].genres.Replace('\r', 'r'));
            Assert.AreEqual("Comedy,\r\nDrama,\r\nMusic", imdbs[3].genres);
            Assert.AreEqual("In 1862, Amsterdam Vallon returns to the Five Points area of \"New York\" City seeking revenge against Bill the Butcher, his father's killer.",imdbs[10].summary);
        }

        [TestMethod]
        public void Export()
        {
            CarCsv[] cars = new CarCsv[]
            {
                new CarCsv{Name="Benz",Price=52000.00m,Year=2012,ExpireDate=new DateTime(2020,5,5)},
                new CarCsv{Name="BMW",Price=152000.233m,Year=2011,ExpireDate=new DateTime(2020,2,15)},
                new CarCsv{Name="Tata",Price=85000.00m,Year=2000,ExpireDate=new DateTime(2020,12,5)}
            };

            string content = CsvContext.GetContent(cars, null);
            Debug.Print(content);
        }
    }
}
