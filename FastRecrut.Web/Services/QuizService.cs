using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Web.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FastRecrut.Web.Services
{
    public class QuizService
    {
        private HttpClient httpClient;

        public QuizService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44378/api/");
        }
       
        public async Task<IList<QuizViewModel>> GetAll()
        {
            var response = await this.httpClient.GetAsync( $"Quiz");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quiz = JsonConvert.DeserializeObject<List<QuizViewModel>>(responseBody);

                return quiz;
            }

            return new List<QuizViewModel>();
        }

        public async Task<IList<QuizViewModel>> GetBySubject(string subject)
        {
            var response = await this.httpClient.GetAsync($"Quiz/filter/{subject}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quiz = JsonConvert.DeserializeObject<List<QuizViewModel>>(responseBody);

                return quiz;
            }

            return new List<QuizViewModel>();
        }

        public async Task<QuizViewModel> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"Quiz/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quiz = JsonConvert.DeserializeObject<QuizViewModel>(responseBody);

                return quiz;
            }

            return null;
        }

        public async Task<bool> Create(QuizViewModel quiz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quiz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"Quiz", content);

            if (response.IsSuccessStatusCode)
            {   
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, QuizViewModel quiz)
        {
             var content = new StringContent(JsonConvert.SerializeObject(quiz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"Quiz", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {   
            var response = await this.httpClient.DeleteAsync($"Quiz/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
