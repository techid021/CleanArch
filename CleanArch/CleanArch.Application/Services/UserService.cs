using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public CheckUser CheckUser(string userName, string email)
        {
            bool userNameValid = userRepository.IsExistUserName(userName);
            bool emailValid = userRepository.IsExistEmail(email);

            if (userNameValid && emailValid)
            {
                return ViewModels.CheckUser.UserNameAndEmailNotValid;
            }
            else if (userNameValid)
            {
                return ViewModels.CheckUser.UserNameNotValid;
            }
            if (emailValid)
            {
                return ViewModels.CheckUser.EmailNotValid;
            }

            return ViewModels.CheckUser.Ok;

        }

        public bool IsExistUser(string email, string password)
        {
            return userRepository.IsExistUser(email.Trim(), PasswordHelper.EncodePasswordMd5(password.Trim()));
        }

        public int RegisterUser(User user)
        {
            userRepository.AddUser(user);
            userRepository.Save();
            return user.UserId;

        }
    }
}
