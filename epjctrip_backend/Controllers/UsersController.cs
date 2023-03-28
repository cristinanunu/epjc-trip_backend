using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epjctrip_backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace epjctrip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TripContext _context;
        private readonly IConfiguration _config;

        public UsersController(IConfiguration config, TripContext context)
        {
            _context = context;
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // // GET: api/Users
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        // {
        //   if (_context.User == null)
        //   {
        //       return NotFound();
        //   }
        //     return await _context.User.ToListAsync();
        // }
        //
        // // GET: api/Users/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<User>> GetUser(int id)
        // {
        //   if (_context.User == null)
        //   {
        //       return NotFound();
        //   }
        //     var user = await _context.User.FindAsync(id);
        //
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return user;
        // }

        // // PUT: api/Users/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutUser(int id, User user)
        // {
        //     if (id != user.Id)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _context.Entry(user).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!UserExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //
        //     return NoContent();
        // }
        
        [HttpPost]
        public async Task<ActionResult<User>> Login(LoginRequest login)
        {

            var user = _context.User.FirstOrDefaultAsync(user =>
                user.Email == login.Email && user.Password == login.Password).Result;
            
            if (user == null)
            {
                return Unauthorized();
            }
            
            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        // // DELETE: api/Users/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     if (_context.User == null)
        //     {
        //         return NotFound();
        //     }
        //     var user = await _context.User.FindAsync(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _context.User.Remove(user);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // private bool UserExists(int id)
        // {
        //     return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
