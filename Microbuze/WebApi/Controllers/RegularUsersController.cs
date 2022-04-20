using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Domain.Domain;
using Application.Models;

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
            var regularUserDto = await _regularUsersService.FindRegularUserById(id, cancellationToken);
            return Ok(regularUserDto);
        }

        [HttpGet]
        public async Task<ActionResult<DRegularUser>> GetRegularUserByUsernameAndPassword(string username, string password,
            CancellationToken cancellationToken = default)
        {
            var regularUserDto = await _regularUsersService.FindRegularUserByUsernameAndPassword(username, password, cancellationToken);
            return Ok(regularUserDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegularUser(DRegularUser dRegularUser, CancellationToken cancellationToken = default)
        {
            var createdUser = await _regularUsersService.CreateRegularUser(dRegularUser.Username, dRegularUser.Password,
                dRegularUser.PhoneNumber, dRegularUser.FirstName, dRegularUser.LastName, cancellationToken);
            return CreatedAtAction(nameof(GetRegularUserById), new { id = createdUser.Id }, dRegularUser);
        }
    }
}
