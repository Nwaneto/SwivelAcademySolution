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
    public class SRepository : ISRepository
    {
        private readonly string _connString;
        public SRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("SwivelAcademyConnString");
        }
        public string CreateStudent(StudentModel studentObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_CreateStudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", studentObj.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", studentObj.LastName);
                        cmd.Parameters.AddWithValue("@Address", studentObj.Address);
                        cmd.Parameters.AddWithValue("@Gender", studentObj.Gender);
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

        public string DeleteStudent(int studentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_DeleteStudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        string response = "";
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response = reader["Result"].ToString();
                            }
                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return "Failed";
            }
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand("STP_GetAllStudents", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var response = new List<StudentModel>();
                        await con.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                StudentModel sDto = new StudentModel
                                {
                                    StudentId = Convert.ToInt32(reader["StudentId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Gender = reader["Gender"].ToString()
                                };
                                response.Add(sDto);
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
