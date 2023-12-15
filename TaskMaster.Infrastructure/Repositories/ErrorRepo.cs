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

        public async Task<Error> GetById(int id)
        {
            var err = await _dbContext.Errors.FirstOrDefaultAsync(x => x.Id == id);
            return err;
        }

        public async Task<Error> Edit(int id, Error error)
        {
            error.EncodeName();
            _dbContext.Update(error);

            await _dbContext.SaveChangesAsync();
            return error;
        }
        public async Task Delete(Error error)
        {
            _dbContext.Remove(error);
            await _dbContext.SaveChangesAsync();
        }
    }
}
