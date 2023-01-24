using AccountingSolutions.Domain.Abstractions;
using System.Linq.Expressions;

namespace AccountingSolutions.Domain.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetById(string idi, bool isTracking = true);
        Task<T> GetFirstByExpiression(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetFirst(bool isTracking = true);
    }
}
