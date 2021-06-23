using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwivelAcademyAPI.Controllers
{
    [Route("api/v{version:apiVersion}/Student")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class StudentController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly ISRepository _sRepository;
        private readonly IMapper _mapper;
        private static IHttpContextAccessor _httpConAccessor;

        public StudentController(ISRepository sRepository,
            IMapper mapper, IWebHostEnvironment environment, IHttpContextAccessor httpConAccessor)
        {
            _sRepository = sRepository;
            _mapper = mapper;
            _environment = environment;
            _httpConAccessor = httpConAccessor;
        }

        #region End point to Create a Student Profile

        /// <summary>
        /// End point to Create a Student Profile
        /// </summary>
        /// <param name="studModel"></param>
        /// <returns>"Successfully Created" if successful</returns>
        [HttpPost("Profile")]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCourse(StudentModelDto studModel)
        {
            if (studModel == null)
            {
                return BadRequest(ModelState);
            }
            var studentObj = _mapper.Map<StudentModel>(studModel);

            if (_sRepository.CreateProfile(studentObj) == "Successfully Created")
            {
                return Created("api/v{version:apiVersion}/Student/Profile", "Successful");
            }
            else
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record for {studModel.FirstName}, check the value of your inputs properly and try again.");
                return StatusCode(500, ModelState);
            }

        }

        #endregion End point to Create a Student Profile
    }
}
