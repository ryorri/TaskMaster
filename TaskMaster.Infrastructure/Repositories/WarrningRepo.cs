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

        public async Task Delete(Warning warr)
        {
            _dbContext.Remove(warr);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Warning> GetById(int id)
        {
            var warr = await _dbContext.Warnings.FirstOrDefaultAsync(x => x.Id == id);
            return warr;
        }

        public async Task<Warning> Edit(int id, Warning warr)
        {
            warr.EncodeName();
            _dbContext.Update(warr);

            await _dbContext.SaveChangesAsync();
            return warr;
        }
    }
}
