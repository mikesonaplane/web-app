using System.Threading.Tasks;
using PDX.PBOT.App.Data.Concrete;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.Data.Repositories.Implementations
{
	public class LookupRepository : BaseRepository<Lookup>, ILookupRepository
	{
		public LookupRepository(AppDbContext context) : base(context)
		{ }

		public Lookup ReadSync(int id)
		{
			var dbLookup = Context.Lookups.Find(id);

			return dbLookup;
		}
	}
}