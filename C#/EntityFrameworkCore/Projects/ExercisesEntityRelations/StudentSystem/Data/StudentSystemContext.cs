using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-UAJSSJ3\SQLEXPRESS01;Database=StudentSystem;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                      .IsRequired(false)
                      .IsUnicode(false)
                      .HasMaxLength(10);

                entity.Property(e => e.RegisteredOn)
                      .IsRequired();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .IsRequired(false)
                      .IsUnicode(true);

                entity.Property(e => e.StartDate)
                      .IsRequired();

                entity.Property(e => e.EndDate)
                      .IsRequired();

                entity.Property(e => e.Price)
                      .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourseId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .IsUnicode(true)
                      .HasMaxLength(50);

                entity.Property(e => e.Url)
                      .IsRequired()
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                      .IsUnicode(false);

                entity.Property(e => e.SubmissionTime)
                      .IsRequired();
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new {e.StudentId, e.CourseId});

                entity.HasOne(e => e.Student)
                      .WithMany(e => e.Courses)
                      .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                      .WithMany(e => e.Students)
                      .HasForeignKey(e => e.CourseId);
            });
        }
    }
}
