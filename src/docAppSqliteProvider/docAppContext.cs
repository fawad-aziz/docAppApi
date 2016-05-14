using System;
using System.Linq;
using docAppDomain.Model;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace docAppSqliteProvider
{
	public class docAppContext : DbContext
	{
		public DbSet<AppointmentEntity> Appointments { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<AppointmentEntity>().HasKey(m => m.Id);

			// shadow properties
			builder.Entity<AppointmentEntity>().Property<DateTime>("UpdatedTimestamp");

			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
		   .AddJsonFile("../config.json")
		   .AddEnvironmentVariables();
			var configuration = builder.Build();

			var sqlConnectionString = configuration["DataAccessSqliteProvider:ConnectionString"];

			optionsBuilder.UseSqlite(sqlConnectionString);
		}

		public override int SaveChanges()
		{
			ChangeTracker.DetectChanges();

			UpdateUpdatedProperty<AppointmentEntity>();

			return base.SaveChanges();
		}

		private void UpdateUpdatedProperty<T>() where T : class
		{
			var modifiedSourceInfo =
				ChangeTracker.Entries<T>()
					.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo)
			{
				entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}