using Ana_Panel.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ana_Panel.Models
{
    public class SirketVeritabaniContext : DbContext
    {
        public SirketVeritabaniContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Station> Stations { get; set; }

    }
}
