using AccountingSolutions.Domain.Abstractions;
using AccountingSolutions.Domain.Repositories;
using AccountingSolutions.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccountingSolutions.Persistance.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));
        
        private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled =
           EF.CompileAsyncQuery((CompanyDbContext context) => context.Set<T>().FirstOrDefault());
        
        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>> GetFirstByExpiressionCompiled =
           EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression) => context.Set<T>().FirstOrDefault(expression));

        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll() => Entity.AsQueryable();

        public async Task<T> GetById(string id) => await GetByIdCompiled(_context, id);

        public async Task<T> GetFirst() => await GetFirstCompiled(_context);

        public async Task<T> GetFirstByExpiression(Expression<Func<T, bool>> expression) => await GetFirstByExpiressionCompiled(_context, expression);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression) => Entity.Where(expression);
    }
}