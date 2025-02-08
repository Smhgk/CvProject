using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CvProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminRepository _repo = new AdminRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string mail, string password)
        {
            var user = _repo.TFind(x => x.KullaniciAdi == mail && x.Sifre == password);
            if (user != null)
            {
                if (user.KullaniciAdi != null)
                {
                    List<Claim> claims;
                    {
                        claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.KullaniciAdi),
                        new Claim(ClaimTypes.Role, "admin"),
                    };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(claimsIdentity);
                        var authProperties = new AuthenticationProperties();

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                        return RedirectToAction("Index", "Deneyim");
                    }
                }
            }
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index");
        }
    }
}
