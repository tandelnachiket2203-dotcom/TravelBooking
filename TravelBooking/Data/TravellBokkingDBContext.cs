using Microsoft.EntityFrameworkCore;
using TravelBooking.Models.Domains;

namespace TravelBooking.Data
{
    public class TravellBokkingDBContext: DbContext
    {
        public TravellBokkingDBContext(DbContextOptions<TravellBokkingDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Paayment> Paayments { get; set; }

    }
}
