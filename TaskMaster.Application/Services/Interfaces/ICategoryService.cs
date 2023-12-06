using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Create(Category cat);
        Task<IEnumerable<CategoryDto>> GetAll();
    }
}