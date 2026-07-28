using Estudo.Class.Auth;
using Estudo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Estudo.AppDbContext; 
public class AppProductContext : IdentityDbContext<ApplicationUser>
{
    public AppProductContext(DbContextOptions<AppProductContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Product { get; set; }
}
