using EcommerceProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Data
{
    public class AppDbContext : IdentityDbContext<AppUsers>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<MensClothing> Mens { get; set; }

        public DbSet<WomensClothing> Womens { get; set; }
        public DbSet<KidsClothing> KidsClothing { get; set;}

       
        public DbSet<Orders> Orders { get; set; }

        public DbSet<ProductAddToCart> ProductATC { get; set; }

        
    }
}
