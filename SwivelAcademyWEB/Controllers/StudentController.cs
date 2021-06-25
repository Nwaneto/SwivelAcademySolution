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
    }
}
