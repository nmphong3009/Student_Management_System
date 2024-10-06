using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student.Dtos
{
    public class UpdateStudentDto:BaseDto<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }
        public string Phone { get; set; }
        public string Course { get; set; }
    }
}
