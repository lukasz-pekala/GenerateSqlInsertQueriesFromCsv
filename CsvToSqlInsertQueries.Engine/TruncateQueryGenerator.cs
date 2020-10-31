namespace CsvToSqlInsertQueries.Engine
{
    public class TruncateQueryGenerator
    {
        public string GenerateTruncateTableQuery(string tableName)
        {
            return $"TRUNCATE TABLE {tableName}";
        }
    }
}