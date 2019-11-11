using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTracker.BackService.Data;
using TravelTracker.BackService.Models;

namespace TravelTracker.BackService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        // in memory controller for testing
        // private Repository _repository;
        TripContext _context;

        public TripsController(TripContext tripContext)
        {
            _context = tripContext;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        // GET api/Trips
        [HttpGet]

        // set to async to handle the asynchronous in/out
        // to the database. IActionResult ensures that we
        // can return usable status codes. Ok helper method
        // returns 'OK 200' responses.
        public async Task<IActionResult> GetAsync()
        {
            var trips = await _context.Trips
                // .AsNoTracking() // disables change tracking, only focused on results, 
                // this is replaced above in the TripsController constructor
                .ToListAsync();
            return Ok(trips);
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _context.Trips.Find(id);
        }

        // POST api/Trips
        [HttpPost]
        public IActionResult Post([FromBody] Trip values)
        {
            // we are specifying Trips here because we don't
            // need the db _context to automatically assume it knows
            // which object. If we had multiple objects, we could leave it
            // as something like _context.Add(values);

            // if no workie
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // if workie
            _context.Trips.Add(values);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/Trips/5
        [HttpPut("{id}")]

        // changed to Async because of the nature of the db calls
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trip values)
        {

            // validate Id
            if(!_context.Trips.Any(t => t.Id == id)) // SELECT TOP(1) on the Db
            {
                return NotFound(id);
            }
            // validate state
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // we also need to worry about nulls
            // new way, updates the entire object
            _context.Trips.Update(values);
            await _context.SaveChangesAsync();

            // if not bad, return okay (200)
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var myTrip = _context.Trips.Find(id);
            if(myTrip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(myTrip);
            _context.SaveChangesAsync();

            // DELETE FROM db WHERE id = ?
            return NoContent();
        }
    }
}
