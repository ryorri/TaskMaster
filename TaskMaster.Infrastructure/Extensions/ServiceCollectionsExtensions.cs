﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMaster.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using TaskMaster.Domain.Interfaces;
using TaskMaster.Infrastructure.Repositories;
using TaskMaster.Infrastructure.Methods.AdminPanelMethods;
using TaskMaster.Infrastructure.Methods.CRUDMethods;
using Microsoft.AspNetCore.Mvc.Razor;

namespace TaskMaster.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TaskMasterDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("TaskMaster")));

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.PageViewLocationFormats.Add("/Identity/Account/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<TaskMasterDbContext>();

            services.AddScoped<IWarrningRepo, WarrningRepo>();
            services.AddScoped<IErrorRepo, ErrorRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IPriorityRepo, PriorityRepo>();

            services.AddScoped<PrioritySeeder>();
            services.AddScoped<CategorySeeder>();
            services.AddScoped<RoleSeeder>();
            services.AddScoped<UserSeeder>();

            services.AddScoped<UserManipulation>();
            services.AddScoped<CRUDManipulation>();
        }
	}
}
