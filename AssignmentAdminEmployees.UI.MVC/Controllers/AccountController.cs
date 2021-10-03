using AssignmentAdminEmployees.Application.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        private ILoginService _loginService;
        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }
       [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string Username, string password, string returnUrl)
        {
            if (Username == null)
            {
                TempData["ErrorMessageUsername"] = "Please Enter username.";
                return View("login");
            }
            else if (password == null)
            {
                TempData["ErrorMessagePassword"] = "Please Enter password.";
                return View("login");
            }
            else
            {
                var dbUser = _loginService.Validation(Username, password);

                if (dbUser != null)
                {
                 
                    var claims = new List<Claim>();
                    claims.Add(new Claim("Uid", dbUser.User_Id.ToString()));
                    claims.Add(new Claim("username", Username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, Username));
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                        return RedirectToAction("Index", "Account");
                }

                TempData["ErrorMessage"] = "Invalid username or password.";
                return View("login");
            }

        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}

