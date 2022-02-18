using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Web.Services;
using FastRecrut.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FastRecrut.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizService quizService = new QuizService();

        // GetAll: /api/Quiz
        public async Task<IActionResult> Index()
        {
            var quizList = await quizService.GetAll();
            return View(quizList);
        }

        // Create: /api/Create
        public IActionResult Create()
        {
            var quizVM = new QuizViewModel();
            return View(quizVM);
        }

        // Create : /api/Create
        [HttpPost]
        public async Task<IActionResult> Create(QuizViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await quizService.Create(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // Update : /api/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            var quiz = await quizService.Get((int)id);
            if (quiz == null) return NotFound();

            return View(quiz);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(QuizViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await quizService.Update(vm.Id, vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }


    }
}
