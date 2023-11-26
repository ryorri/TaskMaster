using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Seeders
{
	public class CategorySeeder
	{
		private readonly TaskMasterDbContext _dbContext;
		public CategorySeeder(TaskMasterDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Seed()
		{
			if(await _dbContext.Database.CanConnectAsync())
			{
				if(!_dbContext.Category.Any())
				{
					var hw = new Domain.Entities.Category()
					{
						Name = "Hardware",
						Description = "What wrong with your PC?"
					};
					_dbContext.Category.Add(hw);

					var sw = new Domain.Entities.Category()
					{
						Name = "Softwate",
						Description = "What wrong with your program?"
					};
					_dbContext.Category.Add(sw);

					await _dbContext.SaveChangesAsync();
					}
			}
		}	

	}
}
