using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
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
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }
        public Trip Get(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }
        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }
        public void Update(Trip tripUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripUpdate.Id));
        }
        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
