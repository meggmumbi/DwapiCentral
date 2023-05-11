using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence
{
    public class SqlBulkImporter<T>
    {
        private readonly string _connectionString;

        public SqlBulkImporter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task BulkInsertAsync(IEnumerable<T> entities, string tableName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var table = new DataTable();

                        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                        foreach (var property in properties)
                        {
                            table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                        }

                        foreach (var entity in entities)
                        {
                            var row = table.NewRow();

                            foreach (var property in properties)
                            {
                                row[property.Name] = property.GetValue(entity) ?? DBNull.Value;
                            }

                            table.Rows.Add(row);
                        }

                        using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                        {
                            bulkCopy.DestinationTableName = tableName;

                            foreach (var property in properties)
                            {
                                bulkCopy.ColumnMappings.Add(property.Name, property.Name);
                            }

                            await bulkCopy.WriteToServerAsync(table);

                        }
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Bulk insert failed");
                    }
                }
            }
        }
    }
}
