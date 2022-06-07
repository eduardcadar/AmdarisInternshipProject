using Application.Authentication;
using Application.Authentication.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAgencyUsersService _agencyUsersService;
        private readonly IRegularUsersService _regularUsersService;

        public AccountController(IAuthenticationService authenticationService,
            IAgencyUsersService agencyUsersService, IRegularUsersService regularUsersService)
        {
            _authenticationService = authenticationService;
            _agencyUsersService = agencyUsersService;
            _regularUsersService = regularUsersService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            try
            {
                var authenticationResponse = await _authenticationService.AuthenticateAsync(request);
                return Ok(authenticationResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request,
            CancellationToken cancellationToken = default)
        {
            var registrationResponse = await _authenticationService.RegisterAsync(request);

            if (request.IsAgency)
                await _agencyUsersService
                    .CreateAgencyUser(registrationResponse.UserId, request.UserName,
                    request.PhoneNumber, request.Agency, cancellationToken);
            else
                await _regularUsersService
                    .CreateRegularUser(registrationResponse.UserId, request.UserName,
                    request.PhoneNumber, request.FirstName, request.LastName, cancellationToken);

            return Ok(registrationResponse);
        }
    }
}
