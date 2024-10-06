using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Score")]
    public class Score :EntityBase<int>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double ScoreTen { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
