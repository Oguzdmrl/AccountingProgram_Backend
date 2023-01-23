using AccountingSolutions.Domain.Abstractions;
using System.Linq.Expressions;

namespace AccountingSolutions.Domain.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression);
        Task<T> GetById(string id);
        Task<T> GetFirstByExpiression(Expression<Func<T, bool>> expression);
        Task<T> GetFirst();
    }
}
