using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student.Dtos
{
    public class CreateSubjectResultDto : BaseDto<int>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double ScoreTen { get; set; }
    }
}
