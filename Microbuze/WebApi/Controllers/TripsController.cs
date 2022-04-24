using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTripsFiltered(string departureLocation, string destination,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var filteredTrips = await _tripsService.FindTripsFiltered(departureLocation, destination, cancellationToken);
                return Ok(filteredTrips);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTrip(DAgencyUser dAgencyUser, string departureLocation, string destination, DateTime departureTime,
            TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdTrip = await _tripsService.CreateTrip(dAgencyUser, departureLocation,
                    destination, departureTime, duration, price, seats, cancellationToken);
                return CreatedAtAction(nameof(GetTripById), new { id = createdTrip.Id }, createdTrip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
