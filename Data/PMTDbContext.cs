using Microsoft.EntityFrameworkCore;
using PlanMyTrip.Models;

namespace PlanMyTrip.Data
{
    public class PMTDbContext:DbContext
    {
        public PMTDbContext(DbContextOptions<PMTDbContext> options): base(options)
        {

        }

        public DbSet<User> UserTable { get; set; }
        public DbSet<Package> PackageTable { get; set; }
        public DbSet<PackageImage> PackageImageTable { get; set; }
        public DbSet<Booking> BookingTable { get; set; }
    }
}
