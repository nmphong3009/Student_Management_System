using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student
{
    public interface IStudentRepository : IAppRepository<Models.Student, int>
    {
    }
}
