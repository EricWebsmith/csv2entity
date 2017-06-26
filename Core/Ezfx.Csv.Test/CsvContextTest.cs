using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ezfx.Csv.Test
{
    [TestClass]
    public class CsvContextTest
    {
        [TestMethod]
        public void GetFieldsTest()
        {
            string line = "5-Apr-2012,44526880,FOREIGN EXCHANGE - PURCHASE,49000,22250114,IDR,\"77,553,252.00\",\"9,090.00\",5-Apr-2012";
            string delimiter = ",";
            string[] arr=  CsvContext.GetFields(line, delimiter);
            Assert.AreEqual(arr.Length, 9);
            Assert.AreEqual(arr[6], "77,553,252.00");
            Assert.AreEqual(arr[7], "9,090.00");
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
