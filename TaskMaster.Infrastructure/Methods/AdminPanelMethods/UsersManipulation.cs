using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Methods.AdminPanelMethods
{
    public class UsersManipulation
    {
        private readonly TaskMasterDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public UsersManipulation(TaskMasterDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IdentityUser> GetUserName(string userId)
        {
            IdentityUser? userName = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if(userName == null) 
            {
                throw new ArgumentNullException();
            }

            return userName;
        }


    }
}
