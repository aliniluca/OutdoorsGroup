using Microsoft.EntityFrameworkCore;
using OutdoorsGroup.Models;

namespace OutdoorsGroup.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Race> Races { get; set; }
        public DbSet<Club> Clubs { get; set; }  
        public DbSet<Address> Addresses { get; set; }

    }
}
