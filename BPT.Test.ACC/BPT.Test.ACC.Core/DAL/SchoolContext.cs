using BPT.Test.ACC.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.ACC.Core.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)  : base(options)
        {

        }

        public DbSet<StudentCls> Students { get; set; }
        public DbSet<AssignmentsCls> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssigmentStudentsCls>().HasKey(pt => new { pt.StudentId, pt.AssigmentId });
            modelBuilder.Entity<AssigmentStudentsCls>().HasOne(pt => pt.Student).WithMany(pt => pt.AssigmentStudents).HasForeignKey(pt => pt.StudentId);
            modelBuilder.Entity<AssigmentStudentsCls>().HasOne(pt => pt.Assignment).WithMany(pt => pt.AssigmentStudents).HasForeignKey(pt => pt.AssigmentId);
        }
    }
}
