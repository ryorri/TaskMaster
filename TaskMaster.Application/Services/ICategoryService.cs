using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services
{
    public interface ICategoryService
    {
        Task Create(Category cat);
        Task<IEnumerable<CategoryDto>> GetAll();
    }
}