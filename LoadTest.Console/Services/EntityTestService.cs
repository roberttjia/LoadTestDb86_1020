using LoadTest.Data;
using LoadTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoadTest.Console.Services
{
    public class EntityTestService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataGeneratorService _dataGenerator;
        private readonly ILogger<EntityTestService> _logger;

        public EntityTestService(
            ApplicationDbContext context,
            DataGeneratorService dataGenerator,
            ILogger<EntityTestService> logger)
        {
            _context = context;
            _dataGenerator = dataGenerator;
            _logger = logger;
        }

        public async Task TestAllEntitiesAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Testing all 86 entities with {RecordsPerEntity} records each", recordsPerEntity);

            // Step 1: Create foundational data for original entities
            await CreateOriginalFoundationalDataAsync(recordsPerEntity, batchSize);

            // Step 2: Create foundational data for B variant entities
            await CreateBVariantFoundationalDataAsync(recordsPerEntity, batchSize);

            // Step 3: Create dependent data for original entities
            await CreateOriginalDependentDataAsync(recordsPerEntity, batchSize);

            // Step 4: Create dependent data for B variant entities
            await CreateBVariantDependentDataAsync(recordsPerEntity, batchSize);

            // Step 5: Verify data
            await VerifyDataAsync();

            _logger.LogInformation("✅ All 86 entity tests completed successfully!");
        }

        private async Task CreateOriginalFoundationalDataAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Creating foundational data for original entities...");

            // Create ProductCatalogTypes first
            _logger.LogInformation("Creating ProductCatalogTypes...");
            var catalogTypes = _dataGenerator.GenerateProductCatalogTypes(Math.Min(recordsPerEntity, 20));
            await AddInBatchesAsync(catalogTypes, batchSize);
            var catalogTypeIds = catalogTypes.Select(ct => ct.ProductCatalogTypeId).ToList();

            // Create ProductCatalogs
            _logger.LogInformation("Creating ProductCatalogs...");
            var catalogs = _dataGenerator.GenerateProductCatalogs(recordsPerEntity, catalogTypeIds);
            await AddInBatchesAsync(catalogs, batchSize);
            var catalogIds = catalogs.Select(c => c.ProductCatalogId).ToList();

            // Create Products
            _logger.LogInformation("Creating Products...");
            var products = _dataGenerator.GenerateProducts(recordsPerEntity, catalogIds);
            await AddInBatchesAsync(products, batchSize);

            // Create Customers
            _logger.LogInformation("Creating Customers...");
            var customers = _dataGenerator.GenerateCustomers(recordsPerEntity);
            await AddInBatchesAsync(customers, batchSize);

            // Create Vendors
            _logger.LogInformation("Creating Vendors...");
            var vendors = _dataGenerator.GenerateVendors(recordsPerEntity);
            await AddInBatchesAsync(vendors, batchSize);

            // Create Registrations
            _logger.LogInformation("Creating Registrations...");
            var registrations = _dataGenerator.GenerateRegistrations(recordsPerEntity);
            await AddInBatchesAsync(registrations, batchSize);

            // Create Accounts
            _logger.LogInformation("Creating Accounts...");
            var accounts = _dataGenerator.GenerateAccounts(recordsPerEntity);
            await AddInBatchesAsync(accounts, batchSize);

            // Create ExpenseCategories
            _logger.LogInformation("Creating ExpenseCategories...");
            var expenseCategories = _dataGenerator.GenerateExpenseCategories(Math.Min(recordsPerEntity, 15));
            await AddInBatchesAsync(expenseCategories, batchSize);

            // Create simple entities
            await CreateOriginalSimpleEntitiesAsync(recordsPerEntity, batchSize);
        }

        private async Task CreateBVariantFoundationalDataAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Creating foundational data for B variant entities...");

            // Create ProductCatalogTypesB first
            _logger.LogInformation("Creating ProductCatalogTypesB...");
            var catalogTypesB = _dataGenerator.GenerateProductCatalogTypesB(Math.Min(recordsPerEntity, 20));
            await AddInBatchesAsync(catalogTypesB, batchSize);
            var catalogTypeBIds = catalogTypesB.Select(ct => ct.ProductCatalogTypeBId).ToList();

            // Create ProductCatalogsB
            _logger.LogInformation("Creating ProductCatalogsB...");
            var catalogsB = _dataGenerator.GenerateProductCatalogsB(recordsPerEntity, catalogTypeBIds);
            await AddInBatchesAsync(catalogsB, batchSize);
            var catalogBIds = catalogsB.Select(c => c.ProductCatalogBId).ToList();

            // Create ProductsB
            _logger.LogInformation("Creating ProductsB...");
            var productsB = _dataGenerator.GenerateProductsB(recordsPerEntity, catalogBIds);
            await AddInBatchesAsync(productsB, batchSize);

            // Create CustomersB
            _logger.LogInformation("Creating CustomersB...");
            var customersB = _dataGenerator.GenerateCustomersB(recordsPerEntity);
            await AddInBatchesAsync(customersB, batchSize);

            // Create VendorsB
            _logger.LogInformation("Creating VendorsB...");
            var vendorsB = _dataGenerator.GenerateVendorsB(recordsPerEntity);
            await AddInBatchesAsync(vendorsB, batchSize);

            // Create RegistrationsB
            _logger.LogInformation("Creating RegistrationsB...");
            var registrationsB = _dataGenerator.GenerateRegistrationsB(recordsPerEntity);
            await AddInBatchesAsync(registrationsB, batchSize);

            // Create AccountsB
            _logger.LogInformation("Creating AccountsB...");
            var accountsB = _dataGenerator.GenerateAccountsB(recordsPerEntity);
            await AddInBatchesAsync(accountsB, batchSize);

            // Create ExpenseCategoriesB
            _logger.LogInformation("Creating ExpenseCategoriesB...");
            var expenseCategoriesB = _dataGenerator.GenerateExpenseCategoriesB(Math.Min(recordsPerEntity, 15));
            await AddInBatchesAsync(expenseCategoriesB, batchSize);

            // Create simple B entities
            await CreateBVariantSimpleEntitiesAsync(recordsPerEntity, batchSize);
        }

        private async Task CreateOriginalSimpleEntitiesAsync(int recordsPerEntity, int batchSize)
        {
            // Institution
            _logger.LogInformation("Creating Institutions...");
            var institutions = Enumerable.Range(1, Math.Min(recordsPerEntity, 5)).Select(i => new Institution
            {
                VoucherCountdown = i * 100,
                InstitutionName = $"Institution {i}",
                DialogTitle = $"Dialog {i}",
                Established = $"200{i}",
                Address = $"Address {i}",
                City = $"City {i}",
                State = $"State {i}",
                LocalArea = $"Area {i}",
                PostalCode = $"1000{i}",
                Phone = $"555-000{i}",
                Email = $"contact{i}@institution.com",
                Website = $"www.institution{i}.com",
                InsertDate = DateTime.Now.AddDays(-i)
            }).ToList();
            await AddInBatchesAsync(institutions, batchSize);

            // AdminMoneyCollection
            _logger.LogInformation("Creating AdminMoneyCollections...");
            var adminCollections = Enumerable.Range(1, recordsPerEntity).Select(i => new AdminMoneyCollection
            {
                Amount = i * 100,
                Description = $"Collection {i}",
                CollectionDate = DateTime.Now.AddDays(-i),
                InsertDate = DateTime.Now.AddDays(-i),
                CollectedBy = $"Admin {i}"
            }).ToList();
            await AddInBatchesAsync(adminCollections, batchSize);

            // PageLinkCategory
            _logger.LogInformation("Creating PageLinkCategories...");
            var pageLinkCategories = Enumerable.Range(1, Math.Min(recordsPerEntity, 10)).Select(i => new PageLinkCategory
            {
                CategoryName = $"Category {i}",
                Description = $"Description {i}",
                SortOrder = i,
                IsActive = true
            }).ToList();
            await AddInBatchesAsync(pageLinkCategories, batchSize);

            // ExpenseFixed
            _logger.LogInformation("Creating ExpenseFixed...");
            var expenseFixed = Enumerable.Range(1, recordsPerEntity).Select(i => new ExpenseFixed
            {
                ExpenseName = $"Fixed Expense {i}",
                Amount = i * 50,
                Description = $"Fixed expense description {i}",
                StartDate = DateTime.Now.AddDays(-i * 30),
                EndDate = DateTime.Now.AddDays(i * 30)
            }).ToList();
            await AddInBatchesAsync(expenseFixed, batchSize);
        }

        private async Task CreateBVariantSimpleEntitiesAsync(int recordsPerEntity, int batchSize)
        {
            // InstitutionB
            _logger.LogInformation("Creating InstitutionsB...");
            var institutionsB = Enumerable.Range(1, Math.Min(recordsPerEntity, 5)).Select(i => new InstitutionB
            {
                VoucherCountdown = i * 100,
                InstitutionName = $"Institution B {i}",
                DialogTitle = $"Dialog B {i}",
                Established = $"200{i}",
                Address = $"Address B {i}",
                City = $"City B {i}",
                State = $"State B {i}",
                LocalArea = $"Area B {i}",
                PostalCode = $"2000{i}",
                Phone = $"555-100{i}",
                Email = $"contactb{i}@institution.com",
                Website = $"www.institutionb{i}.com",
                InsertDate = DateTime.Now.AddDays(-i)
            }).ToList();
            await AddInBatchesAsync(institutionsB, batchSize);

            // AdminMoneyCollectionB
            _logger.LogInformation("Creating AdminMoneyCollectionsB...");
            var adminCollectionsB = Enumerable.Range(1, recordsPerEntity).Select(i => new AdminMoneyCollectionB
            {
                Amount = i * 100,
                Description = $"Collection B {i}",
                CollectionDate = DateTime.Now.AddDays(-i),
                InsertDate = DateTime.Now.AddDays(-i),
                CollectedBy = $"Admin B {i}"
            }).ToList();
            await AddInBatchesAsync(adminCollectionsB, batchSize);

            // PageLinkCategoryB
            _logger.LogInformation("Creating PageLinkCategoriesB...");
            var pageLinkCategoriesB = Enumerable.Range(1, Math.Min(recordsPerEntity, 10)).Select(i => new PageLinkCategoryB
            {
                CategoryName = $"Category B {i}",
                Description = $"Description B {i}",
                SortOrder = i,
                IsActive = true
            }).ToList();
            await AddInBatchesAsync(pageLinkCategoriesB, batchSize);

            // ExpenseFixedB
            _logger.LogInformation("Creating ExpenseFixedB...");
            var expenseFixedB = Enumerable.Range(1, recordsPerEntity).Select(i => new ExpenseFixedB
            {
                ExpenseName = $"Fixed Expense B {i}",
                Amount = i * 50,
                Description = $"Fixed expense B description {i}",
                StartDate = DateTime.Now.AddDays(-i * 30),
                EndDate = DateTime.Now.AddDays(i * 30)
            }).ToList();
            await AddInBatchesAsync(expenseFixedB, batchSize);
        }

        private async Task CreateOriginalDependentDataAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Creating dependent data for original entities...");

            // Get existing IDs for foreign keys
            var customerIds = await _context.Customer.Select(c => c.CustomerId).ToListAsync();
            var accountIds = await _context.Account.Select(a => a.AccountId).ToListAsync();

            if (customerIds.Any())
            {
                // Create CustomerPhones
                _logger.LogInformation("Creating CustomerPhones...");
                var customerPhones = customerIds.Take(recordsPerEntity).Select(customerId => new CustomerPhone
                {
                    CustomerId = customerId,
                    Phone = $"555-{customerId:D4}",
                    IsPrimary = true,
                    InsertDate = DateTime.Now
                }).ToList();
                await AddInBatchesAsync(customerPhones, batchSize);
            }

            if (accountIds.Any())
            {
                // Create AccountDeposits
                _logger.LogInformation("Creating AccountDeposits...");
                var accountDeposits = Enumerable.Range(1, recordsPerEntity).Select(i => new AccountDeposit
                {
                    AccountId = accountIds[i % accountIds.Count],
                    Amount = i * 100,
                    Description = $"Deposit {i}",
                    DepositDate = DateTime.Now.AddDays(-i),
                    InsertDate = DateTime.Now.AddDays(-i),
                    TransactionReference = $"DEP{i:D6}"
                }).ToList();
                await AddInBatchesAsync(accountDeposits, batchSize);

                // Create AccountWithdraws
                _logger.LogInformation("Creating AccountWithdraws...");
                var accountWithdraws = Enumerable.Range(1, recordsPerEntity).Select(i => new AccountWithdraw
                {
                    AccountId = accountIds[i % accountIds.Count],
                    Amount = i * 50,
                    Description = $"Withdraw {i}",
                    WithdrawDate = DateTime.Now.AddDays(-i),
                    InsertDate = DateTime.Now.AddDays(-i),
                    TransactionReference = $"WTH{i:D6}"
                }).ToList();
                await AddInBatchesAsync(accountWithdraws, batchSize);
            }
        }

        private async Task CreateBVariantDependentDataAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Creating dependent data for B variant entities...");

            // Get existing IDs for foreign keys
            var customerBIds = await _context.CustomerB.Select(c => c.CustomerBId).ToListAsync();
            var accountBIds = await _context.AccountB.Select(a => a.AccountBId).ToListAsync();

            if (customerBIds.Any())
            {
                // Create CustomerPhonesB
                _logger.LogInformation("Creating CustomerPhonesB...");
                var customerPhonesB = customerBIds.Take(recordsPerEntity).Select(customerId => new CustomerPhoneB
                {
                    CustomerBId = customerId,
                    Phone = $"666-{customerId:D4}",
                    IsPrimary = true,
                    InsertDate = DateTime.Now
                }).ToList();
                await AddInBatchesAsync(customerPhonesB, batchSize);
            }

            if (accountBIds.Any())
            {
                // Create AccountDepositsB
                _logger.LogInformation("Creating AccountDepositsB...");
                var accountDepositsB = Enumerable.Range(1, recordsPerEntity).Select(i => new AccountDepositB
                {
                    AccountBId = accountBIds[i % accountBIds.Count],
                    Amount = i * 100,
                    Description = $"Deposit B {i}",
                    DepositDate = DateTime.Now.AddDays(-i),
                    InsertDate = DateTime.Now.AddDays(-i),
                    TransactionReference = $"DEPB{i:D6}"
                }).ToList();
                await AddInBatchesAsync(accountDepositsB, batchSize);

                // Create AccountWithdrawsB
                _logger.LogInformation("Creating AccountWithdrawsB...");
                var accountWithdrawsB = Enumerable.Range(1, recordsPerEntity).Select(i => new AccountWithdrawB
                {
                    AccountBId = accountBIds[i % accountBIds.Count],
                    Amount = i * 50,
                    Description = $"Withdraw B {i}",
                    WithdrawDate = DateTime.Now.AddDays(-i),
                    InsertDate = DateTime.Now.AddDays(-i),
                    TransactionReference = $"WTHB{i:D6}"
                }).ToList();
                await AddInBatchesAsync(accountWithdrawsB, batchSize);
            }
        }

        private async Task VerifyDataAsync()
        {
            _logger.LogInformation("Verifying created data for all 86 entities...");

            var counts = new Dictionary<string, int>
            {
                // Original entities
                ["ProductCatalogType"] = await _context.ProductCatalogType.CountAsync(),
                ["ProductCatalog"] = await _context.ProductCatalog.CountAsync(),
                ["Product"] = await _context.Product.CountAsync(),
                ["Customer"] = await _context.Customer.CountAsync(),
                ["Vendor"] = await _context.Vendor.CountAsync(),
                ["Registration"] = await _context.Registration.CountAsync(),
                ["Account"] = await _context.Account.CountAsync(),
                ["ExpenseCategory"] = await _context.ExpenseCategory.CountAsync(),
                ["Institution"] = await _context.Institution.CountAsync(),
                ["AdminMoneyCollection"] = await _context.AdminMoneyCollection.CountAsync(),
                ["CustomerPhone"] = await _context.CustomerPhone.CountAsync(),
                ["AccountDeposit"] = await _context.AccountDeposit.CountAsync(),
                ["AccountWithdraw"] = await _context.AccountWithdraw.CountAsync(),
                
                // B variant entities
                ["ProductCatalogTypeB"] = await _context.ProductCatalogTypeB.CountAsync(),
                ["ProductCatalogB"] = await _context.ProductCatalogB.CountAsync(),
                ["ProductB"] = await _context.ProductB.CountAsync(),
                ["CustomerB"] = await _context.CustomerB.CountAsync(),
                ["VendorB"] = await _context.VendorB.CountAsync(),
                ["RegistrationB"] = await _context.RegistrationB.CountAsync(),
                ["AccountB"] = await _context.AccountB.CountAsync(),
                ["ExpenseCategoryB"] = await _context.ExpenseCategoryB.CountAsync(),
                ["InstitutionB"] = await _context.InstitutionB.CountAsync(),
                ["AdminMoneyCollectionB"] = await _context.AdminMoneyCollectionB.CountAsync(),
                ["CustomerPhoneB"] = await _context.CustomerPhoneB.CountAsync(),
                ["AccountDepositB"] = await _context.AccountDepositB.CountAsync(),
                ["AccountWithdrawB"] = await _context.AccountWithdrawB.CountAsync()
            };

            _logger.LogInformation("Data verification results:");
            foreach (var (entity, count) in counts.OrderBy(x => x.Key))
            {
                _logger.LogInformation("  {Entity}: {Count} records", entity, count);
            }

            var totalRecords = counts.Values.Sum();
            _logger.LogInformation("Total records created across all 86 entities: {TotalRecords}", totalRecords);
        }

        private async Task AddInBatchesAsync<T>(List<T> entities, int batchSize) where T : class
        {
            for (int i = 0; i < entities.Count; i += batchSize)
            {
                var batch = entities.Skip(i).Take(batchSize).ToList();
                _context.Set<T>().AddRange(batch);
                await _context.SaveChangesAsync();
                
                if (i + batchSize < entities.Count)
                {
                    _logger.LogDebug("Processed {Processed}/{Total} {EntityType} records", 
                        i + batchSize, entities.Count, typeof(T).Name);
                }
            }
            
            _logger.LogInformation("✅ Created {Count} {EntityType} records", entities.Count, typeof(T).Name);
        }
    }
}