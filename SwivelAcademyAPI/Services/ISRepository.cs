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
        string UpdateStudent(int studentId, StudentModelDto studentDto);
        StudentModel GetStudentByCourseId(int studentId);
        Task<IEnumerable<StudentModel>> GetAllStudents();
        string DeleteStudent(int studentId);
    }
}
