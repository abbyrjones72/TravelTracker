using Microsoft.EntityFrameworkCore;
using TravelTracker.BackService.Models;

namespace TravelTracker.BackService.Data
{
    public class TripContext:DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Trip>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
