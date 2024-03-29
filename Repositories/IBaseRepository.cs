using Models;

namespace Repositories
{
   public interface IBaseRepository<TKey>
   {
      Task<People> GetAsync(TKey id);
   }
}
