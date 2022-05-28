using Application.Authentication;
using Application.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(IOptions<JwtSettings> jwtSettings, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) throw new Exception($"User '{request.UserName}' not found");
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (!result.Succeeded) throw new Exception($"Credentials for '{request.UserName}' aren't valid");

            var jwtSecurityToken = await GenerateToken(user);

            var response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName,
                IsAgency = user.IsAgency
            };
            return response;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null) throw new Exception($"Username '{request.UserName}' already exists");

            var user = new AppUser
            {
                UserName = request.UserName,
                IsAgency = request.IsAgency
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
                return new RegistrationResponse { UserId = user.Id };
            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> GenerateToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(t => new Claim("roles", t)).ToList();

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("uid", user.Id)
                }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
