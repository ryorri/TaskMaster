using AutoMapper;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Entities;
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

        public async Task<WarningDto> Edit(int id, Warning warr)
        {
            var war = await _warrRepo.Edit(id, warr);

            var dto = _mapper.Map<WarningDto>(war);

            return dto;
        }

        public async Task Delete(Warning warr)
        {
            await _warrRepo.Delete(warr);           
        }

        public async Task<WarningDto> GetById(int id)
        {

            var warr = await _warrRepo.GetById(id);

            warr.EncodeName();

            var dto = _mapper.Map<WarningDto>(warr);

            return dto;
        }

    }
}
