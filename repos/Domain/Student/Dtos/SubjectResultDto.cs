using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student.Dtos
{
    public class SubjectResultDto : BaseDto<int>
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int Credit { get; set; }
        public double ScoreTen { get; set; }
        public int SubjectId { get; set; }
    }
}
