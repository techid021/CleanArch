using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private UniversityDBContext universityDBContext;
        public UserRepository(UniversityDBContext universityDBContext)
        {
            this.universityDBContext = universityDBContext;
        }

        public void AddUser(User user)
        {
            universityDBContext.users.Add(user);
        }

        public bool IsExistEmail(string email)
        {
            return universityDBContext.users.Any(u => u.Email == email);
        }

        public bool IsExistUser(string email, string password)
        {
            return universityDBContext.users.Any(u => u.Email == email && u.Password == password);
        }

        public bool IsExistUserName(string username)
        {
            return universityDBContext.users.Any(u => u.UserName == username);
        }

        public void Save()
        {
            universityDBContext.SaveChanges();
        }
    }
}
