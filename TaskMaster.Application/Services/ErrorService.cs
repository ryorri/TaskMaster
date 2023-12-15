using AutoMapper;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Entities;
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

        public Task Delete(Error error)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ErrorDto>> GetAll()
        {
            var err = await _errorRepo.GetAll();
            var dtos = _mapper.Map<IEnumerable<ErrorDto>>(err);

            return dtos;
        }
        public async Task<ErrorDto> GetById(int id)
        {

            var err = await _errorRepo.GetById(id);

            err.EncodeName();

            var dto = _mapper.Map<ErrorDto>(err);

            return dto;
        }

        public async Task<ErrorDto> Edit(int id, Error err)
        {
            var er = await _errorRepo.Edit(id, err);

            var dto = _mapper.Map<ErrorDto>(er);

            return dto;
        }
    }
}
