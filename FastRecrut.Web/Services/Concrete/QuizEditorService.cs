using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FastRecrut.Web.Services.Abstract;
using FastRecrut.Web.ViewModels;
using Newtonsoft.Json;

namespace FastRecrut.Web.Services.Concrete
{
    public class QuizEditorService : IQuizEditorService
    {
        private HttpClient httpClient;

        public QuizEditorService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44378/api/");
        }

        public async Task<List<QuizViewModel>> GetAllQuizAsync()
        {
            var response = await this.httpClient.GetAsync($"Quiz");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quiz = JsonConvert.DeserializeObject<List<QuizViewModel>>(responseBody);

                return quiz;
            }
            return new List<QuizViewModel>();
        }
    }
}
