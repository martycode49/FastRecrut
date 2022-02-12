using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FastRecrut.Web.Models;
using FastRecrut.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FastRecrut.Web.Controllers
{
    public class AgentController : Controller
    {
        private readonly IConfiguration _Config;
        private string URLBase
        {
            get
            {
                return _Config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }
        public AgentController(IConfiguration Config)
        {
            _Config = Config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddMusic()
        {
            var agentViewModel = new AgentViewModel();
            List<User> agentList = new List<User>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URLBase + "Agent"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    agentList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            agentViewModel.AgentList = new SelectList(agentList, "Id", "Email");
            return View(agentViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> AddMusic(AgentViewModel agentModelView)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var agent = new User() { Id = agentModelView.Id, Email = agentModelView.Email };
                    var JWToken = HttpContext.Session.GetString("token");
                    if (string.IsNullOrEmpty(JWToken))
                    {
                        ViewBag.MessageError = "You must be authenticate";
                        return View(agentModelView);
                    }
                    string stringData = JsonConvert.SerializeObject(agent);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                    var response = await client.PostAsync(URLBase + "agent", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ViewBag.MessageError = response.ReasonPhrase;
                    return View(agentModelView);

                }

            }
            return View(agentModelView);
        }
    }
}
