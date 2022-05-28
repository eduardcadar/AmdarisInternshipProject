using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Domain.Domain;
using Application.DTOs;
using Api.DTO;

namespace Api.Controllers
{
    [Route("api/regularUsers")]
    [ApiController]
    public class RegularUsersController : ControllerBase
    {
        private readonly IRegularUsersService _regularUsersService;

        public RegularUsersController(IRegularUsersService regularUsersService)
        {
            _regularUsersService = regularUsersService;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<RegularUserDTO>> GetRegularUserById(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var regularUserDto = await _regularUsersService.FindRegularUserById(id, cancellationToken);
                if (regularUserDto == null)
                    return NotFound();
                return Ok(regularUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Route("byname/{username}")]
        [HttpPost]
        public async Task<ActionResult<DRegularUser>> GetRegularUserByUsername(string username,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var regularUserDto = await _regularUsersService.FindRegularUserByUsername(username, cancellationToken);
                if (regularUserDto == null)
                    return NotFound();
                return Ok(regularUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegularUser([FromBody] RegularUserCreateDTO regularUser, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdRegularUser = await _regularUsersService.CreateRegularUser(regularUser.Id, regularUser.Username,
                    regularUser.PhoneNumber, regularUser.FirstName, regularUser.LastName, cancellationToken);
                return CreatedAtAction(nameof(GetRegularUserById), new { id = createdRegularUser.Id }, createdRegularUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
