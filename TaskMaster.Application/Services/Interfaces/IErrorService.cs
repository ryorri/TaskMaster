using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services.Interfaces
{
    public interface IErrorService
    {
        Task Create(Error error);

        Task<ErrorDto> Edit(int id, Error error);
        Task Delete(Error error);
        Task<ErrorDto> GetById(int id);
        Task<IEnumerable<ErrorDto>> GetAll();
    }
}