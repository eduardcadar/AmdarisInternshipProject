using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Domain.Domain;
using Api.DTO;
using Domain.Repository;

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
        public async Task<ActionResult<AgencyUserDTO>> GetAgencyUserById(string id, CancellationToken cancellationToken = default)
        {
            var agencyUserDto = await _agencyUsersService.FindAgencyUserById(id, cancellationToken);
            if (agencyUserDto == null)
                return NotFound();
            return Ok(agencyUserDto);
        }

        [Route("byname/{username}")]
        [HttpPost]
        public async Task<ActionResult<DAgencyUser>> GetAgencyUserByUsername(string username,
            CancellationToken cancellationToken = default)
        {
            var agencyUserDto = await _agencyUsersService.FindAgencyUserByUsername(
                username, cancellationToken);
            if (agencyUserDto == null)
                return NotFound();
            return Ok(agencyUserDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgencyUser([FromBody] AgencyUserCreateDTO agencyUser, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdAgencyUser = await _agencyUsersService.CreateAgencyUser(agencyUser.Id, agencyUser.Username,
                    agencyUser.PhoneNumber, agencyUser.Agency, cancellationToken);
                return CreatedAtAction(nameof(GetAgencyUserById), new { id = createdAgencyUser.Id }, createdAgencyUser);
            }
            catch (RepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
