using System;
using Ezfx.Csv;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Languages
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IEnumerable<LanguagePopularity> lans = CsvContext.ReadFile<LanguagePopularity>("Languages.csv").OrderBy(l => l.Position);
            foreach (LanguagePopularity lp in lans)
            {
                Console.WriteLine(lp.Position + "\t" + lp.ProgrammingLanguage + "\t" + lp.Ratings.ToString("#.##%") + "\t" + (lp.Delta.HasValue ? lp.Delta.Value.ToString("#.##%") : ""));
            }
            Console.ReadLine();
        }
    }
}
