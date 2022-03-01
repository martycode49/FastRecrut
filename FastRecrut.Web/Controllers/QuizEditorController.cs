using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Web.Models;
using FastRecrut.Web.Services.Abstract;
using FastRecrut.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.Web.Controllers
{
    public class QuizEditorController : Controller
    {
        private IQuizEditorService _quizEditorService;
        public QuizEditorController(IQuizEditorService quizEditorService)
        {
            _quizEditorService = quizEditorService;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["SubjSortParm"] = String.IsNullOrEmpty(sortOrder) ? "subj_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "level" ? "level_desc" : "level";
            
            IEnumerable<QuizViewModel> quizList = await _quizEditorService.GetAllQuizAsync();

            switch (sortOrder)
            {
                case "subj_desc":
                    quizList = quizList.OrderByDescending(s => s.Subject);
                    break;
                case "level":
                    quizList = quizList.OrderBy(s => s.Level);
                    break;
                case "level_desc":
                    quizList = quizList.OrderByDescending(s => s.Level);
                    break;
                default:
                    quizList = quizList.OrderBy(s => s.Subject);
                    break;
            }
            return View(quizList);
        }


    }
}
