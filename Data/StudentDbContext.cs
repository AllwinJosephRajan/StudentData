using InterviewAssignmentTry3.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAssignmentTry3.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentModel> Students { get; set; }
    }
}
