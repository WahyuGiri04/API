using API.Models;
using API.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Users.Base.Controllers;
using Users.Repositories.Data;

namespace Users.Controllers
{
    //[Authorize]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository repository;
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetEmployees()
        {
            var result = await repository.GetEmployees();
            return Json(result);
        }

        public async Task<JsonResult> GetEmployeesByNIK(string id)
        {
            var result = await repository.GetEmployeesByNIK(id);
            return Json(result);
        }

        public JsonResult DeleteEmployees(string id)
        {
            var result = repository.DeleteEmployees(id);
            return Json(result);
        }

        public JsonResult Register(RegisterVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost("Auth/")]
        //public async Task<IActionResult> Auth(LoginVM login)
        //{
        //    var jwtToken = await repository.Auth(login);
        //    var token = jwtToken.Token;

        //    if (token == null)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }

        //    HttpContext.Session.SetString("JWToken", token);
        //    //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
        //    //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");

        //    //return RedirectToAction("index", "dashboard");

        //    return RedirectToAction("index", "Home");
        //}

        //[Authorize]
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("index", "Logins"); 
        //}
    }
}
