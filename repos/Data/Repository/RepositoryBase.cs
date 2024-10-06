using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RepositoryBase<TEntity, TId, TDbContext> : IRepository<TEntity, TId, TDbContext>
        where TEntity : class, IEntityBase<TId>
        where TDbContext : DbContext
    {
        public readonly DbFactoryBase<TDbContext> _dbFactory;


        public DbSet<TEntity> _dbSet;

        public DbSet<TEntity> DbSet => _dbSet ?? (_dbSet = _dbFactory.DatabaseContext.Set<TEntity>());

        public RepositoryBase(DbFactoryBase<TDbContext> dbFactory) { _dbFactory = dbFactory; }

        #region pretected methods
        public virtual IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetQueryableNoTracking()
        {
            return GetQueryable().AsNoTracking();
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetQueryableNoTracking().FirstOrDefault(predicate);
        }
        #endregion


        public virtual TEntity Create(TEntity item)
        {
            return DbSet.Add(item).Entity;
        }

        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> items)
        {
            var created = new HashSet<TEntity>();
            foreach (var item in items)
            {
                created.Add(DbSet.Add(item).Entity);
            }

            return created;
        }

        public virtual TEntity Update(TEntity item)
        {
            return DbSet.Update(item).Entity;
        }

        public virtual IEnumerable<TEntity> Update(IEnumerable<TEntity> items)
        {
            var updated = new HashSet<TEntity>();
            foreach (var item in items)
            {
                updated.Add(DbSet.Update(item).Entity);
            }

            return updated;
        }

        public TEntity Delete(TEntity item)
        {
            return DbSet.Remove(item).Entity;
        }

        public virtual IEnumerable<TEntity> Delete(IEnumerable<TEntity> items)
        {
            var deleted = new HashSet<TEntity>();
            foreach (var item in items)
            {
                deleted.Add(DbSet.Remove(item).Entity);
            }

            return deleted;
        }

        public TEntity Get(TId id)
        {
            return GetQueryable().FirstOrDefault(x => id.Equals(x.Id));
        }

        public TEntity GetNotracking(TId id)
        {
            return GetQueryableNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetQueryable();
        }

        public IQueryable<TEntity> GetAllNotracking()
        {
            return GetQueryableNoTracking();
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, string include = "")
        {
            var query = GetAllNotracking();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            foreach (var includeProperty in include.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query?.Include(includeProperty);
            }

            return query;
        }
    }
}
