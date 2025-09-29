using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoadTest.Data
{
    public class DatabaseVerify
    {
        public static async Task<int> Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            // Setup logging
            using var loggerFactory = LoggerFactory.Create(builder =>
                builder.AddConsole().SetMinimumLevel(LogLevel.Information));
            var logger = loggerFactory.CreateLogger<DatabaseVerify>();

            try
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                logger.LogInformation("Testing connection to: {ConnectionString}", MaskPassword(connectionString));

                // Test connection to master to list databases
                var builder = new SqlConnectionStringBuilder(connectionString);
                var masterConnectionString = new SqlConnectionStringBuilder(connectionString)
                {
                    InitialCatalog = "master"
                }.ToString();

                logger.LogInformation("Connecting to master database to list all databases...");
                using var masterConnection = new SqlConnection(masterConnectionString);
                await masterConnection.OpenAsync();

                // List all databases
                var listDbSql = "SELECT name FROM sys.databases WHERE name LIKE 'LoadTest%' ORDER BY name";
                using var listCommand = new SqlCommand(listDbSql, masterConnection);
                using var reader = await listCommand.ExecuteReaderAsync();

                logger.LogInformation("LoadTest databases found:");
                var foundDatabases = new List<string>();
                while (await reader.ReadAsync())
                {
                    var dbName = reader.GetString(0);
                    foundDatabases.Add(dbName);
                    logger.LogInformation("  - {DatabaseName}", dbName);
                }

                if (!foundDatabases.Any())
                {
                    logger.LogWarning("No LoadTest databases found!");
                    return 1;
                }

                // Test connection to our specific database
                logger.LogInformation("Testing connection to LoadTestDb86_1020...");
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                logger.LogInformation("✅ Successfully connected to LoadTestDb86_1020");

                // Count tables
                var countTablesSql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                using var countCommand = new SqlCommand(countTablesSql, connection);
                var tableCount = await countCommand.ExecuteScalarAsync();
                logger.LogInformation("✅ Found {TableCount} tables in LoadTestDb86_1020", tableCount);

                // List some table names
                var listTablesSql = @"
                    SELECT TOP 10 TABLE_NAME 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_TYPE = 'BASE TABLE' 
                    ORDER BY TABLE_NAME";
                using var tablesCommand = new SqlCommand(listTablesSql, connection);
                using var tablesReader = await tablesCommand.ExecuteReaderAsync();

                logger.LogInformation("Sample tables:");
                while (await tablesReader.ReadAsync())
                {
                    var tableName = tablesReader.GetString(0);
                    logger.LogInformation("  - {TableName}", tableName);
                }

                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database verification failed");
                return 1;
            }
        }

        private static string MaskPassword(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                return "null";
            
            return connectionString.Replace("Password=Password12345!", "Password=***");
        }
    }
}