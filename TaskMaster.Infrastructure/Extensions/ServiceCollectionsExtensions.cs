﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMaster.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;

namespace TaskMaster.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TaskMasterDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("TaskMaster")));

			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<TaskMasterDbContext>();

			services.AddScoped<PrioritySeeder>();
			services.AddScoped<CategorySeeder>();
		}
	}
}
