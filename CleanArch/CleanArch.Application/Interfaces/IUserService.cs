using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        CheckUser CheckUser(string userName, string email);
        int RegisterUser(User user);
    }
}
