using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System.Linq.Expressions;

namespace Repositories
{
   public interface IPeopleRepository
   {
      ValueTask<EntityEntry<People>> CreateAsync(People model);
      EntityEntry<People> Edit(People model);
      Task<People> FindAsync(params object[] Keys);
      Task<List<People>> GetAllAsync();
      Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<People, TResult>> select);
      EntityEntry<People> Delete(People model);
   }
}
