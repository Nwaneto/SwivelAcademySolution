using SwivelAcademyWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyWEB.Services
{
    public interface ITRepository
    {
        public Task<string> GetTaughtCourses(string url, int userId);
        public Task<string> GetAllCourses(string url);
        public Task<bool> TeachCourse(string url, TeachCourseModel reg);
    }
}
