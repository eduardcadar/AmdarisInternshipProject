using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Domain.Domain;

namespace Api.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        [Route("{userid}-{tripid}")]
        [HttpGet]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int userid, int tripid, CancellationToken cancellationToken = default)
        {
            try
            {
                var reservation = await _reservationsService.FindReservationById(userid, tripid, cancellationToken);
                if (reservation == null)
                    return NotFound();
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("byRegularUserId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByRegularUserId(int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var reservations = await _reservationsService.FindReservationsByRegularUserId(id, cancellationToken);
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("byTripId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByTripId(int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var reservations = await _reservationsService.FindReservationsByTripId(id, cancellationToken);
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation(TripCreationObject tripCreationObject, int seats,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var createdReservation = await _reservationsService.CreateReservation(tripCreationObject.Trip,
                    tripCreationObject.RegularUser, seats, cancellationToken);
                return CreatedAtAction(nameof(GetReservationById),
                    new { userid = createdReservation.RegularUser.Id, tripid = createdReservation.Trip.Id },
                    createdReservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public record TripCreationObject
    {
        public DTrip? Trip { get; set; }
        public DRegularUser? RegularUser { get; set; }
    }
}
