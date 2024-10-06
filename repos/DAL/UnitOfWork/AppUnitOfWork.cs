using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class AppUnitOfWork : UnitOfWorkBase<StudentDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbFactory dbFactory) : base(dbFactory) 
        {
        }
    }
}
