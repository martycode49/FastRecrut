using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        public int[] GetRatioLevel()
        {
            int[] LevelList = new int[] { 80,10,10 }; // keep order junior; confirmé, expert 

            using (var fileStream = File.Open(@"C:\TEMP\test.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MyDocument));
                var myDocument = (MyDocument)serializer.Deserialize(fileStream);

                //Console.WriteLine($"My Property : {myDocument.ConfigLevel}");
                //Console.WriteLine($"My Subject : {myDocument.Subject.Value}");
                var index = 0;
                foreach (var item in myDocument.MyList)
                {
                    LevelList[index++] = item;
                    //Console.Write(LevelList[index++] + " > ");
                    //Console.WriteLine(item);
                }
            }
            return LevelList;
        }

    }
}
