using AccountingSolutions.Domain.Abstractions;
using AccountingSolutions.Domain.AppEntities;
using AccountingSolutions.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountingSolutions.Persistance.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    //entry.Property(p => p.Id).CurrentValue = Guid.NewGuid().ToString();
                    entry.Property(p=>p.CreatedDate).CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdateDate).CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                return new AppDbContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=OGUZ;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options);
            }
        }
    }
}