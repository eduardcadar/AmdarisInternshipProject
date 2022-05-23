using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Domain.Domain;
using Api.DTO;

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

        [Route("{tripid}-{userid}")]
        [HttpGet]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int tripid, int userid, CancellationToken cancellationToken = default)
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
                return BadRequest(ex.ToString());
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
                return BadRequest(ex.ToString());
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
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationCreateDTO reservation,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var createdReservation = await _reservationsService.CreateReservation(reservation.TripId,
                    reservation.RegularUserId, reservation.Seats, cancellationToken);
                return CreatedAtAction(nameof(GetReservationById),
                    new { userid = createdReservation.RegularUser.Id, tripid = createdReservation.Trip.Id },
                    createdReservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{tripid}-{userid}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteReservation(int tripid, int userid, CancellationToken cancellationToken = default)
        {
            await _reservationsService.DeleteReservation(tripid, userid, cancellationToken);
            return Ok();
        }
    }
}
