using DataAccess;
using Repositories;
using Services.Records.Peoples;
using Models;
namespace Services
{
   public class PeopleService : IPeopleService
   {
      private readonly IPeopleRepository _repository;
      private readonly IUnitOfWork _unitOfWork;

      public PeopleService(IPeopleRepository repository, IUnitOfWork unitOfWork)
      {
         _repository = repository;
         _unitOfWork = unitOfWork;
      }

      public async Task<PeopleItem> CreateAsync(PeopleCreate model)
      {
         People people = People.Create(model.Name, model.Active);
         await _repository.CreateAsync(people);
         await _unitOfWork.CommitAsync();
         return PeopleItem.Create(people);
      }

      public async Task<bool> DeleteAsync(params object[] keys)
      {
         var model = await _repository.FindAsync(keys);
         if (model != null)
         {
            _repository.Delete(model);
            return await _unitOfWork.CommitAsync() > 0;
         }
         return false;
      }

      public async Task<PeopleItem> EditAsync(PeopleEdit model)
      {
         People people = People.Create(model.Id, model.Name, model.Active);
         _repository.Edit(people);
         await _unitOfWork.CommitAsync();
         return PeopleItem.Create(people);
      }

      public async Task<PeopleItem> FindAsync(params object[] keys)
      {
         var result = await _repository.FindAsync(keys);
         if (result != null)
         {
            return PeopleItem.Create(result);
         }
         return null;
      }

      public async Task<List<PeopleItem>> GetAllAsync()
      {
         return await _repository.GetAllAsync(x => PeopleItem.Create(x));
      }
   }
}