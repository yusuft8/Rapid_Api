using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AkademiQRapidApi.Controllers
{
    public class DailyFilmController : Controller
    {
        public async Task<IActionResult> Index()
        {

         
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rottentomato.p.rapidapi.com/today-recomendations"),
                Headers =
    {
        { "x-rapidapi-key", "a587c278cfmsh772574fdc79a834p178403jsna5ef07f7ed59" },
        { "x-rapidapi-host", "rottentomato.p.rapidapi.com" },
    },
            };
            var response = await client.SendAsync(request);
            var jsonBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var values = JsonSerializer.Deserialize<Models.DailyFilmModel.Rootobject>(jsonBody, options);
            return View(values);  // ← Bu satır olmalı, Content() değil

        }
    }
}
