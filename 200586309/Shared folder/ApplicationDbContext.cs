using Microsoft.EntityFrameworkCore;
using _200586309.Models;

namespace _200586309.Shared_folder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
