using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public interface ICourseService
    {
        CourseViewModel GetCourse();
        Course GetCourseById(int courseId);
    }
}
