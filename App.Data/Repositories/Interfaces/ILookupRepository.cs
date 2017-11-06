using PDX.PBOT.App.Data.Models;

namespace PDX.PBOT.App.Data.Repositories.Interfaces
{
    public interface ILookupRepository : IRepository<Lookup>
    {
        Lookup ReadSync(int id);
    }
}