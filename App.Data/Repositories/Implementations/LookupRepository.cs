using System.Threading.Tasks;
using PDX.PBOT.App.Data.Concrete;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.Data.Repositories.Implementations
{
	public class LookupRepository : BaseRepository<Lookup>, ILookupRepository
	{
		public LookupRepository(AppContext context) : base(context)
		{}
	}
}