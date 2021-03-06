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

        public StudentController(ISRepository sRepository)
        {
            _sRepository = sRepository;
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
        public ActionResult CreateStudent(StudentModel studModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sModel = new StudentModel();
            //var studentObj = _mapper.Map<StudentModel>(studModel);

            if (_sRepository.CreateStudent(studModel) == "Successfully Created")
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
        public ActionResult<StudentModel> GetStudentById(int studentId)
        {
            var studentObj = _sRepository.GetStudentById(studentId);
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
            var studentObj = _sRepository.GetStudentById(studentId);
            if (studentObj == null)
            {
                return NotFound();
            }
            else
            {
                var result = _sRepository.DeleteStudent(studentId);
                return Ok(result);
            }
            
        }

        #endregion End point to Delete a Student

        #region End point to Register For a course

        /// <summary>
        /// End point to Register For a course
        /// </summary>
        /// <param name="regCourse"></param>
        /// <returns>"Successfully Created" if successful</returns>
        [HttpPost("RegisterCourse")]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult RegisterCourse(RegisterCourseModel regCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_sRepository.RegisterCourse(regCourse) == "Successfully Created")
            {
                return Created("api/v{version:apiVersion}/Student/RegisterCourse", "Successfully Created");
            }
            else
            {
                ModelState.AddModelError("", $"Something went wrong, check the value of your inputs properly and try again.");
                return StatusCode(500, ModelState);
            }

        }

        #endregion End point to Register For a course

        #region End point to Get all Courses registered by a Students

        /// <summary>
        /// End point to Get all Courses registered by a Students
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>A List of Courses</returns>
        [HttpGet("All-registered-courses/{studentId:int}")]
        [ProducesResponseType(200, Type = typeof(RegCourses))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllCoursesByStudent(int studentId)
        {
            var courseObj = await _sRepository.GetAllCoursesByStudent(studentId);
            if (courseObj == null)
            {
                return NotFound();
            }
            return Ok(courseObj);
        }
        #endregion End point to Get all Courses registered by a Students
    }
}
