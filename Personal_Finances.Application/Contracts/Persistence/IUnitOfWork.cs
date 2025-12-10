using Personal_Finances.Domain.Common;

namespace Personal_Finances.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
