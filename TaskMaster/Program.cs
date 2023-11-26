using TaskMaster.Infrastructure.Extensions;
using TaskMaster.Infrastructure.Seeders;


			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddInfrastructure(builder.Configuration);

			var app = builder.Build();

			var scope = app.Services.CreateScope();

			#region Seeder
			var prioseeder = scope.ServiceProvider.GetRequiredService<PrioritySeeder>();
			var categoryseeder = scope.ServiceProvider.GetRequiredService<CategorySeeder>();

			await categoryseeder.Seed();
			await prioseeder.Seed();
			#endregion


			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		