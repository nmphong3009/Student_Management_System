using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace DAL
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { } 
        public virtual DbSet<Student> Students {  get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Subject>();
            modelBuilder.Entity<Score>()
                .HasOne(s => s.Student)
                .WithMany(st => st.Scores)
                .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<Score>()
                .HasOne(s => s.Subject)
                .WithMany(su => su.Scores)
                .HasForeignKey(s => s.SubjectId);
        }
    }
}
