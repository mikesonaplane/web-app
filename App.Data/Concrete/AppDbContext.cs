using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PDX.PBOT.App.Data.Extensions;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Options;

namespace PDX.PBOT.App.Data.Concrete
{
	public partial class AppContext : DbContext
	{
		private readonly AppStoreOptions StoreOptions;
		public DbSet<Lookup> Lookups { get; set; }
		public DbSet<Content> Contents { get; set; }

		public AppContext(DbContextOptions<AppContext> options, AppStoreOptions storeOptions) : base(options)
		{
			if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
			StoreOptions = storeOptions;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ConfigureContext(StoreOptions);

			base.OnModelCreating(modelBuilder);
		}

		public Task<int> SaveChangesAsync()
		{
			return base.SaveChangesAsync();
		}
	}
}