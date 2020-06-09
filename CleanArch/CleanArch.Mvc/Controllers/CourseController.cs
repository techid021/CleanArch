using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Services;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult Index()
        {
            CourseViewModel model = courseService.GetCourse();
            return View(model);
        }

        public IActionResult ShowCourse(int id)
        {
            Course course = courseService.GetCourseById(id);
            if (course==null)
            {
                return NotFound();
            }
            return View(course);
        }

    }
}