using System;
using System.Collections.Generic;
using System.IO;

namespace CsvToSqlInsertQueries.Engine
{
    public class DataToQueryFromCsv
    {
        public IList<string> DataToQuery(string table, string delimiter)
        {
            var importer = new CsvImporter(new Uri(@"C:\Users\Administrator\Desktop\DB_To_Import"));

            var result = importer.ImportCsv(table + ".csv");

            var columns = result[0];
            var splitColumns = columns.Split(',');
            result.RemoveAt(0);
            var values = result;

            var importedCsv = new ImportedCsv
            {
                Columns = splitColumns, 
                Rows = values
            };

            var queryGenerator = new InsertQueryGenerator();
            var queries = queryGenerator.GenerateInsertQueries(table, delimiter, importedCsv.Columns, importedCsv.Rows);

            return queries;
        }
    }
}
