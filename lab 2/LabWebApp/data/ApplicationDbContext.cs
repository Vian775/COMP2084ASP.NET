using Microsoft.EntityFrameworkCore;
using LabWebApp.Models;

namespace LabWebApp.data;
//viyan rony
//200586309
//lab 2
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}

