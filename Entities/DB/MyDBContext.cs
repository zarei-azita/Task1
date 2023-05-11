using Microsoft.EntityFrameworkCore;

namespace Entities.DB
{
    public class MyDBContext : DbContext  
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Professor> Professors { get; set; }

    }
}
