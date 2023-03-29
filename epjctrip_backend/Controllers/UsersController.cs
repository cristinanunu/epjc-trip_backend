using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using epjctrip_backend.Models;
using epjctrip_backend.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace epjctrip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UsersController(IConfiguration config, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _config = config;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("JwtConfig:SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet("{id}")]
        public Task<ActionResult<User>> GetUser(int id)
        {
            var user = _userRepository.GetOne(id).Result.Value;

            return user == null
                ? Task.FromResult<ActionResult<User>>(NotFound())
                : Task.FromResult<ActionResult<User>>(user);
        }

        [HttpPost("/login")]
        public Task<ActionResult<User>> Login(LoginRequest login)
        {
            var user = _userRepository.Login(login).Result;

            if (user == null)
            {
                return Task.FromResult<ActionResult<User>>(Unauthorized());
            }

            var token = GenerateJwtToken(user);
            return Task.FromResult<ActionResult<User>>(Ok(new { token, user.Id, user.Name, user.Email }));
        }

        [HttpPost("/register")]
        public async Task<ActionResult<User>> Register(RegisterRequest request)
        {
            var newUser = await _userRepository.Create(new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            });

            var actionName = nameof(GetUser);
            var routeValue = new { id = newUser.Id };
            return CreatedAtAction(actionName, routeValue, newUser);
        }
    }
}