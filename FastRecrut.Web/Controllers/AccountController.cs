using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FastRecrut.Web.Models;
using FastRecrut.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FastRecrut.Web.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IConfiguration _Config;
        private string URLBase
        {
            get
            {
                return _Config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }

        public AccountController(IConfiguration Config)
        {
            _Config = Config;
        }

        
        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var user = new User();
                    user.Email = loginViewModel.Email;
                    user.Password = loginViewModel.Password;
                    string stringData = JsonConvert.SerializeObject(user);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URLBase + "Agent/authenticate", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<System.IdentityModel.Tokens.Jwt.JwtPayload>(stringJWT);
                        var jwtString = jwt["token"].ToString();
                        HttpContext.Session.SetString("token", jwtString);//username

                        HttpContext.Session.SetString("email", jwt["email"].ToString());

                        ViewBag.Message = jwt["email"].ToString() + " logged in successfully!";
                    }

                }
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Register()
        {
            var register = new RegisterViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    string stringData = JsonConvert.SerializeObject(register);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URLBase + "Agent/register", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<System.IdentityModel.Tokens.Jwt.JwtPayload>(stringJWT);
                        var jwtString = jwt["token"].ToString();
                        HttpContext.Session.SetString("token", jwtString);//username

                        HttpContext.Session.SetString("email", jwt["email"].ToString());

                        ViewBag.Message = jwt["email"].ToString() + " logged in successfully!";
                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }
    }
}
