using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WideWorldImporters.Server.Services;

namespace WideWorldImporters.Server.Manager
{
    public class ChatGptManager
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<string> GetChatGPTResponse(string userInput)
        {

            //string apiKey = "RRRsk-proj-zyZaxWm6C3QRAlAAruVSAoyM-VjTbB3vXA5VzlGlTHwFtDF2Kw87JuzNjWamYeRjGwMLJl3MHtT3BlbkFJQ2FfzDtkMMeJhuXKn4XEvzXLuRBecOym5Szt-b3LeEkppbtrrwZFOyPOFM9dYOYHin0atwmioA"; // Ta clé API OpenAI
            string endpoint = "https://api.openai.com/v1/chat/completions";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-3.5-turbo", //-- gpt -4", // ou "gpt-3.5-turbo"
                messages = new[]
                {
                new { role = "system", content = "Tu es un assistant utile." },
                new { role = "user", content = userInput }
            }
                //,
                //max_tokens = 200,
                //temperature = 0.7
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            var result = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(result);
            return json.choices[0].message.content.ToString();

            //var response = await _httpClient.PostAsync(endpoint, content);
            //var result = await response.Content.ReadAsStringAsync();
            //if (result != null)
            //{
            //    dynamic json = JsonConvert.DeserializeObject(result);
            //    return json != null ? json.choices[0].message.content.ToString() : null;
            //}
            //return null;
        }
    }
}

