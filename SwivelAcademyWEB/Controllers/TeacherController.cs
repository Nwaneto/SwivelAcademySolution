using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwivelAcademyWEB.Models;
using SwivelAcademyWEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwivelAcademyWEB.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public static IConfiguration _configuration { get; set; }
        private readonly ITRepository _tRepo;

        public TeacherController(IHttpClientFactory clientFactory, IConfiguration configuration, ITRepository tRepo)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _tRepo = tRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Course()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Profile(TeacherModel teacherModel)
        {
            //
            return View();
        }
        
        public IActionResult ViewProfile()
        {
            return View();
        }
        public IActionResult ViewMyCourses()
        {
            return View();
        }

        public async Task<string> GetTaughtCourses()
        {
            string url = _configuration.GetValue<string>("Endpoints:GetTaughtCourses");
            int teacherId = _configuration.GetValue<int>("AppData:TeacherId");

            var data = await _tRepo.GetTaughtCourses(url, teacherId);

            return data;
        }

        public async Task<bool> TeachCourse(TeachCourseModel model)
        {
            string url = _configuration.GetValue<string>("Endpoints:TeachCourse");
            //Teacher Id should come from claims
            int teacherId = _configuration.GetValue<int>("AppData:TeacherId");
            model.TeacherID = teacherId;
            var data = await _tRepo.TeachCourse(url, model);
            if (data == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetAllCourses()
        {
            string url = _configuration.GetValue<string>("Endpoints:GetAllCourses");
            int userId = _configuration.GetValue<int>("AppData:TeacherId");

            var data = await _tRepo.GetAllCourses(url);

            return data;
        }
    }
}
