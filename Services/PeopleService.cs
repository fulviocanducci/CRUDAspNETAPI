using DataAccess;
using Repositories;
using Services.Records.Peoples;
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
         var people = new Models.People
         {
            Name = model.Name,
            Active = model.Active
         };
         await _repository.CreateAsync(people);
         await _unitOfWork.CommitAsync();
         return new PeopleItem(people.Id, people.Name, people.Active);
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
         var people = new Models.People
         {
            Id = model.Id,
            Name = model.Name,
            Active = model.Active
         };
         _repository.Edit(people);
         await _unitOfWork.CommitAsync();
         return new PeopleItem(people.Id, people.Name, people.Active);
      }

      public async Task<PeopleItem> FindAsync(params object[] keys)
      {
         var result = await _repository.FindAsync(keys);
         if (result != null)
         {
            return new PeopleItem(result.Id, result.Name, result.Active);
         }
         return null;
      }

      public async Task<List<PeopleItem>> GetAllAsync()
      {
         return await _repository.GetAllAsync(x => new PeopleItem(x.Id, x.Name, x.Active));
      }
   }
}
