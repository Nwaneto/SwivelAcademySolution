using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Services
{
    public interface ITRepository
    {
        string CreateCourse(CourseModel courseObj);
        string UpdateCourse(int courseId, CourseModelDto courseDto);
        CourseModel GetCourseByCourseId(int courseId);
        Task<List<CourseModel>> GetAllCourses();
        string DeleteCourse(int courseId);
    }
}
