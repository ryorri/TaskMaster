using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMaster.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;



namespace TaskMaster.Infrastructure.Extensions
{
	public static class ServiceCollectionsExtensions
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TaskMasterDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("TaskMaster")));

			//services.AddScoped<CarWorkshopSeeder>();
		}
	}
}
