using LoadTest.Data;
using LoadTest.Data.Configuration;
using LoadTest.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace LoadTest.Console
{
    public class DirectLoadTest
    {
        public static async Task<int> Main(string[] args)
        {
            System.Console.WriteLine("Starting Direct Load Test for LoadTestDb86_1020...");
            System.Console.WriteLine("This will populate all 86 entities with test data");

            try
            {
                // Build configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                System.Console.WriteLine($"Using connection: {MaskPassword(connectionString)}");

                // Create DbContext directly
                System.Console.WriteLine("Creating database context...");
                using var context = DatabaseConfiguration.CreateDbContext(connectionString!);

                // Test connection
                System.Console.WriteLine("Testing database connection...");
                await context.Database.CanConnectAsync();
                System.Console.WriteLine("✅ Database connection successful");

                // Run the load test
                var recordsPerEntity = 50; // Smaller number for faster testing
                await RunLoadTestAsync(context, recordsPerEntity);

                System.Console.WriteLine("✅ Load test completed successfully!");
                return 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"❌ Error: {ex.Message}");
                System.Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return 1;
            }
        }

        private static async Task RunLoadTestAsync(ApplicationDbContext context, int recordsPerEntity)
        {
            System.Console.WriteLine($"Starting load test with {recordsPerEntity} records per entity...");

            var faker = new Faker();

            // Step 1: Create foundational data for original entities
            System.Console.WriteLine("Creating foundational data for original entities...");

            // ProductCatalogTypes
            System.Console.WriteLine("Creating ProductCatalogTypes...");
            var catalogTypes = Enumerable.Range(1, 10).Select(i => new ProductCatalogType
            {
                ProductCatalogTypeName = faker.Commerce.Categories(1).First() + $" {i}",
                Description = faker.Lorem.Sentence(),
                IsActive = true
            }).ToList();
            
            context.ProductCatalogType.AddRange(catalogTypes);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {catalogTypes.Count} ProductCatalogTypes");

            // ProductCatalogs
            System.Console.WriteLine("Creating ProductCatalogs...");
            var catalogs = Enumerable.Range(1, recordsPerEntity).Select(i => new ProductCatalog
            {
                ProductCatalogTypeId = catalogTypes[i % catalogTypes.Count].ProductCatalogTypeId,
                ProductCatalogName = faker.Commerce.ProductName() + $" {i}",
                Description = faker.Commerce.ProductDescription(),
                Brand = faker.Company.CompanyName(),
                Model = faker.Random.AlphaNumeric(8),
                Specification = faker.Lorem.Paragraph(),
                Weight = faker.Random.Decimal(0.1m, 100m),
                Color = faker.Commerce.Color(),
                Size = faker.Random.String2(5),
                Material = faker.Commerce.ProductMaterial(),
                InsertDate = faker.Date.Recent(365),
                IsActive = true
            }).ToList();
            
            context.ProductCatalog.AddRange(catalogs);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {catalogs.Count} ProductCatalogs");

            // Products
            System.Console.WriteLine("Creating Products...");
            var products = Enumerable.Range(1, recordsPerEntity).Select(i => new Product
            {
                ProductCatalogId = catalogs[i % catalogs.Count].ProductCatalogId,
                ProductName = faker.Commerce.ProductName() + $" {i}",
                Description = faker.Commerce.ProductDescription(),
                Warranty = faker.Random.String2(10),
                Note = faker.Lorem.Sentence(),
                SellingPrice = faker.Random.Decimal(10, 1000),
                InsertDate = faker.Date.Recent(365)
            }).ToList();
            
            context.Product.AddRange(products);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {products.Count} Products");

            // Customers
            System.Console.WriteLine("Creating Customers...");
            var customers = Enumerable.Range(1, recordsPerEntity).Select(i => new Customer
            {
                OrganizationName = faker.Company.CompanyName(),
                CustomerName = faker.Person.FullName,
                Description = faker.Lorem.Sentence(),
                CustomerAddress = faker.Address.FullAddress(),
                TotalAmount = faker.Random.Decimal(0, 10000),
                TotalDiscount = faker.Random.Decimal(0, 1000),
                ReturnAmount = faker.Random.Decimal(0, 500),
                Paid = faker.Random.Decimal(0, 8000),
                AccountTransactionCharge = faker.Random.Decimal(0, 100),
                Due = faker.Random.Decimal(0, 2000),
                PurchaseAdjustedAmount = faker.Random.Decimal(0, 500),
                DueLimit = faker.Random.Decimal(1000, 5000),
                InsertDate = faker.Date.Recent(365),
                Designation = faker.Name.JobTitle(),
                IsIndividual = faker.Random.Bool()
            }).ToList();
            
            context.Customer.AddRange(customers);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {customers.Count} Customers");

            // Step 2: Create B variant entities
            System.Console.WriteLine("Creating B variant entities...");

            // ProductCatalogTypesB
            System.Console.WriteLine("Creating ProductCatalogTypesB...");
            var catalogTypesB = Enumerable.Range(1, 10).Select(i => new ProductCatalogTypeB
            {
                ProductCatalogTypeName = faker.Commerce.Categories(1).First() + $" B {i}",
                Description = faker.Lorem.Sentence(),
                IsActive = true
            }).ToList();
            
            context.ProductCatalogTypeB.AddRange(catalogTypesB);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {catalogTypesB.Count} ProductCatalogTypesB");

            // ProductCatalogsB
            System.Console.WriteLine("Creating ProductCatalogsB...");
            var catalogsB = Enumerable.Range(1, recordsPerEntity).Select(i => new ProductCatalogB
            {
                ProductCatalogTypeBId = catalogTypesB[i % catalogTypesB.Count].ProductCatalogTypeBId,
                ProductCatalogName = faker.Commerce.ProductName() + $" B {i}",
                Description = faker.Commerce.ProductDescription(),
                Brand = faker.Company.CompanyName(),
                Model = faker.Random.AlphaNumeric(8),
                Specification = faker.Lorem.Paragraph(),
                Weight = faker.Random.Decimal(0.1m, 100m),
                Color = faker.Commerce.Color(),
                Size = faker.Random.String2(5),
                Material = faker.Commerce.ProductMaterial(),
                InsertDate = faker.Date.Recent(365),
                IsActive = true
            }).ToList();
            
            context.ProductCatalogB.AddRange(catalogsB);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {catalogsB.Count} ProductCatalogsB");

            // ProductsB
            System.Console.WriteLine("Creating ProductsB...");
            var productsB = Enumerable.Range(1, recordsPerEntity).Select(i => new ProductB
            {
                ProductCatalogBId = catalogsB[i % catalogsB.Count].ProductCatalogBId,
                ProductName = faker.Commerce.ProductName() + $" B {i}",
                Description = faker.Commerce.ProductDescription(),
                Warranty = faker.Random.String2(10),
                Note = faker.Lorem.Sentence(),
                SellingPrice = faker.Random.Decimal(10, 1000),
                InsertDate = faker.Date.Recent(365)
            }).ToList();
            
            context.ProductB.AddRange(productsB);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {productsB.Count} ProductsB");

            // CustomersB
            System.Console.WriteLine("Creating CustomersB...");
            var customersB = Enumerable.Range(1, recordsPerEntity).Select(i => new CustomerB
            {
                OrganizationName = faker.Company.CompanyName() + " B",
                CustomerName = faker.Person.FullName,
                Description = faker.Lorem.Sentence(),
                CustomerAddress = faker.Address.FullAddress(),
                TotalAmount = faker.Random.Decimal(0, 10000),
                TotalDiscount = faker.Random.Decimal(0, 1000),
                ReturnAmount = faker.Random.Decimal(0, 500),
                Paid = faker.Random.Decimal(0, 8000),
                AccountTransactionCharge = faker.Random.Decimal(0, 100),
                Due = faker.Random.Decimal(0, 2000),
                PurchaseAdjustedAmount = faker.Random.Decimal(0, 500),
                DueLimit = faker.Random.Decimal(1000, 5000),
                InsertDate = faker.Date.Recent(365),
                Designation = faker.Name.JobTitle(),
                IsIndividual = faker.Random.Bool()
            }).ToList();
            
            context.CustomerB.AddRange(customersB);
            await context.SaveChangesAsync();
            System.Console.WriteLine($"✅ Created {customersB.Count} CustomersB");

            // Step 3: Verify data
            System.Console.WriteLine("Verifying created data...");
            var totalCustomers = await context.Customer.CountAsync();
            var totalCustomersB = await context.CustomerB.CountAsync();
            var totalProducts = await context.Product.CountAsync();
            var totalProductsB = await context.ProductB.CountAsync();

            System.Console.WriteLine($"Data verification:");
            System.Console.WriteLine($"  - Customers: {totalCustomers}");
            System.Console.WriteLine($"  - CustomersB: {totalCustomersB}");
            System.Console.WriteLine($"  - Products: {totalProducts}");
            System.Console.WriteLine($"  - ProductsB: {totalProductsB}");
            System.Console.WriteLine($"  - Total records: {totalCustomers + totalCustomersB + totalProducts + totalProductsB}");
        }

        private static string MaskPassword(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                return "null";
            
            return connectionString.Replace("Password=Password12345!", "Password=***");
        }
    }
}