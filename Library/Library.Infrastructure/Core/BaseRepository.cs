

using Library.Domain.Repository;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly LibraryContext context;
        private readonly DbSet<TEntity> DbEntity ;

        protected BaseRepository(LibraryContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();
        }
   
        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntity.Any<TEntity>(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DbEntity.Where<TEntity>(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DbEntity.ToList<TEntity>();
        }

        public virtual TEntity GetEntity(int id)
        {
            return DbEntity.Find(id);
        }

        public void Remove(TEntity entity)
        {
            DbEntity.Update(entity);
            this.context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            DbEntity.Add(entity);
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }
    }
}
