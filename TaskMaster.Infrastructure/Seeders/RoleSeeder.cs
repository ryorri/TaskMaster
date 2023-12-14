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
	public class RoleSeeder
	{
        private readonly TaskMasterDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleSeeder(TaskMasterDbContext dbContext, RoleManager<IdentityRole> roleManager)
		{
            _dbContext = dbContext;
			_roleManager = roleManager;
		}

		public async Task Seed()
		{
			if (await _dbContext.Database.CanConnectAsync())
			{
				if (!_dbContext.Roles.Any())
				{
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("Moderator"));
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }
			}
		}

	}
}
