using LoadTest.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoadTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Original entities (43)
        public virtual DbSet<AdminMoneyCollection> AdminMoneyCollection { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountDeposit> AccountDeposit { get; set; }
        public virtual DbSet<AccountWithdraw> AccountWithdraw { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPhone> CustomerPhone { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<ExpenseFixed> ExpenseFixed { get; set; }
        public virtual DbSet<ExpenseTransportation> ExpenseTransportation { get; set; }
        public virtual DbSet<ExpenseTransportationList> ExpenseTransportationList { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<PageLink> PageLink { get; set; }
        public virtual DbSet<PageLinkAssign> PageLinkAssign { get; set; }
        public virtual DbSet<PageLinkCategory> PageLinkCategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCatalog> ProductCatalog { get; set; }
        public virtual DbSet<ProductCatalogType> ProductCatalogType { get; set; }
        public virtual DbSet<ProductDamaged> ProductDamaged { get; set; }
        public virtual DbSet<ProductLog> ProductLog { get; set; }
        public virtual DbSet<ProductStock> ProductStock { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseList> PurchaseList { get; set; }
        public virtual DbSet<PurchasePayment> PurchasePayment { get; set; }
        public virtual DbSet<PurchasePaymentList> PurchasePaymentList { get; set; }
        public virtual DbSet<PurchasePaymentReturnRecord> PurchasePaymentReturnRecord { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Selling> Selling { get; set; }
        public virtual DbSet<SellingExpense> SellingExpense { get; set; }
        public virtual DbSet<SellingAdjustment> SellingAdjustment { get; set; }
        public virtual DbSet<SellingList> SellingList { get; set; }
        public virtual DbSet<SellingPayment> SellingPayment { get; set; }
        public virtual DbSet<SellingPaymentList> SellingPaymentList { get; set; }
        public virtual DbSet<SellingPaymentReturnRecord> SellingPaymentReturnRecord { get; set; }
        public virtual DbSet<SellingPromiseDateMiss> SellingPromiseDateMiss { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceDevice> ServiceDevice { get; set; }
        public virtual DbSet<ServiceList> ServiceList { get; set; }
        public virtual DbSet<ServicePaymentList> ServicePaymentList { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Warranty> Warranty { get; set; }
        public virtual DbSet<VW_ExpenseWithTransportation> VW_ExpenseWithTransportation { get; set; }
        public virtual DbSet<VW_CapitalProfitReport> VW_CapitalProfitReport { get; set; }

        // B variant entities (44)
        public virtual DbSet<AdminMoneyCollectionB> AdminMoneyCollectionB { get; set; }
        public virtual DbSet<AccountB> AccountB { get; set; }
        public virtual DbSet<AccountDepositB> AccountDepositB { get; set; }
        public virtual DbSet<AccountWithdrawB> AccountWithdrawB { get; set; }
        public virtual DbSet<CustomerB> CustomerB { get; set; }
        public virtual DbSet<CustomerPhoneB> CustomerPhoneB { get; set; }
        public virtual DbSet<ExpenseB> ExpenseB { get; set; }
        public virtual DbSet<ExpenseFixedB> ExpenseFixedB { get; set; }
        public virtual DbSet<ExpenseTransportationB> ExpenseTransportationB { get; set; }
        public virtual DbSet<ExpenseTransportationListB> ExpenseTransportationListB { get; set; }
        public virtual DbSet<ExpenseCategoryB> ExpenseCategoryB { get; set; }
        public virtual DbSet<InstitutionB> InstitutionB { get; set; }
        public virtual DbSet<PageLinkB> PageLinkB { get; set; }
        public virtual DbSet<PageLinkAssignB> PageLinkAssignB { get; set; }
        public virtual DbSet<PageLinkCategoryB> PageLinkCategoryB { get; set; }
        public virtual DbSet<ProductB> ProductB { get; set; }
        public virtual DbSet<ProductCatalogB> ProductCatalogB { get; set; }
        public virtual DbSet<ProductCatalogTypeB> ProductCatalogTypeB { get; set; }
        public virtual DbSet<ProductDamagedB> ProductDamagedB { get; set; }
        public virtual DbSet<ProductLogB> ProductLogB { get; set; }
        public virtual DbSet<ProductStockB> ProductStockB { get; set; }
        public virtual DbSet<PurchaseB> PurchaseB { get; set; }
        public virtual DbSet<PurchaseListB> PurchaseListB { get; set; }
        public virtual DbSet<PurchasePaymentB> PurchasePaymentB { get; set; }
        public virtual DbSet<PurchasePaymentListB> PurchasePaymentListB { get; set; }
        public virtual DbSet<PurchasePaymentReturnRecordB> PurchasePaymentReturnRecordB { get; set; }
        public virtual DbSet<RegistrationB> RegistrationB { get; set; }
        public virtual DbSet<SellingB> SellingB { get; set; }
        public virtual DbSet<SellingExpenseB> SellingExpenseB { get; set; }
        public virtual DbSet<SellingAdjustmentB> SellingAdjustmentB { get; set; }
        public virtual DbSet<SellingListB> SellingListB { get; set; }
        public virtual DbSet<SellingPaymentB> SellingPaymentB { get; set; }
        public virtual DbSet<SellingPaymentListB> SellingPaymentListB { get; set; }
        public virtual DbSet<SellingPaymentReturnRecordB> SellingPaymentReturnRecordB { get; set; }
        public virtual DbSet<SellingPromiseDateMissB> SellingPromiseDateMissB { get; set; }
        public virtual DbSet<ServiceB> ServiceB { get; set; }
        public virtual DbSet<ServiceDeviceB> ServiceDeviceB { get; set; }
        public virtual DbSet<ServiceListB> ServiceListB { get; set; }
        public virtual DbSet<ServicePaymentListB> ServicePaymentListB { get; set; }
        public virtual DbSet<VendorB> VendorB { get; set; }
        public virtual DbSet<WarrantyB> WarrantyB { get; set; }
        public virtual DbSet<VW_ExpenseWithTransportationB> VW_ExpenseWithTransportationB { get; set; }
        public virtual DbSet<VW_CapitalProfitReportB> VW_CapitalProfitReportB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            ConfigureRelationships(modelBuilder);
            
            // Configure views as keyless entities
            modelBuilder.Entity<VW_ExpenseWithTransportation>().HasNoKey().ToView("VW_ExpenseWithTransportation");
            modelBuilder.Entity<VW_CapitalProfitReport>().HasNoKey().ToView("VW_CapitalProfitReport");
            modelBuilder.Entity<VW_ExpenseWithTransportationB>().HasNoKey().ToView("VW_ExpenseWithTransportationB");
            modelBuilder.Entity<VW_CapitalProfitReportB>().HasNoKey().ToView("VW_CapitalProfitReportB");
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Disable cascade delete globally to avoid circular references
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configure decimal precision for all decimal properties
            ConfigureDecimalPrecision(modelBuilder);
        }

        private void ConfigureDecimalPrecision(ModelBuilder modelBuilder)
        {
            // Original entities
            modelBuilder.Entity<Product>().Property(p => p.SellingPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Customer>().Property(c => c.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<Purchase>().Property(p => p.PurchaseTotalPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Selling>().Property(s => s.SellingTotalPrice).HasPrecision(18, 2);

            // B variant entities
            modelBuilder.Entity<ProductB>().Property(p => p.SellingPrice).HasPrecision(18, 2);
            modelBuilder.Entity<CustomerB>().Property(c => c.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<PurchaseB>().Property(p => p.PurchaseTotalPrice).HasPrecision(18, 2);
            modelBuilder.Entity<SellingB>().Property(s => s.SellingTotalPrice).HasPrecision(18, 2);
        }
    }
}