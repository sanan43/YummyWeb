using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using yummysayt.Models;
using yummysayt.Models.Auth;

namespace yummysayt.DAL
{
    public class AppDbContext : IdentityDbContext<MyAppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
