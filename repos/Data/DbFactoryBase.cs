using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class DbFactoryBase<TDbContext> where TDbContext : DbContext 
	{
		private Func<TDbContext> _instance;
		private TDbContext _dbContext;
		public TDbContext DatabaseContext => _dbContext ?? (_dbContext = _instance.Invoke());
		public DbFactoryBase(Func<TDbContext> factoryDb)
		{
			_instance = factoryDb;
		}
	}
}
