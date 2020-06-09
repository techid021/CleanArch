using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer
            service.AddScoped<ICourseService, CourseService>();
            service.AddScoped<IUserService, UserService>();


            //Infra Data Layer
            service.AddScoped<ICourseRepository, CourseRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
