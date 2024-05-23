using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using FamilyTreeAPI.Models;
using FamilyTreeAPI.Data;


namespace FamilyTreeAPI.Controllers
{

    [ApiController, AllowAnonymous, Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        // https://code-maze.com/authentication-aspnetcore-jwt-1/
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            var dbUser = await _userRepository.GetUserAsync(user.UserName, user.Password);

            if (dbUser != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superTroperTotallyUberSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString, User = dbUser.Name });
            }
            return Unauthorized();
        } 
    }
}