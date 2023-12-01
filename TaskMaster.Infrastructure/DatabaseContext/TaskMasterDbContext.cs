using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Infrastructure.DatabaseContext
{
	public class TaskMasterDbContext : IdentityDbContext
	{
		public TaskMasterDbContext(DbContextOptions<TaskMasterDbContext> options) : base(options)
		{ }
		public DbSet<Domain.Entities.Error> Errors { get; set; }
		public DbSet<Domain.Entities.Warning> Warnings { get; set; }

		public DbSet<Domain.Entities.Priority> Priority { get; set; }
		public DbSet<Domain.Entities.Category> Category { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Domain.Entities.Error>();
			modelBuilder.Entity<Domain.Entities.Warning>();
			modelBuilder.Entity<Domain.Entities.Category>();
			modelBuilder.Entity<Domain.Entities.Priority>();

		}



	}
}