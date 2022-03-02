using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Web.Helpers;
using FastRecrut.Web.Models;
using FastRecrut.Web.Services.Abstract;
using FastRecrut.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
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
        public async Task<IActionResult> Index(
            string sortOrder, 
            string currentFilter, 
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SubjSortParm"] = String.IsNullOrEmpty(sortOrder) ? "subj_desc" : "";
            ViewData["LevelSortParm"] = sortOrder == "level" ? "level_desc" : "level";
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            

            IEnumerable<QuizViewModel> quizList = await _quizEditorService.GetAllQuizAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                quizList = quizList.Where(s => s.Question.Contains(searchString)
                                       || s.Subject.Contains(searchString));
            }

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
            int pageSize = 10;
            return View(PaginatedList<QuizViewModel>.Create(quizList.AsQueryable(), pageNumber ?? 1, pageSize));
        }
        /// <summary>
        /// Render Teacher List
        /// </summary>
        /// <returns></returns>
        public object PartialRatioLevel()
        {
            return PartialView(_quizEditorService.GetRatioLevel());
        }
        
    }
}
