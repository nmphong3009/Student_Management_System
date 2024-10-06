using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DAL
{
    public class AppRepository<TEntity, TId> : RepositoryBase<TEntity, TId, StudentDbContext>, IAppRepository<TEntity, TId>
        where TEntity : class, IEntityBase<TId>
    {
        public AppRepository(AppDbFactory dbFactory) : base(dbFactory)
        {

        }
        public TEntity GetLast()
        {
            return GetAllNotracking().OrderByColumnDescending("Id").FirstOrDefault();
        }
    }
}