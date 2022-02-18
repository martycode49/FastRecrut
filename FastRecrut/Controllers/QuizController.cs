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

        // GET: api/Quiz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quizzes = await _quizService.GetAllAsync();
            return Ok(quizzes);
        }

        // GET: api/Quiz/filter with filters => Subject(string) , Level(int)
        [HttpGet("filter/{level}/{subject}")]
        public async Task<IActionResult> GetBySubjectLevel(int level, string subject)
        {
            var quizzes = await _quizService.GetAllQuizWithFilters(subject,level);
            return Ok(quizzes);
        }

        // GET: api/Quiz/filter with filters => Subject(string)
        [HttpGet("filter/{subject}")]
        public async Task<IActionResult> GetBySubject(int level, string subject)
        {
            var quizzes = await _quizService.GetAllQuizWithSubject(subject);
            return Ok(quizzes);
        }

        // GET: api/Quiz/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var quiz = await _quizService.GetByIdAsync(id);
                if (quiz == null) return NotFound("Data not available !");
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Quiz/Create
        [HttpPost]
        public async Task<IActionResult> Create(Quiz quiz)
        {
            var newquiz = await _quizService.AddAsync(quiz);
            return Ok(quiz);
        }

        // POST: api/Quiz/5
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
