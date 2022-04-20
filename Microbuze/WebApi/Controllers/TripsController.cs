using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.Models;
using Domain.Domain;

namespace Api.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTripsFiltered(string departureLocation, string destination,
            CancellationToken cancellationToken = default)
        {
            var filteredTrips = await _tripsService.FindTripsFiltered(departureLocation, destination, cancellationToken);
            return Ok(filteredTrips);
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateTrip(DAgencyUser dAgencyUser, string departureLocation, string destination, DateTime departureTime,
        //    TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default)
        //{
        //    var createdTrip = await _tripsService.CreateTrip(dAgencyUser, departureLocation,
        //        destination, departureTime, duration, price, seats, cancellationToken);
        //    return CreatedAtAction(createdTrip);
        //}
    }
}
