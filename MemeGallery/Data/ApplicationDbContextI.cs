using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MemeGallery.Data;

public class ApplicationDbContextI : IdentityDbContext
{
    public ApplicationDbContextI(DbContextOptions<ApplicationDbContextI> options)
        : base(options)
    {
    }
}

