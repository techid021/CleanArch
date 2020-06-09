using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

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
            return View("SuccessRegister",register);
        }
    }
}