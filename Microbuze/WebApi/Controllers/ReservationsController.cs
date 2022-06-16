using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Authentication;
using Domain.Repository;

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

        [Route("{tripid}:{userid}")]
        [HttpGet]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int tripid, string userid, CancellationToken cancellationToken = default)
        {
            var reservation = await _reservationsService.FindReservationById(userid, tripid, cancellationToken);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [Route("byRegularUserId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByRegularUserId(string id,
            CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationsService.FindReservationsByRegularUserId(id, cancellationToken);
            return Ok(reservations);
        }

        [Route("byTripId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByTripId(int id,
            CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationsService.FindReservationsByTripId(id, cancellationToken);
            return Ok(reservations);
        }

        [HttpPost]
        [Authorize(Roles=Constants.Roles.REGULARUSER)]
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
            catch (RepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{tripid}:{userid}")]
        [HttpDelete]
        [Authorize(Roles=Constants.Roles.REGULARUSER)]
        public async Task<ActionResult> DeleteReservation(int tripid, string userid, CancellationToken cancellationToken = default)
        {
            try
            {
                await _reservationsService.DeleteReservation(tripid, userid, cancellationToken);
                return Ok();
            }
            catch (RepositoryException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("{tripid}:{userid}")]
        [HttpPut]
        [Authorize(Roles=Constants.Roles.REGULARUSER)]
        public async Task<ActionResult> UpdateReservation(int tripid, string userid, [FromBody] int seats, CancellationToken cancellationToken = default)
        {
            try
            {
                await _reservationsService.UpdateReservation(tripid, userid, seats, cancellationToken);
                return Ok();
            }
            catch (RepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
