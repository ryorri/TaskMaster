using Microsoft.EntityFrameworkCore;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Interfaces;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Repositories
{
    internal class PriorityRepo : IPriorityRepo
    {
        private readonly TaskMasterDbContext _dbContext;

        public PriorityRepo(TaskMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Priority prio)
        {
            _dbContext.Add(prio);
             await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Priority>> GetAll() => await _dbContext.Priority.ToListAsync();
    }
}
