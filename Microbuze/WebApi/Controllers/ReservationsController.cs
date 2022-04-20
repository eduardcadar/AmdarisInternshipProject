using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.Models;
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
            var reservation = await _reservationsService.FindReservationById(userid, tripid, cancellationToken);
            return Ok(reservation);
        }

        [Route("byRegularUserId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByRegularUserId(int id,
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

        //[HttpPost]
        //public async Task<ActionResult> CreateReservation(DTrip trip, DRegularUser regularUser, int seats,
        //    CancellationToken cancellationToken = default)
        //{
        //    var createdReservation = _reservationsService.CreateReservation(trip, regularUser, seats, cancellationToken);
        //    return CreatedAtAction(createdReservation);
        //}
    }
}
