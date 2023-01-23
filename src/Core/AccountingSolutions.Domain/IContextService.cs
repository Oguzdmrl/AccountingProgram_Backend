using Microsoft.EntityFrameworkCore;

namespace AccountingSolutions.Domain
{
    public interface IContextService
    {
        DbContext CreateDbContextInstance(string companyId);
    }
}