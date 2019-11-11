using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TravelTracker.BackService.Models;

namespace TravelTracker.BackService.Data
{
    public class TripContext:DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
        public TripContext() { } // for reflections parameter list
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Trip>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            // dependency injection resolution, the using part creates and destroys
            // this when it is done
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())

            {
                // assign tripcontext and auto type it with 'var'
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                // ensure that the database is created so the trips table is as well
                context.Database.EnsureCreated();

                // if no trips, just return
                if (context.Trips.Any())
                {
                    return;
                }

                // if trips, add the array of example trips
                context.Trips.AddRange(new Trip[]
                    {
                        new Trip
                        {
                            Id = 1,
                            Name = "ComicCon 2020",
                            StartDate = new DateTime(2020, 3, 5),
                            EndDate = new DateTime(2020, 3, 9)
                        },

                        new Trip
                        {
                            Id = 2,
                            Name = "NerdiCon 2020",
                            StartDate = new DateTime(2020, 4, 15),
                            EndDate = new DateTime(2020, 4, 19)
                        },

                        new Trip
                        {
                            Id = 3,
                            Name = "C# Developer Conference",
                            StartDate = new DateTime(2020, 5, 3),
                            EndDate = new DateTime(2020, 5, 6)

                        }
                    });

                context.SaveChanges();
            }
        }
    }
}
