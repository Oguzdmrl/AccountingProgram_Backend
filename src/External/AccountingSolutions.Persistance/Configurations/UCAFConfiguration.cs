using AccountingSolutions.Domain.CompanyEntities;
using AccountingSolutions.Persistance.Constans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingSolutions.Persistance.Configurations
{
    public sealed class UCAFConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
    {
        public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
        {
            builder.ToTable(TableNames.UniformChartOfAccounts);
            builder.HasKey(p => p.Id);
        }
    }
}