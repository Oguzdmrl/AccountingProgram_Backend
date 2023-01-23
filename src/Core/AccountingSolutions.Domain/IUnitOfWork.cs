using Microsoft.EntityFrameworkCore;

namespace AccountingSolutions.Domain
{
    public interface IUnitOfWork 
    {
        void SetDbContextInstance(DbContext context);
        Task<int> SaveChangeAsync();
    }
}