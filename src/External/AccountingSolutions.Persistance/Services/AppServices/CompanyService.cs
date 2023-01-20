using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingSolutions.Application.Services.AppServices;
using AccountingSolutions.Domain.AppEntities;
using AccountingSolutions.Persistance.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingSolutions.Persistance.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled
            = EF.CompileAsyncQuery((AppDbContext context, string name) => context.Set<Company>().FirstOrDefault(p => p.Name == name));
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await GetCompanyByNameCompiled(_context,name);
        }

        public async Task MigrateCompanyDatabases()
        {
           var companies = await _context.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
