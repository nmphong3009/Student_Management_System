using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data       
{
    public interface IUnitOfWork
    {
        int SaveChange();

        Task<int> SaveChangeAsync();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
