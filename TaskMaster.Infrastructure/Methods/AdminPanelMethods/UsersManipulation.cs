using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Methods.AdminPanelMethods
{
    public class UserManipulation
    {
        private readonly TaskMasterDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public UserManipulation(TaskMasterDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IdentityUser> GetUser(string userId)
        {
            IdentityUser? userName = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if(userName == null) 
            {
                throw new ArgumentNullException();
            }

            return userName;
        }

        

        public async Task<IList<string>> GetUserRole(Task<IdentityUser> userName)
        {
            IList<string> roles = await _userManager.GetRolesAsync(await userName);

            if (userName == null)
            {
                throw new ArgumentNullException();
            }

            return roles;
        }


        public IEnumerable<SelectListItem> GetUserList()
        {
            var users = _dbContext.Users.ToList();

            var userList = users.ToList().Select(x => new SelectListItem
            {
                Text = x.UserName,
                Value = x.Id.ToString(),
            });

            return userList;
        }

        public IEnumerable<SelectListItem> GetRoleList()
        {
            var roles = _dbContext.Roles.ToList();

            var roleList = roles.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name,
            });

            return roleList;
        }

        public Task RemoveUser(IdentityUser? user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _userManager.DeleteAsync(user);
            _dbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
