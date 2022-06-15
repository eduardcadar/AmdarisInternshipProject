using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Authentication;
using Domain.Repository;

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

        [Route("{tripid}")]
        [HttpDelete]
        [Authorize(Roles=Constants.Roles.AGENCYUSER)]
        public async Task<ActionResult> DeleteTrip(int tripid, CancellationToken cancellationToken = default)
        {
            try
            {
                await _tripsService.DeleteTrip(tripid, cancellationToken);
                return Ok();
            }
            catch (RepositoryException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrips([FromQuery(Name = "agency")] string? agency,
            [FromQuery(Name = "departure")] string? departureLocation, [FromQuery(Name = "destination")] string? destination,
            [FromQuery(Name = "date")] string? dateString, CancellationToken cancellationToken = default)
        {
            try
            {
                DateTime? date = null;
                if (agency == null)
                    agency = "";
                if (departureLocation == null)
                    departureLocation = "";
                if (destination == null)
                    destination = "";
                if (dateString != null)
                    date = DateTime.Parse(dateString);
                var filteredTrips = await _tripsService
                    .FindTripsFiltered(agency, departureLocation, destination, date, cancellationToken);
                return Ok(filteredTrips);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles=Constants.Roles.AGENCYUSER)]
        public async Task<ActionResult> CreateTrip([FromBody] TripCreateDTO trip, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdTrip = await _tripsService.CreateTrip(trip.AgencyUserId, trip.DepartureLocation, trip.Destination,
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
