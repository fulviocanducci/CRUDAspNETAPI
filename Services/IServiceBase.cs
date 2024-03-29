using Services.Records.Peoples;

namespace Services
{
   public interface IServiceBase<T, TKey> where T: class, new()
   {
      Task<T> CreateAsync(PeopleCreate model);
      Task<bool> DeleteAsync(params object[] keys);
      Task<T> EditAsync(PeopleEdit model);
      Task<T> FindAsync(params object[] keys);      
      Task<T> GetAsync(int id);
      Task<List<T>> GetAllAsync();
   }
}