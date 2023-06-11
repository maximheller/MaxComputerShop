using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Max.Models;
using Microsoft.Extensions.Options;
using Max.Data;
using Microsoft.EntityFrameworkCore;
using Max.Models.viewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Max.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    // localhost:5555/api/auth
    public class LoginController : ControllerBase
    {

        private readonly ShopContext _context; 
        private readonly IConfiguration _configuration;

        public LoginController(ShopContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Post(UserLoginViewModel userViewModel)
        {
            User? userFromDb = _context.Users.Include(u=> u.Role).FirstOrDefault(
               u => u.Name.Equals(userViewModel.Name) && u.Password.Equals(userViewModel.Password));
            if (userFromDb == null)
            {
                return BadRequest(new { message = "Wrong login or password!" });
            }

            // 2. Generate JWT token
            List<Claim> claims = new List<Claim>() {
                    new Claim (ClaimsIdentity.DefaultNameClaimType, userFromDb.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userFromDb.Role?.Name),
                    new Claim ("Email", userFromDb.Email),
                    new Claim ("Id", userFromDb.Id.ToString())
                };
            TokenHelper tokenHelper = new TokenHelper(_configuration);
            string token = tokenHelper.CreateToken(claims); // TODO on server we get exception 
            return Ok(new { Token = token});
        }
    }
}
