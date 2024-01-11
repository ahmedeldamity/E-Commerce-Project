using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUnitOfWork: IAsyncDisposable 
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
