using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DAL
{
    public interface IAppRepository<TEntity, TId> : IRepository<TEntity, TId, StudentDbContext>
        where TEntity : IEntityBase<TId>
    {
        public TEntity GetLast();
    }
}
