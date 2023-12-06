using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services.Interfaces
{
    public interface IPriorityService
    {
        Task Create(Priority prio);
        Task<IEnumerable<PriorityDto>> GetAll();
    }
}