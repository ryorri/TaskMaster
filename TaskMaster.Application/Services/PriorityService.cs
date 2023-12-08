using AutoMapper;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Application.Services
{
    public class PriorityService: IPriorityService
    {
        private readonly IPriorityRepo _prioRepo;
        private readonly IMapper _mapper;

        public PriorityService(IPriorityRepo prioRepos, IMapper mapper)
        {
            _prioRepo = prioRepos;
            _mapper = mapper;
        }

        public async Task Create(Domain.Entities.Priority prio)
        {
            await _prioRepo.Create(prio);
        }

        public async Task<IEnumerable<PriorityDto>> GetAll()
        {
            var prio = await _prioRepo.GetAll();
            var dtos = _mapper.Map<IEnumerable<PriorityDto>>(prio);

            return dtos;
        }
    }
}
