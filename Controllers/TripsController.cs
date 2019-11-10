using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelTracker.BackService.Data;
using TravelTracker.BackService.Models;

namespace TravelTracker.BackService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        //private Repository _repository;

        TripContext _context;

        public TripsController(TripContext tripContext)
        {
            _context = tripContext;
        }
        
        // GET api/Trips
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _context.Trips.ToList();
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _context.Trips.Find(id);
        }

        // POST api/Trips
        [HttpPost]
        public void Post([FromBody] Trip values)
        {
            _context.Add(values);
        }

        // PUT api/Trips/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip values)
        {
            _context.Update(values);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Remove(id);
        }
    }
}
