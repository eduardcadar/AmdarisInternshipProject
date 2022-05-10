using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<RegularUserDTO>> GetRegularUserById(int id, CancellationToken cancellationToken = default)
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

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<DRegularUser>> GetRegularUserByUsernameAndPassword([FromBody] LoginDTO login,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var regularUserDto = await _regularUsersService.FindRegularUserByUsernameAndPassword(login.Username, login.Password, cancellationToken);
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
                var createdRegularUser = await _regularUsersService.CreateRegularUser(regularUser.Username, regularUser.Password,
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
