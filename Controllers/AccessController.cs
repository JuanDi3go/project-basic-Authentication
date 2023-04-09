using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using project_basic_Authentication.Data;
using project_basic_Authentication.Models;
using System.Security.Claims;

namespace project_basic_Authentication.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserProgram userLogin)
        {
            Data_logic _da_User = new Data_logic();

            var user = _da_User.ValidateUser(userLogin.Email, userLogin.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("Email", user.Email)
                };

                foreach(string rol in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }


                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
                return View();

        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Access");
        }
    }
}
