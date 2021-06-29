using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwivelAcademyAPI.Controllers
{
    [Route("api/v{version:apiVersion}/Teacher")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TeacherController : ControllerBase
    {
        private readonly ITRepository _tRepository;

        public TeacherController(ITRepository tRepository,
            IMapper mapper, IWebHostEnvironment environment, IHttpContextAccessor httpConAccessor)
        {
            _tRepository = tRepository;
        }


        #region End point to Create a Course

        /// <summary>
        /// End point to create a Course
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns>"Successfully Created" if successful</returns>
        [HttpPost("CreateCourse")]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCourse(CourseModelDto cModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var courseObj = _mapper.Map<CourseModel>(cModel);

            if (_tRepository.CreateCourse(cModel) == "Successfully Created")
            {
                return Created("api/v{version:apiVersion}/Teacher/CreateCourse", "Successful");
            }
            else
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record for {cModel.CourseName}, check the value of your inputs properly and try again.");
                return StatusCode(500, ModelState);
            }

        }

        #endregion End point to create a Course

        #region End point to Update a Course
        /// <summary>
        /// End point to Update a Course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseDto"></param>
        /// <returns>"Updated Successfully" if update was successful</returns>
        [HttpPatch("UpdateCourse/{courseId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult updateCourse(int courseId, CourseModelDto courseDto)
        {
            if (courseDto == null || courseId < 1)
            {
                return BadRequest(ModelState);
            }
            if (_tRepository.UpdateCourse(courseId, courseDto) != "Updated Successfully")
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record for {courseDto.CourseName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated Successfully");
        }
        #endregion End point to Update a Course

        #region End point to Get a Course by courseId

        /// <summary>
        /// End point to Get a Course by courseId
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>A course object</returns>
        [HttpGet("Course/{courseId:int}")]
        [ProducesResponseType(200, Type = typeof(CourseModel))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetCourseById(int courseId)
        {
            var courseObj = _tRepository.GetCourseByCourseId(courseId);
            if (courseObj == null)
            {
                return NotFound();
            }
            return Ok(courseObj);
        }

        #endregion End point to Get a Course by courseId

        #region End point to Get all Courses

        /// <summary>
        /// End point to Get all Courses
        /// </summary>
        /// <param></param>
        /// <returns>A List of course objects</returns>
        [HttpGet("Courses")]
        [ProducesResponseType(200, Type = typeof(CourseModel))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllCourses()
        {
            var courseObj = await _tRepository.GetAllCourses();
            if (courseObj == null)
            {
                return NotFound();
            }
            return Ok(courseObj);
        }
        #endregion End point to Get all Courses

        #region End point to Delete a Course

        /// <summary>
        /// End point to Delete a Course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>Successfully deleted</returns>
        [HttpDelete("DeleteCourse/{courseId:int}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteCourseById(int courseId)
        {
            var courseObj = _tRepository.DeleteCourse(courseId);
            if (courseObj == null)
            {
                return NotFound();
            }
            return Ok(courseObj);
        }

        #endregion End point to Get a Course by courseId



        #region End point to Create a Teacher record

        /// <summary>
        /// End point to Create a Teacher record
        /// </summary>
        /// <param name="tModel"></param>
        /// <returns>"Successfully Created" if successful</returns>
        [HttpPost("AddTeacher")]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddTeacher(TeacherModelDto tModel)
        {
            if (tModel == null)
            {
                return BadRequest(ModelState);
            }
            var teacherObj = _mapper.Map<TeacherModelDto>(tModel);

            if (_tRepository.AddTeacher(teacherObj) == "Successfully Created")
            {
                return Created("api/v{version:apiVersion}/Teacher/AddTeacher", "Successful");
            }
            else
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record for {tModel.FirstName}, check the value of your inputs properly and try again.");
                return StatusCode(500, ModelState);
            }
        }

        #endregion End point to Create a Teacher record

        #region End point to Update a Teacher record
        /// <summary>
        /// End point to Update a Teacher record
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="teacherDto"></param>
        /// <returns>"Updated Successfully" if update was successful</returns>
        [HttpPatch("UpdateTeacher/{teacherId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTeacher(int teacherId, TeacherModelDto teacherDto)
        {
            if (teacherDto == null || teacherId < 1)
            {
                return BadRequest(ModelState);
            }
            if (_tRepository.UpdateTeacher(teacherId, teacherDto) != "Updated Successfully")
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record for {teacherDto.FirstName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated Successfully");
        }
        #endregion End point to Update a Teacher record

        #region End point to Get a Teacher by teacherId

        /// <summary>
        /// End point to Get a Teacher by teacherId
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>A course object</returns>
        [HttpGet("Teacher/{teacherId:int}")]
        [ProducesResponseType(200, Type = typeof(TeacherModel))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetTeacherById(int teacherId)
        {
            var teacherObj = _tRepository.GetTeacherById(teacherId);
            if (teacherObj == null)
            {
                return NotFound();
            }
            return Ok(teacherObj);
        }

        #endregion End point to Get a Teacher by teacherId

        #region End point to Get all Teachers

        /// <summary>
        /// End point to Get all Teachers
        /// </summary>
        /// <param></param>
        /// <returns>A List of Teacher objects</returns>
        [HttpGet("Teachers")]
        [ProducesResponseType(200, Type = typeof(TeacherModel))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teacherObj = await _tRepository.GetAllTeachers();
            if (teacherObj == null)
            {
                return NotFound();
            }
            return Ok(teacherObj);
        }
        #endregion End point to Get all Teachers

        #region End point to Delete a Teacher Record

        /// <summary>
        /// End point to Delete a Teacher Record
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>Successful</returns>
        [HttpDelete("DeleteTeacher/{teacherId:int}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteTeacherById(int teacherId)
        {
            var result = _tRepository.DeleteTeacher(teacherId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        #endregion End point to Delete a Teacher Record

        #region End point for Teacher to Register to take a course

        /// <summary>
        /// End point for Teacher to Register to take a course
        /// </summary>
        /// <param name="teachCourse"></param>
        /// <returns>"Successfully Created" if successful</returns>
        [HttpPost("TeachCourse")]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult TeachCourse(TeachCourseModel teachCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_tRepository.TeachCourse(teachCourse) == "Successfully Created")
            {
                return Created("api/v{version:apiVersion}/Teacher/TeachCourse", "Successfully Created");
            }
            else
            {
                ModelState.AddModelError("", $"Something went wrong, check the value of your inputs properly and try again.");
                return StatusCode(500, ModelState);
            }

        }

        #endregion End point for Teacher to Register to take a course


        #region End point to Get all Courses taught by a teacher

        /// <summary>
        /// End point to Get all Courses taught by a teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>A List of Courses</returns>
        [HttpGet("All-taughtcourses-by-teacher/{teacherId:int}")]
        [ProducesResponseType(200, Type = typeof(TaughtCourses))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllTaughtCoursesByTeacher(int teacherId)
        {
            var courseObj = await _tRepository.GetAllTaughtCoursesByTeacher(teacherId);
            if (courseObj == null)
            {
                return NotFound();
            }
            return Ok(courseObj);
        }
        #endregion End point to Get all Courses taught by a teacher
    }
}
