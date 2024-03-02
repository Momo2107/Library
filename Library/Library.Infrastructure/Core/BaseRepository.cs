using Library.Domain.Repository;

namespace Library.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
