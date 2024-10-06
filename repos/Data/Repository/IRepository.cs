using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data
{
    public interface  IRepository
    {

    }
    public interface IRepository<TEntity, TId, TDbContext>
        where TEntity : IEntityBase<TId> where TDbContext : DbContext
    {
        TEntity Get(TId id);
        TEntity GetNotracking(TId id);
        TEntity Create(TEntity item);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> items);
        TEntity Update(TEntity item);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> items);
        TEntity Delete(TEntity item);
        IEnumerable<TEntity> Delete(IEnumerable<TEntity> items);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllNotracking();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="order"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, string include = "");
    }
}

