using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public CourseViewModel GetCourse()
        {
            return new CourseViewModel { Courses = courseRepository.GetCourses() };
        }

        //خالی بودن اینجا هم چک نمیشود
        public Course GetCourseById(int courseId)
        {
            Course course = courseRepository.GetCourse(courseId);
            return course;
        }
    }
}
