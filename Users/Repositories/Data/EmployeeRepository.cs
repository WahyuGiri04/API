
using API.Models;
using API.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Users.Base.Url;

namespace Users.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<Register>> GetEmployees()
        {
            /*Employee entity = null;

            using (var response = await httpClient.GetAsync(request + "Profile/" + NIK))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<Employee>(apiResponse);
            }
            return entity;*/

            List<Register> entities = new List<Register>();

            using (var response = await httpClient.GetAsync(request + "Profile/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Register>>(apiResponse);
            }
            return entities;
        }
        public async Task<List<Register>> GetEmployeesByNIK(string id)
        {
            List<Register> entities = new List<Register>();

            using (var response = await httpClient.GetAsync(request + "CariData?nik=" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Register>>(apiResponse);
            }
            return entities;
        }
        public HttpStatusCode DeleteEmployees(string id)
        {
            var result = httpClient.DeleteAsync(request + "Hapus?nik=" + id).Result;
            return result.StatusCode;
        }
        public HttpStatusCode Post(RegisterVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "Register", content).Result;
            return result.StatusCode;
        }

        //public async Task<JWTokenVM> Auth(LoginVM login)
        //{
        //    JWTokenVM token = null; 

        //    StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
        //    var result = await httpClient.PostAsync(request + "Sign", content);

        //    string apiResponse = await result.Content.ReadAsStringAsync();
        //    token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);

        //    return token;
        //}
    }
}
