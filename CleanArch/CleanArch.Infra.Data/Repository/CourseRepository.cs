using CleanArch.Application.Services;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private UniversityDBContext universityDBContext;
        public CourseRepository(UniversityDBContext universityDBContext)
        {
            this.universityDBContext = universityDBContext;
        }

        // اینجا خالی بودن چک نمیشود
        //وظیفه این بخش نیست
        //null
        public Course GetCourse(int courseId)
        {
            return universityDBContext.Courses.Find(courseId);
        }

        public IEnumerable<Course> GetCourses()
        {
            return universityDBContext.Courses;
        }
    }
}
