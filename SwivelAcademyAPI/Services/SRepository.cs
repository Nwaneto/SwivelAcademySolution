using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Services
{
    public class SRepository : ISRepository
    {
        public string CreateProfile(StudentModel studentObj)
        {
            throw new NotImplementedException();
        }

        public string DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public List<StudentModel> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public StudentModel GetStudentByCourseId(int studentId)
        {
            throw new NotImplementedException();
        }

        public string UpdateStudent(int studentId, StudentModelDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
