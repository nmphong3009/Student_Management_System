using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbFactory : DbFactoryBase<StudentDbContext>
    {
        public AppDbFactory(Func<StudentDbContext> factoryDb):base(factoryDb)
        {

        }
    }
}
