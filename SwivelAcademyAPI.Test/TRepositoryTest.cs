using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Test
{
    class TRepositoryTest : ITRepository
    {
        private readonly List<TeacherModel> _sDto;

        public TRepositoryTest()
        {
            _sDto = new List<TeacherModel>()
            {
                new TeacherModel() {
                    TeacherId = 3,
                    FirstName = "Mary",
                    LastName="Jane",
                    Address = "2 havard avenue",
                    Gender = "Female"
                },
                new TeacherModel() {
                    TeacherId = 12,
                    FirstName = "John",
                    LastName="Cena",
                    Address = "12 Lagos road",
                    Gender = "Male"
                },
                new TeacherModel() {
                    TeacherId = 4,
                    FirstName = "Ann",
                    LastName="Churchill",
                    Address = "6 eastern avenue",
                    Gender = "Female"
                }
            };
        }

        public string AddTeacher(TeacherModelDto teacherObj)
        {
            throw new NotImplementedException();
        }

        public string CreateCourse(CourseModelDto courseObj)
        {
            throw new NotImplementedException();
        }

        public string DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public string DeleteTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseModel>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<List<TaughtCourses>> GetAllTaughtCoursesByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherModel>> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public CourseModel GetCourseByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        public TeacherModel GetTeacherById(int teacherId)
        {
            throw new NotImplementedException();
        }

        public string TeachCourse(TeachCourseModel teachCourse)
        {
            throw new NotImplementedException();
        }

        public string UpdateCourse(int courseId, CourseModelDto courseDto)
        {
            throw new NotImplementedException();
        }

        public string UpdateTeacher(int teacherId, TeacherModelDto teacherDto)
        {
            throw new NotImplementedException();
        }
    }
}
