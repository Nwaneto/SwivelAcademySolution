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
        string CreateProfile(StudentModel studentObj);
        string UpdateStudent(int studentId, StudentModelDto studentDto);
        StudentModel GetStudentByCourseId(int studentId);
        List<StudentModel> GetAllStudents();
        string DeleteStudent(int studentId);
    }
}
