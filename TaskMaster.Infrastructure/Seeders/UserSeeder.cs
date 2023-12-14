using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Seeders
{
    public class UserSeeder
    {
        private readonly TaskMasterDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public UserSeeder(TaskMasterDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Users.Any())
                {
                    var newUser = new IdentityUser
                    {
                        UserName = "Admin",
                    };

                    await _userManager.CreateAsync(newUser, "Administrator1!");
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                }
            }
        }

    }
}
