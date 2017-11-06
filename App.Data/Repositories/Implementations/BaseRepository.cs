using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDX.PBOT.App.Data.Concrete;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.Data.Repositories.Implementations
{
	public abstract class BaseRepository<T> : IRepository<T>
		where T : class
	{
		protected readonly AppDbContext Context;

		public BaseRepository(AppDbContext context)
		{
			Context = context;
		}

		public async Task<List<T>> All()
		{
			var items = await Context.Set<T>().ToAsyncEnumerable().ToList();

			return items;
		}

		public async Task<T> Create(T item)
		{
			var dbItem = Context.Set<T>().Add(item);

			await Context.SaveChangesAsync();

			return dbItem.Entity;
		}

		public async Task<T> Delete(int id)
		{
			var dbContent = await Context.Set<T>().FindAsync(id);

			Context.Set<T>().Remove(dbContent);

			await Context.SaveChangesAsync();

			return dbContent;
		}

		public async Task<T> Read(int id)
		{
			var dbContent = await Context.Set<T>().FindAsync(id);

			return dbContent;
		}

		public async Task<T> Update(int id, T item)
		{
			Context.Set<T>().Update(item);

			await Context.SaveChangesAsync();

			return item;
		}
	}
}