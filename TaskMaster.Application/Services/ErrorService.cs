using AutoMapper;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Application.Services
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepo _errorRepo;
        private readonly IMapper _mapper;

        public ErrorService(IErrorRepo errorRepo, IMapper mapper)
        {
            _errorRepo = errorRepo;
            _mapper = mapper;
        }

        public async Task Create(Domain.Entities.Error error)
        {
            error.EncodeName();
            await _errorRepo.Create(error);
        }
        public async Task<IEnumerable<ErrorDto>> GetAll()
        {
            var err = await _errorRepo.GetAll();
            var dtos = _mapper.Map<IEnumerable<ErrorDto>>(err);

            return dtos;
        }

    }
}
