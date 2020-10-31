using System.Collections.Generic;

namespace CsvToSqlInsertQueries.Engine
{
    public class ImportedCsv
    {
        public IList<string> Columns { get; set; }
        public IList<string> Rows { get; set; }
    }
}
