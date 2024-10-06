using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student.Dtos
{
    public class UpdateSubjectResultDto: BaseDto<int>
    {
        public double ScoreTen { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
    }
}
