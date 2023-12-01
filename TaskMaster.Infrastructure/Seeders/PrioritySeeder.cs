using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Seeders
{
	public class PrioritySeeder
	{
		private readonly TaskMasterDbContext _dbContext;
		public PrioritySeeder(TaskMasterDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Seed()
		{
			if (await _dbContext.Database.CanConnectAsync())
			{
				if (!_dbContext.Priority.Any())
				{
					var low = new Domain.Entities.Priority()
					{
						_Priority = "Low"
					};
					_dbContext.Priority.Add(low);

					var medium = new Domain.Entities.Priority()
					{
						_Priority = "Medium"
					};
					_dbContext.Priority.Add(medium);

					var high = new Domain.Entities.Priority()
					{
						_Priority = "High"
					};
					_dbContext.Priority.Add(high);

					var crit = new Domain.Entities.Priority()
					{
						_Priority = "Critical"
					};
					_dbContext.Priority.Add(crit);


					await _dbContext.SaveChangesAsync();
				}
			}
		}

	}
}
