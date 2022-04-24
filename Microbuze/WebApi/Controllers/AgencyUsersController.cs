using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Domain.Domain;

namespace Api.Controllers
{
    [Route("api/agencyUsers")]
    [ApiController]
    public class AgencyUsersController : ControllerBase
    {
        private readonly IAgencyUsersService _agencyUsersService;

        public AgencyUsersController(IAgencyUsersService agencyUsersService)
        {
            _agencyUsersService = agencyUsersService;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AgencyUserDTO>> GetAgencyUserById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var agencyUserDto = await _agencyUsersService.FindAgencyUserById(id, cancellationToken);
                if (agencyUserDto == null)
                    return NotFound();
                return Ok(agencyUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<DAgencyUser>> GetAgencyUserByUsernameAndPassword(string username, string password,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var agencyUserDto = await _agencyUsersService.FindAgencyUserByUsernameAndPassword(username, password, cancellationToken);
                if (agencyUserDto == null)
                    return NotFound();
                return Ok(agencyUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgencyUser(DAgencyUser dAgencyUser, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdAgencyUser = await _agencyUsersService.CreateAgencyUser(dAgencyUser.Username,
                    dAgencyUser.Password, dAgencyUser.PhoneNumber, dAgencyUser.Agency, cancellationToken);
                return CreatedAtAction(nameof(GetAgencyUserById), new { id = createdAgencyUser.Id }, createdAgencyUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
