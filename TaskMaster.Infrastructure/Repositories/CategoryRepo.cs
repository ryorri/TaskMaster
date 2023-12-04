using Microsoft.EntityFrameworkCore;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Interfaces;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Repositories
{
    internal class CategoryRepo : ICategoryRepo
    {
        private readonly TaskMasterDbContext _dbContext;

        public CategoryRepo(TaskMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Category category)
        {
            _dbContext.Add(category);
             await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll() => await _dbContext.Category.ToListAsync();
    }
}
