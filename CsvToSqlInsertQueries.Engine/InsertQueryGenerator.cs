using System.Collections.Generic;

namespace CsvToSqlInsertQueries.Engine
{
    public class InsertQueryGenerator
    {
        public IList<string> GenerateInsertQueries(string tableName, string delimiter, IList<string> columns, IList<string> rows)
        {
            var results = new List<string>();

            var commaSeparatedColumns = GenerateCommaSeparatedColumns(columns);

            foreach (var row in rows)
            {
                var commaSeparatedValues = GenerateCommaSeparatedValues(row);

                results.Add($"INSERT INTO {tableName}({commaSeparatedColumns}) VALUES({commaSeparatedValues});");
            }

            return results;
        }

        private static string GenerateCommaSeparatedValues(string row)
        {
            string rowPart = string.Empty;

            var splitRow = row.Split(',');
            //if (columns.Count != rows.Count)
            //    throw new InvalidOperationException("columns.Count != rows.Count");
            foreach (var split in splitRow)
            {
                rowPart += $"'{split}', ";
            }

            rowPart = rowPart.Substring(0, rowPart.Length - 2);
            return rowPart;
        }

        private static string GenerateCommaSeparatedColumns(IList<string> columns)
        {
            var columnPart = string.Empty;
            foreach (var column in columns)
            {
                columnPart += $"\"{column}\", ";
            }

            columnPart = columnPart.Substring(0, columnPart.Length - 2);
            return columnPart;
        }
    }
}