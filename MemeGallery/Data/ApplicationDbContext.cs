using Microsoft.EntityFrameworkCore;
using MemeGallery.Model;

namespace MemeGallery.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Meme> Meme { get; set; }

}

