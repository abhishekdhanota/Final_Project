using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Final_Project.Models;
using System.Diagnostics;

namespace Final_Project.Controllers
{
    public class TripsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Trips/ListTrips
        [HttpGet]
        public IEnumerable<TripDto> ListTrips()
        {
            List<Trip>Trips=db.Trips.ToList();
            List<TripDto> TripDtos = new List<TripDto>();

            Trips.ForEach(a => TripDtos.Add(new TripDto()
            {
                TripId = a.TripId,
                TruckNumber = a.Truck.TruckNumber,
                DriverName=a.Driver.DriverName,
                DestinationName=a.Destination.DestinationName
            })) ;
            return TripDtos ;
        }

        // GET: api/Trips/FindTrip/5
        [ResponseType(typeof(Trip))]
        [HttpGet]
        public IHttpActionResult FindTrip(int id)
        {
            Trip trip = db.Trips.Find(id);
            TripDto TripDto = new TripDto()
            {
                TripId = trip.TripId,
                TruckNumber = trip.Truck.TruckNumber,
                DriverName = trip.Driver.DriverName,
                DestinationName = trip.Destination.DestinationName
            };
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(TripDto);
        }

        // POST: api/Trips/UpdateTrips/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateTrip(int id, Trip trip)
        {
        
            Debug.WriteLine("i have reached update trip method");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("model state not valid");
                return BadRequest(ModelState);
            }

            if (id != trip.TripId)
            {
                Debug.WriteLine("id mismatch");
                Debug.WriteLine("GET parameter"+id);
                Debug.WriteLine("POST parameter"+trip.TripId);
                return BadRequest();
            }

            db.Entry(trip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    Debug.WriteLine("no trip with this id exist");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Debug.WriteLine("no condition triggered");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Trips/AddTrips
        [ResponseType(typeof(Trip))]
        [HttpPost]
        public IHttpActionResult AddTrip(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trips.Add(trip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trip.TripId }, trip);
        }

        // DELETE: api/Trips/DeleteTrips/5
        [ResponseType(typeof(Trip))]
        [HttpPost]
        public IHttpActionResult DeleteTrip(int id)
        {
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            db.Trips.Remove(trip);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TripExists(int id)
        {
            return db.Trips.Count(e => e.TripId == id) > 0;
        }
    }
}