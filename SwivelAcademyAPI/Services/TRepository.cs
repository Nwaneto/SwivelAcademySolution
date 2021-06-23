using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Services
{
    public class TRepository : ITRepository
    {
        public string CreateCourse(CourseModel courseObj)
        {
            throw new NotImplementedException();
        }

        public string DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseModel>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public CourseModel GetCourseByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        public string UpdateCourse(int courseId, CourseModelDto courseDto)
        {
            throw new NotImplementedException();
        }
    }
}
