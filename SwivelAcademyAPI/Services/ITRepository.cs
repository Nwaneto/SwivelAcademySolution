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
        Task<IEnumerable<CourseModel>> GetAllCourses();
        string DeleteCourse(int courseId);
        string AddTeacher(TeacherModel teacherObj);
        string UpdateTeacher(int teacherId, TeacherModelDto teacherDto);
        TeacherModel GetTeacherById(int teacherId);
        Task<List<TeacherModel>> GetAllTeachers();
        string DeleteTeacher(int teacherId);
        string TeachCourse(TeachCourseModel teachCourse);
        Task<List<TaughtCourses>> GetAllTaughtCoursesByTeacher(int teacherId);
    }
}
