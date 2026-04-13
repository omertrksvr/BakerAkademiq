using Baker.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Baker.WebApi.Context
{
    public class BakerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Başına "Server=" ekledik ve parametreleri ayırdık
            optionsBuilder.UseSqlServer("Server=OMER\\SQLEXPRESS; Initial Catalog=DbBakerAkademiq; Integrated Security=true; TrustServerCertificate=true");
        }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<About> Abouts { get; set; }
     
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }

    }
}