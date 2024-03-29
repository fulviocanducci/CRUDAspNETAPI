using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System.Linq.Expressions;
namespace Repositories
{
   public sealed class PeopleRepository : IPeopleRepository
   {
      private readonly DatabaseContext _context;

      public PeopleRepository(DatabaseContext context)
      {
         _context = context;
      }

      public ValueTask<EntityEntry<People>> CreateAsync(People model)
      {
         return _context.Peoples.AddAsync(model);
      }

      public EntityEntry<People> Delete(People model)
      {
         return _context.Peoples.Remove(model);
      }

      public EntityEntry<People> Edit(People model)
      {
         return _context.Peoples.Update(model);
      }

      public async Task<People> FindAsync(params object[] Keys)
      {
         return await _context.Peoples.FindAsync(Keys);
      }

      public async Task<List<People>> GetAllAsync()
      {
         return await _context.Peoples.AsNoTracking().ToListAsync();
      }

      public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<People, TResult>> select)
      {
         return await _context.Peoples.AsNoTracking().Select(select).ToListAsync();
      }
   }
}
