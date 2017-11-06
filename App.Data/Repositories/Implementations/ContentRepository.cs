using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PDX.PBOT.App.Data.Concrete;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.Data.Repositories.Implementations
{
	public class ContentRepository : BaseRepository<Content>, IContentRepository
	{
		public ContentRepository(AppContext context) : base(context)
		{}
	}
}