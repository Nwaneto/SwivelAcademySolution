using Microsoft.Extensions.Configuration;
using SwivelAcademyAPI.Models;
using SwivelAcademyAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Services
{
    public class TRepository : ITRepository
    {
        private readonly string _connString;
        public TRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("SwivelAcademyConnString");
        }
        public string AddTeacher(TeacherModelDto teacherObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_CreateTeacher", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", teacherObj.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", teacherObj.LastName);
                        cmd.Parameters.AddWithValue("@Address", teacherObj.Address);
                        cmd.Parameters.AddWithValue("@Gender", teacherObj.Gender);
                        string response = "";
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response = reader["Result"].ToString();
                            }
                        }
                        con.Close();
                        return response;
                    }
                }
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public string CreateCourse(CourseModel courseObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_CreateCourse", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.Parameters.AddWithValue("@CourseTitle", courseObj.CourseName);
                        cmd.Parameters.AddWithValue("@CourseSyllable", courseObj.CourseSyllabus);
                        string response = "";
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response = reader["Result"].ToString();
                            }
                        }
                        con.Close();
                        return response;
                    }
                }
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public string DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public string DeleteTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseModel>> GetAllCourses()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_GetAllCourses", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var response = new List<CourseModel>();
                        await con.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                CourseModel cmDto = new CourseModel
                                {
                                    
                                    CourseId = Convert.ToInt32(reader["CourseID"]),
                                    CourseName = reader["CourseTitle"].ToString(),
                                    CourseSyllabus = reader["CourseSyllable"].ToString()
                                }; 
                                response.Add(cmDto);
                            }
                        }
                        await con.CloseAsync();
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TeacherModel>> GetAllTeachers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_GetAllTeachers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var response = new List<TeacherModel>();
                        await con.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                TeacherModel tDto = new TeacherModel
                                {
                                    TeacherId = Convert.ToInt32(reader["TeacherId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Gender = reader["Gender"].ToString()
                                };
                                response.Add(tDto);
                            }
                        }
                        await con.CloseAsync();
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CourseModel GetCourseByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        public TeacherModel GetTeacherById(int teacherId)
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
