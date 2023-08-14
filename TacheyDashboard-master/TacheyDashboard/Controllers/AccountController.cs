using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Helpers;
using TacheyDashboard.ViewModel.Account;

namespace TacheyDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly JwtHelper _jwt;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtHelper jwt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = jwt;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public string JwtLogin([FromBody] JwtLoginModel jwt)
        {
            return _jwt.GenerateToken(jwt.Email, jwt.Password);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

                if (result.Succeeded)
                {
                    //if(User.Identity.IsAuthenticated)
                    //{
                    //    if(User.IsInRole("Admin"))
                    //    {
                    //        return RedirectToAction("Index", "Home");
                    //    }
                    //    else 
                    //    {
                    //        return RedirectToAction("UploadVideo", "Common");
                    //    }
                    //}
                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError(string.Empty, "登入嘗試失試。");

            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

    }

}
