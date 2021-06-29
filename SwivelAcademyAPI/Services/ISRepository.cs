using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Services
{
    public interface ISRepository
    {
        string CreateStudent(StudentModel studentObj);
        string RegisterCourse(RegisterCourseModel regCourse);
        string UpdateStudent(int studentId, StudentModelDto studentDto);
        StudentModel GetStudentByCourseId(int studentId);
        StudentModel GetStudentById(int studentId);
        Task<IEnumerable<StudentModel>> GetAllStudents();
        string DeleteStudent(int studentId);
        Task<List<RegCourses>> GetAllCoursesByStudent(int studentId);
    }
}
