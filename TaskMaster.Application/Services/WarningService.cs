using AutoMapper;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Application.Services
{
    public class WarningService : IWarningService
    {
        private readonly IWarrningRepo _warrRepo;
        private readonly IMapper _mapper;

        public WarningService(IWarrningRepo warrRepo, IMapper mapper)
        {
            _warrRepo = warrRepo;
            _mapper = mapper;
        }

        public async Task Create(Domain.Entities.Warning warr)
        {
            warr.EncodeName();
            await _warrRepo.Create(warr);
        }
        public async Task<IEnumerable<WarningDto>> GetAll()
        {
            var warr = await _warrRepo.GetAll();
            var dtos = _mapper.Map<IEnumerable<WarningDto>>(warr);

            return dtos;
        }

    }
}
