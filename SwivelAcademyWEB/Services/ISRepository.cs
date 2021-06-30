using SwivelAcademyWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyWEB.Services
{
    public interface ISRepository
    {
        
        public Task<string> GetRegisteredCourses(string url, int userId);
        public Task<string> GetAllCourses(string url);
    }
}
