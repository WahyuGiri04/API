using API.Base;
using API.Models;
using System.Text;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Viewmodels;
using API.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public IConfiguration _configuration;
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var cek = employeeRepository.Register(registerVM);
            if (cek == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, messege = "Data Berhasil Ditambahkan" });
            }
            if (cek == 2)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Data Gagal di tambahkan ( NIK Sudah ada ) !!!" });
            }
            if (cek == 3)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Data Gagal Ditambahkan ( Email Sudah di Gunakan ) !!!!" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Data Gagal Ditambahkan ( No Hp sudah di gunakan )!!!" });
            }
        }

        //[Authorize(Roles = "Director, Manager")]
        [HttpGet]
        [Route("Profile")]
        public ActionResult<Register> GetProfile()
        {
            var result = employeeRepository.GetProfile();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(new { Status = HttpStatusCode.NotFound, messege = "Data Tidak ada !!!" });
            }
        }

        //[Route("Register/{nik}")]
        //[HttpGet("{nik}")]
        [HttpGet]
        [Route("CariData")]
        public ActionResult<Register> GetProfile(string NIK)
        {
            var result = employeeRepository.GetProfile(NIK);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(new { Status = HttpStatusCode.NotFound, messege = "Data tidak ditemukan !!!" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var cek = employeeRepository.Login(loginVM);
            if (cek == "email")
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Gagal Login email tidak terdaftar !!!" });
            }
            if (cek == "password")
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Gagal Login password salah!!!" });
            }
            else
            {
                var data = employeeRepository.GetProfile(cek);
                return Ok(new { status = HttpStatusCode.OK, data, messege = "Berhasil Login" });
            }
        }

        [HttpPost]
        [Route("Sign")]
        public ActionResult Sign(LoginVM loginVM)
        {
            var cek = employeeRepository.Sign(loginVM);
            if (cek == 2)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Gagal Login email tidak terdaftar !!!" });
            }
            if (cek == 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Gagal Login password salah!!!" });
            }
            else
            {
                //mengambil rolename dari employe yang berhasil login
                var getRoles = employeeRepository.GetRole(loginVM.Email);
                var data = new LoginDataVM()
                {
                    Email = loginVM.Email
                };
                //payload
                var claims = new List<Claim>
                {
                    new Claim("Email", data.Email)
                };
                foreach (var a in getRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, a.ToString()));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //Header
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10), //set Experied time
                    signingCredentials: signIn
                    );
                var idtoken = new JwtSecurityTokenHandler().WriteToken(token); //generate token
                claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                return Ok(new { status = HttpStatusCode.OK, idtoken, messege = "Berhasil Login" });
            }
        }

        /*[Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("TestJWT")]
        public ActionResult TestJWT()
        {
            return Ok("Test Berhasil");
        }*/

        [Authorize(Roles = "Director")]
        [HttpPost]
        [Route("AddManager")]
        public ActionResult AddManager(AccountRole accountRole)
        {
            /*return Ok("Hore bisa !!!");*/
            var result = employeeRepository.AddManager(accountRole);
            if (result == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, messege = "Data Berhasil Ditambah" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, messege = "Data gagal di tambah (role sudah ada)" });
            }
        }

        [HttpDelete]
        [Route("Hapus")]
        public ActionResult Hapus(string NIK)
        {
            try
            {
                employeeRepository.Hapus(NIK);
                return Ok(new { status = HttpStatusCode.OK, message = $"Berhasil Menghapus NIK : {NIK} " });
            }
            catch (Exception)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = $"Gagal Menghapus NIK : {NIK} data tidak ditemukan" });
            }
        }

        [HttpGet]
        [Route("GetGender")]
        public ActionResult<GetGender> GetGender()
        {
            var result = employeeRepository.GetGender();
            return Ok(new { status = HttpStatusCode.OK, result, messege = "Berhasil" });
        }

        [HttpGet]
        [Route("GetRole")]
        public ActionResult GetRole()
        {
            var result = employeeRepository.GetRole();
            return Ok(new { status = HttpStatusCode.OK, result, messege = "Berhasil" });
        }

        [HttpGet]
        [Route("GetSalary")]
        public ActionResult GetSalary()
        {
            var result = employeeRepository.GetSalary();
            return Ok(new { status = HttpStatusCode.OK, result, messege = "Berhasil" });
        }
    }
}
