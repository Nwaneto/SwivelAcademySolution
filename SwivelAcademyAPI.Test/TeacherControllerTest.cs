using SwivelAcademyAPI.Controllers;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyAPI.Test
{
    class TeacherControllerTest
    {
        TeacherController _controller;
        ITRepository _service;

        public TeacherControllerTest()
        {
            _service = new TRepositoryTest();
            _controller = new TeacherController(_service);
        }
    }
}
