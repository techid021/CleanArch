using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] // CallBack Method
        [Route("Register")]
        public IActionResult Register(RegisterViewModels register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            CheckUser checkUser = userService.CheckUser(register.UserName, register.Email);
            if (checkUser != CheckUser.Ok)
            {
                ViewBag.Check = checkUser;
                return View(register);
            }

            User user = new User
            {
                Email = register.Email.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(register.Password.Trim()),
                UserName = register.UserName.Trim()
            };
            userService.RegisterUser(user);
            return View("SuccessRegister", register);
        }
        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login(string returnUrl="/")
        {
            ViewBag.Return = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            if (!userService.IsExistUser(login.Email, login.Password))
            {
                ModelState.AddModelError("Email", "User Not Found ...");
                return View(login);
            }

            var cliams = new List<Claim>
            {
                new Claim(ClaimTypes.Name , login.Email),
                new Claim(ClaimTypes.NameIdentifier , login.Email)
            };
            var identity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);


            return Redirect("/");
        }

        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");

        }

    }
}