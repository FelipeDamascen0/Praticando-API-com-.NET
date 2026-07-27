using Estudo.Class;
using Microsoft.EntityFrameworkCore;

namespace Estudo.AppDbContext;

public class AppProductContext : DbContext
{
    public AppProductContext(DbContextOptions<AppProductContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Product { get; set; }
}
