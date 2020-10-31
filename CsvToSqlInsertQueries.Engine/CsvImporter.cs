using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlInsertQueries.Engine
{
    public class CsvImporter
    {
        public string CsvDirectory { get; set; }

        public List<string> ImportCsv(string fileName)
        {
            var fileReadLineByLine = new List<string>();
            var fullPathToFile = Path.Combine(CsvDirectory, fileName);

            System.IO.StreamReader file =   
                new System.IO.StreamReader(fullPathToFile);  

            string line;  

            while((line = file.ReadLine()) != null)  
            {  
                fileReadLineByLine.Add(line);
            }

            return fileReadLineByLine;
        }
    }
}
