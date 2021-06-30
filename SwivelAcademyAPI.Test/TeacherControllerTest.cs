using Microsoft.AspNetCore.Mvc;
using SwivelAcademyAPI.Controllers;
using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SwivelAcademyAPI.Test
{
    public class TeacherControllerTest
    {
        TeacherController _controller;
        ITRepository _service;

        public TeacherControllerTest()
        {
            _service = new TRepositoryTest();
            _controller = new TeacherController(_service);
        }

        [Fact]
        public void GetAllTeachers_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllTeachers();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllTeachers_WhenCalled_ReturnsAllTeacherObject()
        {
            // Act
            var okResult = _controller.GetAllTeachers().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<TeacherModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetTeacherById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetTeacherById(200);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetTeacherById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 3;

            // Act
            var okResult = _controller.GetTeacherById(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public void GetTeacherById_ExistingIdPassed_ReturnsRightRecord()
        {
            // Arrange
            var id = 3;

            // Act
            var okResult = _controller.GetTeacherById(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<TeacherModel>(okResult.Value);
            Assert.Equal(id, (okResult.Value as TeacherModel).TeacherId);
        }

        [Fact]
        public void CreateTeacher_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var teacherToCreate = new TeacherModel()
            {
                LastName = "Nwaneto",
                Address = "2 Lagos Street, Nigeria",
                Gender = "Male"
            };
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var badResponse = _controller.AddTeacher(teacherToCreate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void CreateTeacher_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var teacherToCreate = new TeacherModel()
            {
                TeacherId = 0,
                FirstName = "Chidiebere",
                LastName = "Nwaneto",
                Address = "2 Lagos Street, Nigeria",
                Gender = "Male"
            };

            // Act
            var createdResponse = _controller.AddTeacher(teacherToCreate);

            // Assert
            Assert.IsType<ObjectResult>(createdResponse);
        }

        [Fact]
        public void Remove_NotExistingTeacherIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 300;

            // Act
            var badResponse = _controller.DeleteTeacherById(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingTeacherIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingTeacherId = 3;

            // Act
            var okResponse = _controller.DeleteTeacherById(existingTeacherId);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }

        [Fact]
        public void GetAllCourses_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllCourses();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllCourses_WhenCalled_ReturnsAllCourseObject()
        {
            // Act
            var okResult = _controller.GetAllCourses().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<CourseModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetCourseById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetCourseById(200);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetCourseById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 10;

            // Act
            var okResult = _controller.GetCourseById(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

        }

        [Fact]
        public void GetCourseById_ExistingIdPassed_ReturnsRightRecord()
        {
            // Arrange
            var id = 10;

            // Act
            var okResult = _controller.GetCourseById(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<CourseModel>(okResult.Value);
            Assert.Equal(id, (okResult.Value as CourseModel).CourseId);
        }

        [Fact]
        public void CreateCourse_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var teacherToCreate = new TeacherModel()
            {
                LastName = "Nwaneto",
                Address = "2 Lagos Street, Nigeria",
                Gender = "Male"
            };
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var badResponse = _controller.AddTeacher(teacherToCreate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void CreateCourse_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var courseToCreate = new CourseModel()
            {
                CourseId = 0,
                CourseName = "Programming",
                CourseSyllabus = "Lorem Ipsum"
            };

            // Act
            var createdResponse = _controller.CreateCourse(courseToCreate);

            // Assert
            Assert.IsType<ObjectResult>(createdResponse);
        }

        [Fact]
        public void Remove_NotExistingCourseIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 300;

            // Act
            var badResponse = _controller.DeleteCourseById(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingCourseIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingCourseId = 10;

            // Act
            var okResponse = _controller.DeleteCourseById(existingCourseId);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }


    }
}
