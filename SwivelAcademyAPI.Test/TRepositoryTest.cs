using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using SwivelAcademyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Test
{
    class TRepositoryTest : ITRepository
    {
        private readonly List<TeacherModel> _tDto;
        private readonly List<CourseModel> _cDto;

        public TRepositoryTest()
        {
            _tDto = new List<TeacherModel>()
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
            _cDto = new List<CourseModel>() 
            {
                new CourseModel() {
                    CourseId = 10,
                    CourseName = "History",
                    CourseSyllabus = "Lorem Ipsum"
                },
                new CourseModel() {
                    CourseId = 11,
                    CourseName = "Geography",
                    CourseSyllabus = "Lorem Ipsum"
                },
                new CourseModel() {
                    CourseId = 12,
                    CourseName = "Anatomy",
                    CourseSyllabus = "Lorem Ipsum"
                }
            };
        }

        public string AddTeacher(TeacherModel teacherObj)
        {
            _tDto.Add(teacherObj);
            return "Successfull";
        }

        public string CreateCourse(CourseModel courseObj)
        {
            _cDto.Add(courseObj);
            return "Successfull";
        }

        public string DeleteCourse(int courseId)
        {
            var existing = _cDto.First(a => a.CourseId == courseId);
            _cDto.Remove(existing);
            return "Successful";
        }

        public string DeleteTeacher(int teacherId)
        {
            var existing = _tDto.First(a => a.TeacherId == teacherId);
            _tDto.Remove(existing);
            return "Successful";
        }

        public async Task<IEnumerable<CourseModel>> GetAllCourses()
        {
            return await Task.FromResult(_cDto);
        }

        public Task<List<TaughtCourses>> GetAllTaughtCoursesByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeacherModel>> GetAllTeachers()
        {
            return await Task.FromResult(_tDto);
        }

        public CourseModel GetCourseByCourseId(int courseId)
        {
            return _cDto.Where(a => a.CourseId == courseId).FirstOrDefault();
        }

        public TeacherModel GetTeacherById(int teacherId)
        {
            return _tDto.Where(a => a.TeacherId == teacherId).FirstOrDefault();
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
