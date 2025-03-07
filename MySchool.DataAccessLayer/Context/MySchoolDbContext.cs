using Microsoft.EntityFrameworkCore;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DataAccessLayer.Context
{
    public class MySchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SLLU6PK; Database=MySchoolDb;Uid=sa;Pwd=123aA*; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Teachers)
                .WithMany(t => t.Lessons)
                .UsingEntity<Dictionary<string, object>>(
                    "LessonTeacher",
                    j => j.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId").OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Lesson>().WithMany().HasForeignKey("LessonId").OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Students)
                .WithMany(s => s.Lessons)
                .UsingEntity<Dictionary<string, object>>(
                    "LessonStudent",
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Lesson>().WithMany().HasForeignKey("LessonId").OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder.Entity<AssignmentSubmission>()
                .HasOne(a => a.Assigment)
                .WithMany()
                .HasForeignKey(a => a.AssigmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssignmentSubmission>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamResult>()
               .HasOne(er => er.Student)
               .WithMany(s => s.ExamResults)
               .HasForeignKey(er => er.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Assigment> Assigments { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

    }
}
