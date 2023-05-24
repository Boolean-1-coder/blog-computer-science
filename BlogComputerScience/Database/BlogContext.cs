using BlogComputerScience.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogComputerScience.Database
{
    public class BlogContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFTecBlog;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
