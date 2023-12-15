using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services.Interfaces
{
    public interface IWarningService
    {
        Task Create(Warning warr);
        Task<WarningDto> Edit(int id, Warning warr);
        Task Delete(Warning warr);
        Task<WarningDto> GetById(int id);
        Task<IEnumerable<WarningDto>> GetAll();
    }
}