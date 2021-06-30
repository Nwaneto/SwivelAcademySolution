using Microsoft.Extensions.Configuration;
using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Test
{
    public class SRepositoryTest : ISRepository
    {
        private readonly List<StudentModel> _sDto;

        public SRepositoryTest()
        {
            _sDto = new List<StudentModel>()
            {
                new StudentModel() {
                    StudentId = 3,
                    FirstName = "Mary",
                    LastName="Jane",
                    Address = "2 havard avenue",
                    Gender = "Female"
                },
                new StudentModel() {
                    StudentId = 12,
                    FirstName = "John",
                    LastName="Cena",
                    Address = "12 Lagos road",
                    Gender = "Male"
                },
                new StudentModel() {
                    StudentId = 4,
                    FirstName = "Ann",
                    LastName="Churchill",
                    Address = "6 eastern avenue",
                    Gender = "Female"
                }
            };
        }

        public string CreateProfile(StudentModel studentObj)
        {
            throw new NotImplementedException();
        }

        public string CreateStudent(StudentModel studentObj)
        {
            _sDto.Add(studentObj);
            return "Successfull";
        }

        public string DeleteStudent(int studentId)
        {
            var existing = _sDto.First(a => a.StudentId == studentId);
            _sDto.Remove(existing);
            return "Successful";
        }

        public Task<List<RegCourses>> GetAllCoursesByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            return await Task.FromResult(_sDto);
        }

        public StudentModel GetStudentByCourseId(int studentId)
        {
            return _sDto.Where(a => a.StudentId == studentId).FirstOrDefault();
        }

        public StudentModel GetStudentById(int studentId)
        {
            return _sDto.Where(a => a.StudentId == studentId).FirstOrDefault();
        }

        public string RegisterCourse(RegisterCourseModel regCourse)
        {
            throw new NotImplementedException();
        }

        public string UpdateStudent(int studentId, StudentModelDto studentDto)
        {
            throw new NotImplementedException();
        }

    }
}
