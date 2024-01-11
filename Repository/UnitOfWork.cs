using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Collections;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _repositories = new Hashtable();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;

            if (!_repositories.ContainsKey(key))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _storeContext);

                _repositories.Add(key, repository);
            }

            return (GenericRepository<T>) _repositories[key];
        }

        public async Task<int> CompleteAsync()
        {
            return await _storeContext.SaveChangesAsync();  
        }

        public async ValueTask DisposeAsync()
        {
            await _storeContext.DisposeAsync();
        }

    }
}
