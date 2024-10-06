using DAL;
using Domain.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student
{
    public class StudentRepository : AppRepository<Models.Student, int>, IStudentRepository
    {
        public StudentRepository(AppDbFactory dbFactory): base(dbFactory) 
        {
        }
    }
}
