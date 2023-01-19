using AccountingSolutions.Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountingSolutions.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString = "";
        public CompanyDbContext(string companyId, Company company = null)
        {
            if (company != null)
                ConnectionString = string.IsNullOrEmpty(company.UserId) ?
                      $"Data Source={company.ServerName};" +
                      $"Initial Catalog={company.DatabaseName};Integrated Security=True;" +
                      $"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;"
                      :
                      $"Data Source={company.ServerName};" +
                      $"Initial Catalog={company.DatabaseName};" +
                      $"User Id={company.UserId};" +
                      $"Password={company.Password};" +
                      $"Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;";


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext("");
            }
        }
    }
}
