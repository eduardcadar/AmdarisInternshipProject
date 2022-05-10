using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.DTOs;
using Domain.Domain;
using Api.DTO;

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
                return BadRequest(ex.ToString());
            }
            
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<DAgencyUser>> GetAgencyUserByUsernameAndPassword([FromBody] LoginDTO loginDTO,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var agencyUserDto = await _agencyUsersService.FindAgencyUserByUsernameAndPassword(
                    loginDTO.Username, loginDTO.Password, cancellationToken);
                if (agencyUserDto == null)
                    return NotFound();
                return Ok(agencyUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgencyUser([FromBody] AgencyUserCreateDTO agencyUser, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdAgencyUser = await _agencyUsersService.CreateAgencyUser(agencyUser.Username,
                    agencyUser.Password, agencyUser.PhoneNumber, agencyUser.AgencyId, cancellationToken);
                return CreatedAtAction(nameof(GetAgencyUserById), new { id = createdAgencyUser.Id }, createdAgencyUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
