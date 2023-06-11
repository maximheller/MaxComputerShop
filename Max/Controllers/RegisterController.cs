using Max.Data;
using Max.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Max.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        IRepository repository;

        public RegisterController(IRepository repository)
        {
            this.repository = repository;
        }

       

        [HttpPost]
        public IActionResult Register(UserCreateViewModel model)
        {
            User user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                RoleId = 1  // TODO 1 in variable
            };
            repository.Add(user);
            return Ok();
        }

      

        //[HttpPost]
        //public IActionResult Login(User user)
        //{
        //    User? user1 = repository.Users.FirstOrDefault();

        //    bool b1 = user1.Email == user.Email;
        //    bool b2 = user1.Password == user.Password;


        //    User ? foundUser = repository.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            
        //    if (foundUser == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        //HttpContext.Session.SetString("Login", foundUser.Name);
        //        //HttpContext.Session.SetInt32("Id", foundUser.Id);

        //        // создаем один claim

        //        //string address = "";
        //        //if (foundUser.Address != null)
        //        //{
        //        //    address = foundUser.Address;
        //        //}
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, foundUser.Name),
        //            new Claim("Id", foundUser.Id.ToString()),
        //            new Claim("age", "18"),
        //            // new Claim("Address", address)
        //        };
        //        // создаем объект ClaimsIdentity
        //        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", 
        //            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //        // установка аутентификационных куки
        //        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        //        return RedirectToAction("Index", "Home");
        //    }           
        //}

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


    }
}
