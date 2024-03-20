namespace DataAccess
{
   public class UnitOfWork : IUnitOfWork
   {
      public UnitOfWork(DatabaseContext databaseContext)
      {
         DatabaseContext = databaseContext;
      }

      public DatabaseContext DatabaseContext { get; }

      public int Commit()
      {
         return DatabaseContext.SaveChanges();
      }
      public async Task<int> CommitAsync()
      {
         return await DatabaseContext.SaveChangesAsync();
      }
   }
}
