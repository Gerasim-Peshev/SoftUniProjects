using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext
    {
        private IdentityUser TestUser { get; set; }
        private Board OpenBoard { get; set; }
        private Board InProgressBoard { get; set; }
        private Board DoneBoard { get; set; }

        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Task>()
               .HasOne(t => t.Board)
               .WithMany(b => b.Tasks)
               .HasForeignKey(t => t.BoardId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            SeedUsers();
            builder
               .Entity<IdentityUser>()
               .HasData(TestUser);

            SeedBoards();
            builder
               .Entity<Board>()
               .HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder
               .Entity<Task>()
               .HasData(new Task()
                        {
                            Id = 1,
                            Title = "Improve CSS styles",
                            Description = "Same",
                            CreatedOn = DateTime.Now.AddDays(-200),
                            OwnerId = "42c50d75-a329-43d6-b030-9620bbfe7a13",
                            BoardId = OpenBoard.Id
                        },
                        new Task()
                        {
                            Id = 2,
                            Title = "Android Client App",
                            Description = "Same as second Title",
                            CreatedOn = DateTime.Now.AddDays(-5),
                            OwnerId = "42c50d75-a329-43d6-b030-9620bbfe7a13",
                            BoardId = OpenBoard.Id
                        },
                        new Task()
                        {
                            Id = 3,
                            Title = "Desctop Client App",
                            Description = "Same as third Title",
                            CreatedOn = DateTime.Now.AddMonths(-1),
                            OwnerId = "42c50d75-a329-43d6-b030-9620bbfe7a13",
                            BoardId = InProgressBoard.Id
                        },
                        new Task()
                        {
                            Id = 4,
                            Title = "Create Tasks",
                            Description = "Same as forth Title",
                            CreatedOn = DateTime.Now.AddYears(-1),
                            OwnerId = "42c50d75-a329-43d6-b030-9620bbfe7a13",
                            BoardId = DoneBoard.Id
                        });
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedEmail = "TEST@SOFTUNI.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}