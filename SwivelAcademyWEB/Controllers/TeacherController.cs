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
            return View();
        }
    }
}
