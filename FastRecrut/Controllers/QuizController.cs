using System;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FastRecrut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        //private readonly IMapper _mapper; // for Dto using

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET: Quiz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quizzes = await _quizService.GetAllAsync();
            return Ok(quizzes);
        }

        // GET: Quiz with filters => Subject(string) , Level(int)
        [HttpGet("filter/{level}/{subject}")]
        public async Task<IActionResult> GetByIdSubject(int level, string subject)
        {
            var quizzes = await _quizService.GetAllAsync();
            return Ok(quizzes.Where(q=>q.Level == level && q.Subject == subject));
        }

        // GET: QuizController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var quiz = await _quizService.GetByIdAsync(id);
                if (quiz == null) return BadRequest("Data not available !");
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Quiz/Create
        [HttpPost]
        public async Task<IActionResult> Create(Quiz quiz)
        {
            var newquiz = await _quizService.AddAsync(quiz);
            return Ok(quiz);
        }

        // POST: Quiz/Edit/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Quiz quiz)
        {
            var updateQuiz = _quizService.GetByIdAsync(id).Result;
            _quizService.Update(quiz);
            return NoContent();
        }

        // POST: Quiz/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedQuiz = _quizService.GetByIdAsync(id).Result;
            _quizService.Remove(deletedQuiz);
            return NoContent();
        }
    }
}
