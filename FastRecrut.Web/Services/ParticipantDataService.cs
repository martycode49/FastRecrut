using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Web.ViewModels;
using Newtonsoft.Json;

namespace FastRecrut.Web.Services
{
    public class ParticipantDataService
    {
        private HttpClient httpClient;

        public ParticipantDataService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44378/api/");
        }

        public async Task<IList<ParticipantDataViewModel>> GetAll()
        {
            var response = await this.httpClient.GetAsync($"ParticipantData");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var pdata = JsonConvert.DeserializeObject<List<ParticipantDataViewModel>>(responseBody);

                return pdata;
            }

            return new List<ParticipantDataViewModel>();
        }

        public async Task<IList<ParticipantDataViewModel>> GetByParticipant(int participantId)
        {
            var response = await this.httpClient.GetAsync($"ParticipantData/filter/{participantId}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var pdata = JsonConvert.DeserializeObject<List<ParticipantDataViewModel>>(responseBody);

                return pdata;
            }

            return new List<ParticipantDataViewModel>();
        }

        public async Task<ParticipantDataViewModel> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"ParticipantData/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var pdata = JsonConvert.DeserializeObject<ParticipantDataViewModel>(responseBody);

                return pdata;
            }

            return null;
        }

        public async Task<bool> Create(ParticipantDataViewModel pdata)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pdata), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"ParticipantData", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, ParticipantDataViewModel pdata)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pdata), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"ParticipantData", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"ParticipantData/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}

