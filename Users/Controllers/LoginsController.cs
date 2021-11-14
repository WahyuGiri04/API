using API.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Base.Controllers;
using Users.Repositories.Data;

namespace Users.Controllers
{
    public class LoginsController : BaseController<LoginVM, LoginRepository, string>
    {
        private readonly LoginRepository repository;
        public LoginsController(LoginRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorEmail()
        {
            return View();
        }
        public IActionResult ErrorPassword()
        {
            return View();
        }
        public IActionResult Error401()
        {
            return View();
        }
        public IActionResult ErrorNotFound()
        {
            return View();
        }
        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwtToken = await repository.Auth(login);
            var token = jwtToken.Token;
            var pesan = jwtToken.Messages;

            if (token == "")
            {
                if(pesan == "0")
                {
                    return RedirectToAction("ErrorEmail", "Logins");
                }
                else
                {
                    return RedirectToAction("ErrorPassword", "Logins");
                }
            }

            HttpContext.Session.SetString("JWToken", token);
            //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
            //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");

            //return RedirectToAction("index", "dashboard");

            return RedirectToAction("index", "Home");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Logins");
        }
    }
}
