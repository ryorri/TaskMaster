using Microsoft.EntityFrameworkCore;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Interfaces;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Repositories
{
    internal class WarrningRepo : IWarrningRepo
    {
        private readonly TaskMasterDbContext _dbContext;

        public WarrningRepo(TaskMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Warning warr)
        {
            _dbContext.Add(warr);
             await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Warning>> GetAll() => await _dbContext.Warnings.ToListAsync();
    }
}
