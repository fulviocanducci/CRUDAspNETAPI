namespace DataAccess
{
   public interface IUnitOfWork
   {
      int Commit();
      Task<int> CommitAsync();
   }
}
