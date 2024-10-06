using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.UnitOfWork
{
    public class UnitOfWorkBase<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private DbFactoryBase<TDbContext> _dbFactory;

        private IDbContextTransaction _contextTransaction;

        public UnitOfWorkBase(DbFactoryBase<TDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public int SaveChange()
        {
            return _dbFactory.DatabaseContext.SaveChanges();
        }

        public Task<int> SaveChangeAsync()
        {
            return _dbFactory.DatabaseContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _contextTransaction = _dbFactory.DatabaseContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _contextTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            _contextTransaction.Rollback();
        }
    }

}
