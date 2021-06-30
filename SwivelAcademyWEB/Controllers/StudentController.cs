using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwivelAcademyWEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwivelAcademyWEB.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public static IConfiguration _configuration { get; set; }
        private readonly ISRepository _sRepo;

        public StudentController(IHttpClientFactory clientFactory, IConfiguration configuration, ISRepository sRepo)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _sRepo = sRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult RegisterForCourse()
        {
            return View();
        }
        public IActionResult RegisterProfile()
        {
            return View();
        }
        public IActionResult UpdateProfile()
        {
            return View();
        }
        public IActionResult ViewProfile()
        {
            return View(); 
        }
        public async Task<string> GetRegisteredCourses()
        {
            string url = _configuration.GetValue<string>("Endpoints:GetRegCourses");
            int userId = _configuration.GetValue<int>("AppData:UserId");

            var data = await _sRepo.GetRegisteredCourses(url, userId);

            return data;
        }

        public async Task<string> GetAllCourses()
        {
            string url = _configuration.GetValue<string>("Endpoints:GetAllCourses");
            int userId = _configuration.GetValue<int>("AppData:UserId");

            var data = await _sRepo.GetAllCourses(url);

            return data;
        }

        //public async Task<bool> RegisterForCourse(int Job_Id, int UserId)
        //{

        //}
    }
}
