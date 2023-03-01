using BusinessLayer;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SmartTech.Controllers
{
    public class AccountController : Controller
    {
        AccountBL business = new AccountBL();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
 
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAuthoCL userAutho)
        {
            if (ModelState.IsValid)
            {
                int result = business.LoginUser(userAutho);
                if (result == 1)
                {
                    var claims = new List<Claim>()
                    {

                        new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userAutho.Email)),
                        new Claim(ClaimTypes.Name,userAutho.Email),
                        new Claim(ClaimTypes.Role,"Admin"),
                        //new Claim(ClaimTypes.Email,Convert.ToString(result)),


                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = true
                    }); ;
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 2)
                {
                    var claims = new List<Claim>()
                    {

                        new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userAutho.Email)),
                        new Claim(ClaimTypes.Name,userAutho.Email),
                        new Claim(ClaimTypes.Role,"User"),

                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = true
                    }); 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Invalid Login Credentails!";
                    return View(userAutho);
                }


            }
            return View(userAutho);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


    }
}
