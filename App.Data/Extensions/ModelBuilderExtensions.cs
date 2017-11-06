using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Options;

namespace PDX.PBOT.App.Data.Extensions
{
	public static class ModelBuilderExtensions
	{
		private static EntityTypeBuilder<TEntity> ToTable<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, TableConfiguration configuration)
			where TEntity : class
		{
			return string.IsNullOrWhiteSpace(configuration.Schema) ? entityTypeBuilder.ToTable(configuration.Name) : entityTypeBuilder.ToTable(configuration.Name, configuration.Schema);
		}

		public static void ConfigureContext(this ModelBuilder modelBuilder, AppStoreOptions storeOptions)
		{
			if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

			modelBuilder.Entity<Lookup>(lookup =>
			{
				lookup.ToTable(storeOptions.Lookup);

				lookup.HasKey(x => x.Id);

				lookup.Property(x => x.Name).HasMaxLength(200).IsRequired();

				lookup.HasIndex(x => x.Name).IsUnique();
			});

			modelBuilder.Entity<Content>(content => 
			{
				content.ToTable(storeOptions.Content);

				content.HasKey(x => x.Id);

				content.Property(x => x.Data).HasMaxLength(1000).IsRequired();

				content.HasOne(x => x.Lookup).WithMany(x => x.Contents).OnDelete(DeleteBehavior.ClientSetNull);
			});
		}
	}
}
