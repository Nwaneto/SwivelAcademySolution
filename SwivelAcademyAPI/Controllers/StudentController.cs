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
        public IActionResult CreateStudent(StudentModelDto studModel)
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

        #region End point to Update a Student record
        /// <summary>
        /// End point to Update a Student record
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentDto"></param>
        /// <returns>"Updated Successfully" if update was successful</returns>
        [HttpPatch("UpdateStudent/{studentId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult updateStudent(int studentId, StudentModelDto studentDto)
        {
            if (studentDto == null || studentId < 1)
            {
                return BadRequest(ModelState);
            }
            if (_sRepository.UpdateStudent(studentId, studentDto) != "Updated Successfully")
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record for {studentDto.FirstName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated Successfully");
        }
        #endregion End point to Update a Student record

        #region End point to Get a Student

        /// <summary>
        /// End point to Get a Student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>A student object</returns>
        [HttpGet("Student/{studentId:int}")]
        [ProducesResponseType(200, Type = typeof(StudentModel))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetStudentById(int studentId)
        {
            var studentObj = _sRepository.GetStudentByCourseId(studentId);
            if (studentObj == null)
            {
                return NotFound();
            }
            return Ok(studentObj);
        }

        #endregion End point to Get a Student

        #region End point to Get all Students

        /// <summary>
        /// End point to Get all Students
        /// </summary>
        /// <param></param>
        /// <returns>A List of students</returns>
        [HttpGet("Students")]
        [ProducesResponseType(200, Type = typeof(StudentModel))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentObj = await _sRepository.GetAllStudents();
            if (studentObj == null)
            {
                return NotFound();
            }
            return Ok(studentObj);
        }
        #endregion End point to Get all Students

        #region End point to Delete a Student

        /// <summary>
        /// End point to Delete a Student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Successful</returns>
        [HttpDelete("DeleteStudent/{studentId:int}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteStudentById(int studentId)
        {
            var result = _sRepository.DeleteStudent(studentId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        #endregion End point to Delete a Student
    }
}
