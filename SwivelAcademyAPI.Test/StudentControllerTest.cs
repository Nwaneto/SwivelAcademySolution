using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwivelAcademyAPI;
using SwivelAcademyAPI.Controllers;
using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Services;
using Xunit;

namespace SwivelAcademyAPI.Test
{
    public class StudentControllerTest
    {
        StudentController _controller;
        ISRepository _service;
        //IConfiguration _conFig;

        public StudentControllerTest()
        {
            _service = new SRepositoryTest();
            _controller = new StudentController(_service);
        }

        [Fact]
        public void GetAllStudents_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllStudents();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllStudents_WhenCalled_ReturnsAllStudentObject()
        {
            // Act
            var okResult = _controller.GetAllStudents().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<StudentModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetStudentById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetStudentById(200);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetStudentById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 3;

            // Act
            var okResult = _controller.GetStudentById(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

        }

        [Fact]
        public void GetStudentById_ExistingIdPassed_ReturnsRightRecord()
        {
            // Arrange
            var id = 3;

            // Act
            var okResult = _controller.GetStudentById(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<StudentModel>(okResult.Value);
            Assert.Equal(id, (okResult.Value as StudentModel).StudentId);
        }

        [Fact]
        public void CreateStudent_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var studentToCreate = new StudentModel()
            {
                LastName = "Nwaneto",
                Address = "2 Lagos Street, Nigeria",
                Gender = "Male"
            };
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var badResponse = _controller.CreateStudent(studentToCreate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void CreateStudent_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var studentToCreate = new StudentModel()
            {
                StudentId = 0,
                FirstName = "Chidiebere",
                LastName = "Nwaneto",
                Address = "2 Lagos Street, Nigeria",
                Gender = "Male"
            };

            // Act
            var createdResponse = _controller.CreateStudent(studentToCreate);

            // Assert
            Assert.IsType<ObjectResult>(createdResponse);
        }

        [Fact]
        public void Remove_NotExistingStudentIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 300;

            // Act
            var badResponse = _controller.DeleteStudentById(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingStudentIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingStudentId = 3;

            // Act
            var okResponse = _controller.DeleteStudentById(existingStudentId);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }
    }
}
