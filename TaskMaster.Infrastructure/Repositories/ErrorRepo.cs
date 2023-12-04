using Microsoft.EntityFrameworkCore;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Interfaces;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Repositories
{
    internal class ErrorRepo : IErrorRepo
    {
        private readonly TaskMasterDbContext _dbContext;

        public ErrorRepo(TaskMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Error error)
        {
            _dbContext.Add(error);
             await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Error>> GetAll() => await _dbContext.Errors.ToListAsync();
    }
}
