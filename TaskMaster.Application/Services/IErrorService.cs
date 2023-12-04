using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services
{
    public interface IErrorService
    {
        Task Create(Error error);

        Task<IEnumerable<ErrorDto>> GetAll();
    }
}