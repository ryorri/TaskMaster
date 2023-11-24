﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Infrastructure.DatabaseContext
{
	public class TaskMasterDbContext : DbContext
	{
		public TaskMasterDbContext(DbContextOptions<TaskMasterDbContext> options) : base(options)
		{ }
		public DbSet<TaskMaster.Domain.Entities.Error> Errors { get; set; }
		public DbSet<TaskMaster.Domain.Entities.Warning> Warnings { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Domain.Entities.Error>();
			modelBuilder.Entity<Domain.Entities.Warning>();

		}



	}
}