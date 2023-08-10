using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AuthProject.Models;
using AuthProject.Data;

namespace AuthProject.Controllers
{
    public class AccessController : Controller
    {
        private readonly AppDbContext _context;

        public AccessController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");


            return View();
        }


        [HttpPost]


        public async Task<IActionResult> Login(Login modelLogin)
        {
            var role = _context.roles.Where(x => x.Email == modelLogin.Email && x.Password == modelLogin.PassWord).FirstOrDefault();
            if (role == null)
            {
                ViewData["ValidateMessage"] = "User not found";
                return View();
            }

            List<Claim> claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
          //    new Claim("OtherProperties", "Example Role"),
                new Claim(ClaimTypes.Role, role.RollName)
              };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = modelLogin.KeepLoggedIn,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index" ,"Home");
        }


    }
}