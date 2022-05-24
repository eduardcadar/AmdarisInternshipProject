using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Api.DTO;

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

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<TripDTO>> GetTripById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var trip = await _tripsService.FindTripById(id, cancellationToken);
                if (trip == null)
                    return NotFound();
                return Ok(trip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrips([FromQuery(Name = "departure")] string? departureLocation,
            [FromQuery(Name = "destination")] string? destination, CancellationToken cancellationToken = default)
        {
            try
            {
                if (departureLocation == null)
                    departureLocation = "";
                if (destination == null)
                    destination = "";
                var filteredTrips = await _tripsService.FindTripsFiltered(departureLocation, destination, cancellationToken);
                return Ok(filteredTrips);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTrip([FromBody] TripCreateDTO trip, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdTrip = await _tripsService.CreateTrip(trip.AgencyId, trip.DepartureLocation, trip.Destination,
                    DateTime.Parse(trip.DepartureTime), TimeSpan.Parse(trip.Duration), trip.Price, trip.Seats, cancellationToken);
                return CreatedAtAction(nameof(GetTripById), new { id = createdTrip.Id }, createdTrip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
