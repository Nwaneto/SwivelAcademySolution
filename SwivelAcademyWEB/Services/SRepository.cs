using Microsoft.Extensions.Configuration;
using SwivelAcademyWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwivelAcademyWEB.Services
{
    public class SRepository : ISRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        public SRepository(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _config = configuration;
        }

        public async Task<string> GetAllCourses(string url)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return jsonString;
                }

                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return "Error encountered";
            }
        }

        public async Task<string> GetRegisteredCourses(string url, int userId)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url + userId);

                var client = _clientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return jsonString;
                }

                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return "Error encountered";
            }
        }
    }
}
