using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public interface ICourseService
    {
        CourseViewModel GetCourse();
    }
}
