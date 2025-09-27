# LoadTestDb86_1020

A comprehensive SQL Server database stress test with **86 entities** and **1020+ columns** designed for testing database migration tools, ORM performance, and system scalability.

## 📊 Database Statistics

- **Entities**: 86
- **Tables**: 86
- **Columns**: 1020+
- **Complexity Level**: Medium
- **Use Case**: Standard testing

## 🏗️ Architecture

This project contains a synthetic business database with realistic entity relationships including:

- **Account Management**: Account variants (A-H), AccountDeposit, AccountWithdraw
- **Customer Management**: Customer variants, CustomerPhone
- **Expense Tracking**: Expense variants, ExpenseFixed, ExpenseTransportation, ExpenseCategory
- **Product Catalog**: Product variants, ProductCatalog, ProductStock, ProductDamaged
- **Sales & Purchasing**: Purchase variants, Selling variants, Registration
- **Service Management**: Service variants, ServiceDevice, ServiceList
- **Reporting Views**: VW_ExpenseWithTransportation, VW_CapitalProfitReport
- **Extended Entities**: Multiple variant suffixes (B, C, D, E, F, G, H) for comprehensive testing

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 or VS Code

### Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd LoadTestDb86_1020
   ```

2. **Configure Connection String**
   
   Update the connection strings in both `appsettings.json` files:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=LoadTestDb86_1020;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Build the Solution**
   ```bash
   dotnet build
   ```

4. **Create Database Schema**
   ```bash
   cd LoadTest.Data/bin/Debug/net8.0
   ./LoadTest.Data.exe
   ```

5. **Test Database Connectivity**
   ```bash
   cd LoadTest.Console/bin/Debug/net8.0
   ./LoadTest.Console.exe
   ```

## 🧪 Testing Capabilities

### LoadTest.Data Project
- **EF Core Model**: Complete Entity Framework Core model with all 86 entities
- **Database Creation**: Automated schema generation using EF Core migrations
- **Relationship Mapping**: Proper foreign key relationships and constraints
- **Comprehensive Testing**: Full CRUD operations on all entities

### LoadTest.Console Project
- **Connectivity Testing**: Database connection validation
- **Schema Verification**: Table and column count validation
- **Performance Metrics**: Performance measurements and statistics

## 📈 Performance Characteristics

- **Build Time**: Scales with entity count
- **Schema Creation**: ~5-30 seconds depending on complexity
- **Memory Usage**: Medium
- **EF Core Compatibility**: Excellent

## 🎯 Use Cases

### Migration Tool Testing
- **Medium Testing**: Perfect for standard testing
- **Scalability Testing**: Test migration tool limits
- **Performance Validation**: Measure migration performance

### ORM Performance Testing
- **Entity Framework**: Validate EF Core performance with 86 entities
- **Query Performance**: Test complex query patterns
- **CRUD Operations**: Validate operations across all entities

### System Integration Testing
- **Load Testing**: Database performance under load
- **Stress Testing**: System limits and breaking points
- **Performance Benchmarking**: Comprehensive performance metrics

## 🔧 Customization

### Adding New Entities
1. Create new entity class in `LoadTest.Data/Models/`
2. Add DbSet property to `ApplicationDbContext`
3. Configure relationships in `OnModelCreating`

### Modifying Connection Strings
- Update `LoadTest.Data/appsettings.json`
- Update `LoadTest.Console/appsettings.json`

## 📊 Comparison with Other LoadTest Databases

| Database | Entities | Complexity | Use Case |
|----------|----------|------------|----------|
| LoadTestDb43_510 | 43 | Basic | Initial testing |
| LoadTestDb86_1020 | 86 | Medium | Standard testing |
| LoadTestDb129_1530 | 129 | High | Advanced testing |
| LoadTestDb172_2040 | 172 | Very High | Stress testing |
| LoadTestDb215_2550 | 215 | Extreme | Limit testing |
| LoadTestDb258_3060 | 258 | Maximum | Ultimate testing |
| LoadTestDb301_3570 | 301 | Record | World record |
| **LoadTestDb86_1020** | **86** | **Medium** | **Standard testing** |

## 🏆 Performance Records





## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- Built with Entity Framework Core 8.0
- Designed for SQL Server compatibility
- Optimized for migration tool testing
- Part of the comprehensive LoadTest Database Series

## 📞 Support

For questions or issues:
- Create an issue in the GitHub repository
- Check the documentation in other LoadTest projects
- Review the comprehensive test suite

---

**Part of the LoadTest Database Series** - A comprehensive suite of databases designed to test the limits of migration tools and ORM frameworks.
