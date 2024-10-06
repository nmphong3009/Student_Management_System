using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Data;

namespace Models
{
    [Table("Subject")]
    public class Subject : EntityBase<int>
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Credit { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
