using AccountingSolutions.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AccountingSolutions.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void SetDbContextInstance(DbContext context);
        DbSet<T> Entity { get;}
    }
}
