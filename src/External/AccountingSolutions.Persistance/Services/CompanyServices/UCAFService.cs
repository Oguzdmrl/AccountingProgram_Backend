using AccountingSolutions.Application.Features.CompanyFeatures.UCAFFeatures.Commands;
using AccountingSolutions.Application.Services.CompanyServices;
using AccountingSolutions.Domain;
using AccountingSolutions.Domain.CompanyEntities;
using AccountingSolutions.Domain.Repositories.UCAFRepositories;
using AccountingSolutions.Persistance.Context;
using AutoMapper;

namespace AccountingSolutions.Persistance.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private CompanyDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFRequest request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
            await _commandRepository.AddAsync(uniformChartOfAccount);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}